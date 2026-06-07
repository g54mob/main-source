namespace VampireSurvivors.Objects.Characters
{
	public class TP_SlograAndGaibon_Character : TP_Character
	{
		private bool _spawnFollowerNextFrame;

		private bool isSlogra;

		private CharacterController follower;

		private bool isEnraged;

		public bool IsSlogra => false;

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		protected override void OnStop()
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
