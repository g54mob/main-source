using System;

namespace Coherence.Toolkit
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class DisplayNameAttribute : Attribute
	{
		public string Name { get; }

		public string Tooltip { get; }

		public DisplayNameAttribute(string name, string tooltip)
		{
		}
	}
}
