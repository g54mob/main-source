using CTS.Utilities;
using ES3Types;

namespace CTS
{
	public class ES3UserType_UnscaledGameTimeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_UnscaledGameTimeArray()
			: base(typeof(UnscaledGameTime[]), ES3UserType_UnscaledGameTime.Instance)
		{
			Instance = this;
		}
	}
}
