using UnityEngine;

namespace Polyart
{
	public class MillRotate : MonoBehaviour
	{
		private float x;

		public float rotationSpeed = 25f;

		private float y;

		private float z;

		private void Start()
		{
			x = 0f;
			y = base.transform.rotation.y;
			z = base.transform.rotation.z;
		}

		private void FixedUpdate()
		{
			x += Time.deltaTime * rotationSpeed;
			if (x > 360f)
			{
				x = 0f;
			}
			base.transform.localRotation = Quaternion.Euler(x, y, z);
		}
	}
}
