using System.ComponentModel;
using System.Windows.Forms;

namespace IdSharp.Tagging.ID3v2
{
	internal sealed class FrameBinder
	{
		private FrameContainer m_FrameContainer;

		public FrameBinder(FrameContainer frameContainer)
		{
			m_FrameContainer = frameContainer;
		}

		public void Bind(INotifyPropertyChanged frame, string frameProperty, string tagProperty, MethodInvoker validator)
		{
			frame.PropertyChanged += delegate
			{
				m_FrameContainer.FirePropertyChanged(tagProperty);
				if (validator != null)
				{
					validator();
				}
			};
		}
	}
}
