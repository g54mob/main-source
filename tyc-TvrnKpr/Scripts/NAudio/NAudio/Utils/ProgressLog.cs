using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NAudio.Utils
{
	public class ProgressLog : UserControl
	{
		private delegate void LogMessageDelegate(Color color, string message);

		private delegate void ClearLogDelegate();

		private IContainer components;

		private RichTextBox richTextBoxLog;

		public new string Text => null;

		public void LogMessage(Color color, string message)
		{
		}

		public void ClearLog()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
