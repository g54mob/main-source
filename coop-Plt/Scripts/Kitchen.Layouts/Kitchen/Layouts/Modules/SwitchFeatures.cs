using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Features/Switch Features")]
	public class SwitchFeatures : LayoutModule
	{
		public FeatureType SetToFeature;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features.ForEach(delegate(Feature f)
			{
				f.Type = SetToFeature;
			});
		}
	}
}
