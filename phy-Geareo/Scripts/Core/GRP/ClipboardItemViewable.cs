using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class ClipboardItemViewable : Viewable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBuildThumbnail_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ClipboardItemViewable _003C_003E4__this;

			private EntityData[] _003CpartsData_003E5__2;

			private List<Id> _003CpartsId_003E5__3;

			private int[] _003Corders_003E5__4;

			private ProjectThumbnailBuilder _003Cptb_003E5__5;

			private TaskAwaiter _003C_003Eu__1;

			private State<Texture2D> _003C_003E7__wrap5;

			private ClipboardItem _003C_003E7__wrap6;

			private TaskAwaiter<Texture2D> _003C_003Eu__2;

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

		[RawImageCrew]
		public State<Texture2D> thumbnail;

		[GameObjectCrew]
		public State<bool> selected;

		public ClipboardItem item;

		public ClipboardPage clipboardPage;

		private bool disposed;

		public ClipboardItemViewable(ClipboardItem item, ClipboardPage clipboardPage)
		{
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CBuildThumbnail_003Ed__7))]
		private void BuildThumbnail()
		{
		}

		[CrewMethod]
		public void Remove()
		{
		}

		[CrewMethod]
		public void Select()
		{
		}
	}
}
