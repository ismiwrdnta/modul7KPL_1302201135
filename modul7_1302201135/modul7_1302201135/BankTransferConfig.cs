using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Json;


namespace modul7_1302201135
{
    public class BankTransferConfig
    {
        public string lang { get; set;}
        public int threshold { get; set;}
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public List<string> methods { get; set; };
        public string confirmation{get; set;}

		public void readJson()
		{
			var file = File.OpenText("bank_transfer_config.json");

			JsonElement fileJson = JsonSerializer.Deserialize<JsonElement>(file.ReadToEnd());

			lang = fileJson.GetProperty("lang").GetString();
			threshold = fileJson.GetProperty("transfer").GetProperty("threshold").GetInt32();
			low_fee = fileJson.GetProperty("transfer").GetProperty("low_fee").GetInt32();
			high_fee = fileJson.GetProperty("transfer").GetProperty("high_fee").GetInt32();
			foreach (var item in fileJson.GetProperty("methods").EnumerateArray().ToList())
			{
				methods.Add(item.GetString());
			}
			confirmation = fileJson.GetProperty("confirmation").GetProperty(lang).GetString();			
		}

		public void transferBank()
        {
			if (lang == "en")
            {
				Console.WriteLine("Please insert the amount of money to transfer");
			}else if (lang == "id")
            {
				Console.WriteLine("Masukkan jumlah uang yang ingin di-transfer:");
			}

			int transfer = int.Parse(Console.ReadLine());
			int biayaTransfer;

			if(transfer <= threshold)
            {
				 biayaTransfer = low_fee;
            }else if(transfer > threshold)
            {
				 biayaTransfer = high_fee;
            }
			int totalTransfer;
			totalTransfer = biayaTransfer + transfer;

			if (lang == "en")
			{
				Console.WriteLine($"Transfer fee = {0}", biayaTransfer);
				Console.WriteLine($"Total amount = {1}", totalTransfer);
				Console.WriteLine("Select transfer method: ");
			}
			else if (lang == "id")
			{
				Console.WriteLine($"Biaya transfer = {2}", biayaTransfer);
				Console.WriteLine($"Total biaya = {3}", totalTransfer);
				Console.WriteLine("Pilih metode transfer: ");
			}

			for (int i = 0; i < methods.Count; i++)
			{
				Console.WriteLine($"{6}. {7}", i + 1, methods[i]);
			}
			int method = int.Parse(Console.ReadLine());

			if (lang == "en")
			{
				Console.WriteLine($"Please type {4} to confirm the transaction:", confirmation);
			}
			else if (lang == "id")
			{
				Console.WriteLine($"Silahkan ketik {5} untuk mengkonfirmasi transaksi", confirmation);
			}
			
			string inputC = Console.ReadLine();
			if (inputC == confirmation)
			{
				if (lang == "en")
				{
					Console.WriteLine("The transfer is completed");
				}
				else if (lang == "id")
				{
					Console.WriteLine("Proses transfer berhasil");
				}
			}
			else 
			{
				if (lang == "en")
				{
					Console.WriteLine("Transfer is cancelled");
				}
				else if (lang == "id")
				{
					Console.WriteLine("Transfer anda dibatalkan");
				}
			}
		}













	}
}

