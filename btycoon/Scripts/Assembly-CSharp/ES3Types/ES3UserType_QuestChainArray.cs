using CTS;

namespace ES3Types
{
	public class ES3UserType_QuestChainArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_QuestChainArray()
			: base(typeof(QuestChain[]), ES3UserType_QuestChain.Instance)
		{
			Instance = this;
		}
	}
}
