using CTS;

namespace ES3Types
{
	public class ES3UserType_JunkObjectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_JunkObjectArray()
			: base(typeof(JunkObject[]), ES3UserType_JunkObject.Instance)
		{
			Instance = this;
		}
	}
}
