using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameSettingItem_Switch : AUIGameSettingItem
{
	[Serializable]
	public class SwitchOption
	{
		public string content;

		public bool isLocKey;
	}

	[SerializeField]
	protected List<SwitchOption> list_OptionsData;

	[SerializeField]
	protected TMP_Text text_CurrentOption;

	[SerializeField]
	protected Button button_Previous;

	[SerializeField]
	protected Button button_Next;

	[SerializeField]
	protected bool doOverrideSwitchOrder;

	[SerializeField]
	protected List<int> list_OverrideSwitchOrder;

	protected override void Start()
	{
	}

	private void Update()
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void OnDisable()
	{
	}

	public void PreviousOption()
	{
	}

	public void NextOption()
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
