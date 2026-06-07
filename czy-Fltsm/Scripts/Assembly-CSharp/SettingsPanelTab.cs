using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsPanelTab : AnimatedToggle
{
	[SerializeField]
	private MasterSettingsWindow _window;

	[SerializeField]
	private SettingsPanel _panel;

	public SettingsPanel Panel => _panel;

	protected override void OnEnable()
	{
		base.OnEnable();
		if (base.isOn)
		{
			_window.TryChangeTab(this, OnChangeTabResult);
		}
	}

	private void OnChangeTabResult(SettingsPanelTab tab, bool result)
	{
		bool flag = tab == this && result;
		if (base.isOn != flag)
		{
			base.isOn = flag;
		}
		else if (base.isOn)
		{
			_panel.SetActive(value: true);
		}
	}

	public bool HasChanges()
	{
		if ((bool)_panel)
		{
			return _panel.HasChanges();
		}
		return false;
	}

	public override void OnSelect(BaseEventData eventData)
	{
		if (base.isOn)
		{
			_window.TryChangeTab(this, OnChangeTabResult);
		}
		base.OnSelect(eventData);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		_window.TryChangeTab(this, OnChangeTabResult);
	}

	public override void OnSubmit(BaseEventData eventData)
	{
	}
}
