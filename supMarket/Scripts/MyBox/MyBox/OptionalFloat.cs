using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class OptionalFloat : Optional<float>
	{
		public static OptionalFloat WithValue(float value)
		{
			return null;
		}
	}
}
