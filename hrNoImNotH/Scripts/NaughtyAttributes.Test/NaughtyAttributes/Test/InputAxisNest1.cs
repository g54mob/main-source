using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class InputAxisNest1
	{
		[InputAxis]
		public string inputAxis1;

		public InputAxisNest2 nest2;
	}
}
