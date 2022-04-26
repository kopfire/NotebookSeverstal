using System.Collections.Generic;
using System.IO;

namespace Notebook
{
    internal class Database
    {
        public static List<string> database = new();

        private readonly string path = @"..\..\..\Database\database.txt";

        /// <summary>
        /// Чтение из "базы данных" (текстовый документ)
        /// </summary>
        public void Read()
        {
            using StreamReader reader = new(path);
            database = new List<string>(reader.ReadToEnd().Split(":-:"));
        }

        /// <summary>
        /// Запись в "базу данных" (текстовый документ)
        /// </summary>
        public void Write()
        {
            using StreamWriter writer = new(path, false);
            writer.Flush();
            for (int i = 0; i < database.Count; i++)
            {
                writer.Write(database[i]);
                if (i != database.Count - 1)
                    writer.Write(":-:");
            }
        }
    }
}
