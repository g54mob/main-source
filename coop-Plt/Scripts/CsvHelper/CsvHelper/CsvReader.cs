using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public class CsvReader : IReader, IReaderRow, IDisposable
	{
		private readonly Lazy<RecordManager> recordManager;

		private readonly bool detectColumnCountChanges;

		private readonly Dictionary<string, List<int>> namedIndexes = new Dictionary<string, List<int>>();

		private readonly Dictionary<string, (string, int)> namedIndexCache = new Dictionary<string, (string, int)>();

		private readonly Dictionary<Type, TypeConverterOptions> typeConverterOptionsCache = new Dictionary<Type, TypeConverterOptions>();

		private readonly MemberMapData reusableMemberMapData = new MemberMapData(null);

		private readonly bool hasHeaderRecord;

		private readonly HeaderValidated headerValidated;

		private readonly ShouldSkipRecord shouldSkipRecord;

		private readonly ReadingExceptionOccurred readingExceptionOccurred;

		private readonly CultureInfo cultureInfo;

		private readonly bool ignoreBlankLines;

		private readonly MissingFieldFound missingFieldFound;

		private readonly bool includePrivateMembers;

		private readonly PrepareHeaderForMatch prepareHeaderForMatch;

		private CsvContext context;

		private bool disposed;

		private IParser parser;

		private int columnCount;

		private int currentIndex = -1;

		private bool hasBeenRead;

		private string[] headerRecord;

		public virtual int ColumnCount => columnCount;

		public virtual int CurrentIndex => currentIndex;

		public virtual string[] HeaderRecord => headerRecord;

		public virtual CsvContext Context => context;

		public virtual IReaderConfiguration Configuration { get; private set; }

		public virtual IParser Parser => parser;

		public virtual string this[int index]
		{
			get
			{
				CheckHasBeenRead();
				return GetField(index);
			}
		}

		public virtual string this[string name]
		{
			get
			{
				CheckHasBeenRead();
				return GetField(name);
			}
		}

		public virtual string this[string name, int index]
		{
			get
			{
				CheckHasBeenRead();
				return GetField(name, index);
			}
		}

		public CsvReader(TextReader reader, CultureInfo culture, bool leaveOpen = false)
			: this(new CsvParser(reader, culture, leaveOpen))
		{
		}

		public CsvReader(TextReader reader, CsvConfiguration configuration)
			: this(new CsvParser(reader, configuration))
		{
		}

		public CsvReader(IParser parser)
		{
			Configuration = (parser.Configuration as IReaderConfiguration) ?? throw new ConfigurationException("The IParser configuration must implement IReaderConfiguration to be used in CsvReader.");
			this.parser = parser ?? throw new ArgumentNullException("parser");
			context = parser.Context ?? throw new InvalidOperationException("For IParser to be used in CsvReader, Context must also implement CsvContext.");
			context.Reader = this;
			recordManager = new Lazy<RecordManager>(() => ObjectResolver.Current.Resolve<RecordManager>(new object[1] { this }));
			cultureInfo = Configuration.CultureInfo;
			detectColumnCountChanges = Configuration.DetectColumnCountChanges;
			hasHeaderRecord = Configuration.HasHeaderRecord;
			headerValidated = Configuration.HeaderValidated;
			ignoreBlankLines = Configuration.IgnoreBlankLines;
			includePrivateMembers = Configuration.IncludePrivateMembers;
			missingFieldFound = Configuration.MissingFieldFound;
			prepareHeaderForMatch = Configuration.PrepareHeaderForMatch;
			readingExceptionOccurred = Configuration.ReadingExceptionOccurred;
			shouldSkipRecord = Configuration.ShouldSkipRecord;
		}

		public virtual bool ReadHeader()
		{
			if (!hasHeaderRecord)
			{
				throw new ReaderException(context, "Configuration.HasHeaderRecord is false.");
			}
			headerRecord = parser.Record;
			ParseNamedIndexes();
			return headerRecord != null;
		}

		public virtual void ValidateHeader<T>()
		{
			ValidateHeader(typeof(T));
		}

		public virtual void ValidateHeader(Type type)
		{
			if (!hasHeaderRecord)
			{
				throw new InvalidOperationException("Validation can't be performed on a the header if no header exists. HasHeaderRecord can't be false.");
			}
			CheckHasBeenRead();
			if (headerRecord == null)
			{
				throw new InvalidOperationException("The header must be read before it can be validated.");
			}
			if (context.Maps[type] == null)
			{
				context.Maps.Add(context.AutoMap(type));
			}
			ClassMap map = context.Maps[type];
			List<InvalidHeader> list = new List<InvalidHeader>();
			ValidateHeader(map, list);
			HeaderValidatedArgs args = new HeaderValidatedArgs(list.ToArray(), context);
			headerValidated?.Invoke(args);
		}

		protected virtual void ValidateHeader(ClassMap map, List<InvalidHeader> invalidHeaders)
		{
			foreach (ParameterMap parameterMap in map.ParameterMaps)
			{
				if (!parameterMap.Data.Ignore && !parameterMap.Data.IsConstantSet && (!parameterMap.Data.IsIndexSet || parameterMap.Data.IsNameSet))
				{
					if (parameterMap.ConstructorTypeMap != null)
					{
						ValidateHeader(parameterMap.ConstructorTypeMap, invalidHeaders);
					}
					else if (parameterMap.ReferenceMap != null)
					{
						ValidateHeader(parameterMap.ReferenceMap.Data.Mapping, invalidHeaders);
					}
					else if (GetFieldIndex(parameterMap.Data.Names.ToArray(), parameterMap.Data.NameIndex, isTryGet: true) == -1 && !parameterMap.Data.IsOptional)
					{
						invalidHeaders.Add(new InvalidHeader
						{
							Index = parameterMap.Data.NameIndex,
							Names = parameterMap.Data.Names.ToList()
						});
					}
				}
			}
			foreach (MemberMap memberMap in map.MemberMaps)
			{
				if (!memberMap.Data.Ignore && CanRead(memberMap) && memberMap.Data.ReadingConvertExpression == null && !memberMap.Data.IsConstantSet && (!memberMap.Data.IsIndexSet || memberMap.Data.IsNameSet) && GetFieldIndex(memberMap.Data.Names.ToArray(), memberMap.Data.NameIndex, isTryGet: true) == -1 && !memberMap.Data.IsOptional)
				{
					invalidHeaders.Add(new InvalidHeader
					{
						Index = memberMap.Data.NameIndex,
						Names = memberMap.Data.Names.ToList()
					});
				}
			}
			foreach (MemberReferenceMap referenceMap in map.ReferenceMaps)
			{
				if (CanRead(referenceMap))
				{
					ValidateHeader(referenceMap.Data.Mapping, invalidHeaders);
				}
			}
		}

		public virtual bool Read()
		{
			bool flag;
			do
			{
				flag = parser.Read();
			}
			while (flag && shouldSkipRecord(new ShouldSkipRecordArgs(parser.Record)));
			currentIndex = -1;
			hasBeenRead = true;
			if (detectColumnCountChanges && flag)
			{
				if (columnCount > 0 && columnCount != parser.Count)
				{
					BadDataException ex = new BadDataException(context, "An inconsistent number of columns has been detected.");
					ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex);
					ReadingExceptionOccurred obj = readingExceptionOccurred;
					if (obj == null || obj(args))
					{
						throw ex;
					}
				}
				columnCount = parser.Count;
			}
			return flag;
		}

		public virtual async Task<bool> ReadAsync()
		{
			bool flag;
			do
			{
				flag = await parser.ReadAsync();
			}
			while (flag && shouldSkipRecord(new ShouldSkipRecordArgs(parser.Record)));
			currentIndex = -1;
			hasBeenRead = true;
			if (detectColumnCountChanges && flag)
			{
				if (columnCount > 0 && columnCount != parser.Count)
				{
					BadDataException ex = new BadDataException(context, "An inconsistent number of columns has been detected.");
					ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex);
					if (readingExceptionOccurred?.Invoke(args) ?? true)
					{
						throw ex;
					}
				}
				columnCount = parser.Count;
			}
			return flag;
		}

		public virtual string GetField(int index)
		{
			CheckHasBeenRead();
			currentIndex = index;
			if (index >= parser.Count || index < 0)
			{
				if (ignoreBlankLines)
				{
					MissingFieldFoundArgs args = new MissingFieldFoundArgs(null, index, context);
					missingFieldFound?.Invoke(args);
				}
				return null;
			}
			return parser[index];
		}

		public virtual string GetField(string name)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name);
			if (fieldIndex < 0)
			{
				return null;
			}
			return GetField(fieldIndex);
		}

		public virtual string GetField(string name, int index)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name, index);
			if (fieldIndex < 0)
			{
				return null;
			}
			return GetField(fieldIndex);
		}

		public virtual object GetField(Type type, int index)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
			return GetField(type, index, converter);
		}

		public virtual object GetField(Type type, string name)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
			return GetField(type, name, converter);
		}

		public virtual object GetField(Type type, string name, int index)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
			return GetField(type, name, index, converter);
		}

		public virtual object GetField(Type type, int index, ITypeConverter converter)
		{
			CheckHasBeenRead();
			reusableMemberMapData.Index = index;
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
			string field = GetField(index);
			return converter.ConvertFromString(field, this, reusableMemberMapData);
		}

		public virtual object GetField(Type type, string name, ITypeConverter converter)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name);
			return GetField(type, fieldIndex, converter);
		}

		public virtual object GetField(Type type, string name, int index, ITypeConverter converter)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name, index);
			return GetField(type, fieldIndex, converter);
		}

		public virtual T GetField<T>(int index)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
			return GetField<T>(index, converter);
		}

		public virtual T GetField<T>(string name)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
			return GetField<T>(name, converter);
		}

		public virtual T GetField<T>(string name, int index)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
			return GetField<T>(name, index, converter);
		}

		public virtual T GetField<T>(int index, ITypeConverter converter)
		{
			CheckHasBeenRead();
			if (index >= parser.Count || index < 0)
			{
				currentIndex = index;
				if (ignoreBlankLines)
				{
					MissingFieldFoundArgs args = new MissingFieldFoundArgs(null, index, context);
					missingFieldFound?.Invoke(args);
				}
				return default(T);
			}
			return (T)GetField(typeof(T), index, converter);
		}

		public virtual T GetField<T>(string name, ITypeConverter converter)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name);
			return GetField<T>(fieldIndex, converter);
		}

		public virtual T GetField<T>(string name, int index, ITypeConverter converter)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name, index);
			return GetField<T>(fieldIndex, converter);
		}

		public virtual T GetField<T, TConverter>(int index) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();
			TConverter val = ObjectResolver.Current.Resolve<TConverter>(new object[0]);
			return GetField<T>(index, val);
		}

		public virtual T GetField<T, TConverter>(string name) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();
			TConverter val = ObjectResolver.Current.Resolve<TConverter>(new object[0]);
			return GetField<T>(name, val);
		}

		public virtual T GetField<T, TConverter>(string name, int index) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();
			TConverter val = ObjectResolver.Current.Resolve<TConverter>(new object[0]);
			return GetField<T>(name, index, val);
		}

		public virtual bool TryGetField(Type type, int index, out object field)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
			return TryGetField(type, index, converter, out field);
		}

		public virtual bool TryGetField(Type type, string name, out object field)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
			return TryGetField(type, name, converter, out field);
		}

		public virtual bool TryGetField(Type type, string name, int index, out object field)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter(type);
			return TryGetField(type, name, index, converter, out field);
		}

		public virtual bool TryGetField(Type type, int index, ITypeConverter converter, out object field)
		{
			CheckHasBeenRead();
			try
			{
				field = GetField(type, index, converter);
				return true;
			}
			catch
			{
				field = (type.GetTypeInfo().IsValueType ? ObjectResolver.Current.Resolve(type) : null);
				return false;
			}
		}

		public virtual bool TryGetField(Type type, string name, ITypeConverter converter, out object field)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name, 0, isTryGet: true);
			if (fieldIndex == -1)
			{
				field = (type.GetTypeInfo().IsValueType ? ObjectResolver.Current.Resolve(type) : null);
				return false;
			}
			return TryGetField(type, fieldIndex, converter, out field);
		}

		public virtual bool TryGetField(Type type, string name, int index, ITypeConverter converter, out object field)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name, index, isTryGet: true);
			if (fieldIndex == -1)
			{
				field = (type.GetTypeInfo().IsValueType ? ObjectResolver.Current.Resolve(type) : null);
				return false;
			}
			return TryGetField(type, fieldIndex, converter, out field);
		}

		public virtual bool TryGetField<T>(int index, out T field)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
			return TryGetField<T>(index, converter, out field);
		}

		public virtual bool TryGetField<T>(string name, out T field)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
			return TryGetField<T>(name, converter, out field);
		}

		public virtual bool TryGetField<T>(string name, int index, out T field)
		{
			CheckHasBeenRead();
			ITypeConverter converter = context.TypeConverterCache.GetConverter<T>();
			return TryGetField<T>(name, index, converter, out field);
		}

		public virtual bool TryGetField<T>(int index, ITypeConverter converter, out T field)
		{
			CheckHasBeenRead();
			try
			{
				field = GetField<T>(index, converter);
				return true;
			}
			catch
			{
				field = default(T);
				return false;
			}
		}

		public virtual bool TryGetField<T>(string name, ITypeConverter converter, out T field)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name, 0, isTryGet: true);
			if (fieldIndex == -1)
			{
				field = default(T);
				return false;
			}
			return TryGetField<T>(fieldIndex, converter, out field);
		}

		public virtual bool TryGetField<T>(string name, int index, ITypeConverter converter, out T field)
		{
			CheckHasBeenRead();
			int fieldIndex = GetFieldIndex(name, index, isTryGet: true);
			if (fieldIndex == -1)
			{
				field = default(T);
				return false;
			}
			return TryGetField<T>(fieldIndex, converter, out field);
		}

		public virtual bool TryGetField<T, TConverter>(int index, out T field) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();
			TConverter val = ObjectResolver.Current.Resolve<TConverter>(new object[0]);
			return TryGetField<T>(index, val, out field);
		}

		public virtual bool TryGetField<T, TConverter>(string name, out T field) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();
			TConverter val = ObjectResolver.Current.Resolve<TConverter>(new object[0]);
			return TryGetField<T>(name, val, out field);
		}

		public virtual bool TryGetField<T, TConverter>(string name, int index, out T field) where TConverter : ITypeConverter
		{
			CheckHasBeenRead();
			TConverter val = ObjectResolver.Current.Resolve<TConverter>(new object[0]);
			return TryGetField<T>(name, index, val, out field);
		}

		public virtual T GetRecord<T>()
		{
			CheckHasBeenRead();
			if (headerRecord == null && hasHeaderRecord)
			{
				ReadHeader();
				ValidateHeader<T>();
				if (!Read())
				{
					return default(T);
				}
			}
			T result;
			try
			{
				return recordManager.Value.Create<T>();
			}
			catch (Exception ex)
			{
				CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
				ReadingExceptionOccurred obj = readingExceptionOccurred;
				if (obj == null || obj(args))
				{
					if (ex is CsvHelperException)
					{
						throw;
					}
					throw ex2;
				}
				result = default(T);
			}
			return result;
		}

		public virtual T GetRecord<T>(T anonymousTypeDefinition)
		{
			if (anonymousTypeDefinition == null)
			{
				throw new ArgumentNullException("anonymousTypeDefinition");
			}
			if (!anonymousTypeDefinition.GetType().IsAnonymous())
			{
				throw new ArgumentException("Argument is not an anonymous type.", "anonymousTypeDefinition");
			}
			return GetRecord<T>();
		}

		public virtual object GetRecord(Type type)
		{
			CheckHasBeenRead();
			if (headerRecord == null && hasHeaderRecord)
			{
				ReadHeader();
				ValidateHeader(type);
				if (!Read())
				{
					return null;
				}
			}
			try
			{
				return recordManager.Value.Create(type);
			}
			catch (Exception ex)
			{
				CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
				ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
				ReadingExceptionOccurred obj = readingExceptionOccurred;
				if (obj == null || obj(args))
				{
					if (ex is CsvHelperException)
					{
						throw;
					}
					throw ex2;
				}
				return null;
			}
		}

		public virtual IEnumerable<T> GetRecords<T>()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CsvReader", "GetRecords<T>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. e.g. .ToList() Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
			}
			if (hasHeaderRecord && headerRecord == null)
			{
				if (!Read())
				{
					yield break;
				}
				ReadHeader();
				ValidateHeader<T>();
			}
			while (Read())
			{
				T val;
				try
				{
					val = recordManager.Value.Create<T>();
				}
				catch (Exception ex)
				{
					CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
					ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
					if (readingExceptionOccurred?.Invoke(args) ?? true)
					{
						if (ex is CsvHelperException)
						{
							throw;
						}
						throw ex2;
					}
					continue;
				}
				yield return val;
			}
		}

		public virtual IEnumerable<T> GetRecords<T>(T anonymousTypeDefinition)
		{
			if (anonymousTypeDefinition == null)
			{
				throw new ArgumentNullException("anonymousTypeDefinition");
			}
			if (!anonymousTypeDefinition.GetType().IsAnonymous())
			{
				throw new ArgumentException("Argument is not an anonymous type.", "anonymousTypeDefinition");
			}
			return GetRecords<T>();
		}

		public virtual IEnumerable<object> GetRecords(Type type)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CsvReader", "GetRecords<object>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. e.g. .ToList() Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
			}
			if (hasHeaderRecord && headerRecord == null)
			{
				if (!Read())
				{
					yield break;
				}
				ReadHeader();
				ValidateHeader(type);
			}
			while (Read())
			{
				object obj;
				try
				{
					obj = recordManager.Value.Create(type);
				}
				catch (Exception ex)
				{
					CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
					ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
					if (readingExceptionOccurred?.Invoke(args) ?? true)
					{
						if (ex is CsvHelperException)
						{
							throw;
						}
						throw ex2;
					}
					continue;
				}
				yield return obj;
			}
		}

		public virtual IEnumerable<T> EnumerateRecords<T>(T record)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("CsvReader", "GetRecords<T>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. e.g. .ToList() Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
			}
			if (hasHeaderRecord && headerRecord == null)
			{
				if (!Read())
				{
					yield break;
				}
				ReadHeader();
				ValidateHeader<T>();
			}
			while (Read())
			{
				try
				{
					recordManager.Value.Hydrate(record);
				}
				catch (Exception ex)
				{
					CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
					ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
					if (readingExceptionOccurred?.Invoke(args) ?? true)
					{
						if (ex is CsvHelperException)
						{
							throw;
						}
						throw ex2;
					}
					continue;
				}
				yield return record;
			}
		}

		public virtual int GetFieldIndex(string name, int index = 0, bool isTryGet = false)
		{
			return GetFieldIndex(new string[1] { name }, index, isTryGet);
		}

		public virtual int GetFieldIndex(string[] names, int index = 0, bool isTryGet = false, bool isOptional = false)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			if (!hasHeaderRecord)
			{
				throw new ReaderException(context, "There is no header record to determine the index by name.");
			}
			if (headerRecord == null)
			{
				throw new ReaderException(context, "The header has not been read. You must call ReadHeader() before any fields can be retrieved by name.");
			}
			string key = string.Join("_", names) + index;
			if (namedIndexCache.ContainsKey(key))
			{
				var (key2, index2) = namedIndexCache[key];
				return namedIndexes[key2][index2];
			}
			string text = null;
			for (int i = 0; i < names.Length; i++)
			{
				string header = names[i];
				PrepareHeaderForMatchArgs args = new PrepareHeaderForMatchArgs(header, i);
				string text2 = prepareHeaderForMatch(args);
				if (namedIndexes.ContainsKey(text2))
				{
					text = text2;
					break;
				}
			}
			if (text == null || index >= namedIndexes[text].Count)
			{
				if (!isTryGet && !isOptional)
				{
					MissingFieldFoundArgs args2 = new MissingFieldFoundArgs(names, index, context);
					missingFieldFound?.Invoke(args2);
				}
				return -1;
			}
			namedIndexCache.Add(key, (text, index));
			return namedIndexes[text][index];
		}

		public virtual bool CanRead(MemberMap memberMap)
		{
			bool flag = memberMap.Data.Ignore;
			PropertyInfo propertyInfo = memberMap.Data.Member as PropertyInfo;
			if (propertyInfo != null)
			{
				flag = flag || (propertyInfo.GetSetMethod() == null && !includePrivateMembers) || propertyInfo.GetSetMethod(nonPublic: true) == null;
			}
			return !flag;
		}

		public virtual bool CanRead(MemberReferenceMap memberReferenceMap)
		{
			bool flag = false;
			PropertyInfo propertyInfo = memberReferenceMap.Data.Member as PropertyInfo;
			if (propertyInfo != null)
			{
				flag = (propertyInfo.GetSetMethod() == null && !includePrivateMembers) || propertyInfo.GetSetMethod(nonPublic: true) == null;
			}
			return !flag;
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
				if (disposing)
				{
					parser.Dispose();
				}
				context = null;
				disposed = true;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void CheckHasBeenRead()
		{
			if (!hasBeenRead)
			{
				throw new ReaderException(context, "You must call read on the reader before accessing its data.");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void ParseNamedIndexes()
		{
			if (headerRecord == null)
			{
				throw new ReaderException(context, "No header record was found.");
			}
			namedIndexes.Clear();
			for (int i = 0; i < headerRecord.Length; i++)
			{
				PrepareHeaderForMatchArgs args = new PrepareHeaderForMatchArgs(headerRecord[i], i);
				string key = prepareHeaderForMatch(args);
				if (namedIndexes.ContainsKey(key))
				{
					namedIndexes[key].Add(i);
					continue;
				}
				namedIndexes[key] = new List<int> { i };
			}
		}
	}
}
