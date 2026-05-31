using CTS;

namespace ES3Types
{
	public class ES3UserType_FurnitureControllerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_FurnitureControllerArray()
			: base(typeof(FurnitureController[]), ES3UserType_FurnitureController.Instance)
		{
			Instance = this;
		}
	}
}
