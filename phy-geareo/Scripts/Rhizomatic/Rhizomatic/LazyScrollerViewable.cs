using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class LazyScrollerViewable : Viewable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoad_003Ed__21 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public LazyScrollerViewable _003C_003E4__this;

			public bool clear;

			private int _003Coffset_003E5__2;

			private int _003CmyIndex_003E5__3;

			private TaskAwaiter<List<IViewable>> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRefresh_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public LazyScrollerViewable _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[ScrollableLayoutCrew]
		public ScrollableLayoutViewable layout;

		[GameObjectCrew]
		public State<bool> loading;

		[GameObjectCrew]
		public State<bool> error;

		[GameObjectCrew]
		public State<bool> finished;

		[GameObjectCrew]
		public StateSelector<bool> willRefresh;

		public bool allowRefresh;

		public bool allowLoadMore;

		public float startPadding;

		public float loadingPadding;

		public List<IViewable> items;

		public readonly int offset;

		public readonly LazyScrollerLoader loader;

		private int loadIndex;

		public event Action<List<IViewable>> onItemsLoaded
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

		public event Action<Exception> onError
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

		public LazyScrollerViewable(int offset, LazyScrollerLoader loader, params IViewable[] startItems)
		{
		}

		public Task LoadMore()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoad_003Ed__21))]
		public Task Load(bool clear)
		{
			return null;
		}

		public void Cancel()
		{
		}

		public void Clear()
		{
		}

		[AsyncStateMachine(typeof(_003CRefresh_003Ed__24))]
		[CrewMethod]
		public Task Refresh()
		{
			return null;
		}

		[CrewMethod]
		public void Retry()
		{
		}

		public static LazyScrollerViewable Simple<T>(Context context, Func<int, Task<IEnumerable<T>>> loader, Func<T, IViewable> builder)
		{
			return null;
		}
	}
}
