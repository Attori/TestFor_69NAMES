using System;
using System.IO.Ports;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TestFor_69NAMES
{
    public class Test_for_69_Names
    {
        public static void Main(string[] args)
        {
            var openMenu = new Menu();
            Console.WriteLine("Выберите пункт согласно заданию от [1] до [5]");
            Console.WriteLine();
            openMenu.DoAction();
        }
      
    }
}

