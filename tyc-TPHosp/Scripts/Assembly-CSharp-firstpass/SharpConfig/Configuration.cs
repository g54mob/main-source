using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SharpConfig
{
	public class Configuration : IEnumerable<Section>, IEnumerable
	{
		private static NumberFormatInfo mNumberFormat;

		private static DateTimeFormatInfo mDateTimeFormat;

		private static char mPreferredCommentChar;

		private static char mArrayElementSeparator;

		private static ITypeStringConverter mFallbackConverter;

		private static Dictionary<Type, ITypeStringConverter> mTypeStringConverters;

		internal readonly List<Section> mSections;

		internal static ITypeStringConverter FallbackConverter => mFallbackConverter;

		public static NumberFormatInfo NumberFormat
		{
			get
			{
				return mNumberFormat;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				mNumberFormat = value;
			}
		}

		public static DateTimeFormatInfo DateTimeFormat
		{
			get
			{
				return mDateTimeFormat;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				mDateTimeFormat = value;
			}
		}

		public static char[] ValidCommentChars { get; private set; }

		public static char PreferredCommentChar
		{
			get
			{
				return mPreferredCommentChar;
			}
			set
			{
				if (!Array.Exists(ValidCommentChars, (char c) => c == value))
				{
					throw new ArgumentException("The specified char '" + value + "' is not allowed as a comment char.");
				}
				mPreferredCommentChar = value;
			}
		}

		public static char ArrayElementSeparator
		{
			get
			{
				return mArrayElementSeparator;
			}
			set
			{
				if (value == '\0')
				{
					throw new ArgumentException("Zero-character is not allowed.");
				}
				mArrayElementSeparator = value;
			}
		}

		public static bool IgnoreInlineComments { get; set; }

		public static bool IgnorePreComments { get; set; }

		public int SectionCount => mSections.Count;

		public Section this[int index]
		{
			get
			{
				if (index < 0 || index >= mSections.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return mSections[index];
			}
		}

		public Section this[string name]
		{
			get
			{
				Section section = FindSection(name);
				if (section == null)
				{
					section = new Section(name);
					Add(section);
				}
				return section;
			}
		}

		static Configuration()
		{
			mNumberFormat = CultureInfo.InvariantCulture.NumberFormat;
			mDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
			ValidCommentChars = new char[3] { '#', ';', '\'' };
			mPreferredCommentChar = '#';
			mArrayElementSeparator = ',';
			mFallbackConverter = new FallbackStringConverter();
			mTypeStringConverters = new Dictionary<Type, ITypeStringConverter>
			{
				{
					typeof(bool),
					new BoolStringConverter()
				},
				{
					typeof(byte),
					new ByteStringConverter()
				},
				{
					typeof(char),
					new CharStringConverter()
				},
				{
					typeof(DateTime),
					new DateTimeStringConverter()
				},
				{
					typeof(decimal),
					new DecimalStringConverter()
				},
				{
					typeof(double),
					new DoubleStringConverter()
				},
				{
					typeof(Enum),
					new EnumStringConverter()
				},
				{
					typeof(short),
					new Int16StringConverter()
				},
				{
					typeof(int),
					new Int32StringConverter()
				},
				{
					typeof(long),
					new Int64StringConverter()
				},
				{
					typeof(sbyte),
					new SByteStringConverter()
				},
				{
					typeof(float),
					new SingleStringConverter()
				},
				{
					typeof(string),
					new StringStringConverter()
				},
				{
					typeof(ushort),
					new UInt16StringConverter()
				},
				{
					typeof(uint),
					new UInt32StringConverter()
				},
				{
					typeof(ulong),
					new UInt64StringConverter()
				}
			};
			IgnoreInlineComments = false;
			IgnorePreComments = false;
		}

		public Configuration()
		{
			mSections = new List<Section>();
		}

		public IEnumerator<Section> GetEnumerator()
		{
			return mSections.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(Section section)
		{
			if (section == null)
			{
				throw new ArgumentNullException("section");
			}
			if (Contains(section))
			{
				throw new ArgumentException("The specified section already exists in the configuration.");
			}
			mSections.Add(section);
		}

		public bool Remove(string sectionName)
		{
			if (string.IsNullOrEmpty(sectionName))
			{
				throw new ArgumentNullException("sectionName");
			}
			return Remove(FindSection(sectionName));
		}

		public bool Remove(Section section)
		{
			return mSections.Remove(section);
		}

		public void RemoveAllNamed(string sectionName)
		{
			if (string.IsNullOrEmpty(sectionName))
			{
				throw new ArgumentNullException("sectionName");
			}
			while (Remove(sectionName))
			{
			}
		}

		public void Clear()
		{
			mSections.Clear();
		}

		public bool Contains(Section section)
		{
			return mSections.Contains(section);
		}

		public bool Contains(string sectionName)
		{
			if (string.IsNullOrEmpty(sectionName))
			{
				throw new ArgumentNullException("sectionName");
			}
			return FindSection(sectionName) != null;
		}

		public bool Contains(string sectionName, string settingName)
		{
			if (string.IsNullOrEmpty(sectionName))
			{
				throw new ArgumentNullException("sectionName");
			}
			if (string.IsNullOrEmpty(settingName))
			{
				throw new ArgumentNullException("settingName");
			}
			return FindSection(sectionName)?.Contains(settingName) ?? false;
		}

		public static void RegisterTypeStringConverter(ITypeStringConverter converter)
		{
			if (converter == null)
			{
				throw new ArgumentNullException("converter");
			}
			Type convertibleType = converter.ConvertibleType;
			if (mTypeStringConverters.ContainsKey(convertibleType))
			{
				throw new InvalidOperationException($"A converter for type '{convertibleType.FullName}' is already registered.");
			}
			mTypeStringConverters.Add(convertibleType, converter);
		}

		public static void DeregisterTypeStringConverter(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!mTypeStringConverters.ContainsKey(type))
			{
				throw new InvalidOperationException($"No converter is registered for type '{type.FullName}'.");
			}
			mTypeStringConverters.Remove(type);
		}

		internal static ITypeStringConverter FindTypeStringConverter(Type type)
		{
			ITypeStringConverter value = null;
			if (!mTypeStringConverters.TryGetValue(type, out value))
			{
				value = mFallbackConverter;
			}
			return value;
		}

		public static Configuration LoadFromFile(string filename)
		{
			return LoadFromFile(filename, null);
		}

		public static Configuration LoadFromFile(string filename, Encoding encoding)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			if (!File.Exists(filename))
			{
				return null;
			}
			if (encoding != null)
			{
				return LoadFromString(File.ReadAllText(filename, encoding));
			}
			return LoadFromString(File.ReadAllText(filename));
		}

		public static Configuration LoadFromStream(Stream stream)
		{
			return LoadFromStream(stream, null);
		}

		public static Configuration LoadFromStream(Stream stream, Encoding encoding)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			string source = null;
			StreamReader streamReader = ((encoding == null) ? new StreamReader(stream) : new StreamReader(stream, encoding));
			using (streamReader)
			{
				source = streamReader.ReadToEnd();
			}
			return LoadFromString(source);
		}

		public static Configuration LoadFromString(string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return ConfigurationReader.ReadFromString(source);
		}

		public static Configuration LoadFromBinaryFile(string filename)
		{
			return LoadFromBinaryFile(filename, null);
		}

		public static Configuration LoadFromBinaryFile(string filename, BinaryReader reader)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			using FileStream stream = File.OpenRead(filename);
			return LoadFromBinaryStream(stream, reader);
		}

		public static Configuration LoadFromBinaryStream(Stream stream)
		{
			return LoadFromBinaryStream(stream, null);
		}

		public static Configuration LoadFromBinaryStream(Stream stream, BinaryReader reader)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			return ConfigurationReader.ReadFromBinaryStream(stream, reader);
		}

		public void SaveToFile(string filename)
		{
			SaveToFile(filename, null);
		}

		public void SaveToFile(string filename, Encoding encoding)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			using FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
			SaveToStream(stream, encoding);
		}

		public void SaveToStream(Stream stream)
		{
			SaveToStream(stream, null);
		}

		public void SaveToStream(Stream stream, Encoding encoding)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			ConfigurationWriter.WriteToStreamTextual(this, stream, encoding);
		}

		public void SaveToBinaryFile(string filename)
		{
			SaveToBinaryFile(filename, null);
		}

		public void SaveToBinaryFile(string filename, BinaryWriter writer)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentNullException("filename");
			}
			using FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
			SaveToBinaryStream(stream, writer);
		}

		public void SaveToBinaryStream(Stream stream)
		{
			SaveToBinaryStream(stream, null);
		}

		public void SaveToBinaryStream(Stream stream, BinaryWriter writer)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			ConfigurationWriter.WriteToStreamBinary(this, stream, writer);
		}

		public IEnumerable<Section> GetSectionsNamed(string name)
		{
			List<Section> list = new List<Section>();
			foreach (Section mSection in mSections)
			{
				if (string.Equals(mSection.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					list.Add(mSection);
				}
			}
			return list;
		}

		private Section FindSection(string name)
		{
			foreach (Section mSection in mSections)
			{
				if (string.Equals(mSection.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					return mSection;
				}
			}
			return null;
		}
	}
}
