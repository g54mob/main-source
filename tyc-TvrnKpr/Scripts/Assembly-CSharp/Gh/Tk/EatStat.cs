using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class EatStat : PatronStat
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnActorSpawned(object sender, EventArgs<Actor> e)
		{
		}

		protected EatStat()
		{
		}

		public EatStat(Patron owner)
		{
		}

		public override void Init()
		{
		}

		public override void Update()
		{
		}
	}
}
