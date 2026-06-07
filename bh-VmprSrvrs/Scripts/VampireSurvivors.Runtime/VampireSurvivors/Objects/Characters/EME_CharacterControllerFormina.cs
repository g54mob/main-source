using System.Collections.Generic;

namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerFormina : EME_CharacterControllerShowstopper
	{
		public bool spawnFollowerNextFrame;

		private float _techniquesCount;

		private float _bonusDuration;

		private List<string> firingAnims;

		public override float PDuration()
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

		public override void OnRangedAttackAnim()
		{
		}
	}
}
