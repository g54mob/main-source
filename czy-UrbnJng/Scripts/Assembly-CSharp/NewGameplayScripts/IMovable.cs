using UnityEngine;

namespace NewGameplayScripts
{
	public interface IMovable
	{
		string MoveId { get; }

		string itemGUID { get; set; }

		int itemLevelNumber { get; set; }

		Transform transform { get; }

		bool isWorkingItem { get; set; }

		bool isWorking { get; set; }

		bool secondProjectorOn { get; set; }

		bool trashInCan { get; set; }

		void StartMoving();

		void StopMoving();

		bool CheckIfCanPlace();

		void ToggleOutline(bool value);

		void SwitchMovement(bool turnOn);

		void RightClickAction();

		string PassThroughItem();
	}
}
