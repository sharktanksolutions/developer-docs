﻿Imports RefundVault.MWCredit

Module Module1

    Sub Main()
        'Create Soap Client
        Dim MWCredit As New CreditSoapClient

        'Create Credentails Object
        Dim Credentials As New MerchantCredentials With {
        .MerchantName = "TEST MERCHANT",
        .MerchantSiteId = "XXXXXXXX",
        .MerchantKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
        }

        'Create PaymentData Object
        Dim PaymentData As New PaymentData With {
        .Source = "VAULT",
        .VaultToken = "100000100ABCDE123456"
        }

        'Create Request Object
        Dim RefundRequest As New RefundRequest With {
        .Amount = "1.01",
        .InvoiceNumber = "INV1234",
        .CardAcceptorTerminalId = "01",
        .RegisterNumber = "01",
        .MerchantTransactionId = "123"
        }

        'Process Request
        Dim Response As TransactionResponse45
        Response = MWCredit.Refund(Credentials, PaymentData, RefundRequest)

        'Display Results
        Console.WriteLine(" Refund Response: {0} Token: {1} Amount: ${2} RFMIQ: {3}", Response.ApprovalStatus + vbNewLine, Response.Token + vbNewLine, Response.Amount + vbNewLine, Response.Rfmiq + vbNewLine)
        Console.WriteLine("Press Any Key to Close")
        Console.ReadKey()
    End Sub

End Module