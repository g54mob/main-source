using System;

namespace Sirenix.Utilities
{
	public class SirenixBuildVersionAttribute : Attribute
	{
		public string Version { get; private set; }

		public SirenixBuildVersionAttribute(string version)
		{
		}
	}
}
