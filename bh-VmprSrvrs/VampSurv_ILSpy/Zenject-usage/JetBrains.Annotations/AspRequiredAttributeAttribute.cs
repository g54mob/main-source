using System;

namespace JetBrains.Annotations;

internal sealed class AspRequiredAttributeAttribute(string attribute) : Attribute
{
	private string _003CAttribute_003Ek__BackingField = attribute;

	public string Attribute
	{
		get
		{
			return _003CAttribute_003Ek__BackingField;
		}
		private set
		{
			_003CAttribute_003Ek__BackingField = value;
		}
	}
}
