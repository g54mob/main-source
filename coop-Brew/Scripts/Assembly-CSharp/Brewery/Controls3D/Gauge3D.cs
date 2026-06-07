using UnityEngine;

namespace Brewery.Controls3D
{
	public class Gauge3D : MonoBehaviour
	{
		[Header("Needle")]
		[SerializeField]
		private Transform needle;

		[Header("Configuration")]
		[SerializeField]
		private float minAngle;

		[SerializeField]
		private float maxAngle;

		[SerializeField]
		private float smoothSpeed;

		[Header("State")]
		[SerializeField]
		[Range(0f, 1f)]
		private float value;

		private float targetValue;

		public float Value => 0f;

		private void Start()
		{
		}

		public void SetValue(float normalized)
		{
		}

		private void Update()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private static Vector3 AngleToDir(float angleDeg, Vector3 up, Vector3 right)
		{
			return default(Vector3);
		}
	}
}
