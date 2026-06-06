using I2.Loc;
using UnityEngine;

public class TMP_DrifertAttributeTypeDropDown : TMP_EnumDropdown<DrifterAttributes.AttributeType>
{
	[SerializeField]
	private DrifterAttributes _drifterAttributes;

	[SerializeField]
	private LocalizedString _noneOptionOverride = null;

	[SerializeField]
	private DrifterAttributeTypeEvent _onValueChanged;

	protected override void OnValueChanged(DrifterAttributes.AttributeType value)
	{
		_onValueChanged.Invoke(value);
	}

	protected override bool TryReturnOption(DrifterAttributes.AttributeType value, out string option)
	{
		if (value == DrifterAttributes.AttributeType.None)
		{
			option = _noneOptionOverride;
			return true;
		}
		DrifterAttributes.Attribute attribute = _drifterAttributes.ReturnAttribute(value);
		if (attribute != null && attribute.ShowInRerollDropdown)
		{
			option = attribute.Name;
			return true;
		}
		option = null;
		return false;
	}
}
