using UnityEngine;
using UnityEngine.EventSystems;

namespace Simulator
{
	public interface ITooltipDisplayer : IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		RectTransform RectTransform { get; }

		bool TryGetTooltipTerm(out string tooltipTerm);
	}
}
