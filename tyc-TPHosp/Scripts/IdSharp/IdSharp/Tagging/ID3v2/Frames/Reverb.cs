using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class Reverb : IReverb, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private short m_ReverbLeftMilliseconds;

		private short m_ReverbRightMilliseconds;

		private byte m_ReverbBouncesLeft;

		private byte m_ReverbBouncesRight;

		private byte m_ReverbFeedbackLeftToLeft;

		private byte m_ReverbFeedbackLeftToRight;

		private byte m_ReverbFeedbackRightToRight;

		private byte m_ReverbFeedbackRightToLeft;

		private byte m_PremixLeftToRight;

		private byte m_PremixRightToLeft;

		public short ReverbLeftMilliseconds
		{
			get
			{
				return m_ReverbLeftMilliseconds;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_ReverbLeftMilliseconds = value;
				FirePropertyChanged("ReverbLeftMilliseconds");
			}
		}

		public short ReverbRightMilliseconds
		{
			get
			{
				return m_ReverbRightMilliseconds;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_ReverbRightMilliseconds = value;
				FirePropertyChanged("ReverbRightMilliseconds");
			}
		}

		public byte ReverbBouncesLeft
		{
			get
			{
				return m_ReverbBouncesLeft;
			}
			set
			{
				m_ReverbBouncesLeft = value;
				FirePropertyChanged("ReverbBouncesLeft");
			}
		}

		public byte ReverbBouncesRight
		{
			get
			{
				return m_ReverbBouncesRight;
			}
			set
			{
				m_ReverbBouncesRight = value;
				FirePropertyChanged("ReverbBouncesRight");
			}
		}

		public byte ReverbFeedbackLeftToLeft
		{
			get
			{
				return m_ReverbFeedbackLeftToLeft;
			}
			set
			{
				m_ReverbFeedbackLeftToLeft = value;
				FirePropertyChanged("ReverbFeedbackLeftToLeft");
			}
		}

		public byte ReverbFeedbackLeftToRight
		{
			get
			{
				return m_ReverbFeedbackLeftToRight;
			}
			set
			{
				m_ReverbFeedbackLeftToRight = value;
				FirePropertyChanged("ReverbFeedbackLeftToRight");
			}
		}

		public byte ReverbFeedbackRightToRight
		{
			get
			{
				return m_ReverbFeedbackRightToRight;
			}
			set
			{
				m_ReverbFeedbackRightToRight = value;
				FirePropertyChanged("ReverbFeedbackRightToRight");
			}
		}

		public byte ReverbFeedbackRightToLeft
		{
			get
			{
				return m_ReverbFeedbackRightToLeft;
			}
			set
			{
				m_ReverbFeedbackRightToLeft = value;
				FirePropertyChanged("ReverbFeedbackRightToLeft");
			}
		}

		public byte PremixLeftToRight
		{
			get
			{
				return m_PremixLeftToRight;
			}
			set
			{
				m_PremixLeftToRight = value;
				FirePropertyChanged("PremixLeftToRight");
			}
		}

		public byte PremixRightToLeft
		{
			get
			{
				return m_PremixRightToLeft;
			}
			set
			{
				m_PremixRightToLeft = value;
				FirePropertyChanged("PremixRightToLeft");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public Reverb()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "RVRB";
			case ID3v2TagVersion.ID3v22:
				return "REV";
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
			if (ReverbLeftMilliseconds == 0 && ReverbRightMilliseconds == 0)
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
