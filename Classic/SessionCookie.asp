<% Language=VBScript %>
<%
Function AddSessionCookie(key, value)
    Response.Cookies("SessionCookie")(key) = value
    Response.Cookies("SessionCookie").Expires = DATE + 1 ' Set the timeout to be consistent with SAML SSO Guidelines
    Response.Cookies(strCookieName).Secure = True
    Session(key) = value
End Function

Function GetSessionCookie(key)
    IF Request.Cookies("SessionCookie")(key) <> "" THEN
        GetSessionCookie = Request.Cookies("SessionCookie")(key)
    End If
End Function
%>
