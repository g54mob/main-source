using System.Collections.Generic;
using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Conditions/No Overlaps")]
	public class RequireNoOverlaps : LayoutCondition
	{
		protected override bool Test(LayoutBlueprint blueprint)
		{
			HashSet<LayoutPosition> hashSet = new HashSet<LayoutPosition>();
			foreach (Feature feature in blueprint.Features)
			{
				if (hashSet.Contains(feature.Tile1))
				{
					return false;
				}
				if (hashSet.Contains(feature.Tile2))
				{
					return false;
				}
				hashSet.Add(feature.Tile1);
				hashSet.Add(feature.Tile2);
			}
			return true;
		}
	}
}
