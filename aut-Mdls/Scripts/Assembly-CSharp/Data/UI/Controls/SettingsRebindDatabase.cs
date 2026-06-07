using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Data.UI.Controls
{
	[CreateAssetMenu(fileName = "SettingsRebindDatabase", menuName = "General/Settings/RebindDatabase")]
	public class SettingsRebindDatabase : ScriptableObject
	{
		[Serializable]
		public class GroupCollection
		{
			public SettingsRebindGroup[] Groups;
		}

		public readonly Dictionary<string, string> BindingPathReplacers = new Dictionary<string, string>
		{
			{ "<Keyboard>/leftCtrl", "<Keyboard>/ctrl" },
			{ "<Keyboard>/rightCtrl", "<Keyboard>/ctrl" },
			{ "<Keyboard>/leftAlt", "<Keyboard>/alt" },
			{ "<Keyboard>/rightAlt", "<Keyboard>/alt" },
			{ "<Keyboard>/leftShift", "<Keyboard>/shift" },
			{ "<Keyboard>/rightShift", "<Keyboard>/shift" }
		};

		[Header("Display")]
		[SerializeField]
		private InputBinding.DisplayStringOptions _displayStringOptions;

		[SerializeField]
		private InputBinding.DisplayStringOptions _displayFullStringOptions;

		[Header("Groups")]
		[SerializeField]
		private SettingsRebindGroup[] _groups;

		[SerializeField]
		private GroupCollection[] _conflictingGroups;

		[Header("Binding Paths")]
		[SerializeField]
		private InputActionReference[] _modifierInputs = Array.Empty<InputActionReference>();

		[SerializeField]
		private Color[] _modifierColours = Array.Empty<Color>();

		[SerializeField]
		private string[] _cancelBindingPaths = new string[2] { "<Keyboard>/escape", "<Mouse>/leftButton" };

		[SerializeField]
		private string[] _clearBindingPaths = new string[1] { "<Keyboard>/delete" };

		public InputBinding.DisplayStringOptions DisplayStringOptions => _displayStringOptions;

		public InputBinding.DisplayStringOptions DisplayFullStringOptions => _displayFullStringOptions;

		public SettingsRebindGroup[] Groups => _groups;

		public string[] CancelBindingPaths => _cancelBindingPaths;

		public string[] ClearBindingPaths => _clearBindingPaths;

		public GroupCollection[] ConflictingGroups => _conflictingGroups;

		public IReadOnlyList<Color> ModifierColours => _modifierColours;

		public IEnumerable<InputAction> GetAllModifierInputs()
		{
			InputActionReference[] modifierInputs = _modifierInputs;
			foreach (InputActionReference inputActionReference in modifierInputs)
			{
				yield return inputActionReference.action;
			}
		}

		public IEnumerable<InputActionReference> GetAllModifierReferences()
		{
			InputActionReference[] modifierInputs = _modifierInputs;
			for (int i = 0; i < modifierInputs.Length; i++)
			{
				yield return modifierInputs[i];
			}
		}

		public IEnumerable<string> GetAllModifierBindingPaths()
		{
			InputActionReference[] modifierInputs = _modifierInputs;
			foreach (InputActionReference inputActionReference in modifierInputs)
			{
				foreach (InputBinding binding in inputActionReference.action.bindings)
				{
					yield return binding.path;
				}
			}
		}

		public bool TryGetModifierColour(string modifierPath, out Color colour)
		{
			for (int i = 0; i < _modifierInputs.Length; i++)
			{
				foreach (InputBinding binding in _modifierInputs[i].action.bindings)
				{
					if (modifierPath == binding.path)
					{
						colour = _modifierColours[i];
						return true;
					}
				}
			}
			colour = Color.white;
			return false;
		}
	}
}
