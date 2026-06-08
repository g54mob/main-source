using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using UnityEngine;

namespace Stonescript.Compiler
{
	[GeneratedCode("ANTLR", "4.9.1")]
	[CLSCompliant(false)]
	public class StonescriptLexer : Lexer
	{
		protected static DFA[] decisionToDFA;

		protected static PredictionContextCache sharedContextCache;

		public const int INDENT = 1;

		public const int DEDENT = 2;

		public const int COMMAND = 3;

		public const int ASCII_BLOCK = 4;

		public const int VAR = 5;

		public const int CONST = 6;

		public const int NEW = 7;

		public const int IMPORT = 8;

		public const int THIS = 9;

		public const int TRUE = 10;

		public const int FALSE = 11;

		public const int NULL = 12;

		public const int FUNCTION = 13;

		public const int RETURN = 14;

		public const int FOR = 15;

		public const int IN = 16;

		public const int GREATER_THAN_EQUAL = 17;

		public const int LESS_THAN = 18;

		public const int LESS_THAN_EQUAL = 19;

		public const int LPAREN = 20;

		public const int RPAREN = 21;

		public const int LBRACKET = 22;

		public const int RBRACKET = 23;

		public const int LCBRACKET = 24;

		public const int RCBRACKET = 25;

		public const int BREAK = 26;

		public const int CONTINUE = 27;

		public const int EQUAL = 28;

		public const int DOUBLE_EQUAL = 29;

		public const int PLUS = 30;

		public const int MINUS = 31;

		public const int MULTIPLY = 32;

		public const int DIVIDE = 33;

		public const int PLUS_EQUAL = 34;

		public const int MINUS_EQUAL = 35;

		public const int MULTIPLY_EQUAL = 36;

		public const int DIVIDE_EQUAL = 37;

		public const int INCREMENT = 38;

		public const int DECREMENT = 39;

		public const int NOT = 40;

		public const int NOT_EQUAL = 41;

		public const int OR = 42;

		public const int AND = 43;

		public const int DOUBLE_OR = 44;

		public const int DOUBLE_AND = 45;

		public const int COLON = 46;

		public const int QUESTION = 47;

		public const int MOD = 48;

		public const int COMMA = 49;

		public const int DOUBLE_DOT = 50;

		public const int DOT = 51;

		public const int HASH = 52;

		public const int GREATER_THAN = 53;

		public const int LINE_COMMENT = 54;

		public const int BLOCK_COMMENT = 55;

		public const int NUMBER = 56;

		public const int ID = 57;

		public const int COLOR = 58;

		public const int PATH = 59;

		public const int STRING_LITERAL = 60;

		public const int UNQUOTED_STRING = 61;

		public const int LINE_CONT = 62;

		public const int NEWLINE = 63;

		public const int WS = 64;

		public const int INVALID = 65;

		public const int COMMAND_COMMA_SEP = 66;

		public const int COMMAND_COMMA_ASCII_BLOCK = 67;

		public const int COMMAND_COMMA_PARAM = 68;

		public const int COMMAND_COMMA_LINE_CONT = 69;

		public const int COMMAND_COMMA_NEWLINE = 70;

		public const int COMMAND_SPACE_SEP = 71;

		public const int COMMAND_SPACE_ASCII_BLOCK = 72;

		public const int COMMAND_SPACE_PARAM = 73;

		public const int COMMAND_SPACE_LINE_CONT = 74;

		public const int COMMAND_SPACE_NEWLINE = 75;

		public const int COMMENT = 2;

		public const int COMMAND_MODE_COMMA = 1;

		public const int COMMAND_MODE_SPACE = 2;

		public static string[] channelNames;

		public static string[] modeNames;

		public static readonly string[] ruleNames;

		private List<IToken> tokens = new List<IToken>();

		private List<int> indents = new List<int>();

		private int opened;

		private bool started;

		private IToken lastToken;

		public List<string> registeredCommands = new List<string>();

		public static int spacesPerTab;

		private static readonly string[] _LiteralNames;

		private static readonly string[] _SymbolicNames;

		public static readonly IVocabulary DefaultVocabulary;

		private static char[] _serializedATN;

		public static readonly ATN _ATN;

		[NotNull]
		public override IVocabulary Vocabulary => DefaultVocabulary;

		public override string GrammarFileName => "StonescriptLexer.g4";

		public override string[] RuleNames => ruleNames;

		public override string[] ChannelNames => channelNames;

		public override string[] ModeNames => modeNames;

		public override string SerializedAtn => new string(_serializedATN);

		public override void Emit(IToken t)
		{
			base.Token = t;
			tokens.Add(t);
		}

		public override void Reset()
		{
			tokens.Clear();
			indents.Clear();
			opened = 0;
			started = false;
			lastToken = null;
			base.Reset();
		}

		public override IToken NextToken()
		{
			if (InputStream.LA(1) == -1 && indents.Count > 0)
			{
				for (int num = tokens.Count - 1; num >= 0; num--)
				{
					if (tokens[num].Type == -1)
					{
						tokens.RemoveAt(num);
					}
				}
				Emit(commonToken(63, "\n"));
				while (indents.Count > 0)
				{
					Emit(createDedent());
					indents.RemoveAt(indents.Count - 1);
				}
				Emit(commonToken(-1, "<EOF>"));
			}
			IToken token = base.NextToken();
			if (token.Channel == 0)
			{
				lastToken = token;
			}
			if (tokens.Count == 0)
			{
				return token;
			}
			IToken result = tokens[0];
			tokens.RemoveAt(0);
			return result;
		}

		private IToken createDedent()
		{
			CommonToken commonToken = this.commonToken(2, "");
			if (lastToken != null)
			{
				commonToken.Line = lastToken.Line;
			}
			else
			{
				Debug.LogError("Bad parsing in lexer. 'lastToken' is null.");
			}
			return commonToken;
		}

		private CommonToken commonToken(int type, string text)
		{
			int num = CharIndex - 1;
			int start = (string.IsNullOrEmpty(text) ? num : (num - text.Length + 1));
			return new CommonToken(Tuple.Create((ITokenSource)this, (ICharStream)InputStream), type, 0, start, num);
		}

		private void processNewline()
		{
			string text = Regex.Replace(Text, "[^\r\n\f]+", "");
			string text2 = Regex.Replace(Text, "[\r\n\f]+", "");
			int num = InputStream.LA(1);
			int num2 = InputStream.LA(2);
			if (opened > 0 || (num2 != -1 && (num == 13 || num == 10 || num == 12 || (num == 47 && (num2 == 47 || num2 == 42)))))
			{
				Skip();
				return;
			}
			if (num == 46)
			{
				Skip();
				return;
			}
			Emit(commonToken(63, text));
			int indentationCount = getIndentationCount(text2);
			int num3 = ((indents.Count != 0) ? indents[indents.Count - 1] : 0);
			if (indentationCount == num3)
			{
				Skip();
			}
			else if (indentationCount > num3)
			{
				indents.Add(indentationCount);
				Emit(commonToken(1, text2));
			}
			else if (indentationCount == 0)
			{
				while (indents.Count > 0)
				{
					Emit(createDedent());
					indents.RemoveAt(indents.Count - 1);
				}
			}
			else if ((indents.Count < 2 && indentationCount > 0) || (indents.Count >= 2 && indentationCount > indents[indents.Count - 2]))
			{
				indents[indents.Count - 1] = indentationCount;
			}
			else
			{
				while (indents.Count >= 2 && indents[indents.Count - 2] >= indentationCount)
				{
					Emit(createDedent());
					indents.RemoveAt(indents.Count - 1);
				}
			}
		}

		private static int getIndentationCount(string spaces)
		{
			int num = 0;
			for (int i = 0; i < spaces.Length; i++)
			{
				num = ((spaces[i] != '\t') ? (num + 1) : (num + (spacesPerTab - num % spacesPerTab)));
			}
			return num;
		}

		private void CheckCommandMode(int cmdMode)
		{
			if (isCommand())
			{
				Emit(commonToken(3, Text));
				int num = InputStream.LA(1);
				if (num != -1 && num != 13 && num != 10)
				{
					Mode(cmdMode);
				}
			}
		}

		private bool atStartOfInput()
		{
			if (base.Column == 0)
			{
				return base.Line == 1;
			}
			return false;
		}

		private bool atStartOfLine()
		{
			IToken token = lastToken;
			if (tokens.Count > 0)
			{
				token = tokens[tokens.Count - 1];
			}
			_ = token?.Type;
			if (token != null && token.Type != 63 && token.Type != 1)
			{
				return token.Type == 2;
			}
			return true;
		}

		private void mode(int newMode)
		{
			Mode(newMode);
		}

		private bool atEndOfLineOr(int delimiter)
		{
			int num = InputStream.LA(1);
			bool flag = num == 13 || num == 10 || num == delimiter || num == -1;
			if (!flag && num == 47)
			{
				int num2 = InputStream.LA(2);
				flag = num2 == 47 || num2 == 42;
			}
			return flag;
		}

		private bool atEndOfLine()
		{
			int num = InputStream.LA(1);
			bool flag = num == 13 || num == 10 || num == -1;
			if (!flag && num == 47)
			{
				int num2 = InputStream.LA(2);
				flag = num2 == 47 || num2 == 42;
			}
			return flag;
		}

		private bool isCommand()
		{
			if (!atStartOfLine())
			{
				return false;
			}
			string text = Text;
			if (text[0] == '>')
			{
				return true;
			}
			text = text.ToLower();
			if (registeredCommands.Contains(text))
			{
				return true;
			}
			return false;
		}

		private int getLastToken()
		{
			IToken token = lastToken;
			if (tokens.Count > 0)
			{
				token = tokens[tokens.Count - 1];
			}
			int result = -1;
			if (token != null)
			{
				result = token.Type;
			}
			return result;
		}

		private bool canBePath()
		{
			if (!atEndOfLineOr(44) || atStartOfLine())
			{
				return false;
			}
			int num = getLastToken();
			if (num == 8 || num == 7)
			{
				return true;
			}
			return false;
		}

		private bool canBeColor()
		{
			char num = Text[0];
			_ = Text.Length;
			if (num != '#')
			{
				return Regex.IsMatch(Text, "^[a-fA-F0-9]{6}$");
			}
			return true;
		}

		private void processWhitespace()
		{
			if (started || base.Line > 1)
			{
				Skip();
				return;
			}
			string text = Text;
			if (base.Column == text.Length)
			{
				int indentationCount = getIndentationCount(text);
				indents.Add(indentationCount);
				Emit(commonToken(1, "{"));
			}
			started = true;
			Skip();
		}

		public StonescriptLexer(ICharStream input)
			: this(input, Console.Out, Console.Error)
		{
		}

		public StonescriptLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
			: base(input, output, errorOutput)
		{
			Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
		}

		static StonescriptLexer()
		{
			sharedContextCache = new PredictionContextCache();
			channelNames = new string[3] { "DEFAULT_TOKEN_CHANNEL", "HIDDEN", "COMMENT" };
			modeNames = new string[3] { "DEFAULT_MODE", "COMMAND_MODE_COMMA", "COMMAND_MODE_SPACE" };
			ruleNames = new string[83]
			{
				"ASCII_BLOCK", "VAR", "CONST", "NEW", "IMPORT", "THIS", "TRUE", "FALSE", "NULL", "FUNCTION",
				"RETURN", "FOR", "IN", "GREATER_THAN_EQUAL", "LESS_THAN", "LESS_THAN_EQUAL", "LPAREN", "RPAREN", "LBRACKET", "RBRACKET",
				"LCBRACKET", "RCBRACKET", "BREAK", "CONTINUE", "EQUAL", "DOUBLE_EQUAL", "PLUS", "MINUS", "MULTIPLY", "DIVIDE",
				"PLUS_EQUAL", "MINUS_EQUAL", "MULTIPLY_EQUAL", "DIVIDE_EQUAL", "INCREMENT", "DECREMENT", "NOT", "NOT_EQUAL", "OR", "AND",
				"DOUBLE_OR", "DOUBLE_AND", "COLON", "QUESTION", "MOD", "COMMA", "DOUBLE_DOT", "DOT", "HASH", "GREATER_THAN",
				"LINE_COMMENT", "BLOCK_COMMENT", "HexDigit", "LineComment", "BlockComment", "NUMBER", "ID", "COLOR", "PATH", "STRING_LITERAL",
				"UNQUOTED_STRING", "UnquotedStringChars", "LineContinuation", "LINE_CONT", "NEWLINE", "WS", "INVALID", "Comma", "Esc", "EscSeq",
				"DQuote", "DQuoteLiteral", "SPACES", "COMMAND_COMMA_SEP", "COMMAND_COMMA_ASCII_BLOCK", "COMMAND_COMMA_PARAM", "COMMAND_COMMA_LINE_CONT", "COMMAND_COMMA_NEWLINE", "COMMAND_SPACE_SEP", "COMMAND_SPACE_ASCII_BLOCK",
				"COMMAND_SPACE_PARAM", "COMMAND_SPACE_LINE_CONT", "COMMAND_SPACE_NEWLINE"
			};
			spacesPerTab = 2;
			_LiteralNames = new string[67]
			{
				null, null, null, null, null, "'var'", "'const'", "'new'", "'import'", "'this'",
				"'true'", "'false'", "'null'", "'func'", "'return'", "'for'", "'in'", "'>='", "'<'", "'<='",
				"'('", "')'", null, null, "'{'", "'}'", "'break'", "'continue'", "'='", "'=='",
				"'+'", "'-'", "'*'", "'/'", "'+='", "'-='", "'*='", "'/='", "'++'", "'--'",
				"'!'", "'!='", "'|'", "'&'", "'||'", "'&&'", "':'", "'?'", "'%'", null,
				"'..'", "'.'", "'#'", "'>'", null, null, null, null, null, null,
				null, null, null, null, null, null, "','"
			};
			_SymbolicNames = new string[76]
			{
				null, "INDENT", "DEDENT", "COMMAND", "ASCII_BLOCK", "VAR", "CONST", "NEW", "IMPORT", "THIS",
				"TRUE", "FALSE", "NULL", "FUNCTION", "RETURN", "FOR", "IN", "GREATER_THAN_EQUAL", "LESS_THAN", "LESS_THAN_EQUAL",
				"LPAREN", "RPAREN", "LBRACKET", "RBRACKET", "LCBRACKET", "RCBRACKET", "BREAK", "CONTINUE", "EQUAL", "DOUBLE_EQUAL",
				"PLUS", "MINUS", "MULTIPLY", "DIVIDE", "PLUS_EQUAL", "MINUS_EQUAL", "MULTIPLY_EQUAL", "DIVIDE_EQUAL", "INCREMENT", "DECREMENT",
				"NOT", "NOT_EQUAL", "OR", "AND", "DOUBLE_OR", "DOUBLE_AND", "COLON", "QUESTION", "MOD", "COMMA",
				"DOUBLE_DOT", "DOT", "HASH", "GREATER_THAN", "LINE_COMMENT", "BLOCK_COMMENT", "NUMBER", "ID", "COLOR", "PATH",
				"STRING_LITERAL", "UNQUOTED_STRING", "LINE_CONT", "NEWLINE", "WS", "INVALID", "COMMAND_COMMA_SEP", "COMMAND_COMMA_ASCII_BLOCK", "COMMAND_COMMA_PARAM", "COMMAND_COMMA_LINE_CONT",
				"COMMAND_COMMA_NEWLINE", "COMMAND_SPACE_SEP", "COMMAND_SPACE_ASCII_BLOCK", "COMMAND_SPACE_PARAM", "COMMAND_SPACE_LINE_CONT", "COMMAND_SPACE_NEWLINE"
			};
			DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);
			_serializedATN = new char[5638]
			{
				'\u0003', '悋', 'Ꜫ', '脳', '맭', '䅼', '㯧', '瞆', '奤', '\u0002',
				'M', 'ɰ', '\b', '\u0001', '\b', '\u0001', '\b', '\u0001', '\u0004', '\u0002',
				'\t', '\u0002', '\u0004', '\u0003', '\t', '\u0003', '\u0004', '\u0004', '\t', '\u0004',
				'\u0004', '\u0005', '\t', '\u0005', '\u0004', '\u0006', '\t', '\u0006', '\u0004', '\a',
				'\t', '\a', '\u0004', '\b', '\t', '\b', '\u0004', '\t', '\t', '\t',
				'\u0004', '\n', '\t', '\n', '\u0004', '\v', '\t', '\v', '\u0004', '\f',
				'\t', '\f', '\u0004', '\r', '\t', '\r', '\u0004', '\u000e', '\t', '\u000e',
				'\u0004', '\u000f', '\t', '\u000f', '\u0004', '\u0010', '\t', '\u0010', '\u0004', '\u0011',
				'\t', '\u0011', '\u0004', '\u0012', '\t', '\u0012', '\u0004', '\u0013', '\t', '\u0013',
				'\u0004', '\u0014', '\t', '\u0014', '\u0004', '\u0015', '\t', '\u0015', '\u0004', '\u0016',
				'\t', '\u0016', '\u0004', '\u0017', '\t', '\u0017', '\u0004', '\u0018', '\t', '\u0018',
				'\u0004', '\u0019', '\t', '\u0019', '\u0004', '\u001a', '\t', '\u001a', '\u0004', '\u001b',
				'\t', '\u001b', '\u0004', '\u001c', '\t', '\u001c', '\u0004', '\u001d', '\t', '\u001d',
				'\u0004', '\u001e', '\t', '\u001e', '\u0004', '\u001f', '\t', '\u001f', '\u0004', ' ',
				'\t', ' ', '\u0004', '!', '\t', '!', '\u0004', '"', '\t', '"',
				'\u0004', '#', '\t', '#', '\u0004', '$', '\t', '$', '\u0004', '%',
				'\t', '%', '\u0004', '&', '\t', '&', '\u0004', '\'', '\t', '\'',
				'\u0004', '(', '\t', '(', '\u0004', ')', '\t', ')', '\u0004', '*',
				'\t', '*', '\u0004', '+', '\t', '+', '\u0004', ',', '\t', ',',
				'\u0004', '-', '\t', '-', '\u0004', '.', '\t', '.', '\u0004', '/',
				'\t', '/', '\u0004', '0', '\t', '0', '\u0004', '1', '\t', '1',
				'\u0004', '2', '\t', '2', '\u0004', '3', '\t', '3', '\u0004', '4',
				'\t', '4', '\u0004', '5', '\t', '5', '\u0004', '6', '\t', '6',
				'\u0004', '7', '\t', '7', '\u0004', '8', '\t', '8', '\u0004', '9',
				'\t', '9', '\u0004', ':', '\t', ':', '\u0004', ';', '\t', ';',
				'\u0004', '<', '\t', '<', '\u0004', '=', '\t', '=', '\u0004', '>',
				'\t', '>', '\u0004', '?', '\t', '?', '\u0004', '@', '\t', '@',
				'\u0004', 'A', '\t', 'A', '\u0004', 'B', '\t', 'B', '\u0004', 'C',
				'\t', 'C', '\u0004', 'D', '\t', 'D', '\u0004', 'E', '\t', 'E',
				'\u0004', 'F', '\t', 'F', '\u0004', 'G', '\t', 'G', '\u0004', 'H',
				'\t', 'H', '\u0004', 'I', '\t', 'I', '\u0004', 'J', '\t', 'J',
				'\u0004', 'K', '\t', 'K', '\u0004', 'L', '\t', 'L', '\u0004', 'M',
				'\t', 'M', '\u0004', 'N', '\t', 'N', '\u0004', 'O', '\t', 'O',
				'\u0004', 'P', '\t', 'P', '\u0004', 'Q', '\t', 'Q', '\u0004', 'R',
				'\t', 'R', '\u0004', 'S', '\t', 'S', '\u0004', 'T', '\t', 'T',
				'\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002',
				'\u0003', '\u0002', '\u0003', '\u0002', '\u0005', '\u0002', '³', '\n', '\u0002', '\u0003',
				'\u0002', '\u0003', '\u0002', '\a', '\u0002', '·', '\n', '\u0002', '\f', '\u0002',
				'\u000e', '\u0002', 'º', '\v', '\u0002', '\u0003', '\u0002', '\u0005', '\u0002', '½',
				'\n', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002',
				'\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002', '\u0003', '\u0002',
				'\u0003', '\u0002', '\u0003', '\u0003', '\u0003', '\u0003', '\u0003', '\u0003', '\u0003', '\u0003',
				'\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004', '\u0003', '\u0004',
				'\u0003', '\u0004', '\u0003', '\u0005', '\u0003', '\u0005', '\u0003', '\u0005', '\u0003', '\u0005',
				'\u0003', '\u0006', '\u0003', '\u0006', '\u0003', '\u0006', '\u0003', '\u0006', '\u0003', '\u0006',
				'\u0003', '\u0006', '\u0003', '\u0006', '\u0003', '\a', '\u0003', '\a', '\u0003', '\a',
				'\u0003', '\a', '\u0003', '\a', '\u0003', '\b', '\u0003', '\b', '\u0003', '\b',
				'\u0003', '\b', '\u0003', '\b', '\u0003', '\t', '\u0003', '\t', '\u0003', '\t',
				'\u0003', '\t', '\u0003', '\t', '\u0003', '\t', '\u0003', '\n', '\u0003', '\n',
				'\u0003', '\n', '\u0003', '\n', '\u0003', '\n', '\u0003', '\v', '\u0003', '\v',
				'\u0003', '\v', '\u0003', '\v', '\u0003', '\v', '\u0003', '\f', '\u0003', '\f',
				'\u0003', '\f', '\u0003', '\f', '\u0003', '\f', '\u0003', '\f', '\u0003', '\f',
				'\u0003', '\r', '\u0003', '\r', '\u0003', '\r', '\u0003', '\r', '\u0003', '\u000e',
				'\u0003', '\u000e', '\u0003', '\u000e', '\u0003', '\u000f', '\u0003', '\u000f', '\u0003', '\u000f',
				'\u0003', '\u0010', '\u0003', '\u0010', '\u0003', '\u0011', '\u0003', '\u0011', '\u0003', '\u0011',
				'\u0003', '\u0012', '\u0003', '\u0012', '\u0003', '\u0013', '\u0003', '\u0013', '\u0003', '\u0014',
				'\u0003', '\u0014', '\u0003', '\u0014', '\u0003', '\u0015', '\u0003', '\u0015', '\u0003', '\u0015',
				'\u0003', '\u0016', '\u0003', '\u0016', '\u0003', '\u0016', '\u0003', '\u0017', '\u0003', '\u0017',
				'\u0003', '\u0017', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0018',
				'\u0003', '\u0018', '\u0003', '\u0018', '\u0003', '\u0019', '\u0003', '\u0019', '\u0003', '\u0019',
				'\u0003', '\u0019', '\u0003', '\u0019', '\u0003', '\u0019', '\u0003', '\u0019', '\u0003', '\u0019',
				'\u0003', '\u0019', '\u0003', '\u001a', '\u0003', '\u001a', '\u0003', '\u001b', '\u0003', '\u001b',
				'\u0003', '\u001b', '\u0003', '\u001c', '\u0003', '\u001c', '\u0003', '\u001d', '\u0003', '\u001d',
				'\u0003', '\u001e', '\u0003', '\u001e', '\u0003', '\u001f', '\u0003', '\u001f', '\u0003', ' ',
				'\u0003', ' ', '\u0003', ' ', '\u0003', '!', '\u0003', '!', '\u0003', '!',
				'\u0003', '"', '\u0003', '"', '\u0003', '"', '\u0003', '#', '\u0003', '#',
				'\u0003', '#', '\u0003', '$', '\u0003', '$', '\u0003', '$', '\u0003', '%',
				'\u0003', '%', '\u0003', '%', '\u0003', '&', '\u0003', '&', '\u0003', '\'',
				'\u0003', '\'', '\u0003', '\'', '\u0003', '(', '\u0003', '(', '\u0003', ')',
				'\u0003', ')', '\u0003', '*', '\u0003', '*', '\u0003', '*', '\u0003', '+',
				'\u0003', '+', '\u0003', '+', '\u0003', ',', '\u0003', ',', '\u0003', '-',
				'\u0003', '-', '\u0003', '.', '\u0003', '.', '\u0003', '/', '\u0003', '/',
				'\u0003', '0', '\u0003', '0', '\u0003', '0', '\u0003', '1', '\u0003', '1',
				'\u0003', '2', '\u0003', '2', '\u0003', '3', '\u0003', '3', '\u0003', '3',
				'\u0003', '4', '\u0003', '4', '\u0003', '4', '\u0003', '4', '\u0003', '5',
				'\u0003', '5', '\u0003', '5', '\u0003', '5', '\u0003', '6', '\u0003', '6',
				'\u0003', '7', '\u0003', '7', '\u0003', '7', '\u0003', '7', '\a', '7',
				'Ż', '\n', '7', '\f', '7', '\u000e', '7', 'ž', '\v', '7',
				'\u0003', '8', '\u0003', '8', '\u0003', '8', '\u0003', '8', '\a', '8',
				'Ƅ', '\n', '8', '\f', '8', '\u000e', '8', 'Ƈ', '\v', '8',
				'\u0003', '8', '\u0003', '8', '\u0003', '8', '\u0005', '8', 'ƌ', '\n',
				'8', '\u0003', '9', '\u0006', '9', 'Ə', '\n', '9', '\r', '9',
				'\u000e', '9', 'Ɛ', '\u0003', '9', '\u0003', '9', '\u0006', '9', 'ƕ',
				'\n', '9', '\r', '9', '\u000e', '9', 'Ɩ', '\u0005', '9', 'ƙ',
				'\n', '9', '\u0003', ':', '\u0003', ':', '\a', ':', 'Ɲ', '\n',
				':', '\f', ':', '\u000e', ':', 'Ơ', '\v', ':', '\u0003', ':',
				'\u0003', ':', '\u0003', ';', '\u0005', ';', 'ƥ', '\n', ';', '\u0003',
				';', '\u0006', ';', 'ƨ', '\n', ';', '\r', ';', '\u000e', ';',
				'Ʃ', '\u0003', ';', '\u0003', ';', '\u0003', '<', '\u0006', '<', 'Ư',
				'\n', '<', '\r', '<', '\u000e', '<', 'ư', '\u0003', '<', '\u0003',
				'<', '\u0003', '=', '\u0003', '=', '\u0003', '>', '\u0006', '>', 'Ƹ',
				'\n', '>', '\r', '>', '\u000e', '>', 'ƹ', '\u0003', '?', '\u0003',
				'?', '\u0003', '@', '\u0005', '@', 'ƿ', '\n', '@', '\u0003', '@',
				'\u0003', '@', '\a', '@', 'ǃ', '\n', '@', '\f', '@', '\u000e',
				'@', 'ǆ', '\v', '@', '\u0003', '@', '\u0003', '@', '\u0003', 'A',
				'\u0003', 'A', '\u0003', 'A', '\u0003', 'A', '\u0003', 'B', '\u0005', 'B',
				'Ǐ', '\n', 'B', '\u0003', 'B', '\u0003', 'B', '\u0005', 'B', 'Ǔ',
				'\n', 'B', '\u0003', 'B', '\u0005', 'B', 'ǖ', '\n', 'B', '\u0003',
				'B', '\u0003', 'B', '\u0003', 'C', '\u0006', 'C', 'Ǜ', '\n', 'C',
				'\r', 'C', '\u000e', 'C', 'ǜ', '\u0003', 'C', '\u0003', 'C', '\u0003',
				'D', '\u0003', 'D', '\u0003', 'E', '\u0003', 'E', '\u0003', 'F', '\u0003',
				'F', '\u0003', 'G', '\u0003', 'G', '\u0003', 'G', '\u0003', 'G', '\u0005',
				'G', 'ǫ', '\n', 'G', '\u0003', 'H', '\u0003', 'H', '\u0003', 'I',
				'\u0003', 'I', '\u0003', 'I', '\u0003', 'I', '\u0005', 'I', 'ǳ', '\n',
				'I', '\u0003', 'I', '\u0003', 'I', '\a', 'I', 'Ƿ', '\n', 'I',
				'\f', 'I', '\u000e', 'I', 'Ǻ', '\v', 'I', '\u0003', 'I', '\u0005',
				'I', 'ǽ', '\n', 'I', '\u0003', 'I', '\u0003', 'I', '\u0003', 'J',
				'\u0006', 'J', 'Ȃ', '\n', 'J', '\r', 'J', '\u000e', 'J', 'ȃ',
				'\u0003', 'K', '\u0003', 'K', '\u0003', 'L', '\u0003', 'L', '\u0003', 'L',
				'\u0003', 'L', '\u0003', 'L', '\u0003', 'L', '\u0003', 'L', '\u0005', 'L',
				'ȏ', '\n', 'L', '\u0003', 'L', '\u0003', 'L', '\a', 'L', 'ȓ',
				'\n', 'L', '\f', 'L', '\u000e', 'L', 'Ȗ', '\v', 'L', '\u0003',
				'L', '\u0005', 'L', 'ș', '\n', 'L', '\u0003', 'L', '\u0003', 'L',
				'\u0003', 'L', '\u0003', 'L', '\u0003', 'L', '\u0003', 'L', '\u0003', 'L',
				'\u0003', 'L', '\u0003', 'L', '\u0003', 'L', '\u0003', 'M', '\u0006', 'M',
				'Ȧ', '\n', 'M', '\r', 'M', '\u000e', 'M', 'ȧ', '\u0003', 'N',
				'\u0003', 'N', '\u0003', 'N', '\u0003', 'N', '\u0003', 'O', '\u0005', 'O',
				'ȯ', '\n', 'O', '\u0003', 'O', '\u0003', 'O', '\u0005', 'O', 'ȳ',
				'\n', 'O', '\u0003', 'O', '\u0005', 'O', 'ȶ', '\n', 'O', '\u0003',
				'O', '\u0003', 'O', '\u0003', 'P', '\u0006', 'P', 'Ȼ', '\n', 'P',
				'\r', 'P', '\u000e', 'P', 'ȼ', '\u0003', 'Q', '\u0003', 'Q', '\u0003',
				'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0005',
				'Q', 'Ɇ', '\n', 'Q', '\u0003', 'Q', '\u0003', 'Q', '\a', 'Q',
				'Ɋ', '\n', 'Q', '\f', 'Q', '\u000e', 'Q', 'ɍ', '\v', 'Q',
				'\u0003', 'Q', '\u0005', 'Q', 'ɐ', '\n', 'Q', '\u0003', 'Q', '\u0003',
				'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0003',
				'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0003', 'Q', '\u0003', 'R', '\u0006',
				'R', 'ɝ', '\n', 'R', '\r', 'R', '\u000e', 'R', 'ɞ', '\u0003',
				'S', '\u0003', 'S', '\u0003', 'S', '\u0003', 'S', '\u0003', 'T', '\u0005',
				'T', 'ɦ', '\n', 'T', '\u0003', 'T', '\u0003', 'T', '\u0005', 'T',
				'ɪ', '\n', 'T', '\u0003', 'T', '\u0005', 'T', 'ɭ', '\n', 'T',
				'\u0003', 'T', '\u0003', 'T', '\u0006', '\u00b8', 'ƅ', 'Ȕ', 'ɋ', '\u0002',
				'U', '\u0005', '\u0006', '\a', '\a', '\t', '\b', '\v', '\t', '\r',
				'\n', '\u000f', '\v', '\u0011', '\f', '\u0013', '\r', '\u0015', '\u000e', '\u0017',
				'\u000f', '\u0019', '\u0010', '\u001b', '\u0011', '\u001d', '\u0012', '\u001f', '\u0013', '!',
				'\u0014', '#', '\u0015', '%', '\u0016', '\'', '\u0017', ')', '\u0018', '+',
				'\u0019', '-', '\u001a', '/', '\u001b', '1', '\u001c', '3', '\u001d', '5',
				'\u001e', '7', '\u001f', '9', ' ', ';', '!', '=', '"', '?',
				'#', 'A', '$', 'C', '%', 'E', '&', 'G', '\'', 'I',
				'(', 'K', ')', 'M', '*', 'O', '+', 'Q', ',', 'S',
				'-', 'U', '.', 'W', '/', 'Y', '0', '[', '1', ']',
				'2', '_', '3', 'a', '4', 'c', '5', 'e', '6', 'g',
				'7', 'i', '8', 'k', '9', 'm', '\u0002', 'o', '\u0002', 'q',
				'\u0002', 's', ':', 'u', ';', 'w', '<', 'y', '=', '{',
				'>', '}', '?', '\u007f', '\u0002', '\u0081', '\u0002', '\u0083', '@', '\u0085',
				'A', '\u0087', 'B', '\u0089', 'C', '\u008b', '\u0002', '\u008d', '\u0002', '\u008f',
				'\u0002', '\u0091', '\u0002', '\u0093', '\u0002', '\u0095', '\u0002', '\u0097', 'D', '\u0099',
				'E', '\u009b', 'F', '\u009d', 'G', '\u009f', 'H', '¡', 'I', '£',
				'J', '¥', 'K', '§', 'L', '©', 'M', '\u0005', '\u0002', '\u0003',
				'\u0004', '\u0012', '\u0004', '\u0002', ']', ']', '］', '］', '\u0004', '\u0002',
				'_', '_', '\uff3f', '\uff3f', '\u0005', '\u0002', '2', ';', 'C', 'H',
				'c', 'h', '\u0004', '\u0002', '\f', '\f', '\u000f', '\u000f', '\u0003', '\u0002',
				'2', ';', '\u0005', '\u0002', 'C', '\\', 'a', 'a', 'c', '|',
				'\u0006', '\u0002', '2', ';', 'C', '\\', 'a', 'a', 'c', '|',
				'\u0005', '\u0002', '2', ';', 'C', '\\', 'c', '|', '\a', '\u0002',
				'/', ';', 'C', '\\', '^', '^', 'a', 'a', 'c', '|',
				'\u000f', '\u0002', '\v', '\f', '\u000f', '\u000f', '"', '%', '\'', '(',
				'*', '1', '<', '<', '>', 'A', ']', ']', '_', '_',
				'}', '\u007f', '＄', '＄', '］', '］', '\uff3f', '\uff3f', '\u0004', '\u0002',
				'\v', '\v', '"', '"', '\v', '\u0002', '$', '$', ')', ')',
				'^', '^', 'd', 'd', 'h', 'h', 'p', 'p', 't', 't',
				'v', 'v', '＄', '＄', '\u0004', '\u0002', '$', '$', '＄', '＄',
				'\a', '\u0002', '\f', '\f', '\u000f', '\u000f', '$', '$', '^', '^',
				'＄', '＄', '\u0005', '\u0002', '\f', '\f', '\u000f', '\u000f', '.', '.',
				'\u0005', '\u0002', '\v', '\f', '\u000f', '\u000f', '"', '"', '\u0002', 'ʍ',
				'\u0002', '\u0005', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\a', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', '\t', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\v',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\r', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', '\u000f', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u0011', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', '\u0013', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u0015',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u0017', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', '\u0019', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u001b', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', '\u001d', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u001f',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '!', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', '#', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '%', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', '\'', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', ')',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '+', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', '-', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '/', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', '1', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '3',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '5', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', '7', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '9', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', ';', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '=',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '?', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', 'A', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'C', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', 'E', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'G',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'I', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', 'K', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'M', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', 'O', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'Q',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'S', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', 'U', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'W', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', 'Y', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '[',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', ']', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', '_', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'a', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', 'c', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'e',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'g', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', 'i', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'k', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', 's', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'u',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', 'w', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', 'y', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '{', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0002', '}', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u0083',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u0085', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0002', '\u0087', '\u0003', '\u0002', '\u0002', '\u0002', '\u0002', '\u0089', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0003', '\u0097', '\u0003', '\u0002', '\u0002', '\u0002', '\u0003', '\u0099',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0003', '\u009b', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0003', '\u009d', '\u0003', '\u0002', '\u0002', '\u0002', '\u0003', '\u009f', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0004', '¡', '\u0003', '\u0002', '\u0002', '\u0002', '\u0004', '£',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0004', '¥', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0004', '§', '\u0003', '\u0002', '\u0002', '\u0002', '\u0004', '©', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0005', '«', '\u0003', '\u0002', '\u0002', '\u0002', '\a', 'È',
				'\u0003', '\u0002', '\u0002', '\u0002', '\t', 'Ì', '\u0003', '\u0002', '\u0002', '\u0002',
				'\v', 'Ò', '\u0003', '\u0002', '\u0002', '\u0002', '\r', 'Ö', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u000f', 'Ý', '\u0003', '\u0002', '\u0002', '\u0002', '\u0011', 'â',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0013', 'ç', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0015', 'í', '\u0003', '\u0002', '\u0002', '\u0002', '\u0017', 'ò', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0019', '÷', '\u0003', '\u0002', '\u0002', '\u0002', '\u001b', 'þ',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u001d', 'Ă', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u001f', 'ą', '\u0003', '\u0002', '\u0002', '\u0002', '!', 'Ĉ', '\u0003', '\u0002',
				'\u0002', '\u0002', '#', 'Ċ', '\u0003', '\u0002', '\u0002', '\u0002', '%', 'č',
				'\u0003', '\u0002', '\u0002', '\u0002', '\'', 'ď', '\u0003', '\u0002', '\u0002', '\u0002',
				')', 'đ', '\u0003', '\u0002', '\u0002', '\u0002', '+', 'Ĕ', '\u0003', '\u0002',
				'\u0002', '\u0002', '-', 'ė', '\u0003', '\u0002', '\u0002', '\u0002', '/', 'Ě',
				'\u0003', '\u0002', '\u0002', '\u0002', '1', 'ĝ', '\u0003', '\u0002', '\u0002', '\u0002',
				'3', 'ģ', '\u0003', '\u0002', '\u0002', '\u0002', '5', 'Ĭ', '\u0003', '\u0002',
				'\u0002', '\u0002', '7', 'Į', '\u0003', '\u0002', '\u0002', '\u0002', '9', 'ı',
				'\u0003', '\u0002', '\u0002', '\u0002', ';', 'ĳ', '\u0003', '\u0002', '\u0002', '\u0002',
				'=', 'ĵ', '\u0003', '\u0002', '\u0002', '\u0002', '?', 'ķ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'A', 'Ĺ', '\u0003', '\u0002', '\u0002', '\u0002', 'C', 'ļ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'E', 'Ŀ', '\u0003', '\u0002', '\u0002', '\u0002',
				'G', 'ł', '\u0003', '\u0002', '\u0002', '\u0002', 'I', 'Ņ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'K', 'ň', '\u0003', '\u0002', '\u0002', '\u0002', 'M', 'ŋ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'O', 'ō', '\u0003', '\u0002', '\u0002', '\u0002',
				'Q', 'Ő', '\u0003', '\u0002', '\u0002', '\u0002', 'S', 'Œ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'U', 'Ŕ', '\u0003', '\u0002', '\u0002', '\u0002', 'W', 'ŗ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Y', 'Ś', '\u0003', '\u0002', '\u0002', '\u0002',
				'[', 'Ŝ', '\u0003', '\u0002', '\u0002', '\u0002', ']', 'Ş', '\u0003', '\u0002',
				'\u0002', '\u0002', '_', 'Š', '\u0003', '\u0002', '\u0002', '\u0002', 'a', 'Ţ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'c', 'ť', '\u0003', '\u0002', '\u0002', '\u0002',
				'e', 'ŧ', '\u0003', '\u0002', '\u0002', '\u0002', 'g', 'ũ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'i', 'Ŭ', '\u0003', '\u0002', '\u0002', '\u0002', 'k', 'Ű',
				'\u0003', '\u0002', '\u0002', '\u0002', 'm', 'Ŵ', '\u0003', '\u0002', '\u0002', '\u0002',
				'o', 'Ŷ', '\u0003', '\u0002', '\u0002', '\u0002', 'q', 'ſ', '\u0003', '\u0002',
				'\u0002', '\u0002', 's', 'Ǝ', '\u0003', '\u0002', '\u0002', '\u0002', 'u', 'ƚ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'w', 'Ƥ', '\u0003', '\u0002', '\u0002', '\u0002',
				'y', 'Ʈ', '\u0003', '\u0002', '\u0002', '\u0002', '{', 'ƴ', '\u0003', '\u0002',
				'\u0002', '\u0002', '}', 'Ʒ', '\u0003', '\u0002', '\u0002', '\u0002', '\u007f', 'ƻ',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0081', 'ƾ', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0083', 'ǉ', '\u0003', '\u0002', '\u0002', '\u0002', '\u0085', 'ǒ', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0087', 'ǚ', '\u0003', '\u0002', '\u0002', '\u0002', '\u0089', 'Ǡ',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u008b', 'Ǣ', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u008d', 'Ǥ', '\u0003', '\u0002', '\u0002', '\u0002', '\u008f', 'Ǧ', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u0091', 'Ǭ', '\u0003', '\u0002', '\u0002', '\u0002', '\u0093', 'Ǯ',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u0095', 'ȁ', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u0097', 'ȅ', '\u0003', '\u0002', '\u0002', '\u0002', '\u0099', 'ȇ', '\u0003', '\u0002',
				'\u0002', '\u0002', '\u009b', 'ȥ', '\u0003', '\u0002', '\u0002', '\u0002', '\u009d', 'ȩ',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u009f', 'Ȳ', '\u0003', '\u0002', '\u0002', '\u0002',
				'¡', 'Ⱥ', '\u0003', '\u0002', '\u0002', '\u0002', '£', 'Ⱦ', '\u0003', '\u0002',
				'\u0002', '\u0002', '¥', 'ɜ', '\u0003', '\u0002', '\u0002', '\u0002', '§', 'ɠ',
				'\u0003', '\u0002', '\u0002', '\u0002', '©', 'ɩ', '\u0003', '\u0002', '\u0002', '\u0002',
				'«', '¬', '\a', 'c', '\u0002', '\u0002', '¬', '\u00ad', '\a', 'u',
				'\u0002', '\u0002', '\u00ad', '®', '\a', 'e', '\u0002', '\u0002', '®', '\u00af',
				'\a', 'k', '\u0002', '\u0002', '\u00af', '°', '\a', 'k', '\u0002', '\u0002',
				'°', '²', '\u0003', '\u0002', '\u0002', '\u0002', '±', '³', '\a', '\u000f',
				'\u0002', '\u0002', '²', '±', '\u0003', '\u0002', '\u0002', '\u0002', '²', '³',
				'\u0003', '\u0002', '\u0002', '\u0002', '³', '\u00b4', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u00b4', '\u00b8', '\a', '\f', '\u0002', '\u0002', 'µ', '·', '\v', '\u0002',
				'\u0002', '\u0002', '¶', 'µ', '\u0003', '\u0002', '\u0002', '\u0002', '·', 'º',
				'\u0003', '\u0002', '\u0002', '\u0002', '\u00b8', '¹', '\u0003', '\u0002', '\u0002', '\u0002',
				'\u00b8', '¶', '\u0003', '\u0002', '\u0002', '\u0002', '¹', '¼', '\u0003', '\u0002',
				'\u0002', '\u0002', 'º', '\u00b8', '\u0003', '\u0002', '\u0002', '\u0002', '»', '½',
				'\a', '\u000f', '\u0002', '\u0002', '¼', '»', '\u0003', '\u0002', '\u0002', '\u0002',
				'¼', '½', '\u0003', '\u0002', '\u0002', '\u0002', '½', '¾', '\u0003', '\u0002',
				'\u0002', '\u0002', '¾', '¿', '\a', '\f', '\u0002', '\u0002', '¿', 'À',
				'\a', 'c', '\u0002', '\u0002', 'À', 'Á', '\a', 'u', '\u0002', '\u0002',
				'Á', 'Â', '\a', 'e', '\u0002', '\u0002', 'Â', 'Ã', '\a', 'k',
				'\u0002', '\u0002', 'Ã', 'Ä', '\a', 'k', '\u0002', '\u0002', 'Ä', 'Å',
				'\a', 'g', '\u0002', '\u0002', 'Å', 'Æ', '\a', 'p', '\u0002', '\u0002',
				'Æ', 'Ç', '\a', 'f', '\u0002', '\u0002', 'Ç', '\u0006', '\u0003', '\u0002',
				'\u0002', '\u0002', 'È', 'É', '\a', 'x', '\u0002', '\u0002', 'É', 'Ê',
				'\a', 'c', '\u0002', '\u0002', 'Ê', 'Ë', '\a', 't', '\u0002', '\u0002',
				'Ë', '\b', '\u0003', '\u0002', '\u0002', '\u0002', 'Ì', 'Í', '\a', 'e',
				'\u0002', '\u0002', 'Í', 'Î', '\a', 'q', '\u0002', '\u0002', 'Î', 'Ï',
				'\a', 'p', '\u0002', '\u0002', 'Ï', 'Ð', '\a', 'u', '\u0002', '\u0002',
				'Ð', 'Ñ', '\a', 'v', '\u0002', '\u0002', 'Ñ', '\n', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ò', 'Ó', '\a', 'p', '\u0002', '\u0002', 'Ó', 'Ô',
				'\a', 'g', '\u0002', '\u0002', 'Ô', 'Õ', '\a', 'y', '\u0002', '\u0002',
				'Õ', '\f', '\u0003', '\u0002', '\u0002', '\u0002', 'Ö', '×', '\a', 'k',
				'\u0002', '\u0002', '×', 'Ø', '\a', 'o', '\u0002', '\u0002', 'Ø', 'Ù',
				'\a', 'r', '\u0002', '\u0002', 'Ù', 'Ú', '\a', 'q', '\u0002', '\u0002',
				'Ú', 'Û', '\a', 't', '\u0002', '\u0002', 'Û', 'Ü', '\a', 'v',
				'\u0002', '\u0002', 'Ü', '\u000e', '\u0003', '\u0002', '\u0002', '\u0002', 'Ý', 'Þ',
				'\a', 'v', '\u0002', '\u0002', 'Þ', 'ß', '\a', 'j', '\u0002', '\u0002',
				'ß', 'à', '\a', 'k', '\u0002', '\u0002', 'à', 'á', '\a', 'u',
				'\u0002', '\u0002', 'á', '\u0010', '\u0003', '\u0002', '\u0002', '\u0002', 'â', 'ã',
				'\a', 'v', '\u0002', '\u0002', 'ã', 'ä', '\a', 't', '\u0002', '\u0002',
				'ä', 'å', '\a', 'w', '\u0002', '\u0002', 'å', 'æ', '\a', 'g',
				'\u0002', '\u0002', 'æ', '\u0012', '\u0003', '\u0002', '\u0002', '\u0002', 'ç', 'è',
				'\a', 'h', '\u0002', '\u0002', 'è', 'é', '\a', 'c', '\u0002', '\u0002',
				'é', 'ê', '\a', 'n', '\u0002', '\u0002', 'ê', 'ë', '\a', 'u',
				'\u0002', '\u0002', 'ë', 'ì', '\a', 'g', '\u0002', '\u0002', 'ì', '\u0014',
				'\u0003', '\u0002', '\u0002', '\u0002', 'í', 'î', '\a', 'p', '\u0002', '\u0002',
				'î', 'ï', '\a', 'w', '\u0002', '\u0002', 'ï', 'ð', '\a', 'n',
				'\u0002', '\u0002', 'ð', 'ñ', '\a', 'n', '\u0002', '\u0002', 'ñ', '\u0016',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ò', 'ó', '\a', 'h', '\u0002', '\u0002',
				'ó', 'ô', '\a', 'w', '\u0002', '\u0002', 'ô', 'õ', '\a', 'p',
				'\u0002', '\u0002', 'õ', 'ö', '\a', 'e', '\u0002', '\u0002', 'ö', '\u0018',
				'\u0003', '\u0002', '\u0002', '\u0002', '÷', 'ø', '\a', 't', '\u0002', '\u0002',
				'ø', 'ù', '\a', 'g', '\u0002', '\u0002', 'ù', 'ú', '\a', 'v',
				'\u0002', '\u0002', 'ú', 'û', '\a', 'w', '\u0002', '\u0002', 'û', 'ü',
				'\a', 't', '\u0002', '\u0002', 'ü', 'ý', '\a', 'p', '\u0002', '\u0002',
				'ý', '\u001a', '\u0003', '\u0002', '\u0002', '\u0002', 'þ', 'ÿ', '\a', 'h',
				'\u0002', '\u0002', 'ÿ', 'Ā', '\a', 'q', '\u0002', '\u0002', 'Ā', 'ā',
				'\a', 't', '\u0002', '\u0002', 'ā', '\u001c', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ă', 'ă', '\a', 'k', '\u0002', '\u0002', 'ă', 'Ą', '\a', 'p',
				'\u0002', '\u0002', 'Ą', '\u001e', '\u0003', '\u0002', '\u0002', '\u0002', 'ą', 'Ć',
				'\a', '@', '\u0002', '\u0002', 'Ć', 'ć', '\a', '?', '\u0002', '\u0002',
				'ć', ' ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ĉ', 'ĉ', '\a', '>',
				'\u0002', '\u0002', 'ĉ', '"', '\u0003', '\u0002', '\u0002', '\u0002', 'Ċ', 'ċ',
				'\a', '>', '\u0002', '\u0002', 'ċ', 'Č', '\a', '?', '\u0002', '\u0002',
				'Č', '$', '\u0003', '\u0002', '\u0002', '\u0002', 'č', 'Ď', '\a', '*',
				'\u0002', '\u0002', 'Ď', '&', '\u0003', '\u0002', '\u0002', '\u0002', 'ď', 'Đ',
				'\a', '+', '\u0002', '\u0002', 'Đ', '(', '\u0003', '\u0002', '\u0002', '\u0002',
				'đ', 'Ē', '\t', '\u0002', '\u0002', '\u0002', 'Ē', 'ē', '\b', '\u0014',
				'\u0002', '\u0002', 'ē', '*', '\u0003', '\u0002', '\u0002', '\u0002', 'Ĕ', 'ĕ',
				'\t', '\u0003', '\u0002', '\u0002', 'ĕ', 'Ė', '\b', '\u0015', '\u0003', '\u0002',
				'Ė', ',', '\u0003', '\u0002', '\u0002', '\u0002', 'ė', 'Ę', '\a', '}',
				'\u0002', '\u0002', 'Ę', 'ę', '\b', '\u0016', '\u0004', '\u0002', 'ę', '.',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ě', 'ě', '\a', '\u007f', '\u0002', '\u0002',
				'ě', 'Ĝ', '\b', '\u0017', '\u0005', '\u0002', 'Ĝ', '0', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ĝ', 'Ğ', '\a', 'd', '\u0002', '\u0002', 'Ğ', 'ğ',
				'\a', 't', '\u0002', '\u0002', 'ğ', 'Ġ', '\a', 'g', '\u0002', '\u0002',
				'Ġ', 'ġ', '\a', 'c', '\u0002', '\u0002', 'ġ', 'Ģ', '\a', 'm',
				'\u0002', '\u0002', 'Ģ', '2', '\u0003', '\u0002', '\u0002', '\u0002', 'ģ', 'Ĥ',
				'\a', 'e', '\u0002', '\u0002', 'Ĥ', 'ĥ', '\a', 'q', '\u0002', '\u0002',
				'ĥ', 'Ħ', '\a', 'p', '\u0002', '\u0002', 'Ħ', 'ħ', '\a', 'v',
				'\u0002', '\u0002', 'ħ', 'Ĩ', '\a', 'k', '\u0002', '\u0002', 'Ĩ', 'ĩ',
				'\a', 'p', '\u0002', '\u0002', 'ĩ', 'Ī', '\a', 'w', '\u0002', '\u0002',
				'Ī', 'ī', '\a', 'g', '\u0002', '\u0002', 'ī', '4', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ĭ', 'ĭ', '\a', '?', '\u0002', '\u0002', 'ĭ', '6',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Į', 'į', '\a', '?', '\u0002', '\u0002',
				'į', 'İ', '\a', '?', '\u0002', '\u0002', 'İ', '8', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ı', 'Ĳ', '\a', '-', '\u0002', '\u0002', 'Ĳ', ':',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ĳ', 'Ĵ', '\a', '/', '\u0002', '\u0002',
				'Ĵ', '<', '\u0003', '\u0002', '\u0002', '\u0002', 'ĵ', 'Ķ', '\a', ',',
				'\u0002', '\u0002', 'Ķ', '>', '\u0003', '\u0002', '\u0002', '\u0002', 'ķ', 'ĸ',
				'\a', '1', '\u0002', '\u0002', 'ĸ', '@', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ĺ', 'ĺ', '\a', '-', '\u0002', '\u0002', 'ĺ', 'Ļ', '\a', '?',
				'\u0002', '\u0002', 'Ļ', 'B', '\u0003', '\u0002', '\u0002', '\u0002', 'ļ', 'Ľ',
				'\a', '/', '\u0002', '\u0002', 'Ľ', 'ľ', '\a', '?', '\u0002', '\u0002',
				'ľ', 'D', '\u0003', '\u0002', '\u0002', '\u0002', 'Ŀ', 'ŀ', '\a', ',',
				'\u0002', '\u0002', 'ŀ', 'Ł', '\a', '?', '\u0002', '\u0002', 'Ł', 'F',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ł', 'Ń', '\a', '1', '\u0002', '\u0002',
				'Ń', 'ń', '\a', '?', '\u0002', '\u0002', 'ń', 'H', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ņ', 'ņ', '\a', '-', '\u0002', '\u0002', 'ņ', 'Ň',
				'\a', '-', '\u0002', '\u0002', 'Ň', 'J', '\u0003', '\u0002', '\u0002', '\u0002',
				'ň', 'ŉ', '\a', '/', '\u0002', '\u0002', 'ŉ', 'Ŋ', '\a', '/',
				'\u0002', '\u0002', 'Ŋ', 'L', '\u0003', '\u0002', '\u0002', '\u0002', 'ŋ', 'Ō',
				'\a', '#', '\u0002', '\u0002', 'Ō', 'N', '\u0003', '\u0002', '\u0002', '\u0002',
				'ō', 'Ŏ', '\a', '#', '\u0002', '\u0002', 'Ŏ', 'ŏ', '\a', '?',
				'\u0002', '\u0002', 'ŏ', 'P', '\u0003', '\u0002', '\u0002', '\u0002', 'Ő', 'ő',
				'\a', '~', '\u0002', '\u0002', 'ő', 'R', '\u0003', '\u0002', '\u0002', '\u0002',
				'Œ', 'œ', '\a', '(', '\u0002', '\u0002', 'œ', 'T', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ŕ', 'ŕ', '\a', '~', '\u0002', '\u0002', 'ŕ', 'Ŗ',
				'\a', '~', '\u0002', '\u0002', 'Ŗ', 'V', '\u0003', '\u0002', '\u0002', '\u0002',
				'ŗ', 'Ř', '\a', '(', '\u0002', '\u0002', 'Ř', 'ř', '\a', '(',
				'\u0002', '\u0002', 'ř', 'X', '\u0003', '\u0002', '\u0002', '\u0002', 'Ś', 'ś',
				'\a', '<', '\u0002', '\u0002', 'ś', 'Z', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ŝ', 'ŝ', '\a', 'A', '\u0002', '\u0002', 'ŝ', '\\', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ş', 'ş', '\a', '\'', '\u0002', '\u0002', 'ş', '^',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Š', 'š', '\u0005', '\u008b', 'E', '\u0002',
				'š', '`', '\u0003', '\u0002', '\u0002', '\u0002', 'Ţ', 'ţ', '\a', '0',
				'\u0002', '\u0002', 'ţ', 'Ť', '\a', '0', '\u0002', '\u0002', 'Ť', 'b',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ť', 'Ŧ', '\a', '0', '\u0002', '\u0002',
				'Ŧ', 'd', '\u0003', '\u0002', '\u0002', '\u0002', 'ŧ', 'Ũ', '\a', '%',
				'\u0002', '\u0002', 'Ũ', 'f', '\u0003', '\u0002', '\u0002', '\u0002', 'ũ', 'Ū',
				'\a', '@', '\u0002', '\u0002', 'Ū', 'ū', '\b', '3', '\u0006', '\u0002',
				'ū', 'h', '\u0003', '\u0002', '\u0002', '\u0002', 'Ŭ', 'ŭ', '\u0005', 'o',
				'7', '\u0002', 'ŭ', 'Ů', '\u0003', '\u0002', '\u0002', '\u0002', 'Ů', 'ů',
				'\b', '4', '\a', '\u0002', 'ů', 'j', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ű', 'ű', '\u0005', 'q', '8', '\u0002', 'ű', 'Ų', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ų', 'ų', '\b', '5', '\a', '\u0002', 'ų', 'l',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ŵ', 'ŵ', '\t', '\u0004', '\u0002', '\u0002',
				'ŵ', 'n', '\u0003', '\u0002', '\u0002', '\u0002', 'Ŷ', 'ŷ', '\a', '1',
				'\u0002', '\u0002', 'ŷ', 'Ÿ', '\a', '1', '\u0002', '\u0002', 'Ÿ', 'ż',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ź', 'Ż', '\n', '\u0005', '\u0002', '\u0002',
				'ź', 'Ź', '\u0003', '\u0002', '\u0002', '\u0002', 'Ż', 'ž', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ż', 'ź', '\u0003', '\u0002', '\u0002', '\u0002', 'ż', 'Ž',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ž', 'p', '\u0003', '\u0002', '\u0002', '\u0002',
				'ž', 'ż', '\u0003', '\u0002', '\u0002', '\u0002', 'ſ', 'ƀ', '\a', '1',
				'\u0002', '\u0002', 'ƀ', 'Ɓ', '\a', ',', '\u0002', '\u0002', 'Ɓ', 'ƅ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ƃ', 'Ƅ', '\v', '\u0002', '\u0002', '\u0002',
				'ƃ', 'Ƃ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ƅ', 'Ƈ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ƅ', 'Ɔ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƅ', 'ƃ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ɔ', 'Ƌ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ƈ', 'ƅ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƈ', 'Ɖ', '\a', ',',
				'\u0002', '\u0002', 'Ɖ', 'ƌ', '\a', '1', '\u0002', '\u0002', 'Ɗ', 'ƌ',
				'\a', '\u0002', '\u0002', '\u0003', 'Ƌ', 'ƈ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ƌ', 'Ɗ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƌ', 'r', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ƍ', 'Ə', '\t', '\u0006', '\u0002', '\u0002', 'Ǝ', 'ƍ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ə', 'Ɛ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ɛ', 'Ǝ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ɛ', 'Ƒ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ƒ', 'Ƙ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƒ', 'Ɣ',
				'\a', '0', '\u0002', '\u0002', 'Ɠ', 'ƕ', '\t', '\u0006', '\u0002', '\u0002',
				'Ɣ', 'Ɠ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƕ', 'Ɩ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ɩ', 'Ɣ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ɩ', 'Ɨ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ɨ', 'ƙ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ƙ', 'ƒ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ƙ', 'ƙ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ƙ', 't', '\u0003', '\u0002', '\u0002', '\u0002', 'ƚ', 'ƞ',
				'\t', '\a', '\u0002', '\u0002', 'ƛ', 'Ɲ', '\t', '\b', '\u0002', '\u0002',
				'Ɯ', 'ƛ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ɲ', 'Ơ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ƞ', 'Ɯ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƞ', 'Ɵ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ɵ', 'ơ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ơ', 'ƞ', '\u0003', '\u0002', '\u0002', '\u0002', 'ơ', 'Ƣ', '\b', ':',
				'\b', '\u0002', 'Ƣ', 'v', '\u0003', '\u0002', '\u0002', '\u0002', 'ƣ', 'ƥ',
				'\a', '%', '\u0002', '\u0002', 'Ƥ', 'ƣ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ƥ', 'ƥ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƥ', 'Ƨ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ʀ', 'ƨ', '\t', '\t', '\u0002', '\u0002', 'Ƨ', 'Ʀ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ƨ', 'Ʃ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ʃ', 'Ƨ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ʃ', 'ƪ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ƪ', 'ƫ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƫ', 'Ƭ',
				'\u0006', ';', '\u0002', '\u0002', 'Ƭ', 'x', '\u0003', '\u0002', '\u0002', '\u0002',
				'ƭ', 'Ư', '\t', '\n', '\u0002', '\u0002', 'Ʈ', 'ƭ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ư', 'ư', '\u0003', '\u0002', '\u0002', '\u0002', 'ư', 'Ʈ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ư', 'Ʊ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ʊ', 'Ʋ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ʋ', 'Ƴ', '\u0006', '<',
				'\u0003', '\u0002', 'Ƴ', 'z', '\u0003', '\u0002', '\u0002', '\u0002', 'ƴ', 'Ƶ',
				'\u0005', '\u0093', 'I', '\u0002', 'Ƶ', '|', '\u0003', '\u0002', '\u0002', '\u0002',
				'ƶ', 'Ƹ', '\u0005', '\u007f', '?', '\u0002', 'Ʒ', 'ƶ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ƹ', 'ƹ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƹ', 'Ʒ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ƹ', 'ƺ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ƺ', '~', '\u0003', '\u0002', '\u0002', '\u0002', 'ƻ', 'Ƽ', '\n', '\v',
				'\u0002', '\u0002', 'Ƽ', '\u0080', '\u0003', '\u0002', '\u0002', '\u0002', 'ƽ', 'ƿ',
				'\a', '\u000f', '\u0002', '\u0002', 'ƾ', 'ƽ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ƾ', 'ƿ', '\u0003', '\u0002', '\u0002', '\u0002', 'ƿ', 'ǀ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ǀ', 'Ǆ', '\a', '\f', '\u0002', '\u0002', 'ǁ', 'ǃ',
				'\t', '\f', '\u0002', '\u0002', 'ǂ', 'ǁ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ǃ', 'ǆ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǆ', 'ǂ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ǆ', 'ǅ', '\u0003', '\u0002', '\u0002', '\u0002', 'ǅ', 'Ǉ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ǆ', 'Ǆ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ǉ', 'ǈ', '\a', '`', '\u0002', '\u0002', 'ǈ', '\u0082', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ǉ', 'Ǌ', '\u0005', '\u0081', '@', '\u0002', 'Ǌ', 'ǋ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ǋ', 'ǌ', '\b', 'A', '\t', '\u0002',
				'ǌ', '\u0084', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǎ', 'Ǐ', '\a', '\u000f',
				'\u0002', '\u0002', 'ǎ', 'Ǎ', '\u0003', '\u0002', '\u0002', '\u0002', 'ǎ', 'Ǐ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ǐ', 'ǐ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ǐ', 'Ǔ', '\a', '\f', '\u0002', '\u0002', 'Ǒ', 'Ǔ', '\u0004', '\u000e',
				'\u000f', '\u0002', 'ǒ', 'ǎ', '\u0003', '\u0002', '\u0002', '\u0002', 'ǒ', 'Ǒ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ǔ', 'Ǖ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ǔ', 'ǖ', '\u0005', '\u0095', 'J', '\u0002', 'Ǖ', 'ǔ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ǖ', 'ǖ', '\u0003', '\u0002', '\u0002', '\u0002', 'ǖ', 'Ǘ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ǘ', 'ǘ', '\b', 'B', '\n', '\u0002',
				'ǘ', '\u0086', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǚ', 'Ǜ', '\t', '\f',
				'\u0002', '\u0002', 'ǚ', 'Ǚ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǜ', 'ǜ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ǜ', 'ǚ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ǜ', 'ǝ', '\u0003', '\u0002', '\u0002', '\u0002', 'ǝ', 'Ǟ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ǟ', 'ǟ', '\b', 'C', '\v', '\u0002', 'ǟ', '\u0088',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ǡ', 'ǡ', '\v', '\u0002', '\u0002', '\u0002',
				'ǡ', '\u008a', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǣ', 'ǣ', '\a', '.',
				'\u0002', '\u0002', 'ǣ', '\u008c', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǥ', 'ǥ',
				'\a', '^', '\u0002', '\u0002', 'ǥ', '\u008e', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ǧ', 'Ǫ', '\u0005', '\u008d', 'F', '\u0002', 'ǧ', 'ǫ', '\t', '\r',
				'\u0002', '\u0002', 'Ǩ', 'ǫ', '\v', '\u0002', '\u0002', '\u0002', 'ǩ', 'ǫ',
				'\a', '\u0002', '\u0002', '\u0003', 'Ǫ', 'ǧ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ǫ', 'Ǩ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǫ', 'ǩ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ǫ', '\u0090', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǭ', 'ǭ',
				'\t', '\u000e', '\u0002', '\u0002', 'ǭ', '\u0092', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ǯ', 'Ǹ', '\u0005', '\u0091', 'H', '\u0002', 'ǯ', 'Ƿ', '\u0005', '\u008f',
				'G', '\u0002', 'ǰ', 'Ƿ', '\n', '\u000f', '\u0002', '\u0002', 'Ǳ', 'ǳ',
				'\a', '\u000f', '\u0002', '\u0002', 'ǲ', 'Ǳ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ǲ', 'ǳ', '\u0003', '\u0002', '\u0002', '\u0002', 'ǳ', 'Ǵ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ǵ', 'ǵ', '\a', '\f', '\u0002', '\u0002', 'ǵ', 'Ƿ',
				'\a', '`', '\u0002', '\u0002', 'Ƕ', 'ǯ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ƕ', 'ǰ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ƕ', 'ǲ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ƿ', 'Ǻ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǹ', 'Ƕ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ǹ', 'ǹ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ǹ', 'Ǽ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǻ', 'Ǹ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ǻ', 'ǽ', '\a', '^', '\u0002', '\u0002', 'Ǽ', 'ǻ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ǽ', 'ǽ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ǽ', 'Ǿ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ǿ', 'ǿ', '\u0005', '\u0091',
				'H', '\u0002', 'ǿ', '\u0094', '\u0003', '\u0002', '\u0002', '\u0002', 'Ȁ', 'Ȃ',
				'\t', '\f', '\u0002', '\u0002', 'ȁ', 'Ȁ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ȃ', 'ȃ', '\u0003', '\u0002', '\u0002', '\u0002', 'ȃ', 'ȁ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ȃ', 'Ȅ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ȅ', '\u0096',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ȅ', 'Ȇ', '\a', '.', '\u0002', '\u0002',
				'Ȇ', '\u0098', '\u0003', '\u0002', '\u0002', '\u0002', 'ȇ', 'Ȉ', '\a', 'c',
				'\u0002', '\u0002', 'Ȉ', 'ȉ', '\a', 'u', '\u0002', '\u0002', 'ȉ', 'Ȋ',
				'\a', 'e', '\u0002', '\u0002', 'Ȋ', 'ȋ', '\a', 'k', '\u0002', '\u0002',
				'ȋ', 'Ȍ', '\a', 'k', '\u0002', '\u0002', 'Ȍ', 'Ȏ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ȍ', 'ȏ', '\a', '\u000f', '\u0002', '\u0002', 'Ȏ', 'ȍ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ȏ', 'ȏ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ȏ', 'Ȑ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ȑ', 'Ȕ', '\a', '\f',
				'\u0002', '\u0002', 'ȑ', 'ȓ', '\v', '\u0002', '\u0002', '\u0002', 'Ȓ', 'ȑ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ȓ', 'Ȗ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ȕ', 'ȕ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ȕ', 'Ȓ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ȕ', 'Ș', '\u0003', '\u0002', '\u0002', '\u0002', 'Ȗ', 'Ȕ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ȗ', 'ș', '\a', '\u000f', '\u0002', '\u0002',
				'Ș', 'ȗ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ș', 'ș', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ș', 'Ț', '\u0003', '\u0002', '\u0002', '\u0002', 'Ț', 'ț',
				'\a', '\f', '\u0002', '\u0002', 'ț', 'Ȝ', '\a', 'c', '\u0002', '\u0002',
				'Ȝ', 'ȝ', '\a', 'u', '\u0002', '\u0002', 'ȝ', 'Ȟ', '\a', 'e',
				'\u0002', '\u0002', 'Ȟ', 'ȟ', '\a', 'k', '\u0002', '\u0002', 'ȟ', 'Ƞ',
				'\a', 'k', '\u0002', '\u0002', 'Ƞ', 'ȡ', '\a', 'g', '\u0002', '\u0002',
				'ȡ', 'Ȣ', '\a', 'p', '\u0002', '\u0002', 'Ȣ', 'ȣ', '\a', 'f',
				'\u0002', '\u0002', 'ȣ', '\u009a', '\u0003', '\u0002', '\u0002', '\u0002', 'Ȥ', 'Ȧ',
				'\n', '\u0010', '\u0002', '\u0002', 'ȥ', 'Ȥ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ȧ', 'ȧ', '\u0003', '\u0002', '\u0002', '\u0002', 'ȧ', 'ȥ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ȧ', 'Ȩ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ȩ', '\u009c',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ȩ', 'Ȫ', '\u0005', '\u0081', '@', '\u0002',
				'Ȫ', 'ȫ', '\u0003', '\u0002', '\u0002', '\u0002', 'ȫ', 'Ȭ', '\b', 'N',
				'\t', '\u0002', 'Ȭ', '\u009e', '\u0003', '\u0002', '\u0002', '\u0002', 'ȭ', 'ȯ',
				'\a', '\u000f', '\u0002', '\u0002', 'Ȯ', 'ȭ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ȯ', 'ȯ', '\u0003', '\u0002', '\u0002', '\u0002', 'ȯ', 'Ȱ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ȱ', 'ȳ', '\a', '\f', '\u0002', '\u0002', 'ȱ', 'ȳ',
				'\u0004', '\u000e', '\u000f', '\u0002', 'Ȳ', 'Ȯ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ȳ', 'ȱ', '\u0003', '\u0002', '\u0002', '\u0002', 'ȳ', 'ȵ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ȴ', 'ȶ', '\u0005', '\u0095', 'J', '\u0002', 'ȵ', 'ȴ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ȵ', 'ȶ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ȶ', 'ȷ', '\u0003', '\u0002', '\u0002', '\u0002', 'ȷ', 'ȸ', '\b', 'O',
				'\f', '\u0002', 'ȸ', '\u00a0', '\u0003', '\u0002', '\u0002', '\u0002', 'ȹ', 'Ȼ',
				'\t', '\f', '\u0002', '\u0002', 'Ⱥ', 'ȹ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ȼ', 'ȼ', '\u0003', '\u0002', '\u0002', '\u0002', 'ȼ', 'Ⱥ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ȼ', 'Ƚ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ƚ', '¢',
				'\u0003', '\u0002', '\u0002', '\u0002', 'Ⱦ', 'ȿ', '\a', 'c', '\u0002', '\u0002',
				'ȿ', 'ɀ', '\a', 'u', '\u0002', '\u0002', 'ɀ', 'Ɂ', '\a', 'e',
				'\u0002', '\u0002', 'Ɂ', 'ɂ', '\a', 'k', '\u0002', '\u0002', 'ɂ', 'Ƀ',
				'\a', 'k', '\u0002', '\u0002', 'Ƀ', 'Ʌ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ʉ', 'Ɇ', '\a', '\u000f', '\u0002', '\u0002', 'Ʌ', 'Ʉ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ʌ', 'Ɇ', '\u0003', '\u0002', '\u0002', '\u0002', 'Ɇ', 'ɇ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɇ', 'ɋ', '\a', '\f', '\u0002', '\u0002',
				'Ɉ', 'Ɋ', '\v', '\u0002', '\u0002', '\u0002', 'ɉ', 'Ɉ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ɋ', 'ɍ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɋ', 'Ɍ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɋ', 'ɉ', '\u0003', '\u0002', '\u0002', '\u0002',
				'Ɍ', 'ɏ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɍ', 'ɋ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'Ɏ', 'ɐ', '\a', '\u000f', '\u0002', '\u0002', 'ɏ', 'Ɏ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɏ', 'ɐ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ɐ', 'ɑ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɑ', 'ɒ', '\a', '\f',
				'\u0002', '\u0002', 'ɒ', 'ɓ', '\a', 'c', '\u0002', '\u0002', 'ɓ', 'ɔ',
				'\a', 'u', '\u0002', '\u0002', 'ɔ', 'ɕ', '\a', 'e', '\u0002', '\u0002',
				'ɕ', 'ɖ', '\a', 'k', '\u0002', '\u0002', 'ɖ', 'ɗ', '\a', 'k',
				'\u0002', '\u0002', 'ɗ', 'ɘ', '\a', 'g', '\u0002', '\u0002', 'ɘ', 'ə',
				'\a', 'p', '\u0002', '\u0002', 'ə', 'ɚ', '\a', 'f', '\u0002', '\u0002',
				'ɚ', '¤', '\u0003', '\u0002', '\u0002', '\u0002', 'ɛ', 'ɝ', '\n', '\u0011',
				'\u0002', '\u0002', 'ɜ', 'ɛ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɝ', 'ɞ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɞ', 'ɜ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ɞ', 'ɟ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɟ', '¦', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ɠ', 'ɡ', '\u0005', '\u0081', '@', '\u0002', 'ɡ', 'ɢ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɢ', 'ɣ', '\b', 'S', '\t', '\u0002',
				'ɣ', '\u00a8', '\u0003', '\u0002', '\u0002', '\u0002', 'ɤ', 'ɦ', '\a', '\u000f',
				'\u0002', '\u0002', 'ɥ', 'ɤ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɥ', 'ɦ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɦ', 'ɧ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ɧ', 'ɪ', '\a', '\f', '\u0002', '\u0002', 'ɨ', 'ɪ', '\u0004', '\u000e',
				'\u000f', '\u0002', 'ɩ', 'ɥ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɩ', 'ɨ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɪ', 'ɬ', '\u0003', '\u0002', '\u0002', '\u0002',
				'ɫ', 'ɭ', '\u0005', '\u0095', 'J', '\u0002', 'ɬ', 'ɫ', '\u0003', '\u0002',
				'\u0002', '\u0002', 'ɬ', 'ɭ', '\u0003', '\u0002', '\u0002', '\u0002', 'ɭ', 'ɮ',
				'\u0003', '\u0002', '\u0002', '\u0002', 'ɮ', 'ɯ', '\b', 'T', '\r', '\u0002',
				'ɯ', 'ª', '\u0003', '\u0002', '\u0002', '\u0002', '.', '\u0002', '\u0003', '\u0004',
				'²', '\u00b8', '¼', 'ż', 'ƅ', 'Ƌ', 'Ɛ', 'Ɩ', 'Ƙ', 'ƞ',
				'Ƥ', 'Ʃ', 'ư', 'ƹ', 'ƾ', 'Ǆ', 'ǎ', 'ǒ', 'Ǖ', 'ǜ',
				'Ǫ', 'ǲ', 'Ƕ', 'Ǹ', 'Ǽ', 'ȃ', 'Ȏ', 'Ȕ', 'Ș', 'ȧ',
				'Ȯ', 'Ȳ', 'ȵ', 'ȼ', 'Ʌ', 'ɋ', 'ɏ', 'ɞ', 'ɥ', 'ɩ',
				'ɬ', '\u000e', '\u0003', '\u0014', '\u0002', '\u0003', '\u0015', '\u0003', '\u0003', '\u0016',
				'\u0004', '\u0003', '\u0017', '\u0005', '\u0003', '3', '\u0006', '\u0002', '\u0004', '\u0002',
				'\u0003', ':', '\a', '\b', '\u0002', '\u0002', '\u0003', 'B', '\b', '\u0003',
				'C', '\t', '\u0003', 'O', '\n', '\u0003', 'T', '\v'
			};
			_ATN = new ATNDeserializer().Deserialize(_serializedATN);
			decisionToDFA = new DFA[_ATN.NumberOfDecisions];
			for (int i = 0; i < _ATN.NumberOfDecisions; i++)
			{
				decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
			}
		}

		public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex)
		{
			switch (ruleIndex)
			{
			case 18:
				LBRACKET_action(_localctx, actionIndex);
				break;
			case 19:
				RBRACKET_action(_localctx, actionIndex);
				break;
			case 20:
				LCBRACKET_action(_localctx, actionIndex);
				break;
			case 21:
				RCBRACKET_action(_localctx, actionIndex);
				break;
			case 49:
				GREATER_THAN_action(_localctx, actionIndex);
				break;
			case 56:
				ID_action(_localctx, actionIndex);
				break;
			case 64:
				NEWLINE_action(_localctx, actionIndex);
				break;
			case 65:
				WS_action(_localctx, actionIndex);
				break;
			case 77:
				COMMAND_COMMA_NEWLINE_action(_localctx, actionIndex);
				break;
			case 82:
				COMMAND_SPACE_NEWLINE_action(_localctx, actionIndex);
				break;
			}
		}

		private void LBRACKET_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 0)
			{
				opened++;
			}
		}

		private void RBRACKET_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 1)
			{
				opened--;
			}
		}

		private void LCBRACKET_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 2)
			{
				opened++;
			}
		}

		private void RCBRACKET_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 3)
			{
				opened--;
			}
		}

		private void GREATER_THAN_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 4)
			{
				CheckCommandMode(1);
			}
		}

		private void ID_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 5)
			{
				CheckCommandMode(2);
			}
		}

		private void NEWLINE_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 6)
			{
				processNewline();
			}
		}

		private void WS_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 7)
			{
				processWhitespace();
			}
		}

		private void COMMAND_COMMA_NEWLINE_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 8)
			{
				mode(0);
				processNewline();
			}
		}

		private void COMMAND_SPACE_NEWLINE_action(RuleContext _localctx, int actionIndex)
		{
			if (actionIndex == 9)
			{
				mode(0);
				processNewline();
			}
		}

		public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex)
		{
			return ruleIndex switch
			{
				57 => COLOR_sempred(_localctx, predIndex), 
				58 => PATH_sempred(_localctx, predIndex), 
				_ => true, 
			};
		}

		private bool COLOR_sempred(RuleContext _localctx, int predIndex)
		{
			if (predIndex == 0)
			{
				return canBeColor();
			}
			return true;
		}

		private bool PATH_sempred(RuleContext _localctx, int predIndex)
		{
			if (predIndex == 1)
			{
				return canBePath();
			}
			return true;
		}
	}
}
