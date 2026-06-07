using System.Collections.Generic;
using PlayFab.ClientModels;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication
{
	public class AccountDetails
	{
		public readonly Dictionary<AccountDetailsType, string> PlatformAccounts;

		private AccountDetails()
		{
		}

		public bool IsDifferentAccountLinked(AccountDetailsType platform)
		{
			return false;
		}

		public string GetPlatformAccountIdentifier(AccountDetailsType platform)
		{
			return null;
		}

		public static AccountDetails FromApiResult(GetAccountInfoResult result)
		{
			return null;
		}

		public string GetCurrentPlatformDetails()
		{
			return null;
		}

		public bool HasAddedEmailCredentials()
		{
			return false;
		}

		public bool IsCurrentPlatformLinked()
		{
			return false;
		}

		public bool IsPlatformLinked(AccountDetailsType type)
		{
			return false;
		}

		public AccountDetailsType GetCurrentPlatformType()
		{
			return default(AccountDetailsType);
		}
	}
}
