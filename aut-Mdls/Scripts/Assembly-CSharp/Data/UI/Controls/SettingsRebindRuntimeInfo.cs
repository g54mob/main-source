#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Data.UI.Controls
{
	[CreateAssetMenu(fileName = "SettingsRebindRuntimeInfo", menuName = "General/Settings/SettingsRebindRuntimeInfo")]
	public class SettingsRebindRuntimeInfo : ScriptableObject
	{
		[SerializeField]
		private SettingsRebindDatabase _database;

		private readonly List<SettingsRebindAction> _rebindActions = new List<SettingsRebindAction>();

		private readonly Dictionary<InputActionReference, List<SettingsRebindActionData>> _rebindDatasByInputActions = new Dictionary<InputActionReference, List<SettingsRebindActionData>>();

		private readonly Dictionary<InputActionReference, List<SettingsRebindAction>> _rebindActionsByInputActions = new Dictionary<InputActionReference, List<SettingsRebindAction>>();

		private readonly Dictionary<SettingsRebindGroup, List<SettingsRebindAction>> _rebindActionsByGroup = new Dictionary<SettingsRebindGroup, List<SettingsRebindAction>>();

		private readonly Dictionary<SettingsRebindGroup, List<SettingsRebindGroup>> _conflictingGroupByGroup = new Dictionary<SettingsRebindGroup, List<SettingsRebindGroup>>();

		public IEnumerable<SettingsRebindAction> AllRebindActions => _rebindActions;

		public void Initialize()
		{
			_rebindActions.Clear();
			_rebindDatasByInputActions.Clear();
			_rebindActionsByInputActions.Clear();
			_rebindActionsByGroup.Clear();
			_conflictingGroupByGroup.Clear();
			CreateRebindActions();
			PopulateConflictDicationary();
		}

		public bool TryGetBindingString(InputActionReference inputAction, out string bindingString, bool getLongVersion = false, string inBetweens = "")
		{
			bindingString = "";
			if (!TryGetRebindActions(inputAction, out var rebindActions))
			{
				this.LogError("There are no SettingsRebindAction for my SettingsRebindActionData, there should always be atleast 1?", "TryGetBindingString", 39);
				return false;
			}
			bool flag = true;
			bool flag2 = false;
			foreach (SettingsRebindAction item in rebindActions)
			{
				if (item.IsUnbound())
				{
					flag2 = true;
				}
				else if (!item.IsAlt || flag2)
				{
					flag2 = false;
					if (!flag)
					{
						bindingString += inBetweens;
					}
					flag = false;
					if (getLongVersion)
					{
						bindingString += item.GetBindingLongString();
					}
					else
					{
						bindingString += item.GetBindingString();
					}
				}
			}
			return !string.IsNullOrEmpty(bindingString);
		}

		public bool TryGetRebindActionData(InputActionReference inputAction, out IReadOnlyList<SettingsRebindActionData> rebindActionData)
		{
			if (!_rebindDatasByInputActions.TryGetValue(inputAction, out var value))
			{
				rebindActionData = null;
				return false;
			}
			rebindActionData = value;
			return true;
		}

		public bool TryGetRebindActions(InputActionReference inputAction, out IReadOnlyList<SettingsRebindAction> rebindActions)
		{
			if (!_rebindActionsByInputActions.TryGetValue(inputAction, out var value))
			{
				rebindActions = null;
				return false;
			}
			rebindActions = value;
			return true;
		}

		public bool TryGetConflictGroups(SettingsRebindGroup group, out IReadOnlyList<SettingsRebindGroup> conflictGroups)
		{
			if (!_conflictingGroupByGroup.TryGetValue(group, out var value))
			{
				conflictGroups = null;
				return false;
			}
			conflictGroups = value;
			return true;
		}

		public bool TryGetRebindActions(SettingsRebindGroup group, out IReadOnlyList<SettingsRebindAction> rebindActions)
		{
			if (!_rebindActionsByGroup.TryGetValue(group, out var value))
			{
				rebindActions = null;
				return false;
			}
			rebindActions = value;
			return true;
		}

		private void CreateRebindActions()
		{
			SettingsRebindGroup[] groups = _database.Groups;
			foreach (SettingsRebindGroup settingsRebindGroup in groups)
			{
				foreach (SettingsRebindActionData rebindActionData in settingsRebindGroup.RebindActionDatas)
				{
					if (!_rebindDatasByInputActions.TryGetValue(rebindActionData.Action, out var value))
					{
						value = new List<SettingsRebindActionData>();
						_rebindDatasByInputActions.Add(rebindActionData.Action, value);
						foreach (InputActionReference hiddenDuplicateAction in rebindActionData.HiddenDuplicateActions)
						{
							_rebindDatasByInputActions.Add(hiddenDuplicateAction, value);
						}
					}
					if (!value.Contains(rebindActionData))
					{
						value.Add(rebindActionData);
					}
					if (rebindActionData.FeatureFlagValidator != null && !rebindActionData.FeatureFlagValidator.IsEnabledFeatureFlag())
					{
						continue;
					}
					if (!_rebindActionsByGroup.TryGetValue(settingsRebindGroup, out var value2))
					{
						value2 = new List<SettingsRebindAction>();
						_rebindActionsByGroup.Add(settingsRebindGroup, value2);
					}
					if (!_rebindActionsByInputActions.TryGetValue(rebindActionData.Action, out var value3))
					{
						value3 = new List<SettingsRebindAction>();
						_rebindActionsByInputActions.Add(rebindActionData.Action, value3);
						foreach (InputActionReference hiddenDuplicateAction2 in rebindActionData.HiddenDuplicateActions)
						{
							_rebindActionsByInputActions.Add(hiddenDuplicateAction2, value3);
						}
					}
					SettingsRebindAction settingsRebindAction = new SettingsRebindAction(rebindActionData, settingsRebindGroup, _database, isAlt: false);
					_rebindActions.Add(settingsRebindAction);
					value2.Add(settingsRebindAction);
					value3.Add(settingsRebindAction);
					if (rebindActionData.HasAltBinding())
					{
						SettingsRebindAction settingsRebindAction2 = new SettingsRebindAction(rebindActionData, settingsRebindGroup, _database, isAlt: true);
						_rebindActions.Add(settingsRebindAction2);
						value2.Add(settingsRebindAction2);
						value3.Add(settingsRebindAction2);
						settingsRebindAction.SetSiblingRebind(settingsRebindAction2);
						settingsRebindAction2.SetSiblingRebind(settingsRebindAction);
					}
				}
			}
		}

		private void PopulateConflictDicationary()
		{
			SettingsRebindGroup[] groups = _database.Groups;
			foreach (SettingsRebindGroup settingsRebindGroup in groups)
			{
				_conflictingGroupByGroup.Add(settingsRebindGroup, new List<SettingsRebindGroup> { settingsRebindGroup });
			}
			SettingsRebindDatabase.GroupCollection[] conflictingGroups = _database.ConflictingGroups;
			foreach (SettingsRebindDatabase.GroupCollection groupCollection in conflictingGroups)
			{
				for (int j = 0; j < groupCollection.Groups.Length; j++)
				{
					SettingsRebindGroup settingsRebindGroup2 = groupCollection.Groups[j];
					if (!_conflictingGroupByGroup.TryGetValue(settingsRebindGroup2, out var value))
					{
						value = new List<SettingsRebindGroup> { settingsRebindGroup2 };
						_conflictingGroupByGroup.Add(settingsRebindGroup2, value);
					}
					for (int k = 0; k < groupCollection.Groups.Length; k++)
					{
						if (k != j)
						{
							SettingsRebindGroup item = groupCollection.Groups[k];
							if (!value.Contains(item))
							{
								value.Add(item);
							}
						}
					}
				}
			}
		}
	}
}
