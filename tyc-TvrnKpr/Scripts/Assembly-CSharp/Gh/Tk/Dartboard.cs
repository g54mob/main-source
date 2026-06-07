using UnityEngine;

namespace Gh.Tk
{
	public class Dartboard : Prop
	{
		[SerializeField]
		private GameObject _projectileParent;

		public override void Start()
		{
		}

		public void ClearBoard()
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}
	}
}
