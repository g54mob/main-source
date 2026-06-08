using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Filters/By Room")]
	public class FilterByRoom : LayoutModule
	{
		public bool RemoveMode;

		public RoomType Type1;

		public bool FilterSecond;

		public RoomType Type2;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features.RemoveAll((Feature f) => RemoveMode != ((blueprint[f.Tile1].Type != Type1 || (blueprint[f.Tile2].Type != Type2 && FilterSecond)) && ((blueprint[f.Tile1].Type != Type2 && FilterSecond) || blueprint[f.Tile2].Type != Type1)));
		}
	}
}
