using CTS;

namespace ES3Types
{
	public class ES3UserType_MaeveExterminationArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MaeveExterminationArray()
			: base(typeof(MaeveExtermination[]), ES3UserType_MaeveExtermination.Instance)
		{
			Instance = this;
		}
	}
}
