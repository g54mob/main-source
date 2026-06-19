#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class RelativeVolumeAdjustment : IRelativeVolumeAdjustment, IFrame, INotifyPropertyChanged
	{
		private const byte m_ID3v24BitsRepresentingPeak = 16;

		private FrameHeader m_FrameHeader;

		private string m_Identification;

		private decimal m_FrontRightAdjustment;

		private decimal m_FrontLeftAdjustment;

		private decimal m_BackRightAdjustment;

		private decimal m_BackLeftAdjustment;

		private decimal m_FrontCenterAdjustment;

		private decimal m_SubwooferAdjustment;

		private decimal m_BackCenterAdjustment;

		private decimal m_OtherAdjustment;

		private decimal m_MasterAdjustment;

		private decimal m_FrontRightPeak;

		private decimal m_FrontLeftPeak;

		private decimal m_BackRightPeak;

		private decimal m_BackLeftPeak;

		private decimal m_FrontCenterPeak;

		private decimal m_SubwooferPeak;

		private decimal m_BackCenterPeak;

		private decimal m_OtherPeak;

		private decimal m_MasterPeak;

		public string Identification
		{
			get
			{
				return m_Identification;
			}
			set
			{
				m_Identification = value;
				FirePropertyChanged("Identification");
			}
		}

		public decimal FrontRightAdjustment
		{
			get
			{
				return m_FrontRightAdjustment;
			}
			set
			{
				m_FrontRightAdjustment = value;
				FirePropertyChanged("FrontRightAdjustment");
			}
		}

		public decimal FrontLeftAdjustment
		{
			get
			{
				return m_FrontLeftAdjustment;
			}
			set
			{
				m_FrontLeftAdjustment = value;
				FirePropertyChanged("FrontLeftAdjustment");
			}
		}

		public decimal BackRightAdjustment
		{
			get
			{
				return m_BackRightAdjustment;
			}
			set
			{
				m_BackRightAdjustment = value;
				FirePropertyChanged("BackRightAdjustment");
			}
		}

		public decimal BackLeftAdjustment
		{
			get
			{
				return m_BackLeftAdjustment;
			}
			set
			{
				m_BackLeftAdjustment = value;
				FirePropertyChanged("BackLeftAdjustment");
			}
		}

		public decimal FrontCenterAdjustment
		{
			get
			{
				return m_FrontCenterAdjustment;
			}
			set
			{
				m_FrontCenterAdjustment = value;
				FirePropertyChanged("FrontCenterAdjustment");
			}
		}

		public decimal SubwooferAdjustment
		{
			get
			{
				return m_SubwooferAdjustment;
			}
			set
			{
				m_SubwooferAdjustment = value;
				FirePropertyChanged("SubwooferAdjustment");
			}
		}

		public decimal BackCenterAdjustment
		{
			get
			{
				return m_BackCenterAdjustment;
			}
			set
			{
				m_BackCenterAdjustment = value;
				FirePropertyChanged("BackCenterAdjustment");
			}
		}

		public decimal OtherAdjustment
		{
			get
			{
				return m_OtherAdjustment;
			}
			set
			{
				m_OtherAdjustment = value;
				FirePropertyChanged("OtherAdjustment");
			}
		}

		public decimal MasterAdjustment
		{
			get
			{
				return m_MasterAdjustment;
			}
			set
			{
				m_MasterAdjustment = value;
				FirePropertyChanged("MasterAdjustment");
			}
		}

		public decimal FrontRightPeak
		{
			get
			{
				return m_FrontRightPeak;
			}
			set
			{
				m_FrontRightPeak = value;
				FirePropertyChanged("FrontRightPeak");
			}
		}

		public decimal FrontLeftPeak
		{
			get
			{
				return m_FrontLeftPeak;
			}
			set
			{
				m_FrontLeftPeak = value;
				FirePropertyChanged("FrontLeftPeak");
			}
		}

		public decimal BackRightPeak
		{
			get
			{
				return m_BackRightPeak;
			}
			set
			{
				m_BackRightPeak = value;
				FirePropertyChanged("BackRightPeak");
			}
		}

		public decimal BackLeftPeak
		{
			get
			{
				return m_BackLeftPeak;
			}
			set
			{
				m_BackLeftPeak = value;
				FirePropertyChanged("BackLeftPeak");
			}
		}

		public decimal FrontCenterPeak
		{
			get
			{
				return m_FrontCenterPeak;
			}
			set
			{
				m_FrontCenterPeak = value;
				FirePropertyChanged("FrontCenterPeak");
			}
		}

		public decimal SubwooferPeak
		{
			get
			{
				return m_SubwooferPeak;
			}
			set
			{
				m_SubwooferPeak = value;
				FirePropertyChanged("SubwooferPeak");
			}
		}

		public decimal BackCenterPeak
		{
			get
			{
				return m_BackCenterPeak;
			}
			set
			{
				m_BackCenterPeak = value;
				FirePropertyChanged("BackCenterPeak");
			}
		}

		public decimal OtherPeak
		{
			get
			{
				return m_OtherPeak;
			}
			set
			{
				m_OtherPeak = value;
				FirePropertyChanged("OtherPeak");
			}
		}

		public decimal MasterPeak
		{
			get
			{
				return m_MasterPeak;
			}
			set
			{
				m_MasterPeak = value;
				FirePropertyChanged("MasterPeak");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public RelativeVolumeAdjustment()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			return tagVersion switch
			{
				ID3v2TagVersion.ID3v24 => "RVA2", 
				ID3v2TagVersion.ID3v23 => "RVAD", 
				ID3v2TagVersion.ID3v22 => "RVA", 
				_ => throw new ArgumentException("Unknown tag version"), 
			};
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft <= 0)
			{
				return;
			}
			bool flag = m_FrameHeader.TagVersion == ID3v2TagVersion.ID3v24;
			if (flag)
			{
				Identification = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
				while (bytesLeft >= 3)
				{
					Utils.ReadByte(stream, ref bytesLeft);
					Utils.ReadInt16(stream, ref bytesLeft);
					if (bytesLeft > 0)
					{
						byte b = Utils.ReadByte(stream, ref bytesLeft);
						if (b == 0 || bytesLeft < b)
						{
							break;
						}
						byte[] array = Utils.Read(stream, b);
						bytesLeft -= array.Length;
					}
				}
				if (bytesLeft > 0)
				{
					stream.Seek(bytesLeft - m_FrameHeader.FrameSizeExcludingAdditions, SeekOrigin.Current);
					bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
					flag = false;
				}
			}
			if (!flag)
			{
				byte byteToCheck = Utils.ReadByte(stream, ref bytesLeft);
				if (bytesLeft > 0)
				{
					byte b2 = Utils.ReadByte(stream, ref bytesLeft);
					int num = b2 / 8;
					if (bytesLeft >= num)
					{
						byte[] byteArray = Utils.Read(stream, num, ref bytesLeft);
						FrontRightAdjustment = Utils.ConvertToInt64(byteArray) * (Utils.IsBitSet(byteToCheck, 0) ? 1 : (-1));
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray2 = Utils.Read(stream, num, ref bytesLeft);
						FrontLeftAdjustment = Utils.ConvertToInt64(byteArray2) * (Utils.IsBitSet(byteToCheck, 1) ? 1 : (-1));
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray3 = Utils.Read(stream, num, ref bytesLeft);
						FrontRightPeak = Utils.ConvertToInt64(byteArray3);
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray4 = Utils.Read(stream, num, ref bytesLeft);
						FrontLeftPeak = Utils.ConvertToInt64(byteArray4);
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray5 = Utils.Read(stream, num, ref bytesLeft);
						BackRightAdjustment = Utils.ConvertToInt64(byteArray5) * (Utils.IsBitSet(byteToCheck, 2) ? 1 : (-1));
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray6 = Utils.Read(stream, num, ref bytesLeft);
						BackLeftAdjustment = Utils.ConvertToInt64(byteArray6) * (Utils.IsBitSet(byteToCheck, 3) ? 1 : (-1));
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray7 = Utils.Read(stream, num, ref bytesLeft);
						BackRightPeak = Utils.ConvertToInt64(byteArray7);
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray8 = Utils.Read(stream, num, ref bytesLeft);
						BackLeftPeak = Utils.ConvertToInt64(byteArray8);
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray9 = Utils.Read(stream, num, ref bytesLeft);
						FrontCenterAdjustment = Utils.ConvertToInt64(byteArray9) * (Utils.IsBitSet(byteToCheck, 4) ? 1 : (-1));
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray10 = Utils.Read(stream, num, ref bytesLeft);
						FrontCenterPeak = Utils.ConvertToInt64(byteArray10);
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray11 = Utils.Read(stream, num, ref bytesLeft);
						SubwooferAdjustment = Utils.ConvertToInt64(byteArray11) * (Utils.IsBitSet(byteToCheck, 5) ? 1 : (-1));
					}
					if (bytesLeft >= num)
					{
						byte[] byteArray12 = Utils.Read(stream, num, ref bytesLeft);
						SubwooferPeak = Utils.ConvertToInt64(byteArray12);
					}
				}
			}
			if (bytesLeft > 0)
			{
				Trace.WriteLine("Invalid RVA2/RVAD/RVA frame");
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			return new byte[0];
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void WriteID3v24ChannelItem(MemoryStream memoryStream, ChannelType channelType, decimal adjustment, decimal peak)
		{
			if (adjustment != 0m || peak != 0m)
			{
				memoryStream.WriteByte((byte)channelType);
				if (adjustment <= 64m)
				{
					_ = adjustment >= -64m;
				}
				throw new NotImplementedException();
			}
		}
	}
}
