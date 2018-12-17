using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushQuant.Clients;

namespace RushQuantClientDemo
{
    class Program
    {
        public static string __username;
        public static string __key;
        public static string __accountId;
        public static string __password;
        //public static string __accountId1;
        //public static string __password1;

        static int Main(string[] args)
        {
            // TODO: Read config from args
            if (args.Length == 4)
            {
                __username = args[0]; // 比如'jimcai'。
                __key = args[1]; // 从Rushquant网站获取。
                __accountId = args[2]; // 要操作的账户id，为末尾5位。
                __password = args[3]; // 要操作的账户交易密码。
            }

            if (!RushQuantClient.Initialize(__username, Convert.FromBase64String(__key)))
            {
                return -1;
            }

            RushQuantClient client = RushQuantClient.Create(Convert.ToInt32(__accountId));
            //// reset account
            //result = rushquant_trade_Reset(g_AccountId);
            //if (result != Error_Success)
            //{
            //    printf("Reset Error: %d", result);
            //    return result;
            //}
            //rushquant_trade_UpdateTest(g_AccountId);
            //// Login
            //LoginInput input = { 0 };
            //// 设置交易密码
            //CopyString(input.TradePassword, g_Password);
            //LoginOutput output = { 0 };
            //result = rushquant_trade_Login(g_AccountId, &input, &output);
            //if (result != Error_Success)
            //{
            //    printf("Login Error: %d, Message: %s", result, output.ErrorMessage);
            //    return result;
            //}

            //test_QueryTickData();
            //test_QueryStockholderInfo();
            //test_QuerySecurityCapitalInfo();
            //test_QuerySecurityPositionInfo();
            //test_QuerySecurityIntradayOrder();
            //test_QuerySecurityHistoricalOrder();
            ////test_QuerySecurityIntradayDeal();
            //test_QuerySecurityHistoricalDeal();
            //test_QuerySecurityOrderEvaluation();
            //test_QuerySecurityOrderCapacity();

            //test_PostSecuritySubmitOrder2();
            //test_PostSecuritySubmitOrder();
            //test_PostSecuritySubmitOrder_Purchase();
            //test_PostSecurityCancelOrder();

            //for (int i = 0; i < 20; i++)
            //{
            //    test_PostSecuritySubmitOrder_NotReturn();
            //    Sleep(1);
            //}

            //rushquant_dispose();





            return 0;
        }
    }
}
