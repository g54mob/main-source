namespace ES3Types
{
	public class ES3UserType_GroceryArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GroceryArray()
			: base(typeof(Grocery[]), ES3UserType_Grocery.Instance)
		{
			Instance = this;
		}
	}
}
