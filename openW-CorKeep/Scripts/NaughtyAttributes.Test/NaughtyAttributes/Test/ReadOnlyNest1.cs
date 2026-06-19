using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ReadOnlyNest1
	{
		[ReadOnly]
		[AllowNesting]
		public float readOnlyFloat = 3.14f;

		public ReadOnlyNest2 nest2;
	}
}
