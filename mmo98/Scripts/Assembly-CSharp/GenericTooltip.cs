using UnityEngine;
using UnityEngine.EventSystems;

public class GenericTooltip : MonoBehaviour, ITooltip, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[field: SerializeField]
	public Tooltip Tooltip { get; private set; }
}
