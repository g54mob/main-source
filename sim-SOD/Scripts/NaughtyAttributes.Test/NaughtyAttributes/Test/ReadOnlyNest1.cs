using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ReadOnlyNest1
	{
		[AllowNesting]
		[ReadOnly]
		public float readOnlyFloat;

		public ReadOnlyNest2 nest2;
	}
}
