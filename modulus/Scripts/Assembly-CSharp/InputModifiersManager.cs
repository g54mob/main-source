using System.Collections.Generic;
using System.Linq;
using Data.UI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputModifiersManager : MonoBehaviour
{
	[SerializeField]
	private SettingsRebindRuntimeInfo _settingsRebindRuntimeInfo;

	[SerializeField]
	private SettingsRebindDatabase _settingsRebindDatabase;

	[SerializeField]
	private SettingsRebindEvent _settingsRebindEndEvent;

	private readonly Dictionary<string, InputModifierListener> _modifierListeners = new Dictionary<string, InputModifierListener>();

	private void Start()
	{
		InputAction[] array = _settingsRebindDatabase.GetAllModifierInputs().ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Enable();
		}
		foreach (SettingsRebindAction allRebindAction in _settingsRebindRuntimeInfo.AllRebindActions)
		{
			AddRebindAction(allRebindAction);
		}
		_settingsRebindEndEvent.Register(AddRebindAction);
	}

	private void OnDestroy()
	{
		foreach (InputModifierListener value in _modifierListeners.Values)
		{
			value.CleanUp();
		}
		_modifierListeners.Clear();
		_settingsRebindEndEvent.UnRegister(AddRebindAction);
	}

	private void AddRebindAction(SettingsRebindAction rebindAction)
	{
		if (!rebindAction.IsUnbound())
		{
			string effectivePath = rebindAction.Binding.effectivePath;
			if (!_modifierListeners.TryGetValue(effectivePath, out var value))
			{
				value = new InputModifierListener(_settingsRebindDatabase.GetAllModifierInputs().ToArray());
				_modifierListeners[effectivePath] = value;
			}
			value.Add(rebindAction);
		}
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		foreach (KeyValuePair<string, InputModifierListener> modifierListener in _modifierListeners)
		{
			modifierListener.Value.OnApplicationFocus(hasFocus);
		}
	}
}
