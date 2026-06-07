using UnityEngine;
using UnityEngine.UI;

namespace ModelShark
{
	public static class TooltipExtensions
	{
		public static void SetPosition(this Tooltip tooltip, TooltipTrigger trigger, Canvas canvas, Camera camera)
		{
		}

		private static void SetPosition(this Tooltip tooltip, TipPosition tipPosition, TooltipStyle style, Vector3[] triggerCorners, Image bkgImage, RectTransform tooltipRectTrans, Canvas canvas, Camera camera)
		{
		}
	}
}
