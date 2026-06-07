using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos.B
{
	public class MovingCar : MonoBehaviour
	{
		public float Speed { get; set; } = 1f;

		public Vector2 Direction { get; set; } = Vector2.down;

		private void Update()
		{
			Vector3 vector = new Vector3(Direction.x, 0f, Direction.y) * Speed * Time.deltaTime;
			base.transform.position = new Vector3(base.transform.position.x + vector.x, base.transform.position.y + vector.y, base.transform.position.z + vector.z);
			if (base.transform.position.x <= -5f || base.transform.position.x >= 45f || base.transform.position.z <= -5f || base.transform.position.z >= 35f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
