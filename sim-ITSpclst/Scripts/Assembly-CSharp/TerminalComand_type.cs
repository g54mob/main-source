using UnityEngine;

public class TerminalComand_type : MonoBehaviour
{
	public AppTerminal appTerminal;

	public appExplorer appExplorer;

	public TerminalComand_Cd terminalComand_Cd;

	public ComputerDesktop computerDesktop;

	public void Run(string comand, string[] variables, string[] param, TerminalComandBase terminalComandBase)
	{
	}

	private void Comand(string comand, TerminalValidateComand terminalValidateComand)
	{
	}

	public static CorrectFileStructure ValidateFileName(string fullname)
	{
		return null;
	}

	private void UpdateRenderExplorer()
	{
	}

	public void HelpComandDestription()
	{
	}

	public void Help()
	{
	}
}
