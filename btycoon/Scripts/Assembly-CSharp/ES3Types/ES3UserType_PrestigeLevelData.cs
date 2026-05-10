using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "Level", "PrestigeRequired", "MaxPopulation", "SeatCoeficient", "VampireRatio", "TimeBetweenSpawnsInSeconds" })]
	public class ES3UserType_PrestigeLevelData : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_PrestigeLevelData()
			: base(typeof(PrestigeLevelData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			PrestigeLevelData prestigeLevelData = (PrestigeLevelData)obj;
			writer.WriteProperty("Level", prestigeLevelData.Level, ES3Type_int.Instance);
			writer.WriteProperty("PrestigeRequired", prestigeLevelData.PrestigeRequired, ES3Type_float.Instance);
			writer.WriteProperty("MaxPopulation", prestigeLevelData.MaxPopulation, ES3Type_int.Instance);
			writer.WriteProperty("SeatCoeficient", prestigeLevelData.SeatCoeficient, ES3Type_float.Instance);
			writer.WriteProperty("VampireRatio", prestigeLevelData.VampireRatio, ES3Type_float.Instance);
			writer.WriteProperty("TimeBetweenSpawnsInSeconds", prestigeLevelData.TimeBetweenSpawnsInSeconds, ES3Type_float.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			PrestigeLevelData prestigeLevelData = (PrestigeLevelData)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "Level":
					prestigeLevelData.Level = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "PrestigeRequired":
					prestigeLevelData.PrestigeRequired = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "MaxPopulation":
					prestigeLevelData.MaxPopulation = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "SeatCoeficient":
					prestigeLevelData.SeatCoeficient = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "VampireRatio":
					prestigeLevelData.VampireRatio = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "TimeBetweenSpawnsInSeconds":
					prestigeLevelData.TimeBetweenSpawnsInSeconds = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			PrestigeLevelData prestigeLevelData = new PrestigeLevelData();
			ReadObject<T>(reader, prestigeLevelData);
			return prestigeLevelData;
		}
	}
}
