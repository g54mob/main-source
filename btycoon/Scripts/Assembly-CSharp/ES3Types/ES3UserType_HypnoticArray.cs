using CTS;

namespace ES3Types
{
	public class ES3UserType_HypnoticArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_HypnoticArray()
			: base(typeof(Hypnotic[]), ES3UserType_Hypnotic.Instance)
		{
			Instance = this;
		}
	}
}
