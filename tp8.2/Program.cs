using System;
using System.Text.Json;

internal class Program
{
    public static void Main(string[] args)
    {
        CovidConfig.suhuconfig cs = new CovidConfig.suhuconfig();

        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai celcius : ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? : ");
        int demam = int.Parse(Console.ReadLine());


        if (((cs.config.suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
            (cs.config.suhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5)) &&
            demam < cs.config.hari)
        {
            Console.WriteLine(cs.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(cs.config.pesan_ditolak);
        }

        cs.ubahsatuan();
    }
}