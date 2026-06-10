using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("StringKeyPair", "")]
	public class StringKeyPair : SerializableDictionary<string, float>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public StringKeyPair()
		{
		}

		public StringKeyPair(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadStringArray("keys");
			base.Values = deserializer.ReadFloatArray("values");
			OnAfterDeserialize();
		}
	}
}
