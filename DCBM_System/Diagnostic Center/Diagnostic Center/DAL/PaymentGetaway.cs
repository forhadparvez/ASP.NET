using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diagnostic_Center.DAL
{
    public class PaymentGetaway
    {
        internal string SavePaymentInformation(Models.PaymentInfo aPaymentInfo)
        {
            string Query = @"INSERT INTO [Payment]
           ([PatientID],[PayAmount])
     VALUES
           ('" + aPaymentInfo.ID + "','" + aPaymentInfo.PaymentAmount.Replace("'","") + "')";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Saved Sucessfully....!!";
            }
            else
                throw new Exception("Record Save Failed....!!! ");
        }   

        internal DataTable GetShowTestWiseReportDetails(string FromDate, string ToDate)
        {
            string ShowQuery = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT t1.[TestID])) AS SL, t2.TestName AS [Test Name],COUNT(t1.[TestID])AS [Total Test]
      ,sum(t1.[Fee])  AS [Total Amount] 
  FROM [TestRequestDtls] t1 inner join TestSetup t2 on t2.ID=t1.TestID inner join TestRequestMst t3 on t3.ID=t1.MstID where convert(date,t3.AddDate,103) between convert(date,'" + FromDate + "',103) and convert(date,'" + ToDate + "',103) group by t2.TestName, TestID ";
            DataTable dt = DataTransfection.GetShowDataTable(ShowQuery, "TestRequestDtls");
            return dt;
        }

        internal DataTable GetShowUnpaideReportDetails(string fromDate, string toDate)
        {
            string ShowQuery = @"with tot AS( SELECT ROW_NUMBER() OVER(ORDER BY (SELECT t1.[PatientID])) AS SL,t1.AddDate,
      t1.[PatientID]AS [Bill No]
      ,[PatientName] AS [Patient Name]     
      ,[Mobile] AS [Mobile No]  
	  ,ISNULL(sum(t2.Fee),0) AS [TotalBill],ISNULL(t3.PayAmount,0)AS [PaymentAmount]
  FROM [TestRequestMst] t1 Left join [TestRequestDtls] t2 on t2.MstID=t1.ID LEFT join (select tt.PatientID,sum(tt.PayAmount) as PayAmount from Payment tt group by tt.PatientID) t3 on t3.PatientID=t1.ID group by t1.PatientID,t1.PatientName,t1.Mobile,t1.AddDate,t3.PayAmount) 
  SELECT tot.SL,tot.[Bill No],tot.[Mobile No],tot.[Patient Name],(tot.TotalBill-tot.PaymentAmount) AS [Bill Amount] FROM tot where convert(date,tot.AddDate ,103) between convert(date,'" + fromDate + "',103) and convert(date,'" + toDate + "',103) and (tot.TotalBill-tot.PaymentAmount)>0";
            DataTable dt = DataTransfection.GetShowDataTable(ShowQuery, "TestRequestDtls");
            return dt;
        }

        internal DataTable GetShowTypeWiseReportDetails(string FromDate, string ToDate)
        {
            string ShowQuery = @"SELECT  ROW_NUMBER() OVER(ORDER BY (SELECT t3.TypeName)) AS SL
       ,t3.TypeName as [Test Type Name] 
	   ,count(t3.TypeName)AS [Total No Of Test]
      ,sum(t1.[Fee]) AS [Total Amount]	  
  FROM [TestRequestDtls] t1 inner join [TestSetup] t2 on t2.ID=t1.TestID inner join [TestTypeSetup] t3 on t3.ID=t2.TestTypeID  inner join  [TestRequestMst] t4 on t4.ID=t1.MstID WHERE convert(date,t4.AddDate,103) between convert(date,'" + FromDate + "',103) and convert(date,'" + ToDate + "',103)  group by t3.TypeName";
            DataTable dt = DataTransfection.GetShowDataTable(ShowQuery, "TestRequestDtls");
            return dt;
        }
    }
}