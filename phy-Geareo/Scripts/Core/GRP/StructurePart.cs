using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine.InputSystem;

namespace GRP
{
	public class StructurePart : Part<StructurePartConfig>, IMissionBake, IMissionLaunch
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBakeMission_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public StructurePart _003C_003E4__this;

			public BakedMission mission;

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

		[JsonDataState(null)]
		public State<bool> locked;

		[JsonDataState(null)]
		public State<Key> key;

		public List<StructurePartItem> parts;

		public string bakeKey => null;

		protected override PartViewable DoCreateViewable()
		{
			return null;
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		[AsyncStateMachine(typeof(_003CBakeMission_003Ed__7))]
		public Task BakeMission(BakedMission mission, ProgressTaskGroup task)
		{
			return null;
		}

		public void LaunchMission(Mission mission)
		{
		}

		protected override void Save(JsonData data)
		{
		}

		protected override void Load(JsonData data)
		{
		}

		protected override void LoadDiff(JsonData data)
		{
		}
	}
}
