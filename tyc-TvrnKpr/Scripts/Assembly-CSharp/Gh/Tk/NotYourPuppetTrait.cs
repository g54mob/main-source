using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	[TraitRarityConfig(0.005f, null)]
	public class NotYourPuppetTrait : StaffTrait
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void ManualInstructionGiven(object sender, EventArgs<Actor> e)
		{
		}

		protected NotYourPuppetTrait()
		{
		}

		public NotYourPuppetTrait(Staff owner)
		{
		}

		private void TriggerEffect()
		{
		}
	}
}
