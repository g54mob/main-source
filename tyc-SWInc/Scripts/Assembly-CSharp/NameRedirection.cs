using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Field, Inherited = true)]
public class NameRedirection : Attribute
{
	public HashSet<string> OldNames = new HashSet<string>();

	public NameRedirection(params string[] oldNames)
	{
		OldNames.AddRange(oldNames);
	}
}
