namespace VoxelBusters.EssentialKit
{
	public static class CloudServicesUtility
	{
		public static bool TryGetCloudAndLocalCacheValues<T>(string key, out T cloudValue, out T localCacheValue, T localCacheDefaultValue = default(T))
		{
			cloudValue = default(T);
			localCacheValue = default(T);
			return false;
		}
	}
}
