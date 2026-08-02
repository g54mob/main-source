using UnityEngine;

namespace BloodEffectsPack
{
	public class CircularMovement : MonoBehaviour
	{
		public float radius = 5f;

		public float speed = 1f;

		private Vector3 center;

		private float angle;

		private void Start()
		{
			center = base.transform.position;
		}

		private void Update()
		{
			angle += speed * Time.deltaTime;
			float x = center.x + Mathf.Cos(angle) * radius;
			float z = center.z + Mathf.Sin(angle) * radius;
			base.transform.position = new Vector3(x, base.transform.position.y, z);
		}
	}
}
