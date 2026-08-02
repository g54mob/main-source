using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class TooltipArea : Hover, IPointerEnterHandler, IEventSystemHandler, IPointerMoveHandler, IPointerExitHandler
	{
		[TextArea]
		public string message;

		public TooltipManager manager => null;

		private void Update()
		{
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
		}

		public override void OnPointerMove(PointerEventData eventData)
		{
		}

		private void OnDisable()
		{
		}
	}
}
