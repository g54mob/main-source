using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/Object Control Actions/VRTK_SnapRotateObjectControlAction")]
	public class VRTK_SnapRotateObjectControlAction : VRTK_BaseObjectControlAction
	{
		[Tooltip("The angle to rotate for each snap.")]
		public float anglePerSnap = 30f;

		[Tooltip("The snap angle multiplier to be applied when the modifier button is pressed.")]
		public float angleMultiplier = 1.5f;

		[Tooltip("The amount of time required to pass before another snap rotation can be carried out.")]
		public float snapDelay = 0.5f;

		[Tooltip("The speed for the headset to fade out and back in. Having a blink between rotations can reduce nausia.")]
		public float blinkTransitionSpeed = 0.6f;

		[Range(-1f, 1f)]
		[Tooltip("The threshold the listened axis needs to exceed before the action occurs. This can be used to limit the snap rotate to a single axis direction (e.g. pull down to flip rotate). The threshold is ignored if it is 0.")]
		public float axisThreshold;

		protected float snapDelayTimer;

		protected override void Process(GameObject controlledGameObject, Transform directionDevice, Vector3 axisDirection, float axis, float deadzone, bool currentlyFalling, bool modifierActive)
		{
			CheckForPlayerBeforeRotation(controlledGameObject);
			if (snapDelayTimer < Time.time && ValidThreshold(axis))
			{
				float num = Rotate(axis, modifierActive);
				if (num != 0f)
				{
					Blink(blinkTransitionSpeed);
					RotateAroundPlayer(controlledGameObject, num);
				}
			}
			CheckForPlayerAfterRotation(controlledGameObject);
		}

		protected virtual bool ValidThreshold(float axis)
		{
			if (axisThreshold != 0f)
			{
				if (!(axisThreshold > 0f) || !(axis >= axisThreshold))
				{
					if (axisThreshold < 0f)
					{
						return axis <= axisThreshold;
					}
					return false;
				}
				return true;
			}
			return true;
		}

		protected virtual float Rotate(float axis, bool modifierActive)
		{
			snapDelayTimer = Time.time + snapDelay;
			int axisDirection = GetAxisDirection(axis);
			return anglePerSnap * (modifierActive ? angleMultiplier : 1f) * (float)axisDirection;
		}
	}
}
