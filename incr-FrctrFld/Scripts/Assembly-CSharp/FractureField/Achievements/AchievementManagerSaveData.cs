using System.Collections.Generic;
using Reactivity;

namespace FractureField.Achievements
{
	public class AchievementManagerSaveData : IConvertableSaveData
	{
		public List<string> CompletedAchievementIds { get; set; }

		public RBool HideCompleted { get; set; }

		protected AchievementManagerSaveData Save(AchievementManager data)
		{
			return null;
		}
	}
}
