using System;

namespace UniJSON
{
	public class TreeValueException : ArgumentException
	{
		protected TreeValueException(string msg)
			: base(msg)
		{
		}
	}
}
