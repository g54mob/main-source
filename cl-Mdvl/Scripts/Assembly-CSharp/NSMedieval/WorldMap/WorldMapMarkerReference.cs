using System;
using NSEipix.Base;
using NSMedieval.Serialization;

namespace NSMedieval.WorldMap
{
	[FVSerializableKey("WorldMapMarkerReference", "")]
	public class WorldMapMarkerReference : IWorldMapPlaceReference, IFVSerializable
	{
		[NonSerialized]
		private WorldMapMarkerPlace value;

		public uint Id { get; private set; }

		public WorldMapPlace Value
		{
			get
			{
				if (value == null || !MonoSingleton<WorldMap>.Instance.Data.Markers.Contains(value))
				{
					value = null;
					foreach (WorldMapMarkerPlace marker in MonoSingleton<WorldMap>.Instance.Data.Markers)
					{
						if (marker.Id == Id)
						{
							value = marker;
						}
					}
				}
				return value;
			}
		}

		public WorldMapMarkerReference(WorldMapMarkerPlace place)
		{
			Id = place.Id;
			value = place;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", Id);
		}

		public WorldMapMarkerReference(FVDeserializer deserializer)
		{
			Id = deserializer.ReadUInt("id");
		}
	}
}
