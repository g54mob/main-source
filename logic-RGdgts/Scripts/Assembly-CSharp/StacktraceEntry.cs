using System;

[Serializable]
public class StacktraceEntry
{
	[Serializable]
	public class VarInfo
	{
		public string name;

		public string type;

		public string value;
	}

	public string name;

	public int line;

	public string source;

	public VarInfo[] upVals;

	public VarInfo[] @params;

	public VarInfo[] locals;

	public bool isNative => false;
}
