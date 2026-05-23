using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "parttime" })]
	public class ES3UserType_Parttime : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Parttime()
			: base(typeof(Parttime))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Parttime objectContainingField = (Parttime)obj;
			writer.WritePrivateField("parttime", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Parttime objectContainingField = (Parttime)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "parttime")
				{
					objectContainingField = (Parttime)reader.SetPrivateField("parttime", reader.Read<QuestData>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
