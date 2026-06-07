using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerGenevieve : CharacterController
	{
		public WorldEaterVFX _wolrdEater;

		public override bool NeedsCart => false;

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		protected override void OnStop()
		{
		}

		public void LastBreath()
		{
		}

		public override bool DoesWantPickup(Pickup pickup)
		{
			return false;
		}
	}
}
