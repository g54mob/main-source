using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_WorkerChoreHubArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerChoreHubArray()
			: base(typeof(WorkerChoreHub[]), ES3UserType_WorkerChoreHub.Instance)
		{
			Instance = this;
		}
	}
}
