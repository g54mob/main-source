using UnityEngine.InputSystem;

namespace Kamgam.SettingsGenerator
{
	public static class InputActionRebindingExtensionsExtensions
	{
		public static bool FindBinding(this InputActionAsset inputActionAsset, string bindingId, out InputBinding binding)
		{
			if (string.IsNullOrEmpty(bindingId))
			{
				binding = default(InputBinding);
				return false;
			}
			int count = inputActionAsset.actionMaps.Count;
			for (int i = 0; i < count; i++)
			{
				InputActionMap inputActionMap = inputActionAsset.actionMaps[i];
				int count2 = inputActionMap.bindings.Count;
				for (int j = 0; j < count2; j++)
				{
					if (inputActionMap.bindings[j].id.ToString() == bindingId)
					{
						binding = inputActionMap.bindings[j];
						return true;
					}
				}
			}
			binding = default(InputBinding);
			return false;
		}

		public static InputAction GetActionOfBinding(this InputActionAsset inputActionAsset, string bindingId)
		{
			if (string.IsNullOrEmpty(bindingId))
			{
				return null;
			}
			int count = inputActionAsset.actionMaps.Count;
			for (int i = 0; i < count; i++)
			{
				InputActionMap inputActionMap = inputActionAsset.actionMaps[i];
				int count2 = inputActionMap.actions.Count;
				for (int j = 0; j < count2; j++)
				{
					InputAction inputAction = inputActionMap.actions[j];
					int count3 = inputAction.bindings.Count;
					for (int k = 0; k < count3; k++)
					{
						if (inputAction.bindings[k].id.ToString() == bindingId)
						{
							return inputAction;
						}
					}
				}
			}
			return null;
		}

		public static InputActionMap GetActionMapOfBinding(this InputActionAsset inputActionAsset, string bindingId)
		{
			if (string.IsNullOrEmpty(bindingId))
			{
				return null;
			}
			int count = inputActionAsset.actionMaps.Count;
			for (int i = 0; i < count; i++)
			{
				InputActionMap inputActionMap = inputActionAsset.actionMaps[i];
				int count2 = inputActionMap.actions.Count;
				for (int j = 0; j < count2; j++)
				{
					InputAction inputAction = inputActionMap.actions[j];
					int count3 = inputAction.bindings.Count;
					for (int k = 0; k < count3; k++)
					{
						if (inputAction.bindings[k].id.ToString() == bindingId)
						{
							return inputActionMap;
						}
					}
				}
			}
			return null;
		}

		public static int GetBindingIndexWithinActionMap(this InputActionAsset inputActionAsset, string bindingId)
		{
			if (string.IsNullOrEmpty(bindingId))
			{
				return -1;
			}
			int count = inputActionAsset.actionMaps.Count;
			for (int i = 0; i < count; i++)
			{
				InputActionMap inputActionMap = inputActionAsset.actionMaps[i];
				int count2 = inputActionMap.bindings.Count;
				for (int j = 0; j < count2; j++)
				{
					if (inputActionMap.bindings[j].id.ToString() == bindingId)
					{
						return j;
					}
				}
			}
			return -1;
		}

		public static int GetBindingIndexWithinAction(this InputActionAsset inputActionAsset, string bindingId)
		{
			if (string.IsNullOrEmpty(bindingId))
			{
				return -1;
			}
			int count = inputActionAsset.actionMaps.Count;
			for (int i = 0; i < count; i++)
			{
				InputActionMap inputActionMap = inputActionAsset.actionMaps[i];
				int count2 = inputActionMap.actions.Count;
				for (int j = 0; j < count2; j++)
				{
					InputAction inputAction = inputActionMap.actions[j];
					int count3 = inputAction.bindings.Count;
					for (int k = 0; k < count3; k++)
					{
						if (inputAction.bindings[k].id.ToString() == bindingId)
						{
							return k;
						}
					}
				}
			}
			return -1;
		}

		public static void ApplyBindingOverride(this InputActionAsset inputActionAsset, string bindingId, string overridePath, string overrideInteractions = null, string overrideProcessors = null)
		{
			inputActionAsset.ApplyBindingOverrideWithResult(bindingId, overridePath, overrideInteractions, overrideProcessors);
		}

		public static bool ApplyBindingOverrideWithResult(this InputActionAsset inputActionAsset, string bindingId, string overridePath, string overrideInteractions = null, string overrideProcessors = null)
		{
			int bindingIndexWithinActionMap = inputActionAsset.GetBindingIndexWithinActionMap(bindingId);
			if (bindingIndexWithinActionMap >= 0)
			{
				InputActionMap actionMapOfBinding = inputActionAsset.GetActionMapOfBinding(bindingId);
				if (actionMapOfBinding != null)
				{
					actionMapOfBinding.ApplyBindingOverride(bindingIndexWithinActionMap, new InputBinding
					{
						overridePath = overridePath,
						overrideInteractions = overrideInteractions,
						overrideProcessors = overrideProcessors
					});
					return true;
				}
				return false;
			}
			return false;
		}

		public static void ClearOverride(this InputActionAsset inputActionAsset, string bindingId)
		{
			int bindingIndexWithinAction = inputActionAsset.GetBindingIndexWithinAction(bindingId);
			if (bindingIndexWithinAction >= 0)
			{
				inputActionAsset.GetActionOfBinding(bindingId)?.RemoveBindingOverride(bindingIndexWithinAction);
			}
		}
	}
}
