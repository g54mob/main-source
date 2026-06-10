using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("StringBoolDictionary", "")]
	public class StringBoolDictionary : SerializableDictionary<string, bool>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public StringBoolDictionary()
		{
		}

		public StringBoolDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadStringArray("keys");
			base.Values = deserializer.ReadBoolArray("values");
			OnAfterDeserialize();
		}
	}
}
