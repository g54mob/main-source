using CTS;
using UnityEngine.Localization;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_iceEntry", "_feedback01", "_iceGoal", "_dipEntry", "_feedback02", "_humanServicesEntry", "_humanVariableName", "_humanTargetVariableName",
		"_bark01", "_humanServicesGoal", "_questName", "_startDelay", "_outroDelay"
	})]
	public class ES3UserType_MainQuest24 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest24()
			: base(typeof(MainQuest24))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest24 objectContainingField = (MainQuest24)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateField("_iceEntry", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_iceGoal", objectContainingField);
			writer.WritePrivateField("_dipEntry", objectContainingField);
			writer.WritePrivateField("_feedback02", objectContainingField);
			writer.WritePrivateField("_humanServicesEntry", objectContainingField);
			writer.WritePrivateField("_humanVariableName", objectContainingField);
			writer.WritePrivateField("_humanTargetVariableName", objectContainingField);
			writer.WritePrivateField("_bark01", objectContainingField);
			writer.WritePrivateField("_humanServicesGoal", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest24 objectContainingField = (MainQuest24)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_iceEntry":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_iceEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_iceGoal":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_iceGoal", reader.Read<BuySpecificFurnitureInteractorGoal<BloodyIceCrusher>>(), objectContainingField);
					break;
				case "_dipEntry":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_dipEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback02":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_feedback02", reader.Read<string>(), objectContainingField);
					break;
				case "_humanServicesEntry":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_humanServicesEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_humanVariableName":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_humanVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_humanTargetVariableName":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_humanTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_bark01":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_bark01", reader.Read<LocalizedString>(), objectContainingField);
					break;
				case "_humanServicesGoal":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_humanServicesGoal", reader.Read<SpeciesServiceGoal>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest24)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
