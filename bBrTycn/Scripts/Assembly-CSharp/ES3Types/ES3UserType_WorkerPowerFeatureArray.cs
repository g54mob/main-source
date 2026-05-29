using CTS;

namespace ES3Types
{
	public class ES3UserType_WorkerPowerFeatureArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerPowerFeatureArray()
			: base(typeof(WorkerPowerFeature[]), ES3UserType_WorkerPowerFeature.Instance)
		{
			Instance = this;
		}
	}
}
