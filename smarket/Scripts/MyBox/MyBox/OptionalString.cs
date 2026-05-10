using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class OptionalString : Optional<string>
	{
		public static OptionalString WithValue(string value)
		{
			return null;
		}
	}
}
