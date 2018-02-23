using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class BinarySerialization
    {
        public static void SerializeTXT(string fileLocation, string fileDestination = "D:\\")
        {
            fileDestination = getDestination( fileLocation);
            Data sample = new Data();//створюєм об'єкт контейнер
            sample.folder = getFolder(fileLocation);//отримуємо папку і "підпапку"
            sample.text = File.ReadAllText(fileLocation);//заповняємо поле інформацією з файлу

            using (FileStream fileStream = new FileStream(fileDestination
             + getFileNamr(fileLocation) + ".dat", FileMode.Create))// ініцалізуємо об'єкт 
            {
                Console.WriteLine("Data from file; " + sample.text);
                Console.WriteLine("Folder from file; " + sample.folder);
                BinaryFormatter formatter = new BinaryFormatter();// ініцалізуємо об'єкт 
                formatter.Serialize(fileStream, sample);//виконуємо сералізацію в двійковому форматі
            }
        }
        public static void Deserialize(string fileLocation, string fileDestination = "D:\\")
        {
            fileLocation = fileLocation.Substring(0, fileLocation.Length - 4);
            using (FileStream fileStream = new FileStream(fileLocation + ".dat", FileMode.Open))// відкриваємо файл
            {
                BinaryFormatter formatter = new BinaryFormatter(); //ініцалізуємо об'єкт 
                Data deserializedSample = (Data)formatter.Deserialize(fileStream);//отримуємо інформацію
                Console.WriteLine(deserializedSample.text);
                Console.WriteLine(deserializedSample.folder);
                saveFale(fileDestination, deserializedSample, getFileNamr(fileLocation));//зберігаємо документ в новому місці
            }
        }
        public static void saveFale(string fileDestination, Data data, string fileName)
        {
            fileDestination += data.folder;//додаємо попередні папки до нового розташування файлу
            if (Directory.Exists(fileDestination))// перевіряємо чи існує даний шлях
            {
                //якщо так то зберігаємо файл
                File.WriteAllText(fileDestination + fileName + ".txt", data.text);
                Console.WriteLine("New file destination " + fileDestination + fileName + ".txt");
                return;
            }
            else
            {
                //якщо ні то створюємо дані папки і в них зберігаємо файл
                DirectoryInfo di = Directory.CreateDirectory(fileDestination);
                File.WriteAllText(fileDestination + fileName + ".txt", data.text);
                Console.WriteLine("New file destination " + fileDestination + fileName + ".txt");
                return;
            }

        }
        public static string getFolder(string fileLocation) 
        {
            try{
                char slash = '\\';
                int endIndex, midlIndex, startIndex = fileLocation.LastIndexOf(slash);

                string buffer2, buffer = fileLocation.Substring(startIndex, fileLocation.Length - startIndex);
                buffer = fileLocation.Replace(buffer, "");

                endIndex = buffer.LastIndexOf(slash);
                buffer2 = buffer.Substring(endIndex, buffer.Length - endIndex);
                buffer2 = buffer.Replace(buffer2, "");

                midlIndex = buffer2.LastIndexOf(slash);
                buffer = buffer2.Substring(midlIndex, buffer2.Length - midlIndex);
                buffer = buffer2.Replace(buffer, "");

                return fileLocation.Substring(buffer.Length, fileLocation.Length - startIndex + 1);
            }catch(Exception)
            {
                return "";
            }
       }
        public static string getFileNamr(string fileLocation)
        {
            int startIndex = fileLocation.LastIndexOf('\\');
            string bufer = fileLocation.Substring(startIndex, fileLocation.Length - startIndex);
            if (bufer.LastIndexOf('.') == -1)
            {
                return bufer;
            }
            else
            {
                startIndex = bufer.LastIndexOf('.');
                return bufer.Substring(0, startIndex);
            }

        }
        public static string getDestination(string fileLocation)
        {
            int startIndex = fileLocation.LastIndexOf('\\');
            return fileLocation.Substring(0, fileLocation.Length - (fileLocation.Length-startIndex));
           
        }
    }
}
