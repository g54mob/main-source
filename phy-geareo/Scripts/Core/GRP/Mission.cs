using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GRP
{
	public class Mission : Domain<MissionConfig, MissionScene>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBake_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Mission _003C_003E4__this;

			private ProgressContainer _003Cprogress_003E5__2;

			private List<IMissionBake> _003Cbakes_003E5__3;

			private ProgressTaskGroup[] _003Ctasks_003E5__4;

			private int _003Ci_003E5__5;

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
		private struct _003CLaunch_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Mission _003C_003E4__this;

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
		private struct _003COnLoaded_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Mission _003C_003E4__this;

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

		public ProjectContainer projectContainer;

		public ProjectContainer missionEditorContainer;

		public MissionPoint missionPoint;

		public MissionItem missionItem;

		public MissionState missionState;

		public BakedMission bakedMission;

		private int bakedVersion;

		[AsyncStateMachine(typeof(_003COnLoaded_003Ed__7))]
		protected override void OnLoaded()
		{
		}

		public void OpenMissionEditor()
		{
		}

		public MissionData Serialize()
		{
			return null;
		}

		public void Save()
		{
		}

		[AsyncStateMachine(typeof(_003CBake_003Ed__11))]
		public Task Bake()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLaunch_003Ed__12))]
		public Task Launch()
		{
			return null;
		}

		public void TryWin()
		{
		}

		public void TryLose()
		{
		}

		public void LoadCampaign()
		{
		}
	}
}
