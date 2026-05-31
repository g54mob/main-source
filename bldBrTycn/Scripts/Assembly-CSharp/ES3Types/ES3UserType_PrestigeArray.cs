using CTS;

namespace ES3Types
{
	public class ES3UserType_PrestigeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PrestigeArray()
			: base(typeof(Prestige[]), ES3UserType_Prestige.Instance)
		{
			Instance = this;
		}
	}
}
