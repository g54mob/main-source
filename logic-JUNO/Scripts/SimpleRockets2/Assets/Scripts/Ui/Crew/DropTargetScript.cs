using System;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Crew
{
	public class DropTargetScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private XmlElement _element;

		private bool _selected;

		public CrewItem CrewItem { get; set; }

		public CrewAssignmentDialogScript Dialog { get; set; }

		public Action<CrewItem> OnDragEnd { get; set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				if (value)
				{
					_element.AddClass("drop-target");
				}
				else
				{
					_element.RemoveClass("drop-target");
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (Dialog.IsDragging)
			{
				Dialog.EnterDropTarget(this, eventData);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (Dialog.IsDragging)
			{
				Dialog.ExitDropTarget(this);
			}
		}

		private void Start()
		{
			_element = GetComponent<XmlElement>();
		}
	}
}
