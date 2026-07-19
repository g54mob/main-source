using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPreferencesVisuals : MonoBehaviour
{
	private Panel panel;

	private void Awake()
	{
		panel = Panel.SetTarget(base.transform);
		List<string> value = new List<string> { "Default", "Light", "Dark", "Space", "Sky (sunset)", "Sky" };
		Panel.CreateComponent("workspace", "dropdown", new Hashtable
		{
			{ "label", "Workspace" },
			{ "list", value },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateDivider();
		List<string> value2 = new List<string> { "High", "Medium", "Low", "Off" };
		Panel.CreateComponent("antiAlias", "dropdown", new Hashtable
		{
			{ "label", "Anti-alias" },
			{ "list", value2 },
			{ "maximumHeight", true },
			{ "width", 100 }
		});
		Panel.CreateComponent("ambientOcclusion", "checkbox", new Hashtable
		{
			{ "label", "Ambient occlusion" },
			{ "value", true }
		});
		Panel.CreateComponent("shadows", "checkbox", new Hashtable
		{
			{ "label", "Shadows" },
			{ "value", true }
		});
		Panel.CreateComponent("vsync", "checkbox", new Hashtable
		{
			{ "label", "Vsync" },
			{ "value", false }
		});
		Panel.CreateDivider();
		Panel.CreateComponent("scale", "input", new Hashtable
		{
			{ "label", "UI Scale" },
			{ "value", "1" },
			{ "min", 0.5f },
			{ "max", 2f },
			{ "content", "number" }
		});
		Panel.CreateDivider();
		Panel.CreateComponent("scaleGizmo", "input", new Hashtable
		{
			{ "label", "Gizmo Scale" },
			{ "value", "1" },
			{ "min", 0.5f },
			{ "max", 2f },
			{ "content", "number" }
		});
		panel.SetValue("workspace", Preferences.data.visualsWorkspace);
		panel.SetValue("antiAlias", Preferences.data.visualsAntiAlias);
		panel.SetValue("ambientOcclusion", Preferences.data.visualsAmbientOcclusion);
		panel.SetValue("shadows", Preferences.data.visualsShadows);
		panel.SetValue("vsync", Preferences.data.visualsVSync);
		panel.SetValue("scale", Preferences.data.visualsScale.ToString());
		panel.SetValue("scaleGizmo", Preferences.data.gizmoScale.ToString());
	}

	public void workspaceSelect(int i)
	{
		Preferences.data.visualsWorkspace = i;
		Preferences.SavePreferences();
	}

	public void antiAliasSelect(int i)
	{
		Preferences.data.visualsAntiAlias = i;
		Preferences.SavePreferences();
	}

	private void ambientOcclusionToggle(bool t)
	{
		Preferences.data.visualsAmbientOcclusion = t;
		Preferences.SavePreferences();
	}

	private void shadowsToggle(bool t)
	{
		Preferences.data.visualsShadows = t;
		Preferences.SavePreferences();
	}

	private void vsyncToggle(bool t)
	{
		Preferences.data.visualsVSync = t;
		Preferences.SavePreferences();
	}

	private void scaleUpdate(string n)
	{
		Preferences.data.visualsScale = float.Parse(n);
		Preferences.SavePreferences();
	}

	private void scaleGizmoUpdate(string n)
	{
		Preferences.data.gizmoScale = float.Parse(n);
		Preferences.SavePreferences();
	}
}
