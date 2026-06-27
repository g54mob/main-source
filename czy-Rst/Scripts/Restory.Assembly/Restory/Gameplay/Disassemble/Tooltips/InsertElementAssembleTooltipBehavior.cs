using Restory.Data.Elements;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public class InsertElementAssembleTooltipBehavior : CustomAssembleTooltipBehaviorBase
	{
		[SerializeField]
		private FlipElementGroup flipElementGroup;

		[SerializeField]
		private FlipElementSocket flipElementSocket;

		[SerializeField]
		private ElementSocket insertedElementSocket;

		public override bool IsConditionsToShowCustomTooltipMet(out ElementProjectionData projectionData, out Transform projectionParent, out ElementInfo elementInfo)
		{
			projectionData = null;
			projectionParent = null;
			elementInfo = null;
			if ((bool)insertedElementSocket.NestedElement)
			{
				return false;
			}
			if (!flipElementSocket.NestedElement)
			{
				ElementBase prefab = flipElementSocket.CompatibleElementInfo.Prefab;
				projectionData = new ElementProjectionData(prefab.transform, Vector3.zero, prefab.BehaviorSwitcher.CastCollider);
				projectionParent = flipElementSocket.transform;
				elementInfo = flipElementSocket.CompatibleElementInfo;
				return true;
			}
			if (flipElementGroup.IsOpen)
			{
				return false;
			}
			ElementBase prefab2 = insertedElementSocket.CompatibleElementInfo.Prefab;
			projectionData = new ElementProjectionData(prefab2.transform, Vector3.zero, prefab2.BehaviorSwitcher.CastCollider);
			projectionParent = insertedElementSocket.transform;
			elementInfo = insertedElementSocket.CompatibleElementInfo;
			return true;
		}
	}
}
