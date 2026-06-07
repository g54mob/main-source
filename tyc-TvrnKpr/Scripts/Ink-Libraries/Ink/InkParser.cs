using System.Collections.Generic;
using Ink.Parsed;

namespace Ink
{
	public class InkParser : StringParser
	{
		protected enum CustomFlags
		{
			ParsingString = 1
		}

		protected class InfixOperator
		{
			public string type;

			public int precedence;

			public bool requireWhitespace;

			public InfixOperator(string type, int precedence, bool requireWhitespace)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		protected class FlowDecl
		{
			public string name;

			public List<FlowBase.Argument> arguments;

			public bool isFunction;
		}

		protected enum StatementLevel
		{
			InnerBlock = 0,
			Stitch = 1,
			Knot = 2,
			Top = 3
		}

		private IFileHandler _fileHandler;

		private Ink.ErrorHandler _externalErrorHandler;

		private string _filename;

		public static readonly CharacterRange LatinBasic;

		public static readonly CharacterRange LatinExtendedA;

		public static readonly CharacterRange LatinExtendedB;

		public static readonly CharacterRange Greek;

		public static readonly CharacterRange Cyrillic;

		public static readonly CharacterRange Armenian;

		public static readonly CharacterRange Hebrew;

		public static readonly CharacterRange Arabic;

		public static readonly CharacterRange Korean;

		private bool _parsingChoice;

		private CharacterSet _runtimePathCharacterSet;

		private CharacterSet _nonTextPauseCharacters;

		private CharacterSet _nonTextEndCharacters;

		private CharacterSet _notTextEndCharactersChoice;

		private CharacterSet _notTextEndCharactersString;

		private List<InfixOperator> _binaryOperators;

		private int _maxBinaryOpLength;

		private InkParser _rootParser;

		private HashSet<string> _openFilenames;

		private CharacterSet _identifierCharSet;

		private CharacterSet _sequenceTypeSymbols;

		private ParseRule[][] _statementRulesAtLevel;

		private ParseRule[][] _statementBreakRulesAtLevel;

		private CharacterSet _endOfTagCharSet;

		private CharacterSet _inlineWhitespaceChars;

		protected bool parsingStringExpression
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private CharacterSet identifierCharSet => null;

		public InkParser(string str, string filenameForMetadata = null, Ink.ErrorHandler externalErrorHandler = null, IFileHandler fileHandler = null)
			: base(null)
		{
		}

		private InkParser(string str, string inkFilename = null, Ink.ErrorHandler externalErrorHandler = null, InkParser rootParser = null, IFileHandler fileHandler = null)
			: base(null)
		{
		}

		public Story Parse()
		{
			return null;
		}

		protected List<T> SeparatedList<T>(SpecificParseRule<T> mainRule, ParseRule separatorRule) where T : class
		{
			return null;
		}

		protected override string PreProcessInputString(string str)
		{
			return null;
		}

		protected override void RuleDidSucceed(object result, StringParserState.Element stateAtStart, StringParserState.Element stateAtEnd)
		{
		}

		private void OnStringParserError(string message, int index, int lineIndex, bool isWarning)
		{
		}

		protected AuthorWarning AuthorWarning()
		{
			return null;
		}

		private void ExtendIdentifierCharacterRanges(CharacterSet identifierCharSet)
		{
		}

		public static CharacterRange[] ListAllCharacterRanges()
		{
			return null;
		}

		protected Choice Choice()
		{
			return null;
		}

		protected Expression ChoiceCondition()
		{
			return null;
		}

		protected object ChoiceConditionsSpace()
		{
			return null;
		}

		protected Expression ChoiceSingleCondition()
		{
			return null;
		}

		protected Gather Gather()
		{
			return null;
		}

		protected object GatherDashes()
		{
			return null;
		}

		protected object ParseDashNotArrow()
		{
			return null;
		}

		protected string BracketedName()
		{
			return null;
		}

		public CommandLineInput CommandLineUserInput()
		{
			return null;
		}

		private CommandLineInput DebugSource()
		{
			return null;
		}

		private CommandLineInput DebugPathLookup()
		{
			return null;
		}

		private string RuntimePath()
		{
			return null;
		}

		private CommandLineInput UserChoiceNumber()
		{
			return null;
		}

		private CommandLineInput UserImmediateModeStatement()
		{
			return null;
		}

		protected Conditional InnerConditionalContent()
		{
			return null;
		}

		protected Conditional InnerConditionalContent(Expression initialQueryExpression)
		{
			return null;
		}

		protected List<ConditionalSingleBranch> InlineConditionalBranches()
		{
			return null;
		}

		protected List<ConditionalSingleBranch> MultilineConditionalBranches()
		{
			return null;
		}

		protected ConditionalSingleBranch SingleMultilineCondition()
		{
			return null;
		}

		protected Expression ConditionExpression()
		{
			return null;
		}

		protected object ElseExpression()
		{
			return null;
		}

		private void TrimEndWhitespace(List<Object> mixedTextAndLogicResults, bool terminateWithSpace)
		{
		}

		protected List<Object> LineOfMixedTextAndLogic()
		{
			return null;
		}

		protected List<Object> MixedTextAndLogic()
		{
			return null;
		}

		protected Text ContentText()
		{
			return null;
		}

		protected Text ContentTextAllowingEcapeChar()
		{
			return null;
		}

		protected string ContentTextNoEscape()
		{
			return null;
		}

		protected List<Object> MultiDivert()
		{
			return null;
		}

		protected Divert StartThread()
		{
			return null;
		}

		protected Divert DivertIdentifierWithArguments()
		{
			return null;
		}

		protected Divert SingleDivert()
		{
			return null;
		}

		private List<string> DotSeparatedDivertPathComponents()
		{
			return null;
		}

		protected string ParseDivertArrowOrTunnelOnwards()
		{
			return null;
		}

		protected string ParseDivertArrow()
		{
			return null;
		}

		protected string ParseThreadArrow()
		{
			return null;
		}

		protected Object TempDeclarationOrAssignment()
		{
			return null;
		}

		protected void DisallowIncrement(Object expr)
		{
		}

		protected bool ParseTempKeyword()
		{
			return false;
		}

		protected Return ReturnStatement()
		{
			return null;
		}

		protected Expression Expression()
		{
			return null;
		}

		protected Expression Expression(int minimumPrecedence)
		{
			return null;
		}

		protected Expression ExpressionUnary()
		{
			return null;
		}

		protected string ExpressionNot()
		{
			return null;
		}

		protected Expression ExpressionLiteral()
		{
			return null;
		}

		protected Expression ExpressionDivertTarget()
		{
			return null;
		}

		protected Number ExpressionInt()
		{
			return null;
		}

		protected Number ExpressionFloat()
		{
			return null;
		}

		protected StringExpression ExpressionString()
		{
			return null;
		}

		protected Number ExpressionBool()
		{
			return null;
		}

		protected Expression ExpressionFunctionCall()
		{
			return null;
		}

		protected List<Expression> ExpressionFunctionCallArguments()
		{
			return null;
		}

		protected Expression ExpressionVariableName()
		{
			return null;
		}

		protected Expression ExpressionParen()
		{
			return null;
		}

		protected Expression ExpressionInfixRight(Expression left, InfixOperator op)
		{
			return null;
		}

		private InfixOperator ParseInfixOperator()
		{
			return null;
		}

		protected List ExpressionList()
		{
			return null;
		}

		protected string ListMember()
		{
			return null;
		}

		private void RegisterExpressionOperators()
		{
		}

		private void RegisterBinaryOperator(string op, int precedence, bool requireWhitespace = false)
		{
		}

		protected object IncludeStatement()
		{
			return null;
		}

		private bool FilenameIsAlreadyOpen(string fullFilename)
		{
			return false;
		}

		private void AddOpenFilename(string fullFilename)
		{
		}

		private void RemoveOpenFilename(string fullFilename)
		{
		}

		protected Knot KnotDefinition()
		{
			return null;
		}

		protected FlowDecl KnotDeclaration()
		{
			return null;
		}

		protected string KnotTitleEquals()
		{
			return null;
		}

		protected object StitchDefinition()
		{
			return null;
		}

		protected FlowDecl StitchDeclaration()
		{
			return null;
		}

		protected object KnotStitchNoContentRecoveryRule()
		{
			return null;
		}

		protected List<FlowBase.Argument> BracketedKnotDeclArguments()
		{
			return null;
		}

		protected FlowBase.Argument FlowDeclArgument()
		{
			return null;
		}

		protected ExternalDeclaration ExternalDeclaration()
		{
			return null;
		}

		protected Object LogicLine()
		{
			return null;
		}

		protected Object VariableDeclaration()
		{
			return null;
		}

		protected VariableAssignment ListDeclaration()
		{
			return null;
		}

		protected ListDefinition ListDefinition()
		{
			return null;
		}

		protected string ListElementDefinitionSeparator()
		{
			return null;
		}

		protected ListElementDefinition ListElementDefinition()
		{
			return null;
		}

		protected Object ConstDeclaration()
		{
			return null;
		}

		protected Object InlineLogicOrGlue()
		{
			return null;
		}

		protected Glue Glue()
		{
			return null;
		}

		protected Object InlineLogic()
		{
			return null;
		}

		protected Object InnerLogic()
		{
			return null;
		}

		protected Object InnerExpression()
		{
			return null;
		}

		protected string Identifier()
		{
			return null;
		}

		protected Sequence InnerSequence()
		{
			return null;
		}

		protected object SequenceTypeAnnotation()
		{
			return null;
		}

		protected object SequenceTypeSymbolAnnotation()
		{
			return null;
		}

		protected object SequenceTypeWordAnnotation()
		{
			return null;
		}

		protected object SequenceTypeSingleWord()
		{
			return null;
		}

		protected List<ContentList> InnerSequenceObjects()
		{
			return null;
		}

		protected List<ContentList> InnerInlineSequenceObjects()
		{
			return null;
		}

		protected List<ContentList> InnerMultilineSequenceObjects()
		{
			return null;
		}

		protected ContentList SingleMultilineSequenceElement()
		{
			return null;
		}

		protected List<Object> StatementsAtLevel(StatementLevel level)
		{
			return null;
		}

		protected object StatementAtLevel(StatementLevel level)
		{
			return null;
		}

		protected object StatementsBreakForLevel(StatementLevel level)
		{
			return null;
		}

		private void GenerateStatementLevelRules()
		{
		}

		protected object SkipToNextLine()
		{
			return null;
		}

		protected ParseRule Line(ParseRule inlineRule)
		{
			return null;
		}

		protected Tag Tag()
		{
			return null;
		}

		protected List<Tag> Tags()
		{
			return null;
		}

		protected object EndOfLine()
		{
			return null;
		}

		protected object Newline()
		{
			return null;
		}

		protected object EndOfFile()
		{
			return null;
		}

		protected object MultilineWhitespace()
		{
			return null;
		}

		protected object Whitespace()
		{
			return null;
		}

		protected ParseRule Spaced(ParseRule rule)
		{
			return null;
		}

		protected object AnyWhitespace()
		{
			return null;
		}

		protected ParseRule MultiSpaced(ParseRule rule)
		{
			return null;
		}
	}
}
