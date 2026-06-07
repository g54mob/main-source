using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class NavInputField : InteractableNavElement
	{
		[SerializeField]
		private TMP_InputField m_inputField;

		private bool m_isFocused;

		public TMP_InputField InputField => m_inputField;

		public string Text => InputField.text;

		protected override void OnEnable()
		{
			base.OnEnable();
			InputField.onSubmit.AddListener(OnKeyboardSubmit);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			InputField.onSubmit.RemoveListener(OnKeyboardSubmit);
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			base.OnSubmit(eventData);
			if (TransientManager<InputManager>.Instance.CurrentDevice != EInputDeviceType.KEYBOARD)
			{
				InputField.Select();
				OverrideTransition(Transitioner.ESelectionState.Selected, instant: false);
				InputField.onSubmit.AddListener(OnGamepadSubmit);
			}
		}

		private void OnGamepadSubmit(string newText)
		{
			InputField.onSubmit.RemoveListener(OnGamepadSubmit);
			Select();
			OnCustomSubmit();
		}

		private void OnKeyboardSubmit(string text)
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice != EInputDeviceType.GAMEPAD)
			{
				OnCustomSubmit();
			}
		}

		protected virtual void OnCustomSubmit()
		{
		}

		protected override IEnumerable<Selectable> GetChildSelectables()
		{
			foreach (Selectable childSelectable in base.GetChildSelectables())
			{
				yield return childSelectable;
			}
		}

		public void SetText(string text)
		{
			if (InputField != null)
			{
				InputField.text = text;
			}
		}
	}
}
