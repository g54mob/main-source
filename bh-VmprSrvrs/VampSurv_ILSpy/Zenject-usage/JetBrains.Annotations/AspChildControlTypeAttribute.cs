using System;

namespace JetBrains.Annotations;

internal sealed class AspChildControlTypeAttribute(string tagName, Type controlType) : Attribute
{
	private string _003CTagName_003Ek__BackingField = tagName;

	private Type _003CControlType_003Ek__BackingField = controlType;

	public string TagName
	{
		get
		{
			return _003CTagName_003Ek__BackingField;
		}
		private set
		{
			_003CTagName_003Ek__BackingField = value;
		}
	}

	public Type ControlType
	{
		get
		{
			return _003CControlType_003Ek__BackingField;
		}
		private set
		{
			_003CControlType_003Ek__BackingField = value;
		}
	}
}
