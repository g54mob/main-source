using System;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class EventTimingItem : IEventTimingItem, INotifyPropertyChanged
	{
		private MusicEvent m_EventType;

		private int m_Timestamp;

		public MusicEvent EventType
		{
			get
			{
				return m_EventType;
			}
			set
			{
				m_EventType = value;
				FirePropertyChanged("EventType");
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
