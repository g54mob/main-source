using System;

namespace ScheduleOne.Core.Settings.Framework
{
	[Serializable]
	public class SerializableSettingsField<T> : SettingsField<T>, ISerializable
	{
		[Serializable]
		private class SerializedField
		{
			public T Value;

			public SerializedField(T value)
			{
			}
		}

		public SerializableSettingsField(string name, T defaultValue)
			: base((string)null, default(T))
		{
		}

		public string Serialize()
		{
			return null;
		}

		public void Deserialize(string value)
		{
		}
	}
}
