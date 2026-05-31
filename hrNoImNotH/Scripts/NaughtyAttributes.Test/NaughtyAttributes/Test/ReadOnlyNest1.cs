using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ReadOnlyNest1
	{
		[ReadOnly]
		[AllowNesting]
		public float readOnlyFloat;

		public ReadOnlyNest2 nest2;
	}
}
