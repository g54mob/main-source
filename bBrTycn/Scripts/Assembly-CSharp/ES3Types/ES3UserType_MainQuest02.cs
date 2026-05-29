using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_junkToDiscard" })]
	public class ES3UserType_MainQuest02 : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest02()
			: base(typeof(MainQuest02))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MainQuest02 objectContainingField = (MainQuest02)obj;
			writer.WritePrivateFieldByRef("_junkToDiscard", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MainQuest02 objectContainingField = (MainQuest02)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_junkToDiscard")
				{
					objectContainingField = (MainQuest02)reader.SetPrivateField("_junkToDiscard", reader.Read<JunkObject>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
