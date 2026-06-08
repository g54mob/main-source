using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Filters/Free Space")]
	public class FilterByFreeSpace : LayoutModule
	{
		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features.RemoveAll((Feature f) => !blueprint.IsTileFlatWall(f.Tile1) || !blueprint.IsTileFlatWall(f.Tile2));
		}
	}
}
