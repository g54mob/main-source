namespace ES3Types
{
	public class ES3UserType_QuestIndicatorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestIndicatorArray()
			: base(typeof(QuestIndicator[]), ES3UserType_QuestIndicator.Instance)
		{
			Instance = this;
		}
	}
}
