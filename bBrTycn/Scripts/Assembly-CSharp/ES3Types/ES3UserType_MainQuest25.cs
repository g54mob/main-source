using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_missionStockEntry", "_feedback01", "_granitaVariableName", "_granitaTargetVariableName", "_stockMissionData", "_granitaSO", "_missionStockGoal", "_humanKillEntry",
		"_feedback02", "_humanVariableName", "_humanTargetVariableName", "_killHumanGoal", "_corpseDissolveEntry", "_feedback03", "_corpseVariableName", "_corpseTargetVariableName", "_questName", "_startDelay",
		"_outroDelay"
	})]
	public class ES3UserType_MainQuest25 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest25()
			: base(typeof(MainQuest25))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest25 objectContainingField = (MainQuest25)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateField("_missionStockEntry", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_granitaVariableName", objectContainingField);
			writer.WritePrivateField("_granitaTargetVariableName", objectContainingField);
			writer.WritePrivateFieldByRef("_stockMissionData", objectContainingField);
			writer.WritePrivateFieldByRef("_granitaSO", objectContainingField);
			writer.WritePrivateField("_missionStockGoal", objectContainingField);
			writer.WritePrivateField("_humanKillEntry", objectContainingField);
			writer.WritePrivateField("_feedback02", objectContainingField);
			writer.WritePrivateField("_humanVariableName", objectContainingField);
			writer.WritePrivateField("_humanTargetVariableName", objectContainingField);
			writer.WritePrivateField("_killHumanGoal", objectContainingField);
			writer.WritePrivateField("_corpseDissolveEntry", objectContainingField);
			writer.WritePrivateField("_feedback03", objectContainingField);
			writer.WritePrivateField("_corpseVariableName", objectContainingField);
			writer.WritePrivateField("_corpseTargetVariableName", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest25 objectContainingField = (MainQuest25)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_missionStockEntry":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_missionStockEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_granitaVariableName":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_granitaVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_granitaTargetVariableName":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_granitaTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_stockMissionData":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_stockMissionData", reader.Read<StockMissionData>(), objectContainingField);
					break;
				case "_granitaSO":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_granitaSO", reader.Read<StockItemSO>(), objectContainingField);
					break;
				case "_missionStockGoal":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_missionStockGoal", reader.Read<SubStockMissionGoal>(), objectContainingField);
					break;
				case "_humanKillEntry":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_humanKillEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback02":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_feedback02", reader.Read<string>(), objectContainingField);
					break;
				case "_humanVariableName":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_humanVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_humanTargetVariableName":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_humanTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_killHumanGoal":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_killHumanGoal", reader.Read<KillHumanGoal>(), objectContainingField);
					break;
				case "_corpseDissolveEntry":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_corpseDissolveEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback03":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_feedback03", reader.Read<string>(), objectContainingField);
					break;
				case "_corpseVariableName":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_corpseVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_corpseTargetVariableName":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_corpseTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest25)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
