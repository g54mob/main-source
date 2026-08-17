using System;

namespace JetBrains.Annotations;

internal sealed class AspMvcActionAttribute : Attribute
{
	private string _003CAnonymousProperty_003Ek__BackingField;

	public string AnonymousProperty
	{
		get
		{
			return _003CAnonymousProperty_003Ek__BackingField;
		}
		private set
		{
			_003CAnonymousProperty_003Ek__BackingField = value;
		}
	}

	public AspMvcActionAttribute()
	{
	}

	public AspMvcActionAttribute(string anonymousProperty)
	{
		_003CAnonymousProperty_003Ek__BackingField = anonymousProperty;
	}
}
