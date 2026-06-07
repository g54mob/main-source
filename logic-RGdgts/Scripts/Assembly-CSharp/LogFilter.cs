using System;
using System.Collections.Generic;

[Serializable]
public struct LogFilter
{
	public Dictionary<string, bool> filters;

	[NonSerialized]
	public bool init;
}
