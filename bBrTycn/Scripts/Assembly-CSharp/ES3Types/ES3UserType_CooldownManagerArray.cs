using CTS.Utilities;

namespace ES3Types
{
	public class ES3UserType_CooldownManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CooldownManagerArray()
			: base(typeof(CooldownManager[]), ES3UserType_CooldownManager.Instance)
		{
			Instance = this;
		}
	}
}
