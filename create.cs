// using UnityEngine;
// using MongoDB.Driver;
// using MongoDB.Bson;
// using System.Threading.Tasks;
// public class SceneSaver : MonoBehaviour
// {
//     private MongoClient client;
//     private IMongoDatabase database;
//     private IMongoCollection<BsonDocument> collection;

//     void Start()
//     {
//         // Connect to MongoDB Atlas
//         string connectionString = "mongodb+srv://nepalsss008:virtual@cluster0.dvrigrb.mongodb.net/"; // Replace this with your MongoDB Atlas connection string
//         client = new MongoClient(connectionString);
//         database = client.GetDatabase("Apartment");
//         collection = database.GetCollection<BsonDocument>("Maps");
//     }

//     public async void SaveScene()
//     {
//         // Serialize scene data to BSON
//         BsonDocument sceneData = SerializeSceneData();

//         // Insert data into MongoDB collection
//         await collection.InsertOneAsync(sceneData);

//         Debug.Log("Scene data saved to MongoDB Atlas.");
//     }

//     private BsonDocument SerializeSceneData()
//     {
//         // Placeholder function to serialize scene data to BSON
//         // You would need to implement this according to your specific requirements
//         return new BsonDocument("example", "data");
//     }

//     public async void LoadScene()
//     {
//         // Retrieve data from MongoDB collection
//         BsonDocument savedData = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();

//         // Deserialize data and apply to scene
//         DeserializeSceneData(savedData);

//         Debug.Log("Scene data loaded from MongoDB Atlas.");
//     }

//     private void DeserializeSceneData(BsonDocument data)
//     {
//         // Placeholder function to deserialize scene data from BSON
//         // You would need to implement this according to your specific requirements
//     }
// }
