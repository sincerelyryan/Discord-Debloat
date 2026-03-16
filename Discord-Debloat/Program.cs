using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Discord_Debloat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool looped = true;
            while(looped == true)
            {
                Console.Title = "Discord Debloater";
                Console.WriteLine("a super simple discord debloater.");
                Console.WriteLine("\n Debloat Discord? (y/n)");
                string input = Console.ReadLine();
                string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string discordpath = Path.Combine(localappdata + "\\Discord");
                string discordexepath = Path.Combine(discordpath + "\\app-1.0.9228");
                string modules = Path.Combine(discordexepath + "\\modules");
                string locales = Path.Combine(discordexepath + "\\locales");
                string discordAppData = Path.Combine(appdata + "\\discord");
                string[] files = { modules, locales, discordpath + "\\Update.exe", discordpath + "\\SquirrelSetup.log" };
                string[] directories = { discordpath + "\\packages", discordpath + "\\download", modules + "\\discord_cloudsync-1", modules + "\\discord_dispatch-1", modules + "\\discord_erlpack-1", modules + "\\discord_spellcheck-1", };
                string[] cachefiles = {discordAppData  + "\\Cache", discordAppData + "\\Code Cache", discordAppData + "\\GPUCache" };
                if (input == "y")
                {

                    if (Process.GetProcessesByName("Discord").Length > 0)
                    {
                        Console.WriteLine("close discord!");
                        looped = true;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("this will delete the updater to discord, you will have to create a new shortcut.");
                        Console.WriteLine("\n after the debloat is done, it will open the file path to the exe");
                        Console.WriteLine("\n press any key to continue");
                        Console.ReadKey();
                        Console.WriteLine(localappdata);
                        foreach (string i in files)
                        {
                            if (File.Exists(i))
                            {
                                File.Delete(i);
                            }
                            else
                            {
                                Console.WriteLine("these files dont exist, continuing debloat");
                            }
                        }
                        foreach (string i in directories)
                        {
                            if (Directory.Exists(i))
                            {
                                Directory.Delete(i, true);
                            }
                            else
                            {
                                Console.WriteLine("these directories dont exist, continuing debloat");
                            }
                            
                        }

                        foreach (string i in  cachefiles)
                        {
                            if (Directory.Exists(i))
                            {
                                Directory.Delete(i, true);
                            }
                            else
                            {
                                Console.WriteLine("these cache directories dont exist, continuing debloat");
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("do you want to delete all language files except english US? (y/n)");
                        string input2 = Console.ReadLine();
                        if (input2 == "y")
                        {
                            if (Directory.Exists(locales))
                            {
                                File.Copy(locales + "\\en-US.pak", discordexepath + "\\en-US.pak");
                                Directory.Delete(locales, true);
                                Directory.CreateDirectory(locales);
                                File.Move(discordexepath + "\\en-US.pak", locales + "\\en-US.pak");
                                File.Delete(discordexepath + "\\en-US.pak");
                                Console.Clear();
                                Console.WriteLine("discord has been fully debloated");
                                Console.WriteLine("press any key to exit");
                                Process.Start(discordexepath);
                                Console.ReadKey();

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("language files dont exist");
                                Console.WriteLine("discord has been fully debloated");
                                Console.WriteLine("press any key to exit");
                                Process.Start(discordexepath);
                                Console.ReadKey();
                            }

                        }
                        else
                        {
                            Console.WriteLine("discord has been debloated!");
                            Process.Start(discordexepath);

                        }
                    }
                    
                }
                if (input == "n")
                {
                    Console.WriteLine("ok bye");
                    Environment.Exit(0);
                }
                else
                {
                    looped = true;
                    Console.Clear();
                }


            }


        }
    }
}
