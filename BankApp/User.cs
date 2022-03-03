using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;

namespace BankApp
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string balance { get; set; }

        public string[] getAWSCred()
        {
            var creds = System.IO.File.ReadAllLines("");
            string credID = creds[0];
            string secretID = creds[1];

            return new[] { credID, secretID };
        }

        public bool isValidUser(string username, string password)
        {
            string credID = getAWSCred()[0];
            string secretID = getAWSCred()[1];
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(credID, secretID);
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.USEast1);
            Console.WriteLine("Client Created");
            string tableName = "userInfo";

            GetItemRequest request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "username", new AttributeValue { S = username } } },
            };
            var result = client.GetItem(request);

            Dictionary<string, AttributeValue> item = result.Item;

            try
            {
                if (item["username"] != null)
                    if (username == item["username"].S && password == item["password"].S)
                    {
                        this.username = username;
                        this.password = password;
                        this.balance = item["balance"].N;
                        return true;
                    }
                return false;
            }
            catch
            {
                return false;
            }

        }


        public bool checkIfUserExists(string givenUsername)
        {

            string credID = getAWSCred()[0];
            string secretID = getAWSCred()[1];
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(credID, secretID);
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.USEast1);
            string tableName = "userInfo";

            GetItemRequest request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "username", new AttributeValue { S = givenUsername } } },
            };
            var result = client.GetItem(request);
            Console.WriteLine("Request sent");

            Dictionary<string, AttributeValue> item = result.Item;

            try
            {
                if (item["username"].S == givenUsername)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }

        }

        public void registerUser(string givenUsername, string givenPassword)
        {
            string credID = getAWSCred()[0];
            string secretID = getAWSCred()[1];
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(credID, secretID);
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.USEast1);
            string tableName = "userInfo";

            var request = new PutItemRequest
            {
                TableName = tableName,
                Item = new Dictionary<string, AttributeValue>()
      {
          { "username", new AttributeValue { S = givenUsername }},
          { "password", new AttributeValue { S = givenPassword }},
          { "balance", new AttributeValue { N = "0" }}
      }

            };

            this.username = givenUsername;
            this.password = givenPassword;
            this.balance = "0";
            client.PutItem(request);
            Console.WriteLine("Request sent");
        }


        //Update balance function to call when deposit withdraw or transfer has been made.

        public void updateBalance(string username, string newBalance, string currentBalance)
        {
            string credID = getAWSCred()[0];
            string secretID = getAWSCred()[1];
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(credID, secretID);
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.USEast1);
            string tableName = "userInfo";

            var request = new UpdateItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "username", new AttributeValue { S = username } } },
                ExpressionAttributeNames = new Dictionary<string, string>()
    {
        {"#B", "balance"},
    },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
    {
        {":b",new AttributeValue { N = newBalance}},
    },

                UpdateExpression = "SET #B = :b"
            };
            var response = client.UpdateItem(request);
            Console.WriteLine("Request sent");

        }

        public string getUserBalance(string username)
        {
            string credID = getAWSCred()[0];
            string secretID = getAWSCred()[1];
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(credID, secretID);
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, Amazon.RegionEndpoint.USEast1);
            string tableName = "userInfo";

            GetItemRequest request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "username", new AttributeValue { S = username } } },
            };
            var result = client.GetItem(request);
            Console.WriteLine("Request sent");

            Dictionary<string, AttributeValue> item = result.Item;
            string balance = item["balance"].N;
            this.balance = balance;
            return this.balance;
        }
    }

}
