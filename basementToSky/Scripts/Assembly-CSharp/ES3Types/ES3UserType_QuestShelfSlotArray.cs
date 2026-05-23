namespace ES3Types
{
	public class ES3UserType_QuestShelfSlotArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestShelfSlotArray()
			: base(typeof(QuestShelfSlot[]), ES3UserType_QuestShelfSlot.Instance)
		{
			Instance = this;
		}
	}
}
