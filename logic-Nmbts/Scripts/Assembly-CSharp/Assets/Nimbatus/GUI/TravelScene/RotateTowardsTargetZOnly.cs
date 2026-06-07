using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class RotateTowardsTargetZOnly : MonoBehaviour
	{
		public Transform Target;

		public float RotationSpeed;

		private void Update()
		{
			Vector3 normalized = (Target.position - base.transform.position).normalized;
			float b = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
			float z = Mathf.LerpAngle(base.transform.localEulerAngles.z, b, Time.deltaTime * RotationSpeed);
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
		}
	}
}
