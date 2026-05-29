using CTS;

namespace ES3Types
{
	public class ES3UserType_TransactionsHandlersArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TransactionsHandlersArray()
			: base(typeof(TransactionsHandlers[]), ES3UserType_TransactionsHandlers.Instance)
		{
			Instance = this;
		}
	}
}
