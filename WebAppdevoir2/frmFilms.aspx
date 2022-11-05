<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFilms.aspx.cs" Inherits="WebAppdevoir2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FLIXTER</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="styles.css"/>
    <link rel="stylesheet" href="styles1.css"/>
    <link rel="stylesheet" href="styles3.css"/>


</head>
<body>
     <div id="preloader">
         <div class="p">flixter</div>
     </div>
    <form id="form1" runat="server">
           <asp:Button ID="button1" runat="server" />
        <div class="col-lg-12">
           <div class="row m-3">
                 <div class="col-md-6">
                     
                     <a href="frmDetails.aspx">
                         <asp:Image Id="pbImageFilm" runat="server" width="700" />
                      </a>

                 </div>
                <div class="col-lg-6" style="margin-right:0px">
                    <div class="col-md-3">
                         <asp:Label ID="lbTitle" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                    </div>
                    <div class="col-md-3 mb-2">
                         <asp:Label ID="lbDescription" runat="server" Text="" Width="300px"></asp:Label>
                    </div>
                    
                </div>
            </div>
            <div class="row m-3">
                <div class="col-md-2"></div>
                 <div class="col-md-2">
                    <asp:Button class ="btn btn-primary btn-lg" ID="btnPrevious" style="margin-right:30px" runat="server" OnClick="btnPrevious_Click" Text="Previous" />
                    <asp:Button class ="btn btn-primary btn-lg" ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                </div>
                <div class="col-md-2"></div>
            </div>
         </div>
        <script>
            var loader = document.getElementById("preloader");
            window.addEventListener("load", function () {
                setTimeout(function () {
                    loader.style.display = "none";
                }, 3000)
            });
        </script>


    </form>
     <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>

    
</body>
</html>
