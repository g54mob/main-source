using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public abstract class Page : Viewable, IWithContext, IWithContextDispose
	{
		private bool _orderAfterChildren;

		public Page parent;

		internal int order;

		public bool isDialog { get; internal set; }

		public bool isOpen { get; internal set; }

		public bool isTop { get; internal set; }

		public bool isValid => false;

		public bool orderAfterChildren
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public NavigatorViewable myNavigator { get; private set; }

		public Context context { get; set; }

		public NavigatorContext navigatorContext { get; private set; }

		public NavigatorContext rootNavigatorContext { get; private set; }

		protected virtual void OnPageStart()
		{
		}

		protected virtual void OnPageOpen()
		{
		}

		protected virtual void OnPageTop()
		{
		}

		protected virtual void OnPageClose()
		{
		}

		protected virtual void OnPageRemoved()
		{
		}

		public virtual void OnContext()
		{
		}

		public virtual void OnContextDispose()
		{
		}

		public bool HasPage<T>() where T : Page
		{
			return false;
		}

		public bool HasPageOpen<T>() where T : Page
		{
			return false;
		}

		public T GetPage<T>() where T : Page
		{
			return null;
		}

		public T GetPageOpen<T>() where T : Page
		{
			return null;
		}

		public List<Page> GetPageStack()
		{
			return null;
		}

		public List<Page> GetPageParentStack()
		{
			return null;
		}

		public int GetPageStackCount()
		{
			return 0;
		}

		public int GetPageParentStackCount()
		{
			return 0;
		}

		public void PopPage()
		{
		}

		public void ReplacePage(Page newPage)
		{
		}

		public void BringPageToTop()
		{
		}

		public void BringPageToBottom()
		{
		}

		public List<Page> GetPagePath()
		{
			return null;
		}

		public Page GetRootPage()
		{
			return null;
		}

		internal void HandlePageStart(NavigatorViewable navigator)
		{
		}

		internal void HandlePageOpen()
		{
		}

		internal void HandlePageTop()
		{
		}

		internal void HandlePageClose()
		{
		}

		internal void HandlePageRemoved()
		{
		}
	}
}
