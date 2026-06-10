using System;
using System.Collections.Generic;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("SerializableStringIntListDictionary", "")]
	public class SerializableStringIntListDictionary : SerializableDictionary<string, List<int>>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public SerializableStringIntListDictionary()
		{
		}

		public SerializableStringIntListDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadStringArray("keys");
			base.Values = deserializer.ReadIntListArray("values");
			OnAfterDeserialize();
		}
	}
}
