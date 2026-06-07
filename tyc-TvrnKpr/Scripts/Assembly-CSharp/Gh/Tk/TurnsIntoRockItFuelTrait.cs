using System.Text;

namespace Gh.Tk
{
	public class TurnsIntoRockItFuelTrait : TurnsIntoXTrait
	{
		protected TurnsIntoRockItFuelTrait()
		{
		}

		public TurnsIntoRockItFuelTrait(GameObjectX owner)
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
	}
}
