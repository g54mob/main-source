using Microsoft.CodeAnalysis;

namespace RoslynCSharp.Compiler
{
	public sealed class CompilationError
	{
		private Diagnostic diagnostic;

		private string code;

		private string message;

		private Location location = Location.None;

		private DiagnosticSeverity severity = DiagnosticSeverity.Info;

		private bool isWarningAsError;

		private bool isSupressed;

		public string Code => code;

		public string Message => message;

		public string SourceFile => location.SourceTree.FilePath;

		public int SourceLine => location.GetLineSpan().StartLinePosition.Line;

		public int SourceColumn => location.GetLineSpan().StartLinePosition.Character;

		public bool IsInfo => severity == DiagnosticSeverity.Info;

		public bool IsWarning => severity == DiagnosticSeverity.Warning;

		public bool IsError => severity == DiagnosticSeverity.Error;

		public bool IsWarningAsError => isWarningAsError;

		public bool IsSuppressed => isSupressed;

		internal CompilationError(Diagnostic diagnostic)
		{
			this.diagnostic = diagnostic;
			code = diagnostic.Id;
			message = diagnostic.GetMessage();
			location = diagnostic.Location;
			severity = diagnostic.Severity;
			isWarningAsError = diagnostic.IsWarningAsError;
			isSupressed = diagnostic.IsSuppressed;
		}

		public override string ToString()
		{
			return diagnostic.ToString();
		}
	}
}
