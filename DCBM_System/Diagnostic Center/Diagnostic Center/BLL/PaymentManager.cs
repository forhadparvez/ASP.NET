using Diagnostic_Center.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Diagnostic_Center.BLL
{
    public class PaymentManager
    {
        TestRequestManager aTestRequestManager = new TestRequestManager();
        PaymentGetaway aPaymentGetaway = new PaymentGetaway();
        internal string  SavePaymentInformation(Models.PaymentInfo aPaymentInfo)
        {
            if (aPaymentInfo.PaymentAmount == "")
            {
                throw new Exception("Need payment First then save....!!!!");
            }
            if (Convert.ToDouble(aPaymentInfo.PaymentAmount) > Convert.ToDouble(aPaymentInfo.DueAmount))
            {
                throw new Exception("Pay amount over then due amount......!!!!");
            }
            if (Convert.ToDouble(aPaymentInfo.PaymentAmount) > 0)
            {
                return aPaymentGetaway.SavePaymentInformation(aPaymentInfo);
            }
            throw new Exception("Need payment First then save....!!!!");
        }

        internal void GetShowMoneyReceiptReport(iTextSharp.text.Document document,string ID,string PayAmt, string TolatFee, string PaidAmount, string Due)
        {
            DataTable dtMst = aTestRequestManager.GetShowPatientTest(ID);
            if (dtMst.Rows.Count > 0)
            {
                

                PdfPCell cell;
                float[] titwidth = new float[1] { 100 };
                PdfPTable dth = new PdfPTable(titwidth);
                dth.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("Money Receipt"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("  "));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                document.Add(dth);

                float[] width1 = new float[4] { 40, 5, 35, 20 };
                PdfPTable pdftbl = new PdfPTable(width1);
                pdftbl.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("Patient ID"));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["PatientID"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 2;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase("Patient Name"));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["PatientName"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 2;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Mobile Number"));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["Mobile"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.Colspan = 2;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase("Date Of Birth "));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["DOB"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.Colspan = 2;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(""));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.FixedHeight = 10f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeader("ID"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Test Name"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.Colspan = 2;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Fee"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                DataTable dddt = aTestRequestManager.GetShowRequestPatientTestDetailsReport(ID);
                foreach (DataRow dr in dddt.Rows)
                {
                    cell = new PdfPCell(FormatHeaderPhrase(dr["ID"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["TestName"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    cell.Colspan = 2;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Fee"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                }
                cell = new PdfPCell(FormatHeaderPhrase("Total Fee : " + TolatFee));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Paid Amount : " + PaidAmount));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Due Amount : " + Due));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Now Pay Amount : " + PayAmt));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);

                document.Add(pdftbl);
            }
            else
            {
                throw new Exception("Not Found.......!!!!!!!!");
            }
        }
        private static Phrase FormatHeaderPhrase(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL));
        }
        private static Phrase FormatHeader(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD));
        }
        internal DataTable GetShowTestWiseReportDetails(string FromDate, string ToDate)
        {
            DataTable dt= aPaymentGetaway.GetShowTestWiseReportDetails(FromDate, ToDate);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            throw new Exception("No Test Search in this Date.........!!!!");

        }
        internal GridViewRow getShowTotal(double total,string Flag)
        {
            if (total > 0)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);                
                TableCell cell;
                cell = new TableCell();
                cell.Text = "";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "";
                row.Cells.Add(cell);
                if (Flag == "1")
                {
                    cell = new TableCell();
                    cell.Text = "";
                    row.Cells.Add(cell);
                }
                cell = new TableCell();
                cell.Text = "Total ";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = total.ToString("N2");
                row.Cells.Add(cell);
                return row;
            }
            return null;
        }

        internal void GetShowTestWiseReportDetailsReport(Document document, string FromDate, string ToDate)
        {
            DataTable dt = aPaymentGetaway.GetShowTestWiseReportDetails(FromDate, ToDate);
            if (dt.Rows.Count > 0)
            {
                PdfPCell cell;
                float[] titwidth = new float[1] { 100 };
                PdfPTable dth = new PdfPTable(titwidth);
                dth.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("Test Wise Report Date ( " + FromDate + " TO " + ToDate + " )"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("  "));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                document.Add(dth);

                float[] width1 = new float[4] { 10, 30, 15, 15 };
                PdfPTable pdftbl = new PdfPTable(width1);
                pdftbl.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("SL"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Test Name"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;               
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Total Test"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Total Amount"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                decimal tot = decimal.Zero;
                foreach (DataRow dr in dt.Rows)
                {
                    cell = new PdfPCell(FormatHeaderPhrase(dr["SL"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Test Name"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;                    
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Total Test"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Total Amount"].ToString()));
                    cell.HorizontalAlignment = 2;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    tot += Convert.ToDecimal(dr["Total Amount"]);
                }
                cell = new PdfPCell(FormatHeader("Total"));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 3;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader(tot.ToString("N2")));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 3;
                pdftbl.AddCell(cell);
                document.Add(pdftbl);
            }
            else
            {
                throw new Exception("Not Found.......!!!!!!!!");
            }
        }

        internal DataTable GetShowUnpaideReportDetails(string fromDate, string toDate)
        {
            DataTable dt = aPaymentGetaway.GetShowUnpaideReportDetails(fromDate, toDate);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            throw new Exception("No Test Search in this Date.........!!!!");
        }

        internal void GetShowUnpaidReportDetailsReport(Document document, string fromDate, string toDate)
        {
            DataTable dt = aPaymentGetaway.GetShowUnpaideReportDetails(fromDate, toDate);
            if (dt.Rows.Count > 0)
            {
                PdfPCell cell;
                float[] titwidth = new float[1] { 100 };
                PdfPTable dth = new PdfPTable(titwidth);
                dth.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("Unpaid Report Date ( " + fromDate + " TO " + toDate + " )"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("  "));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                document.Add(dth);

                float[] width1 = new float[5] { 10, 30, 15, 15,20 };
                PdfPTable pdftbl = new PdfPTable(width1);
                pdftbl.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("SL"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Bill Number"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Contract No"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Patient Name"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Bill Amount"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);

                decimal tot = decimal.Zero;
                foreach (DataRow dr in dt.Rows)
                {
                    cell = new PdfPCell(FormatHeaderPhrase(dr["SL"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Bill No"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Mobile No"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Patient Name"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Bill Amount"].ToString()));
                    cell.HorizontalAlignment = 2;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    tot += Convert.ToDecimal(dr["Bill Amount"]);
                }
                cell = new PdfPCell(FormatHeader("Total"));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader(tot.ToString("N2")));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                document.Add(pdftbl);
            }
            else
            {
                throw new Exception("Not Found.......!!!!!!!!");
            }
        }

        internal DataTable GetShowTypeWiseReportDetails(string FromDate, string ToDate)
        {
            DataTable dt = aPaymentGetaway.GetShowTypeWiseReportDetails(FromDate, ToDate);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            throw new Exception("No Test Search in this Date.........!!!!");
        }

        internal void GetShowTypeWiseReportDetailsReport(Document document, string FromDate, string ToDate)
        {
            DataTable dt = aPaymentGetaway.GetShowTypeWiseReportDetails(FromDate, ToDate);
            if (dt.Rows.Count > 0)
            {
                PdfPCell cell;
                float[] titwidth = new float[1] { 100 };
                PdfPTable dth = new PdfPTable(titwidth);
                dth.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("Type Wise Report Date ( " + FromDate + " TO " + ToDate + " )"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("  "));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                document.Add(dth);

                float[] width1 = new float[4] { 10, 30, 15, 15 };
                PdfPTable pdftbl = new PdfPTable(width1);
                pdftbl.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("SL"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Test Type Name"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Total No Of Test"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader("Total Amount"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                decimal tot = decimal.Zero;
                foreach (DataRow dr in dt.Rows)
                {
                    cell = new PdfPCell(FormatHeaderPhrase(dr["SL"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Test Type Name"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Total No Of Test"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Total Amount"].ToString()));
                    cell.HorizontalAlignment = 2;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    tot += Convert.ToDecimal(dr["Total Amount"]);
                }
                cell = new PdfPCell(FormatHeader("Total"));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 3;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeader(tot.ToString("N2")));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 3;
                pdftbl.AddCell(cell);
                document.Add(pdftbl);
            }
            else
            {
                throw new Exception("Not Found.......!!!!!!!!");
            }
        }
    }
}