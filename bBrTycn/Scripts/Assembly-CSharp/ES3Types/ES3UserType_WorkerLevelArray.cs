using CTS;

namespace ES3Types
{
	public class ES3UserType_WorkerLevelArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerLevelArray()
			: base(typeof(WorkerLevel[]), ES3UserType_WorkerLevel.Instance)
		{
			Instance = this;
		}
	}
}
