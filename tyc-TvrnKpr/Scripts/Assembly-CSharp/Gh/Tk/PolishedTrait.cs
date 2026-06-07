namespace Gh.Tk
{
	public class PolishedTrait : GameObjectXTrait
	{
		private const float DecreasePerHour = 5f;

		private const float DecayPause = 2f;

		[PersistenceOptIn]
		private float _percentage;

		[PersistenceOptIn]
		private float _decayPauseInSeconds;

		private int _displayPercentage;

		private string _displayDecayPauseKey;

		private float DecayPauseInSeconds
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Percentage
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected int DisplayPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string DisplayDecayPauseKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected PolishedTrait()
		{
		}

		public PolishedTrait(GameObjectX owner)
		{
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		public bool BlocksDirt()
		{
			return false;
		}

		public override void Update()
		{
		}
	}
}
