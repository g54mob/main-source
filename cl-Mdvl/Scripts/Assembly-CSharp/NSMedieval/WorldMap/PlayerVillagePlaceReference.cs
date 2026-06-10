using NSEipix.Base;
using NSMedieval.Serialization;

namespace NSMedieval.WorldMap
{
	[FVSerializableKey("PlayerVillagePlaceReference", "")]
	public class PlayerVillagePlaceReference : IWorldMapPlaceReference, IFVSerializable
	{
		public WorldMapPlace Value => MonoSingleton<WorldMap>.Instance.Data.PlayerVillagePlace;

		public PlayerVillagePlaceReference()
		{
		}

		public void Serialize(FVSerializer serializer)
		{
		}

		public PlayerVillagePlaceReference(FVDeserializer deserializer)
		{
		}
	}
}
