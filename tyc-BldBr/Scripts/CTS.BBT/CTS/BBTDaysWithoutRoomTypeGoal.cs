using System;

namespace CTS
{
	[Serializable]
	public class BBTDaysWithoutRoomTypeGoal : BBTGoal<DaysWithoutRoomTypeGoal>
	{
		public NavigationArea[] NavigationAreas;

		protected override void InstantiateGoal()
		{
			Goal = new DaysWithoutRoomTypeGoal(Quest, Entry, Variable, Target, NavigationAreas);
		}
	}
}
