using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/UI/Look At Camera")]
	public class LookAtCamera : MonoBehaviour
	{
		public bool justY = true;

		public Vector3 Offset;

		private Transform cam;

		private void Start()
		{
			cam = Camera.main.transform;
		}

		private void Update()
		{
			Vector3 vector = cam.position - base.transform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				Quaternion quaternion = Quaternion.LookRotation(vector);
				base.transform.eulerAngles = new Vector3(justY ? 0f : quaternion.eulerAngles.x, quaternion.eulerAngles.y, 0f) + Offset;
			}
		}
	}
}
