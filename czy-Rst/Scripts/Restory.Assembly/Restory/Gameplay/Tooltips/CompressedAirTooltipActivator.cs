using Restory.Data.Equipment;
using Restory.Gameplay.Common;
using Restory.Gameplay.Equipment;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.Gameplay.Tooltips
{
	public class CompressedAirTooltipActivator : TooltipActivatorBase, ITooltipActivatorWithCondition, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private ToolInfo toolInfo;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		private AvailableToolsTrackingService availableToolsTrackingService;

		public ToolInfo ToolInfo => toolInfo;

		public int Count => availableToolsTrackingService.GetToolCount(toolInfo);

		[Inject]
		private void Construct(AvailableToolsTrackingService availableToolsTrackingService)
		{
			this.availableToolsTrackingService = availableToolsTrackingService;
		}

		public bool ShouldTooltipBeShown()
		{
			return availableToolsTrackingService.GetToolCount(toolInfo) > 0;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			outlinableAdapter.IsActive = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			outlinableAdapter.IsActive = false;
		}
	}
}
