using System.Globalization;

namespace CsvHelper.Configuration
{
	public interface IReaderConfiguration : IParserConfiguration
	{
		bool HasHeaderRecord { get; }

		HeaderValidated HeaderValidated { get; }

		MissingFieldFound MissingFieldFound { get; }

		ReadingExceptionOccurred ReadingExceptionOccurred { get; }

		CultureInfo CultureInfo { get; }

		PrepareHeaderForMatch PrepareHeaderForMatch { get; }

		ShouldUseConstructorParameters ShouldUseConstructorParameters { get; }

		GetConstructor GetConstructor { get; }

		GetDynamicPropertyName GetDynamicPropertyName { get; }

		bool IgnoreReferences { get; }

		ShouldSkipRecord ShouldSkipRecord { get; }

		bool IncludePrivateMembers { get; }

		ReferenceHeaderPrefix ReferenceHeaderPrefix { get; }

		bool DetectColumnCountChanges { get; }

		MemberTypes MemberTypes { get; }
	}
}
