// See https://aka.ms/new-console-template for more information
using tpmodul8_1302213005;
public class program
{
    private static void Main(string[] args)
    {
        AppConfig appCovid = new AppConfig();

        appCovid.config.UbahSatuan();




        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai ");
        Console.WriteLine(appCovid.config.satuan_suhu);

        String suhu = Console.ReadLine();
        double dsuhu = Convert.ToDouble(suhu);

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejalan demam?");

        String hari = Console.ReadLine();
        int ihari = Convert.ToInt32(hari);

        if (appCovid.config.satuan_suhu == "celcius")
        {
            if ((dsuhu >= 36.5 && dsuhu <= 37.5) && ihari < appCovid.config.batas_hari_demam)
            {
                Console.WriteLine(appCovid.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(appCovid.config.pesan_ditolak);
            }
        }
        else if (appCovid.config.satuan_suhu == "fahrenheit")
        {
            if ((dsuhu >= 97.7 && dsuhu <= 99.5) && ihari < appCovid.config.batas_hari_demam)
            {
                Console.WriteLine(appCovid.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(appCovid.config.pesan_ditolak);
            }
        }
    }
}