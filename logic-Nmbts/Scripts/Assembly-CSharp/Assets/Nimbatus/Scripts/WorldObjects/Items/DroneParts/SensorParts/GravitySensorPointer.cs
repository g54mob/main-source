using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class GravitySensorPointer : MonoBehaviour
	{
		private Vector2 _direction;

		public void SetDirection(Vector2 gravitydir)
		{
			_direction = gravitydir;
		}

		public void Update()
		{
			Vector2 direction = _direction;
			float num = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.AngleAxis(num + 90f, Vector3.forward), 10f);
		}
	}
}
