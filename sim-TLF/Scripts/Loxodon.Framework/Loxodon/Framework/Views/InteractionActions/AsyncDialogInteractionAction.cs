using System;
using System.Threading.Tasks;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using Loxodon.Log;

namespace Loxodon.Framework.Views.InteractionActions
{
	public class AsyncDialogInteractionAction : AsyncLoadableInteractionActionBase<object>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(AsyncDialogInteractionAction));

		private Window window;

		public Window Window => window;

		public AsyncDialogInteractionAction(string viewName)
			: base(viewName, (IUIViewLocator)null, (IWindowManager)null)
		{
		}

		public AsyncDialogInteractionAction(string viewName, IUIViewLocator locator)
			: base(viewName, locator)
		{
		}

		public override Task Action(object context)
		{
			if (context is WindowNotification { IgnoreAnimation: var ignoreAnimation } windowNotification)
			{
				return windowNotification.ActionType switch
				{
					Loxodon.Framework.Interactivity.ActionType.CREATE => Create(windowNotification.ViewModel), 
					Loxodon.Framework.Interactivity.ActionType.SHOW => Show(windowNotification.ViewModel, ignoreAnimation), 
					Loxodon.Framework.Interactivity.ActionType.HIDE => Hide(ignoreAnimation), 
					Loxodon.Framework.Interactivity.ActionType.DISMISS => Dismiss(ignoreAnimation), 
					_ => Task.CompletedTask, 
				};
			}
			return Show(context);
		}

		protected async Task Create(object viewModel)
		{
			try
			{
				window = await LoadWindowAsync<Window>();
				if (window == null)
				{
					throw new NotFoundException($"Not found the dialog window named \"{base.ViewName}\".");
				}
				SetDataContext(window, viewModel);
				window.Create();
			}
			catch (Exception ex)
			{
				window = null;
				throw ex;
			}
		}

		protected async Task Show(object viewModel, bool ignoreAnimation = false)
		{
			try
			{
				if (window == null)
				{
					await Create(viewModel);
				}
				else if (viewModel != null)
				{
					SetDataContext(window, viewModel);
				}
				await window.Show(ignoreAnimation);
				await window.WaitDismissed();
				window = null;
			}
			catch (Exception ex)
			{
				if (window != null)
				{
					await window.Dismiss(ignoreAnimation);
				}
				window = null;
				throw ex;
			}
		}

		protected async Task Hide(bool ignoreAnimation = false)
		{
			if (window != null)
			{
				await window.Hide(ignoreAnimation);
			}
		}

		protected async Task Dismiss(bool ignoreAnimation = false)
		{
			if (window != null)
			{
				await window.Dismiss(ignoreAnimation);
			}
		}

		protected void SetDataContext(Window window, object viewModel)
		{
			if (viewModel == null)
			{
				return;
			}
			if (window is AlertDialogWindowBase && viewModel is AlertDialogViewModel)
			{
				(window as AlertDialogWindowBase).ViewModel = viewModel as AlertDialogViewModel;
				return;
			}
			if (window is AlertDialogWindowBase)
			{
				DialogNotification notification = viewModel as DialogNotification;
				if (notification != null)
				{
					AlertDialogViewModel alertDialogViewModel = new AlertDialogViewModel();
					alertDialogViewModel.Message = notification.Message;
					alertDialogViewModel.Title = notification.Title;
					alertDialogViewModel.ConfirmButtonText = notification.ConfirmButtonText;
					alertDialogViewModel.NeutralButtonText = notification.NeutralButtonText;
					alertDialogViewModel.CancelButtonText = notification.CancelButtonText;
					alertDialogViewModel.CanceledOnTouchOutside = notification.CanceledOnTouchOutside;
					alertDialogViewModel.Click = delegate(int result)
					{
						notification.DialogResult = result;
					};
					(window as AlertDialogWindowBase).ViewModel = alertDialogViewModel;
					return;
				}
			}
			window.SetDataContext(viewModel);
		}
	}
}
