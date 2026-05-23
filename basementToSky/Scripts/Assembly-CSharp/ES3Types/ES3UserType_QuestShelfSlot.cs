using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "mountedItem" })]
	public class ES3UserType_QuestShelfSlot : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestShelfSlot()
			: base(typeof(QuestShelfSlot))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			QuestShelfSlot objectContainingField = (QuestShelfSlot)obj;
			writer.WritePrivateFieldByRef("mountedItem", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			QuestShelfSlot objectContainingField = (QuestShelfSlot)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "mountedItem")
				{
					objectContainingField = (QuestShelfSlot)reader.SetPrivateField("mountedItem", reader.Read<Item>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
