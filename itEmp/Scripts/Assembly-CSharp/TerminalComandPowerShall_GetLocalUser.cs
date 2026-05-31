using System.Collections.Generic;
using UnityEngine;

public class TerminalComandPowerShall_GetLocalUser : MonoBehaviour
{
	private class TerminalComandPowerShall_GetLocalUser_Accounts
	{
		public string nameAccount;

		public string SID;

		public string Enabled;

		public string Description;
	}

	public AppPowerShell appPowerShall;

	public ComputerVariables computerVariables;

	private List<TerminalComandPowerShall_GetLocalUser_Accounts> accounts;

	public void Run(string comand, string[] variables, string[] param, TerminalComandBase terminalComandBase)
	{
	}

	private void Comand(string comand, TerminalValidateComand terminalValidateComand)
	{
	}

	private void PrintAllAccounts()
	{
	}

	private void PrintByName(string name)
	{
	}

	private void PrintBySID(string sid)
	{
	}

	private void PrintUserNotFoundError(string name)
	{
	}

	private bool WildcardMatch(string text, string pattern)
	{
		return false;
	}

	public void HelpComandDestription()
	{
	}

	public void Help()
	{
	}
}
