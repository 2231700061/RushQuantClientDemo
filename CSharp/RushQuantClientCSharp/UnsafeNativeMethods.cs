using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RushQuant.Clients
{
    internal static class UnsafeNativeMethods
    {
        private static bool __is64bit = IntPtr.Size == sizeof(Int64);

        [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_initialize")]
        internal static extern int rushquant_initialize32(string pUsername, byte[] pKey);
        [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_initialize")]
        internal static extern int rushquant_initialize64(string pUsername, byte[] pKey);
        internal static int rushquant_initialize(string pUsername, byte[] pKey)
        {
            if (__is64bit)
                return rushquant_initialize64(pUsername, pKey);
            else
                return rushquant_initialize32(pUsername, pKey);
        }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_free")]
                internal static extern void rushquant_free32(IntPtr pointer);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_free")]
                internal static extern void rushquant_free64(IntPtr pointer);
                internal static void rushquant_free(IntPtr pointer)
                {
                    if (__is64bit)
                        rushquant_free64(pointer);
                    else
                        rushquant_free32(pointer);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_dispose")]
                internal static extern int rushquant_dispose32();
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_dispose")]
                internal static extern int rushquant_dispose64();
                internal static int rushquant_dispose()
                {
                    if (__is64bit)
                        return rushquant_dispose64();
                    else
                        return rushquant_dispose32();
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_GetAccountList")]
                internal static extern int rushquant_trade_GetAccountList32(IntPtr pointer);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_GetAccountList")]
                internal static extern int rushquant_trade_GetAccountList64(IntPtr pointer);
                internal static int rushquant_trade_GetAccountList(IntPtr pointer)
                {
                    if (__is64bit)
                        return rushquant_trade_GetAccountList64(pointer);
                    else
                        return rushquant_trade_GetAccountList32(pointer);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_Reset")]
                internal static extern int rushquant_trade_Reset32(int accountId);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_Reset")]
                internal static extern int rushquant_trade_Reset64(int accountId);
                internal static int rushquant_trade_Reset(int accountId)
                {
                    if (__is64bit)
                        return rushquant_trade_Reset64(accountId);
                    else
                        return rushquant_trade_Reset32(accountId);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_NextId")]
                internal static extern int rushquant_trade_NextId32(int accountId);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_NextId")]
                internal static extern int rushquant_trade_NextId64(int accountId);
                internal static int rushquant_trade_NextId(int accountId)
                {
                    if (__is64bit)
                        return rushquant_trade_NextId64(accountId);
                    else
                        return rushquant_trade_NextId32(accountId);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_Login")]
                internal static extern int rushquant_trade_Login32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_Login")]
                internal static extern int rushquant_trade_Login64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_Login(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_Login64(input, ref output);
                    else
                        return rushquant_trade_Login32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QueryTickData")]
                internal static extern int rushquant_trade_QueryTickData32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QueryTickData")]
                internal static extern int rushquant_trade_QueryTickData64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QueryTickData(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QueryTickData64(input, ref output);
                    else
                        return rushquant_trade_QueryTickData32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QueryStockholderInfo")]
                internal static extern int rushquant_trade_QueryStockholderInfo32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QueryStockholderInfo")]
                internal static extern int rushquant_trade_QueryStockholderInfo64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QueryStockholderInfo(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QueryStockholderInfo64(input, ref output);
                    else
                        return rushquant_trade_QueryStockholderInfo32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QuerySecurityCapitalInfo")]
                internal static extern int rushquant_trade_QuerySecurityCapitalInfo32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QuerySecurityCapitalInfo")]
                internal static extern int rushquant_trade_QuerySecurityCapitalInfo64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QuerySecurityCapitalInfo(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QuerySecurityCapitalInfo64(input, ref output);
                    else
                        return rushquant_trade_QuerySecurityCapitalInfo32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QuerySecurityPositionInfo")]
                internal static extern int rushquant_trade_QuerySecurityPositionInfo32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QuerySecurityPositionInfo")]
                internal static extern int rushquant_trade_QuerySecurityPositionInfo64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QuerySecurityPositionInfo(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QuerySecurityPositionInfo64(input, ref output);
                    else
                        return rushquant_trade_QuerySecurityPositionInfo32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QuerySecurityOrderEvaluation")]
                internal static extern int rushquant_trade_QuerySecurityOrderEvaluation32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QuerySecurityOrderEvaluation")]
                internal static extern int rushquant_trade_QuerySecurityOrderEvaluation64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QuerySecurityOrderEvaluation(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QuerySecurityOrderEvaluation64(input, ref output);
                    else
                        return rushquant_trade_QuerySecurityOrderEvaluation32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QuerySecurityIntradayOrder")]
                internal static extern int rushquant_trade_QuerySecurityIntradayOrder32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QuerySecurityIntradayOrder")]
                internal static extern int rushquant_trade_QuerySecurityIntradayOrder64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QuerySecurityIntradayOrder(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QuerySecurityIntradayOrder64(input, ref output);
                    else
                        return rushquant_trade_QuerySecurityIntradayOrder32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QuerySecurityHistoricalOrder")]
                internal static extern int rushquant_trade_QuerySecurityHistoricalOrder32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QuerySecurityHistoricalOrder")]
                internal static extern int rushquant_trade_QuerySecurityHistoricalOrder64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QuerySecurityHistoricalOrder(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QuerySecurityHistoricalOrder64(input, ref output);
                    else
                        return rushquant_trade_QuerySecurityHistoricalOrder32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QuerySecurityIntradayDeal")]
                internal static extern int rushquant_trade_QuerySecurityIntradayDeal32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QuerySecurityIntradayDeal")]
                internal static extern int rushquant_trade_QuerySecurityIntradayDeal64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QuerySecurityIntradayDeal(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QuerySecurityIntradayDeal64(input, ref output);
                    else
                        return rushquant_trade_QuerySecurityIntradayDeal32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_QuerySecurityHistoricalDeal")]
                internal static extern int rushquant_trade_QuerySecurityHistoricalDeal32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_QuerySecurityHistoricalDeal")]
                internal static extern int rushquant_trade_QuerySecurityHistoricalDeal64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_QuerySecurityHistoricalDeal(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_QuerySecurityHistoricalDeal64(input, ref output);
                    else
                        return rushquant_trade_QuerySecurityHistoricalDeal32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_PostSecuritySubmitOrder")]
                internal static extern int rushquant_trade_PostSecuritySubmitOrder32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_PostSecuritySubmitOrder")]
                internal static extern int rushquant_trade_PostSecuritySubmitOrder64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_PostSecuritySubmitOrder(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_PostSecuritySubmitOrder64(input, ref output);
                    else
                        return rushquant_trade_PostSecuritySubmitOrder32(input, ref output);
                }

                [DllImport("RushQuantClient32.dll", EntryPoint = "rushquant_trade_PostSecurityCancelOrder")]
                internal static extern int rushquant_trade_PostSecurityCancelOrder32(IntPtr input, ref IntPtr output);
                [DllImport("RushQuantClient64.dll", EntryPoint = "rushquant_trade_PostSecurityCancelOrder")]
                internal static extern int rushquant_trade_PostSecurityCancelOrder64(IntPtr input, ref IntPtr output);
                internal static int rushquant_trade_PostSecurityCancelOrder(IntPtr input, ref IntPtr output)
                {
                    if (__is64bit)
                        return rushquant_trade_PostSecurityCancelOrder64(input, ref output);
                    else
                        return rushquant_trade_PostSecurityCancelOrder32(input, ref output);
                }
    }
}
