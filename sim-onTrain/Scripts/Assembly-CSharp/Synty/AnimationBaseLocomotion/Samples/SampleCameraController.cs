using UnityEngine;

namespace Synty.AnimationBaseLocomotion.Samples
{
	public class SampleCameraController : MonoBehaviour
	{
		[SerializeField]
		private TSPlayerController player;

		[Tooltip("The character game object")]
		[SerializeField]
		private GameObject _syntyCharacter;

		[Tooltip("Main camera used for player perspective")]
		[SerializeField]
		private Camera _mainCamera;

		[SerializeField]
		private Transform _playerTarget;

		[SerializeField]
		private Transform _lockOnTarget;

		[SerializeField]
		private bool _isLockedOn;

		public void LockOn(bool enable, Transform newLockOnTarget)
		{
			_isLockedOn = enable;
			if (newLockOnTarget != null)
			{
				_lockOnTarget = newLockOnTarget;
			}
		}

		public Vector3 GetCameraPosition()
		{
			return _mainCamera.transform.position;
		}

		public Vector3 GetCameraForward()
		{
			return _mainCamera.transform.forward;
		}

		public Vector3 GetCameraForwardZeroedY()
		{
			return new Vector3(_mainCamera.transform.forward.x, 0f, _mainCamera.transform.forward.z);
		}

		public Vector3 GetCameraForwardZeroedYNormalised()
		{
			return GetCameraForwardZeroedY().normalized;
		}

		public Vector3 GetCameraRightZeroedY()
		{
			return new Vector3(_mainCamera.transform.right.x, 0f, _mainCamera.transform.right.z);
		}

		public Vector3 GetCameraRightZeroedYNormalised()
		{
			return GetCameraRightZeroedY().normalized;
		}

		public float GetCameraTiltX()
		{
			return _mainCamera.transform.eulerAngles.x;
		}
	}
}
