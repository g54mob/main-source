using System;
using DV.Common;
using DV.UI;
using DV.Utils;
using UnityEngine;

public class ScreenspaceMouse : SingletonBehaviour<ScreenspaceMouse>
{
	public bool on;

	private RequestSystem requestSystem = new RequestSystem(0f);

	private Vector2Int mousePosition;

	private bool featureRequested;

	public event Action<bool> ValueChanged;

	public new static string AllowAutoCreate()
	{
		return "[ScreenspaceMouse]";
	}

	protected override void Awake()
	{
		base.Awake();
		requestSystem.ValueChanged += delegate(float value)
		{
			RequestSystemValueUpdated(value > 0.5f);
		};
		GameFeatureFlags.RegisterListenerFor(GameFeatureFlags.Flag.MouseMode, OnFeatureFlagChanged);
	}

	private void OnFeatureFlagChanged(GameFeatureFlags.Flag flag, bool allowed)
	{
		if (flag != GameFeatureFlags.Flag.MouseMode)
		{
			return;
		}
		if (allowed)
		{
			if (featureRequested)
			{
				featureRequested = false;
				RemoveRequest(this);
			}
		}
		else if (!featureRequested)
		{
			featureRequested = true;
			RequestOverride(this, on: false, 2);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameFeatureFlags.UnregisterListenerFor(GameFeatureFlags.Flag.MouseMode, OnFeatureFlagChanged);
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
		}
	}

	public void RequestOverride(object caller, bool on, int priority = 0)
	{
		requestSystem.RequestValue(caller, on ? 1f : 0f, priority);
	}

	public void RemoveRequest(object caller)
	{
		requestSystem.RemoveValue(caller);
	}

	private void RequestSystemValueUpdated(bool on)
	{
		if (UnloadWatcher.isQuitting || UnloadWatcher.isUnloading)
		{
			return;
		}
		if (!VRManager.IsVREnabled())
		{
			if (on)
			{
				SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: true);
			}
			else
			{
				SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
			}
		}
		this.on = on;
		if ((bool)SingletonBehaviour<UiVisibilityManagerNonvr>.Instance)
		{
			SingletonBehaviour<UiVisibilityManagerNonvr>.Instance.RefreshVisible();
		}
		this.ValueChanged?.Invoke(on);
	}

	public void SetScreenspaceDefaultValue(bool on)
	{
		requestSystem.SetDefaultValue(on ? 1 : 0);
	}

	public void ToggleScreenspaceDefaultValue()
	{
		requestSystem.SetDefaultValue(1f - requestSystem.GetDefaultValue());
	}

	public void RequestBlock(object caller)
	{
		requestSystem.RequestBlock(caller);
	}

	public void RemoveBlock(object caller)
	{
		requestSystem.RemoveBlock(caller);
	}

	public void ClearValueRequests()
	{
		requestSystem.ClearValueRequests();
	}
}
