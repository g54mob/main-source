using System;
using System.Collections.Generic;
using DV.Highlighting;
using DV.Util.EventWrapper;
using DV.Utils;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class Telegrabbable : MonoBehaviour
{
	public event_<bool> IsBeingTelegrabbedChanged;

	private HashSet<Telegrabbable> recursionSafetyCollection = new HashSet<Telegrabbable>();

	private Telegrabbable redirectTo;

	private bool isBeingTelegrabbed;

	private HighlightTag highlightTag;

	private Renderer soleHighlightRenderer;

	public abstract bool RemoteInteractionOnly { get; }

	public virtual bool ShouldHighlightWhenNearby => true;

	public Telegrabbable RedirectTo
	{
		get
		{
			return redirectTo;
		}
		set
		{
			if (redirectTo == value)
			{
				return;
			}
			if (value == null)
			{
				redirectTo = null;
				return;
			}
			recursionSafetyCollection.Clear();
			recursionSafetyCollection.Add(this);
			Telegrabbable telegrabbable = value;
			while (telegrabbable != null)
			{
				if (recursionSafetyCollection.Contains(telegrabbable))
				{
					Debug.LogError("Telegrabbable: Recursion detected for redirect target. Aborting...", telegrabbable);
					return;
				}
				telegrabbable = telegrabbable.redirectTo;
			}
			redirectTo = value;
		}
	}

	public bool IsBeingTelegrabbed
	{
		get
		{
			if (isBeingTelegrabbed)
			{
				return true;
			}
			Telegrabbable telegrabbable = RedirectTo;
			while (telegrabbable != null)
			{
				if (telegrabbable.isBeingTelegrabbed)
				{
					return true;
				}
				telegrabbable = telegrabbable.RedirectTo;
			}
			return false;
		}
		private set
		{
			isBeingTelegrabbed = value;
			try
			{
				IsBeingTelegrabbedChanged.Invoke(isBeingTelegrabbed);
			}
			catch (Exception exception)
			{
				Debug.LogError($"The following exception was caught while firing {GetType().Name}.{IsBeingTelegrabbedChanged}", this);
				Debug.LogException(exception, this);
			}
		}
	}

	public abstract bool IsTelegrabAllowed(Vector3 targetPosition);

	protected virtual void OnHighlightChange(bool highlightOn)
	{
	}

	protected abstract void SetState(bool isBeingTelegrabbed);

	public abstract Transform GetAnchor(bool isRightHand);

	public abstract bool ShouldRotateToController();

	protected virtual void Start()
	{
		highlightTag = GetComponentInChildren<HighlightTag>();
		if (!highlightTag)
		{
			soleHighlightRenderer = GetComponentInChildren<Renderer>();
		}
	}

	public void SetHighlight(bool on)
	{
		SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on, highlightTag, AGeneralHighlighter.HighlightType.Item, useObstructedMaterial: false);
		SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on, soleHighlightRenderer, AGeneralHighlighter.HighlightType.Item, useObstructedMaterial: false);
		OnHighlightChange(on);
	}

	public bool IsTelegrabAllowed_internal(Vector3 targetPosition)
	{
		if (IsBeingTelegrabbed)
		{
			return false;
		}
		Telegrabbable telegrabbable = this;
		while (telegrabbable != null)
		{
			if (!telegrabbable.IsTelegrabAllowed(targetPosition))
			{
				return false;
			}
			telegrabbable = telegrabbable.RedirectTo;
		}
		return true;
	}

	public void SetState_internal(bool isBeingTelegrabbed)
	{
		if (IsBeingTelegrabbed == isBeingTelegrabbed)
		{
			Debug.LogWarning(string.Format("{0} not expecting {1} when it's already {2}", GetType().Name, "SetState_internal", IsBeingTelegrabbed), this);
		}
		IsBeingTelegrabbed = isBeingTelegrabbed;
		SetState(isBeingTelegrabbed);
	}

	public static T MakeTelegrabbable<T>(GameObject go) where T : Telegrabbable
	{
		Telegrabbable component = go.GetComponent<Telegrabbable>();
		if ((bool)component)
		{
			if (!(component is T result))
			{
				Debug.LogError($"Must have a telegrabbable that inherits from {typeof(T)}, destroying existing {component.GetType().Name} and adding new one", go);
				UnityEngine.Object.Destroy(component);
				return go.AddComponent<T>();
			}
			return result;
		}
		return go.AddComponent<T>();
	}
}
