using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("StringStringDictionary", "")]
	public class StringStringDictionary : SerializableDictionary<string, string>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public StringStringDictionary()
		{
		}

		public StringStringDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadStringArray("keys");
			base.Values = deserializer.ReadStringArray("values");
			OnAfterDeserialize();
		}
	}
}
