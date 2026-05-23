namespace ES3Types
{
	public class ES3UserType_ParttimeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ParttimeArray()
			: base(typeof(Parttime[]), ES3UserType_Parttime.Instance)
		{
			Instance = this;
		}
	}
}
