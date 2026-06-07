namespace Jundroo.Juicy
{
	public class WidgetFactory
	{
		private IWidgetContext _context;

		private IResourceLoader _resourceLoader;

		public WidgetFactory(IResourceLoader resourceLoader, IWidgetContext widgetContext)
		{
			_resourceLoader = resourceLoader;
			_context = widgetContext;
		}
	}
}
