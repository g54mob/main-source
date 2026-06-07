using System;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStateMachine : MonoBehaviour
{
	public class State
	{
		public Action DoUpdate;

		public Action DoFixedUpdate;

		public Action DoLateUpdate;

		public Action DoManualUpdate;

		public Action enterState;

		public Action exitState;

		public Enum currentState;
	}

	public bool DebugGui;

	public Vector2 DebugGuiPosition;

	public string DebugGuiTitle;

	protected Enum queueCommand;

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

	private void OnGUI()
	{
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

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
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
