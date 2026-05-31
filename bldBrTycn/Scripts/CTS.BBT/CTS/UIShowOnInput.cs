using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Canvas))]
	public class UIShowOnInput : MonoBehaviour
	{
		public InputActionReference _action;

		private Canvas _canvas;

		private GraphicRaycaster _raycaster;

		[SerializeField]
		private UnityEvent _onEnable;

		[SerializeField]
		private UnityEvent _onDisable;

		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_raycaster = GetComponent<GraphicRaycaster>();
		}

		private void OnEnable()
		{
			_action.action.performed += Toggle;
		}

		private void OnDisable()
		{
			_action.action.performed -= Toggle;
		}

		private void Toggle(InputAction.CallbackContext ctx)
		{
			_canvas.enabled = !_canvas.enabled;
			if (_canvas.enabled)
			{
				_onEnable?.Invoke();
			}
			else
			{
				_onDisable?.Invoke();
			}
			if ((bool)_raycaster)
			{
				_raycaster.enabled = _canvas.enabled;
			}
		}
	}
}
