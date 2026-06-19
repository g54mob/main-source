using System;
using UnityEngine;

namespace TH20
{
	public static class OSManager
	{
		[Flags]
		public enum Platform
		{
			None = 0,
			Editor = 1,
			Steam = 2,
			MSStore = 4,
			XboxOne = 8,
			Ps4 = 0x10,
			Switch = 0x20,
			EAOrigin = 0x40,
			AmazonPrime = 0x80
		}

		private static IOSManager _instance;

		public static Action OnUserChanged;

		public static Action OnDLCRefreshed;

		public static GameID AppID => new GameID(535930u);

		public static void Initialise()
		{
			if (!IsInitialised())
			{
				_instance = new SteamOSManager();
				IOSManager instance = _instance;
				instance.OnDLCRefreshed = (Action)Delegate.Combine(instance.OnDLCRefreshed, OnDLCRefreshed);
			}
		}

		public static void AssignApp(App app)
		{
			_instance.AssignApp(app);
		}

		private static void OnUserChangedCallback()
		{
			OnUserChanged?.Invoke();
		}

		public static Platform GetPlatform()
		{
			if (_instance == null)
			{
				return Platform.None;
			}
			return _instance.Platform;
		}

		public static bool IsInitialised()
		{
			if (_instance == null)
			{
				return false;
			}
			return _instance.IsInitialised;
		}

		public static string BuildVersion()
		{
			if (_instance == null)
			{
				return "";
			}
			return _instance.BuildVersion;
		}

		public static void Update()
		{
			if (_instance != null)
			{
				_instance.Update();
			}
		}

		public static void Destroy()
		{
			if (_instance != null)
			{
				_instance.Destroy();
			}
			else
			{
				UnityEngine.Debug.LogWarning("Attempting to destroy the OSManager after it has already been destroyed");
			}
		}

		public static Preferences.LanguagePreferences.Language GetLanguage()
		{
			if (_instance == null)
			{
				return Preferences.LanguagePreferences.Language.English;
			}
			return _instance.GetLanguage();
		}

		public static void ValidateUser(IOSManagerResultCallback callback)
		{
			if (_instance != null)
			{
				_instance.ValidateUser(callback);
			}
		}

		public static void EnumerateDLC(IOSManagerResultCallback callback)
		{
			if (_instance != null)
			{
				_instance.EnumerateDLC(callback);
			}
		}

		public static bool IsDlcInstalled(GameID appID)
		{
			if (IsInitialised() && _instance != null)
			{
				return _instance.IsDlcInstalled(appID);
			}
			return false;
		}

		public static bool IsDlcOwned(GameID appID)
		{
			if (IsInitialised() && _instance != null)
			{
				return _instance.IsDlcOwned(appID);
			}
			return false;
		}

		public static bool ShowDlcPurchaseUI(GameID appID, IOSManagerResultCallback callback)
		{
			if (IsInitialised() && _instance != null)
			{
				return _instance.ShowDlcPurchaseUI(appID, delegate(bool result)
				{
					if (result)
					{
						OnDLCRefreshed?.Invoke();
					}
					callback(result);
				});
			}
			return false;
		}

		public static void OpenStoreForProduct(string productID)
		{
			if (_instance != null)
			{
				_instance.OpenStoreForProduct(productID);
			}
		}
	}
}
