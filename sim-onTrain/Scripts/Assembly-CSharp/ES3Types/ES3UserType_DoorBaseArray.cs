namespace ES3Types
{
	public class ES3UserType_DoorBaseArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DoorBaseArray()
			: base(typeof(DoorBase[]), ES3UserType_DoorBase.Instance)
		{
			Instance = this;
		}
	}
}
