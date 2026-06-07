namespace SevenZip.CommandLineParser
{
	public class SwitchForm
	{
		public string IDString;

		public SwitchType Type;

		public bool Multi;

		public int MinLen;

		public int MaxLen;

		public string PostCharSet;

		public SwitchForm(string idString, SwitchType type, bool multi, int minLen, int maxLen, string postCharSet)
		{
		}

		public SwitchForm(string idString, SwitchType type, bool multi, int minLen)
		{
		}

		public SwitchForm(string idString, SwitchType type, bool multi)
		{
		}
	}
}
