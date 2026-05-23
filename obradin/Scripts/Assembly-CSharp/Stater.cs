using System;
using System.Collections.Generic;
using UnityEngine;

public class Stater<Id> where Id : struct, IConvertible
{
	private string debugName;

	private StaterState<Id> curState;

	private float interpCountdown;

	private Dictionary<Id, StaterState<Id>> states = new Dictionary<Id, StaterState<Id>>();

	private static Id defaultStateId = new Id();

	public static bool enableDebugLog;

	public Id curStateId
	{
		get
		{
			return (curState == null) ? defaultStateId : curState.id;
		}
	}

	public float stateTime
	{
		get
		{
			if (curState == null)
			{
				return 0f;
			}
			return curState.stepTime;
		}
	}

	public Stater(string debugName_)
	{
		debugName = debugName_;
	}

	public StaterState<Id> AddState(Id stateId)
	{
		StaterState<Id> staterState = new StaterState<Id>(stateId);
		states.Add(stateId, staterState);
		if (curState == null)
		{
			curState = staterState;
		}
		return staterState;
	}

	public StaterState<Id> GetState(Id stateId)
	{
		StaterState<Id> value = null;
		states.TryGetValue(stateId, out value);
		return value;
	}

	public void Go(Id stateId, bool instant = false)
	{
		StaterState<Id> state = GetState(stateId);
		if (state == null)
		{
			Debug.LogErrorFormat("{0}: State not found: {1}", debugName, stateId.ToString());
			return;
		}
		if (enableDebugLog)
		{
			Debug.LogFormat("{0}: {1} -> {2}", debugName, (curState == null) ? "-" : curState.id.ToString(), stateId);
		}
		interpCountdown = 0f;
		if (curState != null)
		{
			curState.Exit();
		}
		if (curState == null || instant)
		{
			curState = state;
			curState.Enter();
			curState.Apply(1f);
			return;
		}
		curState = state;
		curState.Enter(true);
		interpCountdown = curState.interpDuration;
		if (interpCountdown == 0f)
		{
			curState.Apply(1f);
		}
	}

	public void Trigger(string triggerId)
	{
		if (enableDebugLog)
		{
			Debug.LogFormat("{0}: Trigger [{1}]", debugName, triggerId);
		}
		if (curState != null)
		{
			curState.Trigger(triggerId);
		}
	}

	public void Step(float dt)
	{
		if (curState == null)
		{
			return;
		}
		if (interpCountdown > 0f)
		{
			float interp = Mathf.Min(1f, 1f - interpCountdown / curState.interpDuration);
			curState.Apply(interp);
			interpCountdown -= dt;
			if (interpCountdown <= 0f)
			{
				interpCountdown = 0f;
				curState.Apply(1f);
			}
		}
		if (interpCountdown == 0f)
		{
			if (curState.stepDuration >= 0f && curState.hasAfterStateId && curState.stepTime >= curState.stepDuration)
			{
				Go(curState.afterStateId);
			}
			else
			{
				curState.Step(dt);
			}
		}
	}
}
