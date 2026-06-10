using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Components;
using NSMedieval.Managers.Selection;
using UnityEngine;

namespace NSMedieval
{
	public sealed class SelectionInputListener : InputListener
	{
		private const float MouseDownThreshold = 0.2f;

		private int blockPropagation;

		private float rightMouseDown;

		private bool wasSelecting;

		private bool RightMouseDown => rightMouseDown > 0.2f;

		public SelectionInputListener()
			: base(InputListenerType.Selection)
		{
		}

		public override void Update()
		{
			if (blockPropagation > 0)
			{
				blockPropagation--;
			}
			base.Update();
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			if (button == 0)
			{
				MonoSingleton<SelectionManager>.Instance.OnMouseDown();
			}
			if (MonoSingleton<SelectionManager>.Instance.CanSelect)
			{
				wasSelecting = true;
			}
			base.MouseButtonDown(button, position);
		}

		public override void MouseButtonTick(int button, Vector3 position)
		{
			if (button == 1)
			{
				rightMouseDown += Time.unscaledDeltaTime;
				bool flag;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 1, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Input\\SelectionInputListener.cs");
				if (flag)
				{
					messageBuilder.AppendLiteral("Mouse down: ");
					messageBuilder.AppendFormatted(rightMouseDown);
				}
				Log.Trace(messageBuilder);
			}
			MonoSingleton<SelectionManager>.Instance.OnMouseTick(Time.deltaTime);
			base.MouseButtonTick(button, position);
		}

		public override void MouseButtonUp(int button, Vector3 position)
		{
			blockPropagation = (MonoSingleton<SelectionManager>.Instance.Selecting ? 3 : 0);
			switch (button)
			{
			case 0:
				MonoSingleton<SelectionManager>.Instance.OnMouseUp();
				break;
			case 1:
				if (RightMouseDown)
				{
					bool flag;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(26, 2, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\Input\\SelectionInputListener.cs");
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
					MonoSingleton<SelectionManager>.Instance.OnRightMouseUp();
					if (wasSelecting)
					{
						blockPropagation++;
						wasSelecting = false;
					}
				}
				break;
			}
			rightMouseDown = 0f;
			base.MouseButtonUp(button, position);
		}

		public override bool IsStopEventPropagation()
		{
			if (!MonoSingleton<SelectionManager>.Instance.Selecting)
			{
				return blockPropagation > 0;
			}
			return true;
		}
	}
}
