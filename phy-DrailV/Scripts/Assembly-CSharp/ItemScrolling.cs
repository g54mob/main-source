using System;
using DV;
using DV.Utils;
using UnityEngine;

public abstract class ItemScrolling : MonoBehaviour
{
	public bool invertHorizontal;

	public bool invertVertical;

	public static bool staticScrollingAllowed = true;

	protected bool scrollingAllowed = true;

	protected bool initialized;

	public event Action<ScrollAction> Scrolled;

	public void ToggleScrolling(bool on)
	{
		scrollingAllowed = on;
	}

	protected void AdjustForInversionAndFireScrollingEvent(ScrollAction direction)
	{
		if (!CanScroll())
		{
			return;
		}
		if (invertHorizontal)
		{
			switch (direction)
			{
			case ScrollAction.ScrollLeft:
				direction = ScrollAction.ScrollRight;
				break;
			case ScrollAction.ScrollRight:
				direction = ScrollAction.ScrollLeft;
				break;
			}
		}
		if (invertVertical)
		{
			switch (direction)
			{
			case ScrollAction.ScrollUp:
				direction = ScrollAction.ScrollDown;
				break;
			case ScrollAction.ScrollDown:
				direction = ScrollAction.ScrollUp;
				break;
			}
		}
		this.Scrolled?.Invoke(direction);
	}

	protected abstract void SetupListeners(bool on);

	protected virtual void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && initialized)
		{
			SetupListeners(on: false);
		}
	}

	protected virtual bool CanScroll()
	{
		if (staticScrollingAllowed && scrollingAllowed)
		{
			return !SingletonBehaviour<AppUtil>.Instance.IsTimePaused;
		}
		return false;
	}
}
