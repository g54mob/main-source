using System;

namespace TwitchLib.Client.Exceptions
{
	public class IllegalAssignmentException : Exception
	{
		public IllegalAssignmentException(string description)
			: base(description)
		{
		}
	}
}
