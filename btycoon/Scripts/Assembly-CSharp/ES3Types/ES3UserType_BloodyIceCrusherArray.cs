using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodyIceCrusherArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyIceCrusherArray()
			: base(typeof(BloodyIceCrusher[]), ES3UserType_BloodyIceCrusher.Instance)
		{
			Instance = this;
		}
	}
}
