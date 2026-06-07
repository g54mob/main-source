namespace Refic.Emberward.Minigame
{
	public class TowerOverchargeMinigame_1To9 : ATowerOverchargeMinigame
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
