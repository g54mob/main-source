namespace ES3Types
{
	public class ES3UserType_TutorialSaveDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TutorialSaveDataArray()
			: base(typeof(TutorialSaveData[]), ES3UserType_TutorialSaveData.Instance)
		{
			Instance = this;
		}
	}
}
