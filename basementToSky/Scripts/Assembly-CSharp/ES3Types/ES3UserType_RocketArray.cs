namespace ES3Types
{
	public class ES3UserType_RocketArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_RocketArray()
			: base(typeof(Rocket[]), ES3UserType_Rocket.Instance)
		{
			Instance = this;
		}
	}
}
