using UnityEngine;

namespace Simulator.GameWorld
{
	public class ShopEntryDoor : Door
	{
		[Header("Entry Door")]
		[SerializeField]
		private DoorTrigger m_insideTrigger;

		protected override void OnCharacterListChange()
		{
			base.OnCharacterListChange();
			if (m_insideTrigger.HasPlayerInside())
			{
				Tutorial.TryShow(TutorialSettings.Order);
				switch (World.TimeController.DateElapsed.day)
				{
				case 0:
					ESteamAchievement.FIRST_DAY.Trigger();
					break;
				case 6:
					ESteamAchievement.FIRST_WEEK.Trigger();
					break;
				case 30:
					ESteamAchievement.FIRST_MONTH.Trigger();
					break;
				case 99:
					ESteamAchievement.OVER_100.Trigger();
					break;
				}
			}
		}
	}
}
