using System.Runtime.InteropServices;

public class Il2CPPCreateProcess
{
	[PreserveSig]
	private static extern uint StartProcess(string command);

	public static uint Run(string command)
	{
		return 0u;
	}
}
