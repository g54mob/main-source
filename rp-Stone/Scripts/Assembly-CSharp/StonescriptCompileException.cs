using System;

public class StonescriptCompileException : Exception
{
	public string ScriptName { get; set; }

	public int LineNumber { get; set; }

	public bool IsWarning { get; set; }

	public StonescriptCompileException(string message, string scriptName, int lineNumber, bool isWarning = false)
		: base(message)
	{
		LineNumber = lineNumber;
		ScriptName = scriptName;
		IsWarning = isWarning;
	}
}
