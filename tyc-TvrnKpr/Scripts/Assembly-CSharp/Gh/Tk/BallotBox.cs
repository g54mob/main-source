using System.Collections.Generic;

namespace Gh.Tk
{
	public class BallotBox : Prop
	{
		public static HashSet<BallotBox> AllBallotBoxes;

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}
	}
}
