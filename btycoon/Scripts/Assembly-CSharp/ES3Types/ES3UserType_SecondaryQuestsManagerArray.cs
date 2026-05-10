using CTS;

namespace ES3Types
{
	public class ES3UserType_SecondaryQuestsManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SecondaryQuestsManagerArray()
			: base(typeof(SecondaryQuestsManager[]), ES3UserType_SecondaryQuestsManager.Instance)
		{
			Instance = this;
		}
	}
}
