using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public struct ReadOnlyNest2
	{
		[AllowNesting]
		[ReadOnly]
		public string readOnlyString;
	}
}
