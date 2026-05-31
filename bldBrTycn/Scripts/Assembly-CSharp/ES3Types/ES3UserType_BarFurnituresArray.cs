using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_BarFurnituresArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BarFurnituresArray()
			: base(typeof(BarFurnitures[]), ES3UserType_BarFurnitures.Instance)
		{
			Instance = this;
		}
	}
}
