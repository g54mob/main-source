using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodyTeaBagArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyTeaBagArray()
			: base(typeof(BloodyTeaBag[]), ES3UserType_BloodyTeaBag.Instance)
		{
			Instance = this;
		}
	}
}
