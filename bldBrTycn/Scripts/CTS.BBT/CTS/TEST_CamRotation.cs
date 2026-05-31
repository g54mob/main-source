using UnityEngine;

namespace CTS
{
	public class TEST_CamRotation : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _rotation;

		[SerializeField]
		private float _speed;

		private Vector3 _currentrotation;

		private void Update()
		{
			_currentrotation += _rotation * Time.deltaTime * _speed;
			base.transform.rotation = Quaternion.Euler(_currentrotation);
		}
	}
}
