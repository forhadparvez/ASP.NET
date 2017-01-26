<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Diagnostic_Center._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <br />
    <br />
    <div class="row">

        <div class="col-lg-1 col-md-1 col-sm-12 col-xs-12">
        </div>
        <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12" style="box-shadow: 10px 10px 10px 10px #888888;">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="border: 1px solid #AFC7BA; margin-top: 15px; margin-bottom: 15px; background-color: #DCFAEA; height: auto;">
                <fieldset>
                    <legend>Dashboard</legend>
                    <div class="rows" style="padding: 8px 8px 8px 8px; margin-bottom: 20px; height: 500px;">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="chartContainer" style="border: .5px solid #6B7A72; margin: 0px 0px 0px 0px; padding:0; background-color: #ffffff; height: 250px;">
                                
                                  
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="chartContainer1" style="border: .5px solid #6B7A72; margin: 0px 0px 0px 0px; padding:0; background-color: #ffffff; height: 250px;">
                                  
                                
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="chartContainer2" style="border: .5px solid #6B7A72; margin: 0px 0px 0px 0px; background-color: #ffffff; height: 250px;">
                                 
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" id="chartContainer3" style="border: .5px solid #6B7A72; margin: 0px 0px 0px 0px; background-color: #ffffff; height: 250px;">
                                 
                            </div>
                        </div>

                    </div>


                </fieldset>
            </div>
        </div>
        <br />
    </div>
    <div class="col-lg-1 col-md-1 col-sm-12 col-xs-12">
    </div>
    <script type="text/javascript">
  window.onload = function () {
    var chart = new CanvasJS.Chart("chartContainer",
    {
      title:{
      text: "Listed Test"
      },
      data: [
      {
        type: "line",
        dataPoints: [
        { x: 10, y: 71 },
        { x: 20, y: 55 },
        { x: 30, y: 50 },
        { x: 40, y: 65, lineColor:"red" }, //**Change the lineColor here
        { x: 50, y: 68 },
        { x: 60, y: 28 },
        { x: 70, y: 34 },
        { x: 80, y: 14 },
        { x: 90, y: 23},
        ]
      }
      ]
    });

    chart.render();

    var chart1 = new CanvasJS.Chart("chartContainer1",
 {
     title: {
         text: "Patient Register"
     },
     data: [
     {
         type: "column",
         dataPoints: [
             { y: 45, label: "Apple" },
             { y: 31, label: "Mango" },
             { y: 52, label: "Pineapple" },
             { y: 10, label: "Grapes" },
             { y: 46, label: "Lemon" },
             { y: 30, label: "Banana" },
             { y: 50, label: "Watermelon" },
             { y: 28, label: "Coconut" },
             { y: 45, label: "Lychee" },
             { y: 15, label: "Palm" },
             { y: 48, label: "Orange" },
             { y: 38, label: "Muskmelon" },
             { y: 41, label: "Strawberry" },
             { y: 25, label: "Kiwi" },
             { y: 50, label: "Guava" },
         ]
     }]
 });
    var chart2 = new CanvasJS.Chart("chartContainer2",
  {
      title: {
          text: "Total Received Amount"
      },
      data: [
      {
          type: "pie",
          dataPoints: [
              { y: 4181563 },
              { y: 2175498 },
              { y: 3125844 },
              { y: 1176121 },
              { y: 1727161 },
              { y: 4303364 },
              { y: 1717786 }
          ]
      }
      ]
  });
    var chart4 = new CanvasJS.Chart("chartContainer3",
          {
              title: {
                  text: "Total Due"
              },

              data: [
              {
                  type: "bar",

                  dataPoints: [
                  { x: 10, y: 90, label: "Apple" },
                  { x: 20, y: 70, label: "Mango" },
                  { x: 30, y: 50, label: "Orange" },
                  { x: 40, y: 60, label: "Banana" },
                  { x: 50, y: 20, label: "Pineapple" },
                  { x: 60, y: 30, label: "Pears" },
                  { x: 70, y: 35, label: "Grapes" },
                  { x: 80, y: 40, label: "Lychee" },
                  { x: 90, y: 30, label: "Jackfruit" }
                  ]
              }
              ]
          });
    chart.render();
    chart1.render();
    chart2.render();
    chart4.render();
  }


	</script>
 
    <script src="js/canvasjs.min.js"></script>
</asp:Content>
