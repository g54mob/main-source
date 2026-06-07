using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodyWineBarrelArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyWineBarrelArray()
			: base(typeof(BloodyWineBarrel[]), ES3UserType_BloodyWineBarrel.Instance)
		{
			Instance = this;
		}
	}
}
