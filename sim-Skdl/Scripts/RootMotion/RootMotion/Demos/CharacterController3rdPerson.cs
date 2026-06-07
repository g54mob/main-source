using UnityEngine;

namespace RootMotion.Demos
{
	public class CharacterController3rdPerson : MonoBehaviour
	{
		public CameraController cam;

		private AnimatorController3rdPerson animatorController;

		private static Vector3 inputVector => default(Vector3);

		private static Vector3 inputVectorRaw => default(Vector3);

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
