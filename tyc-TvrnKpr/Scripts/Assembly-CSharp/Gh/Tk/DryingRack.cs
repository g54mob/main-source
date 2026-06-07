using UnityEngine;

namespace Gh.Tk
{
	public class DryingRack : Larder_Tile
	{
		private Transform _dropTarget;

		public override void Start()
		{
		}

		private void DryingRack_UsageFinished(object sender, UsageEventArgs e)
		{
		}

		public override void OnDestroy()
		{
		}

		public override void UpdateVisuals()
		{
		}

		public override void OnCustomSetDown(Actor actor, GameItem itemToSetDown, int position)
		{
		}

		public override void OnCustomPickup(Actor actor, GameItem itemToPickup, int position)
		{
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		public override float GetEffectiveness(string usage)
		{
			return 0f;
		}
	}
}
