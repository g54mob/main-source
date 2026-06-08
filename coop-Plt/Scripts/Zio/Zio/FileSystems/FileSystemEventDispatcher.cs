using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Zio.FileSystems
{
	public class FileSystemEventDispatcher<T> : IDisposable where T : FileSystemWatcher
	{
		private readonly Thread _dispatchThread;

		private readonly BlockingCollection<Action> _dispatchQueue;

		private readonly CancellationTokenSource _dispatchCts;

		private readonly List<T> _watchers;

		public IFileSystem FileSystem { get; }

		public FileSystemEventDispatcher(IFileSystem fileSystem)
		{
			FileSystem = fileSystem ?? throw new ArgumentNullException("fileSystem");
			_dispatchThread = new Thread(DispatchWorker)
			{
				Name = "FileSystem Event Dispatch",
				IsBackground = true
			};
			_dispatchQueue = new BlockingCollection<Action>(16);
			_dispatchCts = new CancellationTokenSource();
			_watchers = new List<T>();
			_dispatchThread.Start();
		}

		~FileSystemEventDispatcher()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			_dispatchCts?.Cancel();
			_dispatchThread?.Join();
			if (!disposing)
			{
				return;
			}
			_dispatchQueue.CompleteAdding();
			lock (_watchers)
			{
				foreach (T watcher in _watchers)
				{
					watcher.Dispose();
				}
				_watchers.Clear();
			}
			_dispatchQueue.Dispose();
		}

		public void Add(T watcher)
		{
			lock (_watchers)
			{
				_watchers.Add(watcher);
			}
		}

		public void Remove(T watcher)
		{
			lock (_watchers)
			{
				_watchers.Remove(watcher);
			}
		}

		public void RaiseChange(UPath path)
		{
			FileChangedEventArgs eventArgs = new FileChangedEventArgs(FileSystem, WatcherChangeTypes.Changed, path);
			Dispatch(eventArgs, delegate(T w, FileChangedEventArgs a)
			{
				w.RaiseChanged(a);
			});
		}

		public void RaiseCreated(UPath path)
		{
			FileChangedEventArgs eventArgs = new FileChangedEventArgs(FileSystem, WatcherChangeTypes.Created, path);
			Dispatch(eventArgs, delegate(T w, FileChangedEventArgs a)
			{
				w.RaiseCreated(a);
			});
		}

		public void RaiseDeleted(UPath path)
		{
			FileChangedEventArgs eventArgs = new FileChangedEventArgs(FileSystem, WatcherChangeTypes.Deleted, path);
			Dispatch(eventArgs, delegate(T w, FileChangedEventArgs a)
			{
				w.RaiseDeleted(a);
			});
		}

		public void RaiseRenamed(UPath newPath, UPath oldPath)
		{
			FileRenamedEventArgs eventArgs = new FileRenamedEventArgs(FileSystem, WatcherChangeTypes.Renamed, newPath, oldPath);
			Dispatch(eventArgs, delegate(T w, FileRenamedEventArgs a)
			{
				w.RaiseRenamed(a);
			});
		}

		public void RaiseError(Exception exception)
		{
			FileSystemErrorEventArgs eventArgs = new FileSystemErrorEventArgs(exception);
			Dispatch(eventArgs, delegate(T w, FileSystemErrorEventArgs a)
			{
				w.RaiseError(a);
			}, captureError: false);
		}

		private void Dispatch<TArgs>(TArgs eventArgs, Action<T, TArgs> handler, bool captureError = true) where TArgs : EventArgs
		{
			List<T> watchersSnapshot;
			lock (_watchers)
			{
				if (_watchers.Count == 0)
				{
					return;
				}
				watchersSnapshot = _watchers.ToList();
			}
			_dispatchQueue.Add(delegate
			{
				foreach (T item in watchersSnapshot)
				{
					try
					{
						handler(item, eventArgs);
					}
					catch (Exception exception) when (captureError)
					{
						RaiseError(exception);
					}
				}
			});
		}

		private void DispatchWorker()
		{
			CancellationToken token = _dispatchCts.Token;
			try
			{
				foreach (Action item in _dispatchQueue.GetConsumingEnumerable(token))
				{
					item();
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (ObjectDisposedException)
			{
			}
		}
	}
}
