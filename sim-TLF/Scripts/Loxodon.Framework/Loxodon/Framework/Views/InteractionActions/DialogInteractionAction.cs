using System;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using Loxodon.Log;

namespace Loxodon.Framework.Views.InteractionActions
{
	public class DialogInteractionAction : InteractionActionBase<object>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(DialogInteractionAction));

		private string viewName;

		public DialogInteractionAction(string viewName)
		{
			this.viewName = viewName;
		}

		public override void Action(object viewModel, Action callback)
		{
			Window window = null;
			try
			{
				IUIViewLocator obj = Context.GetApplicationContext().GetService<IUIViewLocator>() ?? throw new NotFoundException("Not found the \"IUIViewLocator\".");
				if (string.IsNullOrEmpty(viewName))
				{
					throw new ArgumentNullException("The view name is null.");
				}
				window = obj.LoadView<Window>(viewName);
				if (window == null)
				{
					throw new NotFoundException($"Not found the dialog window named \"{viewName}\".");
				}
				if (window is AlertDialogWindowBase && viewModel is AlertDialogViewModel)
				{
					(window as AlertDialogWindowBase).ViewModel = viewModel as AlertDialogViewModel;
				}
				else
				{
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
							goto IL_014b;
						}
					}
					window.SetDataContext(viewModel);
				}
				goto IL_014b;
				IL_014b:
				window.Create();
				window.WaitDismissed().Callbackable().OnCallback(delegate
				{
					callback?.Invoke();
					callback = null;
				});
				window.Show(ignoreAnimation: true);
			}
			catch (Exception exception)
			{
				callback?.Invoke();
				callback = null;
				if (window != null)
				{
					window.Dismiss();
				}
				if (log.IsWarnEnabled)
				{
					log.Error("", exception);
				}
			}
		}
	}
}
