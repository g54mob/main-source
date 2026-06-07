using System;

namespace PlaceholderSoftware.WetStuff
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class RazorDirectiveAttribute : Attribute
	{
		[NotNull]
		public string Directive { get; private set; }

		public RazorDirectiveAttribute([NotNull] string directive)
		{
			Directive = directive;
		}
	}
}
