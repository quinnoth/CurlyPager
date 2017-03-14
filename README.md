# CurlyPager
This is a web service designed to simplify sending notifications from bash and powershell scripts.

You can either GET or POST to the service to send an email. This is non-compliant with HTTP verbs, but the intent of this application is to be easy to use from scripts, not RESTful.

It's an ASP.NET application, so to deploy you'll need to put it on a Windows box somewhere with IIS.

# How to Use
To utilise this tool:

1) Compile and publish it to an IIS server.
2) Adjust the web.config to point to your SMTP host (like gmail) with the correct credentials.
3) Change your scripts to just call the service to send an email, e.g. curl "http://curlypager.foo.com/email/?subject=ERROR%20Backup%20Failed&body=From%20Host%20-%20dc1.foo.com"

# What's next
* It'd be nice to send out SMS/Push notifications. Perhaps controllers will be added for Twilio support and other services.
* Adding more capabilites for messages might be useful.
