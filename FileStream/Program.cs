using File.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FileStream
            //string filePath = Path.Combine(@"C:\Users\Fatime\Desktop\Ap204Directory","text.txt");
            //string anotherPath = Path.Combine(@"C:\Users\Fatime\Desktop\Ap204Directory", "Salam");
            //string anotherFilePath = Path.Combine(@"C:\Users\Fatime\Desktop\Ap204Directory", "Salam","datas.txt");
            //string DbPath = Path.Combine(@"C:\Users\Fatime\Desktop\Ap204Directory", "Salam","db.txt");
            //string privatPh = Path.Combine(@"C:\Users\Fatime\Desktop\Ap204Directory", "Salam","private.txt");

            //StreamWriter streamWriter = new StreamWriter(anotherFilePath,true);
            //for (int i = 0; i < 5; i++)
            //{
            //    streamWriter.WriteLine("Product " + i);
            //}
            //streamWriter.Close();

            //StreamReader streamReader = new StreamReader(anotherFilePath);
            //string data = streamReader.ReadToEnd();
            //Console.WriteLine(data);

            //streamReader.Close();
            //using (StreamWriter streamWriter = new StreamWriter(anotherFilePath, true))
            //{
            //    for (int i = 5; i <= 10; i++)
            //    {
            //    streamWriter.WriteLine("Product " + i);
            //    }
            //    streamWriter.Close();
            //}
            //using (StreamReader streamReader = new StreamReader(anotherFilePath))
            //{
            //    string data = streamReader.ReadToEnd();
            //    Console.WriteLine(data);
            //}
            //streamWriter.Flush();

            //Console.WriteLine(filePath);
            //string path = @"C:\Users\Fatime\Desktop\Ap204Directory";
            //Directory.CreateDirectory(anotherPath);
            //File.Create(anotherFilePath);
            //File.Create(DbPath);
            //File.Create(privatPh);
            //foreach (var item in Directory.GetFiles(anotherPath))
            //{
            //    Console.WriteLine(item);
            //}
            //File.Create(anotherPath);
            //Directory.Delete(path, true);
            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}
            //else
            //{
            //    Console.WriteLine("Bele bir file tapilmadi");
            //}

            //FileStream fileStream = new FileStream("path example",FileMode.Create,FileAccess.Write,FileShare.Read);
            //string text = "This is Fatima";
            //byte[] byteArr = Encoding.UTF8.GetBytes(text);
            //foreach (var item in byteArr)
            //{
            //    Console.WriteLine(item);
            //}
            //fileStream.Write(byteArr, 0, byteArr.Length);
            //fileStream.Close();
            #endregion
            #region Serialize && Deserialize
            Computer computer = new Computer 
            { 
                Id = 1,
                Brand = "Asus",
                Ram = "8gb",
                GraphicCart = "Rtx2090",
                Price = 3000
            };
            Computer computer1 = new Computer
            {
                Id = 1,
                Brand = "Lenovo",
                Ram = "8gb",
                GraphicCart = "Ryzen 7",
                Price = 2500
            };
            Computer computer2 = new Computer
            {
                Id = 1,
                Brand = "Msi",
                Ram = "32gb",
                GraphicCart = "Rtx3090",
                Price = 2000
            };
            Computer computer3 = new Computer
            {
                Id = 1,
                Brand = "Acer",
                Ram = "8gb",
                GraphicCart = "UHDGraphics",
                Price = 1500
            };
            OrderItem orderItem = new OrderItem { Id = 1, Computer = computer, Price = computer.Price };
            OrderItem orderItem1 = new OrderItem { Id = 2, Computer = computer1, Price = computer1.Price };
            OrderItem orderItem2 = new OrderItem { Id = 3, Computer = computer2, Price = computer2.Price };
            OrderItem orderItem3 = new OrderItem { Id = 4, Computer = computer3, Price = computer3.Price };

            Order order = new Order
            {
                Id = 1,
                OrderItems = new System.Collections.Generic.List<OrderItem>()
                {
                    orderItem,
                    orderItem1,
                    orderItem2,
                    orderItem3
                },
                TotalPrice = 12500.99
            };
            List<OrderItem> orderItems = new List<OrderItem>()
                {
                    orderItem,
                    orderItem1,
                    orderItem2,
                    orderItem3
                };

            var orderStr = JsonConvert.SerializeObject(order);
            //Console.WriteLine(orderStr);

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Fatime\source\repos\FileStream\FileStream\Datas\data.json"))
            {
                sw.Write(orderStr);
            }
            string result;
            using (StreamReader sr = new StreamReader(@"C:\Users\Fatime\source\repos\FileStream\FileStream\Datas\data.json"))
            {
                result = sr.ReadLine();
            }
            //Console.WriteLine(result);
            Order orderDeserialise = JsonConvert.DeserializeObject<Order>(result);
            //Console.WriteLine(orderDeserialise.TotalPrice);
            foreach (var item in orderDeserialise.OrderItems)
            {
                Console.WriteLine(item.Computer.Brand);
            }
            #endregion
        }
    }
}
