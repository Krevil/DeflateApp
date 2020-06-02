using System;
using System.IO;
using System.IO.Compression;

namespace DeflateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string mode = args[0];
                if (mode == "d")
                {
                    string input = args[1];
                    string output = args[2];
                    using FileStream fs1 = File.OpenRead(input);
                    {
                        using FileStream fs2 = File.Create(output);
                        {
                            using DeflateStream ds1 = new DeflateStream(fs1, CompressionMode.Decompress, true); //decompress
                            {
                                ds1.CopyTo(fs2);
                            }
                        }
                    }
                }
                if (mode == "c")
                {
                    string input = args[1];
                    string output = args[2];
                    using FileStream fs1 = File.OpenRead(input);
                    {
                        using FileStream fs2 = File.OpenWrite(output);
                        {
                            using DeflateStream ds1 = new DeflateStream(fs2, CompressionMode.Compress, true); //compress
                            {
                                fs1.CopyTo(ds1);
                            }
                        }
                    }
                }
                if (mode != "c" && mode != "d")
                {
                    Console.WriteLine("Something went wrong. Here's the arguments:");
                    Console.WriteLine("Correct arguments: ");
                    Console.WriteLine("d input output" + "     " + "Decompresses the input file to the output");
                    Console.WriteLine("c input output" + "     " + "Compresses the input file to the output");
                }
                if (mode == "help" || mode == "commands")
                {
                    Console.WriteLine("Need some help with the arguments?");
                    Console.WriteLine("Correct arguments: ");
                    Console.WriteLine("d input output" + "     " + "Decompresses the input file to the output");
                    Console.WriteLine("c input output" + "     " + "Compresses the input file to the output");
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong. Here's the arguments:");
                Console.WriteLine("Correct arguments: ");
                Console.WriteLine("d input output" + "     " + "Decompresses the input file to the output");
                Console.WriteLine("c input output" + "     " + "Compresses the input file to the output");
            }
        }
    }
}
