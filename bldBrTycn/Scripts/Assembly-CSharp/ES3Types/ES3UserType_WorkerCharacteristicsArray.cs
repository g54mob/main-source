using CTS;

namespace ES3Types
{
	public class ES3UserType_WorkerCharacteristicsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerCharacteristicsArray()
			: base(typeof(WorkerCharacteristics[]), ES3UserType_WorkerCharacteristics.Instance)
		{
			Instance = this;
		}
	}
}
