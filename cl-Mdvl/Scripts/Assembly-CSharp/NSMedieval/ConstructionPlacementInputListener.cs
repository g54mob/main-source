using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using UnityEngine;

namespace NSMedieval
{
	public class ConstructionPlacementInputListener : InputListener
	{
		private const float MouseDownThreshold = 0.2f;

		private bool blockPropagation;

		private Vector3 dragStartPosition;

		private bool isDragging;

		private float rightMouseDown;

		private bool RightMouseDown => rightMouseDown > 0.2f;

		public ConstructionPlacementInputListener()
			: base(InputListenerType.ConstructionPlacement)
		{
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			blockPropagation = false;
			if (button == 0)
			{
				isDragging = true;
				dragStartPosition = position;
			}
			MonoSingleton<BuildingPlacementManager>.Instance.MouseEventDown(button, position);
			if (MonoSingleton<BuildingPlacementManager>.Instance.HasSelectedItem && !MonoSingleton<BuildingPlacementManager>.Instance.HasSelectedItem)
			{
				blockPropagation = true;
			}
			base.MouseButtonDown(button, position);
		}

		public override void MouseButtonTick(int button, Vector3 position)
		{
			if (button == 1)
			{
				rightMouseDown += Time.unscaledDeltaTime;
				bool flag;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Input\\ConstructionPlacementInputListener.cs");
				if (flag)
				{
					messageBuilder.AppendLiteral("Mouse down: ");
					messageBuilder.AppendFormatted(rightMouseDown);
				}
				Log.Debug(messageBuilder);
			}
			if (isDragging && (position - dragStartPosition).magnitude > 2f)
			{
				MonoSingleton<BuildingPlacementManager>.Instance.OnLeftMouseDrag();
				dragStartPosition = position;
			}
			base.MouseButtonTick(button, position);
		}

		public override void MouseButtonUp(int button, Vector3 position)
		{
			switch (button)
			{
			case 0:
				isDragging = false;
				MonoSingleton<BuildingPlacementManager>.Instance.OnLeftMouseUp();
				break;
			case 1:
				if (RightMouseDown)
				{
					bool flag;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(26, 2, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Input\\ConstructionPlacementInputListener.cs");
					if (flag)
					{
						messageBuilder.AppendLiteral("Right Mouse was down: ");
						messageBuilder.AppendFormatted(rightMouseDown);
						messageBuilder.AppendLiteral(" > ");
						messageBuilder.AppendFormatted(0.2f);
						messageBuilder.AppendLiteral(" ");
					}
					Log.Debug(messageBuilder);
				}
				else
				{
					MonoSingleton<BuildingPlacementManager>.Instance.OnRightMouseUp();
				}
				break;
			}
			if (blockPropagation)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					blockPropagation = false;
				});
			}
			rightMouseDown = 0f;
			base.MouseButtonUp(button, position);
		}

		public override bool IsStopEventPropagation()
		{
			if (!blockPropagation)
			{
				return MonoSingleton<BuildingPlacementManager>.Instance.HasSelectedItem;
			}
			return true;
		}
	}
}
