using UnityEngine.Scripting;

namespace Gh.Tk
{
	[TraitRarityConfig(0f, null)]
	[Preserve]
	public class FrighteningTrait : StaffTrait
	{
		protected FrighteningTrait()
		{
		}

		public FrighteningTrait(Staff owner)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}

		private void InteractedWithPatron(object sender, EventArgs<(Staff staff, Patron patron)> e)
		{
		}

		private void OnPatronInteraction(Patron patron)
		{
		}
	}
}
