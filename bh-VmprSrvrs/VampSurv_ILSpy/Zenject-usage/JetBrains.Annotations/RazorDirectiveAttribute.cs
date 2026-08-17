using System;

namespace JetBrains.Annotations;

internal sealed class RazorDirectiveAttribute(string directive) : Attribute
{
	private string _003CDirective_003Ek__BackingField = directive;

	public string Directive
	{
		get
		{
			return _003CDirective_003Ek__BackingField;
		}
		private set
		{
			_003CDirective_003Ek__BackingField = value;
		}
	}
}
