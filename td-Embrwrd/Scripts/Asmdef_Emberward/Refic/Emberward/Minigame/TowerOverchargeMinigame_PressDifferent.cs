namespace Refic.Emberward.Minigame
{
	public class TowerOverchargeMinigame_PressDifferent : ATowerOverchargeMinigame
	{
		private int correctAnswer;

		private int correctCount;

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
