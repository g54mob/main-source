using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodyExpressoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyExpressoArray()
			: base(typeof(BloodyExpresso[]), ES3UserType_BloodyExpresso.Instance)
		{
			Instance = this;
		}
	}
}
