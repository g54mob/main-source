using System.Collections.Generic;
using mattmc3.dotmore.Collections.Generic;

public class RplCompiler
{
	public class CachedCompile
	{
		public string scriptName;

		public string resultMessage;

		public List<RplCore.Command> commands;

		public Dictionary<string, int> funcTable;

		public OrderedDictionary2<string, RplCore.Data> inputVars;

		public HashSet<string> hiddenInputVars;
	}

	private struct Token
	{
		public string tok;

		public int lineNumber;

		public Token(string tok, int lineNumber)
		{
			this.tok = null;
			this.lineNumber = 0;
		}
	}

	private List<RplCore.Command> commands;

	private Dictionary<string, int> funcTable;

	private string ReplaceNotInQuotes(string src, string what, string with)
	{
		return null;
	}

	private RplCore.Data ParseInputVar(Token tok, string varValue, out string resultMessage)
	{
		resultMessage = null;
		return null;
	}

	public bool Compile(CPack cpack, string scriptName, string program, out string resultMessage, out List<RplCore.Command> commands, out Dictionary<string, int> funcTable, out OrderedDictionary2<string, RplCore.Data> inputVars, out HashSet<string> hiddenInputVars, bool overwriteCache = false)
	{
		resultMessage = null;
		commands = null;
		funcTable = null;
		inputVars = null;
		hiddenInputVars = null;
		return false;
	}

	private static List<Token> SplitIntoTokens(string stringToSplit, params char[] delimiters)
	{
		return null;
	}

	private void HandleTranspositions()
	{
	}

	private string HandleProperties()
	{
		return null;
	}

	private string HandleListIndexes()
	{
		return null;
	}

	private string HandleTables()
	{
		return null;
	}

	private bool SecondPass(out string message)
	{
		message = null;
		return false;
	}

	private bool ValidateCalls(out string message)
	{
		message = null;
		return false;
	}

	private bool WarpValidateScript(out string message)
	{
		message = null;
		return false;
	}

	private bool BracketValidateScript(out string message)
	{
		message = null;
		return false;
	}

	private bool BraceValidateScript(out string message)
	{
		message = null;
		return false;
	}

	private bool ValidateScript(out string message)
	{
		message = null;
		return false;
	}

	private RplCore.Command AppendCommand(RplCore.STATEMENT statement, int lineNumber)
	{
		return default(RplCore.Command);
	}

	private RplCore.Command AppendCommand(RplCore.STATEMENT statement, int arg, int lineNumber)
	{
		return default(RplCore.Command);
	}

	private RplCore.Command AppendCommand(RplCore.STATEMENT statement, float arg, int lineNumber)
	{
		return default(RplCore.Command);
	}

	private RplCore.Command AppendCommand(RplCore.STATEMENT statement, string arg, int lineNumber)
	{
		return default(RplCore.Command);
	}

	private RplCore.Command AppendCommand(RplCore.STATEMENT statement, string arg, int metaData, int lineNumber)
	{
		return default(RplCore.Command);
	}

	private void DeleteCommand(int index)
	{
	}

	private int FindJumpPoint(int currentCommandIndex)
	{
		return 0;
	}

	private int FindCloseTran(int currentCommandIndex)
	{
		return 0;
	}

	private int FindCloseBracket(int currentCommandIndex)
	{
		return 0;
	}

	private int FindCloseBrace(int currentCommandIndex)
	{
		return 0;
	}

	private int FindLoop(int currentCommandIndex)
	{
		return 0;
	}

	private int FindEndOnce(int currentCommandIndex)
	{
		return 0;
	}

	private int FindEndWhile(int currentCommandIndex)
	{
		return 0;
	}

	private int FindEndSwitch(int currentCommandIndex)
	{
		return 0;
	}

	private int FindEndCase(int currentCommandIndex)
	{
		return 0;
	}

	private int FindDoOrEndWhile(int currentCommandIndex)
	{
		return 0;
	}
}
