using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rhizomatic.UI;
using UnityEngine;

namespace Rhizomatic.ImUI
{
	public class LabelHeightView : ImUIView<LabelHeightViewState>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadState_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LabelHeightView _003C_003E4__this;

			public LabelHeightViewState state;

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

		public RectTransform rect;

		public RectTransform textRect;

		public TextAdapter text;

		[AsyncStateMachine(typeof(_003CLoadState_003Ed__3))]
		protected override void LoadState(LabelHeightViewState state)
		{
		}

		protected override void LateUpdate()
		{
		}
	}
}
