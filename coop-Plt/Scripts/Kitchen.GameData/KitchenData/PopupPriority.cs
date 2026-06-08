using System.Collections.Generic;

namespace KitchenData
{
	public static class PopupPriority
	{
		private static readonly List<PopupType> Priority = new List<PopupType>
		{
			PopupType.Null,
			PopupType.LoadPreviousSave,
			PopupType.EnterPracticeMode,
			PopupType.StartTutorial,
			PopupType.PracticeBlockedByParcelOrHolding,
			PopupType.ScrapFranchiseInFranchiseMode,
			PopupType.RestartRestaurantAfterFailure,
			PopupType.QuitToLobby,
			PopupType.LeaveTutorial,
			PopupType.AbandonRestaurant,
			PopupType.AbandonSave,
			PopupType.EndDayPopup,
			PopupType.EndDemoPopup,
			PopupType.SpeedrunCompleted
		};

		public static int Get(PopupType type)
		{
			if (!Priority.Contains(type))
			{
				return 0;
			}
			return Priority.IndexOf(type);
		}
	}
}
