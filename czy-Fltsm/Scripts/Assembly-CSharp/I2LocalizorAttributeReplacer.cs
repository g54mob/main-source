using UnityEngine;

public class I2LocalizorAttributeReplacer : I2LocalizorKeyReplacer
{
	[SerializeField]
	private DrifterAttributes _attributes;

	[SerializeField]
	private DrifterAttributes.AttributeType _attributeType = DrifterAttributes.AttributeType.Athletics;

	protected override string ReturnText()
	{
		return DrifterAttributes.ReplaceModifiers(base.ReturnText(), _attributes, _attributeType, 1);
	}
}
