using CTS;

namespace ES3Types
{
	public class ES3UserType_PunchingBallArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PunchingBallArray()
			: base(typeof(PunchingBall[]), ES3UserType_PunchingBall.Instance)
		{
			Instance = this;
		}
	}
}
