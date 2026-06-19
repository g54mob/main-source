using System;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class TempoData : ITempoData, INotifyPropertyChanged
	{
		private short m_TempoCode;

		private int m_Timestamp;

		public short TempoCode
		{
			get
			{
				return m_TempoCode;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_TempoCode = value;
				FirePropertyChanged("TempoCode");
			}
		}

		public int Timestamp
		{
			get
			{
				return m_Timestamp;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_Timestamp = value;
				FirePropertyChanged("Timestamp");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
