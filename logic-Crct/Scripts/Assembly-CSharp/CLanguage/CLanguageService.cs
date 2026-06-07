using CLanguage.Interpreter;
using CLanguage.Syntax;

namespace CLanguage
{
	public static class CLanguageService
	{
		public const string DefaultCodePath = "main.cpp";

		public static TranslationUnit ParseTranslationUnit(string code)
		{
			return null;
		}

		public static TranslationUnit ParseTranslationUnit(string code, Report report)
		{
			return null;
		}

		public static TranslationUnit ParseTranslationUnit(string code, Report.Printer printer)
		{
			return null;
		}

		public static CInterpreter CreateInterpreter(string code, MachineInfo? machineInfo = null, Report.Printer? printer = null)
		{
			return null;
		}

		public static Executable Compile(string code, MachineInfo? machineInfo = null, Report.Printer? printer = null)
		{
			return null;
		}

		public static ColorSpan[] Colorize(string code, MachineInfo? machineInfo = null, Report.Printer? printer = null)
		{
			return null;
		}

		public static void Run(string code)
		{
		}

		public static object Eval(string expression, string? includeCode = "")
		{
			return null;
		}
	}
}
