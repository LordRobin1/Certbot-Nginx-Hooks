# Certbot Custom Hooks (Windows)
Simple C# scripts that will stop the nginx process for the certificate renewal and start it again afterwards.

## Usage
You will find the `.exe` files in the paths <br/> 
`Certbot-Nginx-Hooks/preHook/bin/Debug/netcoreapp3.1/preHook.exe` <br/> and <br/>
`Certbot-Nginx-Hooks/postHook/bin/Debug/netcoreapp3.1/postHook.exe`. <br/>

Certbot requires custom hooks to be `.exe` files which it then executes when renewing. 
Therefore you will have to create links of the `.exe` files and put them in there respective directory:

Assuming you installed certbot directly to your drive (`C:\`):
- The `postHook-link.lnk` goes into C:\\Certbot\\renewal-hooks\\post\\
- The `preHook-link.lnk` goes into C:\\Certbot\\renewal-hooks\\pre\\

You might have to give the links permissions/rights under `properties -> security`.

### appsettings.json
You have to specify the directory of your `nginx.exe` (for example: `C:\nginx-1.22.0`):
```json
{
    "AppSettings": {
        "NginxPath": "your-nginx-path"
    }
}
```

Start your nginx server, then do a `certbot renew --dry-run` to verify that everything works as expected.
