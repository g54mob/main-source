using System.Collections;

namespace SevenZip.CommandLineParser
{
	public class Parser
	{
		public ArrayList NonSwitchStrings;

		private SwitchResult[] _switches;

		private const char kSwitchID1 = '-';

		private const char kSwitchID2 = '/';

		private const char kSwitchMinus = '-';

		private const string kStopSwitchParsing = "--";

		public SwitchResult Item => null;

		public Parser(int numSwitches)
		{
		}

		private bool ParseString(string srcString, SwitchForm[] switchForms)
		{
			return false;
		}

		public void ParseStrings(SwitchForm[] switchForms, string[] commandStrings)
		{
		}

		public static int ParseCommand(CommandForm[] commandForms, string commandString, out string postString)
		{
			postString = null;
			return 0;
		}

		private static bool ParseSubCharsCommand(int numForms, CommandSubCharsSet[] forms, string commandString, ArrayList indices)
		{
			return false;
		}

		private static bool IsItSwitchChar(char c)
		{
			return false;
		}
	}
}
