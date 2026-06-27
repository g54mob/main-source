using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public class RemoveInsertedElementDisassembleTooltipBehavior : CustomDisassembleTooltipBehaviorBase
	{
		[SerializeField]
		private FlipElementGroup flipElementGroup;

		[SerializeField]
		private FlipElementSocket flipElementSocket;

		[SerializeField]
		private ElementSocket insertedElementSocket;

		public override bool IsConditionsToShowCustomTooltipMet(out ElementProjectionData projectionData, out Transform projectionParent)
		{
			projectionData = null;
			projectionParent = null;
			if (!insertedElementSocket.NestedElement)
			{
				return false;
			}
			if (flipElementGroup.IsOpen)
			{
				projectionData = insertedElementSocket.NestedElement.ProjectionData;
				projectionParent = insertedElementSocket.transform;
				return true;
			}
			projectionData = flipElementSocket.NestedElement.ProjectionData;
			projectionParent = flipElementSocket.transform;
			return true;
		}
	}
}
