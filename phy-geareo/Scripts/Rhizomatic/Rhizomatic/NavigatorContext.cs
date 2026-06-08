namespace Rhizomatic
{
	public class NavigatorContext
	{
		public readonly NavigatorViewable navigator;

		public readonly Context context;

		public readonly Page parent;

		public readonly Page myPage;

		public NavigatorContext(Page myPage)
		{
		}

		public NavigatorContext(NavigatorViewable navigator, Context context, Page parent = null)
		{
		}

		public T Push<T>(T page) where T : Page
		{
			return null;
		}

		public T Push<T>(T page, Page parent) where T : Page
		{
			return null;
		}

		public T PushNested<T>(T page) where T : Page
		{
			return null;
		}

		public T PushDialog<T>(T page) where T : Page
		{
			return null;
		}

		public T PushDialog<T>(T page, Page parent) where T : Page
		{
			return null;
		}

		public T PushDialogNested<T>(T page) where T : Page
		{
			return null;
		}

		public static NavigatorContext Of(Context context)
		{
			return null;
		}
	}
}
