using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class ToasterItemView : View<ToasterItemViewable>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnViewOpen_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ToasterItemView _003C_003E4__this;

			private TaskAwaiter<int> _003C_003Eu__1;

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

		public Transform parent;

		public Transform view;

		public CanvasGroup canvasGroup;

		public float smooth;

		public AnimationCurve fadeCurve;

		public float fadeTime;

		[AsyncStateMachine(typeof(_003COnViewOpen_003Ed__6))]
		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		protected override void Update()
		{
		}
	}
}
