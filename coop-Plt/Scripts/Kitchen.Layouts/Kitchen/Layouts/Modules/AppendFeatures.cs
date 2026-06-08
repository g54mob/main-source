using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Append Features")]
	public class AppendFeatures : LayoutModule
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public LayoutGraphConnection AppendFrom;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			if (!TryGetInput<LayoutBlueprint>("AppendFrom", out List<LayoutBlueprint> result))
			{
				return;
			}
			foreach (LayoutBlueprint item in result)
			{
				blueprint.Features.AddRange(item.Features.Where((Feature f) => !blueprint.HasFeature(f.Tile1, f.Tile2)));
			}
		}
	}
}
