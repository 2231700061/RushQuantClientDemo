#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "const.h"
#include "rushquant.h"

#pragma comment(lib,"RushQuantClient64.lib")

#define DYNAMIC_DATA

static const int g_AccountId = 99999;
static const char* g_Password = "121314";


char* CopyString(char *pDestination, const char *pSource)
{
    char *s = pDestination;
    while ((*s++ = *pSource++) != 0)
        ;
    return (pDestination);
}

char* GetQuoteType(char* exchangeId, int quoteType)
{
    if (strcmp(exchangeId, "SSE") == 0)
    {
        switch (quoteType)
        {
            case QuoteType_SSE_LimitPrice:
                return "1-限价委托";
            case QuoteType_SSE_FivePriceThenCancel:
                return "5-五档即成剩撤";
            case QuoteType_SSE_FivePriceThenLimitPrice:
                return "7-五档即成转限价";
            default:
                return "0-未知";
        }
    }
    else if (strcmp(exchangeId, "SZE") == 0)
    {
        switch (quoteType)
        {
            case QuoteType_SZE_LimitPrice:
                return "1-限价委托";
            case QuoteType_SZE_CounterpartyBestPrice:
                return "2-对方最优价格";
            case QuoteType_SZE_BestPrice:
                return "3-本方最优价格";
            case QuoteType_SZE_AnyPriceThenCancel:
                return "4-即时成交剩余撤销";
            case QuoteType_SZE_FivePriceThenCancel:
                return "5-五档即成剩撤";
            case QuoteType_SZE_AllPriceOrCancel:
                return "6-全额成交或撤销";
            default:
                return "0-未知";
        }
    }
    else
    {
        return "0-未知";
    }
}

char* GetTradeFlagText(int tradeFlag)
{
    switch (tradeFlag)
    {
        case 1:
            return "1-买入";
        case 2:
            return "2-卖出";
        case 3:
            return "3-申购";
        case 4:
            return "4-赎回";
        default:
            return "0-未知";
    }
}

char* GetStatusText(int status)
{
    switch (status)
    {
        case 1:
            return "1-";
        case 2:
            return "2-已申报未成交";
        case 3:
            return "3-";
        case 4:
            return "4-";
        case 5:
            return "5-";
        case 6:
            return "6-全部成交";
        case 7:
            return "7-部成部撤";
        case 8:
            return "8-全部撤单";
        case 9:
            return "9-";
        case 10:
            return "10-";
        case 11:
            return "11-";
        case 12:
            return "12-";
        case 13:
            return "13-";
        default:
            return "0-未知";
    }
}

void test_QueryTickData()
{
    printf("******* QueryTickData BEGIN *********\n");

    QueryTickDataInput input = { 0 };
    CopyString(input.ExchangeId, "SSE");
    CopyString(input.InstrumentCode, "601288");

#ifdef DYNAMIC_DATA
    QueryTickDataOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QueryTickDataOutput* pOutput = (QueryTickDataOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QueryTickData(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QueryTickData END *********\n");
        printf("\n");
        return;
    }

    QueryTickDataOutput* pItem = pOutput;
    printf("交易所名称:%s, 合约代码:%s, 合约名称:%s\n卖五: %-10.4f %d\n卖四: %-10.4f %d\n卖三: %-10.4f %d\n卖二: %-10.4f %d\n卖一: %-10.4f %d\n买一: %-10.4f %d\n买二: %-10.4f %d\n买三: %-10.4f %d\n买四: %-10.4f %d\n买五: %-10.4f %d\n",
        pItem->ExchangeId, pItem->InstrumentCode, pItem->InstrumentName,
        pItem->AskPrice5, pItem->AskVolume5,
        pItem->AskPrice4, pItem->AskVolume4,
        pItem->AskPrice3, pItem->AskVolume3,
        pItem->AskPrice2, pItem->AskVolume2,
        pItem->AskPrice1, pItem->AskVolume1,

        pItem->BidPrice1, pItem->BidVolume1,
        pItem->BidPrice2, pItem->BidVolume2,
        pItem->BidPrice3, pItem->BidVolume3,
        pItem->BidPrice4, pItem->BidVolume4,
        pItem->BidPrice5, pItem->BidVolume5);
    printf("******* QueryTickData END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QueryStockholderInfo()
{
    printf("******* QueryStockholderInfo BEGIN *********\n");

    QueryStockholderInfoInput input = { 0 };

#ifdef DYNAMIC_DATA
    QueryStockholderInfoOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QueryStockholderInfoOutput* pOutput = (QueryStockholderInfoOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QueryStockholderInfo(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QueryStockholderInfo END *********\n");
        printf("\n");
        return;
    }

    printf("%-20s\t%-20s\n", "交易所名称", "股东代码");
    for (int i = 0; i < pOutput->Count; i++)
    {
        QueryStockholderInfoOutputItem* pItem = pOutput->Items + i;
        printf("%-20s\t%-20s\n", pItem->ExchangeId, pItem->StockholderCode);
    }
    printf("******* QueryStockholderInfo END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QuerySecurityCapitalInfo()
{
    printf("******* QuerySecurityCapitalInfo BEGIN *********\n");

    QuerySecurityCapitalInfoInput input = { 0 };

#ifdef DYNAMIC_DATA
    QuerySecurityCapitalInfoOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QuerySecurityCapitalInfoOutput* pOutput = (QuerySecurityCapitalInfoOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QuerySecurityCapitalInfo(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QuerySecurityCapitalInfo END *********\n");
        printf("\n");
        return;
    }

    printf("%-20s\t%-20s\t%-20s\t%-20s\t%-20s\n", "币种", "资金余额", "可用资金", "可取资金", "总资产");
    for (int i = 0; i < pOutput->Count; i++)
    {
        QuerySecurityCapitalInfoOutputItem* pItem = pOutput->Items + i;
        printf("%-20d\t%-20.4f\t%-20.4f\t%-20.4f\t%-20.4f\n", pItem->Currency, pItem->RemainingCapitalAmount, pItem->AvailableCapitalAmount, pItem->WithdrawableCapitalAmount, pItem->TotalAssetAmount);
    }
    printf("******* QuerySecurityCapitalInfo END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QuerySecurityPositionInfo()
{
    printf("******* QuerySecurityPositionInfo BEGIN *********\n");

    QuerySecurityPositionInfoInput input = { 0 };

#ifdef DYNAMIC_DATA
    QuerySecurityPositionInfoOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QuerySecurityPositionInfoOutput* pOutput = (QuerySecurityPositionInfoOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QuerySecurityPositionInfo(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QuerySecurityPositionInfo END *********\n");
        printf("\n");
        return;
    }

    printf("%-10s\t%-20s\t%-20s\t%-20s\t%-20s\t%-20s\n", "交易所名称", "合约代码", "合约名称", "数量", "可卖数量", "股东代码");
    for (int i = 0; i < pOutput->Count; i++)
    {
        QuerySecurityPositionInfoOutputItem* pItem = pOutput->Items + i;
        printf("%-10s\t%-20s\t%-20s\t%-20d\t%-20d\t%-20s\n", pItem->ExchangeId, pItem->InstrumentCode, pItem->InstrumentName, pItem->Volume, pItem->AvailableVolume, pItem->StockholderCode);
    }
    printf("******* QuerySecurityPositionInfo END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QuerySecurityIntradayOrder()
{
    printf("******* QuerySecurityIntradayOrder BEGIN *********\n");

    QuerySecurityIntradayOrderInput input = { 0 };

#ifdef DYNAMIC_DATA
    QuerySecurityIntradayOrderOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QuerySecurityIntradayOrderOutput* pOutput = (QuerySecurityIntradayOrderOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QuerySecurityIntradayOrder(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QuerySecurityIntradayOrder END *********\n");
        printf("\n");
        return;
    }

    printf("%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\n", "委托日期", "委托时间", "委托编号", "股东代码", "交易所代码", "合约代码", "合约名称", "交易标志", "委托价格", "委托数量", "成交价格", "成交数量", "撤单数量", "报价类型", "状态");
    for (int i = 0; i < pOutput->Count; i++)
    {
        QuerySecurityIntradayOrderOutputItem* pItem = pOutput->Items + i;
        printf("%-15d\t%-15d\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15.4f\t%-15d\t%-15.4f\t%-15d\t%-15d\t%-15s\t%-15s\n",
            pItem->OrderDate,
            pItem->OrderTime,
            pItem->OrderID,
            pItem->StockholderCode,
            pItem->ExchangeId,

            pItem->InstrumentCode,
            pItem->InstrumentName,
            GetTradeFlagText(pItem->TradeFlag),
            pItem->OrderPrice,
            pItem->OrderVolume,
            pItem->DealPrice,
            pItem->DealVolume,
            pItem->CancelVolume,
            GetQuoteType(pItem->ExchangeId, pItem->QuoteType),
            GetStatusText(pItem->OrderStatus));

    }
    printf("******* QuerySecurityIntradayOrder END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QuerySecurityHistoricalOrder()
{
    printf("******* QuerySecurityHistoricalOrder BEGIN *********\n");

    QuerySecurityHistoricalOrderInput input = { 0 };
    input.BeginDate = 20181206;
    input.EndDate = 20181213;

#ifdef DYNAMIC_DATA
    QuerySecurityHistoricalOrderOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QuerySecurityHistoricalOrderOutput* pOutput = (QuerySecurityHistoricalOrderOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QuerySecurityHistoricalOrder(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QuerySecurityHistoricalOrder END *********\n");
        printf("\n");
        return;
    }

    printf("%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\n", "委托日期", "委托时间", "委托编号", "股东代码", "交易所代码", "合约代码", "合约名称", "交易标志", "委托价格", "委托数量", "成交数量", "撤单数量", "报价类型", "状态");
    for (int i = 0; i < pOutput->Count; i++)
    {
        QuerySecurityHistoricalOrderOutputItem* pItem = pOutput->Items + i;
        printf("%-15d\t%-15d\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15.4f\t%-15d\t%-15d\t%-15d\t%-15s\t%-15s\n",
            pItem->OrderDate,
            pItem->OrderTime,
            pItem->OrderID,
            pItem->StockholderCode,
            pItem->ExchangeId,

            pItem->InstrumentCode,
            pItem->InstrumentName,
            GetTradeFlagText(pItem->TradeFlag),
            pItem->OrderPrice,
            pItem->OrderVolume,

            pItem->DealVolume,
            pItem->CancelVolume,
            GetQuoteType(pItem->ExchangeId, pItem->QuoteType),
            GetStatusText(pItem->OrderStatus));

    }
    printf("******* QuerySecurityHistoricalOrder END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QuerySecurityIntradayDeal()
{
    printf("******* QuerySecurityIntradayDeal BEGIN *********\n");

    QuerySecurityIntradayDealInput input = { 0 };
    input.BeginNumber = 0;

#ifdef DYNAMIC_DATA
    QuerySecurityIntradayDealOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QuerySecurityIntradayDealOutput* pOutput = (QuerySecurityIntradayDealOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QuerySecurityIntradayDeal(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QuerySecurityIntradayDeal END *********\n");
        printf("\n");
        return;
    }

    printf("%-15s\t%-15s\t%-25s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\n", "成交时间", "成交编号", "委托编号", "申报编号", "股东代码", "交易所代码", "合约代码", "合约名称", "交易标志", "成交价格", "成交数量");
    for (int i = 0; i < pOutput->Count; i++)
    {
        QuerySecurityIntradayDealOutputItem* pItem = pOutput->Items + i;
        printf("%-15d\t%-15s\t%-25s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15.4f\t%-15d\n",
            pItem->DealTime,
            pItem->DealID,
            pItem->OrderID,
            pItem->QuoteNumber,

            pItem->StockholderCode,
            pItem->ExchangeId,
            pItem->InstrumentCode,
            pItem->InstrumentName,

            GetTradeFlagText(pItem->TradeFlag),
            pItem->DealPrice,
            pItem->DealVolume);
    }
    printf("******* QuerySecurityIntradayDeal END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QuerySecurityHistoricalDeal()
{
    printf("******* QuerySecurityHistoricalDeal BEGIN *********\n");

    QuerySecurityHistoricalDealInput input = { 0 };
    input.BeginDate = 20181212;
    input.EndDate = 20181213;

#ifdef DYNAMIC_DATA
    QuerySecurityHistoricalDealOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QuerySecurityHistoricalDealOutput* pOutput = (QuerySecurityHistoricalDealOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QuerySecurityHistoricalDeal(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QuerySecurityHistoricalDeal END *********\n");
        printf("\n");
        return;
    }

    printf("%-15s\t%-15s\t%-25s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\n", "成交日期", "成交时间", "成交编号", "股东代码", "交易所代码", "合约代码", "合约名称", "交易标志", "成交价格", "成交数量");
    for (int i = 0; i < pOutput->Count; i++)
    {
        QuerySecurityHistoricalDealOutputItem* pItem = pOutput->Items + i;
        printf("%-15d\t%-15d\t%-25s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15s\t%-15.4f\t%-15d\n",
            pItem->DealDate,
            pItem->DealTime,
            pItem->DealID,

            pItem->StockholderCode,
            pItem->ExchangeId,
            pItem->InstrumentCode,
            pItem->InstrumentName,

            GetTradeFlagText(pItem->TradeFlag),
            pItem->DealPrice,
            pItem->DealVolume);

    }
    printf("******* QuerySecurityHistoricalDeal END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_QuerySecurityOrderEvaluation()
{
    printf("******* QueryTickData BEGIN *********\n");

    QuerySecurityOrderEvaluationInput input = { 0 };
    CopyString(input.ExchangeId, "SSE");
    CopyString(input.InstrumentCode, "601288");
    input.LatestPrice = 3.52;
    input.CapitalAmount = 53612.15;

#ifdef DYNAMIC_DATA
    QuerySecurityOrderEvaluationOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    QuerySecurityOrderEvaluationOutput* pOutput = (QuerySecurityOrderEvaluationOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_QuerySecurityOrderEvaluation(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* QuerySecurityOrderEvaluation END *********\n");
        printf("\n");
        return;
    }

    QuerySecurityOrderEvaluationOutput* pItem = pOutput;
    printf("可买数量:%.0f\n",
        pItem->BidableVolume);
    printf("******* QuerySecurityOrderEvaluation END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

//void test_QuerySecurityOrderCapacity()
//{
//    printf("******* QueryTickData BEGIN *********\n");
//
//    QuerySecurityOrderCapacityInput input = { 0 };
//    CopyString(input.ExchangeId, "SSE");
//    CopyString(input.InstrumentCode, "601288");
//
//#ifdef DYNAMIC_DATA
//    QuerySecurityOrderCapacityOutput* pOutput = NULL;
//#else
//    Byte buffer[50000];
//    QuerySecurityOrderCapacityOutput* pOutput = (QuerySecurityOrderCapacityOutput*)buffer;
//    pOutput->Size = sizeof(buffer);
//#endif
//
//    int result = rushquant_trade_QuerySecurityOrderCapacity(g_AccountId, &input, &pOutput);
//    if (result != Error_Success)
//    {
//        printf("%d: %s\n", result, pOutput->ErrorMessage);
//        printf("******* QuerySecurityOrderCapacity END *********\n");
//        printf("\n");
//        return;
//    }
//
//    QuerySecurityOrderCapacityOutput* pItem = pOutput;
//    printf("可用金额:%.0f, 证券名称:%s\n",
//        pItem->AvailableCapitalAmount, pItem->InstrumentName);
//    printf("******* QuerySecurityOrderCapacity END *********\n");
//    printf("\n");
//
//#ifdef DYNAMIC_DATA
//    rushquant_free(pOutput);
//#endif
//}

void test_PostSecuritySubmitOrder()
{
    printf("******* PostSecuritySubmitOrder BEGIN *********\n");

    PostSecuritySubmitOrderInput input = { 0 };
    CopyString(input.ExchangeId, "SSE");
    CopyString(input.InstrumentCode, "601288");
    input.TradeFlag = TradeFlag_Buy;
    input.QuoteType = QuoteType_SSE_LimitPrice;
    input.OrderPrice = 3.42;
    input.OrderVolume = 100;

#ifdef DYNAMIC_DATA
    PostSecuritySubmitOrderOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    PostSecuritySubmitOrderOutput* pOutput = (PostSecuritySubmitOrderOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_PostSecuritySubmitOrder(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* PostSecuritySubmitOrder END *********\n");
        printf("\n");
        return;
    }

    PostSecuritySubmitOrderOutput* pItem = pOutput;
    printf("委托编号: %s\n",
        pItem->OrderID);
    printf("******* PostSecuritySubmitOrder END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_PostSecuritySubmitOrder_NotReturn()
{
    //printf("******* PostSecuritySubmitOrder BEGIN *********\n");

    PostSecuritySubmitOrderInput input = { 0 };
    CopyString(input.ExchangeId, "SSE");
    CopyString(input.InstrumentCode, "601288");
    input.TradeFlag = TradeFlag_Buy;
    input.QuoteType = QuoteType_SSE_LimitPrice;
    input.OrderPrice = 3.25;
    input.OrderVolume = 100;

    int result = rushquant_trade_PostSecuritySubmitOrder(g_AccountId, &input, NULL);
    if (result != Error_Success)
    {
        printf("%d\n", result);
        printf("******* PostSecuritySubmitOrder END *********\n");
        printf("\n");
        return;
    }

    //printf("******* PostSecuritySubmitOrder END *********\n");
    //printf("\n");
}

void test_PostSecuritySubmitOrder_Purchase()
{
    printf("******* PostSecuritySubmitOrder BEGIN *********\n");

    PostSecuritySubmitOrderInput input = { 0 };
    CopyString(input.ExchangeId, "SSE");
    CopyString(input.InstrumentCode, "511851");
    input.TradeFlag = TradeFlag_Purchase;
    input.QuoteType = QuoteType_SSE_LimitPrice;
    input.OrderPrice = 1.0;
    input.OrderVolume = 100;

#ifdef DYNAMIC_DATA
    PostSecuritySubmitOrderOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    PostSecuritySubmitOrderOutput* pOutput = (PostSecuritySubmitOrderOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_PostSecuritySubmitOrder(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* PostSecuritySubmitOrder END *********\n");
        printf("\n");
        return;
    }

    PostSecuritySubmitOrderOutput* pItem = pOutput;
    printf("委托编号: %s\n",
        pItem->OrderID);
    printf("******* PostSecuritySubmitOrder END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

void test_PostSecurityCancelOrder()
{
    printf("******* PostSecurityCancelOrder BEGIN *********\n");

    PostSecurityCancelOrderInput input = { 0 };
    CopyString(input.ExchangeId, "SZE");
    CopyString(input.OrderID, "6080");

#ifdef DYNAMIC_DATA
    PostSecurityCancelOrderOutput* pOutput = NULL;
#else
    Byte buffer[50000];
    PostSecurityCancelOrderOutput* pOutput = (PostSecurityCancelOrderOutput*)buffer;
    pOutput->Size = sizeof(buffer);
#endif

    int result = rushquant_trade_PostSecurityCancelOrder(g_AccountId, &input, &pOutput);
    if (result != Error_Success)
    {
        printf("%d: %s\n", result, pOutput->ErrorMessage);
        printf("******* PostSecurityCancelOrder END *********\n");
        printf("\n");
        return;
    }

    PostSecurityCancelOrderOutput* pItem = pOutput;
    //printf("委托编号: %s\n",
    //    pItem->OrderID);
    printf("******* PostSecurityCancelOrder END *********\n");
    printf("\n");

#ifdef DYNAMIC_DATA
    rushquant_free(pOutput);
#endif
}

int main(int argc, char* argv[])
{
    int result;
    // initialize
    result = rushquant_initialize("jimcai", "zrqJzuCpdldVL9o8cvOA3tJJZ+HHBccvADtuPy2GwedMzRow0wpGD9S6CHPgMJTPOSNpmt6d789z0N4PNnooVQ==");
    if (result != Error_Success)
    {
        printf("Initialize Error: %d", result);
        return result;
    }

    int accountId[1000];
    int count = rushquant_trade_GetAccountList(accountId);


    // reset account
    result = rushquant_trade_Reset(g_AccountId);
    if (result != Error_Success)
    {
        printf("Reset Error: %d", result);
        return result;
    }
    // Login
    LoginInput input = { 0 };
    // 设置交易密码
    CopyString(input.TradePassword, g_Password);
    LoginOutput output = { 0 };
    result = rushquant_trade_Login(g_AccountId, &input, &output);
    if (result != Error_Success)
    {
        printf("Login Error: %d, Message: %s", result, output.ErrorMessage);
        return result;
    }

    //test_QueryTickData();
    //test_QueryStockholderInfo();
    //test_QuerySecurityCapitalInfo();
    //test_QuerySecurityPositionInfo();
    //test_QuerySecurityIntradayOrder();
    //test_QuerySecurityHistoricalOrder();
    //test_QuerySecurityIntradayDeal();
    //test_QuerySecurityHistoricalDeal();
    //test_QuerySecurityOrderEvaluation();
    //test_QuerySecurityOrderCapacity();
    //test_PostSecuritySubmitOrder();
    //Sleep(500);
    //test_PostSecuritySubmitOrder();
    //test_PostSecuritySubmitOrder_Purchase();
    //test_PostSecurityCancelOrder();

 /*   for (int i = 0; i < 5; i++)
    {
        test_PostSecuritySubmitOrder_NotReturn();
    }*/

    rushquant_dispose();

    system("pause");
    return 0;
}