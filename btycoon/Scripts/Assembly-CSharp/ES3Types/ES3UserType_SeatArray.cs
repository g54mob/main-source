using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_SeatArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SeatArray()
			: base(typeof(Seat[]), ES3UserType_Seat.Instance)
		{
			Instance = this;
		}
	}
}
