using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_WorkerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerArray()
			: base(typeof(Worker[]), ES3UserType_Worker.Instance)
		{
			Instance = this;
		}
	}
}
