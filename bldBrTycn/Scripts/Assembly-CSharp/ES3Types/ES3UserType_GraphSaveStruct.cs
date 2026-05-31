using CTS;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "currentMounth", "hasPastOneYear", "dataPerMounth" })]
	public class ES3UserType_GraphSaveStruct : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_GraphSaveStruct()
			: base(typeof(GraphSaveStruct))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			GraphSaveStruct graphSaveStruct = (GraphSaveStruct)obj;
			writer.WriteProperty("currentMounth", graphSaveStruct.currentMounth, ES3Type_int.Instance);
			writer.WriteProperty("hasPastOneYear", graphSaveStruct.hasPastOneYear, ES3Type_bool.Instance);
			writer.WriteProperty("dataPerMounth", graphSaveStruct.dataPerMounth, ES3TypeMgr.GetOrCreateES3Type(typeof(GraphPerMounthData[])));
		}

		public override object Read<T>(ES3Reader reader)
		{
			GraphSaveStruct graphSaveStruct = default(GraphSaveStruct);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "currentMounth":
					graphSaveStruct.currentMounth = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "hasPastOneYear":
					graphSaveStruct.hasPastOneYear = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "dataPerMounth":
					graphSaveStruct.dataPerMounth = reader.Read<GraphPerMounthData[]>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			return graphSaveStruct;
		}
	}
}
