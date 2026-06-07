using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class NameGenerator : ScriptableObject
{
	public abstract string ReturnName();

	public virtual void AddAllNames(List<string> names)
	{
		throw new NotImplementedException();
	}
}
