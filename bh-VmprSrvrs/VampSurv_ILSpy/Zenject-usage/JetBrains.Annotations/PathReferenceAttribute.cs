using System;

namespace JetBrains.Annotations;

internal sealed class PathReferenceAttribute : Attribute
{
	private string _003CBasePath_003Ek__BackingField;

	public string BasePath
	{
		get
		{
			return _003CBasePath_003Ek__BackingField;
		}
		private set
		{
			_003CBasePath_003Ek__BackingField = value;
		}
	}

	public PathReferenceAttribute()
	{
	}

	public PathReferenceAttribute(string basePath)
	{
		_003CBasePath_003Ek__BackingField = basePath;
	}
}
