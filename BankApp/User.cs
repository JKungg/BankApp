using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;

namespace BankApp
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string balance { get; set; }

        public bool isValidUser(string username, string password)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "userInfo";

            GetItemRequest request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "username", new AttributeValue { S = username } } },
            };
            var result = client.GetItem(request);

            Dictionary<string, AttributeValue> item = result.Item;


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

        public void registerUser(string givenUsername, string givenPassword)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
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
        }
    }

    //User user1 = new User();
    //User user2 = new User();
    //user1.registeruser(name,password)
    //User.validateUser(user1);

}
