using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Replace Features By Room Type")]
	public class ReplaceFeaturesByRoomType : LayoutModule
	{
		public FeatureType SetToFeature;

		public RoomType MatchingType1;

		public RoomType MatchingType2;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features.ForEach(delegate(Feature f)
			{
				if ((blueprint.Tiles[f.Tile1].Type == MatchingType1 && blueprint.Tiles[f.Tile2].Type == MatchingType2) || (blueprint.Tiles[f.Tile2].Type == MatchingType1 && blueprint.Tiles[f.Tile1].Type == MatchingType2))
				{
					f.Type = SetToFeature;
				}
			});
		}
	}
}
