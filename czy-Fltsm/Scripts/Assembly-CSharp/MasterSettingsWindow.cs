using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MasterSettingsWindow : PauseMenuWindow
{
	[Header("Panels")]
	[SerializeField]
	[Tooltip("List of all the different settings panels.")]
	public SettingsPanel[] SettingsPanels = new SettingsPanel[0];

	[SerializeField]
	private Button _applyButton;

	private SettingsPanelTab _currentTab;

	public void ActivatePanel()
	{
		LoadSettings();
		base.gameObject.SetActive(value: true);
		SettingsPanel[] settingsPanels = SettingsPanels;
		for (int i = 0; i < settingsPanels.Length; i++)
		{
			settingsPanels[i].Changed.AddListener(OnSettingsChanged);
		}
		OnSettingsChanged();
	}

	protected override void OnDisable()
	{
		Settings.Instance.Save();
		SettingsPanel[] settingsPanels = SettingsPanels;
		foreach (SettingsPanel obj in settingsPanels)
		{
			obj.Changed.RemoveListener(OnSettingsChanged);
			obj.DeactivatePanel();
		}
		base.OnDisable();
	}

	public void LoadSettings()
	{
		for (int i = 0; i < SettingsPanels.Length; i++)
		{
			SettingsPanels[i].Load(Settings.Instance);
		}
	}

	public void TryChangeTab(SettingsPanelTab tab, UnityAction<SettingsPanelTab, bool> callback)
	{
		_currentTab = tab;
		callback(tab, this);
	}

	private void OnSettingsChanged()
	{
		SettingsPanel[] settingsPanels = SettingsPanels;
		for (int i = 0; i < settingsPanels.Length; i++)
		{
			if (settingsPanels[i].HasChanges())
			{
				_applyButton.gameObject.SetActive(value: true);
				return;
			}
		}
		_applyButton.gameObject.SetActive(value: false);
	}

	public void ResetToDefault()
	{
		_currentTab.Panel.ResetToDefault();
	}

	public void Apply()
	{
		if (_currentTab.HasChanges())
		{
			_currentTab.Panel.ApplyChanges();
		}
	}
}
