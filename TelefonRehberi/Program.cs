using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace TelefonRehberi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=postgres;Password=postgres;Database=postgres";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            // INSERT INTO public."PhoneBook"("Name", "Surname", "PhoneNumber", "Email") VALUES('Oykun', 'YENAL', '5546902', 'oykun@deu.edu.tr');
            //"SELECT * FROM \"SwitchKonum\"";
            //string sql = "Insert INTO \"Cihaz\"(geom, koordinat, marka, bina, aciklama) VALUES (ST_SetSRID(ST_MakePoint(27.20792,38.36976),4326), '', 'Cisco', 'o ye', 'Web Sayfasından Geldi')"
            cmd.CommandText = "INSERT INTO \"PhoneBook\"(name, surname, phonenumber, email) VALUES('Orhan Oykun', 'YENAL', '5546902', 'oykun@deu.edu.tr')";
            cmd.ExecuteNonQuery();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
