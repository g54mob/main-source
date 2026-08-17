using System;

namespace JetBrains.Annotations;

internal sealed class AspMvcAreaAttribute : Attribute
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

	public AspMvcAreaAttribute()
	{
	}

	public AspMvcAreaAttribute(string anonymousProperty)
	{
		_003CAnonymousProperty_003Ek__BackingField = anonymousProperty;
	}
}
