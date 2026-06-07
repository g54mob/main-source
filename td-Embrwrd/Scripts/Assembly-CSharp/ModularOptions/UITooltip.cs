using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModularOptions
{
	[RequireComponent(typeof(Selectable))]
	[AddComponentMenu("Modular Options/Tooltip")]
	public class UITooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		public enum RelativePosition
		{
			left = 0,
			right = 1,
			bottom = 2,
			top = 3
		}

		public GameObject tooltip;

		[Tooltip("Direction relative to this object in which to show Tooltip.")]
		public RelativePosition relativePosition;

		[Tooltip("Optional offset for Tooltip position.")]
		public Vector3 offset;

		private RectTransform ttTrans;

		private RectTransform rTrans;

		private readonly Vector2 middleLeftPivot;

		private readonly Vector2 middleRightPivot;

		private readonly Vector2 bottomCenterPivot;

		private readonly Vector2 topCenterPivot;

		private void Awake()
		{
		}

		public void OnPointerEnter(PointerEventData _eventData)
		{
		}

		public void OnPointerExit(PointerEventData _eventData)
		{
		}

		public void OnSelect(BaseEventData _eventData)
		{
		}

		public void OnDeselect(BaseEventData _eventData)
		{
		}

		private void EnterOrSelect()
		{
		}
	}
}
