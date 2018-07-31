using System;
using System.IO;
using System.Reflection;
using AirCraft;

namespace StronglyNamedAssembly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AirPlane.Flight();
            Helicopter.Flight();
            Ufo.Flight();
            
            FileStream fs = File.Open("../../Key.snk", FileMode.Open);
            StrongNameKeyPair k = new StrongNameKeyPair(fs);
            Console.WriteLine($"\nPublic key:\n{BitConverter.ToString(k.PublicKey)}");
            fs.Close();

            Console.ReadKey();
        }
    }
}
