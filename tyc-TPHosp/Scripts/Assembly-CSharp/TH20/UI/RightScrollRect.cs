using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	public class RightScrollRect : ScrollRect
	{
		[SerializeField]
		private bool _useLeftAlso = true;

		public override void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				if (!_useLeftAlso)
				{
					base.OnBeginDrag(eventData);
				}
			}
			if (_useLeftAlso)
			{
				base.OnBeginDrag(eventData);
			}
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				if (!_useLeftAlso)
				{
					base.OnEndDrag(eventData);
				}
			}
			if (_useLeftAlso)
			{
				base.OnEndDrag(eventData);
			}
		}

		public override void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				if (!_useLeftAlso)
				{
					base.OnDrag(eventData);
				}
			}
			if (_useLeftAlso)
			{
				base.OnDrag(eventData);
			}
		}
	}
}
