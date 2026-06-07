namespace Gh.Tk
{
	public class StaffEatDrinkBehaviour : StaffBehaviour
	{
		private const float _minCooldownInDays = 0.8f;

		private const float _maxCooldownInDays = 1.2f;

		protected StaffEatDrinkBehaviour()
		{
		}

		public StaffEatDrinkBehaviour(Staff owner)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		private void CoolDown()
		{
		}
	}
}
