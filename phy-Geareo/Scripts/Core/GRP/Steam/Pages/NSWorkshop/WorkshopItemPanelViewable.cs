using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP.Steam.Pages.NSWorkshop
{
	public class WorkshopItemPanelViewable : Viewable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDownload_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WorkshopItemPanelViewable _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

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
		private struct _003COpenProject_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WorkshopItemPanelViewable _003C_003E4__this;

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
		private struct _003CSubscribe_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WorkshopItemPanelViewable _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

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
		private struct _003CUnsubscribe_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WorkshopItemPanelViewable _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		[ViewCrew(typeof(ImageUrlView))]
		public ImageUrlViewable image;

		[TextCrew]
		public string title;

		[TextCrew]
		public string updated;

		[TextCrew]
		public string description;

		[GameObjectCrew]
		public State<bool> isInstalled;

		[GameObjectCrew]
		public State<bool> isSubscribed;

		[GameObjectCrew]
		public State<bool> isNotSubscribed;

		[GameObjectCrew]
		public State<bool> needsUpdate;

		[GameObjectCrew]
		public State<bool> isDownloading;

		[GameObjectCrew]
		public State<bool> isDownloadPending;

		[SelectableCrew]
		public State<bool> download;

		[SelectableCrew]
		public StateSelector<bool> subscribe;

		[SelectableCrew]
		public StateSelector<bool> unsubscribe;

		[GameObjectCrew]
		public State<bool> busy;

		[BarCrew]
		public State<float> downloadProgress;

		[TextCrew]
		public StateSelector<string> downloadProgressPer;

		[GameObjectCrew]
		public bool isProject;

		public Context context;

		public WorkshopItem item;

		public WorkshopItemPanelViewable(Context context, WorkshopItem item)
		{
		}

		public void Dispose()
		{
		}

		public void UpdateState()
		{
		}

		[AsyncStateMachine(typeof(_003CDownload_003Ed__22))]
		[CrewMethod]
		public void Download()
		{
		}

		[AsyncStateMachine(typeof(_003CSubscribe_003Ed__23))]
		[CrewMethod]
		public void Subscribe()
		{
		}

		[AsyncStateMachine(typeof(_003CUnsubscribe_003Ed__24))]
		[CrewMethod]
		public void Unsubscribe()
		{
		}

		[AsyncStateMachine(typeof(_003COpenProject_003Ed__25))]
		[CrewMethod]
		public void OpenProject()
		{
		}
	}
}
