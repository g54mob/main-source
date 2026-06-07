using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Simulator
{
	public static class CSVParser
	{
		public static List<List<string>> ParseFromPath(string path, bool hasHeader, bool removeHeader = true, Delimiter delimiter = Delimiter.Auto, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			return ParseFromString(File.ReadAllText(path, encoding), hasHeader, removeHeader, delimiter);
		}

		public static List<List<string>> ParseFromString(string data, bool hasHeader, bool removeHeader = true, Delimiter delimiter = Delimiter.Auto)
		{
			if (delimiter == Delimiter.Auto)
			{
				delimiter = DelimiterUtils.DetectDelimiterFromContent(data);
			}
			ConvertToCrlf(ref data);
			List<List<string>> list = new List<List<string>>();
			List<string> row = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			int num = 0;
			ReadOnlySpan<char> value = delimiter.ToChar().ToString().AsSpan();
			ReadOnlySpan<char> value2 = "\r\n".AsSpan();
			ReadOnlySpan<char> value3 = "\"".AsSpan();
			ReadOnlySpan<char> value4 = "\"\"".AsSpan();
			while (num < data.Length)
			{
				int length = ((num > data.Length - 2) ? 1 : 2);
				ReadOnlySpan<char> span = data.AsSpan(num, length);
				if (span.StartsWith(value))
				{
					if (flag)
					{
						stringBuilder.Append(delimiter.ToChar());
					}
					else
					{
						AddCell(row, stringBuilder);
					}
					num++;
				}
				else if (span.StartsWith(value2))
				{
					if (flag)
					{
						stringBuilder.Append("\r\n");
					}
					else
					{
						AddCell(row, stringBuilder);
						if (IsRowNonEmpty(row))
						{
							AddRow(list, ref row);
						}
						else
						{
							row.Clear();
						}
					}
					num += 2;
				}
				else if (span.StartsWith(value4))
				{
					stringBuilder.Append("\"");
					num += 2;
				}
				else if (span.StartsWith(value3))
				{
					flag = !flag;
					num++;
				}
				else
				{
					stringBuilder.Append(span[0]);
					num++;
				}
			}
			if (IsRowNonEmpty(row) || stringBuilder.Length > 0)
			{
				AddCell(row, stringBuilder);
				AddRow(list, ref row);
			}
			if (hasHeader && removeHeader && list.Count > 0)
			{
				list.RemoveAt(0);
			}
			if (hasHeader && !removeHeader && list.Count == 1)
			{
				list.Clear();
			}
			return list;
		}

		private static bool IsRowNonEmpty(List<string> row)
		{
			if (row.Count > 0)
			{
				return row.Any((string cell) => !string.IsNullOrWhiteSpace(cell));
			}
			return false;
		}

		private static void AddCell(List<string> row, StringBuilder cell)
		{
			row.Add(cell.ToString());
			cell.Clear();
		}

		private static void AddRow(List<List<string>> sheet, ref List<string> row)
		{
			sheet.Add(new List<string>(row));
			row.Clear();
		}

		private static void ConvertToCrlf(ref string data)
		{
			data = Regex.Replace(data, "\\r\\n|\\r|\\n", "\r\n");
		}

		private static object ConvertValue(string value, Type targetType)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				if (targetType == typeof(string))
				{
					return string.Empty;
				}
				if (!targetType.IsValueType)
				{
					return null;
				}
				return Activator.CreateInstance(targetType);
			}
			if (targetType == typeof(string))
			{
				return value;
			}
			if (targetType == typeof(int) || targetType == typeof(int?))
			{
				if (!int.TryParse(value, out var result))
				{
					return null;
				}
				return result;
			}
			if (targetType == typeof(decimal) || targetType == typeof(decimal?))
			{
				if (!decimal.TryParse(value, out var result2))
				{
					return null;
				}
				return result2;
			}
			if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
			{
				if (!DateTime.TryParse(value, out var result3))
				{
					return null;
				}
				return result3;
			}
			if (targetType == typeof(bool) || targetType == typeof(bool?))
			{
				if (!bool.TryParse(value, out var result4))
				{
					return null;
				}
				return result4;
			}
			if (targetType == typeof(double) || targetType == typeof(double?))
			{
				if (!double.TryParse(value, out var result5))
				{
					return null;
				}
				return result5;
			}
			throw new NotSupportedException($"Type {targetType} is not supported for conversion.");
		}
	}
}
