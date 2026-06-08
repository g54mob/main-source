using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Amazon.Runtime.Internal.Util
{
	public class OptimisticLockedTextFile
	{
		private string OriginalContents { get; set; }

		public string FilePath { get; private set; }

		public List<string> Lines { get; private set; }

		public OptimisticLockedTextFile(string filePath)
		{
			FilePath = filePath;
			Read();
		}

		public void Persist()
		{
			string text = ToString();
			string directoryName = Path.GetDirectoryName(FilePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			using FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
			using StreamReader streamReader = new StreamReader(fileStream);
			if (string.Equals(streamReader.ReadToEnd(), OriginalContents, StringComparison.Ordinal))
			{
				fileStream.Seek(0L, SeekOrigin.Begin);
				using StreamWriter streamWriter = new StreamWriter(fileStream);
				streamWriter.Write(text);
				streamWriter.Flush();
				fileStream.Flush();
				fileStream.SetLength(fileStream.Position);
				OriginalContents = text;
				return;
			}
			throw new IOException(string.Format(CultureInfo.InvariantCulture, "Cannot write to file {0}. The file has been modified since it was last read.", FilePath));
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Lines.Count; i++)
			{
				string text = Lines[i];
				if (i < Lines.Count - 1 && !HasEnding(text))
				{
					stringBuilder.AppendLine(text);
				}
				else
				{
					stringBuilder.Append(text);
				}
			}
			return stringBuilder.ToString();
		}

		private void Read()
		{
			OriginalContents = "";
			if (File.Exists(FilePath))
			{
				try
				{
					OriginalContents = File.ReadAllText(FilePath);
				}
				catch (FileNotFoundException)
				{
				}
				catch (DirectoryNotFoundException)
				{
				}
			}
			Lines = ReadLinesWithEndings(OriginalContents);
		}

		private static bool HasEnding(string line)
		{
			char c = line[line.Length - 1];
			if (c != '\n')
			{
				return c == '\r';
			}
			return true;
		}

		private static List<string> ReadLinesWithEndings(string str)
		{
			List<string> list = new List<string>();
			int length = str.Length;
			int num = 0;
			int num2 = 0;
			while (num < length)
			{
				if (str[num] == '\r')
				{
					num++;
					if (num < length && str[num] == '\n')
					{
						num++;
					}
					list.Add(str.Substring(num2, num - num2));
					num2 = num;
				}
				else if (str[num] == '\n')
				{
					num++;
					list.Add(str.Substring(num2, num - num2));
					num2 = num;
				}
				else
				{
					num++;
				}
			}
			if (num2 < num)
			{
				list.Add(str.Substring(num2, num - num2));
			}
			return list;
		}
	}
}
