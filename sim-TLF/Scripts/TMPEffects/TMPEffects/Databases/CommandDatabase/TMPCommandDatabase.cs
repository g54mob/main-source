using System;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPCommands;
using UnityEngine;

namespace TMPEffects.Databases.CommandDatabase
{
	[CreateAssetMenu(fileName = "new TMPCommandDatabase", menuName = "TMPEffects/Database/Command Database", order = 30)]
	public class TMPCommandDatabase : TMPEffectDatabase<TMPCommand>
	{
		[SerializeField]
		private SerializedDictionary<string, TMPCommand> commands;

		public override bool ContainsEffect(string name)
		{
			return commands.ContainsKey(name);
		}

		public override TMPCommand GetEffect(string name)
		{
			TMPCommand tMPCommand = commands[name];
			if (tMPCommand == null)
			{
				throw new InvalidOperationException("The command " + name + " is unassigned on database " + base.name);
			}
			return tMPCommand;
		}
	}
}
