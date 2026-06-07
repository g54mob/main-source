using RainbowArt.CleanFlatUI;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "uiPos", "questWindowPrefab", "newspaperWindowPrefab", "cleanupWindowPrefab", "partTimeRewardQuestPrefab", "currentPartTime" })]
	public class ES3UserType_QuestUI : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestUI()
			: base(typeof(QuestUI))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			QuestUI objectContainingField = (QuestUI)obj;
			writer.WritePrivateFieldByRef("uiPos", objectContainingField);
			writer.WritePrivateFieldByRef("questWindowPrefab", objectContainingField);
			writer.WritePrivateFieldByRef("newspaperWindowPrefab", objectContainingField);
			writer.WritePrivateFieldByRef("cleanupWindowPrefab", objectContainingField);
			writer.WritePrivateFieldByRef("partTimeRewardQuestPrefab", objectContainingField);
			writer.WritePrivateFieldByRef("currentPartTime", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			QuestUI objectContainingField = (QuestUI)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "uiPos":
					objectContainingField = (QuestUI)reader.SetPrivateField("uiPos", reader.Read<Transform>(), objectContainingField);
					break;
				case "questWindowPrefab":
					objectContainingField = (QuestUI)reader.SetPrivateField("questWindowPrefab", reader.Read<GameObject>(), objectContainingField);
					break;
				case "newspaperWindowPrefab":
					objectContainingField = (QuestUI)reader.SetPrivateField("newspaperWindowPrefab", reader.Read<GameObject>(), objectContainingField);
					break;
				case "cleanupWindowPrefab":
					objectContainingField = (QuestUI)reader.SetPrivateField("cleanupWindowPrefab", reader.Read<GameObject>(), objectContainingField);
					break;
				case "partTimeRewardQuestPrefab":
					objectContainingField = (QuestUI)reader.SetPrivateField("partTimeRewardQuestPrefab", reader.Read<GameObject>(), objectContainingField);
					break;
				case "currentPartTime":
					objectContainingField = (QuestUI)reader.SetPrivateField("currentPartTime", reader.Read<QuestWindow>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
