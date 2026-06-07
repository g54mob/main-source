using System.IO;
using CLanguage.Parser.yyParser;
using CLanguage.Syntax;

namespace CLanguage.Parser
{
	public class CParser
	{
		public TextWriter ErrorOutput;

		public int eof_token;

		protected const int yyFinal = 28;

		protected static readonly string[] yyNames;

		private int yyExpectingState;

		protected int yyMax;

		private static int[] global_yyStates;

		private static object[] global_yyVals;

		protected bool use_global_stacks;

		private object[] yyVals;

		private object yyVal;

		private int yyToken;

		private int yyTop;

		private static readonly short[] yyLhs;

		private static readonly short[] yyLen;

		private static readonly short[] yyDefRed;

		protected static readonly short[] yyDgoto;

		protected static readonly short[] yySindex;

		protected static readonly short[] yyRindex;

		protected static readonly short[] yyGindex;

		protected static readonly short[] yyTable;

		protected static readonly short[] yyCheck;

		public static int yacc_verbose_flag;

		private TranslationUnit _tu;

		private ParserInput lexer;

		private static readonly Token[] noTokens;

		private static readonly object[] noObjects;

		public void yyerror(string message)
		{
		}

		public void yyerror(string message, string[] expected)
		{
		}

		public static string yyname(int token)
		{
			return null;
		}

		protected int[] yyExpectingTokens(int state)
		{
			return null;
		}

		protected string[] yyExpecting(int state)
		{
			return null;
		}

		internal object yyparse(yyInput yyLex, object yyd)
		{
			return null;
		}

		protected object yyDefault(object first)
		{
			return null;
		}

		internal object yyparse(yyInput yyLex)
		{
			return null;
		}

		private void case_17()
		{
		}

		private void case_18()
		{
		}

		private void case_64()
		{
		}

		private void case_82()
		{
		}

		private void case_83()
		{
		}

		private void case_84()
		{
		}

		private void case_85()
		{
		}

		private void case_86()
		{
		}

		private void case_87()
		{
		}

		private void case_88()
		{
		}

		private void case_89()
		{
		}

		private void case_90()
		{
		}

		private void case_91()
		{
		}

		private void case_92()
		{
		}

		private void case_123()
		{
		}

		private void case_124()
		{
		}

		private void case_125()
		{
		}

		private void case_126()
		{
		}

		private void case_132()
		{
		}

		private void case_133()
		{
		}

		private void case_144()
		{
		}

		private void case_154()
		{
		}

		private void case_166()
		{
		}

		private void case_167()
		{
		}

		private void case_168()
		{
		}

		private void case_178()
		{
		}

		private void case_192()
		{
		}

		private void case_193()
		{
		}

		private void case_194()
		{
		}

		private void case_195()
		{
		}

		private void case_228()
		{
		}

		private void case_245()
		{
		}

		private void case_246()
		{
		}

		private void case_251()
		{
		}

		private void case_252()
		{
		}

		private void case_256()
		{
		}

		private void case_257()
		{
		}

		private void case_258()
		{
		}

		private void case_259()
		{
		}

		private void case_260()
		{
		}

		public TranslationUnit ParseTranslationUnit(string name, string code, Preprocessor.Include include, Report report)
		{
			return null;
		}

		public TranslationUnit ParseTranslationUnit(Report report, string name, Preprocessor.Include include, params Token[][] tokens)
		{
			return null;
		}

		public static Expression TryParseExpression(Report report, Token[] tokens)
		{
			return null;
		}

		private void AddDeclaration(object a)
		{
		}

		private Declarator FixPointerAndArrayPrecedence(Declarator d)
		{
			return null;
		}

		private Declarator? MakeArrayDeclarator(Declarator? left, TypeQualifiers tq, Expression? len, bool isStatic)
		{
			return null;
		}

		private Location GetLocation(object obj)
		{
			return default(Location);
		}
	}
}
