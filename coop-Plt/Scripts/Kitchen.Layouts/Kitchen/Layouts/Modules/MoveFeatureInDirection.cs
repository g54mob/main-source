using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Move Feature In Direction")]
	public class MoveFeatureInDirection : LayoutModule
	{
		public int OffsetX;

		public int OffsetY;

		public int MaxSteps = 3;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			LayoutPosition layoutPosition = new LayoutPosition(OffsetX, OffsetY);
			foreach (Feature feature in blueprint.Features)
			{
				LayoutPosition tile = feature.Tile1;
				LayoutPosition tile2 = feature.Tile2;
				int iD = blueprint[feature.Tile1].ID;
				int iD2 = blueprint[feature.Tile2].ID;
				for (int i = 0; i < MaxSteps; i++)
				{
					tile += layoutPosition;
					tile2 += layoutPosition;
					int iD3 = blueprint[tile].ID;
					int iD4 = blueprint[tile2].ID;
					if (iD3 != iD || iD4 != iD2)
					{
						break;
					}
					feature.Tile1 = tile;
					feature.Tile2 = tile2;
				}
			}
		}
	}
}
