using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class SpotlightTrait : ActorTrait
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnEnteringTavern(object sender, EventArgs<Actor> e)
		{
		}

		protected SpotlightTrait()
		{
		}

		public SpotlightTrait(Actor owner)
		{
		}
	}
}
