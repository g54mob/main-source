using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	public class Configuration : IReaderConfiguration, IParserConfiguration, IWriterConfiguration, ISerializerConfiguration
	{
		private string delimiter;

		private char escape;

		private char quote;

		private string quoteString;

		private string doubleQuoteString;

		private CultureInfo cultureInfo;

		private readonly ClassMapCollection maps;

		public virtual TypeConverterOptionsCache TypeConverterOptionsCache { get; set; }

		public virtual TypeConverterCache TypeConverterCache { get; set; }

		public virtual bool HasHeaderRecord { get; set; }

		public virtual Action<bool, string[], int, ReadingContext> HeaderValidated { get; set; }

		public virtual Action<string[], int, ReadingContext> MissingFieldFound { get; set; }

		public virtual Action<ReadingContext> BadDataFound { get; set; }

		public virtual Func<CsvHelperException, bool> ReadingExceptionOccurred { get; set; }

		public virtual Func<string[], bool> ShouldSkipRecord { get; set; }

		public virtual bool LineBreakInQuotedFieldIsBadData { get; set; }

		public virtual bool SanitizeForInjection { get; set; }

		public virtual char[] InjectionCharacters { get; set; }

		public virtual char InjectionEscapeCharacter { get; set; }

		public virtual bool DetectColumnCountChanges { get; set; }

		public virtual Func<string, int, string> PrepareHeaderForMatch { get; set; }

		public virtual Func<Type, bool> ShouldUseConstructorParameters { get; set; }

		public virtual Func<Type, ConstructorInfo> GetConstructor { get; set; }

		public virtual IComparer<string> DynamicPropertySort { get; set; }

		public virtual bool IgnoreReferences { get; set; }

		public virtual TrimOptions TrimOptions { get; set; }

		public virtual string Delimiter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual char Escape
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		public virtual char Quote
		{
			get
			{
				return '\0';
			}
			set
			{
			}
		}

		public virtual string QuoteString => null;

		public virtual string DoubleQuoteString => null;

		public Func<string, WritingContext, bool> ShouldQuote { get; set; }

		public virtual char Comment { get; set; }

		public virtual bool AllowComments { get; set; }

		public virtual int BufferSize { get; set; }

		public virtual bool CountBytes { get; set; }

		public virtual Encoding Encoding { get; set; }

		public virtual CultureInfo CultureInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual bool IgnoreQuotes { get; set; }

		public virtual bool IncludePrivateMembers { get; set; }

		public virtual MemberTypes MemberTypes { get; set; }

		public virtual bool IgnoreBlankLines { get; set; }

		public virtual Func<Type, string, string> ReferenceHeaderPrefix { get; set; }

		public virtual ClassMapCollection Maps => null;

		public virtual bool UseNewObjectForNullReferenceMembers { get; set; }

		public Configuration()
		{
		}

		public Configuration(CultureInfo cultureInfo)
		{
		}

		public virtual TMap RegisterClassMap<TMap>() where TMap : ClassMap
		{
			return null;
		}

		public virtual ClassMap RegisterClassMap(Type classMapType)
		{
			return null;
		}

		public virtual void RegisterClassMap(ClassMap map)
		{
		}

		public virtual void UnregisterClassMap<TMap>() where TMap : ClassMap
		{
		}

		public virtual void UnregisterClassMap(Type classMapType)
		{
		}

		public virtual void UnregisterClassMap()
		{
		}

		public virtual ClassMap<T> AutoMap<T>()
		{
			return null;
		}

		public virtual ClassMap AutoMap(Type type)
		{
			return null;
		}
	}
}
