using System;
using System.IO;
using System.Text;

namespace SharpConfig
{
	internal static class ConfigurationReader
	{
		internal static Configuration ReadFromString(string source)
		{
			int num = 0;
			Configuration configuration = new Configuration();
			Section section = null;
			StringBuilder stringBuilder = new StringBuilder();
			int length = Environment.NewLine.Length;
			using StringReader stringReader = new StringReader(source);
			string text = null;
			while ((text = stringReader.ReadLine()) != null)
			{
				num++;
				text = text.Trim();
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				int commentIndex = 0;
				string text2 = ParseComment(text, out commentIndex);
				if (!Configuration.IgnorePreComments && commentIndex == 0)
				{
					stringBuilder.AppendLine(text2);
					continue;
				}
				if (!Configuration.IgnoreInlineComments && commentIndex > 0)
				{
					text = text.Remove(commentIndex).Trim();
				}
				if (text.StartsWith("["))
				{
					section = ParseSection(text, num);
					if (!Configuration.IgnoreInlineComments)
					{
						section.Comment = text2;
					}
					if (!Configuration.IgnorePreComments && stringBuilder.Length > 0)
					{
						stringBuilder.Remove(stringBuilder.Length - length, length);
						section.PreComment = stringBuilder.ToString();
						stringBuilder.Length = 0;
					}
					configuration.mSections.Add(section);
					continue;
				}
				Setting setting = ParseSetting(text, num);
				if (!Configuration.IgnoreInlineComments)
				{
					setting.Comment = text2;
				}
				if (section == null)
				{
					throw new ParserException($"The setting '{setting.Name}' has to be in a section.", num);
				}
				if (!Configuration.IgnorePreComments && stringBuilder.Length > 0)
				{
					stringBuilder.Remove(stringBuilder.Length - length, length);
					setting.PreComment = stringBuilder.ToString();
					stringBuilder.Length = 0;
				}
				section.Add(setting);
			}
			return configuration;
		}

		private static bool IsInQuoteMarks(string line, int startIndex)
		{
			int num = startIndex;
			bool flag = false;
			while (--num >= 0)
			{
				if (line[num] == '"')
				{
					flag = true;
					break;
				}
			}
			bool flag2 = line.IndexOf('"', startIndex) > 0;
			return flag && flag2;
		}

		private static string ParseComment(string line, out int commentIndex)
		{
			string result = null;
			commentIndex = -1;
			do
			{
				commentIndex = line.IndexOfAny(Configuration.ValidCommentChars, commentIndex + 1);
				if (commentIndex < 0)
				{
					break;
				}
				if (commentIndex > 0 && line[commentIndex - 1] == '\\')
				{
					return null;
				}
				if (!IsInQuoteMarks(line, commentIndex))
				{
					result = line.Substring(commentIndex + 1).Trim();
					break;
				}
			}
			while (commentIndex >= 0);
			return result;
		}

		private static Section ParseSection(string line, int lineNumber)
		{
			line = line.Trim();
			int num = line.IndexOf(']');
			if (num < 0)
			{
				throw new ParserException("closing bracket missing.", lineNumber);
			}
			if (line.Length - 1 > num)
			{
				string arg = line.Substring(num + 1);
				throw new ParserException($"unexpected token '{arg}'", lineNumber);
			}
			return new Section(line.Substring(1, line.Length - 2).Trim());
		}

		private static Setting ParseSetting(string line, int lineNumber)
		{
			int num = line.IndexOf('=');
			if (num < 0)
			{
				throw new ParserException("setting assignment expected.", lineNumber);
			}
			string text = line.Substring(0, num).Trim();
			string text2 = line.Substring(num + 1);
			text2 = text2.Trim();
			if (string.IsNullOrEmpty(text))
			{
				throw new ParserException("setting name expected.", lineNumber);
			}
			if (text2 == null)
			{
				text2 = string.Empty;
			}
			return new Setting(text, text2);
		}

		internal static Configuration ReadFromBinaryStream(Stream stream, BinaryReader reader)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (reader == null)
			{
				reader = new BinaryReader(stream);
			}
			Configuration configuration = new Configuration();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				string name = reader.ReadString();
				int num2 = reader.ReadInt32();
				Section section = new Section(name);
				ReadCommentsBinary(reader, section);
				for (int j = 0; j < num2; j++)
				{
					Setting setting = new Setting(reader.ReadString(), reader.ReadString());
					ReadCommentsBinary(reader, setting);
					section.Add(setting);
				}
				configuration.Add(section);
			}
			return configuration;
		}

		private static void ReadCommentsBinary(BinaryReader reader, ConfigurationElement element)
		{
			if (reader.ReadBoolean())
			{
				reader.ReadChar();
				element.Comment = reader.ReadString();
			}
			if (reader.ReadBoolean())
			{
				reader.ReadChar();
				element.PreComment = reader.ReadString();
			}
		}
	}
}
