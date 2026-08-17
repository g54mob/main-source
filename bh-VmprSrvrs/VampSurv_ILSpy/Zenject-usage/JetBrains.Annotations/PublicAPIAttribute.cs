using System;

namespace JetBrains.Annotations;

internal sealed class PublicAPIAttribute : Attribute
{
	private string _003CComment_003Ek__BackingField;

	public string Comment
	{
		get
		{
			return _003CComment_003Ek__BackingField;
		}
		private set
		{
			_003CComment_003Ek__BackingField = value;
		}
	}

	public PublicAPIAttribute()
	{
	}

	public PublicAPIAttribute(string comment)
	{
		_003CComment_003Ek__BackingField = comment;
	}
}
