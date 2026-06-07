using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelTabGroup : SelectableGroup
{
	[SerializeField]
	private MasterSettingsWindow _window;

	protected override void Select(Selectable selectable)
	{
		if (selectable is SettingsPanelTab tab)
		{
			_window.TryChangeTab(tab, OnChangeTabResult);
		}
	}

	private void OnChangeTabResult(SettingsPanelTab tab, bool result)
	{
		if (result)
		{
			base.Select(tab);
		}
	}
}
