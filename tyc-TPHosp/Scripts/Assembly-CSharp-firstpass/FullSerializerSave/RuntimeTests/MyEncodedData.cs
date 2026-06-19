namespace FullSerializerSave.RuntimeTests
{
	public class MyEncodedData
	{
		public string value;

		private MyEncodedData()
		{
		}

		public static MyEncodedData Make(string value)
		{
			return new MyEncodedData
			{
				value = value
			};
		}
	}
}
