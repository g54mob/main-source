using System;
using NSMedieval.Dictionary;
using NSMedieval.Serialization;
using NSMedieval.State;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("SerializableDictionaryVec3IntPlantInstance", "")]
	public class SerializableDictionaryVec3IntPlantInstance : SerializableDictionary<Vec3Int, PlantMapResourceInstance>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public SerializableDictionaryVec3IntPlantInstance()
		{
		}

		public SerializableDictionaryVec3IntPlantInstance(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadObjectArray<Vec3Int>("keys");
			base.Values = deserializer.ReadObjectArray<PlantMapResourceInstance>("values");
			OnAfterDeserialize();
		}
	}
}
