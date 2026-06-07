using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class NavigatorPathBase
{
	private NavigatorPathState _state;

	private ProjectFlags _flags;

	private bool _wasProcessed;

	private bool _recalculateOnProcessed;

	public Action NavigationFinished;

	public Navigator Navigator { get; private set; }

	public ITarget Target { get; protected set; }

	public abstract int Length { get; }

	public bool Processed => NavigatorPathState.Processed <= State;

	public bool NoPathFound { get; set; }

	public bool IncompletePath { get; set; }

	public NavigatorPathState State
	{
		get
		{
			return _state;
		}
		protected set
		{
			bool num = _state == NavigatorPathState.Processing;
			_state = value;
			if (num && NavigatorPathState.Processing <= _state)
			{
				if (_recalculateOnProcessed)
				{
					Recalculate();
				}
				else
				{
					_wasProcessed = true;
				}
			}
		}
	}

	public bool WasProcessed
	{
		get
		{
			if (NavigatorPathState.Processed <= State && _wasProcessed)
			{
				_wasProcessed = false;
				return true;
			}
			_wasProcessed = false;
			return false;
		}
	}

	public NavigatorPathBase(Navigator navigator)
	{
		if (navigator == null)
		{
			Debug.LogException(new Exception("Tried queuing a path without a navigator!"));
		}
		else
		{
			Navigator = navigator;
		}
	}

	public virtual void SetTarget(ITarget target)
	{
		if (target == null)
		{
			Debug.LogException(new Exception("Tried queuing a path without a target!"));
			return;
		}
		Reset();
		Target = target;
		Target.AddQueuedPath(this);
	}

	public bool ValidateTarget()
	{
		if (Target.IsNull())
		{
			NoPathFound = true;
			State = NavigatorPathState.Processed;
			return false;
		}
		return true;
	}

	public abstract void SetState(NavigatorPathState state);

	public void FinishPath(ProjectFlags flags)
	{
		_flags = flags;
		if (flags.IsFlagSet(ProjectFlags.Success))
		{
			SetState(NavigatorPathState.Navigated);
		}
		else if (flags.IsFlagSet(ProjectFlags.Cancelled))
		{
			SetState(NavigatorPathState.Canceled);
		}
		else
		{
			SetState(NavigatorPathState.Interupted);
		}
		if (Target != null)
		{
			Target.RemoveQueuedPath(this);
		}
		Dequeue();
		if (NavigationFinished != null)
		{
			NavigationFinished();
		}
	}

	public abstract void ClearNodes();

	public void Recalculate()
	{
		if (State < NavigatorPathState.Processing)
		{
			Debug.LogException(new NotSupportedException("There is no need to recalculate a Path that is not being processed yet."));
		}
		else if (State == NavigatorPathState.Processing)
		{
			Debug.LogException(new NotImplementedException("Recalculate when processing has completed."));
			_recalculateOnProcessed = true;
		}
		else
		{
			ClearNodes();
			State = NavigatorPathState.Recalculate;
			_recalculateOnProcessed = false;
		}
	}

	public abstract void PopulateLineRenderer(List<Vector3> line, Vector3 offset);

	protected virtual void Dequeue()
	{
	}

	private void Reset()
	{
		Target = null;
		NoPathFound = false;
		IncompletePath = false;
		_recalculateOnProcessed = false;
		_wasProcessed = false;
		SetState(NavigatorPathState.None);
	}

	public virtual bool TryGetNextNode<T>(out T nextNode) where T : PathfindingNode
	{
		nextNode = null;
		return false;
	}

	public virtual void OnDrawGizmos(Navigator navigator)
	{
	}
}
