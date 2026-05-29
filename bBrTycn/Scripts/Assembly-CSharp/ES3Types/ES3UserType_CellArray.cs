using CTS;

namespace ES3Types
{
	public class ES3UserType_CellArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CellArray()
			: base(typeof(Cell[]), ES3UserType_Cell.Instance)
		{
			Instance = this;
		}
	}
}
