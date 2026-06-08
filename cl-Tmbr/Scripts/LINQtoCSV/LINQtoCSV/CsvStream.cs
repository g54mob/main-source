using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LINQtoCSV
{
	internal class CsvStream
	{
		private TextReader m_instream;

		private TextWriter m_outStream;

		private char m_SeparatorChar;

		private char[] m_SpecialChars;

		private bool m_IgnoreTrailingSeparatorChar;

		private int m_lineNbr;

		private bool EOS;

		private bool EOL;

		private bool previousWasCr;

		private char[] buffer = new char[4096];

		private int pos;

		private int length;

		public CsvStream(TextReader inStream, TextWriter outStream, char SeparatorChar, bool IgnoreTrailingSeparatorChar)
		{
			m_instream = inStream;
			m_outStream = outStream;
			m_SeparatorChar = SeparatorChar;
			m_IgnoreTrailingSeparatorChar = IgnoreTrailingSeparatorChar;
			m_SpecialChars = ("\"\n\r" + m_SeparatorChar).ToCharArray();
			m_lineNbr = 1;
		}

		public void WriteRow(List<string> row, bool quoteAllFields)
		{
			bool flag = true;
			foreach (string item in row)
			{
				if (!flag)
				{
					m_outStream.Write(m_SeparatorChar);
				}
				if (item != null)
				{
					if (quoteAllFields || item.IndexOfAny(m_SpecialChars) > -1 || item.Trim() == "")
					{
						m_outStream.Write("\"" + item.Replace("\"", "\"\"") + "\"");
					}
					else
					{
						m_outStream.Write(item);
					}
				}
				flag = false;
			}
			m_outStream.WriteLine("");
		}

		public bool ReadRow(IDataRow row, List<int> charactersLength = null)
		{
			row.Clear();
			int num = 0;
			while (true)
			{
				int lineNbr = m_lineNbr;
				string itemString = null;
				int? itemLength = charactersLength?.Skip(num).First();
				bool flag = GetNextItem(ref itemString, itemLength);
				if (charactersLength != null && charactersLength.Count() <= num + 1)
				{
					if (flag)
					{
						row.Add(new DataRowItem(itemString, lineNbr));
					}
					if (!EOL)
					{
						AdvanceToEndOfLine();
						flag = false;
					}
				}
				if (!flag)
				{
					break;
				}
				row.Add(new DataRowItem(itemString, lineNbr));
				num++;
			}
			return row.Count > 0;
		}

		private void AdvanceToEndOfLine()
		{
			char nextChar;
			do
			{
				nextChar = GetNextChar(eat: true);
				if (EOS)
				{
					return;
				}
			}
			while (nextChar != '\r');
			m_lineNbr++;
			previousWasCr = true;
			EOL = true;
			if (nextChar == '\r' && GetNextChar(eat: false) == '\n')
			{
				GetNextChar(eat: true);
			}
			EOL = false;
		}

		private bool GetNextItem(ref string itemString, int? itemLength = null)
		{
			itemString = null;
			if (EOL)
			{
				EOL = false;
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = true;
			bool flag4 = false;
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			char nextChar;
			while (true)
			{
				if (itemLength.HasValue && num >= itemLength.Value)
				{
					itemString = stringBuilder.ToString();
					return true;
				}
				nextChar = GetNextChar(eat: true);
				num++;
				if (EOS)
				{
					if (flag)
					{
						itemString = stringBuilder.ToString();
					}
					return flag;
				}
				if (!previousWasCr && nextChar == '\n')
				{
					m_lineNbr++;
				}
				if (nextChar == '\r')
				{
					m_lineNbr++;
					previousWasCr = true;
				}
				else
				{
					previousWasCr = false;
				}
				if ((flag4 || !flag2) && !itemLength.HasValue && nextChar == m_SeparatorChar)
				{
					if (m_IgnoreTrailingSeparatorChar)
					{
						char nextChar2 = GetNextChar(eat: false);
						if (nextChar2 == '\n' || nextChar2 == '\r')
						{
							continue;
						}
					}
					if (flag)
					{
						itemString = stringBuilder.ToString();
					}
					return true;
				}
				if ((flag3 || flag4 || !flag2) && (nextChar == '\n' || nextChar == '\r'))
				{
					break;
				}
				if (flag3 && nextChar == ' ')
				{
					continue;
				}
				if (flag3 && nextChar == '"')
				{
					flag2 = true;
					flag3 = false;
					flag = true;
				}
				else if (flag3)
				{
					flag3 = false;
					stringBuilder.Append(nextChar);
					flag = true;
				}
				else if (nextChar == '"' && flag2)
				{
					if (GetNextChar(eat: false) == '"')
					{
						stringBuilder.Append(GetNextChar(eat: true));
					}
					else
					{
						flag4 = true;
					}
				}
				else
				{
					stringBuilder.Append(nextChar);
				}
			}
			EOL = true;
			if (nextChar == '\r' && GetNextChar(eat: false) == '\n')
			{
				GetNextChar(eat: true);
			}
			if (flag)
			{
				itemString = stringBuilder.ToString();
			}
			return true;
		}

		private char GetNextChar(bool eat)
		{
			if (pos >= length)
			{
				length = m_instream.ReadBlock(buffer, 0, buffer.Length);
				if (length == 0)
				{
					EOS = true;
					return '\0';
				}
				pos = 0;
			}
			if (eat)
			{
				return buffer[pos++];
			}
			return buffer[pos];
		}
	}
}
