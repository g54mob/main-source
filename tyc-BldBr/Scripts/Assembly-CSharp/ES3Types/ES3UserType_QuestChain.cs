using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_lastQuestSucceeded" })]
	public class ES3UserType_QuestChain : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestChain()
			: base(typeof(QuestChain))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			QuestChain objectContainingField = (QuestChain)obj;
			writer.WritePrivateFieldByRef("_lastQuestSucceeded", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			QuestChain objectContainingField = (QuestChain)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_lastQuestSucceeded")
				{
					objectContainingField = (QuestChain)reader.SetPrivateField("_lastQuestSucceeded", reader.Read<Quest>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
