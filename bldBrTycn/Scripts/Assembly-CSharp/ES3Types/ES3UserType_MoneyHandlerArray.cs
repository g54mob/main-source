using CTS;

namespace ES3Types
{
	public class ES3UserType_MoneyHandlerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MoneyHandlerArray()
			: base(typeof(MoneyHandler[]), ES3UserType_MoneyHandler.Instance)
		{
			Instance = this;
		}
	}
}
