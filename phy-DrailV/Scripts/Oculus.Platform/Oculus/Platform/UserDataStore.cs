using System.Collections.Generic;
using Oculus.Platform.Models;
using UnityEngine;

namespace Oculus.Platform
{
	public static class UserDataStore
	{
		public static Request<UserDataStoreUpdateResponse> PrivateDeleteEntryByKey(ulong userID, string key)
		{
			if (Core.IsInitialized())
			{
				return new Request<UserDataStoreUpdateResponse>(CAPI.ovr_UserDataStore_PrivateDeleteEntryByKey(userID, key));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Dictionary<string, string>> PrivateGetEntries(ulong userID)
		{
			if (Core.IsInitialized())
			{
				return new Request<Dictionary<string, string>>(CAPI.ovr_UserDataStore_PrivateGetEntries(userID));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Dictionary<string, string>> PrivateGetEntryByKey(ulong userID, string key)
		{
			if (Core.IsInitialized())
			{
				return new Request<Dictionary<string, string>>(CAPI.ovr_UserDataStore_PrivateGetEntryByKey(userID, key));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<UserDataStoreUpdateResponse> PrivateWriteEntry(ulong userID, string key, string value)
		{
			if (Core.IsInitialized())
			{
				return new Request<UserDataStoreUpdateResponse>(CAPI.ovr_UserDataStore_PrivateWriteEntry(userID, key, value));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<UserDataStoreUpdateResponse> PublicDeleteEntryByKey(ulong userID, string key)
		{
			if (Core.IsInitialized())
			{
				return new Request<UserDataStoreUpdateResponse>(CAPI.ovr_UserDataStore_PublicDeleteEntryByKey(userID, key));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Dictionary<string, string>> PublicGetEntries(ulong userID)
		{
			if (Core.IsInitialized())
			{
				return new Request<Dictionary<string, string>>(CAPI.ovr_UserDataStore_PublicGetEntries(userID));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<Dictionary<string, string>> PublicGetEntryByKey(ulong userID, string key)
		{
			if (Core.IsInitialized())
			{
				return new Request<Dictionary<string, string>>(CAPI.ovr_UserDataStore_PublicGetEntryByKey(userID, key));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}

		public static Request<UserDataStoreUpdateResponse> PublicWriteEntry(ulong userID, string key, string value)
		{
			if (Core.IsInitialized())
			{
				return new Request<UserDataStoreUpdateResponse>(CAPI.ovr_UserDataStore_PublicWriteEntry(userID, key, value));
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}
	}
}
