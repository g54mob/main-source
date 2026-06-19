using System.Collections.Generic;
using Michsky.DreamOS;
using UnityEngine;

namespace Computer.Commander
{
	[CreateAssetMenu(menuName = "Computer/Commander/Shell")]
	public class CommanderShell : ScriptableObject
	{
		public string Name;

		public List<CommanderManager.CommandItem> ShellCommands;
	}
}
