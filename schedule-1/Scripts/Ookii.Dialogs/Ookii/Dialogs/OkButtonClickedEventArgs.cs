using System.ComponentModel;
using System.Windows.Forms;

namespace Ookii.Dialogs
{
	public class OkButtonClickedEventArgs : CancelEventArgs
	{
		private string _input;

		private IWin32Window _inputBoxWindow;

		public string Input => null;

		public IWin32Window InputBoxWindow => null;

		public OkButtonClickedEventArgs(string input, IWin32Window inputBoxWindow)
		{
		}
	}
}
