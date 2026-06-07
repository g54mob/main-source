using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class PropertyStore
	{
		private readonly IPropertyStore storeInterface;

		public int Count => 0;

		public PropertyStoreProperty this[int index] => null;

		public PropertyStoreProperty this[PropertyKey key] => null;

		public bool Contains(PropertyKey key)
		{
			return false;
		}

		public PropertyKey Get(int index)
		{
			return default(PropertyKey);
		}

		public PropVariant GetValue(int index)
		{
			return default(PropVariant);
		}

		public void SetValue(PropertyKey key, PropVariant value)
		{
		}

		public void Commit()
		{
		}

		internal PropertyStore(IPropertyStore store)
		{
		}
	}
}
