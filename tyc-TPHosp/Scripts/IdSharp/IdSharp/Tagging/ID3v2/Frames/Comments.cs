#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class Comments : IComments, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_LanguageCode;

		private string m_Description;

		private string m_Value;

		public EncodingType TextEncoding
		{
			get
			{
				return m_TextEncoding;
			}
			set
			{
				m_TextEncoding = value;
				FirePropertyChanged("TextEncoding");
			}
		}

		public string LanguageCode
		{
			get
			{
				return m_LanguageCode;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					m_LanguageCode = "eng";
				}
				else
				{
					m_LanguageCode = value.ToLower().Trim();
					if (m_LanguageCode.Length != 3)
					{
						string message = $"Invalid language code '{value}' in COMM frame";
						Trace.WriteLine(message);
						if (m_LanguageCode.Length > 3)
						{
							m_LanguageCode = m_LanguageCode.Substring(0, 3);
						}
						else
						{
							m_LanguageCode = m_LanguageCode.PadRight(3, ' ');
						}
					}
				}
				FirePropertyChanged("LanguageCode");
			}
		}

		public string Description
		{
			get
			{
				return m_Description;
			}
			set
			{
				m_Description = value;
				FirePropertyChanged("Description");
			}
		}

		public string Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
				FirePropertyChanged("Value");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public Comments()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "COMM";
			case ID3v2TagVersion.ID3v22:
				return "COM";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			if (m_FrameHeader.FrameSizeExcludingAdditions >= 1)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream);
				if (m_FrameHeader.FrameSizeExcludingAdditions >= 4)
				{
					string text = Utils.ReadString(EncodingType.ISO88591, stream, 3);
					int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions - 1 - 3;
					string text2 = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
					bool flag = false;
					if (!LanguageHelper.Languages.ContainsKey(text.ToLower()) && text.ToLower() != "xxx")
					{
						if (text.StartsWith("en"))
						{
							text = "";
						}
						flag = true;
						if (bytesLeft == 0)
						{
							Description = "";
						}
						else
						{
							Description = text + text2;
						}
						LanguageCode = "eng";
					}
					else
					{
						LanguageCode = text;
						Description = text2;
					}
					if (bytesLeft > 0)
					{
						Value = Utils.ReadString(TextEncoding, stream, bytesLeft);
					}
					else if (flag)
					{
						if (text.Contains("\0"))
						{
							Value = "";
						}
						else
						{
							Value = text + text2;
						}
					}
					else
					{
						Value = "";
					}
				}
				else
				{
					string message = $"Under-sized ({m_FrameHeader.FrameSizeExcludingAdditions} bytes) COMM frame at position {stream.Position}";
					Trace.WriteLine(message);
					LanguageCode = "eng";
					Value = "";
				}
			}
			else
			{
				string message2 = $"Under-sized ({m_FrameHeader.FrameSizeExcludingAdditions} bytes) COMM frame at position {stream.Position}";
				Trace.WriteLine(message2);
				LanguageCode = "eng";
				Value = "";
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (string.IsNullOrEmpty(Value))
			{
				return new byte[0];
			}
			if (LanguageCode == null || LanguageCode.Length != 3)
			{
				LanguageCode = "eng";
			}
			byte[] array = new byte[1] { (byte)TextEncoding };
			byte[] array2 = Utils.ISO88591GetBytes(LanguageCode);
			byte[] stringBytes = Utils.GetStringBytes(tagVersion, TextEncoding, Description, isTerminated: true);
			byte[] stringBytes2 = Utils.GetStringBytes(tagVersion, TextEncoding, Value, isTerminated: false);
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array, 0, array.Length);
			memoryStream.Write(array2, 0, array2.Length);
			memoryStream.Write(stringBytes, 0, stringBytes.Length);
			memoryStream.Write(stringBytes2, 0, stringBytes2.Length);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
