using System;
using System.Collections;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Keybindings
{
	public class KeybindButton : MonoBehaviour
	{
		public UILabel Label;

		private KeybindList _parent;

		public bool Mod;

		public KeyCode Key;

		private KeybindListItem _item;

		public void Init(KeybindList parentList, KeybindListItem item, KeyCode key, bool modifier)
		{
			_parent = parentList;
			_item = item;
			Key = key;
			Mod = modifier;
			Refresh();
		}

		private void Refresh()
		{
			Label.text = ((Key == KeyCode.None) ? "" : ((Mod ? "Ctrl + " : "") + Key.ToLocalizationString()));
		}

		public void OnTooltip(bool show)
		{
			if (Label.processedText != Label.text)
			{
				NimbatusToolTip.Show(Label.text, show);
			}
		}

		public void OnClick()
		{
			if (UICamera.currentTouchID == -1)
			{
				StartCoroutine(AssignKey());
			}
			else if (UICamera.currentTouchID == -2)
			{
				Key = KeyCode.None;
				Mod = false;
				_item.ApplyKeyBinding();
				Refresh();
				_parent.HidePopup();
			}
		}

		private IEnumerator AssignKey()
		{
			_parent.ShowPopup();
			while (true)
			{
				KeyCode keyCode = FetchKey();
				switch (keyCode)
				{
				case KeyCode.Escape:
					_parent.HidePopup();
					yield break;
				case KeyCode.None:
					yield return true;
					continue;
				}
				Key = keyCode;
				Mod = Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
				_item.ApplyKeyBinding();
				Refresh();
				_parent.HidePopup();
				yield break;
			}
		}

		private KeyCode FetchKey()
		{
			foreach (KeyCode item in Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>())
			{
				if (item != KeyCode.RightControl && item != KeyCode.LeftCommand && item != KeyCode.RightCommand && item != KeyCode.LeftControl && Input.GetKey(item))
				{
					return item;
				}
			}
			if (Input.GetMouseButtonDown(0))
			{
				return KeyCode.Mouse0;
			}
			if (Input.GetMouseButtonDown(1))
			{
				return KeyCode.Mouse1;
			}
			if (Input.GetMouseButtonDown(2))
			{
				return KeyCode.Mouse2;
			}
			if (Input.GetMouseButtonDown(3))
			{
				return KeyCode.Mouse3;
			}
			if (Input.GetMouseButtonDown(4))
			{
				return KeyCode.Mouse4;
			}
			if (Input.GetMouseButtonDown(5))
			{
				return KeyCode.Mouse5;
			}
			if (Input.GetMouseButtonDown(6))
			{
				return KeyCode.Mouse6;
			}
			return KeyCode.None;
		}
	}
}
