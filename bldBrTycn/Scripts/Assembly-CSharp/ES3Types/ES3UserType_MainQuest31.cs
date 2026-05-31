using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_investigatorsEntry", "_investigatorsVariableName", "_investigatorsTargetVariableName", "_feedback01", "_investigatorsGoal", "_moneyEntry", "_moneyVariableName", "_moneyTargetVariableName",
		"_feedback02", "_sellDrinksGoal", "_questName", "_startDelay", "_outroDelay"
	})]
	public class ES3UserType_MainQuest31 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest31()
			: base(typeof(MainQuest31))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest31 objectContainingField = (MainQuest31)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateField("_investigatorsEntry", objectContainingField);
			writer.WritePrivateField("_investigatorsVariableName", objectContainingField);
			writer.WritePrivateField("_investigatorsTargetVariableName", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_investigatorsGoal", objectContainingField);
			writer.WritePrivateField("_moneyEntry", objectContainingField);
			writer.WritePrivateField("_moneyVariableName", objectContainingField);
			writer.WritePrivateField("_moneyTargetVariableName", objectContainingField);
			writer.WritePrivateField("_feedback02", objectContainingField);
			writer.WritePrivateField("_sellDrinksGoal", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest31 objectContainingField = (MainQuest31)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_investigatorsEntry":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_investigatorsEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_investigatorsVariableName":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_investigatorsVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_investigatorsTargetVariableName":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_investigatorsTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_investigatorsGoal":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_investigatorsGoal", reader.Read<NoInvestigatorsGoal>(), objectContainingField);
					break;
				case "_moneyEntry":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_moneyEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_moneyVariableName":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_moneyVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_moneyTargetVariableName":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_moneyTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_feedback02":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_feedback02", reader.Read<string>(), objectContainingField);
					break;
				case "_sellDrinksGoal":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_sellDrinksGoal", reader.Read<SellDrinksGoal>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest31)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
