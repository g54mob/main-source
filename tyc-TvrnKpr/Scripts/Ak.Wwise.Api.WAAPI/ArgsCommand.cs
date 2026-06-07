using System;

[Serializable]
public class ArgsCommand : Args
{
	public string[] objects;

	public string command;

	public ArgsCommand(string c, string[] objectIds)
	{
	}
}
