using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne
{
	[RequireComponent(typeof(RectTransform))]
	public class UISelectable : UITrigger, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		[SerializeField]
		[Tooltip("When selected, the input action in the inputDescriptor list will be active")]
		private List<InputDescriptor> inputDescriptors;

		[Tooltip("Support default A to fire the button click event even if there are inputDescriptors")]
		[SerializeField]
		private bool allowTriggerSubmitWithInputDescriptors;

		[Tooltip("A gameobject that will show when selected. Only shown when in Controller mode")]
		[SerializeField]
		private GameObject selectedImage;

		[SerializeField]
		[Tooltip("Search and Add selectable to a parent Panel on Awake")]
		private bool addToPanelOnAwake;

		[SerializeField]
		[Tooltip("On Disable, tell the parent Panel to search for another valid selectable to select")]
		private bool findAnotherSelectableInPanelOnDisable;

		[SerializeField]
		[Tooltip("Set to true if you want this to be not selectable when UGUI interactable is set to false")]
		private bool blockSelectionOnInteractableFalse;

		[SerializeField]
		[Header("Components")]
		private Text _label;

		public UnityEvent OnSelected;

		public UnityEvent OnDeselected;

		public RectTransform RectTransform { get; private set; }

		public UIPanel ParentPanel { get; private set; }

		public Text Label => null;

		public bool AllowTriggerSubmitWithInputDescriptors => false;

		public bool CanBeSelected => false;

		internal IReadOnlyList<InputDescriptor> GetInputDescriptors()
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnEnable()
		{
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
		}

		protected virtual bool DeselectOnPointerExit()
		{
			return false;
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		internal override void OnReset()
		{
		}

		internal void SetParentPanel(UIPanel panel)
		{
		}

		internal bool IsSelected()
		{
			return false;
		}

		private void SetSelectedImageVisible(bool visible)
		{
		}
	}
}
