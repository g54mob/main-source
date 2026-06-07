using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls.Keybinds
{
	[Serializable]
	public class KeybindSetting
	{
		public EKeybinding Binding;

		public KeyCode PrimaryKey;

		public KeyCode SecondaryKey;

		public bool ModPrimary;

		public bool ModSecondary;

		public KeybindSetting()
		{
		}

		public KeybindSetting(EKeybinding binding, KeyCode primary, bool modprimary, KeyCode secondary, bool modSecondary)
		{
			Binding = binding;
			PrimaryKey = primary;
			SecondaryKey = secondary;
			ModPrimary = modprimary;
			ModSecondary = modSecondary;
		}

		public bool GetKey()
		{
			if ((ModPrimary && !Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftCommand) && !Input.GetKey(KeyCode.RightCommand)) || PrimaryKey == KeyCode.None || !Input.GetKey(PrimaryKey))
			{
				if ((!ModSecondary || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand)) && SecondaryKey != KeyCode.None)
				{
					return Input.GetKey(SecondaryKey);
				}
				return false;
			}
			return true;
		}

		public bool GetKeyDown()
		{
			if ((ModPrimary && !Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftCommand) && !Input.GetKey(KeyCode.RightCommand)) || PrimaryKey == KeyCode.None || !Input.GetKeyDown(PrimaryKey))
			{
				if ((!ModSecondary || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand)) && SecondaryKey != KeyCode.None)
				{
					return Input.GetKeyDown(SecondaryKey);
				}
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return LabelHelper.LightGrey + Binding.ToLocalizationString() + ": " + LabelHelper.White + (ModPrimary ? "Ctrl + " : "") + PrimaryKey.ToLocalizationString() + ((SecondaryKey != KeyCode.None) ? ("/" + LabelHelper.White + (ModSecondary ? "Ctrl + " : "") + SecondaryKey.ToLocalizationString()) : "");
		}
	}
}
