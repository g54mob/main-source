namespace Gh.Tk
{
	public class CreatesDustTrait : PropTraitBase
	{
		private DustSettings _dustSettings;

		private bool _isLarderTile;

		[PersistenceOptIn]
		private float _dustToGain;

		private DustSettings DustSettings => null;

		protected CreatesDustTrait()
		{
		}

		public CreatesDustTrait(Prop owner)
		{
		}

		public override void Init()
		{
		}

		public override void Update()
		{
		}

		private float GetRandomSpawnDifference()
		{
			return 0f;
		}
	}
}
