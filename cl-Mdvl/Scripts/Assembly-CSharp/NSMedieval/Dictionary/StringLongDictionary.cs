using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("StringLongDictionary", "")]
	public class StringLongDictionary : SerializableDictionary<string, long>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public StringLongDictionary()
		{
		}

		public StringLongDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadStringArray("keys");
			base.Values = deserializer.ReadLongArray("values");
			OnAfterDeserialize();
		}
	}
}
