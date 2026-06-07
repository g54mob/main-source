using UnityEngine;

namespace DV.Interaction
{
	public interface IItemPlacerHandler
	{
		void InitializePlacement();

		void UpdatePlacement();

		(bool success, GameObject placedItem, GameObject targetContainer) FinalizePlacement();

		void CancelPlacement();
	}
}
