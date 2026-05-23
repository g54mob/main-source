namespace MG_BlocksEngine2.Block
{
	public class BE2_InputValues
	{
		public bool isText;

		public string stringValue;

		public float floatValue;

		public BE2_InputValues(string stringValue, float floatValue, bool isText)
		{
			this.isText = isText;
			this.stringValue = stringValue;
			this.floatValue = floatValue;
		}
	}
}
