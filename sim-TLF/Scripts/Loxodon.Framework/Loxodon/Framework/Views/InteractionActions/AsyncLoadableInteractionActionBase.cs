using System;
using System.Threading.Tasks;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;

namespace Loxodon.Framework.Views.InteractionActions
{
	public abstract class AsyncLoadableInteractionActionBase<TNotification> : AsyncInteractionActionBase<TNotification>
	{
		private string viewName;

		private IUIViewLocator locator;

		private IWindowManager windowManager;

		protected string ViewName => viewName;

		protected IUIViewLocator Locator
		{
			get
			{
				if (locator == null)
				{
					ApplicationContext applicationContext = Context.GetApplicationContext();
					locator = applicationContext.GetService<IUIViewLocator>();
				}
				return locator;
			}
		}

		public AsyncLoadableInteractionActionBase(string viewName, IUIViewLocator locator)
			: this(viewName, locator, (IWindowManager)null)
		{
		}

		public AsyncLoadableInteractionActionBase(string viewName, IWindowManager windowManager)
			: this(viewName, (IUIViewLocator)null, windowManager)
		{
		}

		public AsyncLoadableInteractionActionBase(string viewName, IUIViewLocator locator, IWindowManager windowManager)
		{
			this.viewName = viewName;
			this.locator = locator;
			this.windowManager = windowManager;
		}

		protected async Task<T> LoadViewAsync<T>() where T : IView
		{
			IUIViewLocator obj = Locator ?? throw new NotFoundException("Not found the \"IUIViewLocator\".");
			if (string.IsNullOrEmpty(viewName))
			{
				throw new ArgumentNullException("The view name is null.");
			}
			return await obj.LoadViewAsync<T>(viewName);
		}

		protected async Task<T> LoadWindowAsync<T>() where T : IWindow
		{
			IUIViewLocator obj = Locator ?? throw new NotFoundException("Not found the \"IUIViewLocator\".");
			if (string.IsNullOrEmpty(viewName))
			{
				throw new ArgumentNullException("The view name is null.");
			}
			return await obj.LoadWindowAsync<T>(windowManager, viewName);
		}
	}
}
