using System;
using System.Collections.Generic;
using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine.EventSystems;

public class MouseInputEvents : SingletonBehaviour<MouseInputEvents>
{
	private class ScrollReceiver
	{
		public int priority;

		public Action<int> Scrolled;
	}

	private int scrollLinesThisFrame;

	private readonly List<ScrollReceiver> ScrollReceivers = new List<ScrollReceiver>();

	public static int ScrollLinesThisFrame => SingletonBehaviour<MouseInputEvents>.Instance.scrollLinesThisFrame;

	public event Action UiInteractionPrimaryDown;

	public event Action UiInteractionPrimaryReleased;

	public event Action UiInteractionSecondaryDown;

	public event Action UiInteractionSecondaryReleased;

	public new static string AllowAutoCreate()
	{
		return "[MouseInputEvents]";
	}

	public void SubscribeScrollReceiver(Action<int> action, int priority)
	{
		ScrollReceivers.Add(new ScrollReceiver
		{
			priority = priority,
			Scrolled = action
		});
		ScrollReceivers.Sort((ScrollReceiver a, ScrollReceiver b) => b.priority.CompareTo(a.priority));
	}

	public void UnsubscribeScrollReceiver(Action<int> action)
	{
		for (int num = ScrollReceivers.Count - 1; num >= 0; num--)
		{
			if (ScrollReceivers[num].Scrolled == action)
			{
				ScrollReceivers.RemoveAt(num);
				break;
			}
		}
	}

	private void Update()
	{
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionPrimary))
		{
			this.UiInteractionPrimaryDown?.Invoke();
		}
		else if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.InteractionPrimary))
		{
			this.UiInteractionPrimaryReleased?.Invoke();
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionSecondary))
		{
			this.UiInteractionSecondaryDown?.Invoke();
		}
		else if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.InteractionSecondary))
		{
			this.UiInteractionSecondaryReleased?.Invoke();
		}
		float axis = InputManager.NewPlayer.GetAxis(InputManager.Actions.Scroll);
		scrollLinesThisFrame = (int)axis;
		if (!EventSystem.current || !EventSystem.current.IsPointerOverGameObject())
		{
			int scrollValue = InputManager.GetScrollValue();
			if (scrollValue != 0 && ScrollReceivers.Count > 0)
			{
				ScrollReceivers[0].Scrolled?.Invoke(scrollValue);
			}
		}
	}
}
