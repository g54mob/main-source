using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Disassemble.Tooltips
{
	public abstract class CustomDisassembleTooltipBehaviorBase : MonoBehaviour
	{
		public abstract bool IsConditionsToShowCustomTooltipMet(out ElementProjectionData projectionData, out Transform projectionParent);
	}
}
