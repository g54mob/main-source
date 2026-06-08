using System;
using System.Collections.Generic;
using UnityEngine;

public class ExecutedCommand : IEquatable<ExecutedCommand>
{
	public CommandDefinition Command { get; set; }

	public List<string> Arguments { get; set; }

	public List<int> DroneNumbers { get; set; }

	public string RawCommandLine { get; set; }

	public float TimeStamp { get; set; }

	public bool Handled { get; set; }

	public bool Queued { get; set; }

	public bool RequestConfirmation { get; set; }

	public bool RequestConfirmed { get; set; }

	public ExecutedCommand(ExecutedCommand command)
		: this(command.Command, command.Arguments, command.DroneNumbers, command.RawCommandLine)
	{
	}

	public ExecutedCommand(CommandDefinition command, List<string> arguments, List<int> droneNumbers, string rawCommandLine)
	{
		Command = command;
		Arguments = arguments;
		DroneNumbers = droneNumbers;
		RawCommandLine = rawCommandLine;
		TimeStamp = Time.time;
		Handled = false;
	}

	public bool Equals(ExecutedCommand other)
	{
		return Command.CommandNameLower == other.Command.CommandNameLower;
	}
}
