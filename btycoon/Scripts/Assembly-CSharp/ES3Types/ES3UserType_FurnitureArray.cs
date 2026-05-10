using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_FurnitureArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_FurnitureArray()
			: base(typeof(Furniture[]), ES3UserType_Furniture.Instance)
		{
			Instance = this;
		}
	}
}
