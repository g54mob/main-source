using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.State;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Crew
{
	public class CrewItem : IDraggableItem
	{
		private bool _canDrag;

		private DragHandlerScript _dragHandler;

		public bool CanDrag
		{
			get
			{
				if (_canDrag)
				{
					return !Dialog.IsDragging;
				}
				return false;
			}
		}

		public CompartmentTarget Compartment { get; set; }

		public CrewMember Crew { get; set; }

		public string CrewName { get; }

		public CrewAssignmentDialogScript Dialog { get; private set; }

		public GameObject DragElement => Element.gameObject;

		public Transform DragParent => Dialog.DragParent;

		public XmlElement Element { get; }

		public bool IsEmpty => Crew == null;

		public EvaData OriginalEva { get; set; }

		public bool ShowReadyForDragIndication { get; set; }

		public bool Visible
		{
			get
			{
				return Element.gameObject.activeSelf;
			}
			set
			{
				Element.gameObject.SetActive(value);
			}
		}

		public CrewItem(XmlElement element, CrewMember crew, CrewAssignmentDialogScript dialog)
		{
			Element = element;
			Crew = crew;
			CrewName = Crew?.Name ?? OriginalEva?.Name;
			if (string.IsNullOrWhiteSpace(CrewName))
			{
				CrewName = "Unassigned";
			}
			Dialog = dialog;
			_canDrag = true;
			if (_canDrag)
			{
				_dragHandler = element.gameObject.AddComponent<DragHandlerScript>();
				_dragHandler.Item = this;
				_dragHandler.WaitForDelayedDrag = false;
				_dragHandler.UseHorizontalDragToStart = true;
			}
			else
			{
				Element.AddClass("disabled");
			}
			RefreshUI();
		}

		public void EnableHighlight()
		{
			Element.AddClass("highlighted");
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			Dialog.StartDragging(this);
		}

		public void OnDrag(PointerEventData eventData)
		{
			Dialog.Dragging();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			Dialog.EndDrag();
		}

		public void RefreshUI()
		{
			Element.GetElementByInternalId<TextMeshProUGUI>("name").text = CrewName;
			if (Crew != null)
			{
				if (Crew.State == CrewMemberState.InFlight)
				{
					Element.GetElementByInternalId<TextMeshProUGUI>("status").text = "In Flight: " + Crew.Location;
				}
				else
				{
					Element.GetElementByInternalId<TextMeshProUGUI>("status").text = Crew.State.ToString();
				}
			}
		}
	}
}
