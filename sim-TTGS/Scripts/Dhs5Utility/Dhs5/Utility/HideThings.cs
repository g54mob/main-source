using UnityEngine;
using UnityEngine.InputSystem;

namespace Dhs5.Utility
{
	public class HideThings : MonoBehaviour
	{
		public CanvasGroup hudCanvas;

		private bool isOn = true;

		[SerializeField]
		private InputAction m_action;

		private void OnEnable()
		{
			m_action.Enable();
			m_action.performed += OnHideThings;
		}

		private void OnDisable()
		{
			m_action.Disable();
			m_action.performed -= OnHideThings;
		}

		private void OnHideThings(InputAction.CallbackContext context)
		{
			isOn = !isOn;
			hudCanvas.alpha = (isOn ? 1f : 0f);
		}
	}
}
