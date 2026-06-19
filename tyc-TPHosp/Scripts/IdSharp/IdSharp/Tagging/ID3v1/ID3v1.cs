using System.ComponentModel;
using System.IO;
using System.Text;

namespace IdSharp.Tagging.ID3v1
{
	internal sealed class ID3v1 : IID3v1, INotifyPropertyChanged
	{
		private string m_Title;

		private string m_Artist;

		private string m_Album;

		private string m_Year;

		private string m_Comment;

		private int m_TrackNumber;

		private int m_GenreIndex;

		private ID3v1TagVersion m_TagVersion;

		public string Title
		{
			get
			{
				return m_Title;
			}
			set
			{
				m_Title = GetString(value, 30);
				FirePropertyChanged("Title");
			}
		}

		public string Artist
		{
			get
			{
				return m_Artist;
			}
			set
			{
				m_Artist = GetString(value, 30);
				FirePropertyChanged("Artist");
			}
		}

		public string Album
		{
			get
			{
				return m_Album;
			}
			set
			{
				m_Album = GetString(value, 30);
				FirePropertyChanged("Album");
			}
		}

		public string Year
		{
			get
			{
				return m_Year;
			}
			set
			{
				m_Year = GetString(value, 4);
				FirePropertyChanged("Year");
			}
		}

		public string Comment
		{
			get
			{
				return m_Comment;
			}
			set
			{
				if (m_TagVersion == ID3v1TagVersion.ID3v11)
				{
					m_Comment = GetString(value, 28);
				}
				else
				{
					m_Comment = GetString(value, 30);
				}
				FirePropertyChanged("Comment");
			}
		}

		public int TrackNumber
		{
			get
			{
				return m_TrackNumber;
			}
			set
			{
				if (value >= 0 && value <= 255)
				{
					m_TrackNumber = value;
					if (m_TagVersion == ID3v1TagVersion.ID3v10)
					{
						TagVersion = ID3v1TagVersion.ID3v11;
					}
				}
				FirePropertyChanged("TrackNumber");
			}
		}

		public int GenreIndex
		{
			get
			{
				return m_GenreIndex;
			}
			set
			{
				if (value >= 0 && value <= 147)
				{
					m_GenreIndex = value;
				}
				FirePropertyChanged("GenreIndex");
			}
		}

		public ID3v1TagVersion TagVersion
		{
			get
			{
				return m_TagVersion;
			}
			set
			{
				m_TagVersion = value;
				FirePropertyChanged("TagVersion");
				if (value == ID3v1TagVersion.ID3v11)
				{
					Comment = m_Comment;
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public ID3v1()
		{
			m_TagVersion = ID3v1TagVersion.ID3v11;
			m_GenreIndex = 12;
		}

		public void Read(string path)
		{
			using FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			ReadStream(stream);
		}

		public void ReadStream(Stream stream)
		{
			if (stream.Length >= 128)
			{
				stream.Seek(-128L, SeekOrigin.End);
				if (GetString(stream, 3) == "TAG")
				{
					Title = GetString(stream, 30);
					Artist = GetString(stream, 30);
					Album = GetString(stream, 30);
					Year = GetString(stream, 4);
					byte[] array = new byte[30];
					stream.Read(array, 0, 30);
					string text = GetString(array);
					if (array[28] == 0 && array[29] != 0)
					{
						string text2 = text.Substring(0, 28);
						char[] trimChars = new char[1];
						Comment = text2.TrimEnd(trimChars).TrimEnd(' ');
						TrackNumber = array[29];
						TagVersion = ID3v1TagVersion.ID3v11;
					}
					else
					{
						Comment = text;
						TrackNumber = 0;
						TagVersion = ID3v1TagVersion.ID3v10;
					}
					int num = stream.ReadByte();
					if (num < 0 || num > 147)
					{
						num = 12;
					}
					GenreIndex = num;
				}
				else
				{
					Reset();
				}
			}
			else
			{
				Reset();
			}
		}

		public void Reset()
		{
			Title = null;
			Artist = null;
			Album = null;
			Year = null;
			Comment = null;
			TrackNumber = 0;
			GenreIndex = 12;
			TagVersion = ID3v1TagVersion.ID3v11;
		}

		public void Save(string path)
		{
			using FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			fileStream.Seek(-ID3v1Helper.GetTagSize(fileStream), SeekOrigin.End);
			byte[] bytes = Encoding.ASCII.GetBytes("TAG");
			byte[] byteArray = SafeGetBytes(m_Title);
			byte[] byteArray2 = SafeGetBytes(m_Artist);
			byte[] byteArray3 = SafeGetBytes(m_Album);
			byte[] byteArray4 = SafeGetBytes(m_Year);
			fileStream.Write(bytes, 0, 3);
			WriteBytesPadded(fileStream, byteArray, 30);
			WriteBytesPadded(fileStream, byteArray2, 30);
			WriteBytesPadded(fileStream, byteArray3, 30);
			WriteBytesPadded(fileStream, byteArray4, 4);
			if (m_TagVersion == ID3v1TagVersion.ID3v11)
			{
				byte[] byteArray5 = SafeGetBytes(m_Comment);
				WriteBytesPadded(fileStream, byteArray5, 28);
				fileStream.WriteByte(0);
				fileStream.WriteByte((byte)m_TrackNumber);
			}
			else
			{
				byte[] byteArray5 = SafeGetBytes(m_Comment);
				WriteBytesPadded(fileStream, byteArray5, 30);
			}
			fileStream.WriteByte((byte)m_GenreIndex);
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private static void WriteBytesPadded(Stream stream, byte[] byteArray, int length)
		{
			int i;
			for (i = 0; i < length && i < byteArray.Length && byteArray[i] != 0; i++)
			{
				stream.WriteByte(byteArray[i]);
			}
			for (; i < length; i++)
			{
				stream.WriteByte(0);
			}
		}

		private static string GetString(Stream stream, int length)
		{
			byte[] array = new byte[length];
			stream.Read(array, 0, length);
			return GetString(array);
		}

		private static string GetString(byte[] byteArray)
		{
			string text = Encoding.GetEncoding(28591).GetString(byteArray);
			char[] trimChars = new char[1];
			return text.TrimEnd(trimChars).TrimEnd(' ');
		}

		private static string GetString(string value, int maxLength)
		{
			if (value == null)
			{
				return null;
			}
			value = value.Trim();
			if (value.Length > maxLength)
			{
				return value.Substring(0, maxLength).Trim();
			}
			return value;
		}

		private static byte[] SafeGetBytes(string value)
		{
			if (value == null)
			{
				return new byte[0];
			}
			return Encoding.GetEncoding(28591).GetBytes(value);
		}
	}
}
