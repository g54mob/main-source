using UnityEngine;
using UnityEngine.UI;

public class UIGameSettingItem_Toggle : AUIGameSettingItem
{
	[SerializeField]
	protected Toggle toggle;

	protected override void Start()
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void OnDisable()
	{
	}

	protected virtual void Update()
	{
	}

	private void OnToggleChanged(bool isOn)
	{
	}

	protected virtual void OnToggleChangedProc(bool isOn)
	{
	}

	protected override void ApplySetting()
	{
	}

	protected override void ResetToDefault()
	{
	}

	protected override void UpdateDisplay()
	{
	}
}
