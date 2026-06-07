using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class TagNest1
	{
		[Tag]
		public string tag1;

		public TagNest2 nest2;
	}
}
