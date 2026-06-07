using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	public struct MoveTransformGrabAttachEventArgs
	{
		public GameObject interactingObject;

		public Vector3 position;

		public Vector3 normalizedPosition;

		public Vector3 currentDirection;

		public Vector3 originDirection;
	}
}
