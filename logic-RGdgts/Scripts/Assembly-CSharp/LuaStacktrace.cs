using System;

[Serializable]
public class LuaStacktrace
{
	public StacktraceEntry[] entries;

	public int firstLineIndex => 0;

	public int GetLine(string filename, out int depth)
	{
		depth = default(int);
		return 0;
	}

	public StacktraceEntry GetFirstViewable(out int depth)
	{
		depth = default(int);
		return null;
	}
}
