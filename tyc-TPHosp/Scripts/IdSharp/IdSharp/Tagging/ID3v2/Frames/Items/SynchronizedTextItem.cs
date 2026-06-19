using System;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class SynchronizedTextItem : ISynchronizedTextItem, INotifyPropertyChanged
	{
		private string m_Text;

		private int m_Timestamp;

		public string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				m_Text = value;
				FirePropertyChanged("Text");
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
