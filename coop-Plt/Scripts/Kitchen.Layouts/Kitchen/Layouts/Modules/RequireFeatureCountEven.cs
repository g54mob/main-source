using System.Linq;
using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Conditions/Feature Count Even")]
	public class RequireFeatureCountEven : LayoutCondition
	{
		public FeatureType Type;

		public bool RequireEven;

		protected override bool Test(LayoutBlueprint blueprint)
		{
			int num = blueprint.Features.Count((Feature f) => f.Type == Type);
			if (num % 2 == 0 != RequireEven)
			{
				throw new LayoutFailureException($"Found {num} wanted even {RequireEven} required {Type}");
			}
			return true;
		}
	}
}
