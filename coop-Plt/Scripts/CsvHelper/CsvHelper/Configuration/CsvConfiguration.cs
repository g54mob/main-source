using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CsvHelper.Configuration
{
	public class CsvConfiguration : IReaderConfiguration, IParserConfiguration, IWriterConfiguration, IEquatable<CsvConfiguration>
	{
		private string newLine;

		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(CsvConfiguration);
			}
		}

		public virtual bool AllowComments { get; set; }

		public virtual BadDataFound BadDataFound { get; set; }

		public virtual int BufferSize { get; set; }

		public virtual bool CacheFields { get; set; }

		public virtual char Comment { get; set; }

		public virtual bool CountBytes { get; set; }

		public virtual CultureInfo CultureInfo { get; protected set; }

		public virtual string Delimiter { get; set; }

		public virtual bool DetectDelimiter { get; set; }

		public virtual string[] DetectDelimiterValues { get; set; }

		public virtual bool DetectColumnCountChanges { get; set; }

		public virtual IComparer<string> DynamicPropertySort { get; set; }

		public virtual Encoding Encoding { get; set; }

		public virtual char Escape { get; set; }

		public virtual bool ExceptionMessagesContainRawData { get; set; }

		public virtual GetConstructor GetConstructor { get; set; }

		public virtual GetDynamicPropertyName GetDynamicPropertyName { get; set; }

		public virtual bool HasHeaderRecord { get; set; }

		public virtual HeaderValidated HeaderValidated { get; set; }

		public virtual bool IgnoreBlankLines { get; set; }

		public virtual bool IgnoreReferences { get; set; }

		public virtual bool IncludePrivateMembers { get; set; }

		public virtual char[] InjectionCharacters { get; set; }

		public virtual char InjectionEscapeCharacter { get; set; }

		public bool IsNewLineSet { get; private set; }

		public virtual bool LeaveOpen { get; set; }

		public virtual bool LineBreakInQuotedFieldIsBadData { get; set; }

		public virtual MemberTypes MemberTypes { get; set; }

		public virtual MissingFieldFound MissingFieldFound { get; set; }

		public virtual CsvMode Mode { get; set; }

		public virtual string NewLine
		{
			get
			{
				return newLine;
			}
			set
			{
				IsNewLineSet = true;
				newLine = value;
			}
		}

		public virtual PrepareHeaderForMatch PrepareHeaderForMatch { get; set; }

		public virtual int ProcessFieldBufferSize { get; set; }

		public virtual char Quote { get; set; }

		public virtual ReadingExceptionOccurred ReadingExceptionOccurred { get; set; }

		public virtual ReferenceHeaderPrefix ReferenceHeaderPrefix { get; set; }

		public virtual bool SanitizeForInjection { get; set; }

		public ShouldQuote ShouldQuote { get; set; }

		public virtual ShouldSkipRecord ShouldSkipRecord { get; set; }

		public virtual ShouldUseConstructorParameters ShouldUseConstructorParameters { get; set; }

		public virtual TrimOptions TrimOptions { get; set; }

		public virtual bool UseNewObjectForNullReferenceMembers { get; set; }

		public virtual char[] WhiteSpaceChars { get; set; }

		public CsvConfiguration(CultureInfo cultureInfo)
		{
			newLine = "\r\n";
			BadDataFound = ConfigurationFunctions.BadDataFound;
			BufferSize = 4096;
			Comment = '#';
			DetectDelimiterValues = new string[4] { ",", ";", "|", "\t" };
			Encoding = Encoding.UTF8;
			Escape = '"';
			ExceptionMessagesContainRawData = true;
			GetConstructor = ConfigurationFunctions.GetConstructor;
			GetDynamicPropertyName = ConfigurationFunctions.GetDynamicPropertyName;
			HasHeaderRecord = true;
			HeaderValidated = ConfigurationFunctions.HeaderValidated;
			IgnoreBlankLines = true;
			InjectionCharacters = new char[4] { '=', '@', '+', '-' };
			InjectionEscapeCharacter = '\t';
			MemberTypes = MemberTypes.Properties;
			MissingFieldFound = ConfigurationFunctions.MissingFieldFound;
			PrepareHeaderForMatch = ConfigurationFunctions.PrepareHeaderForMatch;
			ProcessFieldBufferSize = 1024;
			Quote = '"';
			ReadingExceptionOccurred = ConfigurationFunctions.ReadingExceptionOccurred;
			ShouldQuote = ConfigurationFunctions.ShouldQuote;
			ShouldSkipRecord = ConfigurationFunctions.ShouldSkipRecord;
			ShouldUseConstructorParameters = ConfigurationFunctions.ShouldUseConstructorParameters;
			UseNewObjectForNullReferenceMembers = true;
			WhiteSpaceChars = new char[1] { ' ' };
			base._002Ector();
			CultureInfo = cultureInfo;
			Delimiter = cultureInfo.TextInfo.ListSeparator;
		}

		public void Validate()
		{
			string text = Escape.ToString();
			string text2 = Quote.ToString();
			string[] source = new string[3] { "\r", "\n", "\r\n" };
			string[] source2 = WhiteSpaceChars.Select((char c) => c.ToString()).ToArray();
			if (text == Delimiter)
			{
				throw new ConfigurationException($"{Escape} and {Delimiter} cannot be the same.");
			}
			if (text == NewLine && IsNewLineSet)
			{
				throw new ConfigurationException($"{Escape} and {NewLine} cannot be the same.");
			}
			if (source.Contains(Escape.ToString()) && !IsNewLineSet)
			{
				throw new ConfigurationException($"{Escape} cannot be a line ending. ('\\r', '\\n', '\\r\\n')");
			}
			if (source2.Contains(text))
			{
				throw new ConfigurationException($"{Escape} cannot be a WhiteSpaceChar.");
			}
			if (text2 == Delimiter)
			{
				throw new ConfigurationException($"{Quote} and {Delimiter} cannot be the same.");
			}
			if (text2 == NewLine && IsNewLineSet)
			{
				throw new ConfigurationException($"{Quote} and {NewLine} cannot be the same.");
			}
			if (source.Contains(text2))
			{
				throw new ConfigurationException($"{Quote} cannot be a line ending. ('\\r', '\\n', '\\r\\n')");
			}
			if (source2.Contains(text2))
			{
				throw new ConfigurationException($"{Quote} cannot be a WhiteSpaceChar.");
			}
			if (Delimiter == NewLine && IsNewLineSet)
			{
				throw new ConfigurationException(Delimiter + " and " + NewLine + " cannot be the same.");
			}
			if (source.Contains(Delimiter))
			{
				throw new ConfigurationException(Delimiter + " cannot be a line ending. ('\\r', '\\n', '\\r\\n')");
			}
			if (source2.Contains(Delimiter))
			{
				throw new ConfigurationException(Delimiter + " cannot be a WhiteSpaceChar.");
			}
			if (DetectDelimiter && DetectDelimiterValues.Length == 0)
			{
				throw new ConfigurationException("At least one value is required for DetectDelimiterValues when DetectDelimiter is enabled.");
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("CsvConfiguration");
			stringBuilder.Append(" { ");
			if (PrintMembers(stringBuilder))
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		protected virtual bool PrintMembers(StringBuilder builder)
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("AllowComments = ");
			builder.Append(AllowComments.ToString());
			builder.Append(", BadDataFound = ");
			builder.Append(BadDataFound);
			builder.Append(", BufferSize = ");
			builder.Append(BufferSize.ToString());
			builder.Append(", CacheFields = ");
			builder.Append(CacheFields.ToString());
			builder.Append(", Comment = ");
			builder.Append(Comment.ToString());
			builder.Append(", CountBytes = ");
			builder.Append(CountBytes.ToString());
			builder.Append(", CultureInfo = ");
			builder.Append(CultureInfo);
			builder.Append(", Delimiter = ");
			builder.Append((object)Delimiter);
			builder.Append(", DetectDelimiter = ");
			builder.Append(DetectDelimiter.ToString());
			builder.Append(", DetectDelimiterValues = ");
			builder.Append(DetectDelimiterValues);
			builder.Append(", DetectColumnCountChanges = ");
			builder.Append(DetectColumnCountChanges.ToString());
			builder.Append(", DynamicPropertySort = ");
			builder.Append(DynamicPropertySort);
			builder.Append(", Encoding = ");
			builder.Append(Encoding);
			builder.Append(", Escape = ");
			builder.Append(Escape.ToString());
			builder.Append(", ExceptionMessagesContainRawData = ");
			builder.Append(ExceptionMessagesContainRawData.ToString());
			builder.Append(", GetConstructor = ");
			builder.Append(GetConstructor);
			builder.Append(", GetDynamicPropertyName = ");
			builder.Append(GetDynamicPropertyName);
			builder.Append(", HasHeaderRecord = ");
			builder.Append(HasHeaderRecord.ToString());
			builder.Append(", HeaderValidated = ");
			builder.Append(HeaderValidated);
			builder.Append(", IgnoreBlankLines = ");
			builder.Append(IgnoreBlankLines.ToString());
			builder.Append(", IgnoreReferences = ");
			builder.Append(IgnoreReferences.ToString());
			builder.Append(", IncludePrivateMembers = ");
			builder.Append(IncludePrivateMembers.ToString());
			builder.Append(", InjectionCharacters = ");
			builder.Append((object)InjectionCharacters);
			builder.Append(", InjectionEscapeCharacter = ");
			builder.Append(InjectionEscapeCharacter.ToString());
			builder.Append(", IsNewLineSet = ");
			builder.Append(IsNewLineSet.ToString());
			builder.Append(", LeaveOpen = ");
			builder.Append(LeaveOpen.ToString());
			builder.Append(", LineBreakInQuotedFieldIsBadData = ");
			builder.Append(LineBreakInQuotedFieldIsBadData.ToString());
			builder.Append(", MemberTypes = ");
			builder.Append(MemberTypes.ToString());
			builder.Append(", MissingFieldFound = ");
			builder.Append(MissingFieldFound);
			builder.Append(", Mode = ");
			builder.Append(Mode.ToString());
			builder.Append(", NewLine = ");
			builder.Append((object)NewLine);
			builder.Append(", PrepareHeaderForMatch = ");
			builder.Append(PrepareHeaderForMatch);
			builder.Append(", ProcessFieldBufferSize = ");
			builder.Append(ProcessFieldBufferSize.ToString());
			builder.Append(", Quote = ");
			builder.Append(Quote.ToString());
			builder.Append(", ReadingExceptionOccurred = ");
			builder.Append(ReadingExceptionOccurred);
			builder.Append(", ReferenceHeaderPrefix = ");
			builder.Append(ReferenceHeaderPrefix);
			builder.Append(", SanitizeForInjection = ");
			builder.Append(SanitizeForInjection.ToString());
			builder.Append(", ShouldQuote = ");
			builder.Append(ShouldQuote);
			builder.Append(", ShouldSkipRecord = ");
			builder.Append(ShouldSkipRecord);
			builder.Append(", ShouldUseConstructorParameters = ");
			builder.Append(ShouldUseConstructorParameters);
			builder.Append(", TrimOptions = ");
			builder.Append(TrimOptions.ToString());
			builder.Append(", UseNewObjectForNullReferenceMembers = ");
			builder.Append(UseNewObjectForNullReferenceMembers.ToString());
			builder.Append(", WhiteSpaceChars = ");
			builder.Append((object)WhiteSpaceChars);
			return true;
		}

		public static bool operator !=(CsvConfiguration? left, CsvConfiguration? right)
		{
			return !(left == right);
		}

		public static bool operator ==(CsvConfiguration? left, CsvConfiguration? right)
		{
			if ((object)left != right)
			{
				return left?.Equals(right) ?? false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ((((((((((((((((((((((((((((((((((((((((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(newLine)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(AllowComments)) * -1521134295 + EqualityComparer<BadDataFound>.Default.GetHashCode(BadDataFound)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(BufferSize)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(CacheFields)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(Comment)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(CountBytes)) * -1521134295 + EqualityComparer<CultureInfo>.Default.GetHashCode(CultureInfo)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Delimiter)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(DetectDelimiter)) * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(DetectDelimiterValues)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(DetectColumnCountChanges)) * -1521134295 + EqualityComparer<IComparer<string>>.Default.GetHashCode(DynamicPropertySort)) * -1521134295 + EqualityComparer<Encoding>.Default.GetHashCode(Encoding)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(Escape)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(ExceptionMessagesContainRawData)) * -1521134295 + EqualityComparer<GetConstructor>.Default.GetHashCode(GetConstructor)) * -1521134295 + EqualityComparer<GetDynamicPropertyName>.Default.GetHashCode(GetDynamicPropertyName)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(HasHeaderRecord)) * -1521134295 + EqualityComparer<HeaderValidated>.Default.GetHashCode(HeaderValidated)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IgnoreBlankLines)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IgnoreReferences)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IncludePrivateMembers)) * -1521134295 + EqualityComparer<char[]>.Default.GetHashCode(InjectionCharacters)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(InjectionEscapeCharacter)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IsNewLineSet)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(LeaveOpen)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(LineBreakInQuotedFieldIsBadData)) * -1521134295 + EqualityComparer<MemberTypes>.Default.GetHashCode(MemberTypes)) * -1521134295 + EqualityComparer<MissingFieldFound>.Default.GetHashCode(MissingFieldFound)) * -1521134295 + EqualityComparer<CsvMode>.Default.GetHashCode(Mode)) * -1521134295 + EqualityComparer<PrepareHeaderForMatch>.Default.GetHashCode(PrepareHeaderForMatch)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(ProcessFieldBufferSize)) * -1521134295 + EqualityComparer<char>.Default.GetHashCode(Quote)) * -1521134295 + EqualityComparer<ReadingExceptionOccurred>.Default.GetHashCode(ReadingExceptionOccurred)) * -1521134295 + EqualityComparer<ReferenceHeaderPrefix>.Default.GetHashCode(ReferenceHeaderPrefix)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(SanitizeForInjection)) * -1521134295 + EqualityComparer<ShouldQuote>.Default.GetHashCode(ShouldQuote)) * -1521134295 + EqualityComparer<ShouldSkipRecord>.Default.GetHashCode(ShouldSkipRecord)) * -1521134295 + EqualityComparer<ShouldUseConstructorParameters>.Default.GetHashCode(ShouldUseConstructorParameters)) * -1521134295 + EqualityComparer<TrimOptions>.Default.GetHashCode(TrimOptions)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(UseNewObjectForNullReferenceMembers)) * -1521134295 + EqualityComparer<char[]>.Default.GetHashCode(WhiteSpaceChars);
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as CsvConfiguration);
		}

		public virtual bool Equals(CsvConfiguration? other)
		{
			if ((object)this != other)
			{
				if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(newLine, other.newLine) && EqualityComparer<bool>.Default.Equals(AllowComments, other.AllowComments) && EqualityComparer<BadDataFound>.Default.Equals(BadDataFound, other.BadDataFound) && EqualityComparer<int>.Default.Equals(BufferSize, other.BufferSize) && EqualityComparer<bool>.Default.Equals(CacheFields, other.CacheFields) && EqualityComparer<char>.Default.Equals(Comment, other.Comment) && EqualityComparer<bool>.Default.Equals(CountBytes, other.CountBytes) && EqualityComparer<CultureInfo>.Default.Equals(CultureInfo, other.CultureInfo) && EqualityComparer<string>.Default.Equals(Delimiter, other.Delimiter) && EqualityComparer<bool>.Default.Equals(DetectDelimiter, other.DetectDelimiter) && EqualityComparer<string[]>.Default.Equals(DetectDelimiterValues, other.DetectDelimiterValues) && EqualityComparer<bool>.Default.Equals(DetectColumnCountChanges, other.DetectColumnCountChanges) && EqualityComparer<IComparer<string>>.Default.Equals(DynamicPropertySort, other.DynamicPropertySort) && EqualityComparer<Encoding>.Default.Equals(Encoding, other.Encoding) && EqualityComparer<char>.Default.Equals(Escape, other.Escape) && EqualityComparer<bool>.Default.Equals(ExceptionMessagesContainRawData, other.ExceptionMessagesContainRawData) && EqualityComparer<GetConstructor>.Default.Equals(GetConstructor, other.GetConstructor) && EqualityComparer<GetDynamicPropertyName>.Default.Equals(GetDynamicPropertyName, other.GetDynamicPropertyName) && EqualityComparer<bool>.Default.Equals(HasHeaderRecord, other.HasHeaderRecord) && EqualityComparer<HeaderValidated>.Default.Equals(HeaderValidated, other.HeaderValidated) && EqualityComparer<bool>.Default.Equals(IgnoreBlankLines, other.IgnoreBlankLines) && EqualityComparer<bool>.Default.Equals(IgnoreReferences, other.IgnoreReferences) && EqualityComparer<bool>.Default.Equals(IncludePrivateMembers, other.IncludePrivateMembers) && EqualityComparer<char[]>.Default.Equals(InjectionCharacters, other.InjectionCharacters) && EqualityComparer<char>.Default.Equals(InjectionEscapeCharacter, other.InjectionEscapeCharacter) && EqualityComparer<bool>.Default.Equals(IsNewLineSet, other.IsNewLineSet) && EqualityComparer<bool>.Default.Equals(LeaveOpen, other.LeaveOpen) && EqualityComparer<bool>.Default.Equals(LineBreakInQuotedFieldIsBadData, other.LineBreakInQuotedFieldIsBadData) && EqualityComparer<MemberTypes>.Default.Equals(MemberTypes, other.MemberTypes) && EqualityComparer<MissingFieldFound>.Default.Equals(MissingFieldFound, other.MissingFieldFound) && EqualityComparer<CsvMode>.Default.Equals(Mode, other.Mode) && EqualityComparer<PrepareHeaderForMatch>.Default.Equals(PrepareHeaderForMatch, other.PrepareHeaderForMatch) && EqualityComparer<int>.Default.Equals(ProcessFieldBufferSize, other.ProcessFieldBufferSize) && EqualityComparer<char>.Default.Equals(Quote, other.Quote) && EqualityComparer<ReadingExceptionOccurred>.Default.Equals(ReadingExceptionOccurred, other.ReadingExceptionOccurred) && EqualityComparer<ReferenceHeaderPrefix>.Default.Equals(ReferenceHeaderPrefix, other.ReferenceHeaderPrefix) && EqualityComparer<bool>.Default.Equals(SanitizeForInjection, other.SanitizeForInjection) && EqualityComparer<ShouldQuote>.Default.Equals(ShouldQuote, other.ShouldQuote) && EqualityComparer<ShouldSkipRecord>.Default.Equals(ShouldSkipRecord, other.ShouldSkipRecord) && EqualityComparer<ShouldUseConstructorParameters>.Default.Equals(ShouldUseConstructorParameters, other.ShouldUseConstructorParameters) && EqualityComparer<TrimOptions>.Default.Equals(TrimOptions, other.TrimOptions) && EqualityComparer<bool>.Default.Equals(UseNewObjectForNullReferenceMembers, other.UseNewObjectForNullReferenceMembers))
				{
					return EqualityComparer<char[]>.Default.Equals(WhiteSpaceChars, other.WhiteSpaceChars);
				}
				return false;
			}
			return true;
		}

		public virtual CsvConfiguration _003CClone_003E_0024()
		{
			return new CsvConfiguration(this);
		}

		protected CsvConfiguration(CsvConfiguration original)
		{
			base._002Ector();
			newLine = original.newLine;
			AllowComments = original.AllowComments;
			BadDataFound = original.BadDataFound;
			BufferSize = original.BufferSize;
			CacheFields = original.CacheFields;
			Comment = original.Comment;
			CountBytes = original.CountBytes;
			CultureInfo = original.CultureInfo;
			Delimiter = original.Delimiter;
			DetectDelimiter = original.DetectDelimiter;
			DetectDelimiterValues = original.DetectDelimiterValues;
			DetectColumnCountChanges = original.DetectColumnCountChanges;
			DynamicPropertySort = original.DynamicPropertySort;
			Encoding = original.Encoding;
			Escape = original.Escape;
			ExceptionMessagesContainRawData = original.ExceptionMessagesContainRawData;
			GetConstructor = original.GetConstructor;
			GetDynamicPropertyName = original.GetDynamicPropertyName;
			HasHeaderRecord = original.HasHeaderRecord;
			HeaderValidated = original.HeaderValidated;
			IgnoreBlankLines = original.IgnoreBlankLines;
			IgnoreReferences = original.IgnoreReferences;
			IncludePrivateMembers = original.IncludePrivateMembers;
			InjectionCharacters = original.InjectionCharacters;
			InjectionEscapeCharacter = original.InjectionEscapeCharacter;
			IsNewLineSet = original.IsNewLineSet;
			LeaveOpen = original.LeaveOpen;
			LineBreakInQuotedFieldIsBadData = original.LineBreakInQuotedFieldIsBadData;
			MemberTypes = original.MemberTypes;
			MissingFieldFound = original.MissingFieldFound;
			Mode = original.Mode;
			PrepareHeaderForMatch = original.PrepareHeaderForMatch;
			ProcessFieldBufferSize = original.ProcessFieldBufferSize;
			Quote = original.Quote;
			ReadingExceptionOccurred = original.ReadingExceptionOccurred;
			ReferenceHeaderPrefix = original.ReferenceHeaderPrefix;
			SanitizeForInjection = original.SanitizeForInjection;
			ShouldQuote = original.ShouldQuote;
			ShouldSkipRecord = original.ShouldSkipRecord;
			ShouldUseConstructorParameters = original.ShouldUseConstructorParameters;
			TrimOptions = original.TrimOptions;
			UseNewObjectForNullReferenceMembers = original.UseNewObjectForNullReferenceMembers;
			WhiteSpaceChars = original.WhiteSpaceChars;
		}
	}
}
