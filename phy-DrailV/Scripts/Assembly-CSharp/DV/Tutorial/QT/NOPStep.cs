namespace DV.Tutorial.QT
{
	public class NOPStep : AQuickTutorialStep
	{
		public NOPStep()
			: base("")
		{
		}

		protected override bool InternalCheck()
		{
			return true;
		}
	}
}
