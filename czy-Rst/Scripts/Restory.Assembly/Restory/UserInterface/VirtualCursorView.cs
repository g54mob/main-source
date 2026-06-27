using Restory.Gameplay.GameCursor;
using Restory.Infrastructure.CommonServices;
using Rewired.Components;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	[RequireComponent(typeof(RectTransform))]
	public class VirtualCursorView : MonoBehaviour
	{
		[SerializeField]
		private RawImage image;

		private PlayerMouse playerMouse;

		[Space]
		private RectTransform rectTransform;

		private Canvas canvas;

		private ControlsManager controlsManager;

		private ISpecialCursor specialCursor;

		public Vector2 ScreenPosition => playerMouse.screenPosition;

		public bool Visible
		{
			set
			{
				image.gameObject.SetActive(value);
			}
		}

		public bool Locked
		{
			set
			{
				playerMouse.enabled = !value;
			}
		}

		[Inject]
		private void Construct(PlayerMouse playerMouse, ControlsManager controlsManager)
		{
			this.playerMouse = playerMouse;
			this.controlsManager = controlsManager;
			if (base.isActiveAndEnabled)
			{
				this.playerMouse.ScreenPositionChangedEvent += ResolveScreenPositionChangedEvent;
				this.controlsManager.OnControlsTypeChanged += ResolveControlsManagerOnControlsTypeChanged;
				ResolveScreenPositionChangedEvent(playerMouse.screenPosition);
				ResolveControlsManagerOnControlsTypeChanged(controlsManager.ControlType);
			}
		}

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			UpdateCanvas();
		}

		private void OnEnable()
		{
			if ((bool)controlsManager)
			{
				controlsManager.OnControlsTypeChanged += ResolveControlsManagerOnControlsTypeChanged;
				ResolveControlsManagerOnControlsTypeChanged(controlsManager.ControlType);
			}
			if ((bool)playerMouse)
			{
				playerMouse.ScreenPositionChangedEvent -= ResolveScreenPositionChangedEvent;
				ResolveScreenPositionChangedEvent(playerMouse.screenPosition);
			}
		}

		private void OnDisable()
		{
			if ((bool)controlsManager)
			{
				controlsManager.OnControlsTypeChanged -= ResolveControlsManagerOnControlsTypeChanged;
			}
			if ((bool)playerMouse)
			{
				playerMouse.ScreenPositionChangedEvent -= ResolveScreenPositionChangedEvent;
			}
		}

		private void Update()
		{
			Cursor.visible = false;
			if (playerMouse == null)
			{
				Cursor.lockState = CursorLockMode.Confined;
			}
			else if (playerMouse.enabled)
			{
				Cursor.lockState = (Screen.fullScreen ? CursorLockMode.Confined : CursorLockMode.None);
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
		}

		private void OnTransformParentChanged()
		{
			UpdateCanvas();
		}

		public void SetIcon(Texture2D targetTexture)
		{
			ApplyTextureAndEnableIcon(targetTexture);
			image.rectTransform.rotation = Quaternion.identity;
			image.SetNativeSize();
		}

		public void SetIcon(Texture2D targetTexture, float iconRotationAngle)
		{
			SetIcon(targetTexture);
			Vector3 eulerAngles = image.rectTransform.rotation.eulerAngles;
			image.rectTransform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z + iconRotationAngle);
		}

		public void SetIcon(Texture2D targetTexture, Vector2 textureSize)
		{
			ApplyTextureAndEnableIcon(targetTexture);
			image.rectTransform.rotation = Quaternion.identity;
			image.rectTransform.sizeDelta = textureSize;
		}

		public void SetSpecialCursor(ISpecialCursor specialCursor)
		{
			HideSpecialCursor();
			Visible = false;
			this.specialCursor = specialCursor;
			this.specialCursor.Show();
		}

		public float GetIconRotationAngle()
		{
			return image.rectTransform.rotation.eulerAngles.z;
		}

		private void ApplyTextureAndEnableIcon(Texture2D targetTexture)
		{
			HideSpecialCursor();
			image.texture = targetTexture;
			Visible = true;
		}

		private void UpdateCanvas()
		{
			canvas = GetComponentInParent<Canvas>();
		}

		private void ResolveScreenPositionChangedEvent(Vector2 screenPosition)
		{
			if (!(canvas == null))
			{
				Vector2 anchoredPosition = screenPosition / canvas.scaleFactor;
				rectTransform.anchoredPosition = anchoredPosition;
			}
		}

		private void ResolveControlsManagerOnControlsTypeChanged(InputControlsType type)
		{
			switch (type)
			{
			case InputControlsType.Joystick:
				playerMouse.Rewired_002EIPlayerMouse_002EpointerSpeed = 1f;
				break;
			case InputControlsType.KeyboardAndMouse:
				playerMouse.Rewired_002EIPlayerMouse_002EpointerSpeed = ((!playerMouse.useHardwarePointerPosition) ? 1 : 0);
				break;
			}
		}

		private void HideSpecialCursor()
		{
			if (specialCursor != null)
			{
				specialCursor.Hide();
				specialCursor = null;
			}
		}
	}
}
