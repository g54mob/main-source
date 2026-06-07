using CTS;

namespace ES3Types
{
	public class ES3UserType_SaveFinanceGraphArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SaveFinanceGraphArray()
			: base(typeof(SaveFinanceGraph[]), ES3UserType_SaveFinanceGraph.Instance)
		{
			Instance = this;
		}
	}
}
