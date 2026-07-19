using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class PanelPreferencesGeneral : MonoBehaviour
{
	public Sidebar sidebar;

	private Panel panel;

	private void OnEnable()
	{
		Tips.Hide();
	}

	private void Awake()
	{
		panel = Panel.SetTarget(base.transform);
		Panel.CreateComponent("recovery", "checkbox", new Hashtable
		{
			{ "label", "Auto save back-up" },
			{ "value", true }
		});
		Panel.CreateDivider();
		Panel.CreateComponent("tips", "checkbox", new Hashtable
		{
			{ "label", "Display hints" },
			{ "value", true }
		});
		Panel.CreateDivider();
		Panel.CreateComponent("resetPrefences", "button", new Hashtable { { "text", "Reset preferences" } });
		Panel.CreateComponent("clearThubmnailCache", "button", new Hashtable { { "text", "Clear thumbnail cache" } });
		Panel.CreateComponent("preferencesFolder", "button", new Hashtable { { "text", "Open preferences folder" } });
		panel.SetValue("recovery", Preferences.data.generalRecovery);
		panel.SetValue("tips", Preferences.data.displayHints);
	}

	private void recoveryToggle(bool t)
	{
		Preferences.data.generalRecovery = t;
		Preferences.SavePreferences();
	}

	private void tipsToggle(bool t)
	{
		Preferences.data.displayHints = t;
		Preferences.SavePreferences();
	}

	private void resetPrefencesCallback(Transform t)
	{
		Preferences.ResetPreferences();
		Global.ShowMessage("Preferences reset");
		sidebar.Close();
	}

	private void clearThubmnailCacheCallback(Transform t)
	{
		Cache.Clear();
		Global.ShowMessage("Thumbnail cache cleared, restart Asset Forge for changes", 4f);
		sidebar.Close();
	}

	private void preferencesFolderCallback(Transform t)
	{
		string persistentDataPath = Application.persistentDataPath;
		if (Directory.Exists(persistentDataPath))
		{
			Process.Start("explorer.exe", persistentDataPath.Replace("/", "\\"));
		}
	}
}
