<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROYECTO_WEB.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
        <title>Login</title>
    </head>
    <body class="p-3 mb-2 bg-dark text-white">
        <nav style="background-color: #1F618D; border-radius: 8px; top: 0px; left: 0px;" class="navbar p-2" >
            <div class="container-fluid ">
                <a class="navbar-brand" href="#">
                   Tienda
                </a>
            </div>    
        </nav>
        <div style=" display: flex;  min-height: 80vh; align-items: center;" class="container mt-4 col-lg-4">
            <div class="card col-sm-10 p-3" >
                <div class="card-body">
                    <form class="form-sign" id="form1" runat="server">
                        <div class="form-group text-center">
                            <h3 style="color:#1F618D;">Inicio de sesión</h3>
                        </div>
                        <br>
                        <div class="form-group">
                            <asp:Label ID="lblcorreo" runat="server" Text="Usuario:"></asp:Label>
                            <asp:TextBox style=" background-color: #1F618D; border-color: transparent;" type="text" name="txt_nombre" class="form-control" autocomplete="off" ID="txt_usuario" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblcontraseña" runat="server" Text="Contraseña:"></asp:Label>
                            <asp:TextBox style=" background-color: #1F618D; border-color: transparent;" type="password" name="txt_password" class="form-control" autocomplete="off" ID="txtcontrasena" runat="server"></asp:TextBox>
                        </div>
                         <asp:Button style="margin-top: 10px; width: 100%; border-color: #134566; --bs-btn-hover-bg: #1E6CA0" type="submit" name="btn_enviar" value="Ingresar" class="btn btn-outline" ID="btniniciar" runat="server" Text="Ingresar" OnClick="btniniciar_Click"/>
                    </form>
                </div>
            </div>
            
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
        <script src="https://kit.fontawesome.com/4b5617367e.js" crossorigin="anonymous"></script>
        
    </body>
</html>
