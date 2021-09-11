using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Security.Cryptography;

namespace BOFNET.Bofs
{
    public class LNKCreate : BeaconObject
    {
        public LNKCreate(BeaconApi api) : base(api) { }
        public override void Go(string[] args)
        {
            if (args.Length >= 2)
            {
                try
                {
                    BeaconConsole.WriteLine("[+] Creating LNK file...");
                    string lnkPath = args[0].ToString();
                    string targetPath = args[1].ToString();
                    BeaconConsole.WriteLine(String.Format("Path: {0}", lnkPath));
                    BeaconConsole.WriteLine(String.Format("Target: {0}", targetPath));

                    IWshShell wsh = new WshShell();
                    IWshShortcut lnk = (IWshShortcut)wsh.CreateShortcut(lnkPath);
                    lnk.TargetPath = targetPath;

                    lnk.WindowStyle = 7; // Minimised

                    if (args.Length > 2)
                    {
                        string lnkArguments = args[2].ToString();
                        BeaconConsole.WriteLine(String.Format("Arguments: {0}", lnkArguments));
                        lnk.Arguments = lnkArguments;
                    }

                    if (args.Length > 3)
                    {
                        string lnkIconPath = args[3].ToString();
                        BeaconConsole.WriteLine(String.Format("Icon: {0}", lnkIconPath));
                        lnk.IconLocation = lnkIconPath;
                    }

                    if (args.Length > 4)
                    {
                        string lnkDescription = args[4].ToString();
                        BeaconConsole.WriteLine(String.Format("Description: {0}", lnkDescription));
                        lnk.Description = lnkDescription;
                    }

                    lnk.Save();

                    using (FileStream lnk_stream = System.IO.File.OpenRead(lnkPath))
                    {
                        var sha256_hasher = new SHA256Managed();
                        byte[] checksum = sha256_hasher.ComputeHash(lnk_stream);
                        BeaconConsole.WriteLine(String.Format("SHA-256: {0}", BitConverter.ToString(checksum).Replace("-", String.Empty)));
                    }

                    BeaconConsole.WriteLine("\n[+] LNK created successfully!");

                }
                catch (Exception e)
                {
                    BeaconConsole.WriteLine(String.Format("[!] Error: {0}", e.ToString()));
                }

            }
            else
            {
                BeaconConsole.WriteLine("[!] Error: Invalid number of arguments provided");
            }
        }
    }
}