using UnityEngine;
using UnityEngine.Events;

public class OptionsPropertyDropdownField : OptionsPropertyField<DropdownField>
{
	[SerializeField]
	private UnityEvent<int> OnUpdateSetting = new UnityEvent<int>();

	public DropdownField GetDropdownField()
	{
		return propertyField;
	}

	public void UpdateSetting(int value)
	{
		OnUpdateSetting.Invoke(value);
	}

	public void OnUpdateField(int value)
	{
	}
}
