using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public class OpenElementUsingButtonDisassembleTooltipBehavior : CustomDisassembleTooltipBehaviorBase
	{
		[SerializeField]
		private FlipElementGroup flipElementGroup;

		[SerializeField]
		private ElementSocket openTriggerSocket;

		public override bool IsConditionsToShowCustomTooltipMet(out ElementProjectionData projectionData, out Transform projectionParent)
		{
			projectionData = null;
			projectionParent = null;
			if (flipElementGroup.IsOpen)
			{
				return false;
			}
			if (!openTriggerSocket.NestedElement)
			{
				Debug.LogError("Nested element is lost in openTriggerSocket");
				return false;
			}
			ElementButton componentInChildren = openTriggerSocket.NestedElement.GetComponentInChildren<ElementButton>();
			if (!componentInChildren)
			{
				Debug.LogError("ElementButton is lost on " + openTriggerSocket.NestedElement.Info.ID);
				return false;
			}
			projectionData = new ElementProjectionData(componentInChildren.transform, Vector3.zero, componentInChildren.Collider);
			projectionParent = componentInChildren.transform;
			return true;
		}
	}
}
