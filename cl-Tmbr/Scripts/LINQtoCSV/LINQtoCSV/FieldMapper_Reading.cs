using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LINQtoCSV
{
	internal class FieldMapper_Reading<T> : FieldMapper<T> where T : new()
	{
		public FieldMapper_Reading(CsvFileDescription fileDescription, string fileName, bool writingFile)
			: base(fileDescription, fileName, writingFile)
		{
		}

		public void ReadNames(IDataRow row)
		{
			int num = 0;
			for (int i = 0; i < row.Count; i++)
			{
				if (!m_NameToInfo.ContainsKey(row[i].Value))
				{
					if (!m_fileDescription.IgnoreUnknownColumns)
					{
						throw new NameNotInTypeException(typeof(T).ToString(), row[i].Value, m_fileName);
					}
				}
				else
				{
					_mappingIndexes.Add(i, num);
					num++;
				}
			}
			for (int j = 0; j < row.Count; j++)
			{
				if (_mappingIndexes.ContainsKey(j))
				{
					m_IndexToInfo[_mappingIndexes[j]] = m_NameToInfo[row[j].Value];
					if (m_fileDescription.EnforceCsvColumnAttribute && !m_IndexToInfo[j].hasColumnAttribute)
					{
						throw new MissingCsvColumnAttributeException(typeof(T).ToString(), row[j].Value, m_fileName);
					}
				}
			}
		}

		public List<int> GetCharLengths()
		{
			if (!m_fileDescription.NoSeparatorChar)
			{
				return null;
			}
			return m_IndexToInfo.Select((TypeFieldInfo e) => e.charLength).ToList();
		}

		public T ReadObject(IDataRow row, AggregatedException ae)
		{
			if (row.Count > m_IndexToInfo.Length && !m_fileDescription.IgnoreUnknownColumns)
			{
				throw new TooManyDataFieldsException(typeof(T).ToString(), row[0].LineNbr, m_fileName);
			}
			T val = new T();
			int num = ((_mappingIndexes.Count > 0) ? row.Count : Math.Min(row.Count, m_IndexToInfo.Length));
			for (int i = 0; i < num; i++)
			{
				TypeFieldInfo typeFieldInfo;
				if (m_fileDescription.IgnoreUnknownColumns && _mappingIndexes.Count > 0)
				{
					if (!_mappingIndexes.ContainsKey(i))
					{
						continue;
					}
					typeFieldInfo = m_IndexToInfo[_mappingIndexes[i]];
				}
				else
				{
					typeFieldInfo = m_IndexToInfo[i];
				}
				if (m_fileDescription.EnforceCsvColumnAttribute && !typeFieldInfo.hasColumnAttribute)
				{
					throw new TooManyNonCsvColumnDataFieldsException(typeof(T).ToString(), row[i].LineNbr, m_fileName);
				}
				if (!m_fileDescription.FirstLineHasColumnNames && typeFieldInfo.index == int.MaxValue)
				{
					throw new MissingFieldIndexException(typeof(T).ToString(), row[i].LineNbr, m_fileName);
				}
				if (m_fileDescription.UseFieldIndexForReadingData && !m_fileDescription.FirstLineHasColumnNames && typeFieldInfo.index > row.Count)
				{
					throw new WrongFieldIndexException(typeof(T).ToString(), row[i].LineNbr, m_fileName);
				}
				int index = (m_fileDescription.UseFieldIndexForReadingData ? (typeFieldInfo.index - 1) : i);
				string value = row[index].Value;
				if (value == null)
				{
					if (!typeFieldInfo.canBeNull)
					{
						ae.AddException(new MissingRequiredFieldException(typeof(T).ToString(), typeFieldInfo.name, row[i].LineNbr, m_fileName));
					}
					continue;
				}
				try
				{
					object obj = null;
					obj = ((typeFieldInfo.typeConverter != null) ? typeFieldInfo.typeConverter.ConvertFromString(null, m_fileDescription.FileCultureInfo, value) : (((object)typeFieldInfo.parseExactMethod != null) ? typeFieldInfo.parseExactMethod.Invoke(typeFieldInfo.fieldType, new object[3] { value, typeFieldInfo.outputFormat, m_fileDescription.FileCultureInfo }) : (((object)typeFieldInfo.parseNumberMethod == null) ? value : typeFieldInfo.parseNumberMethod.Invoke(typeFieldInfo.fieldType, new object[3] { value, typeFieldInfo.inputNumberStyle, m_fileDescription.FileCultureInfo }))));
					if (typeFieldInfo.memberInfo is PropertyInfo)
					{
						((PropertyInfo)typeFieldInfo.memberInfo).SetValue(val, obj, null);
					}
					else
					{
						((FieldInfo)typeFieldInfo.memberInfo).SetValue(val, obj);
					}
				}
				catch (Exception ex)
				{
					if (ex is TargetInvocationException)
					{
						ex = ex.InnerException;
					}
					if (ex is FormatException)
					{
						ex = new WrongDataFormatException(typeof(T).ToString(), typeFieldInfo.name, value, row[i].LineNbr, m_fileName, ex);
					}
					ae.AddException(ex);
				}
			}
			for (int j = row.Count; j < m_IndexToInfo.Length; j++)
			{
				TypeFieldInfo typeFieldInfo2 = m_IndexToInfo[j];
				if ((!m_fileDescription.EnforceCsvColumnAttribute || typeFieldInfo2.hasColumnAttribute) && !typeFieldInfo2.canBeNull)
				{
					ae.AddException(new MissingRequiredFieldException(typeof(T).ToString(), typeFieldInfo2.name, row[row.Count - 1].LineNbr, m_fileName));
				}
			}
			return val;
		}
	}
}
