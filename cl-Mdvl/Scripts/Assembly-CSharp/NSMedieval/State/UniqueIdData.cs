using System.Collections.Generic;
using System.Linq;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("UniqueIdData", "")]
	public class UniqueIdData : IFVSerializable
	{
		private Dictionary<UniqueIdType, TrackingUniqueIdProvider> providers = new Dictionary<UniqueIdType, TrackingUniqueIdProvider>();

		public Dictionary<UniqueIdType, TrackingUniqueIdProvider> Providers => providers;

		public UniqueIdData()
		{
		}

		public UniqueIdData(FVDeserializer deserializer)
		{
			List<int> list = deserializer.ReadIntList("keys");
			List<TrackingUniqueIdProvider> list2 = deserializer.ReadObjectList<TrackingUniqueIdProvider>("values");
			if (list != null && list.Count == list2.Count)
			{
				for (int i = 0; i < list.Count; i++)
				{
					providers.Add((UniqueIdType)list[i], list2[i]);
				}
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			if (providers.Count != 0)
			{
				List<int> value = (from x in providers.Keys.ToList()
					select (int)x).ToList();
				List<TrackingUniqueIdProvider> value2 = providers.Values.ToList();
				serializer.Write("keys", value);
				serializer.Write("values", value2);
			}
		}
	}
}
