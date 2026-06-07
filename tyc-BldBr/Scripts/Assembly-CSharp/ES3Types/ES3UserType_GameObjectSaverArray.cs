using CTS;

namespace ES3Types
{
	public class ES3UserType_GameObjectSaverArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameObjectSaverArray()
			: base(typeof(GameObjectSaver[]), ES3UserType_GameObjectSaver.Instance)
		{
			Instance = this;
		}
	}
}
