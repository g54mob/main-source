using CTS;
using UnityEngine.Localization;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_barEntry", "_feedback01", "_extendBarGoal", "_vampireEntry", "_vampireVariableName", "_vampireTargetVariableName", "_bark01", "_speciesServiceGoal",
		"_questName", "_startDelay", "_outroDelay"
	})]
	public class ES3UserType_MainQuest23 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest23()
			: base(typeof(MainQuest23))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest23 objectContainingField = (MainQuest23)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateField("_barEntry", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_extendBarGoal", objectContainingField);
			writer.WritePrivateField("_vampireEntry", objectContainingField);
			writer.WritePrivateField("_vampireVariableName", objectContainingField);
			writer.WritePrivateField("_vampireTargetVariableName", objectContainingField);
			writer.WritePrivateField("_bark01", objectContainingField);
			writer.WritePrivateField("_speciesServiceGoal", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest23 objectContainingField = (MainQuest23)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_barEntry":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_barEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_extendBarGoal":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_extendBarGoal", reader.Read<ExtendBarGoal>(), objectContainingField);
					break;
				case "_vampireEntry":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_vampireEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_vampireVariableName":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_vampireVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_vampireTargetVariableName":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_vampireTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_bark01":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_bark01", reader.Read<LocalizedString>(), objectContainingField);
					break;
				case "_speciesServiceGoal":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_speciesServiceGoal", reader.Read<SpeciesServiceGoal>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest23)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
