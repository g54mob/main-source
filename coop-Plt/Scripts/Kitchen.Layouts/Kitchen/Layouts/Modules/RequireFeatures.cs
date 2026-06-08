using System.Linq;
using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Conditions/Feature Count")]
	public class RequireFeatures : LayoutCondition
	{
		public FeatureType Type;

		public int Minimum;

		protected override bool Test(LayoutBlueprint blueprint)
		{
			int num = blueprint.Features.Count((Feature f) => f.Type == Type);
			if (num < Minimum)
			{
				throw new LayoutFailureException($"Found {num} of {Minimum} required {Type}");
			}
			return true;
		}
	}
}
