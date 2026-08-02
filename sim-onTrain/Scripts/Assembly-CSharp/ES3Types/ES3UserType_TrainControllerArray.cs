namespace ES3Types
{
	public class ES3UserType_TrainControllerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TrainControllerArray()
			: base(typeof(TrainController[]), ES3UserType_TrainController.Instance)
		{
			Instance = this;
		}
	}
}
