using System;

namespace ICSharpCode.SharpZipLib.Core
{
	public class ScanEventArgs : EventArgs
	{
		private string name_;

		private bool continueRunning_;

		public string Name => null;

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

		public ScanEventArgs(string name)
		{
		}
	}
}
