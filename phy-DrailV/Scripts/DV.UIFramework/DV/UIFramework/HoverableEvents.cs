using System;
using UnityEngine;

namespace DV.UIFramework
{
	public class HoverableEvents
	{
		private readonly IHoverable hoverable;

		protected bool wasHovered;

		protected bool wasMouseOvered;

		protected bool wasInteractable;

		private Action HoverChanged;

		private Action MouseOverChanged;

		private Action InteractabilityChanged;

		protected bool reentrancyGuard;

		public HoverableEvents(IHoverable hoverable, Action hoverChanged, Action mouseOverChanged, Action interactabilityChanged)
		{
			if (Application.isPlaying)
			{
				this.hoverable = hoverable;
				wasHovered = hoverable.IsHovered;
				wasMouseOvered = hoverable.IsMouseOvered;
				wasInteractable = hoverable.IsInteractable;
				HoverChanged = hoverChanged;
				MouseOverChanged = mouseOverChanged;
				InteractabilityChanged = interactabilityChanged;
				GameObject gameObject = hoverable.GetGameObject();
				if (gameObject.GetComponent<UISoundEffects>() == null)
				{
					gameObject.AddComponent<UISoundEffects>();
				}
				if (gameObject.GetComponent<HoverEffect>() == null)
				{
					gameObject.AddComponent<HoverEffect>();
				}
				if (gameObject.GetComponent<InteractableEffect>() == null)
				{
					gameObject.AddComponent<InteractableEffect>();
				}
			}
		}

		public virtual void FireEventsIfNeeded()
		{
			if (!Application.isPlaying || reentrancyGuard)
			{
				return;
			}
			reentrancyGuard = true;
			bool isInteractable = hoverable.IsInteractable;
			bool isHovered = hoverable.IsHovered;
			bool isMouseOvered = hoverable.IsMouseOvered;
			if (isMouseOvered != wasMouseOvered)
			{
				try
				{
					MouseOverChanged?.Invoke();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			if ((!isInteractable && wasHovered) || (isInteractable && wasHovered != isHovered))
			{
				try
				{
					HoverChanged?.Invoke();
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
			}
			if (wasInteractable != isInteractable)
			{
				try
				{
					InteractabilityChanged?.Invoke();
				}
				catch (Exception exception3)
				{
					Debug.LogException(exception3);
				}
			}
			wasHovered = isHovered;
			wasMouseOvered = isMouseOvered;
			wasInteractable = isInteractable;
			reentrancyGuard = false;
		}
	}
}
