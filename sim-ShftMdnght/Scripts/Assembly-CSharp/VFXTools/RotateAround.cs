using UnityEngine;

namespace VFXTools
{
	public class RotateAround : MonoBehaviour
	{
		public Transform target;

		public float rotationSpeed = 30f;

		public float rotationRadius = 2f;

		private Vector3 initialPosition;

		private void Start()
		{
			initialPosition = base.transform.position;
		}

		private void Update()
		{
			if (target != null)
			{
				float f = Time.time * rotationSpeed;
				float x = initialPosition.x + rotationRadius * Mathf.Cos(f);
				float z = initialPosition.z + rotationRadius * Mathf.Sin(f);
				base.transform.position = new Vector3(x, base.transform.position.y, z);
				base.transform.LookAt(target, Vector3.up);
			}
		}
	}
}
