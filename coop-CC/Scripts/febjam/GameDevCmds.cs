using DevCmdLine;

public static class GameDevCmds
{
	[DevCmd("quit", "Quit back to the title screen.\r\n\r\nUsage:\r\n    quit", new string[] { "quit" })]
	[DevCmdVerify("^$")]
	public static void QuitDevCmd(DevCmdArg[] args)
	{
		GameManager.Next(GameNextType.QuitTitle);
	}
}
