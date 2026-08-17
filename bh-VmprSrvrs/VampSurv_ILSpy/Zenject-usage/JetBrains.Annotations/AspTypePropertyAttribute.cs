using System;

namespace JetBrains.Annotations;

internal sealed class AspTypePropertyAttribute : Attribute
{
	private bool _003CCreateConstructorReferences_003Ek__BackingField;

	public bool CreateConstructorReferences
	{
		get
		{
			return _003CCreateConstructorReferences_003Ek__BackingField;
		}
		private set
		{
			_003CCreateConstructorReferences_003Ek__BackingField = value;
		}
	}

	public AspTypePropertyAttribute(bool createConstructorReferences)
	{
		_003CCreateConstructorReferences_003Ek__BackingField = createConstructorReferences;
	}
}
