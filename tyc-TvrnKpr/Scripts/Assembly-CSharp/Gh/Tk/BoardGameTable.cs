using System.Collections.Generic;

namespace Gh.Tk
{
	public class BoardGameTable : Prop
	{
		public static readonly HashSet<BoardGameTable> AllBoardGameTables;

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		public void UpdateInnerTableState()
		{
		}
	}
}
