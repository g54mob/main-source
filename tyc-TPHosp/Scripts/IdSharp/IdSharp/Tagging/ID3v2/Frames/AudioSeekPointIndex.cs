using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class AudioSeekPointIndex : IAudioSeekPointIndex, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private int m_IndexedDataStart;

		private int m_IndexedDataLength;

		private byte m_BitsPerIndexPoint;

		private BindingList<short> m_FractionAtIndex;

		public int IndexedDataStart
		{
			get
			{
				return m_IndexedDataStart;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_IndexedDataStart = value;
				FirePropertyChanged("IndexedDataStart");
			}
		}

		public int IndexedDataLength
		{
			get
			{
				return m_IndexedDataLength;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_IndexedDataLength = value;
				FirePropertyChanged("IndexedDataLength");
			}
		}

		public byte BitsPerIndexPoint
		{
			get
			{
				return m_BitsPerIndexPoint;
			}
			set
			{
				m_BitsPerIndexPoint = value;
				FirePropertyChanged("BitsPerIndexPoint");
			}
		}

		public BindingList<short> FractionAtIndex => m_FractionAtIndex;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public AudioSeekPointIndex()
		{
			m_FrameHeader = new FrameHeader();
			m_FractionAtIndex = new BindingList<short>();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "ASPI";
			case ID3v2TagVersion.ID3v22:
				return null;
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FractionAtIndex.Clear();
			throw new NotImplementedException();
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (IndexedDataLength == 0 || BitsPerIndexPoint == 0 || FractionAtIndex.Count == 0)
			{
				return new byte[0];
			}
			throw new NotImplementedException();
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
