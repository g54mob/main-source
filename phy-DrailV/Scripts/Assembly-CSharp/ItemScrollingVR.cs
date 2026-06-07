using System;
using System.Collections;
using System.Collections.Generic;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class ItemScrollingVR : ItemScrolling
{
	private const float CONTINUOUS_SCROLLING_DELAY = 0.4f;

	private const float CONTINUOUS_SCROLLING_STANDARD_INTERVAL = 0.25f;

	private const float CONTINUOUS_SCROLLING_FAST_INTERVAL = 0.1f;

	private const int CONTINUOUS_SCROLLING_FAST_THRESHOLD = 5;

	private VRTK_InteractableObject_DV interactable;

	private VRTK_InteractUse_DV use;

	public bool handMirroring;

	private Coroutine continuousScrollingCoro;

	[NonSerialized]
	public bool ignoreUseRestriction;

	private static Dictionary<TouchpadInputDirection, ScrollAction> touchpadDirectionToScrollingDirection = new Dictionary<TouchpadInputDirection, ScrollAction>
	{
		{
			TouchpadInputDirection.None,
			ScrollAction.Release
		},
		{
			TouchpadInputDirection.Left,
			ScrollAction.ScrollLeft
		},
		{
			TouchpadInputDirection.Right,
			ScrollAction.ScrollRight
		},
		{
			TouchpadInputDirection.Up,
			ScrollAction.ScrollUp
		},
		{
			TouchpadInputDirection.Down,
			ScrollAction.ScrollDown
		}
	};

	private void Start()
	{
		interactable = GetComponent<VRTK_InteractableObject_DV>();
		if (interactable == null)
		{
			Debug.LogError("'ItemScrollingVR' requires a valid 'VRTK_InteractableObject_DV' reference. Destroying self", base.gameObject);
			UnityEngine.Object.Destroy(this);
		}
		else
		{
			interactable.isScrollable = true;
			initialized = true;
			SetupListeners(on: true);
		}
	}

	private void OnDisable()
	{
		StopContinuousScrolling();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (!UnloadWatcher.isUnloading && initialized)
		{
			interactable.isScrollable = false;
		}
	}

	protected override void SetupListeners(bool on)
	{
		if (on)
		{
			interactable.InteractableObjectGrabbed += OnGrabbed;
			return;
		}
		interactable.InteractableObjectGrabbed -= OnGrabbed;
		interactable.InteractableObjectUngrabbed -= OnUngrabbed;
		if ((bool)use)
		{
			TouchpadInputInterpreter component = use.GetComponent<TouchpadInputInterpreter>();
			if (!(component == null))
			{
				component.DelayedDirectionalInputGiven -= OnScrollInput;
				component.DirectionalInputNeutral -= OnScrollInputNeutral;
				component.PressedChanged -= OnPressedChanged;
			}
		}
	}

	private void OnGrabbed(object sender, InteractableObjectEventArgs e)
	{
		interactable.InteractableObjectUngrabbed += OnUngrabbed;
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(e.interactingObject);
		use = ((VRTK_InteractableObject)sender).GetGrabbingObject().GetComponent<VRTK_InteractUse_DV>();
		TouchpadInputInterpreter component = use.GetComponent<TouchpadInputInterpreter>();
		component.DelayedDirectionalInputGiven += OnScrollInput;
		component.DirectionalInputNeutral += OnScrollInputNeutral;
		if (controllerReference.IsWandOrUndefined())
		{
			component.PressedChanged += OnPressedChanged;
		}
	}

	private void OnPressedChanged(bool pressed)
	{
		if (!pressed)
		{
			StopContinuousScrolling();
		}
	}

	private void OnUngrabbed(object sender, InteractableObjectEventArgs e)
	{
		interactable.InteractableObjectUngrabbed -= OnUngrabbed;
		TouchpadInputInterpreter component = use.GetComponent<TouchpadInputInterpreter>();
		component.DelayedDirectionalInputGiven -= OnScrollInput;
		component.DirectionalInputNeutral -= OnScrollInputNeutral;
		component.PressedChanged -= OnPressedChanged;
		StopContinuousScrolling();
		use = null;
	}

	private void OnScrollInputNeutral(TouchpadInputDirection direction, bool swiped, VRTK_ControllerReference ctrlRef)
	{
		StopContinuousScrolling();
	}

	private void OnScrollInput(TouchpadInputDirection direction, bool swiped, VRTK_ControllerReference ctrlRef)
	{
		if (!ValidInput(direction, swiped, ctrlRef))
		{
			return;
		}
		StopContinuousScrolling();
		ScrollAction direction2 = touchpadDirectionToScrollingDirection[direction];
		int num;
		if (handMirroring)
		{
			num = ((ctrlRef.hand == SDK_BaseController.ControllerHand.Left) ? 1 : 0);
			if (num != 0)
			{
				invertHorizontal = !invertHorizontal;
			}
		}
		else
		{
			num = 0;
		}
		AdjustForInversionAndFireScrollingEvent(direction2);
		continuousScrollingCoro = StartCoroutine(ScrollContinuously(direction2));
		if (num != 0)
		{
			invertHorizontal = !invertHorizontal;
		}
	}

	private bool ValidInput(TouchpadInputDirection direction, bool swiped, VRTK_ControllerReference ctrlRef)
	{
		if (ctrlRef == null || !(use != null) || !use.UseModified)
		{
			return false;
		}
		if (!interactable.isUsable || ignoreUseRestriction)
		{
			return true;
		}
		if (direction != TouchpadInputDirection.Up)
		{
			return direction != TouchpadInputDirection.Down;
		}
		return false;
	}

	private IEnumerator ScrollContinuously(ScrollAction direction)
	{
		yield return WaitFor.Seconds(0.4f);
		int fastScrollingCounter = 0;
		while (true)
		{
			float seconds = ((fastScrollingCounter++ > 5) ? 0.1f : 0.25f);
			yield return WaitFor.Seconds(seconds);
			AdjustForInversionAndFireScrollingEvent(direction);
		}
	}

	private void StopContinuousScrolling()
	{
		if (continuousScrollingCoro != null)
		{
			StopCoroutine(continuousScrollingCoro);
		}
		continuousScrollingCoro = null;
	}
}
