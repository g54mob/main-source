using CTS;

namespace ES3Types
{
	public class ES3UserType_SavePrestigeGraphDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SavePrestigeGraphDataArray()
			: base(typeof(SavePrestigeGraphData[]), ES3UserType_SavePrestigeGraphData.Instance)
		{
			Instance = this;
		}
	}
}
