using System;
using UnityEngine;

public abstract class GestureRecognizer : MonoBehaviour
{
	public enum SelectionType
	{
		Default = 0,
		StartSelection = 1,
		CurrentSelection = 2,
		None = 3
	}

	protected static readonly FingerGestures.IFingerList EmptyFingerList = new FingerGestures.FingerList();

	[SerializeField]
	private int requiredFingerCount = 1;

	public DistanceUnit DistanceUnit = DistanceUnit.Centimeters;

	public int MaxSimultaneousGestures = 1;

	public GestureResetMode ResetMode;

	public ScreenRaycaster Raycaster;

	public FingerClusterManager ClusterManager;

	public GestureRecognizerDelegate Delegate;

	public bool UseSendMessage = true;

	public string EventMessageName;

	public GameObject EventMessageTarget;

	public SelectionType SendMessageToSelection;

	public bool IsExclusive;

	public virtual int RequiredFingerCount
	{
		get
		{
			return requiredFingerCount;
		}
		set
		{
			requiredFingerCount = value;
		}
	}

	public virtual bool SupportFingerClustering => true;

	public virtual GestureResetMode GetDefaultResetMode()
	{
		return GestureResetMode.EndOfTouchSequence;
	}

	public abstract string GetDefaultEventMessageName();

	public abstract Type GetGestureType();

	protected virtual void Awake()
	{
		if (string.IsNullOrEmpty(EventMessageName))
		{
			EventMessageName = GetDefaultEventMessageName();
		}
		if (ResetMode == GestureResetMode.Default)
		{
			ResetMode = GetDefaultResetMode();
		}
		if (!EventMessageTarget)
		{
			EventMessageTarget = base.gameObject;
		}
		if (!Raycaster)
		{
			Raycaster = GetComponent<ScreenRaycaster>();
		}
	}

	protected virtual void OnEnable()
	{
		if ((bool)FingerGestures.Instance)
		{
			FingerGestures.Register(this);
		}
		else
		{
			Debug.LogError("Failed to register gesture recognizer " + this?.ToString() + " - FingerGestures instance is not available.");
		}
	}

	protected virtual void OnDisable()
	{
		if ((bool)FingerGestures.Instance)
		{
			FingerGestures.Unregister(this);
		}
	}

	protected void Acquire(FingerGestures.Finger finger)
	{
		if (!finger.GestureRecognizers.Contains(this))
		{
			finger.GestureRecognizers.Add(this);
		}
	}

	protected bool Release(FingerGestures.Finger finger)
	{
		return finger.GestureRecognizers.Remove(this);
	}

	protected virtual void Start()
	{
		if (!FingerGestures.Instance)
		{
			Debug.LogWarning("FingerGestures instance not found in current scene. Disabling recognizer: " + this);
			base.enabled = false;
		}
		else if (!ClusterManager && SupportFingerClustering)
		{
			ClusterManager = GetComponent<FingerClusterManager>();
			if (!ClusterManager)
			{
				ClusterManager = FingerGestures.DefaultClusterManager;
			}
		}
	}

	protected bool Young(FingerGestures.IFingerList touches)
	{
		FingerGestures.Finger oldest = touches.GetOldest();
		if (oldest == null)
		{
			return false;
		}
		return Time.time - oldest.StarTime < 0.25f;
	}

	public float ToPixels(float distance)
	{
		return distance.Convert(DistanceUnit, DistanceUnit.Pixels);
	}

	public float ToSqrPixels(float distance)
	{
		float num = ToPixels(distance);
		return num * num;
	}
}
