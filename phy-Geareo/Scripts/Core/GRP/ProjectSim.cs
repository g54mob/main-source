using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic.Pooling;
using UnityEngine;

namespace GRP
{
	public class ProjectSim : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass55_0
		{
			public ProjectSim _003C_003E4__this;

			public int i;

			public Predicate<SimPartShape> _003C_003E9__0;

			internal bool _003CExplode_003Eb__0(SimPartShape e)
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExplode_003Ed__55 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ProjectSim _003C_003E4__this;

			private _003C_003Ec__DisplayClass55_0 _003C_003E8__1;

			private List<SimPartShape> _003Csource_003E5__2;

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
		private struct _003CInit_003Ed__46 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ProjectSim _003C_003E4__this;

			public Project project;

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

		public ObjectPool pool;

		public CameraSim cameraSim;

		public HubSim hub;

		public RattleScene rattleScene;

		public Transform container;

		public bool dynamicPhysicsStep;

		public float maxPhysicsLag;

		public int physicsSteps;

		public int ticksPerSecond;

		public AnimationCurve physicsStepsOverFps;

		public PartsContainerConfig partsContainer;

		public List<Cluster> clusters;

		public Project project;

		public PhysicsController physicsController;

		private List<ISimTick> partsTick;

		private List<ISimPhysicsUpdate> partsPhysicsUpdate;

		private List<ISimPrePhysicsUpdate> partsPrePhysicsUpdate;

		private List<ISimPostPhysicsUpdate> partsPostPhysicsUpdate;

		private Stopwatch stopwatch;

		private long fixedDeltaTimeTicks;

		private long maxPhysicsLagTicks;

		private ClusterState[] lastClustersState;

		private ClusterState[] clustersState;

		private List<ClusterState> tempClusters;

		private int clusterStateCursor;

		public List<PartSim> parts { get; }

		public bool started { get; private set; }

		public float deltaTime { get; private set; }

		public float physicsDeltaTime { get; private set; }

		public float time { get; private set; }

		public int ticks { get; private set; }

		[AsyncStateMachine(typeof(_003CInit_003Ed__46))]
		public Task Init(Project project)
		{
			return null;
		}

		private void FixedUpdate()
		{
		}

		private void UpdateTransform()
		{
		}

		public void Clear()
		{
		}

		public void Freeze()
		{
		}

		public ProjectSimState GetState()
		{
			return default(ProjectSimState);
		}

		public void LoadState(ProjectSimState state)
		{
		}

		[AsyncStateMachine(typeof(_003CExplode_003Ed__55))]
		public Task Explode()
		{
			return null;
		}
	}
}
