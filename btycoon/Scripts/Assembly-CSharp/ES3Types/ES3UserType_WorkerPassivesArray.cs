using CTS;

namespace ES3Types
{
	public class ES3UserType_WorkerPassivesArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerPassivesArray()
			: base(typeof(WorkerPassives[]), ES3UserType_WorkerPassives.Instance)
		{
			Instance = this;
		}
	}
}
