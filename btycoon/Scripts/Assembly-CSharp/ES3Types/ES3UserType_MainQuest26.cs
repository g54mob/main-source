using CTS;
using UnityEngine.Localization;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[]
	{
		"_dialogue01", "_reward01", "_punchingBallEntry", "_feedback01", "_punchingBallGoal", "_captureEntry", "_captureVariableName", "_captureTargetVariableName", "_feedback02", "_bark01",
		"_punchingBallCaptureGoal", "_questName", "_startDelay", "_outroDelay"
	})]
	public class ES3UserType_MainQuest26 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest26()
			: base(typeof(MainQuest26))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest26 objectContainingField = (MainQuest26)obj;
			writer.WritePrivateField("_dialogue01", objectContainingField);
			writer.WritePrivateFieldByRef("_reward01", objectContainingField);
			writer.WritePrivateField("_punchingBallEntry", objectContainingField);
			writer.WritePrivateField("_feedback01", objectContainingField);
			writer.WritePrivateField("_punchingBallGoal", objectContainingField);
			writer.WritePrivateField("_captureEntry", objectContainingField);
			writer.WritePrivateField("_captureVariableName", objectContainingField);
			writer.WritePrivateField("_captureTargetVariableName", objectContainingField);
			writer.WritePrivateField("_feedback02", objectContainingField);
			writer.WritePrivateField("_bark01", objectContainingField);
			writer.WritePrivateField("_punchingBallCaptureGoal", objectContainingField);
			writer.WritePrivateField("_questName", objectContainingField);
			writer.WritePrivateField("_startDelay", objectContainingField);
			writer.WritePrivateField("_outroDelay", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest26 objectContainingField = (MainQuest26)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_dialogue01":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_dialogue01", reader.Read<string>(), objectContainingField);
					break;
				case "_reward01":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_reward01", reader.Read<RewardData>(), objectContainingField);
					break;
				case "_punchingBallEntry":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_punchingBallEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_feedback01":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_feedback01", reader.Read<string>(), objectContainingField);
					break;
				case "_punchingBallGoal":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_punchingBallGoal", reader.Read<BuySpecificFurnitureInteractorGoal<PunchingBall>>(), objectContainingField);
					break;
				case "_captureEntry":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_captureEntry", reader.Read<int>(), objectContainingField);
					break;
				case "_captureVariableName":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_captureVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_captureTargetVariableName":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_captureTargetVariableName", reader.Read<string>(), objectContainingField);
					break;
				case "_feedback02":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_feedback02", reader.Read<string>(), objectContainingField);
					break;
				case "_bark01":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_bark01", reader.Read<LocalizedString>(), objectContainingField);
					break;
				case "_punchingBallCaptureGoal":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_punchingBallCaptureGoal", reader.Read<PunchingBallCaptureGoal>(), objectContainingField);
					break;
				case "_questName":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_questName", reader.Read<string>(), objectContainingField);
					break;
				case "_startDelay":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_startDelay", reader.Read<float>(), objectContainingField);
					break;
				case "_outroDelay":
					objectContainingField = (MainQuest26)reader.SetPrivateField("_outroDelay", reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
