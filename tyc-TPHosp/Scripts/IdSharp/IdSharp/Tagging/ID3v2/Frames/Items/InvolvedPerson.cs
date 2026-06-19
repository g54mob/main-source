using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	internal sealed class InvolvedPerson : IInvolvedPerson, INotifyPropertyChanged
	{
		private string m_Name;

		private string m_Involvement;

		public string Name
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name = value;
				FirePropertyChanged("Name");
			}
		}

		public string Involvement
		{
			get
			{
				return m_Involvement;
			}
			set
			{
				m_Involvement = value;
				FirePropertyChanged("Involvement");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
