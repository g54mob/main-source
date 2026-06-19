using System;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using Loxodon.Log;

namespace Loxodon.Framework.Views
{
	public class DefaultDialogService : IDialogService
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(DefaultDialogService));

		public virtual IAsyncResult<int> ShowDialog(string title, string message)
		{
			return ShowDialog(title, message, null, null, null, canceledOnTouchOutside: true);
		}

		public virtual IAsyncResult<int> ShowDialog(string title, string message, string buttonText)
		{
			return ShowDialog(title, message, buttonText, null, null, canceledOnTouchOutside: false);
		}

		public virtual IAsyncResult<int> ShowDialog(string title, string message, string confirmButtonText, string cancelButtonText)
		{
			return ShowDialog(title, message, confirmButtonText, cancelButtonText, null, canceledOnTouchOutside: false);
		}

		public virtual IAsyncResult<int> ShowDialog(string title, string message, string confirmButtonText, string cancelButtonText, string neutralButtonText)
		{
			return ShowDialog(title, message, confirmButtonText, cancelButtonText, neutralButtonText, canceledOnTouchOutside: false);
		}

		public virtual IAsyncResult<int> ShowDialog(string title, string message, string confirmButtonText, string cancelButtonText, string neutralButtonText, bool canceledOnTouchOutside)
		{
			AsyncResult<int> result = new AsyncResult<int>();
			try
			{
				AlertDialog.ShowMessage(message, title, confirmButtonText, neutralButtonText, cancelButtonText, canceledOnTouchOutside, delegate(int which)
				{
					result.SetResult(which);
				});
			}
			catch (Exception exception)
			{
				result.SetException(exception);
			}
			return result;
		}

		public virtual IAsyncResult<TViewModel> ShowDialog<TViewModel>(string viewName, TViewModel viewModel) where TViewModel : IViewModel
		{
			AsyncResult<TViewModel> result = new AsyncResult<TViewModel>();
			Window window = null;
			try
			{
				IUIViewLocator service = Context.GetApplicationContext().GetService<IUIViewLocator>();
				if (service == null)
				{
					if (log.IsWarnEnabled)
					{
						log.Warn("Not found the \"IUIViewLocator\".");
					}
					throw new NotFoundException("Not found the \"IUIViewLocator\".");
				}
				if (string.IsNullOrEmpty(viewName))
				{
					throw new ArgumentNullException("The view name is null.");
				}
				window = service.LoadView<Window>(viewName);
				if (window == null)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("Not found the dialog window named \"{0}\".", viewName);
					}
					throw new NotFoundException($"Not found the dialog window named \"{viewName}\".");
				}
				if (window is AlertDialogWindowBase && viewModel is AlertDialogViewModel)
				{
					(window as AlertDialogWindowBase).ViewModel = viewModel as AlertDialogViewModel;
				}
				else
				{
					window.SetDataContext(viewModel);
				}
				EventHandler handler = null;
				handler = delegate
				{
					window.OnDismissed -= handler;
					result.SetResult(viewModel);
				};
				window.Create();
				window.OnDismissed += handler;
				window.Show(ignoreAnimation: true);
			}
			catch (Exception exception)
			{
				result.SetException(exception);
				if (window != null)
				{
					window.Dismiss();
				}
			}
			return result;
		}

		public IAsyncResult<IViewModel> ShowDialog(string viewName, IViewModel viewModel)
		{
			return this.ShowDialog<IViewModel>(viewName, viewModel);
		}
	}
}
