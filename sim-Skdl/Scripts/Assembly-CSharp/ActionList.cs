using System;
using System.Collections.Generic;

public class ActionList
{
	private readonly List<Action> list;

	private bool _shuffleCallbackList;

	private bool _shuffleBeforeNextInvoke;

	public ActionList(bool shuffleCallbackList = false)
	{
	}

	public List<Action> GetInvocationList()
	{
		return null;
	}

	public void InvokeAll()
	{
	}

	public void InvokeAllStaggered(float staggerTime)
	{
	}

	public void Clear()
	{
	}

	private void Add(Action action)
	{
	}

	private void Remove(Action action)
	{
	}

	public static ActionList operator +(ActionList list, Action action)
	{
		return null;
	}

	public static ActionList operator -(ActionList list, Action action)
	{
		return null;
	}
}
