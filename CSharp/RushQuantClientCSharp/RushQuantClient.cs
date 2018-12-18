using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        public static int MAX_ACCOUNT = 100;

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

            IntPtr pointer = IntPtr.Zero;
            try
            {
                pointer = Marshal.AllocHGlobal(sizeof(int) * MAX_ACCOUNT);
                if (pointer == IntPtr.Zero)
                {
                    return null;
                }

                int count = UnsafeNativeMethods.rushquant_trade_GetAccountList(pointer);
                int[] accountIds = new int[count];
                Marshal.Copy(pointer, accountIds, 0, count);
                return accountIds;
            }
            finally
            {
                if (pointer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pointer);
                }
            }
        }

        public static void Free(IntPtr pointer)
        {
            UnsafeNativeMethods.rushquant_free(pointer);
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

        public int Reset()
        {
            return UnsafeNativeMethods.rushquant_trade_Reset(this._accountId);
        }

        public int NextId()
        {
            return UnsafeNativeMethods.rushquant_trade_NextId(this._accountId);
        }

        public LoginOutput Login(LoginInput input)
        {
            IntPtr pInput = IntPtr.Zero;
            IntPtr pOutput = IntPtr.Zero;
            try
            {
                pInput = Marshal.AllocHGlobal(LoginInput.GetSize());
                if (pInput == IntPtr.Zero)
                {
                    return null;
                }
                pOutput = Marshal.AllocHGlobal(LoginOutput.GetSize());
                if (pOutput == IntPtr.Zero)
                {
                    return null;
                }

                int result = UnsafeNativeMethods.rushquant_trade_Login(this._accountId, pInput, pOutput);
                LoginOutput output = new LoginOutput();
                output.ReadFrom(pOutput);
                if (result != ErrorCode.Success)
                {
                    throw new RushQuantClientException(result, output.ErrorMessage);
                }
                return output;
            }
            finally
            {
                if (pInput != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pInput);
                }
                if (pOutput != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pOutput);
                }
            }
        }

    }

}
