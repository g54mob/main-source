using CTS;

namespace ES3Types
{
	public class ES3UserType_Level01QuestChainArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_Level01QuestChainArray()
			: base(typeof(Level01QuestChain[]), ES3UserType_Level01QuestChain.Instance)
		{
			Instance = this;
		}
	}
}
