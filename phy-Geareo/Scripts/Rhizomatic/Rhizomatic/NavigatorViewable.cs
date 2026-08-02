using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class NavigatorViewable : Viewable, IWithContext, IWithContextDispose
	{
		public StateList<Page> stack;

		public StateList<Page> openPages;

		public Action onStackChanged;

		public Context context { get; set; }

		public NavigatorContext navigatorContext { get; private set; }

		public void OnContext()
		{
		}

		public void OnContextDispose()
		{
		}

		public bool Has<T>(Page parent) where T : Page
		{
			return false;
		}

		public bool HasOpen<T>(Page parent) where T : Page
		{
			return false;
		}

		public T Get<T>(Page parent) where T : Page
		{
			return null;
		}

		public T GetOpen<T>(Page parent) where T : Page
		{
			return null;
		}

		public bool Has<T>() where T : Page
		{
			return false;
		}

		public bool HasOpen<T>() where T : Page
		{
			return false;
		}

		public T Get<T>() where T : Page
		{
			return null;
		}

		public T GetOpen<T>() where T : Page
		{
			return null;
		}

		public Page Push(Page page, Context parentContext = null, Page parent = null)
		{
			return null;
		}

		public T Push<T>(T page, Context parentContext = null, Page parent = null) where T : Page
		{
			return null;
		}

		public Page PushDialog(Page page, Context parentContext = null, Page parent = null)
		{
			return null;
		}

		public T PushDialog<T>(T page, Context parentContext = null, Page parent = null) where T : Page
		{
			return null;
		}

		public Page Insert(int index, Page page, Context parentContext = null, Page parent = null)
		{
			return null;
		}

		public T Insert<T>(int index, T page, Context parentContext = null, Page parent = null) where T : Page
		{
			return null;
		}

		public Page Replace(Page page, Page newPage)
		{
			return null;
		}

		public void Pop(Page page)
		{
		}

		public void Pop<T>() where T : Page
		{
		}

		public void PopAll<T>() where T : Page
		{
		}

		public void Pop()
		{
		}

		public void PopAll()
		{
		}

		public void BringToTop(Page page)
		{
		}

		public void BringToBottom(Page page)
		{
		}

		public List<Page> GetStack(Page parent = null)
		{
			return null;
		}

		public int GetStackCount(Page parent = null)
		{
			return 0;
		}

		internal void UpdatePages()
		{
		}
	}
}
