using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace STMTools.Links
{
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Image))]
	public class LinkObjectUI : LinkObject, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		private RectTransform tr;

		private Image image;

		internal override void Initialize(CharInfo charInfo, LinkController controller, string name, Link link, UnityEvent onEnter, UnityEvent onExit)
		{
			t = base.transform;
			t.SetParent(controller.superTextMesh.t);
			go = base.gameObject;
			tr = t.GetComponent<RectTransform>();
			onClick = link.onClick;
			base.onEnter = onEnter;
			base.onExit = onExit;
			t.name = name;
			image = t.GetComponent<Image>();
			image.color = Color.clear;
			bounds = new Bounds(charInfo.bounds.center, charInfo.bounds.size);
			base.controller = controller;
			SetBoundingBox();
			Encapsulate(charInfo);
		}

		private void SetBoundingBox()
		{
			t.localPosition = bounds.min + bounds.size / 2f;
			tr.sizeDelta = bounds.size;
		}

		internal override void Encapsulate(CharInfo charInfo)
		{
			bounds.Encapsulate(charInfo.bounds);
			SetBoundingBox();
			linkIndex = charInfo.linkIndex;
			lastCharacterIndex = charInfo.charIndex;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			OnClick();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			OnEnter();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			OnExit();
		}
	}
}
