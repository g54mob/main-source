using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "isOpened", "outLine" })]
	public class ES3UserType_TrashBin : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_TrashBin()
			: base(typeof(TrashBin))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			TrashBin trashBin = (TrashBin)obj;
			writer.WritePrivateField("isOpened", trashBin);
			writer.WritePropertyByRef("outLine", trashBin.outLine);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			TrashBin trashBin = (TrashBin)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "isOpened"))
				{
					if (property == "outLine")
					{
						trashBin.outLine = reader.Read<Outline>();
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					trashBin = (TrashBin)reader.SetPrivateField("isOpened", reader.Read<bool>(), trashBin);
				}
			}
		}
	}
}
