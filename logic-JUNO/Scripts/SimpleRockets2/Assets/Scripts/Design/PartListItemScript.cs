using ModApi.Common.Extensions;
using ModApi.Craft.Parts;
using ModApi.Settings;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class PartListItemScript : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
	{
		private bool _draggingPart;

		private Image _iconImage;

		private MouseInputSettingsDesigner _mouseInputSettings;

		private Vector2 _scrollDelta;

		public DesignerPart DesignerPart { get; set; }

		public Sprite IconSprite
		{
			get
			{
				return _iconImage.sprite;
			}
			set
			{
				_iconImage.sprite = value;
			}
		}

		public PartListPanelScript PartList { get; set; }

		public void OnBeginDrag(PointerEventData eventData)
		{
			_scrollDelta = Vector2.zero;
			_draggingPart = false;
			ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.beginDragHandler);
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!_draggingPart)
			{
				if (eventData.IsTouchPrimary() || _mouseInputSettings.CanSelectPart(eventData.InputButton()))
				{
					_scrollDelta += eventData.delta;
					if (_scrollDelta.x - Mathf.Abs(_scrollDelta.y * 0.75f) > 50f)
					{
						_draggingPart = true;
						PartList.AddPart(this, eventData);
						ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
					}
				}
			}
			else
			{
				PartList.MovePart(eventData);
			}
			if (!_draggingPart)
			{
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.dragHandler);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (_draggingPart)
			{
				PartList.FinishedAddingPart(eventData);
			}
			else
			{
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			PartList.HoveredPartItem = this;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			PartList.HoveredPartItem = null;
		}

		private void Awake()
		{
			_iconImage = GetComponent<XmlElement>().GetElementByInternalId<Image>("icon");
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}
	}
}
