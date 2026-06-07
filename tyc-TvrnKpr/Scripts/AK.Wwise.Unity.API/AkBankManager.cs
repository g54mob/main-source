using System;
using System.Collections.Generic;

public static class AkBankManager
{
	private class BankHandle
	{
		protected readonly string bankName;

		protected uint m_BankID;

		protected AkBankTypeEnum m_BankType;

		public int RefCount { get; private set; }

		public BankHandle(string name, AkBankTypeEnum bankType)
		{
		}

		public virtual AKRESULT DoLoadBank()
		{
			return default(AKRESULT);
		}

		public uint LoadBank()
		{
			return 0u;
		}

		public virtual void UnloadBank(bool remove = true)
		{
		}

		public void IncRef()
		{
		}

		public void DecRef()
		{
		}

		protected void LogLoadResult(AKRESULT result)
		{
		}
	}

	private class AsyncBankHandle : BankHandle
	{
		private readonly AkCallbackManager.BankCallback bankCallback;

		public AsyncBankHandle(string name, AkCallbackManager.BankCallback callback, AkBankTypeEnum bankType)
		{
		}

		private static void GlobalBankCallback(uint in_bankID, IntPtr in_pInMemoryBankPtr, AKRESULT in_eLoadResult, object in_Cookie)
		{
		}

		public override AKRESULT DoLoadBank()
		{
			return default(AKRESULT);
		}
	}

	private class DecodableBankHandle : BankHandle
	{
		private readonly bool decodeBank;

		private readonly string decodedBankPath;

		private readonly bool saveDecodedBank;

		public DecodableBankHandle(string name, bool save)
		{
		}

		public override AKRESULT DoLoadBank()
		{
			return default(AKRESULT);
		}

		public override void UnloadBank(bool remove = true)
		{
		}
	}

	private static readonly Dictionary<string, BankHandle> m_BankHandles;

	private static readonly List<BankHandle> BanksToUnload;

	public static void DoUnloadBanks()
	{
	}

	internal static void Reset()
	{
	}

	public static void ReloadAllBanks()
	{
	}

	public static void LoadInitBank(bool doReset = true)
	{
	}

	public static void UnloadInitBank()
	{
	}

	public static uint LoadBank(string name, bool decodeBank, bool saveDecodedBank, AkBankTypeEnum bankType = AkBankTypeEnum.AkBankType_User)
	{
		return 0u;
	}

	public static uint LoadBankAsync(string name, AkCallbackManager.BankCallback callback = null, AkBankTypeEnum bankType = AkBankTypeEnum.AkBankType_User)
	{
		return 0u;
	}

	public static void UnloadBank(string name)
	{
	}

	public static void UnloadAllBanks()
	{
	}
}
