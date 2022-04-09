using System;
using modul7_1302201135;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Json;

namespace modul7_1302201135
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig bank = new BankTransferConfig();
            bank.transferBank();
        }
    }
}