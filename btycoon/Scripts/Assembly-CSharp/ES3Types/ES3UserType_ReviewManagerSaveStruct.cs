using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "CurrentMounth", "LastMounth" })]
	public class ES3UserType_ReviewManagerSaveStruct : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_ReviewManagerSaveStruct()
			: base(typeof(ReviewManagerSaveStruct))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ReviewManagerSaveStruct reviewManagerSaveStruct = (ReviewManagerSaveStruct)obj;
			writer.WriteProperty("CurrentMounth", reviewManagerSaveStruct.CurrentMounth, ES3UserType_ReviewMounthSaveStruct.Instance);
			writer.WriteProperty("LastMounth", reviewManagerSaveStruct.LastMounth, ES3UserType_ReviewMounthSaveStruct.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ReviewManagerSaveStruct reviewManagerSaveStruct = default(ReviewManagerSaveStruct);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				if (!(text == "CurrentMounth"))
				{
					if (text == "LastMounth")
					{
						reviewManagerSaveStruct.LastMounth = reader.Read<ReviewMounthSaveStruct>(ES3UserType_ReviewMounthSaveStruct.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					reviewManagerSaveStruct.CurrentMounth = reader.Read<ReviewMounthSaveStruct>(ES3UserType_ReviewMounthSaveStruct.Instance);
				}
			}
			return reviewManagerSaveStruct;
		}
	}
}
