using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames.Items;
using IdSharp.Tagging.ID3v2.Frames.Lists;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class LanguageFrame : ILanguageFrame, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private LanguageItemBindingList m_LanguageItems;

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

		public BindingList<ILanguageItem> Items => m_LanguageItems;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public LanguageFrame()
		{
			m_FrameHeader = new FrameHeader();
			m_LanguageItems = new LanguageItemBindingList();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "TLAN";
			case ID3v2TagVersion.ID3v22:
				return "TLA";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_LanguageItems.Clear();
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft >= 4)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
				string text = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
				if (text.Length != 3)
				{
					if (text.ToLower() == "english" || text.ToLower() == "en")
					{
						Items.AddNew().LanguageCode = "eng";
					}
					else
					{
						foreach (KeyValuePair<string, string> language in LanguageHelper.Languages)
						{
							if (language.Value.ToLower() == text.ToLower())
							{
								Items.AddNew().LanguageCode = language.Key;
								break;
							}
						}
					}
				}
				else
				{
					Items.AddNew().LanguageCode = text;
				}
			}
			if (bytesLeft > 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (Items.Count == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)TextEncoding);
			bool isTerminated = true;
			for (int i = 0; i < Items.Count; i++)
			{
				ILanguageItem languageItem = Items[i];
				if (i == Items.Count - 1)
				{
					isTerminated = false;
				}
				Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, languageItem.LanguageCode, isTerminated));
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
