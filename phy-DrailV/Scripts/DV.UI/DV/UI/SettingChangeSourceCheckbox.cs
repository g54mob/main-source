using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(ToggleDV))]
	public class SettingChangeSourceCheckbox : SettingChangeSource<bool>
	{
		protected override void Awake()
		{
			base.Awake();
			GetComponent<ToggleDV>().onValueChanged.AddListener(UpdateAndFireEvent);
		}

		protected override void OnResetOrApplied()
		{
			if (base.gameObject.activeSelf)
			{
				GetComponent<ToggleDV>().isOn = GetLatestValueFromProvider();
				base.OnResetOrApplied();
			}
		}
	}
}
