namespace ES3Types
{
	public class ES3UserType_RocketMotorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_RocketMotorArray()
			: base(typeof(RocketMotor[]), ES3UserType_RocketMotor.Instance)
		{
			Instance = this;
		}
	}
}
