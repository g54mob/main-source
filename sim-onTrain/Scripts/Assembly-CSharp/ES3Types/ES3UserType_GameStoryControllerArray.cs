namespace ES3Types
{
	public class ES3UserType_GameStoryControllerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameStoryControllerArray()
			: base(typeof(GameStoryController[]), ES3UserType_GameStoryController.Instance)
		{
			Instance = this;
		}
	}
}
