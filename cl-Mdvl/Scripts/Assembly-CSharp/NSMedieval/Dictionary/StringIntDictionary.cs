using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("StringIntDictionary", "")]
	public class StringIntDictionary : SerializableDictionary<string, int>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public StringIntDictionary()
		{
		}

		public StringIntDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadStringArray("keys");
			base.Values = deserializer.ReadIntArray("values");
			OnAfterDeserialize();
		}
	}
}
