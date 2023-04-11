namespace modul8_1302210123
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppConfig Transfer = new AppConfig();
            if(Transfer.config.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer");
            }
            else
            {
                Console.WriteLine("Masukan jumlah uang yang akan ditransfer");
            }

            int Jumlah;
            try
            {
                Jumlah = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Jumlah = 0;
            }

            int biayaTransfer;
            if (Jumlah <= Transfer.config.transfer.threshold)
            {
                biayaTransfer = Transfer.config.transfer.threshold;
            } else
            {
                biayaTransfer = Transfer.config.transfer.high_fee;
            }

            if (Transfer.config.lang == "en") {
                Console.WriteLine("Transfer fee = " + biayaTransfer);
                Console.WriteLine("Total amount = " + (biayaTransfer + Jumlah));
            }
            else {
                Console.WriteLine("Biaya transfer = " + biayaTransfer);
                Console.WriteLine("Total Biaya = " + (biayaTransfer + Jumlah));
            }

            if (Transfer.config.lang == "en") {
                Console.WriteLine("Select transfer method:");
            }
            else {
                Console.WriteLine("Pilih metode transfer:");
            }

            for (int i = 0; i < Transfer.config.methods.Count(); i++)
            {
                Console.WriteLine((i + 1)+ Transfer.config.methods[i]);
            }

            Console.Write("> ");
            int metodeTransfer;
            try
            {
                metodeTransfer = int.Parse(Console.ReadLine());
            } catch (FormatException)
            {
                metodeTransfer = 1;
            }

            if (Transfer.config.lang == "en")
            {
                Console.Write("Please type " + Transfer.config.confirmation.en + " to confirm the transaction: ");
            }
            else
            {
                Console.Write("Ketik " + Transfer.config.confirmation.id + " untuk mengkonfirmasi transaksi: ");
            }

            string inputKonfirmasi = Console.ReadLine();

            if (Transfer.config.lang == "en")
            {
                if (inputKonfirmasi.Equals(Transfer.config.confirmation))
                {
                    Console.WriteLine("The transfer is completed");
                } 
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else
            {
                if (inputKonfirmasi.Equals(Transfer.config.confirmation))
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
    }
}