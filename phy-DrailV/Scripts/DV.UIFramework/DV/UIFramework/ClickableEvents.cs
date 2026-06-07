using System;
using UnityEngine;

namespace DV.UIFramework
{
	public class ClickableEvents : HoverableEvents
	{
		private readonly IClickable clickable;

		protected bool wasPressed;

		private Action Clicked;

		private Action PressChanged;

		public ClickableEvents(IClickable clickable, Action clicked, Action pressChanged, Action hoverChanged, Action mouseOverChanged, Action interactabilityChanged)
			: base(clickable, hoverChanged, mouseOverChanged, interactabilityChanged)
		{
			if (Application.isPlaying)
			{
				this.clickable = clickable;
				Clicked = clicked;
				PressChanged = pressChanged;
				if (clickable.GetGameObject().GetComponent<ClickEffect>() == null)
				{
					clickable.GetGameObject().AddComponent<ClickEffect>();
				}
				if (clickable.GetGameObject().GetComponent<PressEffect>() == null)
				{
					clickable.GetGameObject().AddComponent<PressEffect>();
				}
				if (clickable is IMarkable)
				{
					clickable.GetGameObject().AddComponent<MarkEffect>();
				}
			}
		}

		public void Click()
		{
			if (Application.isPlaying && clickable.IsInteractable)
			{
				Clicked?.Invoke();
			}
		}

		public override void FireEventsIfNeeded()
		{
			base.FireEventsIfNeeded();
			if (!Application.isPlaying || reentrancyGuard)
			{
				return;
			}
			reentrancyGuard = true;
			bool isInteractable = clickable.IsInteractable;
			bool isPressed = clickable.IsPressed;
			if ((!isInteractable && wasPressed) || (isInteractable && wasPressed != isPressed))
			{
				try
				{
					PressChanged?.Invoke();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			wasPressed = isPressed;
			reentrancyGuard = false;
		}
	}
}
