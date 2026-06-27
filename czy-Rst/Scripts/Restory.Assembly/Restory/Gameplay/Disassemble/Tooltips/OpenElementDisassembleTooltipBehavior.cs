using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public class OpenElementDisassembleTooltipBehavior : CustomDisassembleTooltipBehaviorBase
	{
		[SerializeField]
		private FlipElementGroup flipElementGroup;

		[SerializeField]
		private ElementSocket openElementSocket;

		public override bool IsConditionsToShowCustomTooltipMet(out ElementProjectionData projectionData, out Transform projectionParent)
		{
			projectionData = null;
			projectionParent = null;
			if (flipElementGroup.IsOpen)
			{
				return false;
			}
			if (!openElementSocket.NestedElement)
			{
				Debug.LogError("Nested element is lost in openElementSocket");
				return false;
			}
			projectionData = openElementSocket.NestedElement.ProjectionData;
			projectionParent = openElementSocket.transform;
			return true;
		}
	}
}
