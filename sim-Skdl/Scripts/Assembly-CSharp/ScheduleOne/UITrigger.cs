using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne
{
	[RequireComponent(typeof(Selectable))]
	public class UITrigger : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler
	{
		public enum TriggerType
		{
			Press = 0,
			Hold = 1
		}

		[SerializeField]
		private TriggerType triggerType;

		[Tooltip("Set to true if you want Mouse to be always Press")]
		[SerializeField]
		private bool mouseAlwaysPress;

		[SerializeField]
		[Tooltip("Duration in seconds to hold for Hold trigger")]
		private float holdDuration;

		[SerializeField]
		[Tooltip("Optional UI image to show hold progress (should be Image Type: Filled)")]
		private Image holdImage;

		[SerializeField]
		[Tooltip("Optional UGUI Selectable. If assigned, the uiTrigger interactable will also check for the UGUI Selectable interactable property.")]
		private Selectable uGUISelectable;

		[Tooltip("Event triggered when the action is performed")]
		public UnityEvent OnTrigger;

		private bool isHolding;

		private float holdTime;

		private bool isHoldStarted;

		private bool interactable;

		public bool Interactable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Image HoldImage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal TriggerType GetTriggerType()
		{
			return default(TriggerType);
		}

		protected virtual void Awake()
		{
		}

		private bool IsInteractable()
		{
			return false;
		}

		private void Update()
		{
		}

		internal virtual void OnReset()
		{
		}

		internal virtual void DetectTriggerInput(InputActionReference inputAction)
		{
		}

		internal void OnInputDown()
		{
		}

		internal void OnInputUp()
		{
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		private void HandleHoldStart()
		{
		}

		private void HandleHoldEnd()
		{
		}

		private void UpdateHoldImage(float amount)
		{
		}
	}
}
