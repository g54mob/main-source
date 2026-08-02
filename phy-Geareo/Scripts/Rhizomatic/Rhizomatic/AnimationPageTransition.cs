using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.Playables;

namespace Rhizomatic
{
	public class AnimationPageTransition : PageTransition
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CClose_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AnimationPageTransition _003C_003E4__this;

			public View view;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COpen_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public View view;

			public AnimationPageTransition _003C_003E4__this;

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

		public AnimationClip open;

		public AnimationClip close;

		private Dictionary<View, PlayableGraph> graphs;

		[AsyncStateMachine(typeof(_003COpen_003Ed__3))]
		public override Task Open(View view)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CClose_003Ed__4))]
		public override Task Close(View view)
		{
			return null;
		}

		private Task Wait(float time)
		{
			return null;
		}

		public void PlayAnimation(View view, AnimationClip clip)
		{
		}
	}
}
