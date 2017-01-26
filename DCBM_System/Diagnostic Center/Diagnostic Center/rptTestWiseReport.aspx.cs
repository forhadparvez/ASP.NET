﻿using Diagnostic_Center.BLL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagnostic_Center
{
    public partial class rptTestWiseReport : System.Web.UI.Page
    {
        PaymentManager aPaymentManager = new PaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnPdf.Visible = false;
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("rptTestWiseReport.aspx");
        }
        protected void txtShow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = aPaymentManager.GetShowTestWiseReportDetails(txtFromdate.Text, txtToDate.Text);
                dgTestHistory.DataSource = dt;
                dgTestHistory.DataBind();
                TotalBill();
                btnPdf.Visible = true;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }
        double total = 0;
        protected void dgTestHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Total Amount]"));
            }            
        }
        private void TotalBill()
        {
            GridViewRow row = aPaymentManager.getShowTotal(total,"0");
            if (row != null)
            { dgTestHistory.Controls[0].Controls.Add(row); }
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename='TestWise'.pdf");
                Document document = new Document();
                document = new Document(PageSize.A4);
                MemoryStream ms = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
                document.Open();

                aPaymentManager.GetShowTestWiseReportDetailsReport(document, txtFromdate.Text,txtToDate.Text);
                document.Close();
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }
    }
}