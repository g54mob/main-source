using CTS;

namespace ES3Types
{
	public class ES3UserType_FreemodeProfileArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_FreemodeProfileArray()
			: base(typeof(FreemodeProfile[]), ES3UserType_FreemodeProfile.Instance)
		{
			Instance = this;
		}
	}
}
