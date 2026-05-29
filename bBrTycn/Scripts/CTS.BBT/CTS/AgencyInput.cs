using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class AgencyInput : CTSBehaviour
	{
		[SerializeField]
		private InputActionReference _input;

		private CTSToggle _agencyToggle;

		private CTSToggle _barToggle;

		private CanvasGroupController _canvasGroup;

		private void Start()
		{
			_agencyToggle = (CTSToggle)BBTUI.GetSelectable(BBTUI.Instance.ButtonID_GoToAgency);
			_barToggle = (CTSToggle)BBTUI.GetSelectable(BBTUI.Instance.ButtonID_GoToBar);
			_canvasGroup = _agencyToggle.GetComponentInParent<CanvasGroupController>();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_input.action.performed += OnInputPerformed;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_input.action.performed -= OnInputPerformed;
		}

		private void OnInputPerformed(InputAction.CallbackContext obj)
		{
			if (UIUtility.InInputField() || ToggleInput.ObjectLock.IsLocked)
			{
				return;
			}
			CanvasGroupController.CanvasGroupState state = _canvasGroup.State;
			if (state == CanvasGroupController.CanvasGroupState.Hidden || state == CanvasGroupController.CanvasGroupState.Hidding)
			{
				return;
			}
			if (_agencyToggle.isOn)
			{
				if (_barToggle.interactable)
				{
					_barToggle.isOn = true;
				}
			}
			else if (_agencyToggle.interactable)
			{
				_agencyToggle.isOn = true;
			}
		}
	}
}
