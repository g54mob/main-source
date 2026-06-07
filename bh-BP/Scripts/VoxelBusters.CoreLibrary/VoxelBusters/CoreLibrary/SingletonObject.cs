namespace VoxelBusters.CoreLibrary
{
	public class SingletonObject<T> where T : class
	{
		[ClearOnReload]
		private static T s_sharedInstance;

		public static T Instance => null;

		private static T CreateInstance()
		{
			return null;
		}
	}
}
