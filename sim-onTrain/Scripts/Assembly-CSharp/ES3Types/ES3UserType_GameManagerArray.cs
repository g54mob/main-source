namespace ES3Types
{
	public class ES3UserType_GameManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameManagerArray()
			: base(typeof(TrainGameManager[]), ES3UserType_GameManager.Instance)
		{
			Instance = this;
		}
	}
}
