using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using PlayFab.ClientModels;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Framework.Platforms.SteamworksIntegration;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

public class AccountDetails
{
	public readonly Dictionary<AccountDetailsType, string> PlatformAccounts;

	private AccountDetails()
	{
		Dictionary<AccountDetailsType, string> platformAccounts = new Dictionary<AccountDetailsType, string>();
		PlatformAccounts = platformAccounts;
	}

	public unsafe bool IsDifferentAccountLinked(AccountDetailsType platform)
	{
		//IL_029c: Expected O, but got Ref
		//IL_02b0: Expected I, but got O
		//IL_02f3: Expected I4, but got O
		//IL_0030: Expected I, but got O
		//IL_004c: Expected I, but got O
		//IL_0054: Expected I, but got O
		//IL_0064: Expected O, but got I
		//IL_00a0: Expected O, but got I
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected Ref, but got Unknown
		//IL_01f7: Expected I8, but got I
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected Ref, but got Unknown
		AccountDetailsType accountDetailsType = default(AccountDetailsType);
		object o = accountDetailsType;
		IntPtr intPtr = default(IntPtr);
		bool flag = ValueType.DefaultEquals((object)(&intPtr), o);
		bool flag2 = !flag;
		nint num = unchecked((nint)null);
		if (!flag2)
		{
			SystemPlatform sInstance = SystemPlatform.sInstance;
			if (SystemPlatform.sInstance == null)
			{
				goto IL_02e5;
			}
			IBaseAccount currentSystem = sInstance.m_CurrentSystem;
			bool flag3 = sInstance.m_CurrentSystem == null;
			num = unchecked((nint)null);
			if (!flag3)
			{
				nint num2 = (nint)typeof(SteamworksAccount);
				num = (nint)currentSystem;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v9 (Il2CppClass<VampireSurvivors.Framework.Platforms.SteamworksIntegration.SteamworksAccount>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v3 (Il2CppClass<VampireSurvivors.Framework.Platforms.IBaseAccount>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v9 (Il2CppClass<VampireSurvivors.Framework.Platforms.SteamworksIntegration.SteamworksAccount>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v3 (Il2CppClass<VampireSurvivors.Framework.Platforms.IBaseAccount>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v20+FFFFFFF8+v81 @ rax_v19*8]");
					if (0 == (nint)typeof(SteamworksAccount))
					{
						if (PlatformAccounts != null)
						{
							object obj3 = ((Dictionary<System.Int32Enum, object>)(object)PlatformAccounts).get_Item((System.Int32Enum)platform);
							SystemPlatform sInstance2 = SystemPlatform.sInstance;
							if (SystemPlatform.sInstance != null)
							{
								IBaseAccount currentSystem2 = sInstance2.m_CurrentSystem;
								if (sInstance2.m_CurrentSystem != null)
								{
									string name = currentSystem2.m_Name;
									if (obj3 != null)
									{
										if (obj3 != currentSystem2.m_Name)
										{
											if (currentSystem2.m_Name != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v21 (System.Object)+10]");
												if ((nint)0 == name._stringLength)
												{
													ref byte first = ref *(byte*)(obj3 + 20);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v21 (System.Object)+10]");
													nint num4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v21 (System.Object)+10]");
													ulong length = (ulong)(num4 + 0);
													bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(currentSystem2.m_Name + 20), length);
													return (byte)((flag4 ? 1u : 0u) ^ 1u) != 0;
												}
											}
											return true;
										}
										return false;
									}
								}
							}
						}
						goto IL_02e5;
					}
				}
			}
		}
		object obj4 = accountDetailsType;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		string message = default(string);
		Exception ex = new Exception(message);
		throw ex;
		IL_02e5:
		NullReferenceException ex2 = new NullReferenceException();
		return (byte)(int)ex2 != 0;
	}

	public unsafe string GetPlatformAccountIdentifier(AccountDetailsType platform)
	{
		//IL_00ad: Expected I4, but got O
		//IL_00be: Expected O, but got Ref
		//IL_000e: Expected I4, but got O
		//IL_001f: Expected O, but got Ref
		//IL_003f: Expected I4, but got O
		//IL_0050: Expected O, but got Ref
		object obj = default(object);
		object o = (AccountDetailsType)obj;
		IntPtr intPtr = default(IntPtr);
		if (!ValueType.DefaultEquals((object)(&intPtr), o))
		{
			object o2 = (AccountDetailsType)obj;
			IntPtr intPtr2 = default(IntPtr);
			if (!ValueType.DefaultEquals((object)(&intPtr2), o2))
			{
				object o3 = (AccountDetailsType)obj;
				IntPtr intPtr3 = default(IntPtr);
				bool flag = ValueType.DefaultEquals((object)(&intPtr3), o3);
				return "";
			}
		}
		if (PlatformAccounts != null)
		{
			return (string)((Dictionary<System.Int32Enum, object>)(object)PlatformAccounts).get_Item((System.Int32Enum)platform);
		}
		return (string)(object)new NullReferenceException();
	}

	public static AccountDetails FromApiResult(GetAccountInfoResult result)
	{
		AccountDetails accountDetails = new AccountDetails();
		Dictionary<AccountDetailsType, string> platformAccounts = new Dictionary<AccountDetailsType, string>();
		accountDetails.PlatformAccounts = platformAccounts;
		if (result != null)
		{
			UserAccountInfo accountInfo = result.AccountInfo;
			if (result.AccountInfo != null)
			{
				UserPrivateAccountInfo privateInfo = accountInfo.PrivateInfo;
				if (accountInfo.PrivateInfo != null && privateInfo.Email != null)
				{
					if (accountDetails.PlatformAccounts == null)
					{
						goto IL_05bb;
					}
					bool flag = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).TryInsert((System.Int32Enum)0, (object)privateInfo.Email, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
			}
			UserAccountInfo accountInfo2 = result.AccountInfo;
			if (result.AccountInfo != null)
			{
				UserSteamInfo steamInfo = accountInfo2.SteamInfo;
				if (accountInfo2.SteamInfo != null && steamInfo.SteamName != null)
				{
					if (accountDetails.PlatformAccounts == null)
					{
						goto IL_05bb;
					}
					bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).TryInsert((System.Int32Enum)5, (object)steamInfo.SteamName, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
			}
			UserAccountInfo accountInfo3 = result.AccountInfo;
			if (result.AccountInfo != null)
			{
				UserGooglePlayGamesInfo googlePlayGamesInfo = accountInfo3.GooglePlayGamesInfo;
				if (accountInfo3.GooglePlayGamesInfo != null && googlePlayGamesInfo.GooglePlayGamesPlayerDisplayName != null)
				{
					if (accountDetails.PlatformAccounts == null)
					{
						goto IL_05bb;
					}
					bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).TryInsert((System.Int32Enum)3, (object)googlePlayGamesInfo.GooglePlayGamesPlayerDisplayName, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
			}
			UserAccountInfo accountInfo4 = result.AccountInfo;
			if (result.AccountInfo != null)
			{
				UserAppleIdInfo appleAccountInfo = accountInfo4.AppleAccountInfo;
				if (accountInfo4.AppleAccountInfo != null && appleAccountInfo.AppleSubjectId != null)
				{
					if (accountDetails.PlatformAccounts == null)
					{
						goto IL_05bb;
					}
					bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).TryInsert((System.Int32Enum)1, (object)appleAccountInfo.AppleSubjectId, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
			}
			UserAccountInfo accountInfo5 = result.AccountInfo;
			if (result.AccountInfo != null)
			{
				UserGameCenterInfo gameCenterInfo = accountInfo5.GameCenterInfo;
				if (accountInfo5.GameCenterInfo != null && gameCenterInfo.GameCenterId != null)
				{
					if (accountDetails.PlatformAccounts == null)
					{
						goto IL_05bb;
					}
					bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).TryInsert((System.Int32Enum)2, (object)gameCenterInfo.GameCenterId, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
			}
			UserAccountInfo accountInfo6 = result.AccountInfo;
			if (result.AccountInfo != null)
			{
				UserXboxInfo xboxInfo = accountInfo6.XboxInfo;
				if (accountInfo6.XboxInfo != null && xboxInfo.XboxUserId != null)
				{
					if (accountDetails.PlatformAccounts == null)
					{
						goto IL_05bb;
					}
					bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).TryInsert((System.Int32Enum)6, (object)xboxInfo.XboxUserId, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
			}
			UserAccountInfo accountInfo7 = result.AccountInfo;
			if (result.AccountInfo != null)
			{
				UserNintendoSwitchAccountIdInfo nintendoSwitchAccountInfo = accountInfo7.NintendoSwitchAccountInfo;
				if (accountInfo7.NintendoSwitchAccountInfo != null && nintendoSwitchAccountInfo.NintendoSwitchAccountSubjectId != null)
				{
					if (accountDetails.PlatformAccounts == null)
					{
						goto IL_05bb;
					}
					bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).TryInsert((System.Int32Enum)4, (object)nintendoSwitchAccountInfo.NintendoSwitchAccountSubjectId, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
			}
		}
		return accountDetails;
		IL_05bb:
		return (AccountDetails)(object)new NullReferenceException();
	}

	public string GetCurrentPlatformDetails()
	{
		if (PlatformAccounts != null)
		{
			return (string)((Dictionary<System.Int32Enum, object>)(object)PlatformAccounts).get_Item((System.Int32Enum)5);
		}
		return (string)(object)new NullReferenceException();
	}

	public bool HasAddedEmailCredentials()
	{
		return IsPlatformLinked(AccountDetailsType.Email);
	}

	public bool IsCurrentPlatformLinked()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x186C7A500\"");
		bool result = default(bool);
		return result;
	}

	public bool IsPlatformLinked(AccountDetailsType type)
	{
		//IL_0047: Expected I4, but got O
		if (PlatformAccounts != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)PlatformAccounts).FindEntry((System.Int32Enum)type);
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public AccountDetailsType GetCurrentPlatformType()
	{
		return AccountDetailsType.Steam;
	}
}
