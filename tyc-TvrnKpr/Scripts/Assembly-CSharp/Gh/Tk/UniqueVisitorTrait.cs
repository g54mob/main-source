using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class UniqueVisitorTrait : ActorTrait
	{
		public static string KEY => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnActorDespawned(object sender, EventArgs<Actor> e)
		{
		}

		protected UniqueVisitorTrait()
		{
		}

		public UniqueVisitorTrait(Actor owner)
		{
		}
	}
}
