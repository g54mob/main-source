using CTS;

namespace ES3Types
{
	public class ES3UserType_RoomObjectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_RoomObjectArray()
			: base(typeof(RoomObject[]), ES3UserType_RoomObject.Instance)
		{
			Instance = this;
		}
	}
}
