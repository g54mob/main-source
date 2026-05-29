using CTS;

namespace ES3Types
{
	public class ES3UserType_CircumstantialQuestsManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CircumstantialQuestsManagerArray()
			: base(typeof(CircumstantialQuestsManager[]), ES3UserType_CircumstantialQuestsManager.Instance)
		{
			Instance = this;
		}
	}
}
