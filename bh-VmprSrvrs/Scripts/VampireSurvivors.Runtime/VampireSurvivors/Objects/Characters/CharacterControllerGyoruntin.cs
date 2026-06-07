using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerGyoruntin : CharacterController
	{
		private CarnageWeapon NoFutureWeapon;

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		protected override void OnStop()
		{
		}

		public void SetMechaDamageEmitter()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}
	}
}
