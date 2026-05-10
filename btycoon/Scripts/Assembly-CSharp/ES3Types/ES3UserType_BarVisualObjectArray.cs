using CTS;

namespace ES3Types
{
	public class ES3UserType_BarVisualObjectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BarVisualObjectArray()
			: base(typeof(BarVisualObject[]), ES3UserType_BarVisualObject.Instance)
		{
			Instance = this;
		}
	}
}
