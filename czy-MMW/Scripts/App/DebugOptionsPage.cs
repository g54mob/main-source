using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugOptionsPage : MonoBehaviour
{
	public RectTransform buttonPanel;

	public DebugToggleButton debugToggleButtonPrefab;

	public DebugOptionHeader debugOptionHeaderPrefab;

	private Selectable firstDebugButton;

	private List<DebugToggleButton> debugButtons = new List<DebugToggleButton>();

	public void InitializeButtons()
	{
		if (buttonPanel.childCount == 0)
		{
			SetupButtons();
		}
	}

	public static string CapitalsToSpacePlusCaps(string originalString)
	{
		string text = "";
		for (int i = 0; i < originalString.Length; i++)
		{
			char c = originalString[i];
			if (char.IsUpper(c) && text.Length > 0)
			{
				text += " ";
			}
			text += c;
		}
		return text;
	}

	private void SetupButtons()
	{
		debugButtons.Clear();
		if (!FeatureToggle.IsFeatureEnabled(Feature.OptionsDebugMenu))
		{
			return;
		}
		Array values = Enum.GetValues(typeof(Feature));
		firstDebugButton = null;
		bool flag = false;
		foreach (Feature item in values)
		{
			if (item == Feature.Group_Hidden)
			{
				flag = true;
			}
			else if (item.ToString().StartsWith("Group_"))
			{
				flag = false;
				DebugOptionHeader debugOptionHeader = UnityEngine.Object.Instantiate(debugOptionHeaderPrefab);
				string newHeaderText = CapitalsToSpacePlusCaps(item.ToString().Substring("Group_".Length));
				debugOptionHeader.Initialize(newHeaderText);
				debugOptionHeader.transform.SetParent(buttonPanel);
				debugOptionHeader.transform.localScale = Vector3.one;
			}
			else if (!flag)
			{
				DebugToggleButton debugToggleButton = UnityEngine.Object.Instantiate(debugToggleButtonPrefab);
				debugToggleButton.Initialize(CapitalsToSpacePlusCaps(item.ToString()), item, this, null);
				debugToggleButton.transform.SetParent(buttonPanel);
				debugToggleButton.transform.localScale = Vector3.one;
				firstDebugButton = firstDebugButton ?? debugToggleButton.GetComponent<Selectable>();
				debugButtons.Add(debugToggleButton);
			}
		}
	}

	public void SetDebugOptionEnabled(string optionName, FeatureToggleState newState)
	{
		if (!optionName.StartsWith("Group_") && Diagnostics.Verify(Enum.TryParse<Feature>(optionName, out var result), "Failed to parse enum from string {0}.", optionName))
		{
			OptionsMenuSettingSource.SetOptionsMenuFeatureState(result, newState);
		}
	}
}
