namespace ES3Types
{
	public class ES3UserType_InitalizerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_InitalizerArray()
			: base(typeof(Initalizer[]), ES3UserType_Initalizer.Instance)
		{
			Instance = this;
		}
	}
}
