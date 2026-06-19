using System;

namespace TH20
{
	public interface IOSManager
	{
		bool IsInitialised { get; }

		OSManager.Platform Platform { get; }

		string BuildVersion { get; }

		Action OnDLCRefreshed { get; set; }

		void AssignApp(App app);

		void Update();

		void Destroy();

		Preferences.LanguagePreferences.Language GetLanguage();

		void ValidateUser(IOSManagerResultCallback callback);

		void EnumerateDLC(IOSManagerResultCallback callback);

		bool IsDlcInstalled(GameID appID);

		bool IsDlcOwned(GameID appID);

		bool ShowDlcPurchaseUI(GameID appID, IOSManagerResultCallback callback);

		void OpenStoreForProduct(string productID);
	}
}
