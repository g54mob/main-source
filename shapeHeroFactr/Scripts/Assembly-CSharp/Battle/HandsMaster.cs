using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Battle
{
	public class HandsMaster : BaseEnemy
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSpawnHands_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public HandsMaster _003C_003E4__this;

			private AsyncInstantiateOperation<Hands> _003Chandler_003E5__2;

			private AsyncInstantiateOperation<Hands>.Awaiter _003C_003Eu__1;

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

		[SerializeField]
		private Hands handsPrefab;

		[SerializeField]
		[Label("グループ出現半径")]
		private float _groupRadius;

		private List<Hands> _handsGroup;

		private EnemyCluster _handCluster;

		private int _spawnCount;

		private EnemyBaseInfo _copyInfo;

		private Vector3 _initSpawnPosition;

		private bool _isEmitted;

		private readonly int defaultValue;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private Vector3 AdjustmentPosition(bool isLeader = false)
		{
			return default(Vector3);
		}

		[AsyncStateMachine(typeof(_003CSpawnHands_003Ed__12))]
		private void SpawnHands()
		{
		}

		public override void DestroyObj()
		{
		}

		protected override void AttackTown()
		{
		}
	}
}
