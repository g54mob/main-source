using System.Linq;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

namespace Simulator
{
	public class CustomVirtualMouse : MonoBehaviour
	{
		[Header("UI components")]
		[SerializeField]
		private RectTransform m_canvasRectTransform;

		[SerializeField]
		private Canvas m_canvas;

		[Space]
		[SerializeField]
		private RectTransform m_cursorRectTransform;

		[SerializeField]
		private RawImage m_cursorImage;

		[Header("Settings")]
		[SerializeField]
		private InputActionProperty m_stickAction;

		[SerializeField]
		private InputActionProperty m_leftClickAction;

		[SerializeField]
		private InputActionProperty m_rightClickAction;

		[SerializeField]
		private float m_speed = 1000f;

		[SerializeField]
		private Vector4 m_padding = new Vector4(0f, 0f, 0f, 0f);

		private PlayerInput m_playerInput;

		private Camera m_mainCamera;

		private Mouse m_virtualMouse;

		private bool m_previousLeftMouseState;

		private bool m_previousRightMouseState;

		private void OnEnable()
		{
			m_playerInput = TransientManager<InputManager>.Instance.PlayerInput;
			m_mainCamera = TransientManager<CameraManager>.Instance.Camera;
			if (m_virtualMouse == null)
			{
				m_virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
			}
			else if (!m_virtualMouse.added)
			{
				InputSystem.AddDevice(m_virtualMouse);
			}
			else if (!m_virtualMouse.enabled)
			{
				InputSystem.EnableDevice(m_virtualMouse);
			}
			InputUser.PerformPairingWithDevice(m_virtualMouse, m_playerInput.user);
			if (m_cursorRectTransform != null)
			{
				Vector2 anchoredPosition = m_cursorRectTransform.anchoredPosition;
				InputState.Change(m_virtualMouse.position, anchoredPosition);
			}
			m_stickAction.action.Enable();
			m_leftClickAction.action.Enable();
			m_rightClickAction.action.Enable();
			MoveCursorToCenter();
			InputSystem.onAfterUpdate += UpdateMotion;
			CursorManager.OnCursorStateChanged += OnCursorStateChanged;
		}

		private void OnDisable()
		{
			m_stickAction.action.Disable();
			m_leftClickAction.action.Disable();
			m_rightClickAction.action.Disable();
			InputSystem.onAfterUpdate -= UpdateMotion;
			CursorManager.OnCursorStateChanged -= OnCursorStateChanged;
			if (m_virtualMouse != null && m_virtualMouse.added)
			{
				if (m_playerInput.user.pairedDevices.Contains(m_virtualMouse))
				{
					m_playerInput.user.UnpairDevice(m_virtualMouse);
				}
				InputSystem.DisableDevice(m_virtualMouse);
			}
		}

		private void OnDestroy()
		{
			if (m_virtualMouse != null)
			{
				InputSystem.RemoveDevice(m_virtualMouse);
			}
		}

		private void UpdateMotion()
		{
			if (m_virtualMouse != null && Gamepad.current != null)
			{
				Vector2 vector = m_stickAction.action.ReadValue<Vector2>();
				vector *= m_speed * Time.unscaledDeltaTime;
				Vector2 vector2 = m_virtualMouse.position.ReadValue() + vector;
				vector2.x = Mathf.Clamp(vector2.x, m_padding.x, (float)Screen.width - m_padding.z);
				vector2.y = Mathf.Clamp(vector2.y, m_padding.w, (float)Screen.height - m_padding.y);
				InputState.Change(m_virtualMouse.position, vector2);
				InputState.Change(m_virtualMouse.delta, vector);
				bool flag = m_leftClickAction.action.IsPressed();
				bool flag2 = m_rightClickAction.action.IsPressed();
				if (m_previousLeftMouseState != flag || m_previousRightMouseState != flag2)
				{
					m_virtualMouse.CopyState<MouseState>(out var state);
					state.WithButton(MouseButton.Left, flag);
					state.WithButton(MouseButton.Right, flag2);
					InputState.Change(m_virtualMouse, state);
					m_previousLeftMouseState = flag;
					m_previousRightMouseState = flag2;
				}
				AnchorCursor(vector2);
			}
		}

		private void AnchorCursor(Vector2 position)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(m_canvasRectTransform, position, (m_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : m_mainCamera, out var localPoint);
			m_cursorRectTransform.anchoredPosition = localPoint;
		}

		private void MoveCursorToCenter()
		{
			Vector2 vector = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
			InputState.Change(m_virtualMouse.position, vector);
			InputState.Change(m_virtualMouse.delta, Vector2.zero);
			AnchorCursor(vector);
		}

		private void OnCursorStateChanged(CursorState state)
		{
			m_cursorImage.texture = state.texture;
		}
	}
}
