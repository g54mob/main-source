using System;
using Loxodon.Framework.Execution;
using Loxodon.Log;

namespace Loxodon.Framework.Views
{
	public class Loading : UIBase, IDisposable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(Loading));

		private const string DEFAULT_VIEW_NAME = "UI/Loading";

		private static object _lock = new object();

		private static int refCount = 0;

		private static LoadingWindow window;

		private static string viewName;

		private bool ignoreAnimation;

		private bool disposed;

		public static string ViewName
		{
			get
			{
				if (!string.IsNullOrEmpty(viewName))
				{
					return viewName;
				}
				return "UI/Loading";
			}
			set
			{
				viewName = value;
			}
		}

		public static Loading Show(bool ignoreAnimation = false)
		{
			return new Loading(ignoreAnimation);
		}

		protected Loading(bool ignoreAnimation)
		{
			this.ignoreAnimation = ignoreAnimation;
			lock (_lock)
			{
				if (refCount <= 0)
				{
					window = UIBase.GetUIViewLocator().LoadWindow<LoadingWindow>(ViewName);
					window.Create();
					window.Show(this.ignoreAnimation);
				}
				refCount++;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
			{
				return;
			}
			disposed = true;
			Executors.RunOnMainThread(delegate
			{
				lock (_lock)
				{
					refCount--;
					if (refCount <= 0)
					{
						window.Dismiss(ignoreAnimation);
						window = null;
					}
				}
			});
		}

		~Loading()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
