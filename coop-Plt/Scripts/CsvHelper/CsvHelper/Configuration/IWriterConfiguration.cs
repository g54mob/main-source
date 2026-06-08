using System.Collections.Generic;
using System.Globalization;

namespace CsvHelper.Configuration
{
	public interface IWriterConfiguration
	{
		CsvMode Mode { get; }

		bool LeaveOpen { get; }

		string Delimiter { get; }

		char Quote { get; }

		char Escape { get; }

		TrimOptions TrimOptions { get; }

		bool SanitizeForInjection { get; }

		char[] InjectionCharacters { get; }

		char InjectionEscapeCharacter { get; }

		string NewLine { get; }

		bool IsNewLineSet { get; }

		ShouldQuote ShouldQuote { get; }

		CultureInfo CultureInfo { get; }

		bool AllowComments { get; }

		char Comment { get; }

		bool HasHeaderRecord { get; }

		bool IgnoreReferences { get; }

		bool IncludePrivateMembers { get; }

		ReferenceHeaderPrefix ReferenceHeaderPrefix { get; }

		MemberTypes MemberTypes { get; }

		bool UseNewObjectForNullReferenceMembers { get; }

		IComparer<string> DynamicPropertySort { get; }

		bool ExceptionMessagesContainRawData { get; }
	}
}
