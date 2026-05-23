namespace ES3Types
{
	public class ES3UserType_QuestUIArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestUIArray()
			: base(typeof(QuestUI[]), ES3UserType_QuestUI.Instance)
		{
			Instance = this;
		}
	}
}
