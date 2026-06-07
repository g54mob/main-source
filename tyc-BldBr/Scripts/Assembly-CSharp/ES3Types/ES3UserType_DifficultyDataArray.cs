using CTS;

namespace ES3Types
{
	public class ES3UserType_DifficultyDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DifficultyDataArray()
			: base(typeof(DifficultyData[]), ES3UserType_DifficultyData.Instance)
		{
			Instance = this;
		}
	}
}
