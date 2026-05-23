using UnityEngine;

public class SettingsResetUnitsMorning : MonoBehaviour
{
	public Checkbox checkbox;

	public void OnApply()
	{
		SettingsManager.Instance.SetResetUnitsInTheMorning(checkbox.state);
	}

	private void OnEnable()
	{
		if ((bool)SettingsManager.Instance)
		{
			checkbox.SetState(SettingsManager.Instance.ResetUnitFormationEveryMorning);
		}
	}
}
