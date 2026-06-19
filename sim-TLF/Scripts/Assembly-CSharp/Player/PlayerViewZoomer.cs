using Cinemachine;
using DG.Tweening;
using JSAM;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerViewZoomer : MonoBehaviour
	{
		public bool CanZoom = true;

		[SerializeField]
		private CinemachineVirtualCamera _playerViewCamera;

		[SerializeField]
		private FirstPersonController _firstPersonController;

		[SerializeField]
		private float _zoomScale;

		[SerializeField]
		private float _zoomTime;

		[SerializeField]
		private Ease _zoomEase;

		private float _defaultFOV;

		private float _defaultSensitivity;

		[Inject]
		private IPlayerInputService _playerInputService;

		private void Awake()
		{
			_defaultFOV = _playerViewCamera.m_Lens.FieldOfView;
		}

		private void OnEnable()
		{
			_playerInputService.OnZoom += PlayerZoom;
		}

		private void OnDisable()
		{
			_playerInputService.OnZoom -= PlayerZoom;
		}

		private void PlayerZoom(InputAction.CallbackContext context)
		{
			if (CanZoom)
			{
				AudioManager.PlaySound(PlayerLibrarySounds.Zoom);
				float currentFOV = _playerViewCamera.m_Lens.FieldOfView;
				float num = _defaultFOV;
				_ = _firstPersonController.RotationSpeed;
				float num2 = _firstPersonController.DefaultSensitivity;
				if (context.started)
				{
					Debug.Log("Zoom performed");
					num /= _zoomScale;
					num2 /= _zoomScale;
				}
				else if (context.canceled)
				{
					Debug.Log("Zoom canceled");
					num = _defaultFOV;
					num2 = _firstPersonController.DefaultSensitivity;
				}
				_firstPersonController.RotationSpeed = num2;
				DOTween.To(() => currentFOV, delegate(float x)
				{
					currentFOV = x;
					_playerViewCamera.m_Lens.FieldOfView = x;
				}, num, _zoomTime).SetEase(_zoomEase);
			}
		}
	}
}
