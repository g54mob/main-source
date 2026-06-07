using System.Collections;
using DV.CabControls.NonVR;
using DV.Interaction;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;

public class ItemScrollingNonVR : ItemScrolling
{
	private GrabHandlerItem grabHandler;

	private Coroutine initCoro;

	private void Start()
	{
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Init());
	}

	private IEnumerator Init()
	{
		yield return WaitFor.EndOfFrame;
		grabHandler = GetComponent<GrabHandlerItem>();
		if (grabHandler == null)
		{
			Debug.LogError("Couldn't find GrabHandlerItem, removing this script!", base.gameObject);
			Object.Destroy(this);
			yield break;
		}
		initialized = true;
		ItemNonVR component = GetComponent<ItemNonVR>();
		if (component != null)
		{
			if (component.IsGrabbed())
			{
				OnGrabStart();
			}
			component.isHoverableWhileHeld = true;
		}
		SetupListeners(on: true);
		initCoro = null;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (!UnloadWatcher.isUnloading && initCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(initCoro);
		}
	}

	protected override void SetupListeners(bool on)
	{
		if (on)
		{
			grabHandler.Grabbed += OnGrabStart;
			return;
		}
		grabHandler.Grabbed -= OnGrabStart;
		grabHandler.UnGrabbed -= OnGrabEnd;
		SingletonBehaviour<MouseInputEvents>.Instance.UnsubscribeScrollReceiver(OnMouseWheelScrolled);
	}

	private void OnGrabStart()
	{
		SingletonBehaviour<MouseInputEvents>.Instance.SubscribeScrollReceiver(OnMouseWheelScrolled, 0);
		grabHandler.UnGrabbed += OnGrabEnd;
	}

	private void OnMouseWheelScrolled(int dir)
	{
		AdjustForInversionAndFireScrollingEvent((dir > 0) ? ScrollAction.ScrollUp : ScrollAction.ScrollDown);
	}

	private void OnGrabEnd()
	{
		grabHandler.UnGrabbed -= OnGrabEnd;
		SingletonBehaviour<MouseInputEvents>.Instance.UnsubscribeScrollReceiver(OnMouseWheelScrolled);
	}

	protected override bool CanScroll()
	{
		if (!base.CanScroll())
		{
			return false;
		}
		if (SingletonBehaviour<HotbarController>.Instance != null && SingletonBehaviour<HotbarController>.Instance.IsOpen)
		{
			return false;
		}
		if (SingletonBehaviour<ScreenspaceMouse>.Instance.on && grabHandler.GetGrabber().Raycaster.CurrentlyRaycasted != grabHandler)
		{
			return false;
		}
		return true;
	}
}
