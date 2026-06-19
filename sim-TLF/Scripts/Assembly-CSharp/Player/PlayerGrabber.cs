using Items;
using JSAM;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerGrabber : MonoBehaviour
	{
		[SerializeField]
		private Transform _grabPoint;

		[SerializeField]
		private RaycasterInfo _playerViewRaycaster;

		[SerializeField]
		private float _followSpeed;

		private IGrabable _grabable;

		private Quaternion _initialRotationOffset;

		private Vector3 _initialPositionOffset;

		private float _initialYawOffset;

		[Inject]
		private IPlayerInputService _playerInputService;

		private void OnEnable()
		{
			_playerInputService.OnInteract += TryGrab;
		}

		private void OnDisable()
		{
			_playerInputService.OnInteract -= TryGrab;
		}

		private void FixedUpdate()
		{
			MoveGrabbedObject();
		}

		private void MoveGrabbedObject()
		{
			if (_grabable != null)
			{
				Vector3 b = _grabPoint.position + _initialPositionOffset;
				float y = _grabPoint.rotation.eulerAngles.y + _initialYawOffset;
				Vector3 eulerAngles = _grabable.Rigidbody.rotation.eulerAngles;
				Quaternion b2 = Quaternion.Euler(eulerAngles.x, y, eulerAngles.z);
				_grabable.Rigidbody.MovePosition(Vector3.Lerp(_grabable.Rigidbody.position, b, Time.fixedDeltaTime * _followSpeed));
				_grabable.Rigidbody.MoveRotation(Quaternion.Slerp(_grabable.Rigidbody.rotation, b2, Time.fixedDeltaTime * _followSpeed));
			}
		}

		private void TryGrab(InputAction.CallbackContext context)
		{
			Transform transform = _playerViewRaycaster.Hit.rigidbody?.transform;
			if (context.performed)
			{
				IGrabable component = null;
				if (transform != null)
				{
					transform.TryGetComponent<IGrabable>(out component);
				}
				Debug.Log("Grab Performed");
				Debug.Log(transform);
				if (component == null)
				{
					return;
				}
				component.Grab();
				_grabable = component;
				AudioManager.PlaySound(PlayerLibrarySounds.Grab);
				_initialRotationOffset = Quaternion.Inverse(_grabPoint.rotation) * _grabable.Rigidbody.rotation;
				float y = _grabPoint.rotation.eulerAngles.y;
				float y2 = _grabable.Rigidbody.rotation.eulerAngles.y;
				_initialYawOffset = Mathf.DeltaAngle(y, y2);
				_initialPositionOffset = _grabable.Rigidbody.position - _grabPoint.position;
			}
			if (context.canceled && _grabable != null)
			{
				_grabable.Ungrab();
				_grabable = null;
			}
		}
	}
}
