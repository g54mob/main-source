using UnityEngine;

namespace CTS.BBT
{
	internal static class FurnitureEvent
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialization()
		{
			Application.quitting += OnQuit;
			FurnitureController.FurniturePickedUp += OnFurniturePickedUp;
		}

		private static void OnQuit()
		{
			Application.quitting -= OnQuit;
			FurnitureController.FurniturePickedUp -= OnFurniturePickedUp;
		}

		private static void OnFurniturePickedUp(FurnitureController p_controller)
		{
			if (p_controller.TryGetComponent<FurnitureInteractor>(out var component))
			{
				component.TriggerFurnitureBecameUnavailable();
				component.TriggerFurniturePickedUp();
			}
			if (p_controller.Furniture.Slots == null)
			{
				return;
			}
			FurnitureSlot[] slots = p_controller.Furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot.SlotedFurniture && furnitureSlot.SlotedFurniture.TryGetComponent<FurnitureInteractor>(out component))
				{
					component.TriggerFurnitureBecameUnavailable();
					component.TriggerFurniturePickedUp();
				}
			}
		}
	}
}
