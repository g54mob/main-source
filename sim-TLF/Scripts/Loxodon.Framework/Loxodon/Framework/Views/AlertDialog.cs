using System;
using System.Threading.Tasks;
using Loxodon.Framework.Execution;
using Loxodon.Framework.ViewModels;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Views
{
	public class AlertDialog : UIBase, IDialog
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(AlertDialog));

		public const int BUTTON_POSITIVE = -1;

		public const int BUTTON_NEGATIVE = -2;

		public const int BUTTON_NEUTRAL = -3;

		private const string DEFAULT_VIEW_NAME = "UI/AlertDialog";

		private static string viewName;

		private TaskCompletionSource<int> source;

		private AlertDialogWindowBase window;

		private IUIView contentView;

		private AlertDialogViewModel viewModel;

		public static string ViewName
		{
			get
			{
				if (!string.IsNullOrEmpty(viewName))
				{
					return viewName;
				}
				return "UI/AlertDialog";
			}
			set
			{
				viewName = value;
			}
		}

		public static AlertDialog ShowMessage(string message, string title)
		{
			return ShowMessage(message, title, null, null, null, canceledOnTouchOutside: true, null);
		}

		public static AlertDialog ShowMessage(string message, string title, string buttonText, Action<int> afterHideCallback)
		{
			return ShowMessage(message, title, buttonText, null, null, canceledOnTouchOutside: false, afterHideCallback);
		}

		public static AlertDialog ShowMessage(string message, string title, string confirmButtonText, string cancelButtonText, Action<int> afterHideCallback)
		{
			return ShowMessage(message, title, confirmButtonText, null, cancelButtonText, canceledOnTouchOutside: false, afterHideCallback);
		}

		public static AlertDialog ShowMessage(string message, string title, string confirmButtonText, string neutralButtonText, string cancelButtonText, bool canceledOnTouchOutside, Action<int> afterHideCallback)
		{
			AlertDialogViewModel alertDialogViewModel = new AlertDialogViewModel();
			alertDialogViewModel.Message = message;
			alertDialogViewModel.Title = title;
			alertDialogViewModel.ConfirmButtonText = confirmButtonText;
			alertDialogViewModel.NeutralButtonText = neutralButtonText;
			alertDialogViewModel.CancelButtonText = cancelButtonText;
			alertDialogViewModel.CanceledOnTouchOutside = canceledOnTouchOutside;
			alertDialogViewModel.Click = afterHideCallback;
			return ShowMessage(ViewName, alertDialogViewModel);
		}

		public static AlertDialog ShowMessage(IUIView contentView, string title, string confirmButtonText, string neutralButtonText, string cancelButtonText, bool canceledOnTouchOutside, Action<int> afterHideCallback)
		{
			AlertDialogViewModel alertDialogViewModel = new AlertDialogViewModel();
			alertDialogViewModel.Title = title;
			alertDialogViewModel.ConfirmButtonText = confirmButtonText;
			alertDialogViewModel.NeutralButtonText = neutralButtonText;
			alertDialogViewModel.CancelButtonText = cancelButtonText;
			alertDialogViewModel.CanceledOnTouchOutside = canceledOnTouchOutside;
			alertDialogViewModel.Click = afterHideCallback;
			AlertDialogWindowBase alertDialogWindowBase = UIBase.GetUIViewLocator().LoadView<AlertDialogWindowBase>(ViewName);
			if (alertDialogWindowBase == null)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("Not found the dialog window named \"{0}\".", viewName);
				}
				throw new NotFoundException($"Not found the dialog window named \"{viewName}\".");
			}
			AlertDialog alertDialog = new AlertDialog(alertDialogWindowBase, contentView, alertDialogViewModel);
			alertDialog.Show();
			return alertDialog;
		}

		public static AlertDialog ShowMessage(AlertDialogViewModel viewModel)
		{
			return ShowMessage(ViewName, null, viewModel);
		}

		public static AlertDialog ShowMessage(string viewName, AlertDialogViewModel viewModel)
		{
			return ShowMessage(viewName, null, viewModel);
		}

		public static AlertDialog ShowMessage(string viewName, string contentViewName, AlertDialogViewModel viewModel)
		{
			AlertDialogWindowBase alertDialogWindowBase = null;
			IUIView iUIView = null;
			try
			{
				if (string.IsNullOrEmpty(viewName))
				{
					viewName = ViewName;
				}
				IUIViewLocator uIViewLocator = UIBase.GetUIViewLocator();
				alertDialogWindowBase = uIViewLocator.LoadView<AlertDialogWindowBase>(viewName);
				if (alertDialogWindowBase == null)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("Not found the dialog window named \"{0}\".", viewName);
					}
					throw new NotFoundException($"Not found the dialog window named \"{viewName}\".");
				}
				if (!string.IsNullOrEmpty(contentViewName))
				{
					iUIView = uIViewLocator.LoadView<IUIView>(contentViewName);
				}
				AlertDialog alertDialog = new AlertDialog(alertDialogWindowBase, iUIView, viewModel);
				alertDialog.Show();
				return alertDialog;
			}
			catch (Exception ex)
			{
				if (alertDialogWindowBase != null)
				{
					alertDialogWindowBase.Dismiss();
				}
				if (iUIView != null)
				{
					UnityEngine.Object.Destroy(iUIView.Owner);
				}
				throw ex;
			}
		}

		public AlertDialog(AlertDialogWindowBase window, AlertDialogViewModel viewModel)
			: this(window, null, viewModel)
		{
		}

		public AlertDialog(AlertDialogWindowBase window, IUIView contentView, AlertDialogViewModel viewModel)
		{
			AlertDialog alertDialog = this;
			source = new TaskCompletionSource<int>();
			this.window = window;
			this.contentView = contentView;
			this.viewModel = viewModel;
			EventHandler handler = null;
			handler = delegate
			{
				alertDialog.window.OnDismissed -= handler;
				alertDialog.source.SetResult(viewModel.Result);
			};
			this.window.OnDismissed += handler;
		}

		public virtual object WaitForClosed()
		{
			return Executors.WaitWhile(() => !viewModel.Closed);
		}

		public virtual Task<int> WaitForResult()
		{
			return source.Task;
		}

		public void Show()
		{
			window.ViewModel = viewModel;
			if (contentView != null)
			{
				window.ContentView = contentView;
			}
			window.Create();
			window.Show();
		}

		public void Cancel()
		{
			window.Cancel();
		}
	}
}
