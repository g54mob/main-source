using System;

namespace Kitchen.Utility
{
	public class DependencyFailedException : Exception
	{
		public DependencyFailedException(string s)
			: base(s)
		{
		}
	}
}
