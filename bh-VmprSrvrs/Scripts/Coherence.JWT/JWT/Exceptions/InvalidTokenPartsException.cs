using System;

namespace JWT.Exceptions
{
	public class InvalidTokenPartsException : ArgumentOutOfRangeException
	{
		public InvalidTokenPartsException(string paramName)
		{
		}
	}
}
