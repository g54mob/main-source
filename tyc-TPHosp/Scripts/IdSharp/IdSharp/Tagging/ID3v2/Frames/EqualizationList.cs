using System;
using System.ComponentModel;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames.Items;
using IdSharp.Tagging.ID3v2.Frames.Lists;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class EqualizationList : IEqualizationList, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private InterpolationMethod m_InterpolationMethod;

		private string m_Identification;

		private BindingList<IEqualizationItem> m_Items;

		public InterpolationMethod InterpolationMethod
		{
			get
			{
				return m_InterpolationMethod;
			}
			set
			{
				m_InterpolationMethod = value;
				FirePropertyChanged("InterpolationMethod");
			}
		}

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

		public BindingList<IEqualizationItem> Items => m_Items;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public EqualizationList()
		{
			m_FrameHeader = new FrameHeader();
			m_Items = new EqualizationItemBindingList();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			return tagVersion switch
			{
				ID3v2TagVersion.ID3v24 => "EQU2", 
				ID3v2TagVersion.ID3v23 => "EQUA", 
				ID3v2TagVersion.ID3v22 => "EQU", 
				_ => throw new ArgumentException("Unknown tag version"), 
			};
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int frameSizeExcludingAdditions = m_FrameHeader.FrameSizeExcludingAdditions;
			if (frameSizeExcludingAdditions != 0)
			{
				stream.Seek(frameSizeExcludingAdditions, SeekOrigin.Current);
			}
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
