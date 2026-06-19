using Loxodon.Framework.Contexts;
using Loxodon.Log;

namespace Loxodon.Framework.Views
{
	public abstract class UIBase
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UIBase));

		private const string DEFAULT_VIEW_LOCATOR_KEY = "_DEFAULT_VIEW_LOCATOR";

		protected static IUIViewLocator GetUIViewLocator()
		{
			ApplicationContext applicationContext = Context.GetApplicationContext();
			IUIViewLocator service = applicationContext.GetService<IUIViewLocator>();
			if (service != null)
			{
				return service;
			}
			if (log.IsWarnEnabled)
			{
				log.Warn("Not found the \"IUIViewLocator\" in the ApplicationContext.Try loading the Tips using the DefaultUIViewLocator.");
			}
			service = applicationContext.GetService<IUIViewLocator>("_DEFAULT_VIEW_LOCATOR");
			if (service == null)
			{
				service = new DefaultUIViewLocator();
				applicationContext.GetContainer().Register("_DEFAULT_VIEW_LOCATOR", service);
			}
			return service;
		}

		protected static IUIViewGroup GetCurrentViewGroup()
		{
			IWindow current;
			for (current = GlobalWindowManagerBase.Root.Current; current is WindowContainer windowContainer; current = windowContainer.Current)
			{
			}
			return current as IUIViewGroup;
		}
	}
}
