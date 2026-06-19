using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class PriceInformation : IPriceInformation, INotifyPropertyChanged
	{
		private string m_CurrencyCode;

		private double m_Price;

		public string CurrencyCode
		{
			get
			{
				return m_CurrencyCode;
			}
			set
			{
				m_CurrencyCode = value;
				FirePropertyChanged("CurrencyCode");
			}
		}

		public double Price
		{
			get
			{
				return m_Price;
			}
			set
			{
				m_Price = value;
				FirePropertyChanged("Price");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
