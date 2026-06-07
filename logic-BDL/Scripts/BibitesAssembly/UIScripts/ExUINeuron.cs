using System;
using SettingScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
	public class ExUINeuron : UINeuron, IPointerClickHandler, IEventSystemHandler, IEndDragHandler
	{
		[NonSerialized]
		public NodeType type;

		[NonSerialized]
		public int rank;

		[NonSerialized]
		public Vector2 velocity = new Vector3(0f, 0f);

		[NonSerialized]
		public Vector2 hiddenPosition = new Vector3(0f, 0f);

		[NonSerialized]
		public bool beingDragged;

		public void Start()
		{
			Initialize();
			hiddenPosition = base.transform.localPosition;
		}

		public void SetType(NodeType _type)
		{
			type = _type;
		}

		public override void SetAlphaLow(bool val)
		{
			base.SetAlphaLow(val);
			if (val)
			{
				activationValue.gameObject.SetActive(value: false);
			}
		}

		public void Accelerate(Vector2 acceleration)
		{
			if (!beingDragged)
			{
				velocity += acceleration * Time.unscaledDeltaTime;
			}
		}

		public void Move(float friction, bool moveHiddenPos = false)
		{
			if (!beingDragged)
			{
				if (!moveHiddenPos)
				{
					base.transform.position += (Vector3)velocity * Time.unscaledDeltaTime;
				}
				else
				{
					hiddenPosition += velocity * Time.unscaledDeltaTime;
				}
				velocity *= 1f - friction * Time.unscaledDeltaTime;
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			if (!hidden)
			{
				activationValue.gameObject.SetActive(value: true);
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			activationValue.gameObject.SetActive(value: false);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!beingDragged && eventData.button == PointerEventData.InputButton.Left)
			{
				ExpandedBrainPanel.Instance.BFS(index);
			}
		}

		public override void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				beingDragged = true;
				Vector2 vector = cam.WorldToScreenPoint(parentRectTransform.position);
				Vector2 vector2 = (eventData.position - vector) / UserSettings.totalUIScale / ExpandedBrainPanel.Instance.currentScale;
				float x = Mathf.Max(Mathf.Min(vector2.x, parentRectTransform.rect.width), 0f);
				float y = Mathf.Max(Mathf.Min(vector2.y, 0f), 0f - parentRectTransform.rect.height);
				base.transform.localPosition = new Vector3(x, y, 0f);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			beingDragged = false;
		}
	}
}
