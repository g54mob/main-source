using System;
using System.CodeDom.Compiler;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;

[GeneratedCode("ANTLR", "4.9.1")]
[CLSCompliant(false)]
public class XPathLexer : Lexer
{
	protected static DFA[] decisionToDFA;

	protected static PredictionContextCache sharedContextCache;

	public const int TokenRef = 1;

	public const int RuleRef = 2;

	public const int Anywhere = 3;

	public const int Root = 4;

	public const int Wildcard = 5;

	public const int Bang = 6;

	public const int ID = 7;

	public const int String = 8;

	public static string[] channelNames;

	public static string[] modeNames;

	public static readonly string[] ruleNames;

	private static readonly string[] _LiteralNames;

	private static readonly string[] _SymbolicNames;

	public static readonly IVocabulary DefaultVocabulary;

	private static string _serializedATN;

	public static readonly ATN _ATN;

	[NotNull]
	public override IVocabulary Vocabulary => DefaultVocabulary;

	public override string GrammarFileName => "XPathLexer.g4";

	public override string[] RuleNames => ruleNames;

	public override string[] ChannelNames => channelNames;

	public override string[] ModeNames => modeNames;

	public override string SerializedAtn => _serializedATN;

	public XPathLexer(ICharStream input)
		: base(input)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	static XPathLexer()
	{
		sharedContextCache = new PredictionContextCache();
		channelNames = new string[2] { "DEFAULT_TOKEN_CHANNEL", "HIDDEN" };
		modeNames = new string[1] { "DEFAULT_MODE" };
		ruleNames = new string[8] { "Anywhere", "Root", "Wildcard", "Bang", "ID", "NameChar", "NameStartChar", "String" };
		_LiteralNames = new string[7] { null, null, null, "'//'", "'/'", "'*'", "'!'" };
		_SymbolicNames = new string[9] { null, "TokenRef", "RuleRef", "Anywhere", "Root", "Wildcard", "Bang", "ID", "String" };
		DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);
		_serializedATN = _serializeATN();
		_ATN = new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++)
		{
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

	public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex)
	{
		if (ruleIndex == 4)
		{
			ID_action(_localctx, actionIndex);
		}
	}

	private void ID_action(RuleContext _localctx, int actionIndex)
	{
		if (actionIndex == 0)
		{
			if (char.IsUpper(Text[0]))
			{
				Type = 1;
			}
			else
			{
				Type = 2;
			}
		}
	}

	private static string _serializeATN()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("\u0003а훑舆괭䐗껱趀ꫝ\u0002\n4");
		stringBuilder.Append("\b\u0001\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004\u0004\t\u0004\u0004\u0005\t\u0005\u0004\u0006\t\u0006");
		stringBuilder.Append("\u0004\a\t\a\u0004\b\t\b\u0004\t\t\t\u0003\u0002\u0003\u0002\u0003\u0002\u0003\u0003\u0003\u0003\u0003");
		stringBuilder.Append("\u0004\u0003\u0004\u0003\u0005\u0003\u0005\u0003\u0006\u0003\u0006\a\u0006\u001f\n\u0006\f\u0006\u000e\u0006\"");
		stringBuilder.Append("\v\u0006\u0003\u0006\u0003\u0006\u0003\a\u0003\a\u0005\a(\n\a\u0003\b\u0003\b\u0003\t\u0003\t\a");
		stringBuilder.Append("\t.\n\t\f\t\u000e\t1\v\t\u0003\t\u0003\t\u0003/\u0002\n\u0003\u0005\u0005\u0006\a\a");
		stringBuilder.Append("\t\b\v\t\r\u0002\u000f\u0002\u0011\n\u0003\u0002\u0004\a\u00022;aa¹¹");
		stringBuilder.Append("\u0302ͱ⁁⁂\u000f\u0002C\\c|ÂØÚøú");
		stringBuilder.Append("\u0301ͲͿ\u0381\u2001\u200e\u200f\u2072↑Ⰲ⿱");
		stringBuilder.Append("〃\ufffd車\ufdd1ﷲ\uffff4\u0002\u0003\u0003\u0002\u0002\u0002\u0002");
		stringBuilder.Append("\u0005\u0003\u0002\u0002\u0002\u0002\a\u0003\u0002\u0002\u0002\u0002\t\u0003\u0002\u0002\u0002\u0002\v\u0003\u0002");
		stringBuilder.Append("\u0002\u0002\u0002\u0011\u0003\u0002\u0002\u0002\u0003\u0013\u0003\u0002\u0002\u0002\u0005\u0016\u0003\u0002\u0002");
		stringBuilder.Append("\u0002\a\u0018\u0003\u0002\u0002\u0002\t\u001a\u0003\u0002\u0002\u0002\v\u001c\u0003\u0002\u0002\u0002\r");
		stringBuilder.Append("'\u0003\u0002\u0002\u0002\u000f)\u0003\u0002\u0002\u0002\u0011+\u0003\u0002\u0002\u0002\u0013\u0014\a1");
		stringBuilder.Append("\u0002\u0002\u0014\u0015\a1\u0002\u0002\u0015\u0004\u0003\u0002\u0002\u0002\u0016\u0017\a1");
		stringBuilder.Append("\u0002\u0002\u0017\u0006\u0003\u0002\u0002\u0002\u0018\u0019\a,\u0002\u0002\u0019\b\u0003\u0002\u0002\u0002");
		stringBuilder.Append("\u001a\u001b\a#\u0002\u0002\u001b\n\u0003\u0002\u0002\u0002\u001c \u0005\u000f\b\u0002\u001d\u001f");
		stringBuilder.Append("\u0005\r\a\u0002\u001e\u001d\u0003\u0002\u0002\u0002\u001f\"\u0003\u0002\u0002\u0002 \u001e\u0003\u0002");
		stringBuilder.Append("\u0002\u0002 !\u0003\u0002\u0002\u0002!#\u0003\u0002\u0002\u0002\" \u0003\u0002\u0002\u0002#$\b\u0006\u0002");
		stringBuilder.Append("\u0002$\f\u0003\u0002\u0002\u0002%(\u0005\u000f\b\u0002&(\t\u0002\u0002\u0002'%\u0003\u0002\u0002\u0002");
		stringBuilder.Append("'&\u0003\u0002\u0002\u0002(\u000e\u0003\u0002\u0002\u0002)*\t\u0003\u0002\u0002*\u0010\u0003\u0002\u0002\u0002");
		stringBuilder.Append("+/\a)\u0002\u0002,.\v\u0002\u0002\u0002-,\u0003\u0002\u0002\u0002.1\u0003\u0002\u0002\u0002/0");
		stringBuilder.Append("\u0003\u0002\u0002\u0002/-\u0003\u0002\u0002\u000202\u0003\u0002\u0002\u00021/\u0003\u0002\u0002");
		stringBuilder.Append("\u000223\a)\u0002\u00023\u0012\u0003\u0002\u0002\u0002\u0006\u0002 '/\u0003\u0003\u0006");
		stringBuilder.Append("\u0002");
		return stringBuilder.ToString();
	}
}
