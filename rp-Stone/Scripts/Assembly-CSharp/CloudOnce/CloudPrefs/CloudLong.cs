using CloudOnce.Internal;

namespace CloudOnce.CloudPrefs
{
	public sealed class CloudLong : PersistentValue<long>
	{
		public CloudLong(string key, PersistenceType persistenceType, long value = 0L)
			: base(key, persistenceType, value, value, (ValueLoaderDelegate)DataManager.GetLong, (ValueSetterDelegate)DataManager.SetLong)
		{
		}

		public CloudLong(string key, PersistenceType persistenceType, long value, long defaultValue)
			: base(key, persistenceType, value, defaultValue, (ValueLoaderDelegate)DataManager.GetLong, (ValueSetterDelegate)DataManager.SetLong)
		{
		}
	}
}
