using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class KeyBindingUi : SerializedMonoBehaviour
	{
		public UILabel NameLabel;

		public AddKeyBinding KeyBindButton;

		public ShowTagPopup StringBindingButton;

		private List<KeyBinding> _keyBindings;

		public void Init(List<KeyBinding> keyBindings)
		{
			_keyBindings = keyBindings;
			NameLabel.text = _keyBindings[0].DisplayName;
			KeyCode keyCode = _keyBindings[0].KeyCode;
			string stringCode = _keyBindings[0].StringCode;
			bool flag = false;
			bool flag2 = false;
			foreach (KeyBinding keyBinding in keyBindings)
			{
				if (keyBinding.KeyCode != keyCode)
				{
					flag = true;
					if (flag2)
					{
						break;
					}
				}
				if (keyBinding.StringCode != stringCode)
				{
					flag2 = true;
					if (flag)
					{
						break;
					}
				}
			}
			KeyBindButton.Init(_keyBindings[0].KeyCode, flag);
			KeyBindButton.KeyAssigned += KeyBindButton_KeyAssigned;
			StringBindingButton.Init(_keyBindings[0].StringCode, flag2);
			StringBindingButton.TagChanged += StringBindButton_TagChanged;
			StringBindingButton.gameObject.SetActive(SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.TagsEnabled);
		}

		private void StringBindButton_TagChanged(string newTag)
		{
			foreach (KeyBinding keyBinding in _keyBindings)
			{
				keyBinding.SetKey(newTag);
				keyBinding.HasBeenAssigned = true;
			}
		}

		private void KeyBindButton_KeyAssigned(KeyCode key)
		{
			foreach (KeyBinding keyBinding in _keyBindings)
			{
				keyBinding.SetKey(key);
				keyBinding.HasBeenAssigned = true;
			}
		}

		public void Update()
		{
			StringBindingButton.gameObject.SetActive(SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.TagsEnabled);
		}

		public void OnDestroy()
		{
			KeyBindButton.KeyAssigned -= KeyBindButton_KeyAssigned;
			StringBindingButton.TagChanged -= StringBindButton_TagChanged;
		}
	}
}
