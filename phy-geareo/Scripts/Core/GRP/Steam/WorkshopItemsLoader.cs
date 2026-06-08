using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic.Reactive;
using Steamworks.Ugc;

namespace GRP.Steam
{
	public class WorkshopItemsLoader
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadItemsAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WorkshopItemsLoader _003C_003E4__this;

			private TaskAwaiter<ResultPage?> _003C_003Eu__1;

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

		public StateList<WorkshopItem> items;

		public State<bool> busy;

		public State<bool> error;

		public State<int> page;

		public State<int> totalPages;

		public Func<Query> query;

		public void LoadItems()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadItemsAsync_003Ed__7))]
		public Task LoadItemsAsync()
		{
			return null;
		}

		public WorkshopItemsLoader SetPage(int page)
		{
			return null;
		}
	}
}
