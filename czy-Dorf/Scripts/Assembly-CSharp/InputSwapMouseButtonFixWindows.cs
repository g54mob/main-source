using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Utilities;

public class InputSwapMouseButtonFixWindows : MonoBehaviour
{
	private enum SystemMetric
	{
		SM_SWAPBUTTON = 23
	}

	[DllImport("User32.dll")]
	private static extern int GetSystemMetrics(SystemMetric sm);

	private void OnEnable()
	{
		if (GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0)
		{
			return;
		}
		PlayerInput component = GetComponent<PlayerInput>();
		InputSystemUIInputModule component2 = GetComponent<InputSystemUIInputModule>();
		InputActionAsset inputActionAsset;
		if (component != null)
		{
			inputActionAsset = component.actions;
		}
		else
		{
			if (!(component2 != null))
			{
				return;
			}
			inputActionAsset = component2.actionsAsset;
		}
		foreach (InputActionMap actionMap in inputActionAsset.actionMaps)
		{
			ReadOnlyArray<InputBinding> bindings = actionMap.bindings;
			for (int i = 0; i < bindings.Count; i++)
			{
				if (bindings[i].effectivePath == "<Mouse>/leftButton")
				{
					InputActionRebindingExtensions.ApplyBindingOverride(actionMap, i, new InputBinding
					{
						overridePath = "<Mouse>/rightButton"
					});
				}
				else if (bindings[i].effectivePath == "<Mouse>/rightButton")
				{
					InputActionRebindingExtensions.ApplyBindingOverride(actionMap, i, new InputBinding
					{
						overridePath = "<Mouse>/leftButton"
					});
				}
			}
		}
	}
}
