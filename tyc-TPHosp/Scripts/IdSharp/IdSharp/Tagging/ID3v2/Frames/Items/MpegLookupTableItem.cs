using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class MpegLookupTableItem : IMpegLookupTableItem, INotifyPropertyChanged
	{
		private long m_DeviationInBytes;

		private long m_DeviationInMilliseconds;

		public long DeviationInBytes
		{
			get
			{
				return m_DeviationInBytes;
			}
			set
			{
				m_DeviationInBytes = value;
				FirePropertyChanged("DeviationInBytes");
			}
		}

		public long DeviationInMilliseconds
		{
			get
			{
				return m_DeviationInMilliseconds;
			}
			set
			{
				m_DeviationInMilliseconds = value;
				FirePropertyChanged("DeviationInMilliseconds");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
