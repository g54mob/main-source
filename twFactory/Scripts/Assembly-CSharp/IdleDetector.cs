using System;
using UnityEngine;

public abstract class IdleDetector : MonoBehaviour
{
	[SerializeField]
	private IdleDetectorUI idleDetectorUIPrefab;

	private IdleDetectorUI currentIdleDetectorUI;

	private bool isIdle;

	public bool IsIdle
	{
		get
		{
			return isIdle;
		}
		set
		{
			isIdle = value;
			if (isIdle && !currentIdleDetectorUI)
			{
				UnityEngine.Object.Instantiate(idleDetectorUIPrefab).IdleDetector = this;
			}
		}
	}

	public event Action<IdleDetector> onStartIdle;

	public event Action<IdleDetector> onStopIdle;

	protected virtual void Start()
	{
		GetComponent<PlacementComponent>().onUnplace += delegate
		{
			InvokeOnStopIdle();
		};
	}

	private void OnDestroy()
	{
		if ((bool)currentIdleDetectorUI)
		{
			UnityEngine.Object.Destroy(currentIdleDetectorUI.gameObject);
		}
		InvokeOnStopIdle();
	}

	protected void InvokeOnStartIdle()
	{
		if (!IsIdle)
		{
			IsIdle = true;
			this.onStartIdle?.Invoke(this);
		}
	}

	protected void InvokeOnStopIdle()
	{
		if (IsIdle)
		{
			IsIdle = false;
			this.onStopIdle?.Invoke(this);
		}
	}
}
