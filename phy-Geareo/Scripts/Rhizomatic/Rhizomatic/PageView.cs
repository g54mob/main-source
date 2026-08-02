using System;
using System.Runtime.CompilerServices;
using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public abstract class PageView : View
	{
		private Func<bool> backFunc;

		private BackHandlerItem backHandlerItem;

		public NavigatorView manager { get; private set; }

		public Page page => null;

		public event Action onPageOpen
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onPageClose
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal void _Setup(NavigatorView manager)
		{
		}

		internal void _PageOpen()
		{
		}

		internal void _PageClose()
		{
		}

		public void SetBack(Func<bool> func)
		{
		}

		public void SetBack(Action action)
		{
		}

		public void SetBackPopPage()
		{
		}

		protected virtual void Setup()
		{
		}

		protected virtual void OnPageOpen()
		{
		}

		protected virtual void OnPageClose()
		{
		}
	}
	[CustomMemberBinding]
	public abstract class PageView<T> : PageView where T : Page
	{
		public override Type viewableType => null;

		public new T viewable => null;

		public static void MemberBinder_CustomMemberBinding(MemberBindData bindData)
		{
		}
	}
}
