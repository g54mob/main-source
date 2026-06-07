using CTS.Utilities;
using ES3Types;

namespace CTS
{
	public class ES3UserType_GameTimeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameTimeArray()
			: base(typeof(GameTime[]), ES3UserType_GameTime.Instance)
		{
			Instance = this;
		}
	}
}
