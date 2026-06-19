using System;
using OUSystems.Cheats.Commands;

public class DevCommandCompleteAmalgamationAltar : DevCommand
{
	public static Action AnnounceComplete;

	public override string Description => null;

	public override string Usage => null;

	public override bool Execute(string[] args)
	{
		return false;
	}
}
