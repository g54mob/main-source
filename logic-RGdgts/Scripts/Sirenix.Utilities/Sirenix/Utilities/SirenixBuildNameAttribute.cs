using System;

namespace Sirenix.Utilities
{
	public class SirenixBuildNameAttribute : Attribute
	{
		public string BuildName { get; private set; }

		public SirenixBuildNameAttribute(string buildName)
		{
		}
	}
}
