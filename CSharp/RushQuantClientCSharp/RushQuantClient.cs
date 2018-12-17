using System;
using System.Collections.Generic;
using System.Text;

namespace RushQuant.Clients
{
    public abstract class RushQuantClient
    {
        private static bool __initialized;
        protected static bool Initialized
        {
            get
            {
                return __initialized;
            }
        }

        public static bool Initialize(string pUsername, byte[] pKey)
        {
            int result = UnsafeNativeMethods.rushquant_initialize(pUsername, pKey);
            RushQuantClient.__initialized = (result == ErrorCode.Success);

            return RushQuantClient.__initialized;
        }

        public static void Dispose()
        {
            int result = UnsafeNativeMethods.rushquant_dispose();

            RushQuantClient.__initialized = false;
        }
    }

    public class RushQuantTradeClient : RushQuantClient
    {
        public static RushQuantTradeClient Create(int accountId)
        {
            if (!RushQuantClient.Initialized)
            {
                return null;
            }

            return new RushQuantTradeClient(accountId);
        }

        public static int[] GetAccountList()
        {
            if (!RushQuantClient.Initialized)
            {
                return null;
            }
        }

        private int _accountId;
        public int AccountId
        {
            get
            {
                return this._accountId;
            }
        }

        internal RushQuantTradeClient(int accountId)
        {
            this._accountId = accountId;
        }
    }

}
