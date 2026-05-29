using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_stockMissionData", "_bloodEntry", "_bloodVariableName", "_bloodTargetVariableName", "_bloodSO", "_bloodGoal", "_feedback01", "_granitaEntry",
		"_granitaVariableName", "_granitaTargetVariableName", "_granitaSO", "_granitaGoal", "_feedback02", "_smokedEntry", "_smokedVariableName", "_smokedTargetVariableName", "_smokedSO", "_smockedGoal",
		"_feedback03", "_questName", "_startDelay", "_outroDelay"
	})]
	public class ES3UserType_MainQuest28 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest28()
			: base(typeof(MainQuest28))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest28 objectContainingField = (MainQuest28)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateFieldByRef("_stockMissionData", objectContainingField);
			writer.WritePrivateField("_bloodEntry", objectContainingField);
			writer.WritePrivateField("_bloodVariableName", objectContainingField);
			writer.WritePrivateField("_bloodTargetVariableName", objectContainingField);
			writer.WritePrivateFieldByRef("_bloodSO", objectContainingField);
			writer.WritePrivateField("_bloodGoal", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_granitaEntry", objectContainingField);
			writer.WritePrivateField("_granitaVariableName", objectContainingField);
			writer.WritePrivateField("_granitaTargetVariableName", objectContainingField);
			writer.WritePrivateFieldByRef("_granitaSO", objectContainingField);
			writer.WritePrivateField("_granitaGoal", objectContainingField);
			writer.WritePrivateField("_feedback02", objectContainingField);
			writer.WritePrivateField("_smokedEntry", objectContainingField);
			writer.WritePrivateField("_smokedVariableName", objectContainingField);
			writer.WritePrivateField("_smokedTargetVariableName", objectContainingField);
			writer.WritePrivateFieldByRef("_smokedSO", objectContainingField);
			writer.WritePrivateField("_smockedGoal", objectContainingField);
			writer.WritePrivateField("_feedback03", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest28 objectContainingField = (MainQuest28)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_stockMissionData":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_stockMissionData", reader.Read<StockMissionData>(), objectContainingField);
					break;
				case "_bloodEntry":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_bloodEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_bloodVariableName":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_bloodVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_bloodTargetVariableName":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_bloodTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_bloodSO":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_bloodSO", reader.Read<StockItemSO>(), objectContainingField);
					break;
				case "_bloodGoal":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_bloodGoal", reader.Read<SubStockMissionGoal>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_granitaEntry":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_granitaEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_granitaVariableName":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_granitaVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_granitaTargetVariableName":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_granitaTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_granitaSO":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_granitaSO", reader.Read<StockItemSO>(), objectContainingField);
					break;
				case "_granitaGoal":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_granitaGoal", reader.Read<SubStockMissionGoal>(), objectContainingField);
					break;
				case "_feedback02":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_feedback02", reader.Read<string>(), objectContainingField);
					break;
				case "_smokedEntry":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_smokedEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_smokedVariableName":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_smokedVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_smokedTargetVariableName":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_smokedTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_smokedSO":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_smokedSO", reader.Read<StockItemSO>(), objectContainingField);
					break;
				case "_smockedGoal":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_smockedGoal", reader.Read<SubStockMissionGoal>(), objectContainingField);
					break;
				case "_feedback03":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_feedback03", reader.Read<string>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest28)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
