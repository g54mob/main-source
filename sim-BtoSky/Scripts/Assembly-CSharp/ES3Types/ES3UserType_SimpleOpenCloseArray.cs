using Suburb;

namespace ES3Types
{
	public class ES3UserType_SimpleOpenCloseArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SimpleOpenCloseArray()
			: base(typeof(SimpleOpenClose[]), ES3UserType_SimpleOpenClose.Instance)
		{
			Instance = this;
		}
	}
}
