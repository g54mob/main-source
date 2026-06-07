using Assets.Scripts.XR;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.XR
{
	public class PosedGripInteractableCollider : InteractableCollider
	{
		public override void InteractionUpdate(ref Pose fingertipPose, float fingertipRadius, float triggerPull, out float? forcePoint, FlightHand hand)
		{
			forcePoint = null;
		}
	}
}
