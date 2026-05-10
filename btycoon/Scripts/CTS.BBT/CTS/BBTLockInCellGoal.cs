using System;

namespace CTS
{
	[Serializable]
	public class BBTLockInCellGoal : BBTGoal<LockInCellGoal>
	{
		public NavigationArea[] NavigationAreas;

		protected override void InstantiateGoal()
		{
			Goal = new LockInCellGoal(Quest, Entry, Variable, Target, NavigationAreas);
		}
	}
}
