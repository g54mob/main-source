using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_TableArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TableArray()
			: base(typeof(Table[]), ES3UserType_Table.Instance)
		{
			Instance = this;
		}
	}
}
