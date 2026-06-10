using System;
using NSMedieval.Dictionary;
using NSMedieval.Serialization;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("SerializableStatDictionary", "")]
	public class SerializableStatDictionary : SerializableDictionary<StatType, StatInstance>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.WriteEnum("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public SerializableStatDictionary()
		{
		}

		public SerializableStatDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadEnumArray<StatType>("keys");
			base.Values = deserializer.ReadObjectArray<StatInstance>("values");
			OnAfterDeserialize();
		}
	}
}
