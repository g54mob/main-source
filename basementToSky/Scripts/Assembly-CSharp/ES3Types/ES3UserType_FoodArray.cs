namespace ES3Types
{
	public class ES3UserType_FoodArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_FoodArray()
			: base(typeof(Food[]), ES3UserType_Food.Instance)
		{
			Instance = this;
		}
	}
}
