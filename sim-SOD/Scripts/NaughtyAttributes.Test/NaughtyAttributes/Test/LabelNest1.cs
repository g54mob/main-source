using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class LabelNest1
	{
		[Label("Label 1")]
		[AllowNesting]
		public int int1;

		public LabelNest2 nest2;
	}
}
