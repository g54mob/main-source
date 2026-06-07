using System.Collections;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.CloudServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class CloudServices
	{
		private const string kCacheKeyUserId = "$userId";

		[ClearOnReload]
		private static INativeCloudServicesInterface s_nativeInterface;

		[ClearOnReload]
		private static KeyValueDataStore s_localCache;

		public static CloudServicesUnitySettings UnitySettings { get; private set; }

		public static CloudUser ActiveUser { get; private set; }

		internal static KeyValueDataStore LocalCache => null;

		public static event EventCallback<CloudServicesUserChangeResult> OnUserChange
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

		public static event Callback<CloudServicesSavedDataChangeResult> OnSavedDataChange
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

		public static event Callback<CloudServicesSynchronizeResult> OnSynchronizeComplete
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

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(CloudServicesUnitySettings settings)
		{
		}

		public static bool GetBool(string key)
		{
			return false;
		}

		public static int GetInt(string key)
		{
			return 0;
		}

		public static long GetLong(string key)
		{
			return 0L;
		}

		public static float GetFloat(string key)
		{
			return 0f;
		}

		public static double GetDouble(string key)
		{
			return 0.0;
		}

		public static string GetString(string key)
		{
			return null;
		}

		public static byte[] GetByteArray(string key)
		{
			return null;
		}

		public static bool HasKey(string key)
		{
			return false;
		}

		public static void SetBool(string key, bool value)
		{
		}

		public static void SetInt(string key, int value)
		{
		}

		public static void SetLong(string key, long value)
		{
		}

		public static void SetFloat(string key, float value)
		{
		}

		public static void SetDouble(string key, double value)
		{
		}

		public static void SetString(string key, string value)
		{
		}

		public static void SetByteArray(string key, byte[] value)
		{
		}

		public static IDictionary GetSnapshot()
		{
			return null;
		}

		public static void Synchronize(Callback<CloudServicesSynchronizeResult> callback = null)
		{
		}

		public static void RemoveKey(string key)
		{
		}

		private static void RegisterForEvents()
		{
		}

		private static void UnregisterFromEvents()
		{
		}

		private static void UpdateLocalCacheOnUserChange(CloudUser user)
		{
		}

		private static void HandleOnUserChange(CloudUser user, Error error)
		{
		}

		private static void HandleOnSavedDataChange(CloudSavedDataChangeReasonCode changeReason, string[] changedKeys)
		{
		}
	}
}
