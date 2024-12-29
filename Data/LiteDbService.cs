using Aura.Models;
using LiteDB;


namespace Aura.Data
{
    public class LiteDbService
    {
        private readonly LiteDatabase _database;
        private readonly string _dbPath = "App_Data/aura.db";

        // Método para inicializar la colección (insertando un usuario si está vacía)
        public void Initialize()
        {
            var collection = _database.GetCollection<User>("Users"); // Asegura que la colección de usuarios esté disponible

            if (!collection.Exists(x => x.Id == 1)) // Verifica si existe un usuario con Id = 1
            {
                collection.Insert(new User { Name = "Admin", Email = "admin@example.com" }); // Inserta un usuario de ejemplo
            }
        }

        //......................................................................

        public LiteDbService()
        {
            // Inicia la base de datos al crear la instancia de LiteDbService
            _database = new LiteDatabase(_dbPath);
        }

        // Método para obtener todos los usuarios
        public IEnumerable<User> GetAllUsers()
        {
            var collection = _database.GetCollection<User>("Users"); // Obtenemos la colección de "Users"
            return collection.FindAll();
        }

        // Método para insertar un objeto
        public void Insert<T>(T item, string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);
            collection.Insert(item);
        }

        // Método para actualizar un objeto
        public void Update<T>(T item, string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);
            collection.Update(item);
        }

        public void Delete<T>(int id, string collectionName)
        {
            var collection = _database.GetCollection<T>(collectionName);
            var user = collection.FindById(id); // Encuentra el objeto por su Id
            if (user != null)
            {
                collection.Delete(id); // Elimina el objeto encontrado
            }
        }

        //......................................................................
    }
}
