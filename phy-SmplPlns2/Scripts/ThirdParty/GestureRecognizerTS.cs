using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GestureRecognizerTS<T> : GestureRecognizer where T : Gesture, new()
{
	public delegate void GestureEventHandler(T gesture);

	private List<T> gestures;

	private static FingerGestures.FingerList tempTouchList = new FingerGestures.FingerList();

	public List<T> Gestures => gestures;

	public event GestureEventHandler OnGesture;

	protected override void Start()
	{
		base.Start();
		InitGestures();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	private void InitGestures()
	{
		if (gestures == null)
		{
			gestures = new List<T>();
			for (int i = 0; i < MaxSimultaneousGestures; i++)
			{
				AddGesture();
			}
		}
	}

	protected T AddGesture()
	{
		T val = CreateGesture();
		val.Recognizer = this;
		val.OnStateChanged += OnStateChanged;
		gestures.Add(val);
		return val;
	}

	protected virtual bool CanBegin(T gesture, FingerGestures.IFingerList touches)
	{
		if (touches.Count != RequiredFingerCount)
		{
			return false;
		}
		if (IsExclusive && FingerGestures.Touches.Count != RequiredFingerCount)
		{
			return false;
		}
		if ((bool)Delegate && Delegate.enabled && !Delegate.CanBegin(gesture, touches))
		{
			return false;
		}
		return true;
	}

	protected abstract void OnBegin(T gesture, FingerGestures.IFingerList touches);

	protected abstract GestureRecognitionState OnRecognize(T gesture, FingerGestures.IFingerList touches);

	protected virtual GameObject GetDefaultSelectionForSendMessage(T gesture)
	{
		return gesture.Selection;
	}

	protected virtual T CreateGesture()
	{
		return new T();
	}

	public override Type GetGestureType()
	{
		return typeof(T);
	}

	protected virtual void OnStateChanged(Gesture gesture)
	{
	}

	protected virtual T FindGestureByCluster(FingerClusterManager.Cluster cluster)
	{
		return gestures.Find((T g) => g.ClusterId == cluster.Id);
	}

	protected virtual T MatchActiveGestureToCluster(FingerClusterManager.Cluster cluster)
	{
		return null;
	}

	protected virtual T FindFreeGesture()
	{
		return gestures.Find((T g) => g.State == GestureRecognitionState.Ready);
	}

	protected virtual void Reset(T gesture)
	{
		ReleaseFingers(gesture);
		gesture.ClusterId = 0;
		gesture.Fingers.Clear();
		gesture.State = GestureRecognitionState.Ready;
	}

	public virtual void Update()
	{
		if (IsExclusive)
		{
			UpdateExclusive();
		}
		else if (RequiredFingerCount == 1)
		{
			UpdatePerFinger();
		}
		else if (SupportFingerClustering && (bool)ClusterManager)
		{
			UpdateUsingClusters();
		}
		else
		{
			UpdateExclusive();
		}
	}

	private void UpdateExclusive()
	{
		T val = gestures[0];
		FingerGestures.IFingerList touches = FingerGestures.Touches;
		if (val.State == GestureRecognitionState.Ready && CanBegin(val, touches))
		{
			Begin(val, 0, touches);
		}
		UpdateGesture(val, touches);
	}

	private void UpdatePerFinger()
	{
		for (int i = 0; i < FingerGestures.Instance.MaxFingers && i < MaxSimultaneousGestures; i++)
		{
			FingerGestures.Finger finger = FingerGestures.GetFinger(i);
			T val = gestures[i];
			FingerGestures.FingerList fingerList = tempTouchList;
			fingerList.Clear();
			if (finger.IsDown)
			{
				fingerList.Add(finger);
			}
			if (val.State == GestureRecognitionState.Ready && CanBegin(val, fingerList))
			{
				Begin(val, 0, fingerList);
			}
			UpdateGesture(val, fingerList);
		}
	}

	private void UpdateUsingClusters()
	{
		ClusterManager.Update();
		for (int i = 0; i < ClusterManager.Clusters.Count; i++)
		{
			ProcessCluster(ClusterManager.Clusters[i]);
		}
		for (int j = 0; j < gestures.Count; j++)
		{
			T val = gestures[j];
			FingerClusterManager.Cluster cluster = ClusterManager.FindClusterById(val.ClusterId);
			FingerGestures.IFingerList fingerList;
			if (cluster == null)
			{
				fingerList = GestureRecognizer.EmptyFingerList;
			}
			else
			{
				FingerGestures.IFingerList fingers = cluster.Fingers;
				fingerList = fingers;
			}
			FingerGestures.IFingerList touches = fingerList;
			UpdateGesture(val, touches);
		}
	}

	protected virtual void ProcessCluster(FingerClusterManager.Cluster cluster)
	{
		if (FindGestureByCluster(cluster) != null || cluster.Fingers.Count != RequiredFingerCount)
		{
			return;
		}
		T val = MatchActiveGestureToCluster(cluster);
		if (val != null)
		{
			val.ClusterId = cluster.Id;
			return;
		}
		val = FindFreeGesture();
		if (val != null && CanBegin(val, cluster.Fingers))
		{
			Begin(val, cluster.Id, cluster.Fingers);
		}
	}

	private void ReleaseFingers(T gesture)
	{
		for (int i = 0; i < gesture.Fingers.Count; i++)
		{
			Release(gesture.Fingers[i]);
		}
	}

	private void Begin(T gesture, int clusterId, FingerGestures.IFingerList touches)
	{
		gesture.ClusterId = clusterId;
		gesture.StartTime = Time.time;
		for (int i = 0; i < touches.Count; i++)
		{
			FingerGestures.Finger finger = touches[i];
			gesture.Fingers.Add(finger);
			Acquire(finger);
		}
		OnBegin(gesture, touches);
		gesture.PickStartSelection(Raycaster);
		gesture.State = GestureRecognitionState.Started;
	}

	protected virtual FingerGestures.IFingerList GetTouches(T gesture)
	{
		if (SupportFingerClustering && (bool)ClusterManager)
		{
			FingerClusterManager.Cluster cluster = ClusterManager.FindClusterById(gesture.ClusterId);
			if (cluster == null)
			{
				return GestureRecognizer.EmptyFingerList;
			}
			return cluster.Fingers;
		}
		return FingerGestures.Touches;
	}

	protected virtual void UpdateGesture(T gesture, FingerGestures.IFingerList touches)
	{
		if (gesture.State == GestureRecognitionState.Ready)
		{
			return;
		}
		if (gesture.State == GestureRecognitionState.Started)
		{
			gesture.State = GestureRecognitionState.InProgress;
		}
		switch (gesture.State)
		{
		case GestureRecognitionState.InProgress:
		{
			GestureRecognitionState gestureRecognitionState = OnRecognize(gesture, touches);
			switch (gestureRecognitionState)
			{
			case GestureRecognitionState.FailAndRetry:
			{
				gesture.State = GestureRecognitionState.Failed;
				int clusterId = gesture.ClusterId;
				Reset(gesture);
				if (CanBegin(gesture, touches))
				{
					Begin(gesture, clusterId, touches);
				}
				return;
			}
			case GestureRecognitionState.InProgress:
				gesture.PickSelection(Raycaster);
				break;
			}
			gesture.State = gestureRecognitionState;
			break;
		}
		case GestureRecognitionState.Failed:
		case GestureRecognitionState.Ended:
			if (gesture.PreviousState != gesture.State)
			{
				ReleaseFingers(gesture);
			}
			if (ResetMode == GestureResetMode.NextFrame || (ResetMode == GestureResetMode.EndOfTouchSequence && touches.Count == 0))
			{
				Reset(gesture);
			}
			break;
		default:
			Debug.LogError(this?.ToString() + " - Unhandled state: " + gesture.State.ToString() + ". Failing gesture.");
			gesture.State = GestureRecognitionState.Failed;
			break;
		}
	}

	protected void RaiseEvent(T gesture)
	{
		if (this.OnGesture != null)
		{
			this.OnGesture(gesture);
		}
		FingerGestures.FireEvent(gesture);
		if (!UseSendMessage || string.IsNullOrEmpty(EventMessageName))
		{
			return;
		}
		if ((bool)EventMessageTarget)
		{
			EventMessageTarget.SendMessage(EventMessageName, gesture, SendMessageOptions.DontRequireReceiver);
		}
		if (SendMessageToSelection != SelectionType.None)
		{
			GameObject gameObject = null;
			switch (SendMessageToSelection)
			{
			case SelectionType.Default:
				gameObject = GetDefaultSelectionForSendMessage(gesture);
				break;
			case SelectionType.CurrentSelection:
				gameObject = gesture.Selection;
				break;
			case SelectionType.StartSelection:
				gameObject = gesture.StartSelection;
				break;
			}
			if ((bool)gameObject && gameObject != EventMessageTarget)
			{
				gameObject.SendMessage(EventMessageName, gesture, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
