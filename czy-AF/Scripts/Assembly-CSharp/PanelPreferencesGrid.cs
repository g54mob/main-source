using System.Collections;
using UnityEngine;

public class PanelPreferencesGrid : MonoBehaviour
{
	private Panel panel;

	private void Awake()
	{
		panel = Panel.SetTarget(base.transform);
		Panel.CreateComponent("opacity", "input", new Hashtable
		{
			{ "label", "Opacity" },
			{ "value", "0.5" },
			{ "min", 0f },
			{ "max", 1f },
			{ "content", "number" }
		});
		Panel.CreateComponent("selection", "checkbox", new Hashtable
		{
			{ "label", "Select through grid" },
			{ "value", true }
		});
		panel.SetValue("opacity", Preferences.data.gridOpacity.ToString());
		panel.SetValue("selection", Preferences.data.gridSelection);
	}

	private void opacityUpdate(string n)
	{
		Preferences.data.gridOpacity = float.Parse(n);
		Preferences.SavePreferences();
	}

	private void selectionToggle(bool t)
	{
		Preferences.data.gridSelection = t;
		Preferences.SavePreferences();
	}
}
