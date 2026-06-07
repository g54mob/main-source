using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class PropertyStoreProperty
	{
		private readonly PropertyKey propertyKey;

		private PropVariant propertyValue;

		public PropertyKey Key => default(PropertyKey);

		public object Value => null;

		internal PropertyStoreProperty(PropertyKey key, PropVariant value)
		{
		}
	}
}
