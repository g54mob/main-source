using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class ToggleDV : Toggle, IClickable, IHoverable
	{
		private ClickableEvents events;

		public new bool IsInteractable => IsInteractable();

		public bool IsHovered { get; protected set; }

		public bool IsMouseOvered { get; protected set; }

		public new bool IsPressed => IsPressed();

		public event ClickDelegate Clicked;

		public event PressChangedDelegate PressChanged;

		public event HoverChangedDelegate HoverChanged;

		public event HoverChangedDelegate MouseOverChanged;

		public event InteractabilityChangedDelegate InteractabilityChanged;

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		public void ToggleInteractable(bool newInteractable)
		{
			base.interactable = newInteractable;
			if (!base.interactable)
			{
				IsHovered = false;
			}
			events?.FireEventsIfNeeded();
		}

		public void Hover()
		{
			IsHovered = IsInteractable;
			IsMouseOvered = true;
			events?.FireEventsIfNeeded();
		}

		public void Unhover()
		{
			IsHovered = false;
			IsMouseOvered = false;
			events?.FireEventsIfNeeded();
		}

		public void Click()
		{
			OnPointerClick(null);
		}

		public void Press()
		{
			events?.FireEventsIfNeeded();
		}

		public void Release()
		{
			events?.FireEventsIfNeeded();
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			events?.Click();
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			Hover();
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			Unhover();
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			Press();
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			Release();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Unhover();
		}

		protected override void Awake()
		{
			base.Awake();
			events = new ClickableEvents(this, delegate
			{
				this.Clicked?.Invoke(this);
			}, delegate
			{
				this.PressChanged?.Invoke(this);
			}, delegate
			{
				this.HoverChanged?.Invoke(this);
			}, delegate
			{
				this.MouseOverChanged?.Invoke(this);
			}, delegate
			{
				this.InteractabilityChanged?.Invoke(this);
			});
		}
	}
}
