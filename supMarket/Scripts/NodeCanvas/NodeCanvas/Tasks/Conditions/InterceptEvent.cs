using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("UGUI")]
	[Description("Returns true when the selected event is triggered on the selected agent.\nYou can use this for both GUI and 3D objects.\nPlease make sure that Unity Event Systems are setup correctly")]
	public class InterceptEvent : ConditionTask<Transform>
	{
		public EventTriggerType eventType;

		protected override string info => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void OnPointerEnter(EventData<PointerEventData> data)
		{
		}

		private void OnPointerExit(EventData<PointerEventData> data)
		{
		}

		private void OnPointerDown(EventData<PointerEventData> data)
		{
		}

		private void OnPointerUp(EventData<PointerEventData> data)
		{
		}

		private void OnPointerClick(EventData<PointerEventData> data)
		{
		}

		private void OnDrag(EventData<PointerEventData> data)
		{
		}

		private void OnDrop(EventData<PointerEventData> eventData)
		{
		}

		private void OnScroll(EventData<PointerEventData> data)
		{
		}

		private void OnUpdateSelected(EventData<BaseEventData> eventData)
		{
		}

		private void OnSelect(EventData<BaseEventData> eventData)
		{
		}

		private void OnDeselect(EventData<BaseEventData> eventData)
		{
		}

		private void OnMove(EventData<AxisEventData> eventData)
		{
		}

		private void OnSubmit(EventData<BaseEventData> eventData)
		{
		}
	}
}
