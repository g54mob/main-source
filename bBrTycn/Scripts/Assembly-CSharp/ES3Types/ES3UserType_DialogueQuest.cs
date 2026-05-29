using CTS;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_DialogueQuest : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_DialogueQuest()
			: base(typeof(DialogueQuest))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			DialogueQuest dialogueQuest = (DialogueQuest)obj;
			writer.WriteProperty("IsCompleted", dialogueQuest.IsCompleted);
			writer.WriteProperty("StartTime", dialogueQuest.StartTime);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			DialogueQuest objectContainingField = (DialogueQuest)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "IsCompleted":
				case "<IsCompleted>k__BackingField":
					reader.SetPrivateField("IsCompleted".ToBackingField(), reader.Read<bool>(), objectContainingField);
					break;
				case "StartTime":
					reader.SetPrivateField("StartTime".ToBackingField(), reader.Read<UnscaledGameTime>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
