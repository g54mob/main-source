using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Keybindings
{
	public class KeybindListItem : MonoBehaviour
	{
		public UILabel Label;

		public KeybindButton PrimaryButton;

		public KeybindButton SecondaryButton;

		private KeybindSetting _setting;

		public void Init(KeybindList parent, KeybindSetting keybindSetting)
		{
			_setting = keybindSetting;
			Label.text = keybindSetting.Binding.ToLocalizationString();
			PrimaryButton.Init(parent, this, keybindSetting.PrimaryKey, keybindSetting.ModPrimary);
			SecondaryButton.Init(parent, this, keybindSetting.SecondaryKey, keybindSetting.ModSecondary);
		}

		public void ApplyKeyBinding()
		{
			BaseSingleton<KeybindManager>.Instance.SetBinding(_setting.Binding, PrimaryButton.Key, SecondaryButton.Key, PrimaryButton.Mod, SecondaryButton.Mod);
			BaseSingleton<KeybindManager>.Instance.Save();
		}
	}
}
