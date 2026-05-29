using System;
using UnityEngine.Events;

[Serializable]
public class TerminalComandBase
{
	public string name;

	public string[] comands;

	public string[] variable;

	public string[] param;

	public UnityEvent<string, string[], string[], TerminalComandBase> Comand;

	public UnityEvent Help;

	public UnityEvent HelpComandDestription;
}
