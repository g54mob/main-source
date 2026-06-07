namespace ES3Types
{
	public class ES3UserType_OutlineArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_OutlineArray()
			: base(typeof(Outline[]), ES3UserType_Outline.Instance)
		{
			Instance = this;
		}
	}
}
