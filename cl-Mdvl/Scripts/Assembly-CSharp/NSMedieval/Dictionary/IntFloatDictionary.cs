using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("IntFloatDictionary", "")]
	public class IntFloatDictionary : SerializableDictionary<int, float>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public IntFloatDictionary()
		{
		}

		public IntFloatDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadIntArray("keys");
			base.Values = deserializer.ReadFloatArray("values");
			OnAfterDeserialize();
		}
	}
}
