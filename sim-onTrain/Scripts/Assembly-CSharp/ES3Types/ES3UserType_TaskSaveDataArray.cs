namespace ES3Types
{
	public class ES3UserType_TaskSaveDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TaskSaveDataArray()
			: base(typeof(TaskSaveData[]), ES3UserType_TaskSaveData.Instance)
		{
			Instance = this;
		}
	}
}
