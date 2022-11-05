<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDetails.aspx.cs" Inherits="WebAppdevoir2.frmDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="margin-left:20px">
        <div>
          <asp:literal ID="youtubeVideo" runat="server"></asp:literal>
        </div>
        <div class="row">
                <div class="col-lg-4">
                    <div class="col-md-3">
                         <asp:Label ID="lbTitle" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                    </div>
                    <div class="col-md-3 mb-2">
                         <asp:Label ID="lbDescription" runat="server" Text="" Width="300px"></asp:Label>
                    </div>
                </div>

                <div class="col-lg-6">
                    <div class="col-md-2">
                         <asp:Label ID="lbOriginalLanguange" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                         <asp:Label ID="lbReleaseDate" runat="server" Text=""></asp:Label>
                    </div>
                     <div class="col-md-2">
                         <asp:Label ID="lbVoteAverage" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-2">
                         <asp:Label ID="lbVoteCount" runat="server" Text=""></asp:Label>
                    </div>
               </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
