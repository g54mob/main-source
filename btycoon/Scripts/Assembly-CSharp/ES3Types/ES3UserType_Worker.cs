using System.Collections.Generic;
using CTS;
using CTS.BBT.AI;
using CTS.Core;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<Tags>k__BackingField", "<agentName>k__BackingField", "<agentFirstName>k__BackingField", "IsEngaged", "BaseSalary", "ControlledHuman", "Skin" })]
	public class ES3UserType_Worker : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Worker()
			: base(typeof(Worker))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Worker worker = (Worker)obj;
			writer.WritePrivateField("<Tags>k__BackingField", worker);
			writer.WritePrivateField("<agentName>k__BackingField", worker);
			writer.WritePrivateField("<agentFirstName>k__BackingField", worker);
			writer.WritePrivateProperty("IsEngaged", worker);
			writer.WritePrivatePropertyByRef("ControlledHuman", worker);
			writer.WriteProperty("Skin", worker.Skin, ES3TypeMgr.GetOrCreateES3Type(typeof(CharacterData)));
			writer.WriteProperty("IsVisualActive", worker.AgentVisual.activeSelf || worker.ActionPlayer.HasAnyActionOfType<AgentActionVampireSpawn>() || worker.ActionPlayer.HasAnyActionOfType<AgentActionTeleport>());
			writer.WriteProperty("Dismissable", worker.Dismissable);
			writer.WriteProperty("AssignationBypassNeeds", worker.AssignationBypassNeeds);
			writer.WriteProperty("AssignationBypassPowers", worker.AssignationBypassPowers);
			List<StringKey> list = worker.GetTags().FilterNotSave();
			if (list.Count > 0)
			{
				writer.WriteProperty("ObjectTags", list);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Worker worker = (Worker)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "<Tags>k__BackingField":
					worker = (Worker)reader.SetPrivateField("<Tags>k__BackingField", reader.Read<AgentTags>(), worker);
					break;
				case "ObjectTags":
					worker.RemoveAllTags();
					worker.AddTags(reader.Read<List<StringKey>>());
					break;
				case "<agentName>k__BackingField":
					worker = (Worker)reader.SetPrivateField("<agentName>k__BackingField", reader.Read<string>(), worker);
					break;
				case "<agentFirstName>k__BackingField":
					worker = (Worker)reader.SetPrivateField("<agentFirstName>k__BackingField", reader.Read<string>(), worker);
					break;
				case "IsEngaged":
					worker = (Worker)reader.SetPrivateProperty("IsEngaged", reader.Read<bool>(), worker);
					break;
				case "ControlledHuman":
					worker = (Worker)reader.SetPrivateProperty("ControlledHuman", reader.Read<Customer>(), worker);
					break;
				case "Skin":
					worker.Skin = reader.Read<CharacterData>();
					break;
				case "IsVisualActive":
					worker.SetVisualActive(reader.Read<bool>());
					break;
				case "Dismissable":
					worker.Dismissable = reader.Read<bool>();
					break;
				case "AssignationBypassNeeds":
					worker.AssignationBypassNeeds = reader.Read<bool>();
					break;
				case "AssignationBypassPowers":
					worker.AssignationBypassPowers = reader.Read<bool>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
