namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerDemon : CharacterController
	{
		private float _techniquesCount;

		private float _bonusPower;

		public override float PPower()
		{
			return 0f;
		}

		public override void OnGlimmeredTechniqueFired()
		{
		}
	}
}
