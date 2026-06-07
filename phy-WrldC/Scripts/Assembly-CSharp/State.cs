using System;
using UnityEngine;

public abstract class State<T>
{
	private string stateName;

	public bool IsFirstEntry { get; set; } = true;

	private string StateName
	{
		get
		{
			if (string.IsNullOrEmpty(stateName))
			{
				stateName = GetType().Name.Replace("State", "");
			}
			return stateName;
		}
	}

	public abstract void Start(T entity);

	public void StartWithLog(T entity)
	{
		Start(entity);
		StateDebugLog("Start", "green");
	}

	public abstract void Enter(T entity);

	public void EnterWithLog(T entity)
	{
		Enter(entity);
		StateDebugLog("Enter", "blue");
	}

	public virtual void EnterFromSubState(T entity)
	{
		StateDebugLog("Enter From SubState", "blue");
	}

	public abstract void Execute(T entity);

	public abstract void Exit(T entity);

	public void ExitWithLog(T entity)
	{
		Exit(entity);
		StateDebugLog("Exit", "red");
	}

	public void CustomExitWithLog(Action customExitMethod)
	{
		if (customExitMethod != null)
		{
			customExitMethod();
			StateDebugLog("Custom Exit", "red");
		}
	}

	public virtual void ExitToSubState(T entity)
	{
		StateDebugLog("Exit to SubState", "red");
	}

	private void StateDebugLog(string state, string color)
	{
		Debug.Log("<size=13><color=" + color + "><b>" + state + " State (</b><color=maroon><i>" + StateName + "</i></color><b>)</b></color></size>");
	}
}
