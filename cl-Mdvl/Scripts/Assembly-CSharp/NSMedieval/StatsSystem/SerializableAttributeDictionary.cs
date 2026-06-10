using System;
using NSMedieval.Dictionary;
using NSMedieval.Serialization;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("SerializableAttributeDictionary", "")]
	public class SerializableAttributeDictionary : SerializableDictionary<AttributeType, AttributeInstance>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.WriteEnum("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public SerializableAttributeDictionary()
		{
		}

		public SerializableAttributeDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadEnumArray<AttributeType>("keys");
			base.Values = deserializer.ReadObjectArray<AttributeInstance>("values");
			OnAfterDeserialize();
		}
	}
}
