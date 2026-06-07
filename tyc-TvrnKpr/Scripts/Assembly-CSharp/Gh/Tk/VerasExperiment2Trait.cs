using System.Text;

namespace Gh.Tk
{
	public class VerasExperiment2Trait : TurnsIntoXTrait
	{
		protected VerasExperiment2Trait()
		{
		}

		public VerasExperiment2Trait(GameObjectX owner)
		{
		}

		protected override string GetTargetKey()
		{
			return null;
		}

		protected override bool AreRequirementsMetInternal(StringBuilder details = null)
		{
			return false;
		}

		public override void TransformItem()
		{
		}
	}
}
