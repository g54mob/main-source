namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerBonnie : EME_CharacterControllerShowstopper
	{
		public bool spawnFollowerNextFrame;

		private float _techniquesCount;

		private float _bonusPower;

		public override float PPower()
		{
			return 0f;
		}

		public override void OnGlimmeredTechniqueFired()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
