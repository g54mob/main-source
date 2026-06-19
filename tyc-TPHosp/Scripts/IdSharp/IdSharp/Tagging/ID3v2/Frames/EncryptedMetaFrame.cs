using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class EncryptedMetaFrame : IEncryptedMetaFrame, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader = new FrameHeader();

		private string m_OwnerIdentifier;

		private string m_ContentExplanation;

		private byte[] m_EncryptedData;

		public string OwnerIdentifier
		{
			get
			{
				return m_OwnerIdentifier;
			}
			set
			{
				m_OwnerIdentifier = value;
				FirePropertyChanged("OwnerIdentifier");
			}
		}

		public string ContentExplanation
		{
			get
			{
				return m_ContentExplanation;
			}
			set
			{
				m_ContentExplanation = value;
				FirePropertyChanged("ContentExplanation");
			}
		}

		public byte[] EncryptedData
		{
			get
			{
				if (m_EncryptedData == null)
				{
					return null;
				}
				return (byte[])m_EncryptedData.Clone();
			}
			set
			{
				if (value == null)
				{
					m_EncryptedData = null;
				}
				else
				{
					m_EncryptedData = (byte[])value.Clone();
				}
				FirePropertyChanged("EncryptedData");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return null;
			case ID3v2TagVersion.ID3v22:
				return "CRM";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			throw new NotImplementedException();
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			throw new NotImplementedException();
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
