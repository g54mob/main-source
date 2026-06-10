using System;
using NSMedieval.Dictionary;
using NSMedieval.Serialization;

namespace NSMedieval.Stockpiles
{
	[Serializable]
	[FVSerializableKey("StockpileSpaceDataDictionary", "")]
	public class StockpileSpaceDataDictionary : SerializableDictionary<Vec3Int, StockpileSpaceData>, IFVSerializable
	{
		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("keys", base.Keys);
			serializer.Write("values", base.Values);
		}

		public StockpileSpaceDataDictionary()
		{
		}

		public StockpileSpaceDataDictionary(FVDeserializer deserializer)
		{
			base.Keys = deserializer.ReadObjectArray<Vec3Int>("keys");
			base.Values = deserializer.ReadObjectArray<StockpileSpaceData>("values");
			OnAfterDeserialize();
		}
	}
}
