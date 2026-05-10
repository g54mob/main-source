using CTS;

namespace ES3Types
{
	public class ES3UserType_ChargesHandlersArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ChargesHandlersArray()
			: base(typeof(ChargesHandlers[]), ES3UserType_ChargesHandlers.Instance)
		{
			Instance = this;
		}
	}
}
