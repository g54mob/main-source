using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public class CsvWriter : IWriter, IWriterRow, IDisposable
	{
		private readonly TextWriter writer;

		private readonly CsvContext context;

		private readonly Lazy<RecordManager> recordManager;

		private readonly TypeConverterCache typeConverterCache;

		private readonly TrimOptions trimOptions;

		private readonly ShouldQuote shouldQuote;

		private readonly MemberMapData reusableMemberMapData = new MemberMapData(null);

		private readonly Dictionary<Type, TypeConverterOptions> typeConverterOptionsCache = new Dictionary<Type, TypeConverterOptions>();

		private readonly string quoteString;

		private readonly char quote;

		private readonly CultureInfo cultureInfo;

		private readonly char comment;

		private readonly bool hasHeaderRecord;

		private readonly bool includePrivateMembers;

		private readonly IComparer<string> dynamicPropertySort;

		private readonly string delimiter;

		private readonly bool leaveOpen;

		private readonly string newLine;

		private readonly char[] injectionCharacters;

		private readonly char injectionEscapeCharacter;

		private readonly bool sanitizeForInjection;

		private readonly CsvMode mode;

		private readonly string escapeQuoteString;

		private readonly string escapeDelimiterString;

		private readonly string escapeNewlineString;

		private bool disposed;

		private bool hasHeaderBeenWritten;

		private int row = 1;

		private int index;

		private char[] buffer;

		private int bufferSize;

		private int bufferPosition;

		private Type fieldType;

		public virtual string[] HeaderRecord { get; private set; }

		public virtual int Row => row;

		public virtual int Index => index;

		public virtual CsvContext Context => context;

		public virtual IWriterConfiguration Configuration { get; private set; }

		public CsvWriter(TextWriter writer, CultureInfo culture, bool leaveOpen = false)
			: this(writer, new CsvConfiguration(culture)
			{
				LeaveOpen = leaveOpen
			})
		{
		}

		public CsvWriter(TextWriter writer, CsvConfiguration configuration)
		{
			CsvWriter csvWriter = this;
			configuration.Validate();
			this.writer = writer;
			Configuration = configuration;
			context = new CsvContext(this);
			typeConverterCache = context.TypeConverterCache;
			recordManager = new Lazy<RecordManager>(() => ObjectResolver.Current.Resolve<RecordManager>(new object[1] { csvWriter }));
			comment = configuration.Comment;
			bufferSize = configuration.BufferSize;
			delimiter = configuration.Delimiter;
			cultureInfo = configuration.CultureInfo;
			dynamicPropertySort = configuration.DynamicPropertySort;
			escapeDelimiterString = new string(configuration.Delimiter.SelectMany((char c) => new char[2] { configuration.Escape, c }).ToArray());
			escapeNewlineString = new string(configuration.NewLine.SelectMany((char c) => new char[2] { configuration.Escape, c }).ToArray());
			escapeQuoteString = new string(new char[2] { configuration.Escape, configuration.Quote });
			hasHeaderRecord = configuration.HasHeaderRecord;
			includePrivateMembers = configuration.IncludePrivateMembers;
			injectionCharacters = configuration.InjectionCharacters;
			injectionEscapeCharacter = configuration.InjectionEscapeCharacter;
			leaveOpen = configuration.LeaveOpen;
			mode = configuration.Mode;
			newLine = configuration.NewLine;
			quote = configuration.Quote;
			quoteString = configuration.Quote.ToString();
			sanitizeForInjection = configuration.SanitizeForInjection;
			shouldQuote = configuration.ShouldQuote;
			trimOptions = configuration.TrimOptions;
			buffer = new char[bufferSize];
		}

		public virtual void WriteConvertedField(string field, Type fieldType)
		{
			this.fieldType = fieldType;
			if (field != null)
			{
				WriteField(field);
			}
		}

		public virtual void WriteField(string field)
		{
			if (field != null && (trimOptions & TrimOptions.Trim) == TrimOptions.Trim)
			{
				field = field.Trim();
			}
			if ((object)fieldType == null)
			{
				fieldType = typeof(string);
			}
			ShouldQuoteArgs args = new ShouldQuoteArgs(field, fieldType, this);
			bool flag = shouldQuote(args);
			WriteField(field, flag);
		}

		public virtual void WriteField(string field, bool shouldQuote)
		{
			if (mode == CsvMode.RFC4180)
			{
				if (shouldQuote)
				{
					field = field?.Replace(quoteString, escapeQuoteString);
					field = quote + field + quote;
				}
			}
			else if (mode == CsvMode.Escape)
			{
				field = field?.Replace(quoteString, escapeQuoteString).Replace(delimiter, escapeDelimiterString).Replace(newLine, escapeNewlineString);
			}
			if (sanitizeForInjection)
			{
				field = SanitizeForInjection(field);
			}
			if (index > 0)
			{
				WriteToBuffer(delimiter);
			}
			WriteToBuffer(field);
			index++;
			fieldType = null;
		}

		public virtual void WriteField<T>(T field)
		{
			Type type = ((field == null) ? typeof(string) : field.GetType());
			ITypeConverter converter = typeConverterCache.GetConverter(type);
			WriteField(field, converter);
		}

		public virtual void WriteField<T>(T field, ITypeConverter converter)
		{
			Type type = ((field == null) ? typeof(string) : field.GetType());
			reusableMemberMapData.TypeConverter = converter;
			if (!typeConverterOptionsCache.TryGetValue(type, out var value))
			{
				value = TypeConverterOptions.Merge(new TypeConverterOptions
				{
					CultureInfo = cultureInfo
				}, context.TypeConverterOptionsCache.GetOptions(type));
				typeConverterOptionsCache.Add(type, value);
			}
			reusableMemberMapData.TypeConverterOptions = value;
			string field2 = converter.ConvertToString(field, this, reusableMemberMapData);
			WriteConvertedField(field2, type);
		}

		public virtual void WriteField<T, TConverter>(T field)
		{
			ITypeConverter converter = typeConverterCache.GetConverter<TConverter>();
			WriteField(field, converter);
		}

		public virtual void WriteComment(string text)
		{
			WriteField(comment + text, shouldQuote: false);
		}

		public virtual void WriteHeader<T>()
		{
			WriteHeader(typeof(T));
		}

		public virtual void WriteHeader(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type == typeof(object))
			{
				return;
			}
			if (context.Maps[type] == null)
			{
				context.Maps.Add(context.AutoMap(type));
			}
			MemberMapCollection memberMapCollection = new MemberMapCollection();
			memberMapCollection.AddMembers(context.Maps[type]);
			List<string> list = new List<string>();
			foreach (MemberMap item in memberMapCollection)
			{
				if (!CanWrite(item))
				{
					continue;
				}
				if (item.Data.IndexEnd >= item.Data.Index)
				{
					int num = item.Data.IndexEnd - item.Data.Index + 1;
					for (int i = 1; i <= num; i++)
					{
						string text = item.Data.Names.FirstOrDefault() + i;
						WriteField(text);
						list.Add(text);
					}
				}
				else
				{
					string text2 = item.Data.Names.FirstOrDefault();
					WriteField(text2);
					list.Add(text2);
				}
			}
			HeaderRecord = list.ToArray();
			hasHeaderBeenWritten = true;
		}

		public virtual void WriteDynamicHeader(IDynamicMetaObjectProvider record)
		{
			if (record == null)
			{
				throw new ArgumentNullException("record");
			}
			List<string> list = record.GetMetaObject(Expression.Constant(record)).GetDynamicMemberNames().ToList();
			if (dynamicPropertySort != null)
			{
				list = list.OrderBy((string name) => name, dynamicPropertySort).ToList();
			}
			HeaderRecord = list.ToArray();
			foreach (string item in list)
			{
				WriteField(item);
			}
			hasHeaderBeenWritten = true;
		}

		public virtual void WriteRecord<T>(T record)
		{
			if (record is IDynamicMetaObjectProvider record2 && hasHeaderRecord && !hasHeaderBeenWritten)
			{
				WriteDynamicHeader(record2);
				NextRecord();
			}
			try
			{
				recordManager.Value.Write(record);
				hasHeaderBeenWritten = true;
			}
			catch (Exception ex)
			{
				throw (ex as CsvHelperException) ?? new WriterException(context, "An unexpected error occurred.", ex);
			}
		}

		public virtual void WriteRecords(IEnumerable records)
		{
			try
			{
				foreach (object record2 in records)
				{
					Type type = record2.GetType();
					if (record2 is IDynamicMetaObjectProvider record)
					{
						if (hasHeaderRecord && !hasHeaderBeenWritten)
						{
							WriteDynamicHeader(record);
							NextRecord();
						}
					}
					else
					{
						bool isPrimitive = type.GetTypeInfo().IsPrimitive;
						if (hasHeaderRecord && !hasHeaderBeenWritten && !isPrimitive)
						{
							WriteHeader(type);
							NextRecord();
						}
					}
					try
					{
						recordManager.Value.Write(record2);
					}
					catch (TargetInvocationException ex)
					{
						throw ex.InnerException;
					}
					NextRecord();
				}
			}
			catch (Exception ex2)
			{
				throw (ex2 as CsvHelperException) ?? new WriterException(context, "An unexpected error occurred.", ex2);
			}
		}

		public virtual void WriteRecords<T>(IEnumerable<T> records)
		{
			try
			{
				Type type = typeof(T);
				bool isPrimitive = type.GetTypeInfo().IsPrimitive;
				if (hasHeaderRecord && !hasHeaderBeenWritten && !isPrimitive && type != typeof(object))
				{
					WriteHeader(type);
					if (hasHeaderBeenWritten)
					{
						NextRecord();
					}
				}
				bool flag = type == typeof(object);
				foreach (T record2 in records)
				{
					if (flag)
					{
						type = record2.GetType();
					}
					if (record2 is IDynamicMetaObjectProvider record)
					{
						if (hasHeaderRecord && !hasHeaderBeenWritten)
						{
							WriteDynamicHeader(record);
							NextRecord();
						}
					}
					else
					{
						isPrimitive = type.GetTypeInfo().IsPrimitive;
						if (hasHeaderRecord && !hasHeaderBeenWritten && !isPrimitive)
						{
							WriteHeader(type);
							NextRecord();
						}
					}
					try
					{
						recordManager.Value.Write(record2);
					}
					catch (TargetInvocationException ex)
					{
						throw ex.InnerException;
					}
					NextRecord();
				}
			}
			catch (Exception ex2)
			{
				throw (ex2 as CsvHelperException) ?? new WriterException(context, "An unexpected error occurred.", ex2);
			}
		}

		public virtual async Task WriteRecordsAsync(IEnumerable records, CancellationToken cancellationToken = default(CancellationToken))
		{
			_ = 2;
			try
			{
				foreach (object record in records)
				{
					cancellationToken.ThrowIfCancellationRequested();
					Type type = record.GetType();
					if (record is IDynamicMetaObjectProvider record2)
					{
						if (hasHeaderRecord && !hasHeaderBeenWritten)
						{
							WriteDynamicHeader(record2);
							await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					else
					{
						bool isPrimitive = type.GetTypeInfo().IsPrimitive;
						if (hasHeaderRecord && !hasHeaderBeenWritten && !isPrimitive)
						{
							WriteHeader(type);
							await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					try
					{
						recordManager.Value.Write(record);
					}
					catch (TargetInvocationException ex)
					{
						throw ex.InnerException;
					}
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception ex2)
			{
				throw (ex2 as CsvHelperException) ?? new WriterException(context, "An unexpected error occurred.", ex2);
			}
		}

		public virtual async Task WriteRecordsAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken = default(CancellationToken))
		{
			_ = 3;
			try
			{
				Type recordType = typeof(T);
				bool isPrimitive = recordType.GetTypeInfo().IsPrimitive;
				if (hasHeaderRecord && !hasHeaderBeenWritten && !isPrimitive && recordType != typeof(object))
				{
					WriteHeader(recordType);
					if (hasHeaderBeenWritten)
					{
						await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				bool getRecordType = recordType == typeof(object);
				foreach (T record in records)
				{
					cancellationToken.ThrowIfCancellationRequested();
					if (getRecordType)
					{
						recordType = record.GetType();
					}
					if (record is IDynamicMetaObjectProvider record2)
					{
						if (hasHeaderRecord && !hasHeaderBeenWritten)
						{
							WriteDynamicHeader(record2);
							await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					else
					{
						isPrimitive = recordType.GetTypeInfo().IsPrimitive;
						if (hasHeaderRecord && !hasHeaderBeenWritten && !isPrimitive)
						{
							WriteHeader(recordType);
							await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
						}
					}
					try
					{
						recordManager.Value.Write(record);
					}
					catch (TargetInvocationException ex)
					{
						throw ex.InnerException;
					}
					await NextRecordAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception ex2)
			{
				throw (ex2 as CsvHelperException) ?? new WriterException(context, "An unexpected error occurred.", ex2);
			}
		}

		public virtual void NextRecord()
		{
			WriteToBuffer(newLine);
			FlushBuffer();
			index = 0;
			row++;
		}

		public virtual async Task NextRecordAsync()
		{
			WriteToBuffer(newLine);
			await FlushBufferAsync();
			index = 0;
			row++;
		}

		public virtual void Flush()
		{
			FlushBuffer();
			writer.Flush();
		}

		public virtual async Task FlushAsync()
		{
			await FlushBufferAsync().ConfigureAwait(continueOnCapturedContext: false);
			await writer.FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void FlushBuffer()
		{
			writer.Write(buffer, 0, bufferPosition);
			bufferPosition = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual async Task FlushBufferAsync()
		{
			await writer.WriteAsync(buffer, 0, bufferPosition);
			bufferPosition = 0;
		}

		public virtual bool CanWrite(MemberMap memberMap)
		{
			bool flag = memberMap.Data.Ignore;
			if (memberMap.Data.Member is PropertyInfo propertyInfo)
			{
				flag = flag || (propertyInfo.GetGetMethod() == null && !includePrivateMembers) || propertyInfo.GetGetMethod(nonPublic: true) == null;
			}
			return !flag;
		}

		public virtual Type GetTypeForRecord<T>(T record)
		{
			Type type = typeof(T);
			if (type == typeof(object))
			{
				type = record.GetType();
			}
			return type;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual string SanitizeForInjection(string field)
		{
			if (string.IsNullOrEmpty(field))
			{
				return field;
			}
			if (ArrayHelper.Contains(injectionCharacters, field[0]))
			{
				return injectionEscapeCharacter + field;
			}
			if (field[0] == quote && ArrayHelper.Contains(injectionCharacters, field[1]))
			{
				return field[0].ToString() + injectionEscapeCharacter + field.Substring(1);
			}
			return field;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void WriteToBuffer(string value)
		{
			int num = value?.Length ?? 0;
			if (value == null || num == 0)
			{
				return;
			}
			int num2 = bufferPosition + num;
			if (num2 >= bufferSize)
			{
				while (num2 >= bufferSize)
				{
					bufferSize *= 2;
				}
				Array.Resize(ref buffer, bufferSize);
			}
			value.CopyTo(0, buffer, bufferPosition, num);
			bufferPosition += num;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				Flush();
				if (disposing && !leaveOpen)
				{
					writer.Dispose();
				}
				buffer = null;
				disposed = true;
			}
		}
	}
}
