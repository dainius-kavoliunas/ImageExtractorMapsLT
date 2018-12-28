using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace ImageMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            //int minX = 316, minY = 571, maxX = 329, maxY = 588, scale = 10;
            //int minX = 10191, minY = 18685, maxX = 10206, maxY = 18699, scale = 15;
            //double minX = 81544, minY = 149539, maxX = 81669, maxY = 149593, scale = 18;
            double minX = 20382, minY = 37383, maxX = 20420, maxY = 37401, scale = 16;


            if (!Directory.Exists($"{scale}")) Directory.CreateDirectory($"{scale}");

            for (var x = minX; x <= maxX; x++)
            {
                Bitmap bitmap = new Bitmap(width: (int)(256 * (maxY - minY + 1)), height: 256);


                for (var y = minY; y <= maxY; y++)
                {

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {

                        Image img = Image.FromFile(
                            $"C:\\Users\\daini\\Desktop\\ImageExtractor\\ImageExtractor\\bin\\Debug\\{scale}\\{x}.{y}.jpg");

                        g.DrawImage(img, (int)(y - minY) * 256, 0);

                        img.Dispose();
                    }
                }

                bitmap.Save($"{scale}\\" + x + "result.jpg");
            }

            Bitmap bitmap2 = new Bitmap(width: 256 * (int)(maxY - minY + 1), height: (int)(maxX - minX + 1) * 256);

            using (Graphics g = Graphics.FromImage(bitmap2))
            {

                for (var x = minX; x <= maxX; x++)
                {
                Console.WriteLine((x - minX) / (maxX - minX) * 100);

                    Image img = Image.FromFile($"{scale}\\" + x + "result.jpg");

                    g.DrawImage(img, 0, (int)(x-minX) * 256 );

                    img.Dispose();
                }
            }



            bitmap2.Save($"{scale}\\{scale}.jpg");

        }
    }
}
