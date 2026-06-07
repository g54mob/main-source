using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodyArcadeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyArcadeArray()
			: base(typeof(BloodyArcade[]), ES3UserType_BloodyArcade.Instance)
		{
			Instance = this;
		}
	}
}
