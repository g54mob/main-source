using System;

namespace JetBrains.Annotations;

internal sealed class RazorImportNamespaceAttribute(string name) : Attribute
{
	private string _003CName_003Ek__BackingField = name;

	public string Name
	{
		get
		{
			return _003CName_003Ek__BackingField;
		}
		private set
		{
			_003CName_003Ek__BackingField = value;
		}
	}
}
