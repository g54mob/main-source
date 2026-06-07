using System;

namespace ICSharpCode.SharpZipLib.Core
{
	public class ScanFailureEventArgs : EventArgs
	{
		private string name_;

		private Exception exception_;

		private bool continueRunning_;

		public string Name => null;

		public Exception Exception => null;

		public bool ContinueRunning
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ScanFailureEventArgs(string name, Exception e)
		{
		}
	}
}
