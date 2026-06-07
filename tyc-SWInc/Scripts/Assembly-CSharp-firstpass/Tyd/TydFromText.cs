using System;
using System.Collections.Generic;

namespace Tyd
{
	public static class TydFromText
	{
		public static List<TydNode> Parse(string doc)
		{
			int currentLine = 1;
			return Parse(doc, 0, ref currentLine, true, new List<TydNode>());
		}

		public static TydNode ParseOne(string doc)
		{
			int currentLine = 1;
			List<TydNode> list = Parse(doc, 0, ref currentLine, true, new List<TydNode>(), true);
			if (list.Count == 0)
			{
				throw new Exception("Couldn't retrieve element from empty TyD file");
			}
			return list[0];
		}

		private static void SetAttributeValue(ref Dictionary<string, string> attributes, string key, string value)
		{
			if (attributes == null)
			{
				attributes = new Dictionary<string, string>();
			}
			attributes[key] = value;
		}

		private static List<TydNode> Parse(string doc, int startIndex, ref int currentLine, bool expectNames = true, List<TydNode> res = null, bool breakOnFirst = false)
		{
			int p = startIndex;
			res = res ?? new List<TydNode>();
			while (true)
			{
				string name = null;
				Dictionary<string, string> attributes = null;
				try
				{
					int num = currentLine;
					p = NextSubstanceIndex(doc, p, ref currentLine);
					if (p == doc.Length)
					{
						return res;
					}
					if (doc[p] == ';')
					{
						p++;
						continue;
					}
					if (doc[p] == '}' || doc[p] == ']')
					{
						currentLine = num;
						return res;
					}
					if (expectNames)
					{
						name = ReadSymbol(doc, currentLine, ref p);
					}
					p = NextSubstanceIndex(doc, p, ref currentLine);
					while (doc[p] == '*')
					{
						p++;
						string key = ReadSymbol(doc, currentLine, ref p);
						p = NextSubstanceIndex(doc, p, ref currentLine);
						if (doc[p] == '*' || doc[p] == '#' || doc[p] == '{')
						{
							SetAttributeValue(ref attributes, key, null);
							continue;
						}
						string val;
						ParseStringValue(doc, ref p, ref currentLine, out val);
						SetAttributeValue(ref attributes, key, val);
						p = NextSubstanceIndex(doc, p, ref currentLine);
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Exception parsing Tyd headers at " + IndexToLocationString(doc, currentLine, p) + ": " + ex.ToString());
				}
				if (doc[p] == '{')
				{
					TydTable tydTable = new TydTable(name, currentLine);
					p++;
					p = NextSubstanceIndex(doc, p, ref currentLine);
					foreach (TydNode item in Parse(doc, p, ref currentLine, true, tydTable.Nodes))
					{
						item.Parent = tydTable;
						p = item.DocIndexEnd + 1;
					}
					p = NextSubstanceIndex(doc, p, ref currentLine);
					if (doc[p] != '}')
					{
						throw new FormatException("Expected } at " + IndexToLocationString(doc, currentLine, p));
					}
					tydTable.DocIndexEnd = p;
					tydTable.SetupAttributes(attributes);
					res.Add(tydTable);
					p++;
				}
				else if (doc[p] == '[')
				{
					int index = p;
					TydList tydList = new TydList(name, currentLine);
					p++;
					p = NextSubstanceIndex(doc, p, ref currentLine);
					foreach (TydNode item2 in Parse(doc, p, ref currentLine, false, tydList.Nodes))
					{
						item2.Parent = tydList;
						p = item2.DocIndexEnd + 1;
					}
					p = NextSubstanceIndex(doc, p, ref currentLine);
					if (p >= doc.Length || doc[p] != ']')
					{
						throw new FormatException(string.Format("Expected {0} from {1} at {2}", ']', IndexToLocationString(doc, tydList.DocLine, index), IndexToLocationString(doc, currentLine, p)));
					}
					tydList.DocIndexEnd = p;
					tydList.SetupAttributes(attributes);
					res.Add(tydList);
					if (breakOnFirst)
					{
						return res;
					}
					p++;
				}
				else
				{
					string val2;
					ParseStringValue(doc, ref p, ref currentLine, out val2);
					TydString tydString = new TydString(name, val2, currentLine);
					tydString.DocIndexEnd = p - 1;
					res.Add(tydString);
					if (breakOnFirst)
					{
						break;
					}
				}
			}
			return res;
		}

		private static void ParseStringValue(string doc, ref int p, ref int currentLine, out string val)
		{
			if (doc[p] == '"')
			{
				p++;
				int num = p;
				int line = currentLine;
				while (p >= doc.Length || doc[p] != '"' || doc[p - 1] == '\\')
				{
					if (p >= doc.Length)
					{
						throw new FormatException("Expected \" but reached end of file at " + IndexToLocationString(doc, line, num));
					}
					if (doc[p] == '\n')
					{
						currentLine++;
					}
					p++;
				}
				val = doc.Substring(num, p - num);
				val = ResolveEscapeChars(val);
				p++;
			}
			else
			{
				int num2 = p;
				while (p < doc.Length && !IsNewline(doc, p) && ((doc[p] != ';' && doc[p] != '{' && doc[p] != '*' && doc[p] != '#' && doc[p] != '}' && doc[p] != ']') || doc[p - 1] == '\\'))
				{
					p++;
				}
				int num3 = p - 1;
				while (char.IsWhiteSpace(doc[num3]))
				{
					num3--;
				}
				val = ((num3 >= num2) ? doc.Substring(num2, num3 - num2 + 1) : "");
				val = ((val == "null") ? null : ResolveEscapeChars(val));
			}
			if (p < doc.Length && doc[p] == ';')
			{
				p++;
			}
		}

		private static string ResolveEscapeChars(string input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == '\\')
				{
					if (input.Length <= i + 1)
					{
						throw new Exception("Tyd string value ends with single backslash: " + input);
					}
					char c = EscapedCharOf(input[i + 1]);
					input = input.Substring(0, i) + c + input.Substring(i + 2);
				}
			}
			return input;
		}

		private static char EscapedCharOf(char inputChar)
		{
			switch (inputChar)
			{
			case '\\':
				return '\\';
			case '"':
				return '"';
			case '#':
				return '#';
			case ';':
				return ';';
			case ']':
				return ']';
			case '}':
				return '}';
			case '\r':
				return '\r';
			case 'n':
				return '\n';
			case 't':
				return '\t';
			default:
				throw new Exception("Cannot escape char: \\" + inputChar);
			}
		}

		private static string ReadSymbol(string doc, int line, ref int p)
		{
			int num = p;
			while (true)
			{
				char c = doc[p];
				if (char.IsWhiteSpace(doc[p]) || !IsSymbolChar(c))
				{
					break;
				}
				p++;
			}
			if (p == num)
			{
				throw new FormatException("Missing symbol at " + IndexToLocationString(doc, line, p));
			}
			return doc.Substring(num, p - num);
		}

		public static bool IsSymbolChar(char c)
		{
			for (int i = 0; i < "_-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".Length; i++)
			{
				if ("_-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"[i] == c)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsNewline(string doc, int p)
		{
			if (doc[p] != '\n')
			{
				if (doc[p] == '\r' && p < doc.Length - 1)
				{
					return doc[p + 1] == '\n';
				}
				return false;
			}
			return true;
		}

		private static string IndexToLocationString(string doc, int line, int index)
		{
			int num = 0;
			while (index >= 0 && index < doc.Length && doc[index] != '\n')
			{
				num++;
				index--;
			}
			return "line " + line + " col " + num;
		}

		private static int NextSubstanceIndex(string doc, int p, ref int currentLine)
		{
			while (true)
			{
				if (p >= doc.Length)
				{
					return doc.Length;
				}
				if (char.IsWhiteSpace(doc[p]))
				{
					if (doc[p] == '\n')
					{
						currentLine++;
					}
					p++;
					continue;
				}
				if (doc[p] != '#')
				{
					break;
				}
				while (p < doc.Length && !IsNewline(doc, p))
				{
					p++;
				}
				currentLine++;
				if (p < doc.Length)
				{
					p = ((doc[p] != '\n') ? (p + 2) : (p + 1));
				}
			}
			return p;
		}
	}
}
