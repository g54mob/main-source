using System;
using NSMedieval.Serialization;

namespace NSMedieval.Dictionary
{
	[Serializable]
	[FVSerializableKey("Vec3IntIntDictionary", "")]
	public class Vec3IntIntDictionary : SerializableDictionary<Vec3Int, int>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public Vec3IntIntDictionary()
		{
		}

		public Vec3IntIntDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadObjectList<Vec3Int>("keys")?.ToArray();
			base.Values = deserializer.ReadIntArray("values");
			OnAfterDeserialize();
		}
	}
}
