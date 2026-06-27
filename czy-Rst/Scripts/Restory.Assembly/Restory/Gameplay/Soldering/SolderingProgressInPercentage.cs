namespace Restory.Gameplay.Soldering
{
	public struct SolderingProgressInPercentage
	{
		public float Soot;

		public float Burnt;

		public bool UnconfirmedProgress;

		public static SolderingProgressInPercentage ZeroProgress => new SolderingProgressInPercentage
		{
			Soot = 0f,
			Burnt = 0f
		};

		public static SolderingProgressInPercentage FullProgress => new SolderingProgressInPercentage
		{
			Soot = 1f,
			Burnt = 1f
		};

		public bool IsResoldered()
		{
			if (Soot >= 1f)
			{
				return Burnt >= 1f;
			}
			return false;
		}
	}
}
