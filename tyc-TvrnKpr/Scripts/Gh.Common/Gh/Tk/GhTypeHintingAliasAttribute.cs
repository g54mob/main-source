using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class GhTypeHintingAliasAttribute : Attribute
	{
		public string Alias { get; private set; }

		public GhTypeHintingAliasAttribute(string alias)
		{
		}
	}
}
