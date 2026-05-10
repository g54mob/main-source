using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_CleanableObjectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CleanableObjectArray()
			: base(typeof(CleanableObject[]), ES3UserType_CleanableObject.Instance)
		{
			Instance = this;
		}
	}
}
