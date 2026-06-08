using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using Steamworks.Ugc;
using UnityEngine;

namespace GRP.Steam
{
	public class WorkshopEditorPage : Page, IProgress<float>
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass14_0
		{
			public PublishResult res;

			internal void _003CSubmit_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadItem_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WorkshopEditorPage _003C_003E4__this;

			public WorkshopItem item;

			private State<Texture2D> _003C_003E7__wrap1;

			private TaskAwaiter<Texture2D> _003C_003Eu__1;

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
		private struct _003CSubmit_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WorkshopEditorPage _003C_003E4__this;

			private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

			private TaskAwaiter<PublishResult> _003C_003Eu__1;

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

		[InputFieldCrew]
		public State<string> title;

		[InputFieldCrew]
		public State<string> description;

		[DropdownCrew]
		public State<int> visibility;

		[GameObjectCrew]
		public StateSelector<bool> projectFileSelected;

		[GameObjectCrew]
		public State<bool> loading;

		[BarCrew]
		public State<float> progress;

		[GameObjectCrew]
		public bool creatingNew;

		public State<ProjectFileDefinition> projectFile;

		public Editor editor;

		private Texture2D loadedTexture;

		public WorkshopEditorPage()
		{
		}

		public WorkshopEditorPage(WorkshopItem item)
		{
		}

		public override void OnContext()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadItem_003Ed__13))]
		public void LoadItem(WorkshopItem item)
		{
		}

		[AsyncStateMachine(typeof(_003CSubmit_003Ed__14))]
		[CrewMethod]
		public void Submit()
		{
		}

		[CrewMethod]
		public void PickProject()
		{
		}

		[CrewMethod]
		public void Back()
		{
		}

		public void Report(float value)
		{
		}
	}
}
