using System;

namespace JetBrains.Annotations;

internal sealed class RazorInjectionAttribute(string type, string fieldName) : Attribute
{
	private string _003CType_003Ek__BackingField = type;

	private string _003CFieldName_003Ek__BackingField = fieldName;

	public string Type
	{
		get
		{
			return _003CType_003Ek__BackingField;
		}
		private set
		{
			_003CType_003Ek__BackingField = value;
		}
	}

	public string FieldName
	{
		get
		{
			return _003CFieldName_003Ek__BackingField;
		}
		private set
		{
			_003CFieldName_003Ek__BackingField = value;
		}
	}
}
