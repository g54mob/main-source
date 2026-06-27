using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_ControlsSettingPanel : GUI_ParentControlsSettingPanel
	{
		[SerializeField]
		private Button keyboardButton;

		[SerializeField]
		private Button gamepadButton;

		[SerializeField]
		private GUI_KeyboardControlsSettingPanel keyboardPanel;

		[SerializeField]
		private GUI_GamepadControlsSettingPanel gamepadPanel;

		public override void Init()
		{
			base.Init();
			keyboardPanel.Init();
			gamepadPanel.Init();
		}

		public override void Show()
		{
			base.Show();
			SetCurrentPanel(null);
		}

		public override void Hide()
		{
			base.Hide();
			SetCurrentPanel(null);
		}

		public override void UpdateView()
		{
			base.UpdateView();
			keyboardPanel.UpdateView();
			gamepadPanel.UpdateView();
		}

		public override void Load()
		{
			if (base.CurrentPanel != null)
			{
				base.CurrentPanel.Load();
			}
		}

		public override void Apply()
		{
			if (base.CurrentPanel != null)
			{
				base.CurrentPanel.Apply();
			}
		}

		public override void SetDefault()
		{
			if (base.CurrentPanel != null)
			{
				base.CurrentPanel.SetDefault();
			}
		}

		protected override void SubscribeChildren()
		{
			base.SubscribeChildren();
			keyboardButton.onClick.AddListener(ResolveKeyboardButtonOnClick);
			gamepadButton.onClick.AddListener(ResolveGamepadButtonOnClick);
		}

		protected override void UnsubscribeChildren()
		{
			base.UnsubscribeChildren();
			keyboardButton.onClick.RemoveListener(ResolveKeyboardButtonOnClick);
			gamepadButton.onClick.RemoveListener(ResolveGamepadButtonOnClick);
		}

		protected override void UpdateHasChanges()
		{
		}

		protected override void UpdateIsDefaultValues()
		{
		}

		public void ResolveKeyboardButtonOnClick()
		{
			SetCurrentPanel(keyboardPanel);
		}

		public void ResolveGamepadButtonOnClick()
		{
			SetCurrentPanel(gamepadPanel);
		}
	}
}
