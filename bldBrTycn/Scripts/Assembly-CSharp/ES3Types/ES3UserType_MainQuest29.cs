using CTS;
using UnityEngine.Localization;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_styleEntry", "_styleVariableName", "_styleTargetVariableName", "_feedback01", "_styleGoal", "_wallEntry", "_roomWallStyleGoal", "_floorEntry",
		"_roomFloorStyleGoal", "_serviceEntry", "_serviceVariableName", "_serviceTargetVariableName", "_customerToServe", "_feedback02", "_bark01", "_speciesServiceGoal", "_questName", "_startDelay",
		"_outroDelay"
	})]
	public class ES3UserType_MainQuest29 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest29()
			: base(typeof(MainQuest29))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest29 objectContainingField = (MainQuest29)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateField("_styleEntry", objectContainingField);
			writer.WritePrivateField("_styleVariableName", objectContainingField);
			writer.WritePrivateField("_styleTargetVariableName", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_styleGoal", objectContainingField);
			writer.WritePrivateField("_wallEntry", objectContainingField);
			writer.WritePrivateField("_roomWallStyleGoal", objectContainingField);
			writer.WritePrivateField("_floorEntry", objectContainingField);
			writer.WritePrivateField("_roomFloorStyleGoal", objectContainingField);
			writer.WritePrivateField("_serviceEntry", objectContainingField);
			writer.WritePrivateField("_serviceVariableName", objectContainingField);
			writer.WritePrivateField("_serviceTargetVariableName", objectContainingField);
			writer.WritePrivateFieldByRef("_customerToServe", objectContainingField);
			writer.WritePrivateField("_feedback02", objectContainingField);
			writer.WritePrivateField("_bark01", objectContainingField);
			writer.WritePrivateField("_speciesServiceGoal", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest29 objectContainingField = (MainQuest29)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_styleEntry":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_styleEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_styleVariableName":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_styleVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_styleTargetVariableName":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_styleTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_styleGoal":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_styleGoal", reader.Read<StyleGoal>(), objectContainingField);
					break;
				case "_wallEntry":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_wallEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_roomWallStyleGoal":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_roomWallStyleGoal", reader.Read<RoomWallStyleGoal>(), objectContainingField);
					break;
				case "_floorEntry":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_floorEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_roomFloorStyleGoal":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_roomFloorStyleGoal", reader.Read<RoomFloorStyleGoal>(), objectContainingField);
					break;
				case "_serviceEntry":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_serviceEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_serviceVariableName":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_serviceVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_serviceTargetVariableName":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_serviceTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_customerToServe":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_customerToServe", reader.Read<CustomerParameters>(), objectContainingField);
					break;
				case "_feedback02":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_feedback02", reader.Read<string>(), objectContainingField);
					break;
				case "_bark01":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_bark01", reader.Read<LocalizedString>(), objectContainingField);
					break;
				case "_speciesServiceGoal":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_speciesServiceGoal", reader.Read<SpeciesServiceGoal>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest29)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
