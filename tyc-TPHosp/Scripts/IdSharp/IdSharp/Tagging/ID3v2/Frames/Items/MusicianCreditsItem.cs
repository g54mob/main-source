using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class MusicianCreditsItem : IMusicianCreditsItem, INotifyPropertyChanged
	{
		private string m_Instrument;

		private string m_Artists;

		public string Instrument
		{
			get
			{
				return m_Instrument;
			}
			set
			{
				m_Instrument = value;
				FirePropertyChanged("Instrument");
			}
		}

		public string Artists
		{
			get
			{
				return m_Artists;
			}
			set
			{
				m_Artists = value;
				FirePropertyChanged("Artists");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
