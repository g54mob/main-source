using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class EngineActuatorScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _cylinder;

		[SerializeField]
		private Transform _hinge1;

		[SerializeField]
		private Transform _hinge2;

		[SerializeField]
		private Transform _target;

		public void UpdateRotations()
		{
			Vector3 vector = base.transform.InverseTransformPoint(_target.transform.position);
			vector.y -= _hinge1.localPosition.y;
			float num = Mathf.Atan(vector.x / vector.y) * 57.29578f;
			float x = Mathf.Atan(vector.z / vector.y) * 57.29578f;
			_hinge1.localRotation = Quaternion.Euler(x, 0f, 0f);
			_hinge2.localRotation = Quaternion.Euler(0f, 0f, 0f - num);
			_ = _cylinder.localPosition;
			_cylinder.localPosition = new Vector3(0f, 0f - vector.magnitude, 0f);
		}
	}
}
