namespace ES3Types
{
	public class ES3UserType_RocketMountArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_RocketMountArray()
			: base(typeof(RocketMount[]), ES3UserType_RocketMount.Instance)
		{
			Instance = this;
		}
	}
}
