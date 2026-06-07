using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public struct ReadOnlyNest2
	{
		[ReadOnly]
		[AllowNesting]
		public string readOnlyString;
	}
}
