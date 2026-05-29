using CTS;

namespace ES3Types
{
	public class ES3UserType_VigilanceHandlersArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_VigilanceHandlersArray()
			: base(typeof(VigilanceHandlers[]), ES3UserType_VigilanceHandlers.Instance)
		{
			Instance = this;
		}
	}
}
