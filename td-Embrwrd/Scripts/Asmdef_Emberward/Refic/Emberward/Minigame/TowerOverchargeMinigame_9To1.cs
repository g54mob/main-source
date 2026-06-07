namespace Refic.Emberward.Minigame
{
	public class TowerOverchargeMinigame_9To1 : ATowerOverchargeMinigame
	{
		private int nextCorrectAnswer;

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
