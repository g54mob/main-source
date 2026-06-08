namespace GRP
{
	public class GoalGroup : Goal
	{
		public enum Mode
		{
			And = 0,
			Or = 1
		}

		public Mode mode;

		public Goal[] goals;

		protected override void Setup()
		{
		}

		public bool And()
		{
			return false;
		}

		public bool Or()
		{
			return false;
		}

		public void HandleChanges()
		{
		}
	}
}
