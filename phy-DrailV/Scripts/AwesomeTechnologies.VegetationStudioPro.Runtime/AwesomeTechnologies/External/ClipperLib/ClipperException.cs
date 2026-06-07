using System;

namespace AwesomeTechnologies.External.ClipperLib
{
	internal class ClipperException : Exception
	{
		public ClipperException(string description)
			: base(description)
		{
		}
	}
}
