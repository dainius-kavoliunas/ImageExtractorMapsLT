using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImageExtractor
{
    class Program
    {
        static void Main(string[] args)
        {

            //double minX = 10129, minY = 18291, maxX = 10537, maxY = 18826;
            //double minX = 5064, minY = 9145, maxX = 5268, maxY = 9413, scale = 14;
            //double minX = 316, minY = 571, maxX = 329, maxY = 588, scale = 10;
            //double minX = 1266, minY = 2286, maxX = 1317, maxY = 2353, scale = 12;

            //double minX = 1285, minY = 2310, maxX = 1317, maxY = 2353, scale = 12;
            //int minX = 10191, minY = 18685, maxX = 10206, maxY = 18699, scale = 15;
            //double minX = 81544, minY = 149539, maxX = 81669, maxY = 149593, scale = 18;
            double minX = 20382, minY = 37383, maxX = 20420, maxY = 37401, scale = 16;

            var url =
                "https://beta.maps.lt/arcgis-maps/rest/services/Basemaps/maps_ortofoto_wmerc/MapServer/tile/{0}/{1}/{2}";


            if (!Directory.Exists($"{scale}")) Directory.CreateDirectory($"{scale}");

            for (var y = minY; y <= maxY; y++)
            {

                Console.WriteLine((y - minY) / (maxY - minY) * 100);


                for (var x = minX; x <= maxX; x++)
                {
                    var newUrl = string.Format(url, scale, x, y);

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(newUrl, $"{scale}/{x}.{y}.jpg");
                    }

                }
            }
        }
    }
}
