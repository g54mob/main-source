using System;
using System.Collections.Generic;
using UnityEngine;

public class SuperStateMachine : MonoBehaviour
{
	public class State
	{
		public Action DoSuperUpdate;

		public Action enterState;

		public Action exitState;

		public Enum currentState;
	}

	protected float timeEnteredState;

	public State state;

	[HideInInspector]
	public Enum lastState;

	private Dictionary<Enum, Dictionary<string, Delegate>> _cache;

	public Enum currentState
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void ChangingState()
	{
	}

	private void ConfigureCurrentState()
	{
	}

	private T ConfigureDelegate<T>(string methodRoot, T Default) where T : class
	{
		return null;
	}

	private void SuperUpdate()
	{
	}

	protected virtual void EarlyGlobalSuperUpdate()
	{
	}

	protected virtual void LateGlobalSuperUpdate()
	{
	}

	private static void DoNothing()
	{
	}
}
