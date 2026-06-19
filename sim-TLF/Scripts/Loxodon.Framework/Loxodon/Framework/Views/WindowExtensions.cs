using System;
using Loxodon.Framework.Asynchronous;

namespace Loxodon.Framework.Views
{
	public static class WindowExtensions
	{
		public static Loxodon.Framework.Asynchronous.IAsyncResult WaitDismissed(this Window window)
		{
			AsyncResult result = new AsyncResult();
			EventHandler handler = null;
			handler = delegate
			{
				window.OnDismissed -= handler;
				result.SetResult();
			};
			window.OnDismissed += handler;
			return result;
		}

		public static Loxodon.Framework.Asynchronous.IAsyncResult WaitDisabled(this UIView view)
		{
			AsyncResult result = new AsyncResult();
			EventHandler handler = null;
			handler = delegate
			{
				view.OnDisabled -= handler;
				result.SetResult();
			};
			view.OnDisabled += handler;
			return result;
		}
	}
}
