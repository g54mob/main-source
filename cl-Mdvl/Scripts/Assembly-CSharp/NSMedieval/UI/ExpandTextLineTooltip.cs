using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(TMP_Text))]
	public class ExpandTextLineTooltip : TooltipViewNew
	{
		private TMP_Text textComponent;

		private void Start()
		{
			textComponent = GetComponent<TMP_Text>();
			textComponent.raycastTarget = true;
		}

		protected override List<string> GetLinesToShow()
		{
			bool flag;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(60, 3, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\View\\UI\\Tooltip\\ExpandTextLineTooltip.cs");
			if (flag)
			{
				messageBuilder.AppendLiteral("GetLinesToShow() called for ");
				messageBuilder.AppendFormatted(textComponent.text);
				messageBuilder.AppendLiteral(" overflow mode:");
				messageBuilder.AppendFormatted(textComponent.overflowMode);
				messageBuilder.AppendLiteral(" isOverflowing: ");
				messageBuilder.AppendFormatted(textComponent.isTextOverflowing);
				messageBuilder.AppendLiteral(" ");
			}
			Log.Trace(messageBuilder);
			ClearLines();
			if ((bool)textComponent && textComponent.overflowMode == TextOverflowModes.Ellipsis && textComponent.isTextOverflowing)
			{
				AppendLine(textComponent.text);
			}
			return base.GetLinesToShow();
		}
	}
}
