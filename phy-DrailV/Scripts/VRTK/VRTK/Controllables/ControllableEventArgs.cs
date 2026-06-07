using UnityEngine;

namespace VRTK.Controllables
{
	public struct ControllableEventArgs
	{
		public Collider interactingCollider;

		public VRTK_InteractTouch interactingTouchScript;

		public float value;

		public float normalizedValue;
	}
}
