using CTS;

namespace ES3Types
{
	public class ES3UserType_SyncManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SyncManagerArray()
			: base(typeof(SyncManager[]), ES3UserType_SyncManager.Instance)
		{
			Instance = this;
		}
	}
}
