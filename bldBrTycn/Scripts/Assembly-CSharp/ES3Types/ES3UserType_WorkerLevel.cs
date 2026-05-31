using CTS;
using CTS.Core.StatisticsSystem;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_level", "_experience", "_experienceMultiplicator" })]
	public class ES3UserType_WorkerLevel : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerLevel()
			: base(typeof(WorkerLevel))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			WorkerLevel objectContainingField = (WorkerLevel)obj;
			writer.WritePrivateField("_level", objectContainingField);
			writer.WritePrivateField("_experience", objectContainingField);
			writer.WritePrivateField("_experienceMultiplicator", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			WorkerLevel objectContainingField = (WorkerLevel)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_level":
					objectContainingField = (WorkerLevel)reader.SetPrivateField("_level", reader.Read<NumericStatistic>(), objectContainingField);
					break;
				case "_experience":
					objectContainingField = (WorkerLevel)reader.SetPrivateField("_experience", reader.Read<NumericStatistic>(), objectContainingField);
					break;
				case "_experienceMultiplicator":
					objectContainingField = (WorkerLevel)reader.SetPrivateField("_experienceMultiplicator", reader.Read<NumericStatistic>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
