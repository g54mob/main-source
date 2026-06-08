using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Amazon.Runtime.Internal.Util
{
	public class IniFile
	{
		private const string sectionNamePrefix = "[";

		private const string sectionNameSuffix = "]";

		private const string keyValueSeparator = "=";

		private const string semiColonComment = ";";

		private const string hashComment = "#";

		private OptimisticLockedTextFile textFile;

		private Logger logger;

		public string FilePath => textFile.FilePath;

		private List<string> Lines => textFile.Lines;

		public IniFile(string filePath)
		{
			logger = Logger.GetLogger(GetType());
			textFile = new OptimisticLockedTextFile(filePath);
			Validate();
		}

		public void Persist()
		{
			Validate();
			textFile.Persist();
		}

		public void RenameSection(string oldSectionName, string newSectionName)
		{
			RenameSection(oldSectionName, newSectionName, force: false);
		}

		public void RenameSection(string oldSectionName, string newSectionName, bool force)
		{
			int lineNumber = 0;
			if (TrySeekSection(oldSectionName, ref lineNumber))
			{
				int lineNumber2 = 0;
				if (TrySeekSection(newSectionName, ref lineNumber2))
				{
					if (!string.Equals(oldSectionName, newSectionName, StringComparison.Ordinal))
					{
						if (!force)
						{
							throw new ArgumentException("Cannot rename section. The destination section " + newSectionName + " already exists." + GetLineMessage(lineNumber2));
						}
						DeleteSection(newSectionName);
						RenameSection(oldSectionName, newSectionName, force: false);
					}
				}
				else
				{
					Lines[lineNumber] = "[" + newSectionName + "]";
				}
				return;
			}
			throw new ArgumentException("Cannot rename section. The source section " + oldSectionName + " does not exist.");
		}

		public void CopySection(string fromSectionName, string toSectionName, Dictionary<string, string> replaceProperties)
		{
			CopySection(fromSectionName, toSectionName, replaceProperties, force: false);
		}

		public void CopySection(string fromSectionName, string toSectionName, Dictionary<string, string> replaceProperties, bool force)
		{
			int lineNumber = 0;
			if (TrySeekSection(fromSectionName, ref lineNumber))
			{
				int lineNumber2 = 0;
				if (TrySeekSection(toSectionName, ref lineNumber2))
				{
					if (!string.Equals(fromSectionName, toSectionName, StringComparison.Ordinal))
					{
						if (!force)
						{
							throw new ArgumentException("Cannot copy section. The destination section " + toSectionName + " already exists." + GetLineMessage(lineNumber2));
						}
						DeleteSection(toSectionName);
						CopySection(fromSectionName, toSectionName, replaceProperties, force: false);
					}
					return;
				}
				int num = lineNumber;
				string sectionName;
				for (lineNumber++; lineNumber < Lines.Count && !TryParseSection(Lines[lineNumber], out sectionName); lineNumber++)
				{
				}
				Lines.Add("[" + toSectionName + "]");
				for (int i = num + 1; i < lineNumber; i++)
				{
					if (TryParseProperty(Lines[i], out var propertyName, out var _) && replaceProperties.ContainsKey(propertyName))
					{
						Lines.Add(GetPropertyLine(propertyName, replaceProperties[propertyName]));
					}
					else
					{
						Lines.Add(Lines[i]);
					}
				}
				return;
			}
			throw new ArgumentException("Cannot copy section. The source section " + fromSectionName + " does not exist.");
		}

		public virtual void EditSection(string sectionName, SortedDictionary<string, string> properties)
		{
			EnsureSectionExists(sectionName);
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			foreach (KeyValuePair<string, string> property in properties)
			{
				dictionary.Add(property.Key, property.Value);
			}
			int lineNumber = 0;
			if (!TrySeekSection(sectionName, ref lineNumber))
			{
				return;
			}
			lineNumber++;
			string propertyName;
			string propertyValue;
			NestedProperty nestedProperty;
			while (SeekProperty(ref lineNumber, out propertyName, out propertyValue, out nestedProperty))
			{
				bool flag = false;
				if (dictionary.ContainsKey(propertyName))
				{
					if (!string.Equals(dictionary[propertyName], propertyValue))
					{
						if (dictionary[propertyName] == null)
						{
							Lines.RemoveAt(lineNumber);
							flag = true;
						}
						else
						{
							Lines[lineNumber] = GetPropertyLine(propertyName, dictionary[propertyName]);
						}
					}
					dictionary.Remove(propertyName);
				}
				if (!flag)
				{
					lineNumber++;
				}
			}
			foreach (KeyValuePair<string, string> property2 in properties)
			{
				if (dictionary.ContainsKey(property2.Key) && dictionary[property2.Key] != null)
				{
					Lines.Insert(lineNumber++, property2.Key + "=" + property2.Value);
				}
			}
		}

		public void EnsureSectionExists(string sectionName)
		{
			int lineNumber = 0;
			if (!TrySeekSection(sectionName, ref lineNumber))
			{
				Lines.Add("[" + sectionName + "]");
			}
		}

		public void DeleteSection(string sectionName)
		{
			int lineNumber = 0;
			if (TrySeekSection(sectionName, ref lineNumber))
			{
				Lines.RemoveAt(lineNumber);
				while (lineNumber < Lines.Count && !IsSection(Lines[lineNumber]))
				{
					Lines.RemoveAt(lineNumber);
				}
			}
		}

		public virtual HashSet<string> ListSectionNames()
		{
			HashSet<string> hashSet = new HashSet<string>();
			int lineNumber = 0;
			string sectionName = null;
			while (SeekSection(ref lineNumber, out sectionName))
			{
				hashSet.Add(sectionName);
				lineNumber++;
			}
			return hashSet;
		}

		public bool SectionExists(string sectionName)
		{
			int lineNumber = 0;
			return TrySeekSection(sectionName, ref lineNumber);
		}

		public bool SectionExists(Regex sectionNameRegex, out string sectionName)
		{
			int lineNumber = 0;
			return TrySeekSection(sectionNameRegex, ref lineNumber, out sectionName);
		}

		public virtual bool TryGetSection(string sectionName, out Dictionary<string, string> properties)
		{
			int lineNumber = 0;
			properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (TrySeekSection(sectionName, ref lineNumber))
			{
				lineNumber++;
				string propertyName;
				string propertyValue;
				NestedProperty nestedProperty;
				while (SeekProperty(ref lineNumber, out propertyName, out propertyValue, out nestedProperty))
				{
					if (IsDuplicateProperty(properties, propertyName, sectionName, lineNumber))
					{
						properties.Clear();
						return false;
					}
					properties.Add(propertyName, propertyValue);
					lineNumber++;
				}
				return true;
			}
			return false;
		}

		public bool TryGetSection(Regex sectionNameRegex, out Dictionary<string, string> properties)
		{
			string sectionName;
			return TryGetSection(sectionNameRegex, out sectionName, out properties);
		}

		public bool TryGetSection(Regex sectionNameRegex, out Dictionary<string, string> properties, out Dictionary<string, Dictionary<string, string>> nestedProperties)
		{
			string sectionName;
			return TryGetSection(sectionNameRegex, out sectionName, out properties, out nestedProperties);
		}

		public bool TryGetSection(Regex sectionNameRegex, out string sectionName, out Dictionary<string, string> properties)
		{
			int lineNumber = 0;
			properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (TrySeekSection(sectionNameRegex, ref lineNumber, out sectionName))
			{
				lineNumber++;
				string propertyName;
				string propertyValue;
				NestedProperty nestedProperty;
				while (SeekProperty(ref lineNumber, out propertyName, out propertyValue, out nestedProperty))
				{
					if (IsDuplicateProperty(properties, propertyName, sectionName, lineNumber))
					{
						sectionName = null;
						properties.Clear();
						return false;
					}
					properties.Add(propertyName, propertyValue);
					lineNumber++;
				}
				return true;
			}
			return false;
		}

		public bool TryGetSection(Regex sectionNameRegex, out string sectionName, out Dictionary<string, string> properties, out Dictionary<string, Dictionary<string, string>> nestedProperties)
		{
			int lineNumber = 0;
			properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			nestedProperties = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
			if (TrySeekSection(sectionNameRegex, ref lineNumber, out sectionName))
			{
				lineNumber++;
				string propertyName;
				string propertyValue;
				NestedProperty nestedProperty;
				while (SeekProperty(ref lineNumber, out propertyName, out propertyValue, out nestedProperty))
				{
					if (IsDuplicateProperty(properties, propertyName, sectionName, lineNumber))
					{
						sectionName = null;
						properties.Clear();
						return false;
					}
					if (nestedProperty != null && nestedProperty.ParentKey != null)
					{
						foreach (Tuple<string, string> item in nestedProperty.SubpropertyKeys.Zip(nestedProperty.SubpropertyValues, (string k, string v) => new Tuple<string, string>(k, v)).ToList())
						{
							if (nestedProperties.ContainsKey(nestedProperty.ParentKey))
							{
								nestedProperties[nestedProperty.ParentKey][item.Item1] = item.Item2;
								continue;
							}
							nestedProperties.Add(nestedProperty.ParentKey, new Dictionary<string, string> { { item.Item1, item.Item2 } });
						}
					}
					else
					{
						properties.Add(propertyName, propertyValue);
					}
					lineNumber++;
				}
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return textFile.ToString();
		}

		private bool IsDuplicateProperty(Dictionary<string, string> properties, string propertyName, string sectionName, int lineNumber)
		{
			bool flag = properties.ContainsKey(propertyName);
			if (flag)
			{
				logger.InfoFormat("Skipping section {0} because of duplicate property {1}.  {2}", sectionName, propertyName, GetLineMessage(lineNumber));
			}
			return flag;
		}

		private void Validate()
		{
			for (int i = 0; i < Lines.Count; i++)
			{
				string line = Lines[i];
				if (!IsProperty(line) && !IsSection(line) && !IsCommentOrBlank(line))
				{
					throw new InvalidDataException(GetErrorMessage(i));
				}
			}
		}

		private bool TrySeekSection(Regex sectionNameRegex, ref int lineNumber, out string sectionName)
		{
			string sectionName2 = null;
			while (SeekSection(ref lineNumber, out sectionName2) && !sectionNameRegex.IsMatch(sectionName2))
			{
				lineNumber++;
			}
			sectionName = sectionName2;
			if (sectionName2 != null)
			{
				return sectionNameRegex.IsMatch(sectionName2);
			}
			return false;
		}

		private bool TrySeekSection(string sectionName, ref int lineNumber)
		{
			string sectionName2 = null;
			while (SeekSection(ref lineNumber, out sectionName2) && !string.Equals(sectionName, sectionName2, StringComparison.Ordinal))
			{
				lineNumber++;
			}
			return string.Equals(sectionName, sectionName2, StringComparison.Ordinal);
		}

		private bool SeekSection(ref int lineNumber, out string sectionName)
		{
			while (lineNumber < Lines.Count)
			{
				if (TryParseSection(Lines[lineNumber], out sectionName))
				{
					return true;
				}
				lineNumber++;
			}
			sectionName = null;
			return false;
		}

		private bool SeekProperty(ref int lineNumber, out string propertyName, out string propertyValue, out NestedProperty nestedProperty)
		{
			while (lineNumber < Lines.Count)
			{
				nestedProperty = null;
				if (TryParseProperty(Lines[lineNumber], out propertyName, out propertyValue))
				{
					propertyName = propertyName.ToLowerInvariant();
					if (string.IsNullOrEmpty(propertyValue))
					{
						lineNumber++;
						TryParseSubproperties(ref lineNumber, propertyName, out nestedProperty);
					}
					return true;
				}
				if (IsSection(Lines[lineNumber]))
				{
					return false;
				}
				if (IsCommentOrBlank(Lines[lineNumber]))
				{
					lineNumber++;
					continue;
				}
				throw new InvalidDataException(GetErrorMessage(lineNumber));
			}
			nestedProperty = null;
			propertyName = null;
			propertyValue = null;
			return false;
		}

		private bool TryParseSubproperties(ref int lineNumber, string propertyName, out NestedProperty nestedProperty)
		{
			nestedProperty = new NestedProperty();
			while (lineNumber < Lines.Count)
			{
				string text = Lines[lineNumber];
				string text2 = text.Trim();
				if (!StartsWithWhitespace(text) || IsSection(text))
				{
					lineNumber--;
					return false;
				}
				if (!IsCommentOrBlank(text))
				{
					if (!StartsWithWhitespace(text))
					{
						throw new InvalidDataException(GetErrorMessage(lineNumber));
					}
					int num = text2.IndexOf("=", StringComparison.Ordinal);
					string item = text2.Substring(0, num).ToLowerInvariant().Trim();
					string item2 = text2.Substring(num + 1).Trim();
					nestedProperty.SubpropertyKeys.Add(item);
					nestedProperty.SubpropertyValues.Add(item2);
				}
				lineNumber++;
				nestedProperty.ParentKey = propertyName;
			}
			return true;
		}

		private string GetErrorMessage(int lineNumber)
		{
			return string.Format(CultureInfo.InvariantCulture, "Line {0}:<{1}> in file {2} does not contain a section, property or comment.", lineNumber + 1, Lines[lineNumber], FilePath);
		}

		private static bool IsCommentOrBlank(string line)
		{
			if (line == null)
			{
				return true;
			}
			line = line.Trim();
			if (!string.IsNullOrEmpty(line) && !line.StartsWith(";", StringComparison.Ordinal))
			{
				return line.StartsWith("#", StringComparison.Ordinal);
			}
			return true;
		}

		private static bool IsSection(string line)
		{
			string sectionName;
			return TryParseSection(line, out sectionName);
		}

		private static bool TryParseSection(string line, out string sectionName)
		{
			if (line != null)
			{
				line = line.Trim();
				if (line.StartsWith("[", StringComparison.Ordinal) && line.EndsWith("]", StringComparison.Ordinal))
				{
					sectionName = line.Substring(1, line.Length - 2).Trim();
					return true;
				}
			}
			sectionName = null;
			return false;
		}

		private static bool IsProperty(string line)
		{
			string propertyName;
			string propertyValue;
			return TryParseProperty(line, out propertyName, out propertyValue);
		}

		private static bool TryParseProperty(string line, out string propertyName, out string propertyValue)
		{
			if (line != null && !IsCommentOrBlank(line))
			{
				line = line.Trim();
				int num = line.IndexOf("=", StringComparison.Ordinal);
				if (num >= 0)
				{
					propertyName = line.Substring(0, num).Trim();
					int num2 = num + "=".Length;
					propertyValue = line.Substring(num2, line.Length - num2).Trim();
					return true;
				}
			}
			propertyName = null;
			propertyValue = null;
			return false;
		}

		private static string GetPropertyLine(string propertyName, string propertyValue)
		{
			return propertyName + "=" + propertyValue;
		}

		private string GetLineMessage(int lineNumber)
		{
			return "(" + FilePath + ":line " + (lineNumber + 1) + ")";
		}

		private static bool StartsWithWhitespace(string line)
		{
			if (line.Length > 0)
			{
				return char.IsWhiteSpace(line[0]);
			}
			return false;
		}
	}
}
