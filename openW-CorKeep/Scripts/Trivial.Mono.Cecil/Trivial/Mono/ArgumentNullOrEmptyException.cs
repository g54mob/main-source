using System;

namespace Trivial.Mono
{
	internal class ArgumentNullOrEmptyException : ArgumentException
	{
		public ArgumentNullOrEmptyException(string paramName)
			: base("Argument null or empty", paramName)
		{
		}
	}
}
