using System;
using System.Text;

namespace RushQuant.Clients
{
    internal static class PInvokeHelper
    {
        public static Encoding DefaultEncoding { get; } = Encoding.GetEncoding("gb2312");

        public static unsafe void WriteString(string text, byte* p, int size)
        {
            if (text != null)
            {
                fixed (char* c = text)
                {
                    int count = PInvokeHelper.DefaultEncoding.GetBytes(c, text.Length, p, size);
                    *(p + count) = 0;
                }
            }
            else
            {
                *p = 0;
            }
        }

        public static unsafe string ReadString(byte* p, int size)
        {
            int index = -1;
            for (int i = 0; i < size; i++)
            {
                if (*(p + i) == 0)
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
            {
                return null;
            }

            return DefaultEncoding.GetString(p, index);
        }
    }

    public sealed class LoginInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private string _tradePassword;
        /// <summary>交易密码</summary>
        public string TradePassword
        {
            get
            {
                return this._tradePassword;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._tradePassword = value;
            }
        }
        private string _communicationPassword;
        /// <summary>通讯密码</summary>
        public string CommunicationPassword
        {
            get
            {
                return this._communicationPassword;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._communicationPassword = value;
            }
        }

        internal static int GetSize()
        {
            return 28;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            PInvokeHelper.WriteString(this._tradePassword, p, 12); p += 12;
            PInvokeHelper.WriteString(this._communicationPassword, p, 12); p += 12;
        }
    }
    public sealed class LoginOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
        }
    }

    public sealed class QueryTickDataInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }

        internal static int GetSize()
        {
            return 30;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            PInvokeHelper.WriteString(this._exchangeId, p, 10); p += 10;
            PInvokeHelper.WriteString(this._instrumentCode, p, 16); p += 16;
        }
    }
    public sealed class QueryTickDataOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private string _instrumentName;
        /// <summary>合约名称</summary>
        public string InstrumentName
        {
            get
            {
                return this._instrumentName;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 32))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentName = value;
            }
        }
        private double _preClosePrice;
        public double PreClosePrice
        {
            get
            {
                return this._preClosePrice;
            }
            set
            {
                this._preClosePrice = value;
            }
        }
        private double _openPrice;
        public double OpenPrice
        {
            get
            {
                return this._openPrice;
            }
            set
            {
                this._openPrice = value;
            }
        }
        private double _latestPrice;
        public double LatestPrice
        {
            get
            {
                return this._latestPrice;
            }
            set
            {
                this._latestPrice = value;
            }
        }
        private double _bidPrice1;
        public double BidPrice1
        {
            get
            {
                return this._bidPrice1;
            }
            set
            {
                this._bidPrice1 = value;
            }
        }
        private double _bidPrice2;
        public double BidPrice2
        {
            get
            {
                return this._bidPrice2;
            }
            set
            {
                this._bidPrice2 = value;
            }
        }
        private double _bidPrice3;
        public double BidPrice3
        {
            get
            {
                return this._bidPrice3;
            }
            set
            {
                this._bidPrice3 = value;
            }
        }
        private double _bidPrice4;
        public double BidPrice4
        {
            get
            {
                return this._bidPrice4;
            }
            set
            {
                this._bidPrice4 = value;
            }
        }
        private double _bidPrice5;
        public double BidPrice5
        {
            get
            {
                return this._bidPrice5;
            }
            set
            {
                this._bidPrice5 = value;
            }
        }
        private int _bidVolume1;
        public int BidVolume1
        {
            get
            {
                return this._bidVolume1;
            }
            set
            {
                this._bidVolume1 = value;
            }
        }
        private int _bidVolume2;
        public int BidVolume2
        {
            get
            {
                return this._bidVolume2;
            }
            set
            {
                this._bidVolume2 = value;
            }
        }
        private int _bidVolume3;
        public int BidVolume3
        {
            get
            {
                return this._bidVolume3;
            }
            set
            {
                this._bidVolume3 = value;
            }
        }
        private int _bidVolume4;
        public int BidVolume4
        {
            get
            {
                return this._bidVolume4;
            }
            set
            {
                this._bidVolume4 = value;
            }
        }
        private int _bidVolume5;
        public int BidVolume5
        {
            get
            {
                return this._bidVolume5;
            }
            set
            {
                this._bidVolume5 = value;
            }
        }
        private double _askPrice1;
        public double AskPrice1
        {
            get
            {
                return this._askPrice1;
            }
            set
            {
                this._askPrice1 = value;
            }
        }
        private double _askPrice2;
        public double AskPrice2
        {
            get
            {
                return this._askPrice2;
            }
            set
            {
                this._askPrice2 = value;
            }
        }
        private double _askPrice3;
        public double AskPrice3
        {
            get
            {
                return this._askPrice3;
            }
            set
            {
                this._askPrice3 = value;
            }
        }
        private double _askPrice4;
        public double AskPrice4
        {
            get
            {
                return this._askPrice4;
            }
            set
            {
                this._askPrice4 = value;
            }
        }
        private double _askPrice5;
        public double AskPrice5
        {
            get
            {
                return this._askPrice5;
            }
            set
            {
                this._askPrice5 = value;
            }
        }
        private int _askVolume1;
        public int AskVolume1
        {
            get
            {
                return this._askVolume1;
            }
            set
            {
                this._askVolume1 = value;
            }
        }
        private int _askVolume2;
        public int AskVolume2
        {
            get
            {
                return this._askVolume2;
            }
            set
            {
                this._askVolume2 = value;
            }
        }
        private int _askVolume3;
        public int AskVolume3
        {
            get
            {
                return this._askVolume3;
            }
            set
            {
                this._askVolume3 = value;
            }
        }
        private int _askVolume4;
        public int AskVolume4
        {
            get
            {
                return this._askVolume4;
            }
            set
            {
                this._askVolume4 = value;
            }
        }
        private int _askVolume5;
        public int AskVolume5
        {
            get
            {
                return this._askVolume5;
            }
            set
            {
                this._askVolume5 = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._exchangeId = PInvokeHelper.ReadString(p, 10); p += 10;
            this._instrumentCode = PInvokeHelper.ReadString(p, 16); p += 16;
            this._instrumentName = PInvokeHelper.ReadString(p, 32); p += 32;
            this._preClosePrice = *(double*)p; p += 8;
            this._openPrice = *(double*)p; p += 8;
            this._latestPrice = *(double*)p; p += 8;
            this._bidPrice1 = *(double*)p; p += 8;
            this._bidPrice2 = *(double*)p; p += 8;
            this._bidPrice3 = *(double*)p; p += 8;
            this._bidPrice4 = *(double*)p; p += 8;
            this._bidPrice5 = *(double*)p; p += 8;
            this._bidVolume1 = *(int*)p; p += 4;
            this._bidVolume2 = *(int*)p; p += 4;
            this._bidVolume3 = *(int*)p; p += 4;
            this._bidVolume4 = *(int*)p; p += 4;
            this._bidVolume5 = *(int*)p; p += 4;
            this._askPrice1 = *(double*)p; p += 8;
            this._askPrice2 = *(double*)p; p += 8;
            this._askPrice3 = *(double*)p; p += 8;
            this._askPrice4 = *(double*)p; p += 8;
            this._askPrice5 = *(double*)p; p += 8;
            this._askVolume1 = *(int*)p; p += 4;
            this._askVolume2 = *(int*)p; p += 4;
            this._askVolume3 = *(int*)p; p += 4;
            this._askVolume4 = *(int*)p; p += 4;
            this._askVolume5 = *(int*)p; p += 4;
        }
    }

    public sealed class QueryStockholderInfoInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        internal static int GetSize()
        {
            return 4;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
        }
    }
    public sealed class QueryStockholderInfoOutputItem
    {
        private string _stockholderCode;
        /// <summary>股东代码</summary>
        public string StockholderCode
        {
            get
            {
                return this._stockholderCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._stockholderCode = value;
            }
        }
        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }

        internal static int GetSize()
        {
            return 22;
        }

        internal unsafe void ReadFrom(byte* p)
        {
            this._stockholderCode = PInvokeHelper.ReadString(p, 12); p += 12;
            this._exchangeId = PInvokeHelper.ReadString(p, 10); p += 10;
        }
    }
    public sealed class QueryStockholderInfoOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        private QueryStockholderInfoOutputItem[] _items;
        public QueryStockholderInfoOutputItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._total = *(int*)p; p += 4;
            this._count = *(int*)p; p += 4;
            this._items = new QueryStockholderInfoOutputItem[this._count];
            for (int i = 0; i < this._count; i++)
            {
                this._items[i] = new QueryStockholderInfoOutputItem();
                this._items[i].ReadFrom(p);
                p += QueryStockholderInfoOutputItem.GetSize();
            }
        }
    }

    public sealed class QuerySecurityCapitalInfoInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        internal static int GetSize()
        {
            return 4;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
        }
    }
    public sealed class QuerySecurityCapitalInfoOutputItem
    {
        private int _currency;
        public int Currency
        {
            get
            {
                return this._currency;
            }
            set
            {
                this._currency = value;
            }
        }
        private double _remainingCapitalAmount;
        public double RemainingCapitalAmount
        {
            get
            {
                return this._remainingCapitalAmount;
            }
            set
            {
                this._remainingCapitalAmount = value;
            }
        }
        private double _availableCapitalAmount;
        public double AvailableCapitalAmount
        {
            get
            {
                return this._availableCapitalAmount;
            }
            set
            {
                this._availableCapitalAmount = value;
            }
        }
        private double _withdrawableCapitalAmount;
        public double WithdrawableCapitalAmount
        {
            get
            {
                return this._withdrawableCapitalAmount;
            }
            set
            {
                this._withdrawableCapitalAmount = value;
            }
        }
        private double _totalAssetAmount;
        public double TotalAssetAmount
        {
            get
            {
                return this._totalAssetAmount;
            }
            set
            {
                this._totalAssetAmount = value;
            }
        }

        internal static int GetSize()
        {
            return 36;
        }

        internal unsafe void ReadFrom(byte* p)
        {
            this._currency = *(int*)p; p += 4;
            this._remainingCapitalAmount = *(double*)p; p += 8;
            this._availableCapitalAmount = *(double*)p; p += 8;
            this._withdrawableCapitalAmount = *(double*)p; p += 8;
            this._totalAssetAmount = *(double*)p; p += 8;
        }
    }
    public sealed class QuerySecurityCapitalInfoOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        private QuerySecurityCapitalInfoOutputItem[] _items;
        public QuerySecurityCapitalInfoOutputItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._total = *(int*)p; p += 4;
            this._count = *(int*)p; p += 4;
            this._items = new QuerySecurityCapitalInfoOutputItem[this._count];
            for (int i = 0; i < this._count; i++)
            {
                this._items[i] = new QuerySecurityCapitalInfoOutputItem();
                this._items[i].ReadFrom(p);
                p += QuerySecurityCapitalInfoOutputItem.GetSize();
            }
        }
    }

    public sealed class QuerySecurityPositionInfoInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        internal static int GetSize()
        {
            return 4;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
        }
    }
    public sealed class QuerySecurityPositionInfoOutputItem
    {
        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private string _instrumentName;
        /// <summary>合约代码</summary>
        public string InstrumentName
        {
            get
            {
                return this._instrumentName;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 32))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentName = value;
            }
        }
        private int _volume;
        public int Volume
        {
            get
            {
                return this._volume;
            }
            set
            {
                this._volume = value;
            }
        }
        private int _availableVolume;
        public int AvailableVolume
        {
            get
            {
                return this._availableVolume;
            }
            set
            {
                this._availableVolume = value;
            }
        }
        private string _stockholderCode;
        /// <summary>股东代码</summary>
        public string StockholderCode
        {
            get
            {
                return this._stockholderCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._stockholderCode = value;
            }
        }

        internal static int GetSize()
        {
            return 78;
        }

        internal unsafe void ReadFrom(byte* p)
        {
            this._exchangeId = PInvokeHelper.ReadString(p, 10); p += 10;
            this._instrumentCode = PInvokeHelper.ReadString(p, 16); p += 16;
            this._instrumentName = PInvokeHelper.ReadString(p, 32); p += 32;
            this._volume = *(int*)p; p += 4;
            this._availableVolume = *(int*)p; p += 4;
            this._stockholderCode = PInvokeHelper.ReadString(p, 12); p += 12;
        }
    }
    public sealed class QuerySecurityPositionInfoOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        private QuerySecurityPositionInfoOutputItem[] _items;
        public QuerySecurityPositionInfoOutputItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._total = *(int*)p; p += 4;
            this._count = *(int*)p; p += 4;
            this._items = new QuerySecurityPositionInfoOutputItem[this._count];
            for (int i = 0; i < this._count; i++)
            {
                this._items[i] = new QuerySecurityPositionInfoOutputItem();
                this._items[i].ReadFrom(p);
                p += QuerySecurityPositionInfoOutputItem.GetSize();
            }
        }
    }

    public sealed class QuerySecurityOrderEvaluationInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private double _orderPrice;
        public double OrderPrice
        {
            get
            {
                return this._orderPrice;
            }
            set
            {
                this._orderPrice = value;
            }
        }
        private double _latestPrice;
        public double LatestPrice
        {
            get
            {
                return this._latestPrice;
            }
            set
            {
                this._latestPrice = value;
            }
        }
        private double _capitalAmount;
        public double CapitalAmount
        {
            get
            {
                return this._capitalAmount;
            }
            set
            {
                this._capitalAmount = value;
            }
        }

        internal static int GetSize()
        {
            return 54;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            PInvokeHelper.WriteString(this._exchangeId, p, 10); p += 10;
            PInvokeHelper.WriteString(this._instrumentCode, p, 16); p += 16;
            *(double*)p = this._orderPrice; p += 8;
            *(double*)p = this._latestPrice; p += 8;
            *(double*)p = this._capitalAmount; p += 8;
        }
    }
    public sealed class QuerySecurityOrderEvaluationOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private double _bidableVolume;
        public double BidableVolume
        {
            get
            {
                return this._bidableVolume;
            }
            set
            {
                this._bidableVolume = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._bidableVolume = *(double*)p; p += 8;
        }
    }

    public sealed class QuerySecurityIntradayOrderInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private int _beginNumber;
        public int BeginNumber
        {
            get
            {
                return this._beginNumber;
            }
            set
            {
                this._beginNumber = value;
            }
        }

        internal static int GetSize()
        {
            return 8;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            *(int*)p = this._beginNumber; p += 4;
        }
    }
    public sealed class QuerySecurityIntradayOrderOutputItem
    {
        private int _orderDate;
        public int OrderDate
        {
            get
            {
                return this._orderDate;
            }
            set
            {
                this._orderDate = value;
            }
        }
        private int _orderTime;
        public int OrderTime
        {
            get
            {
                return this._orderTime;
            }
            set
            {
                this._orderTime = value;
            }
        }
        private string _orderID;
        /// <summary>委托编号</summary>
        public string OrderID
        {
            get
            {
                return this._orderID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._orderID = value;
            }
        }
        private string _stockholderCode;
        /// <summary>股东代码</summary>
        public string StockholderCode
        {
            get
            {
                return this._stockholderCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._stockholderCode = value;
            }
        }
        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private string _instrumentName;
        /// <summary>合约名称</summary>
        public string InstrumentName
        {
            get
            {
                return this._instrumentName;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 32))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentName = value;
            }
        }
        private int _tradeFlag;
        public int TradeFlag
        {
            get
            {
                return this._tradeFlag;
            }
            set
            {
                this._tradeFlag = value;
            }
        }
        private double _orderPrice;
        public double OrderPrice
        {
            get
            {
                return this._orderPrice;
            }
            set
            {
                this._orderPrice = value;
            }
        }
        private int _orderVolume;
        public int OrderVolume
        {
            get
            {
                return this._orderVolume;
            }
            set
            {
                this._orderVolume = value;
            }
        }
        private double _dealPrice;
        public double DealPrice
        {
            get
            {
                return this._dealPrice;
            }
            set
            {
                this._dealPrice = value;
            }
        }
        private int _dealVolume;
        public int DealVolume
        {
            get
            {
                return this._dealVolume;
            }
            set
            {
                this._dealVolume = value;
            }
        }
        private int _cancelVolume;
        public int CancelVolume
        {
            get
            {
                return this._cancelVolume;
            }
            set
            {
                this._cancelVolume = value;
            }
        }
        private int _quoteType;
        public int QuoteType
        {
            get
            {
                return this._quoteType;
            }
            set
            {
                this._quoteType = value;
            }
        }
        private int _orderStatus;
        public int OrderStatus
        {
            get
            {
                return this._orderStatus;
            }
            set
            {
                this._orderStatus = value;
            }
        }

        internal static int GetSize()
        {
            return 138;
        }

        internal unsafe void ReadFrom(byte* p)
        {
            this._orderDate = *(int*)p; p += 4;
            this._orderTime = *(int*)p; p += 4;
            this._orderID = PInvokeHelper.ReadString(p, 20); p += 20;
            this._stockholderCode = PInvokeHelper.ReadString(p, 12); p += 12;
            this._exchangeId = PInvokeHelper.ReadString(p, 10); p += 10;
            this._instrumentCode = PInvokeHelper.ReadString(p, 16); p += 16;
            this._instrumentName = PInvokeHelper.ReadString(p, 32); p += 32;
            this._tradeFlag = *(int*)p; p += 4;
            this._orderPrice = *(double*)p; p += 8;
            this._orderVolume = *(int*)p; p += 4;
            this._dealPrice = *(double*)p; p += 8;
            this._dealVolume = *(int*)p; p += 4;
            this._cancelVolume = *(int*)p; p += 4;
            this._quoteType = *(int*)p; p += 4;
            this._orderStatus = *(int*)p; p += 4;
        }
    }
    public sealed class QuerySecurityIntradayOrderOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        private QuerySecurityIntradayOrderOutputItem[] _items;
        public QuerySecurityIntradayOrderOutputItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._total = *(int*)p; p += 4;
            this._count = *(int*)p; p += 4;
            this._items = new QuerySecurityIntradayOrderOutputItem[this._count];
            for (int i = 0; i < this._count; i++)
            {
                this._items[i] = new QuerySecurityIntradayOrderOutputItem();
                this._items[i].ReadFrom(p);
                p += QuerySecurityIntradayOrderOutputItem.GetSize();
            }
        }
    }

    public sealed class QuerySecurityHistoricalOrderInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private int _beginDate;
        public int BeginDate
        {
            get
            {
                return this._beginDate;
            }
            set
            {
                this._beginDate = value;
            }
        }
        private int _endDate;
        public int EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }
        private int _beginNumber;
        public int BeginNumber
        {
            get
            {
                return this._beginNumber;
            }
            set
            {
                this._beginNumber = value;
            }
        }

        internal static int GetSize()
        {
            return 16;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            *(int*)p = this._beginDate; p += 4;
            *(int*)p = this._endDate; p += 4;
            *(int*)p = this._beginNumber; p += 4;
        }
    }
    public sealed class QuerySecurityHistoricalOrderOutputItem
    {
        private int _orderDate;
        public int OrderDate
        {
            get
            {
                return this._orderDate;
            }
            set
            {
                this._orderDate = value;
            }
        }
        private int _orderTime;
        public int OrderTime
        {
            get
            {
                return this._orderTime;
            }
            set
            {
                this._orderTime = value;
            }
        }
        private string _orderID;
        /// <summary>委托编号</summary>
        public string OrderID
        {
            get
            {
                return this._orderID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._orderID = value;
            }
        }
        private string _stockholderCode;
        /// <summary>股东代码</summary>
        public string StockholderCode
        {
            get
            {
                return this._stockholderCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._stockholderCode = value;
            }
        }
        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private string _instrumentName;
        /// <summary>合约名称</summary>
        public string InstrumentName
        {
            get
            {
                return this._instrumentName;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 32))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentName = value;
            }
        }
        private int _tradeFlag;
        public int TradeFlag
        {
            get
            {
                return this._tradeFlag;
            }
            set
            {
                this._tradeFlag = value;
            }
        }
        private double _orderPrice;
        public double OrderPrice
        {
            get
            {
                return this._orderPrice;
            }
            set
            {
                this._orderPrice = value;
            }
        }
        private int _orderVolume;
        public int OrderVolume
        {
            get
            {
                return this._orderVolume;
            }
            set
            {
                this._orderVolume = value;
            }
        }
        private int _dealVolume;
        public int DealVolume
        {
            get
            {
                return this._dealVolume;
            }
            set
            {
                this._dealVolume = value;
            }
        }
        private double _dealAmount;
        public double DealAmount
        {
            get
            {
                return this._dealAmount;
            }
            set
            {
                this._dealAmount = value;
            }
        }
        private int _cancelVolume;
        public int CancelVolume
        {
            get
            {
                return this._cancelVolume;
            }
            set
            {
                this._cancelVolume = value;
            }
        }
        private int _quoteType;
        public int QuoteType
        {
            get
            {
                return this._quoteType;
            }
            set
            {
                this._quoteType = value;
            }
        }
        private int _orderStatus;
        public int OrderStatus
        {
            get
            {
                return this._orderStatus;
            }
            set
            {
                this._orderStatus = value;
            }
        }

        internal static int GetSize()
        {
            return 138;
        }

        internal unsafe void ReadFrom(byte* p)
        {
            this._orderDate = *(int*)p; p += 4;
            this._orderTime = *(int*)p; p += 4;
            this._orderID = PInvokeHelper.ReadString(p, 20); p += 20;
            this._stockholderCode = PInvokeHelper.ReadString(p, 12); p += 12;
            this._exchangeId = PInvokeHelper.ReadString(p, 10); p += 10;
            this._instrumentCode = PInvokeHelper.ReadString(p, 16); p += 16;
            this._instrumentName = PInvokeHelper.ReadString(p, 32); p += 32;
            this._tradeFlag = *(int*)p; p += 4;
            this._orderPrice = *(double*)p; p += 8;
            this._orderVolume = *(int*)p; p += 4;
            this._dealVolume = *(int*)p; p += 4;
            this._dealAmount = *(double*)p; p += 8;
            this._cancelVolume = *(int*)p; p += 4;
            this._quoteType = *(int*)p; p += 4;
            this._orderStatus = *(int*)p; p += 4;
        }
    }
    public sealed class QuerySecurityHistoricalOrderOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        private QuerySecurityHistoricalOrderOutputItem[] _items;
        public QuerySecurityHistoricalOrderOutputItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._total = *(int*)p; p += 4;
            this._count = *(int*)p; p += 4;
            this._items = new QuerySecurityHistoricalOrderOutputItem[this._count];
            for (int i = 0; i < this._count; i++)
            {
                this._items[i] = new QuerySecurityHistoricalOrderOutputItem();
                this._items[i].ReadFrom(p);
                p += QuerySecurityHistoricalOrderOutputItem.GetSize();
            }
        }
    }

    public sealed class QuerySecurityIntradayDealInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private int _beginNumber;
        public int BeginNumber
        {
            get
            {
                return this._beginNumber;
            }
            set
            {
                this._beginNumber = value;
            }
        }

        internal static int GetSize()
        {
            return 8;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            *(int*)p = this._beginNumber; p += 4;
        }
    }
    public sealed class QuerySecurityIntradayDealOutputItem
    {
        private int _dealTime;
        public int DealTime
        {
            get
            {
                return this._dealTime;
            }
            set
            {
                this._dealTime = value;
            }
        }
        private string _dealID;
        /// <summary>成交编号</summary>
        public string DealID
        {
            get
            {
                return this._dealID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._dealID = value;
            }
        }
        private string _orderID;
        /// <summary>委托编号</summary>
        public string OrderID
        {
            get
            {
                return this._orderID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._orderID = value;
            }
        }
        private string _quoteNumber;
        /// <summary>申报编号</summary>
        public string QuoteNumber
        {
            get
            {
                return this._quoteNumber;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._quoteNumber = value;
            }
        }
        private string _stockholderCode;
        /// <summary>股东代码</summary>
        public string StockholderCode
        {
            get
            {
                return this._stockholderCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._stockholderCode = value;
            }
        }
        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private string _instrumentName;
        /// <summary>合约名称</summary>
        public string InstrumentName
        {
            get
            {
                return this._instrumentName;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 32))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentName = value;
            }
        }
        private int _tradeFlag;
        public int TradeFlag
        {
            get
            {
                return this._tradeFlag;
            }
            set
            {
                this._tradeFlag = value;
            }
        }
        private double _dealPrice;
        public double DealPrice
        {
            get
            {
                return this._dealPrice;
            }
            set
            {
                this._dealPrice = value;
            }
        }
        private int _dealVolume;
        public int DealVolume
        {
            get
            {
                return this._dealVolume;
            }
            set
            {
                this._dealVolume = value;
            }
        }

        internal static int GetSize()
        {
            return 150;
        }

        internal unsafe void ReadFrom(byte* p)
        {
            this._dealTime = *(int*)p; p += 4;
            this._dealID = PInvokeHelper.ReadString(p, 20); p += 20;
            this._orderID = PInvokeHelper.ReadString(p, 20); p += 20;
            this._quoteNumber = PInvokeHelper.ReadString(p, 20); p += 20;
            this._stockholderCode = PInvokeHelper.ReadString(p, 12); p += 12;
            this._exchangeId = PInvokeHelper.ReadString(p, 10); p += 10;
            this._instrumentCode = PInvokeHelper.ReadString(p, 16); p += 16;
            this._instrumentName = PInvokeHelper.ReadString(p, 32); p += 32;
            this._tradeFlag = *(int*)p; p += 4;
            this._dealPrice = *(double*)p; p += 8;
            this._dealVolume = *(int*)p; p += 4;
        }
    }
    public sealed class QuerySecurityIntradayDealOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        private QuerySecurityIntradayDealOutputItem[] _items;
        public QuerySecurityIntradayDealOutputItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._total = *(int*)p; p += 4;
            this._count = *(int*)p; p += 4;
            this._items = new QuerySecurityIntradayDealOutputItem[this._count];
            for (int i = 0; i < this._count; i++)
            {
                this._items[i] = new QuerySecurityIntradayDealOutputItem();
                this._items[i].ReadFrom(p);
                p += QuerySecurityIntradayDealOutputItem.GetSize();
            }
        }
    }

    public sealed class QuerySecurityHistoricalDealInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private int _beginDate;
        public int BeginDate
        {
            get
            {
                return this._beginDate;
            }
            set
            {
                this._beginDate = value;
            }
        }
        private int _endDate;
        public int EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }
        private int _beginNumber;
        public int BeginNumber
        {
            get
            {
                return this._beginNumber;
            }
            set
            {
                this._beginNumber = value;
            }
        }

        internal static int GetSize()
        {
            return 16;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            *(int*)p = this._beginDate; p += 4;
            *(int*)p = this._endDate; p += 4;
            *(int*)p = this._beginNumber; p += 4;
        }
    }
    public sealed class QuerySecurityHistoricalDealOutputItem
    {
        private int _dealDate;
        public int DealDate
        {
            get
            {
                return this._dealDate;
            }
            set
            {
                this._dealDate = value;
            }
        }
        private int _dealTime;
        public int DealTime
        {
            get
            {
                return this._dealTime;
            }
            set
            {
                this._dealTime = value;
            }
        }
        private string _dealID;
        /// <summary>成交编号</summary>
        public string DealID
        {
            get
            {
                return this._dealID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._dealID = value;
            }
        }
        private string _stockholderCode;
        /// <summary>股东代码</summary>
        public string StockholderCode
        {
            get
            {
                return this._stockholderCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 12))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._stockholderCode = value;
            }
        }
        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private string _instrumentName;
        /// <summary>合约名称</summary>
        public string InstrumentName
        {
            get
            {
                return this._instrumentName;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 32))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentName = value;
            }
        }
        private int _tradeFlag;
        public int TradeFlag
        {
            get
            {
                return this._tradeFlag;
            }
            set
            {
                this._tradeFlag = value;
            }
        }
        private double _dealPrice;
        public double DealPrice
        {
            get
            {
                return this._dealPrice;
            }
            set
            {
                this._dealPrice = value;
            }
        }
        private int _dealVolume;
        public int DealVolume
        {
            get
            {
                return this._dealVolume;
            }
            set
            {
                this._dealVolume = value;
            }
        }

        internal static int GetSize()
        {
            return 114;
        }

        internal unsafe void ReadFrom(byte* p)
        {
            this._dealDate = *(int*)p; p += 4;
            this._dealTime = *(int*)p; p += 4;
            this._dealID = PInvokeHelper.ReadString(p, 20); p += 20;
            this._stockholderCode = PInvokeHelper.ReadString(p, 12); p += 12;
            this._exchangeId = PInvokeHelper.ReadString(p, 10); p += 10;
            this._instrumentCode = PInvokeHelper.ReadString(p, 16); p += 16;
            this._instrumentName = PInvokeHelper.ReadString(p, 32); p += 32;
            this._tradeFlag = *(int*)p; p += 4;
            this._dealPrice = *(double*)p; p += 8;
            this._dealVolume = *(int*)p; p += 4;
        }
    }
    public sealed class QuerySecurityHistoricalDealOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        private int _count;
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        private QuerySecurityHistoricalDealOutputItem[] _items;
        public QuerySecurityHistoricalDealOutputItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._total = *(int*)p; p += 4;
            this._count = *(int*)p; p += 4;
            this._items = new QuerySecurityHistoricalDealOutputItem[this._count];
            for (int i = 0; i < this._count; i++)
            {
                this._items[i] = new QuerySecurityHistoricalDealOutputItem();
                this._items[i].ReadFrom(p);
                p += QuerySecurityHistoricalDealOutputItem.GetSize();
            }
        }
    }

    public sealed class PostSecuritySubmitOrderInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _instrumentCode;
        /// <summary>合约代码</summary>
        public string InstrumentCode
        {
            get
            {
                return this._instrumentCode;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 16))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._instrumentCode = value;
            }
        }
        private int _tradeFlag;
        public int TradeFlag
        {
            get
            {
                return this._tradeFlag;
            }
            set
            {
                this._tradeFlag = value;
            }
        }
        private double _orderPrice;
        public double OrderPrice
        {
            get
            {
                return this._orderPrice;
            }
            set
            {
                this._orderPrice = value;
            }
        }
        private int _orderVolume;
        public int OrderVolume
        {
            get
            {
                return this._orderVolume;
            }
            set
            {
                this._orderVolume = value;
            }
        }
        private int _quoteType;
        public int QuoteType
        {
            get
            {
                return this._quoteType;
            }
            set
            {
                this._quoteType = value;
            }
        }


        internal static int GetSize()
        {
            return 50;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            PInvokeHelper.WriteString(this._exchangeId, p, 10); p += 10;
            PInvokeHelper.WriteString(this._instrumentCode, p, 16); p += 16;
            *(int*)p = this._tradeFlag; p += 4;
            *(double*)p = this._orderPrice; p += 8;
            *(int*)p = this._orderVolume; p += 4;
            *(int*)p = this._quoteType; p += 4;
        }
    }
    public sealed class PostSecuritySubmitOrderOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private string _orderID;
        /// <summary>委托编号</summary>
        public string OrderID
        {
            get
            {
                return this._orderID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._orderID = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._orderID = PInvokeHelper.ReadString(p, 20); p += 20;
        }
    }

    public sealed class PostSecurityCancelOrderInput
    {
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private string _exchangeId;
        /// <summary>交易所代码</summary>
        public string ExchangeId
        {
            get
            {
                return this._exchangeId;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 10))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._exchangeId = value;
            }
        }
        private string _orderID;
        /// <summary>委托编号</summary>
        public string OrderID
        {
            get
            {
                return this._orderID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._orderID = value;
            }
        }

        internal static int GetSize()
        {
            return 34;
        }

        internal unsafe void WriteTo(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            *(int*)p = this._id; p += 4;
            PInvokeHelper.WriteString(this._exchangeId, p, 10); p += 10;
            PInvokeHelper.WriteString(this._orderID, p, 20); p += 20;
        }
    }
    public sealed class PostSecurityCancelOrderOutput
    {
        private uint _size;
        public uint Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _errorMessage;
        /// <summary>错误消息</summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 100))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._errorMessage = value;
            }
        }

        private string _orderID;
        /// <summary>委托编号</summary>
        public string OrderID
        {
            get
            {
                return this._orderID;
            }
            set
            {
                if ((value != null) && (PInvokeHelper.DefaultEncoding.GetByteCount(value) + 1 > 20))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._orderID = value;
            }
        }

        internal unsafe void ReadFrom(IntPtr pointer)
        {
            byte* p = (byte*)pointer.ToPointer();
            this._size = *(uint*)p; p += 4;
            this._id = *(int*)p; p += 4;
            this._errorMessage = PInvokeHelper.ReadString(p, 100); p += 100;
            this._orderID = PInvokeHelper.ReadString(p, 20); p += 20;
        }
    }

}
