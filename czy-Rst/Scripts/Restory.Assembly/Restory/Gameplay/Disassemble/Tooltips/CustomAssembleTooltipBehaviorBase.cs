using Restory.Data.Elements;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public abstract class CustomAssembleTooltipBehaviorBase : MonoBehaviour
	{
		public abstract bool IsConditionsToShowCustomTooltipMet(out ElementProjectionData projectionData, out Transform projectionParent, out ElementInfo elementInfo);
	}
}
