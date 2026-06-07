using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyCrab : EnemyController
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSpawnPincers_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public EnemyCrab _003C_003E4__this;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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
		private GameObject _RedWarningPrefab;

		[SerializeField]
		private GameObject _SingleWarningPrefab;

		private Stage _stage;

		protected EnemyPincer _leftPincer;

		protected EnemyPincer _rightPincer;

		private EnemyDrowner _drowner;

		protected Timer _leftEvent;

		protected Timer _rightEvent;

		private bool _isPlayerBelow;

		private bool _drownerSummoned;

		private bool _freshlySpawned;

		private Vector2 _leftPincerPos;

		private Vector2 _rightPincerPos;

		private readonly Vector2 _leftOffset;

		private readonly Vector2 _rightOffset;

		private const float PincerRespawnDelayLeft = 1500f;

		private const float PincerRespawnDelayRight = 1500f;

		private const float SummonDelay = 6000f;

		private Timer _summonDelayTimer;

		private Timer _drownerWarningTimer1;

		private Timer _drownerWarningTimer2;

		private Timer _drownerWarningTimer3;

		protected override void FakeConstruct()
		{
		}

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override bool CanEnemyTeleport()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CSpawnPincers_003Ed__28))]
		private UniTaskVoid SpawnPincers()
		{
			return default(UniTaskVoid);
		}

		private void SpawnLeftPincer()
		{
		}

		private void SpawnRightPincer()
		{
		}

		protected virtual void RegrowLeftPincer()
		{
		}

		protected virtual void RegrowRightPincer()
		{
		}

		protected virtual void SummonDrowner()
		{
		}

		private void DismissDrowner()
		{
		}

		private void DrownerWarning()
		{
		}

		private void RedWarning()
		{
		}

		private void SingleWarning(float sizeX)
		{
		}
	}
}
