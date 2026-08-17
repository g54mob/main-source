using System;

namespace JetBrains.Annotations;

internal sealed class AspMvcControllerAttribute : Attribute
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

	public AspMvcControllerAttribute()
	{
	}

	public AspMvcControllerAttribute(string anonymousProperty)
	{
		_003CAnonymousProperty_003Ek__BackingField = anonymousProperty;
	}
}
