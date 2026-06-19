using System;
using System.Threading.Tasks;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Interactivity;
using UnityEngine;

namespace Loxodon.Framework.Views.InteractionActions
{
	public class AsyncViewInteractionAction : AsyncLoadableInteractionActionBase<VisibilityNotification>
	{
		private IUIViewGroup viewGroup;

		private UIView view;

		private bool autoDestroy;

		public UIView View => view;

		public AsyncViewInteractionAction(string viewName, IUIViewGroup viewGroup, bool autoDestroy = true)
			: this(viewName, viewGroup, null, autoDestroy)
		{
		}

		public AsyncViewInteractionAction(string viewName, IUIViewGroup viewGroup, IUIViewLocator locator, bool autoDestroy = true)
			: base(viewName, locator)
		{
			this.viewGroup = viewGroup;
			this.autoDestroy = autoDestroy;
		}

		public AsyncViewInteractionAction(UIView view, bool autoDestroy = false)
			: base((string)null, (IUIViewLocator)null, (IWindowManager)null)
		{
			this.view = view;
			this.autoDestroy = autoDestroy;
		}

		public override Task Action(VisibilityNotification notification)
		{
			if (notification.Visible)
			{
				return Show(notification.ViewModel, notification.WaitDisabled);
			}
			return Hide();
		}

		protected virtual async Task Show(object viewModel, bool waitDisabled)
		{
			_ = 1;
			try
			{
				if (view == null)
				{
					view = await LoadViewAsync<UIView>();
				}
				if (view == null)
				{
					throw new NotFoundException($"Not found the view named \"{base.ViewName}\".");
				}
				if (viewGroup != null)
				{
					viewGroup.AddView(view);
				}
				if (autoDestroy)
				{
					view.WaitDisabled().Callbackable().OnCallback(delegate
					{
						view = null;
					});
				}
				if (viewModel != null)
				{
					view.SetDataContext(viewModel);
				}
				view.Visibility = true;
				if (waitDisabled)
				{
					await view.WaitDisabled();
				}
			}
			catch (Exception ex)
			{
				if (autoDestroy)
				{
					Destroy(view);
				}
				throw ex;
			}
		}

		protected Task Hide()
		{
			UIView uIView = view;
			if (uIView != null)
			{
				uIView.Visibility = false;
				if (autoDestroy)
				{
					Destroy(uIView);
				}
			}
			return Task.CompletedTask;
		}

		private void Destroy(UIView view)
		{
			if (!(view == null))
			{
				GameObject owner = view.Owner;
				if (owner != null)
				{
					UnityEngine.Object.Destroy(owner);
				}
				this.view = null;
			}
		}
	}
}
