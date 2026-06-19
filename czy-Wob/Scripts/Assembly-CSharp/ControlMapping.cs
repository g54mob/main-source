using System;
using System.Collections.Generic;

[Serializable]
public class ControlMapping
{
	public bool toggleSticksDefault = true;

	public List<CommandMapping> mappedCommands = new List<CommandMapping>();
}
