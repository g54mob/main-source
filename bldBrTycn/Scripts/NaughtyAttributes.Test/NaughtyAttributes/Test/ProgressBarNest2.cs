using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ProgressBarNest2
	{
		[ProgressBar("Stamina", 100f, EColor.Green)]
		public float stamina = 75f;
	}
}
