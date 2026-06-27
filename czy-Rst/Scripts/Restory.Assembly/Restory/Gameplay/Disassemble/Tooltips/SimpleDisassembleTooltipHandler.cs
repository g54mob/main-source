using Restory.Data.Elements;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public class SimpleDisassembleTooltipHandler : IDisassembleTooltipHandler
	{
		private readonly TooltipProjectionHighlighter projectionHighlighter;

		[Inject]
		public SimpleDisassembleTooltipHandler(TooltipProjectionHighlighter projectionHighlighter)
		{
			this.projectionHighlighter = projectionHighlighter;
		}

		public void ShowDisassemblingTooltip(Device targetDevice)
		{
			for (int num = targetDevice.SortedSockets.Count - 1; num >= 0; num--)
			{
				ElementSocket elementSocket = targetDevice.SortedSockets[num];
				if ((bool)elementSocket.NestedElement && (((bool)elementSocket.CustomDisassembleTooltipBehavior && elementSocket.CustomDisassembleTooltipBehavior.IsConditionsToShowCustomTooltipMet(out var _, out var _)) || TryShowUnscrewTooltip(elementSocket)))
				{
					break;
				}
			}
		}

		public void ShowAssemblingTooltip(Device targetDevice)
		{
			foreach (ElementSocket sortedSocket in targetDevice.SortedSockets)
			{
				if ((bool)sortedSocket.NestedElement && TryShowScrewTooltip(sortedSocket))
				{
					break;
				}
			}
		}

		private bool TryShowUnscrewTooltip(ElementSocket socket)
		{
			if (!socket.IsBlocked)
			{
				return false;
			}
			bool result = false;
			foreach (ElementSocket blocker in socket.Blockers)
			{
				if (blocker.CompatibleElementInfo.Category == ElementCategory.Small && (bool)blocker.NestedElement && !blocker.IsBlocked)
				{
					projectionHighlighter.CreateAndHighlightProjection(blocker.NestedElement.ProjectionData, blocker.transform);
					result = true;
				}
			}
			return result;
		}

		private bool TryShowScrewTooltip(ElementSocket socket)
		{
			if (socket.Blockers.Count == 0)
			{
				return false;
			}
			bool result = false;
			foreach (ElementSocket blocker in socket.Blockers)
			{
				if (blocker.CompatibleElementInfo.Category == ElementCategory.Small && !blocker.NestedElement)
				{
					if (!blocker.LastNestedElement)
					{
						Debug.LogError("Empty small element socket is not coupled");
						continue;
					}
					projectionHighlighter.CreateAndHighlightProjection(blocker.LastNestedElement.ProjectionData, blocker.transform);
					result = true;
				}
			}
			return result;
		}
	}
}
