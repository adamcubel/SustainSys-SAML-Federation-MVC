## Overview
This project demonstrates the **Sustainsy.Saml2** library, which adds SAML2P support to ASP.NET web sites, allowing the web site to act as a SAML2 Service Provider.

It uses the Sustainsys notional Identity Provider (IDP), which can be a stand-in replacement for testing purposes.

Follow the directions on the Systainsys site to configure your ASP.NET app: https://saml2.sustainsys.com/en/2.0/configuration.html

## In Brief:
- Most modifications will be in your Web.config file
- Configure the ReturnURL in the "sustainsys.saml2 ..." Web.config section. It's set by default to localhost, which is appropriate for testing locally.
- Add a reference to Sustainsys.Sanl2.Mvc
- In the controller for the Return-URL, cast the Current.User.Identity to ClaimsIdentity to have access to the user's claims via the ClaimsIdentity's Claims enumeration

## DONE:
- Session variables are being passed from ASP.NET session to ASP Classic page through cookie values
  - This method is not the most secure as we are relying on the cookies to not be manipulated by end user
  - Suggestions for fixes/alternatives?
    - How to encrypt cookies? https://stackoverflow.com/questions/21711549/is-there-any-way-to-hash-a-password-using-bcrypt-in-classic-asp/21738166
    - Use existing SQL DB to manage user session. Look to use this method: https://docs.microsoft.com/en-us/previous-versions/dotnet/articles/aa479313(v=msdn.10)?redirectedfrom=MSDN

## TODO:
- Attempt to develop shared session state using Billy Yuen (Microsoft) Solution
- Attempt to encrypt cookies using password hash in example above or through project example