using NSMedieval.Serialization;

namespace NSMedieval.WorldMap
{
	public interface IWorldMapPlaceReference : IFVSerializable
	{
		WorldMapPlace Value { get; }
	}
}
