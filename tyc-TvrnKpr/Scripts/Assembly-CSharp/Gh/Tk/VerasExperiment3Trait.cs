using System.Text;

namespace Gh.Tk
{
	public class VerasExperiment3Trait : TurnsIntoXTrait
	{
		protected VerasExperiment3Trait()
		{
		}

		public VerasExperiment3Trait(GameObjectX owner)
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
