using System;
using AssembleSystem;
using Items;
using Zenject;

namespace Player.TutorialHelpers
{
	public class PlayerEquiperTutorialHelper : BaseTutorialHelper
	{
		[Inject]
		private IInventoryService _inventoryService;

		private void OnEnable()
		{
			IInventoryService inventoryService = _inventoryService;
			inventoryService.OnItemPicked = (Action<IInventoryManagable>)Delegate.Combine(inventoryService.OnItemPicked, new Action<IInventoryManagable>(CheckForItemPicked));
		}

		private void CheckForItemPicked(IInventoryManagable managable)
		{
			if (managable is EquipableToolItem equipableToolItem && equipableToolItem.ToolObject.ToolType == ProgressToolType.Screw)
			{
				EmitStep("findScrewdriver");
			}
		}
	}
}
