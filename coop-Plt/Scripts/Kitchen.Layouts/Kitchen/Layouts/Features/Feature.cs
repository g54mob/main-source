using System;
using MessagePack;

namespace Kitchen.Layouts.Features
{
	[Serializable]
	[MessagePackObject(false)]
	public class Feature
	{
		[Key(0)]
		public LayoutPosition Tile1;

		[Key(1)]
		public LayoutPosition Tile2;

		[Key(2)]
		public FeatureType Type;

		public Feature(LayoutPosition tile1, LayoutPosition tile2, FeatureType type)
		{
			Tile1 = tile1;
			Tile2 = tile2;
			Type = type;
		}

		public Feature(Feature copy)
		{
			Tile1 = copy.Tile1;
			Tile2 = copy.Tile2;
			Type = copy.Type;
		}

		public Feature()
		{
		}
	}
}
