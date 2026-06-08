using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace LINQtoCSV
{
	internal class FieldMapper<T>
	{
		protected class TypeFieldInfo : IComparable<TypeFieldInfo>
		{
			public int index = int.MaxValue;

			public string name;

			public bool canBeNull = true;

			public NumberStyles inputNumberStyle = NumberStyles.Any;

			public string outputFormat;

			public bool hasColumnAttribute;

			public MemberInfo memberInfo;

			public Type fieldType;

			public TypeConverter typeConverter;

			public MethodInfo parseNumberMethod;

			public MethodInfo parseExactMethod;

			public int charLength;

			public int CompareTo(TypeFieldInfo other)
			{
				return index.CompareTo(other.index);
			}

			public override string ToString()
			{
				return $"Index: {index}, Name: {name}";
			}
		}

		protected TypeFieldInfo[] m_IndexToInfo;

		protected IDictionary<int, int> _mappingIndexes = new Dictionary<int, int>();

		protected Dictionary<string, TypeFieldInfo> m_NameToInfo;

		protected CsvFileDescription m_fileDescription;

		protected string m_fileName;

		private TypeFieldInfo AnalyzeTypeField(MemberInfo mi, bool allRequiredFieldsMustHaveFieldIndex, bool allCsvColumnFieldsMustHaveFieldIndex)
		{
			TypeFieldInfo typeFieldInfo = new TypeFieldInfo();
			typeFieldInfo.memberInfo = mi;
			if (mi is PropertyInfo)
			{
				typeFieldInfo.fieldType = ((PropertyInfo)mi).PropertyType;
			}
			else
			{
				typeFieldInfo.fieldType = ((FieldInfo)mi).FieldType;
			}
			typeFieldInfo.parseNumberMethod = typeFieldInfo.fieldType.GetMethod("Parse", new Type[3]
			{
				typeof(string),
				typeof(NumberStyles),
				typeof(IFormatProvider)
			});
			if ((object)typeFieldInfo.parseNumberMethod == null)
			{
				if (m_fileDescription.UseOutputFormatForParsingCsvValue)
				{
					typeFieldInfo.parseExactMethod = typeFieldInfo.fieldType.GetMethod("ParseExact", new Type[3]
					{
						typeof(string),
						typeof(string),
						typeof(IFormatProvider)
					});
				}
				typeFieldInfo.typeConverter = null;
				if ((object)typeFieldInfo.parseExactMethod == null)
				{
					typeFieldInfo.typeConverter = TypeDescriptor.GetConverter(typeFieldInfo.fieldType);
				}
			}
			typeFieldInfo.index = int.MaxValue;
			typeFieldInfo.name = mi.Name;
			typeFieldInfo.inputNumberStyle = NumberStyles.Any;
			typeFieldInfo.outputFormat = "";
			typeFieldInfo.hasColumnAttribute = false;
			typeFieldInfo.charLength = 0;
			object[] customAttributes = mi.GetCustomAttributes(typeof(CsvColumnAttribute), inherit: true);
			foreach (object obj in customAttributes)
			{
				CsvColumnAttribute csvColumnAttribute = (CsvColumnAttribute)obj;
				if (!string.IsNullOrEmpty(csvColumnAttribute.Name))
				{
					typeFieldInfo.name = csvColumnAttribute.Name;
				}
				typeFieldInfo.index = csvColumnAttribute.FieldIndex;
				typeFieldInfo.hasColumnAttribute = true;
				typeFieldInfo.canBeNull = csvColumnAttribute.CanBeNull;
				typeFieldInfo.outputFormat = csvColumnAttribute.OutputFormat;
				typeFieldInfo.inputNumberStyle = csvColumnAttribute.NumberStyle;
				typeFieldInfo.charLength = csvColumnAttribute.CharLength;
			}
			if (allCsvColumnFieldsMustHaveFieldIndex && typeFieldInfo.hasColumnAttribute && typeFieldInfo.index == int.MaxValue)
			{
				throw new ToBeWrittenButMissingFieldIndexException(typeof(T).ToString(), typeFieldInfo.name);
			}
			if (allRequiredFieldsMustHaveFieldIndex && !typeFieldInfo.canBeNull && typeFieldInfo.index == int.MaxValue)
			{
				throw new RequiredButMissingFieldIndexException(typeof(T).ToString(), typeFieldInfo.name);
			}
			return typeFieldInfo;
		}

		protected void AnalyzeType(Type type, bool allRequiredFieldsMustHaveFieldIndex, bool allCsvColumnFieldsMustHaveFieldIndex)
		{
			m_NameToInfo.Clear();
			MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
			foreach (MemberInfo memberInfo in members)
			{
				if (memberInfo.MemberType == MemberTypes.Field || memberInfo.MemberType == MemberTypes.Property)
				{
					TypeFieldInfo typeFieldInfo = AnalyzeTypeField(memberInfo, allRequiredFieldsMustHaveFieldIndex, allCsvColumnFieldsMustHaveFieldIndex);
					m_NameToInfo[typeFieldInfo.name] = typeFieldInfo;
				}
			}
			int count = m_NameToInfo.Keys.Count;
			m_IndexToInfo = new TypeFieldInfo[count];
			_mappingIndexes = new Dictionary<int, int>();
			int num = 0;
			foreach (KeyValuePair<string, TypeFieldInfo> item in m_NameToInfo)
			{
				m_IndexToInfo[num++] = item.Value;
			}
			Array.Sort(m_IndexToInfo);
			int num2 = int.MinValue;
			string fieldName = "";
			TypeFieldInfo[] indexToInfo = m_IndexToInfo;
			foreach (TypeFieldInfo typeFieldInfo2 in indexToInfo)
			{
				if (typeFieldInfo2.index == num2 && typeFieldInfo2.index != int.MaxValue)
				{
					throw new DuplicateFieldIndexException(typeof(T).ToString(), typeFieldInfo2.name, fieldName, typeFieldInfo2.index);
				}
				num2 = typeFieldInfo2.index;
				fieldName = typeFieldInfo2.name;
			}
		}

		public FieldMapper(CsvFileDescription fileDescription, string fileName, bool writingFile)
		{
			if (!fileDescription.FirstLineHasColumnNames && !fileDescription.EnforceCsvColumnAttribute)
			{
				throw new CsvColumnAttributeRequiredException();
			}
			m_fileDescription = fileDescription;
			m_fileName = fileName;
			m_NameToInfo = new Dictionary<string, TypeFieldInfo>();
			AnalyzeType(typeof(T), !fileDescription.FirstLineHasColumnNames, writingFile && !fileDescription.FirstLineHasColumnNames);
		}

		public void WriteNames(List<string> row)
		{
			row.Clear();
			for (int i = 0; i < m_IndexToInfo.Length; i++)
			{
				TypeFieldInfo typeFieldInfo = m_IndexToInfo[i];
				if (!m_fileDescription.EnforceCsvColumnAttribute || typeFieldInfo.hasColumnAttribute)
				{
					row.Add(typeFieldInfo.name);
				}
			}
		}

		public void WriteObject(T obj, List<string> row)
		{
			row.Clear();
			for (int i = 0; i < m_IndexToInfo.Length; i++)
			{
				TypeFieldInfo typeFieldInfo = m_IndexToInfo[i];
				if (!m_fileDescription.EnforceCsvColumnAttribute || typeFieldInfo.hasColumnAttribute)
				{
					object obj2 = null;
					obj2 = ((!(typeFieldInfo.memberInfo is PropertyInfo)) ? ((FieldInfo)typeFieldInfo.memberInfo).GetValue(obj) : ((PropertyInfo)typeFieldInfo.memberInfo).GetValue(obj, null));
					string item = null;
					if (obj2 != null)
					{
						item = ((!(obj2 is IFormattable)) ? obj2.ToString() : ((IFormattable)obj2).ToString(typeFieldInfo.outputFormat, m_fileDescription.FileCultureInfo));
					}
					row.Add(item);
				}
			}
		}
	}
}
