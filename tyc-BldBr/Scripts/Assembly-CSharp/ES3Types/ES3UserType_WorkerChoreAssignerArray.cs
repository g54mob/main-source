using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_WorkerChoreAssignerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerChoreAssignerArray()
			: base(typeof(WorkerChoreAssigner[]), ES3UserType_WorkerChoreAssigner.Instance)
		{
			Instance = this;
		}
	}
}
