namespace ES3Types
{
	public class ES3UserType_MyTubeVideoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MyTubeVideoArray()
			: base(typeof(MyTubeVideo[]), ES3UserType_MyTubeVideo.Instance)
		{
			Instance = this;
		}
	}
}
