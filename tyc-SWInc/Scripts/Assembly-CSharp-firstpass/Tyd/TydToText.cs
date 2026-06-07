using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tyd
{
	public static class TydToText
	{
		private static HashSet<char> _symbolSet = new HashSet<char>("_-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");

		public static string Write(TydNode node, bool whitesmiths, int indent = 0, int longestName = 0, bool forceQuotes = false, bool noInlineTables = false, bool special = false, bool errorOnInvalidSymbols = false, bool preferInline = false)
		{
			int indent2 = (whitesmiths ? (indent + 1) : indent);
			TydString tydString;
			if ((tydString = node as TydString) != null)
			{
				if (tydString.Name != null)
				{
					return IndentString(indent) + DoSpecial(node.Name, false, special, true, errorOnInvalidSymbols) + RepeatString(" ", Math.Max(0, longestName - node.Name.Length) + 1) + DoSpecial(StringContentWriteable(tydString.Value, forceQuotes), true, special, false, errorOnInvalidSymbols);
				}
				return IndentString(indent) + DoSpecial(StringContentWriteable(tydString.Value, forceQuotes), true, special, false, errorOnInvalidSymbols);
			}
			TydDocument tydDocument;
			if ((tydDocument = node as TydDocument) != null)
			{
				int longestName2 = tydDocument.Nodes.Max((TydNode x) => x.Name.Length);
				StringBuilder stringBuilder = new StringBuilder();
				foreach (TydNode item in tydDocument)
				{
					stringBuilder.AppendLine(Write(item, whitesmiths, indent, longestName2, forceQuotes, noInlineTables, special, errorOnInvalidSymbols, preferInline));
					if (item is TydCollection)
					{
						stringBuilder.AppendLine();
					}
				}
				return stringBuilder.ToString();
			}
			TydTable tydTable;
			if ((tydTable = node as TydTable) != null)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				bool flag = !noInlineTables && (tydTable.Nodes.Count == 0 || ((preferInline || (tydTable.Parent != null && !(tydTable.Parent is TydDocument))) && IsSimpleCollection(tydTable, preferInline)));
				bool flag2 = AppendNodeIntro(tydTable, stringBuilder2, indent, special, errorOnInvalidSymbols);
				if (flag2 && !flag)
				{
					stringBuilder2.AppendLine();
				}
				if (flag)
				{
					if (!flag2)
					{
						stringBuilder2.Append(IndentString(indent) + "{");
					}
					else
					{
						stringBuilder2.Append(RepeatString(" ", Math.Max(0, longestName - tydTable.Name.Length) + 1) + "{");
					}
					for (int num = 0; num < tydTable.Count; num++)
					{
						stringBuilder2.Append((num == 0) ? " " : "; ");
						stringBuilder2.Append(Write(tydTable[num], whitesmiths, 0, 0, forceQuotes, noInlineTables, special, errorOnInvalidSymbols, preferInline));
					}
					stringBuilder2.Append(" }");
				}
				else
				{
					int longestName3 = ((tydTable.Nodes.Count == 0) ? 1 : tydTable.Nodes.Max((TydNode x) => x.Name.Length));
					stringBuilder2.AppendLine(IndentString(indent2) + "{");
					for (int num2 = 0; num2 < tydTable.Count; num2++)
					{
						stringBuilder2.AppendLine(Write(tydTable[num2], whitesmiths, indent + 1, longestName3, forceQuotes, noInlineTables, special, errorOnInvalidSymbols, preferInline));
					}
					stringBuilder2.Append(IndentString(indent2) + "}");
				}
				return stringBuilder2.ToString();
			}
			TydList tydList;
			if ((tydList = node as TydList) != null)
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				bool flag3 = IsSimpleCollection(tydList, preferInline);
				bool flag4 = AppendNodeIntro(tydList, stringBuilder3, indent, special, errorOnInvalidSymbols);
				if (flag4 && !flag3)
				{
					stringBuilder3.AppendLine();
				}
				if (flag3)
				{
					if (!flag4)
					{
						stringBuilder3.Append(IndentString(indent) + "[");
					}
					else
					{
						stringBuilder3.Append(RepeatString(" ", Math.Max(0, longestName - tydList.Name.Length) + 1) + "[");
					}
					for (int num3 = 0; num3 < tydList.Count; num3++)
					{
						stringBuilder3.Append((num3 == 0) ? " " : "; ");
						stringBuilder3.Append(Write(tydList[num3], whitesmiths, 0, 0, forceQuotes, noInlineTables, special, errorOnInvalidSymbols, preferInline));
					}
					stringBuilder3.Append(" ]");
				}
				else
				{
					stringBuilder3.AppendLine(IndentString(indent2) + "[");
					for (int num4 = 0; num4 < tydList.Count; num4++)
					{
						stringBuilder3.AppendLine(Write(tydList[num4], whitesmiths, indent + 1, 0, forceQuotes, noInlineTables, special, errorOnInvalidSymbols, preferInline));
					}
					stringBuilder3.Append(IndentString(indent2) + "]");
				}
				return stringBuilder3.ToString();
			}
			throw new ArgumentException();
		}

		public static string CleanNodeName(string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < name.Length; i++)
			{
				if (_symbolSet.Contains(name[i]))
				{
					stringBuilder.Append(name[i]);
				}
			}
			return stringBuilder.ToString();
		}

		private static string DoSpecial(string input, bool value, bool special, bool name, bool error)
		{
			if (name)
			{
				StringBuilder stringBuilder = null;
				for (int i = 0; i < input.Length; i++)
				{
					if (!_symbolSet.Contains(input[i]))
					{
						if (error)
						{
							throw new Exception("TyD node name: " + input + " contains invalid character(s)");
						}
						if (stringBuilder == null)
						{
							stringBuilder = new StringBuilder();
							if (i > 0)
							{
								stringBuilder.Append(input.Substring(0, i));
							}
						}
					}
					else if (stringBuilder != null)
					{
						stringBuilder.Append(input[i]);
					}
				}
				if (stringBuilder != null)
				{
					input = stringBuilder.ToString();
				}
			}
			if (special)
			{
				if (value)
				{
					return "<span style=\"color:blue\">" + input + "</span>";
				}
				return "'''" + input + "'''";
			}
			return input;
		}

		private static bool IsSimpleCollection(TydCollection l, bool preferInline)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < l.Nodes.Count; i++)
			{
				TydString tydString;
				if ((tydString = l.Nodes[i] as TydString) != null)
				{
					if (tydString.Value != null)
					{
						if (tydString.Value.Contains("\n"))
						{
							return false;
						}
						num += tydString.Value.Length;
					}
					if (tydString.Name != null)
					{
						num += tydString.Name.Length;
					}
					num2++;
					continue;
				}
				return false;
			}
			if (!preferInline && num2 >= 2)
			{
				return num < 64;
			}
			return true;
		}

		private static string StringContentWriteable(string value, bool forceQuotes)
		{
			if (value == "")
			{
				return "\"\"";
			}
			if (value == null)
			{
				return "null";
			}
			if (!forceQuotes && !ShouldWriteWithQuotes(value))
			{
				return value;
			}
			return "\"" + EscapeCharsEscapedForQuotedString(value) + "\"";
		}

		public static bool ShouldWriteWithQuotes(string value)
		{
			int num = 0;
			foreach (char c in value)
			{
				if (!TydFromText.IsSymbolChar(c) && c != '.')
				{
					return true;
				}
				if (c == ' ' || c == '\n' || c == '\t' || c == '"' || c == '#' || c == ';' || c == '*' || c == '{' || c == '}' || c == '[' || c == ']' || c == '\\')
				{
					return true;
				}
				if (!char.IsWhiteSpace(c))
				{
					num++;
				}
			}
			return num == 0;
		}

		private static string EscapeCharsEscapedForQuotedString(string s)
		{
			return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("#", "\\#");
		}

		private static bool AppendNodeIntro(TydCollection node, StringBuilder sb, int indent, bool special, bool error)
		{
			bool appendedSomething = false;
			if (node.Name != null)
			{
				AppendWithWhitespace(DoSpecial(node.Name, false, special, true, error), sb, ref appendedSomething, indent);
			}
			foreach (KeyValuePair<string, string> attribute in node.GetAttributes())
			{
				if (attribute.Value != null)
				{
					AppendWithWhitespace("*" + attribute.Key + " " + StringContentWriteable(attribute.Value, false), sb, ref appendedSomething, indent);
				}
				else
				{
					AppendWithWhitespace("*" + attribute.Key, sb, ref appendedSomething, indent);
				}
			}
			return appendedSomething;
		}

		private static void AppendWithWhitespace(string s, StringBuilder sb, ref bool appendedSomething, int indent)
		{
			sb.Append((appendedSomething ? " " : IndentString(indent)) + s);
			appendedSomething = true;
		}

		private static string RepeatString(string s, int repeat)
		{
			switch (repeat)
			{
			case 0:
				return "";
			case 1:
				return s;
			default:
			{
				StringBuilder stringBuilder = new StringBuilder(repeat);
				for (int i = 0; i < repeat; i++)
				{
					stringBuilder.Append(s);
				}
				return stringBuilder.ToString();
			}
			}
		}

		public static string IndentString(int indent)
		{
			string text = "";
			for (int i = 0; i < indent; i++)
			{
				text += "    ";
			}
			return text;
		}
	}
}
