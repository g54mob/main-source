using System;
using Restory.Data.Elements;
using Restory.Gameplay.Elements;
using Zenject;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public class SmallElementTooltipHandler : IInitializable, IDisposable
	{
		private readonly DragElementRegistrator dragElementRegistrator;

		private readonly TooltipProjectionHighlighter tooltipProjectionHighlighter;

		private ElementSocket detachedSocket;

		[Inject]
		public SmallElementTooltipHandler(DragElementRegistrator dragElementRegistrator, TooltipProjectionHighlighter tooltipProjectionHighlighter)
		{
			this.dragElementRegistrator = dragElementRegistrator;
			this.tooltipProjectionHighlighter = tooltipProjectionHighlighter;
		}

		public void Initialize()
		{
			dragElementRegistrator.OnElementStopDrag += ResolveElementStopDrag;
		}

		public void Dispose()
		{
			dragElementRegistrator.OnElementStopDrag -= ResolveElementStopDrag;
		}

		public void OnSocketChanged(ElementSocket changedSocket)
		{
			detachedSocket = null;
			if (!changedSocket.NestedElement && changedSocket.CompatibleElementInfo.Category != ElementCategory.Small)
			{
				detachedSocket = changedSocket;
			}
		}

		private void ResolveElementStopDrag()
		{
			HandleBlockedSockets();
			detachedSocket = null;
		}

		private void HandleBlockedSockets()
		{
			if (!detachedSocket)
			{
				return;
			}
			foreach (ElementSocket blockedSocket in detachedSocket.BlockedSockets)
			{
				if ((bool)blockedSocket.NestedElement && blockedSocket.CompatibleElementInfo.Category != ElementCategory.Small && IsSmallElementsBlockingSocket(blockedSocket))
				{
					HighlightSmallElementsBlockingSocket(blockedSocket);
				}
			}
		}

		private bool IsSmallElementsBlockingSocket(ElementSocket socket)
		{
			bool result = false;
			foreach (ElementSocket blocker in socket.Blockers)
			{
				if ((bool)blocker.NestedElement)
				{
					if (blocker.CompatibleElementInfo.Category != ElementCategory.Small)
					{
						return false;
					}
					result = true;
				}
			}
			return result;
		}

		private void HighlightSmallElementsBlockingSocket(ElementSocket socket)
		{
			foreach (ElementSocket blocker in socket.Blockers)
			{
				if ((bool)blocker.NestedElement && blocker.NestedElement.Info.Category == ElementCategory.Small)
				{
					tooltipProjectionHighlighter.CreateAndHighlightProjection(blocker.NestedElement.ProjectionData, blocker.transform);
				}
			}
		}
	}
}
