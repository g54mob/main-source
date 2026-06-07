using UnityEngine;

public class DrifterAttributeModifierTooltip : Tooltip
{
	[SerializeField]
	private bool _addDescription = true;

	private DrifterAttributes _attributes;

	private DrifterAttributes.AttributeType _type;

	private int _modifier;

	private int _affinity;

	public void SetAttributes(DrifterAttributes attributes, DrifterAttributes.AttributeType type, int modifier, int affinity)
	{
		_type = type;
		_modifier = modifier;
		_affinity = affinity;
		_attributes = attributes;
	}

	public void SetAttributes(DrifterAttributes attributes, DrifterAttributeModifier modifier)
	{
		SetAttributes(attributes, modifier.Type, modifier.Modifier, modifier.Affinity);
	}

	public override string ParsedText()
	{
		string text = "";
		if (_attributes != null)
		{
			DrifterAttributes.Attribute attribute = _attributes.ReturnAttribute(_type);
			if (_addDescription)
			{
				text += attribute.Description;
			}
			if (_addDescription)
			{
				text += "\n\n";
			}
			text += DrifterAttributes.ReturnDetailedTooltipText(_attributes, attribute, _type, _modifier, _affinity);
		}
		return text;
	}
}
