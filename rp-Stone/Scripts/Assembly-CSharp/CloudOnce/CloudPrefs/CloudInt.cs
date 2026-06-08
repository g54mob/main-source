using CloudOnce.Internal;

namespace CloudOnce.CloudPrefs
{
	public sealed class CloudInt : PersistentValue<int>
	{
		public CloudInt(string key, PersistenceType persistenceType, int value = 0)
			: base(key, persistenceType, value, value, (ValueLoaderDelegate)DataManager.GetInt, (ValueSetterDelegate)DataManager.SetInt)
		{
		}

		public CloudInt(string key, PersistenceType persistenceType, int value, int defaultValue)
			: base(key, persistenceType, value, defaultValue, (ValueLoaderDelegate)DataManager.GetInt, (ValueSetterDelegate)DataManager.SetInt)
		{
		}
	}
}
