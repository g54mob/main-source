using System.Collections.Generic;

public class sceCode
{
	private class ErrorEntry
	{
		public string shortCode;

		public string longCode;

		public string descriptionJap;

		public string description;

		public ErrorEntry(string _shortCode, string _longCode, string _descriptionJap, string _description)
		{
		}
	}

	private uint errorCode;

	private static Dictionary<uint, ErrorEntry> errorDictionary;

	private static bool checkedErrorFile;

	public static implicit operator sceCode(long code)
	{
		return null;
	}

	private static void readErrorFile()
	{
	}

	public sceCode(uint code)
	{
	}

	public sceCode(long code)
	{
	}

	public override string ToString()
	{
		return null;
	}
}
