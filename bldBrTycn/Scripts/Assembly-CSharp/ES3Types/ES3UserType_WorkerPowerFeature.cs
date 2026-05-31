using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_power" })]
	public class ES3UserType_WorkerPowerFeature : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerPowerFeature()
			: base(typeof(WorkerPowerFeature))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			WorkerPowerFeature objectContainingField = (WorkerPowerFeature)obj;
			writer.WritePrivateField("_power", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			WorkerPowerFeature objectContainingField = (WorkerPowerFeature)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_power")
				{
					objectContainingField = (WorkerPowerFeature)reader.SetPrivateField("_power", reader.Read<WorkerPowerFeature.e_PowerFeatures>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
