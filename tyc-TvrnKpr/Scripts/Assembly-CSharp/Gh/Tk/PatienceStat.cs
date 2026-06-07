namespace Gh.Tk
{
	public class PatienceStat : PatronStat
	{
		private static readonly float[] _tierBaseValues;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _lastPlacateAttempt;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _offeredFreeDrink;

		protected PatienceStat()
		{
		}

		public PatienceStat(Patron owner)
		{
		}

		public static float GetPatienceLossBaseValue(Patron actor)
		{
			return 0f;
		}

		public override void Update()
		{
		}
	}
}
