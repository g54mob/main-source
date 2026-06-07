using System;

[Serializable]
public class TerminalValidateComand
{
	public string comand;

	public bool toManyParameters;

	public bool invalidParameter;

	public TerminalActivesParam[] terminalActivesParam;

	public string[] variable;

	public bool IsParam(string param)
	{
		return false;
	}
}
