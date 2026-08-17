using System;
using System.Collections.Generic;

namespace VampireSurvivors;

public class CheatData
{
	public string Label;

	public List<Action> Actions;

	public void Run()
	{
		//IL_0013: Expected O, but got I4
		List<Action>.Enumerator enumerator = default(List<Action>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public CheatData()
	{
		List<Action> actions = new List<Action>();
		Actions = actions;
	}
}
