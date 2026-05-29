using System;

namespace Libs
{
	public class IntValueAttribute : Attribute
	{
		public int IntValue { get; protected set; }

		public IntValueAttribute(int value)
		{
		}
	}
}
