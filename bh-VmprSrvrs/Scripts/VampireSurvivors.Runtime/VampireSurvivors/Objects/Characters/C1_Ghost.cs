namespace VampireSurvivors.Objects.Characters
{
	public class C1_Ghost : CharacterController
	{
		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		protected override void OnStop()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}
	}
}
