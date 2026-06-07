using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.UI.Utils
{
	public class EventOnClickOut : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _mouseClick;

		[SerializeField]
		private InputActionReference _mousePosition;

		private bool _mousePerformed;

		public event Action ClickedOutside;

		private void OnEnable()
		{
			_mousePerformed = false;
			_mouseClick.action.performed += MousePressed;
		}

		private void OnDisable()
		{
			_mouseClick.action.performed -= MousePressed;
		}

		private void Update()
		{
			if (_mousePerformed)
			{
				HideIfClickedOutside();
			}
		}

		private void MousePressed(InputAction.CallbackContext obj)
		{
			_mousePerformed = true;
		}

		private void HideIfClickedOutside()
		{
			if (base.gameObject.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(base.transform as RectTransform, _mousePosition.action.ReadValue<Vector2>(), Camera.main))
			{
				this.ClickedOutside?.Invoke();
			}
		}
	}
}
