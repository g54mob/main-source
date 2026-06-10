using System;
using FoxyVoxel.Logging;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.UI
{
	public class GoalPreferenceLayoutItemView : LayoutGroupItemView
	{
		private readonly int levelOneIndex;

		private readonly int levelTwoIndex = 1;

		private readonly int levelFourIndex = 2;

		private readonly int levelFiveIndex = 3;

		public void SetData(int preferenceType)
		{
			switch ((GoalPreferenceLevel)preferenceType)
			{
			case GoalPreferenceLevel.Resentful:
				base.GroupItems[levelOneIndex].SetActive(value: true);
				base.GroupItems[levelTwoIndex].SetActive(value: false);
				base.GroupItems[levelFourIndex].SetActive(value: false);
				base.GroupItems[levelFiveIndex].SetActive(value: false);
				break;
			case GoalPreferenceLevel.Unwilling:
				base.GroupItems[levelOneIndex].SetActive(value: false);
				base.GroupItems[levelTwoIndex].SetActive(value: true);
				base.GroupItems[levelFourIndex].SetActive(value: false);
				base.GroupItems[levelFiveIndex].SetActive(value: false);
				break;
			case GoalPreferenceLevel.Indifferent:
				base.GroupItems[levelOneIndex].SetActive(value: false);
				base.GroupItems[levelTwoIndex].SetActive(value: false);
				base.GroupItems[levelFourIndex].SetActive(value: false);
				base.GroupItems[levelFiveIndex].SetActive(value: false);
				break;
			case GoalPreferenceLevel.Eager:
				base.GroupItems[levelOneIndex].SetActive(value: false);
				base.GroupItems[levelTwoIndex].SetActive(value: false);
				base.GroupItems[levelFourIndex].SetActive(value: true);
				base.GroupItems[levelFiveIndex].SetActive(value: false);
				break;
			case GoalPreferenceLevel.Passionate:
				base.GroupItems[levelOneIndex].SetActive(value: false);
				base.GroupItems[levelTwoIndex].SetActive(value: false);
				base.GroupItems[levelFourIndex].SetActive(value: false);
				base.GroupItems[levelFiveIndex].SetActive(value: true);
				break;
			case GoalPreferenceLevel.None:
				Log.Error("GoalPreferenceLevel.None is not a valid GoalPreferenceLevel", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\GoalPreferenceLayoutItemView.cs");
				break;
			default:
				throw new ArgumentOutOfRangeException("preferenceType", preferenceType, null);
			case GoalPreferenceLevel.Incapable:
				break;
			}
		}
	}
}
