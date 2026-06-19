using System;
using System.Threading.Tasks;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Interactivity;

namespace Loxodon.Framework.Views.InteractionActions
{
	public class AsyncWindowInteractionAction : AsyncLoadableInteractionActionBase<WindowNotification>
	{
		private Window window;

		public Window Window => window;

		public AsyncWindowInteractionAction(string viewName)
			: this(viewName, null, null)
		{
		}

		public AsyncWindowInteractionAction(string viewName, IUIViewLocator locator)
			: base(viewName, locator)
		{
		}

		public AsyncWindowInteractionAction(string viewName, IWindowManager windowManager)
			: base(viewName, windowManager)
		{
		}

		public AsyncWindowInteractionAction(string viewName, IUIViewLocator locator, IWindowManager windowManager)
			: base(viewName, locator, windowManager)
		{
		}

		public override Task Action(WindowNotification notification)
		{
			bool ignoreAnimation = notification.IgnoreAnimation;
			return notification.ActionType switch
			{
				Loxodon.Framework.Interactivity.ActionType.CREATE => Create(notification.ViewModel), 
				Loxodon.Framework.Interactivity.ActionType.SHOW => Show(notification.ViewModel, notification.WaitDismissed, ignoreAnimation), 
				Loxodon.Framework.Interactivity.ActionType.HIDE => Hide(ignoreAnimation), 
				Loxodon.Framework.Interactivity.ActionType.DISMISS => Dismiss(ignoreAnimation), 
				_ => Task.CompletedTask, 
			};
		}

		protected async Task Create(object viewModel)
		{
			try
			{
				window = await LoadWindowAsync<Window>();
				if (window == null)
				{
					throw new NotFoundException($"Not found the window named \"{base.ViewName}\".");
				}
				if (viewModel != null)
				{
					window.SetDataContext(viewModel);
				}
				window.Create();
			}
			catch (Exception ex)
			{
				window = null;
				throw ex;
			}
		}

		protected async Task Show(object viewModel, bool waitDismissed, bool ignoreAnimation = false)
		{
			try
			{
				if (window == null)
				{
					await Create(viewModel);
				}
				else if (viewModel != null)
				{
					window.SetDataContext(viewModel);
				}
				window.WaitDismissed().Callbackable().OnCallback(delegate
				{
					window = null;
				});
				await window.Show(ignoreAnimation);
				if (waitDismissed)
				{
					await window.WaitDismissed();
				}
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
	}
}
