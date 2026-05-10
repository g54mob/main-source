using CTS;
using UnityEngine.Localization;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_prestigeEntry", "_feedback01", "_prestigeVariableName", "_prestigeTargetVariableName", "_bark01", "_prestigeLevelGoal", "_questName", "_startDelay",
		"_outroDelay"
	})]
	public class ES3UserType_MainQuest30 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest30()
			: base(typeof(MainQuest30))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest30 objectContainingField = (MainQuest30)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateField("_prestigeEntry", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_prestigeVariableName", objectContainingField);
			writer.WritePrivateField("_prestigeTargetVariableName", objectContainingField);
			writer.WritePrivateField("_bark01", objectContainingField);
			writer.WritePrivateField("_prestigeLevelGoal", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest30 objectContainingField = (MainQuest30)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_prestigeEntry":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_prestigeEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_prestigeVariableName":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_prestigeVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_prestigeTargetVariableName":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_prestigeTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_bark01":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_bark01", reader.Read<LocalizedString>(), objectContainingField);
					break;
				case "_prestigeLevelGoal":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_prestigeLevelGoal", reader.Read<PrestigeLevelGoal>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest30)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
