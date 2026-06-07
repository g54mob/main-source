using System.Collections;
using Kamgam.SettingsGenerator;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseInvertYWrapper : MonoBehaviour
{
	public InputActionReference lookAction;

	private void OnEnable()
	{
		StartCoroutine(DetectCurrentValue());
	}

	private IEnumerator DetectCurrentValue()
	{
		yield return new WaitForSeconds(0.5f);
		bool currentValue = MouseInvertYConnection.CurrentValue;
		bool currentValue2 = MouseInvertXConnection.CurrentValue;
		SetInvert(currentValue2, currentValue);
	}

	public void SetInvert(bool invertX, bool invertY)
	{
		for (int i = 0; i < lookAction.action.bindings.Count; i++)
		{
			InputBinding inputBinding = lookAction.action.bindings[i];
			if (!string.IsNullOrEmpty(inputBinding.processors) && inputBinding.processors.Contains("InvertVector2"))
			{
				string overrideProcessors = "InvertVector2(invertX=" + (invertX ? "true" : "false") + ",invertY=" + (invertY ? "false" : "true") + ")";
				lookAction.action.ApplyBindingOverride(i, new InputBinding
				{
					overrideProcessors = overrideProcessors
				});
			}
		}
	}

	public void SetMouseInvertY(Toggle toggle)
	{
		bool currentValue = MouseInvertXConnection.CurrentValue;
		SetInvert(currentValue, toggle.isOn);
	}
}
