using System.Text;

namespace Gh.Tk
{
	public class VerasExperiment1Trait : TurnsIntoXTrait
	{
		protected VerasExperiment1Trait()
		{
		}

		public VerasExperiment1Trait(GameObjectX owner)
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
