<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PigLatinTranslator.aspx.cs" Inherits="PracticeProject.PigLatinTranslator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Pig Latin Name Translator<br />
            <br />
            First Name:
            <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
            <br />
            <br />
            Last Name:
            <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="translateButton" runat="server" OnClick="translateButton_Click" Text="Translate" />
            <br />
            <br />
            <asp:Label ID="Result" runat="server" Font-Bold="True"></asp:Label>
        </div>
    </form>
</body>
</html>
