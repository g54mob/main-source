using System.Collections.Generic;
using CLanguage.Interpreter;
using CLanguage.Parser;
using CLanguage.Syntax;

namespace CLanguage.Compiler
{
	public class CCompiler
	{
		private CompilerOptions options;

		private readonly Dictionary<string, LexedDocument> lexedDocuments;

		private List<TranslationUnit> tus;

		private static readonly Document[] noDocs;

		public CompilerOptions Options => null;

		public CCompiler()
		{
		}

		public CCompiler(CompilerOptions options)
		{
		}

		public CCompiler(MachineInfo mi, Report report)
		{
		}

		public void Add(TranslationUnit translationUnit)
		{
		}

		private void ProcessDocument(Document document)
		{
		}

		private Token[] Include(string path, bool relative)
		{
			return null;
		}

		public void AddCode(string name, string code)
		{
		}

		public void AddDocument(Document document)
		{
		}

		public Executable Compile()
		{
			return null;
		}

		public static Executable Compile(string code)
		{
			return null;
		}

		private Executable CompileExecutable()
		{
			return null;
		}

		private void AddStatementDeclarations(BlockContext context)
		{
		}

		private FunctionDeclarator? GetFunctionDeclarator(Declarator? d)
		{
			return null;
		}
	}
}
