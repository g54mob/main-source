using System.Collections.Generic;
using UnityEngine;

public class TerminalComand_xcopy : MonoBehaviour
{
	public AppTerminal appTerminal;

	public TerminalComand_Cd terminalComand_Cd;

	public DirectoryManager directoryManager;

	public appExplorer appExplorer;

	private bool paramS;

	private bool paramE;

	public void Run(string comand, string[] variables, string[] param, TerminalComandBase terminalComandBase)
	{
	}

	private void Comand(string comand, TerminalValidateComand terminalValidateComand)
	{
	}

	private void PrintDenied(FileSystemObject obj)
	{
	}

	private FileSystemObject CreateCopyObjectFromSource(FileSystemObject source, string currentRelPath, List<string> blockedPaths)
	{
		return null;
	}

	private void RemoveEmptyDirectories(FileSystemObject dir)
	{
	}

	private int CountFiles(FileSystemObject dir)
	{
		return 0;
	}

	private void UpdateRenderExplorer()
	{
	}

	public void HelpCommandDescription()
	{
	}

	public void Help()
	{
	}
}
