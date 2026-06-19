using System;
using System.ComponentModel;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames.Items;
using IdSharp.Tagging.ID3v2.Frames.Lists;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class InvolvedPersonList : IInvolvedPersonList, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private InvolvedPersonBindingList m_InvolvedPersons;

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

		public BindingList<IInvolvedPerson> Items => m_InvolvedPersons;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public InvolvedPersonList()
		{
			m_FrameHeader = new FrameHeader();
			m_InvolvedPersons = new InvolvedPersonBindingList();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			return tagVersion switch
			{
				ID3v2TagVersion.ID3v24 => "TIPL", 
				ID3v2TagVersion.ID3v23 => "IPLS", 
				ID3v2TagVersion.ID3v22 => "IPL", 
				_ => throw new ArgumentException("Unknown tag version"), 
			};
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			m_InvolvedPersons.Clear();
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft <= 0)
			{
				return;
			}
			TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
			while (bytesLeft > 0)
			{
				string text = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
				string text2 = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
				if (!string.IsNullOrEmpty(text) || !string.IsNullOrEmpty(text2))
				{
					IInvolvedPerson involvedPerson = m_InvolvedPersons.AddNew();
					involvedPerson.Involvement = text;
					involvedPerson.Name = text2;
				}
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (Items.Count == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)m_TextEncoding);
			bool flag = false;
			foreach (IInvolvedPerson item in Items)
			{
				if (!string.IsNullOrEmpty(item.Involvement) || !string.IsNullOrEmpty(item.Name))
				{
					Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, m_TextEncoding, item.Involvement, isTerminated: true));
					Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, m_TextEncoding, item.Name, isTerminated: true));
					flag = true;
				}
			}
			if (!flag)
			{
				return new byte[0];
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
