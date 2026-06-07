using System.Collections;
using DV.Common;
using DV.Interaction;
using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

public class MouseWheelHoverScroller : SingletonBehaviour<MouseWheelHoverScroller>
{
	public const float SCROLL_RELEASE_TIMEOUT = 0.3f;

	private float scrollReleaseTimeout;

	private Grabber grabber;

	private IScrollable currentScrollable;

	private int currentScrollAmount;

	public GameObject CurrentItem { get; private set; }

	public bool IsScrolling => scrollReleaseTimeout > 0f;

	private bool IsCurrentScrollableNull
	{
		get
		{
			if (currentScrollable != null)
			{
				return (Object)currentScrollable == null;
			}
			return true;
		}
	}

	public new static string AllowAutoCreate()
	{
		return "[MouseWheelHoverScroller]";
	}

	private IEnumerator Start()
	{
		if (VRManager.IsVREnabled())
		{
			base.enabled = false;
			yield break;
		}
		while (PlayerManager.PlayerTransform == null)
		{
			yield return null;
		}
		grabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
		grabber.Raycaster.Hovered += OnHovered;
		grabber.Raycaster.UnHovered += OnUnHovered;
	}

	private void OnHovered(AGrabHandler item)
	{
		if (!IsCurrentScrollableNull)
		{
			OnUnHovered(null);
		}
		currentScrollable = item.GetComponent<IScrollable>();
		CurrentItem = item.gameObject;
		if (!IsCurrentScrollableNull)
		{
			SingletonBehaviour<MouseInputEvents>.Instance.SubscribeScrollReceiver(OnScrolled, 1);
		}
	}

	private void OnUnHovered(AGrabHandler _)
	{
		if (!IsCurrentScrollableNull)
		{
			currentScrollable.Scroll(ScrollAction.Release);
		}
		SingletonBehaviour<MouseInputEvents>.Instance.UnsubscribeScrollReceiver(OnScrolled);
		scrollReleaseTimeout = 0f;
		currentScrollable = null;
		CurrentItem = null;
	}

	private void OnScrolled(int scroll)
	{
		if (!IsCurrentScrollableNull)
		{
			currentScrollAmount += InputManager.GetScrollValue();
		}
	}

	private void FixedUpdate()
	{
		if (IsCurrentScrollableNull)
		{
			return;
		}
		if (currentScrollAmount != 0)
		{
			if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.WorldInteraction))
			{
				if (currentScrollAmount > 0)
				{
					currentScrollable.Scroll(ScrollAction.ScrollUp);
				}
				else
				{
					currentScrollable.Scroll(ScrollAction.ScrollDown);
				}
				scrollReleaseTimeout = 0.3f;
			}
			currentScrollAmount = 0;
		}
		if (scrollReleaseTimeout > 0f)
		{
			scrollReleaseTimeout -= Time.fixedDeltaTime;
			if (scrollReleaseTimeout <= 0f)
			{
				currentScrollable.Scroll(ScrollAction.Release);
			}
		}
	}
}
