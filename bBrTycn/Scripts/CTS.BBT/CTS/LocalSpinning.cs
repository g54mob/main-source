using UnityEngine;

namespace CTS
{
	public class LocalSpinning : MonoBehaviour
	{
		[SerializeField]
		private float _speed;

		[SerializeField]
		private bool _useScaledTime;

		[SerializeField]
		private Vector3 _rotation;

		private void LateUpdate()
		{
			float num = (_useScaledTime ? Time.deltaTime : Time.unscaledDeltaTime);
			num *= _speed;
			base.transform.localRotation *= Quaternion.Euler(_rotation * num);
		}
	}
}
