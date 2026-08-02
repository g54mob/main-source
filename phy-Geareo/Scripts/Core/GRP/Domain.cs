using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rhizomatic;

namespace GRP
{
	public abstract class Domain<TConfig> : Domain where TConfig : DomainConfig
	{
		public new TConfig config => null;
	}
	public abstract class Domain<TConfig, TScene> : Domain where TConfig : DomainConfig where TScene : DomainScene
	{
		public new TConfig config => null;

		public new TScene scene => null;
	}
	public abstract class Domain : Thing<DomainConfig>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnContext_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Domain _003C_003E4__this;

			private TaskAwaiter<int> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		public Page pageContainer;

		public Page firstPage;

		public DomainScene scene;

		public Main main;

		public NavigatorContext navigatorContext;

		private bool isLoaded;

		private Action onLoaded;

		[AsyncStateMachine(typeof(_003COnContext_003Ed__7))]
		public override void OnContext()
		{
		}

		protected virtual void OnLoaded()
		{
		}

		public void UseScene(Action<DomainScene> action)
		{
		}

		public override void OnContextDispose()
		{
		}
	}
}
