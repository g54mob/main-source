namespace DevCmdLine
{
	public class DevCmdArg
	{
		public string name = "";

		public string[] values;

		public bool hasName => !string.IsNullOrEmpty(name);

		public bool hasValue => values.Length != 0;

		public string value
		{
			get
			{
				if (values.Length == 0)
				{
					return "";
				}
				return values[0];
			}
		}
	}
}
