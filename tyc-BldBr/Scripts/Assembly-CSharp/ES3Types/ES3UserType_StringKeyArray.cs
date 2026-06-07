using CTS.Core;

namespace ES3Types
{
	public class ES3UserType_StringKeyArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StringKeyArray()
			: base(typeof(StringKey[]), ES3UserType_StringKey.Instance)
		{
			Instance = this;
		}
	}
}
