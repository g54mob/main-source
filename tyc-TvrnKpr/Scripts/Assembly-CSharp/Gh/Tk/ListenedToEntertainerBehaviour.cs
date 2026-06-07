using UnityEngine.Scripting;

namespace Gh.Tk
{
	public class ListenedToEntertainerBehaviour : PatronBehaviour
	{
		[PersistenceOptIn]
		private bool _hasFinishedListening;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Actor_LeavingTavern(object sender, EventArgs<Actor> e)
		{
		}

		public ListenedToEntertainerBehaviour()
		{
		}

		public ListenedToEntertainerBehaviour(Patron owner, string need)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public void OnListenedToEntertainer()
		{
		}

		private void OnActorLeavingTavern()
		{
		}
	}
}
