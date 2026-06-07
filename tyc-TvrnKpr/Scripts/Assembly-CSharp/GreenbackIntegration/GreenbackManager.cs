using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using Gh;
using Gh.Tk;
using UnityEngine.Scripting;

namespace GreenbackIntegration
{
	[InitializeOnGameStarted]
	public static class GreenbackManager
	{
		[Serializable]
		public class CreatorNameData
		{
			public string greenbackUserIdHash { get; set; }

			public string name { get; set; }

			public string nameColor { get; set; }

			public DateTime lastCheckedDate { get; set; }

			public string ToAuthorName()
			{
				return null;
			}
		}

		public class UsernameAvailableResult
		{
			public bool available { get; set; }

			public string username { get; set; }

			public string msg { get; set; }
		}

		private static string _sessionTicket;

		private static string _verifiedEmailHash;

		internal static string _userIdHash;

		internal static string _discordUser;

		internal static TkWebService.UserPrivileges _privileges;

		internal static string _contentUnlocks;

		private static string _username;

		private static bool _isLoggingIn;

		private static Dictionary<string, CreatorNameData> _creatorNameDataCache;

		private static GreenbackUserInventory _inventory;

		private static DateTime? _lastSubmit;

		private const int _eventReportIntervalInMinutes = 10;

		private static readonly List<Dictionary<string, object>> _eventBatch;

		private static Timer _batchTimer;

		private static float _avgFpsData;

		private static int _dataPoints;

		public static bool CreatorFeaturesEnabled => false;

		public static bool PatreonFeaturesEnabled => false;

		public static bool PressFeaturesEnabled => false;

		public static bool DevFeaturesEnabled => false;

		public static string Username
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static string SessionTicket => null;

		public static GreenbackUserInventory Inventory
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public static bool IsLoggedIn => false;

		public static bool IsLoggedInAndActive => false;

		public static float AvgFpsSinceLastSubmit => 0f;

		public static event EventHandler OnUsernameChanged
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

		public static event EventHandler InventoryChanged
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

		public static event EventHandler IsLoggedInStatusChanged
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

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public static bool IsEmailRegistered(string email)
		{
			return false;
		}

		public static void BeginLogin()
		{
		}

		private static Dictionary<string, CreatorNameData> GetCachedCreatorNames()
		{
			return null;
		}

		public static void FetchCreatorNames(int ageInDays = 14)
		{
		}

		public static void FetchCreatorNames(string[] toFetch, Action<CreatorNameData[]> onSuccess = null)
		{
		}

		private static void FetchCloudInventory(string url)
		{
		}

		private static void LogDeviceInfo()
		{
		}

		public static Dictionary<string, object> GetDeviceInfo()
		{
			return null;
		}

		public static void Logout()
		{
		}

		public static void UpdateEmail(string email, Action<string> success, Action<string> error)
		{
		}

		public static void CheckIfEmailIsVerified(string email, Action<bool> success)
		{
		}

		public static void LogInkStoryCompleted(string inkName, string endPort)
		{
		}

		public static void LogEvent(string eventName, Dictionary<string, object> data)
		{
		}

		private static void AddEventToBatch(Dictionary<string, object> @event)
		{
		}

		private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
		}

		public static void Update()
		{
		}

		private static void AddPerfStatsToBatch()
		{
		}

		private static void SubmitBatch(bool threaded = true)
		{
		}

		public static void OnGameClosing()
		{
		}

		public static void EnsureOnlineViaUIPromptWrapper(string actionDescription, Action action, Action onCancelled)
		{
		}

		public static void TestGrantCards()
		{
		}

		public static void ResetRewards()
		{
		}

		public static void MarkRewardAsUnpacked(List<GreenbackRewardData> rewards)
		{
		}

		private static void UpdatePendingRewards()
		{
		}

		public static void ClaimReward(string rewardId)
		{
		}

		private static void OnStarRatingChanged(object sender, EventArgs<float> e)
		{
		}

		public static void SetUsername(string s, Action<string> success, Action<string> error)
		{
		}

		public static void CheckIsUsernameAvailable(string username, Action<UsernameAvailableResult> success, Action<string> error)
		{
		}

		public static bool UpdateNameInTemplates(string greenbackUserHash, string displayName)
		{
			return false;
		}
	}
}
