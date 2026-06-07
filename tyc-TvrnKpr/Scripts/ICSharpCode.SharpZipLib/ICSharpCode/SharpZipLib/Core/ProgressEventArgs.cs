using System;

namespace ICSharpCode.SharpZipLib.Core
{
	public class ProgressEventArgs : EventArgs
	{
		private string name_;

		private long processed_;

		private long target_;

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

		public float PercentComplete => 0f;

		public long Processed => 0L;

		public long Target => 0L;

		public ProgressEventArgs(string name, long processed, long target)
		{
		}
	}
}
