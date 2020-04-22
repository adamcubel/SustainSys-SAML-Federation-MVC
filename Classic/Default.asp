<% Language=VBScript %>

<!-- #include file="SessionCookie.asp" -->

<%
' This needs to match the name of the cookie set in web.config for <federationConfiguration><cookieHandler>
IF Request.Cookies("SampleMvcApplicationAuth") <> "" And GetSessionCookie("username") <> "" THEN
dim x,y
for each x in Request.Cookies
  response.write("<p>")
  if Request.Cookies(x).HasKeys then
    for each y in Request.Cookies(x)
      response.write(x & ":" & y & "=" & Request.Cookies(x)(y))
      response.write("<br>")
    next
  else
    Response.Write(x & "=" & Request.Cookies(x) & "<br>")
  end if
  response.write "</p>"
next
END IF
%>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>
    <h1>This is a test ASP Classic Page</h1>
</body>
</html>