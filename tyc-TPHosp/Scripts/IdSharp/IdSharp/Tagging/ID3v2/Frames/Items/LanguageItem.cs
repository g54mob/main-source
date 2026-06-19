using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class LanguageItem : ILanguageItem, INotifyPropertyChanged
	{
		private string m_LanguageCode;

		private string m_LanguageDisplay;

		public string LanguageCode
		{
			get
			{
				return m_LanguageCode;
			}
			set
			{
				m_LanguageCode = value;
				if (LanguageHelper.Languages.TryGetValue(m_LanguageCode.ToLower(), out var value2))
				{
					LanguageDisplay = value2;
				}
				else
				{
					LanguageDisplay = m_LanguageCode;
				}
				FirePropertyChanged("LanguageCode");
			}
		}

		public string LanguageDisplay
		{
			get
			{
				return m_LanguageDisplay;
			}
			private set
			{
				m_LanguageDisplay = value;
				FirePropertyChanged("LanguageDisplay");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
