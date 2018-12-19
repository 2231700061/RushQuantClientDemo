using System;

namespace RushQuant.Clients
{
    /// <summary>交易所编号</summary>
    public static class ExchangeId
    {
        /// <summary>上海证券交易所</summary>
        public const string SSE = "SSE";
        /// <summary>深圳证券交易所</summary>
        public const string SZE = "SZE";
    }

    /// <summary>货币代码</summary>
    public enum Currency
    {
        /// <summary>人民币</summary>
        [Description("人民币")]
        RMB = 0,
    }

    /// <summary>报价方式</summary>
    public enum QuoteType
    {
        /// <summary>上海: 限价委托</summary>
        [Description("上海: 限价委托")]
        SSE_LimitPrice = 1,
        /// <summary>上海: 五档即成剩撤</summary>
        [Description("上海: 五档即成剩撤")]
        SSE_FivePriceThenCancel = 5,
        /// <summary>上海: 五档即成转限价</summary>
        [Description("上海: 五档即成转限价")]
        SSE_FivePriceThenLimitPrice = 7,
        /// <summary>深圳: 限价委托</summary>
        [Description("深圳: 限价委托")]
        SZE_LimitPrice = 1,
        /// <summary>深圳: 对方最优价格</summary>
        [Description("深圳: 对方最优价格")]
        SZE_CounterpartyBestPrice = 2,
        /// <summary>深圳: 本方最优价格</summary>
        [Description("深圳: 本方最优价格")]
        SZE_BestPrice = 3,
        /// <summary>深圳: 即时成交剩余撤销</summary>
        [Description("深圳: 即时成交剩余撤销")]
        SZE_AnyPriceThenCancel = 4,
        /// <summary>深圳: 五档即成剩撤</summary>
        [Description("深圳: 五档即成剩撤")]
        SZE_FivePriceThenCancel = 5,
        /// <summary>深圳: 全额成交或撤销</summary>
        [Description("深圳: 全额成交或撤销")]
        SZE_AllPriceOrCancel = 6,
    }

    /// <summary>交易标志</summary>
    public enum TradeFlag
    {
        /// <summary>买入</summary>
        [Description("买入")]
        Buy = 1,
        /// <summary>卖出</summary>
        [Description("卖出")]
        Sell = 2,
        /// <summary>申购</summary>
        [Description("申购")]
        Purchase = 3,
        /// <summary>赎回</summary>
        [Description("赎回")]
        Redeem = 4,
        /// <summary>融资买入</summary>
        [Description("融资买入")]
        MarginBuy = 6,
        /// <summary>融券卖出</summary>
        [Description("融券卖出")]
        MarginSell = 7,
        /// <summary>融资售回</summary>
        [Description("融资售回")]
        MarginBuyCover = 8,
        /// <summary>融券购回</summary>
        [Description("融券购回")]
        MarginSellCover = 9,
        /// <summary>ETF申购</summary>
        [Description("ETF申购")]
        ETFPurchase = 11,
        /// <summary>ETF赎回</summary>
        [Description("ETF赎回")]
        ETFRedeem = 12,
        /// <summary>基金申购</summary>
        [Description("基金申购")]
        FundPurchase = 13,
        /// <summary>基金赎回</summary>
        [Description("基金赎回")]
        FundRedeem = 14,
        /// <summary>分级基金合并</summary>
        [Description("分级基金合并")]
        GradedFundMerge = 17,
        /// <summary>分级基金合拆</summary>
        [Description("分级基金合拆")]
        GradedFundSplit = 18,
        /// <summary>基金认购</summary>
        [Description("基金认购")]
        FundSubscribe = 19,
        /// <summary>配售</summary>
        [Description("配售")]
        Placement = 21,
        /// <summary>配号</summary>
        [Description("配号")]
        Distribution = 22,
        /// <summary>撤买</summary>
        [Description("撤买")]
        CancelBuy = -1,
        /// <summary>撤卖</summary>
        [Description("撤卖")]
        CancelSell = -2,
    }

    /// <summary>委托状态</summary>
    public enum OrderStatus
    {
        /// <summary>待撤：撤单指令还未报到场内。</summary>
        [Description("待撤：撤单指令还未报到场内。")]
        PendingCancel = 1,
        /// <summary>正撤：撤单指令已送达公司，正在等待处理，此时不能确定是否已进场。</summary>
        [Description("正撤：撤单指令已送达公司，正在等待处理，此时不能确定是否已进场。")]
        Canceling = 2,
        /// <summary>部撤：下单指令中的一部份数量已被撤消。</summary>
        [Description("部撤：下单指令中的一部份数量已被撤消。")]
        PartialCanceled = 3,
        /// <summary>已撤：委托指令全部被撤消。</summary>
        [Description("已撤：委托指令全部被撤消。")]
        Canceled = 4,
        /// <summary>未报：下单指令还未送入数据处理。</summary>
        [Description("未报：下单指令还未送入数据处理。")]
        Unquote = 5,
        /// <summary>待报：下单指令还未被数据处理报到场内。</summary>
        [Description("待报：下单指令还未被数据处理报到场内。")]
        PendingQuote = 6,
        /// <summary>正报：下单指令已送达公司，正在等待处理，此时不能确定是否已进场。</summary>
        [Description("正报：下单指令已送达公司，正在等待处理，此时不能确定是否已进场。")]
        Quoting = 7,
        /// <summary>已报：已收到下单反馈。</summary>
        [Description("已报：已收到下单反馈。")]
        Quoted = 8,
        /// <summary>部成：下单指令部份成交。</summary>
        [Description("部成：下单指令部份成交。")]
        PartialDealed = 9,
        /// <summary>已成：下单指令全部成交。</summary>
        [Description("已成：下单指令全部成交。")]
        Dealed = 10,
        /// <summary>撤废：撤单废单，表示撤单指令失败，原因可能是被撤的下单指令已经成交了或场内无法找到这条下单记录。</summary>
        [Description("撤废：撤单废单，表示撤单指令失败，原因可能是被撤的下单指令已经成交了或场内无法找到这条下单记录。")]
        CancelInvalid = 11,
        /// <summary>废单：交易所反馈的信息，表示该定单无效。</summary>
        [Description("废单：交易所反馈的信息，表示该定单无效。")]
        Invalid = 12,
        /// <summary>报撤：报单已经取消。</summary>
        [Description("报撤：报单已经取消。")]
        QuoteCanceled = 13,
    }

}
