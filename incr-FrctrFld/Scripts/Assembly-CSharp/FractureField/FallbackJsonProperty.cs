using System;

namespace FractureField
{
	[AttributeUsage(AttributeTargets.Property)]
	public class FallbackJsonProperty : Attribute
	{
		public string PreferredName { get; }

		public string[] FallbackReadNames { get; }

		public FallbackJsonProperty(string preferredName, params string[] fallbackReadNames)
		{
		}
	}
}
