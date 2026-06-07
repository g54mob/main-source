using System;
using System.Collections.Generic;
using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;

namespace Simulator
{
	[Settings("UI/Inputs", Scope.Project)]
	public class InputsUISettings : CustomSettings<InputsUISettings>
	{
		public enum EInteractionType
		{
			NORMAL = 0,
			HOLD = 1
		}

		public enum EControllerType
		{
			KEYBOARD_MOUSE = 0,
			PLAYSTATION = 1,
			XBOX = 2
		}

		[Serializable]
		public struct Container
		{
			[SerializeField]
			private EnumValues<EInteractionType, EnumValues<EControllerType, Sprite>> m_sprites;

			[NonSerialized]
			public EInteractionType interactionType;

			[NonSerialized]
			public string name;

			public Sprite Sprite
			{
				get
				{
					EnumValues<EControllerType, Sprite> enumValues = m_sprites[interactionType];
					if (enumValues == null)
					{
						return null;
					}
					if (CurrentDevice == EInputDeviceType.KEYBOARD)
					{
						return enumValues[EControllerType.KEYBOARD_MOUSE];
					}
					Gamepad current = Gamepad.current;
					if (!(current is DualShockGamepad))
					{
						if (!(current is XInputController))
						{
							Debug.LogWarning("Unmanaged gamepad type: " + Gamepad.current.GetType().Name);
						}
						return enumValues[EControllerType.XBOX];
					}
					return enumValues[EControllerType.PLAYSTATION];
				}
			}

			public EInputDeviceType CurrentDevice => TransientManager<InputManager>.Instance.CurrentDevice;
		}

		private struct InputActionBindingsData
		{
			public readonly string effectivePath;

			public readonly string name;

			public InputActionBindingsData(string effectivePath, string name)
			{
				this.effectivePath = effectivePath;
				this.name = name;
			}
		}

		[SerializeField]
		private SerializedDictionary<string, Container> m_inputControlValues;

		public Container[] GetInputActionContainers(InputAction inputAction)
		{
			InputActionBindingsData[] inputActionDisplayStrings = GetInputActionDisplayStrings(inputAction);
			Container[] array = new Container[inputActionDisplayStrings.Length];
			for (int i = 0; i < inputActionDisplayStrings.Length; i++)
			{
				InputActionBindingsData inputActionBindingsData = inputActionDisplayStrings[i];
				if (!m_inputControlValues.TryGetValue(inputActionBindingsData.effectivePath, out var value))
				{
					Debug.LogWarning("Input action binding data for path '" + inputActionBindingsData.effectivePath + "' not found in settings.");
					continue;
				}
				value.name = inputActionBindingsData.name;
				if (inputAction.interactions.Contains("Hold"))
				{
					value.interactionType = EInteractionType.HOLD;
				}
				else
				{
					value.interactionType = EInteractionType.NORMAL;
				}
				array[i] = value;
			}
			return array;
		}

		private static InputActionBindingsData[] GetInputActionDisplayStrings(InputAction inputAction)
		{
			InputBinding bindingMask = GetBindingMask(TransientManager<InputManager>.Instance.PlayerInput.actions.FindAction(inputAction.name));
			List<InputActionBindingsData> list = new List<InputActionBindingsData>();
			for (int i = 0; i < inputAction.bindings.Count; i++)
			{
				InputBinding binding = inputAction.bindings[i];
				if (bindingMask.Matches(binding))
				{
					string effectivePath = binding.effectivePath;
					string bindingDisplayString = inputAction.GetBindingDisplayString(i, InputBinding.DisplayStringOptions.DontUseShortDisplayNames | InputBinding.DisplayStringOptions.DontIncludeInteractions);
					InputActionBindingsData item = new InputActionBindingsData(effectivePath, bindingDisplayString);
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		private static InputBinding GetBindingMask(InputAction inputAction)
		{
			InputBinding? inputBinding;
			if (inputAction.bindingMask.HasValue)
			{
				inputBinding = inputAction.bindingMask.Value;
			}
			else
			{
				InputActionMap actionMap = inputAction.actionMap;
				inputBinding = ((actionMap != null && actionMap.bindingMask.HasValue) ? new InputBinding?(inputAction.actionMap.bindingMask.Value) : ((inputAction.actionMap == null) ? ((InputBinding?)null) : ((inputAction.actionMap.asset == null) ? ((InputBinding?)null) : (inputAction.actionMap.asset.bindingMask.HasValue ? new InputBinding?(inputAction.actionMap.asset.bindingMask.Value) : ((InputBinding?)null)))));
			}
			return inputBinding.GetValueOrDefault();
		}
	}
}
