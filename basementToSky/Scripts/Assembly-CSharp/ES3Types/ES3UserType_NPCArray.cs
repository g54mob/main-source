namespace ES3Types
{
	public class ES3UserType_NPCArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_NPCArray()
			: base(typeof(NPC[]), ES3UserType_NPC.Instance)
		{
			Instance = this;
		}
	}
}
