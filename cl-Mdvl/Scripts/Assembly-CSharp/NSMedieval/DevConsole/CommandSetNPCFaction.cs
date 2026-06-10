using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSetNPCFaction : ConsoleCommand
	{
		private bool active;

		private Ray ray;

		private RaycastHit hit;

		private FactionInstance factionInstance;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetNPCFaction()
		{
			Command = "setNPCFaction";
			Description = "Sets faction for any NPC on click.";
			Help = GetHelpString();
		}

		private string GetHelpString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("setNPCFaction [factionId]\nPossible factions: ");
			foreach (Faction allItem in Repository<FactionRepository, Faction>.Instance.GetAllItems())
			{
				stringBuilder.AppendFormat("{0} ", allItem.GetID());
			}
			return stringBuilder.ToString();
		}

		private void CommandMethod(string factionId)
		{
			FactionInstance factionInstance = GlobalSaveController.CurrentVillageData.WorldMapData.FactionInstances.FirstOrDefault((FactionInstance fi) => fi.BlueprintId == factionId);
			if (factionInstance == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("S<color=red>Faction instance with blueprintId '" + factionId + "' not found on World Map. Try an other faction./color>", ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
			}
			this.factionInstance = factionInstance;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + " " + factionInstance.BlueprintId });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("setNPCFaction Mode <color=lime>activated</color>! Right click to disable", ConsoleMessageType.Warning);
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (agent.AgentOwner is HumanoidInstance humanoidInstance)
			{
				humanoidInstance.SetFaction(factionInstance);
			}
		}

		private void OnRightMouseDown()
		{
			Disable();
		}

		private void Disable()
		{
			active = false;
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SetNPCBehaviour Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
		}
	}
}
