using UnityEngine;
using UnityEngine.Events;

namespace STMTools.Links
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class LinkCollider2D : LinkObject
	{
		private BoxCollider2D box;

		internal override void Initialize(CharInfo charInfo, LinkController controller, string name, Link link, UnityEvent onEnter, UnityEvent onExit)
		{
			t = base.transform;
			go = base.gameObject;
			onClick = link.onClick;
			base.onEnter = onEnter;
			base.onExit = onExit;
			t.parent = controller.superTextMesh.t;
			t.name = name;
			box = t.GetComponent<BoxCollider2D>();
			bounds = new Bounds(charInfo.bounds.center, charInfo.bounds.size);
			base.controller = controller;
			SetBoundingBox();
			Encapsulate(charInfo);
		}

		private void SetBoundingBox()
		{
			t.localPosition = bounds.min;
			box.size = bounds.size;
			box.offset = box.size / 2f;
		}

		internal override void Encapsulate(CharInfo charInfo)
		{
			bounds.Encapsulate(charInfo.bounds);
			SetBoundingBox();
			linkIndex = charInfo.linkIndex;
			lastCharacterIndex = charInfo.charIndex;
		}

		private void OnMouseDown()
		{
			OnClick();
		}

		private void OnMouseEnter()
		{
			OnEnter();
		}

		private void OnMouseExit()
		{
			OnExit();
		}
	}
}
