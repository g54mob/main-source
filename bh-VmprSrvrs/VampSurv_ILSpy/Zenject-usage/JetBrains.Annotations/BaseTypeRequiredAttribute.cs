using System;

namespace JetBrains.Annotations;

internal sealed class BaseTypeRequiredAttribute(Type baseType) : Attribute
{
	private Type _003CBaseType_003Ek__BackingField = baseType;

	public Type BaseType
	{
		get
		{
			return _003CBaseType_003Ek__BackingField;
		}
		private set
		{
			_003CBaseType_003Ek__BackingField = value;
		}
	}
}
