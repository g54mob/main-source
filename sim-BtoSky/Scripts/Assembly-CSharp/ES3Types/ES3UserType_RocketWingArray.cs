namespace ES3Types
{
	public class ES3UserType_RocketWingArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_RocketWingArray()
			: base(typeof(RocketWing[]), ES3UserType_RocketWing.Instance)
		{
			Instance = this;
		}
	}
}
