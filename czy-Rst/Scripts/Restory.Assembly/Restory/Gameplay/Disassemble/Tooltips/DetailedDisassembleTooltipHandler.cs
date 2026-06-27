using Restory.Data.Elements;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public class DetailedDisassembleTooltipHandler : IDisassembleTooltipHandler
	{
		private readonly WorkSurface workSurface;

		private readonly TooltipProjectionHighlighter projectionHighlighter;

		private readonly GameWarningService gameWarningService;

		private readonly GameWarningDatabase gameWarningDatabase;

		[Inject]
		public DetailedDisassembleTooltipHandler(WorkSurface workSurface, TooltipProjectionHighlighter projectionHighlighter, GameWarningService gameWarningService, GameWarningDatabase gameWarningDatabase)
		{
			this.workSurface = workSurface;
			this.projectionHighlighter = projectionHighlighter;
			this.gameWarningService = gameWarningService;
			this.gameWarningDatabase = gameWarningDatabase;
		}

		public void ShowDisassemblingTooltip(Device targetDevice)
		{
			for (int num = targetDevice.SortedSockets.Count - 1; num >= 0; num--)
			{
				ElementSocket elementSocket = targetDevice.SortedSockets[num];
				if ((bool)elementSocket.NestedElement)
				{
					if (!TryShowCustomDisassembleTooltip(elementSocket) && !TryShowUnscrewTooltip(elementSocket))
					{
						if (elementSocket.NestedElement is FlexibleElement flexibleElement)
						{
							ElementProjectionData projectionData = new ElementProjectionData(flexibleElement.AttachedModel.transform, Vector3.zero, flexibleElement.BehaviorSwitcher.CastCollider);
							projectionHighlighter.CreateAndHighlightProjection(projectionData, elementSocket.transform);
						}
						else
						{
							projectionHighlighter.CreateAndHighlightProjection(elementSocket.NestedElement.ProjectionData, elementSocket.transform);
						}
					}
					break;
				}
			}
		}

		public void ShowAssemblingTooltip(Device targetDevice)
		{
			foreach (ElementSocket sortedSocket in targetDevice.SortedSockets)
			{
				if ((bool)sortedSocket.NestedElement)
				{
					if (TryShowScrewTooltip(sortedSocket))
					{
						break;
					}
					continue;
				}
				if (!TryShowCustomAssembleTooltip(sortedSocket))
				{
					ElementBase prefab = sortedSocket.CompatibleElementInfo.Prefab;
					ElementProjectionData projectionData = new ElementProjectionData((prefab is FlexibleElement flexibleElement) ? flexibleElement.PlacementModel.transform : prefab.transform, Vector3.zero, prefab.BehaviorSwitcher.CastCollider);
					projectionHighlighter.CreateAndHighlightProjection(projectionData, sortedSocket.transform);
					HighlightCompatibleElementsOnSurface(sortedSocket.CompatibleElementInfo);
				}
				break;
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
				if ((bool)blocker.NestedElement && blocker.CompatibleElementInfo.Category == ElementCategory.Small)
				{
					projectionHighlighter.CreateAndHighlightProjection(blocker.NestedElement.ProjectionData, blocker.transform);
					result = true;
				}
			}
			return result;
		}

		private bool TryShowCustomDisassembleTooltip(ElementSocket socket)
		{
			if (!socket.CustomDisassembleTooltipBehavior || !socket.CustomDisassembleTooltipBehavior.IsConditionsToShowCustomTooltipMet(out var projectionData, out var projectionParent))
			{
				return false;
			}
			projectionHighlighter.CreateAndHighlightProjection(projectionData, projectionParent);
			return true;
		}

		private bool TryShowCustomAssembleTooltip(ElementSocket socket)
		{
			if (!socket.CustomAssembleTooltipBehavior || !socket.CustomAssembleTooltipBehavior.IsConditionsToShowCustomTooltipMet(out var projectionData, out var projectionParent, out var elementInfo))
			{
				return false;
			}
			HighlightCompatibleElementsOnSurface(elementInfo);
			projectionHighlighter.CreateAndHighlightProjection(projectionData, projectionParent);
			return true;
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
				if (!blocker.NestedElement && blocker.CompatibleElementInfo.Category == ElementCategory.Small && blocker.TryHighlightSmallElementProjection())
				{
					result = true;
				}
			}
			return result;
		}

		private void HighlightCompatibleElementsOnSurface(ElementInfo elementInfo)
		{
			bool flag = false;
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				if (!(placedElement.Info != elementInfo))
				{
					flag = true;
					projectionHighlighter.CreateAndHighlightProjection(placedElement.ProjectionData, placedElement.transform);
				}
			}
			if (!flag)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.AbsentCompatiblePart);
			}
		}
	}
}
