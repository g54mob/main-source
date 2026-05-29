using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_ContextualFSMArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ContextualFSMArray()
			: base(typeof(ContextualFSM[]), ES3UserType_ContextualFSM.Instance)
		{
			Instance = this;
		}
	}
}
