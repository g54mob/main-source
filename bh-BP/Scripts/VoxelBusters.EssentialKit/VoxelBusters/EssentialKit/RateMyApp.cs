using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class RateMyApp
	{
		public static RateMyAppUnitySettings UnitySettings;

		[ClearOnReload]
		private static RateMyAppController s_controller;

		public static event Callback<RateMyAppConfirmationPromptActionType> OnConfirmationPromptAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void Initialize(RateMyAppUnitySettings settings, string storeId)
		{
		}

		public static bool IsAllowedToRate()
		{
			return false;
		}

		public static void AskForReviewNow(bool skipConfirmation = false)
		{
		}
	}
}
