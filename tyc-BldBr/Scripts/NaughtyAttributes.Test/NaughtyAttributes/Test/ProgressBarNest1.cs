using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ProgressBarNest1
	{
		[ProgressBar("Mana", 100f, EColor.Blue)]
		public float mana = 25f;

		public ProgressBarNest2 nest2;
	}
}
