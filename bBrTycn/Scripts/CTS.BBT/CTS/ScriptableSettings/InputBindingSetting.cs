using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.ScriptableSettings
{
	public class InputBindingSetting : PlayerPrefSetting<List<InputBinding>>
	{
		[SerializeField]
		private InputActionReference _inputActionReference;

		protected override void OnSaveCurrentValueToDisk()
		{
			string value = _inputActionReference.action.SaveBindingOverridesAsJson();
			PlayerPrefs.SetString(_prefKey, value);
		}

		protected override List<InputBinding> GetValueFromDisk()
		{
			return null;
		}
	}
}
