using UnityEngine;

namespace VRTK
{
	public struct ControllerInteractionEventArgs
	{
		public VRTK_ControllerReference controllerReference;

		public float buttonPressure;

		public Vector2 touchpadAxis;

		public float touchpadAngle;

		public Vector2 touchpadTwoAxis;

		public float touchpadTwoAngle;
	}
}
