using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_vladEntry", "_vladVariableName", "_feedback01", "_vladFeedbackPlayed", "_vladGoal", "_yumekoEntry", "_yumekoVariableName", "_feedback03", "_yumekoFeedbackPlayed", "_yumekoGoal",
		"_targetVariableName", "_vampireEntry", "_vampireVariableName", "_vampireTargetVariableName", "_speciesServiceGoal", "_dialogue01", "_dialogue02", "_dialogue03", "_questName", "_startDelay",
		"_outroDelay"
	})]
	public class ES3UserType_MainQuest32 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest32()
			: base(typeof(MainQuest32))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest32 objectContainingField = (MainQuest32)obj;
			writer.WritePrivateField("_vladEntry", objectContainingField);
			writer.WritePrivateField("_vladVariableName", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_vladFeedbackPlayed", objectContainingField);
			writer.WritePrivateField("_vladGoal", objectContainingField);
			writer.WritePrivateField("_yumekoEntry", objectContainingField);
			writer.WritePrivateField("_yumekoVariableName", objectContainingField);
			writer.WritePrivateField("_feedback03", objectContainingField);
			writer.WritePrivateField("_yumekoFeedbackPlayed", objectContainingField);
			writer.WritePrivateField("_yumekoGoal", objectContainingField);
			writer.WritePrivateField("_targetVariableName", objectContainingField);
			writer.WritePrivateField("_vampireEntry", objectContainingField);
			writer.WritePrivateField("_vampireVariableName", objectContainingField);
			writer.WritePrivateField("_vampireTargetVariableName", objectContainingField);
			writer.WritePrivateField("_speciesServiceGoal", objectContainingField);
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateField("_dialogue02", objectContainingField);
			writer.WritePrivateField("_dialogue03", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest32 objectContainingField = (MainQuest32)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_vladEntry":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_vladEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_vladVariableName":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_vladVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_vladFeedbackPlayed":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_vladFeedbackPlayed", reader.Read<bool>(), objectContainingField);
					break;
				case "_vladGoal":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_vladGoal", reader.Read<StyleGoal>(), objectContainingField);
					break;
				case "_yumekoEntry":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_yumekoEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_yumekoVariableName":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_yumekoVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_feedback03":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_feedback03", reader.Read<string>(), objectContainingField);
					break;
				case "_yumekoFeedbackPlayed":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_yumekoFeedbackPlayed", reader.Read<bool>(), objectContainingField);
					break;
				case "_yumekoGoal":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_yumekoGoal", reader.Read<StyleGoal>(), objectContainingField);
					break;
				case "_targetVariableName":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_targetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_vampireEntry":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_vampireEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_vampireVariableName":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_vampireVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_vampireTargetVariableName":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_vampireTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_speciesServiceGoal":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_speciesServiceGoal", reader.Read<SpeciesServiceGoal>(), objectContainingField);
					break;
				case "_dialogue01":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_dialogue02":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_dialogue02", reader.Read<string>(), objectContainingField);
					break;
				case "_dialogue03":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_dialogue03", reader.Read<string>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest32)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
