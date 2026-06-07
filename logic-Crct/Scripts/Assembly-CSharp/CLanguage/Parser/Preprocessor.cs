using System.Collections.Generic;
using CLanguage.Compiler;
using CLanguage.Syntax;
using CLanguage.Types;

namespace CLanguage.Parser
{
	public class Preprocessor
	{
		public delegate Token[] Include(string filePath, bool relative);

		private class Define
		{
			public string Name;

			public readonly string[] Parameters;

			public readonly bool HasParameters;

			public readonly Token[] Body;

			public Define(Token[] body)
			{
			}

			public Define(string name, bool hasParameters, string[] parameters, Token[] body)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		private class PreprocessorContext : EmitContext
		{
			private readonly Dictionary<string, Define> defines;

			private readonly Dictionary<string, Expression> expressions;

			public PreprocessorContext(Report report, Dictionary<string, Define> defines, Dictionary<string, Expression> expressions)
				: base(null)
			{
			}

			public override ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
			{
				return null;
			}
		}

		private readonly List<Token> tokens;

		private readonly Include include;

		private readonly Report report;

		private static readonly Token[] noTokens;

		private static readonly string[] noStrings;

		public Preprocessor(Include include, Report report, params Token[][] tokens)
		{
		}

		public Token[] Preprocess()
		{
			return null;
		}

		private Token[] IncludeBuiltins(string filePath, bool relative)
		{
			return null;
		}

		private static bool PreprocessIteration(Dictionary<string, Define> defines, Include include, List<Token> tokens, Report report)
		{
			return false;
		}

		private static bool EvalIfCondition(Dictionary<string, Define> defines, Token[] tokens)
		{
			return false;
		}

		private static (List<Define>, int) ReadDefineArgs(int startIndex, List<Token> tokens)
		{
			return default((List<Define>, int));
		}
	}
}
