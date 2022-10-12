# Certbot Custom Hooks (Windows)
Simple C# scripts that will stop the nginx process for the certificate renewal and start it again afterwards.

**Currently only works if the nginx path is C\\:nginx-1.23.0**
## Usage
You will find both `.exe` files in the path <br/> 
`Certbot-Nginx-Hooks/hook/bin/Release/netcoreapp3.1/hook.exe` <br/>
***hook*** being either ***preHook*** or ***postHook*** and `hook.exe` being either `preHook.exe` or `postHook.exe`. <br/>

Certbot requires custom hooks to be `.exe` files which it then executes when renewing. 
Therefore you will have to create links of the `.exe` files and put them in there respective directory:

Assuming you installed certbot directly to your drive (C:\\):
- The `postHook-link.lnk` goes into C:\\Certbot\\renewal-hooks\\post\\
- The `preHook-link.lnk` goes into C:\\Certbot\\renewal-hooks\\pre\\

You might have to give the links permissions/rights under `properties -> security`.

Start your nginx server, then do a `certbot renew --dry-run` to verify that everything works as expected.
