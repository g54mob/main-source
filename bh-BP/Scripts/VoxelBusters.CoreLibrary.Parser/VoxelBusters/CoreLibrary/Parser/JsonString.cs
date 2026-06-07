namespace VoxelBusters.CoreLibrary.Parser
{
	public class JsonString
	{
		public string Value { get; private set; }

		public bool IsNullOrEmpty { get; private set; }

		public int Length { get; private set; }

		public char this[int index] => '\0';

		public JsonString(string value)
		{
		}
	}
}
