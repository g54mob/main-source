namespace Refic.Emberward.Minigame
{
	public class TowerOverchargeMinigame_PressAll : ATowerOverchargeMinigame
	{
		private int buttonPressedCount;

		protected override void SetupMinigame()
		{
		}

		public override bool ValidateButtonPress(int index)
		{
			return false;
		}

		public override bool IsCompleted()
		{
			return false;
		}
	}
}
