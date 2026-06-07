using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class RenamedFromAttribute : Attribute
	{
		public string previousName { get; }

		public RenamedFromAttribute(string previousName)
		{
			this.previousName = previousName;
		}
	}
}
