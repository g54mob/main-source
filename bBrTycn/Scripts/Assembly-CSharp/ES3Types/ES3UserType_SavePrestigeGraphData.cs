using CTS;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "currentMounth", "hasPastOneYear", "prestigePerMounth" })]
	public class ES3UserType_SavePrestigeGraphData : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_SavePrestigeGraphData()
			: base(typeof(SavePrestigeGraphData))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			SavePrestigeGraphData savePrestigeGraphData = (SavePrestigeGraphData)obj;
			writer.WriteProperty("currentMounth", savePrestigeGraphData.currentMounth, ES3Type_int.Instance);
			writer.WriteProperty("hasPastOneYear", savePrestigeGraphData.hasPastOneYear, ES3Type_bool.Instance);
			writer.WriteProperty("prestigePerMounth", savePrestigeGraphData.prestigePerMounth, ES3TypeMgr.GetOrCreateES3Type(typeof(PrestigePerMounth[])));
		}

		public override object Read<T>(ES3Reader reader)
		{
			SavePrestigeGraphData savePrestigeGraphData = default(SavePrestigeGraphData);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "currentMounth":
					savePrestigeGraphData.currentMounth = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "hasPastOneYear":
					savePrestigeGraphData.hasPastOneYear = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "prestigePerMounth":
					savePrestigeGraphData.prestigePerMounth = reader.Read<PrestigePerMounth[]>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			return savePrestigeGraphData;
		}
	}
}
