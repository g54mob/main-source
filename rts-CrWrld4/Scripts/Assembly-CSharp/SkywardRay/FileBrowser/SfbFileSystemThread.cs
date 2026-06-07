using System;
using System.Threading;

namespace SkywardRay.FileBrowser
{
	public class SfbFileSystemThread
	{
		private Thread thread;

		private Action queuedAction;

		private SfbFileSystemEntry[] output;

		private Action<string, SfbFileSystemEntry[]> callbackAction;

		private bool waitForCallback;

		private string path;

		private readonly object tLock;

		private readonly object sharedMonitor;

		public bool IsAlive { get; private set; }

		public bool IsWorking { get; private set; }

		public void MainThreadUpdate()
		{
		}

		public void AsyncReadDirectoryContents(string path, Action<string, SfbFileSystemEntry[]> callback)
		{
		}

		public void KillThreadAndWait()
		{
		}

		private void InvokeCallbackOnMainThread()
		{
		}

		private void ThreadFunction()
		{
		}

		private void ReadDirectoryContents()
		{
		}
	}
}
