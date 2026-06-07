using System.IO;
using System.Text;

namespace LitJson
{
	internal class Lexer
	{
		private delegate bool StateHandler(FsmContext ctx);

		private static int[] returnTable;

		private static StateHandler[] handlerTable;

		private int inputBuffer;

		private int inputChar;

		private int state;

		private int unichar;

		private FsmContext context;

		private TextReader reader;

		private StringBuilder stringBuffer;

		public bool AllowComments { get; set; }

		public bool AllowSingleQuotedStrings { get; set; }

		public bool EndOfInput { get; private set; }

		public int Token { get; private set; }

		public string StringValue { get; private set; }

		static Lexer()
		{
		}

		public Lexer(TextReader reader)
		{
		}

		private static int HexValue(int digit)
		{
			return 0;
		}

		private static void PopulateFsmTables()
		{
		}

		private static char ProcessEscChar(int escChar)
		{
			return '\0';
		}

		private static bool State1(FsmContext ctx)
		{
			return false;
		}

		private static bool State2(FsmContext ctx)
		{
			return false;
		}

		private static bool State3(FsmContext ctx)
		{
			return false;
		}

		private static bool State4(FsmContext ctx)
		{
			return false;
		}

		private static bool State5(FsmContext ctx)
		{
			return false;
		}

		private static bool State6(FsmContext ctx)
		{
			return false;
		}

		private static bool State7(FsmContext ctx)
		{
			return false;
		}

		private static bool State8(FsmContext ctx)
		{
			return false;
		}

		private static bool State9(FsmContext ctx)
		{
			return false;
		}

		private static bool State10(FsmContext ctx)
		{
			return false;
		}

		private static bool State11(FsmContext ctx)
		{
			return false;
		}

		private static bool State12(FsmContext ctx)
		{
			return false;
		}

		private static bool State13(FsmContext ctx)
		{
			return false;
		}

		private static bool State14(FsmContext ctx)
		{
			return false;
		}

		private static bool State15(FsmContext ctx)
		{
			return false;
		}

		private static bool State16(FsmContext ctx)
		{
			return false;
		}

		private static bool State17(FsmContext ctx)
		{
			return false;
		}

		private static bool State18(FsmContext ctx)
		{
			return false;
		}

		private static bool State19(FsmContext ctx)
		{
			return false;
		}

		private static bool State20(FsmContext ctx)
		{
			return false;
		}

		private static bool State21(FsmContext ctx)
		{
			return false;
		}

		private static bool State22(FsmContext ctx)
		{
			return false;
		}

		private static bool State23(FsmContext ctx)
		{
			return false;
		}

		private static bool State24(FsmContext ctx)
		{
			return false;
		}

		private static bool State25(FsmContext ctx)
		{
			return false;
		}

		private static bool State26(FsmContext ctx)
		{
			return false;
		}

		private static bool State27(FsmContext ctx)
		{
			return false;
		}

		private static bool State28(FsmContext ctx)
		{
			return false;
		}

		private bool GetChar()
		{
			return false;
		}

		private int NextChar()
		{
			return 0;
		}

		public bool NextToken()
		{
			return false;
		}

		private void UngetChar()
		{
		}
	}
}
