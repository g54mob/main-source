using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.Tools;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.Combat
{
	public class CombatBehaviour : ScheduleOne.NPCs.Behaviour.Behaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass79_0
		{
			public CombatBehaviour _003C_003E4__this;

			public AvatarRangedWeapon rangedWeapon;

			public Func<bool> _003C_003E9__1;

			internal bool _003CRangedWeaponRoutine_003Eb__1()
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass79_1
		{
			public ERangedWeaponAction action;

			public int shots;
		}

		[CompilerGenerated]
		private sealed class _003CRangedWeaponRoutine_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CombatBehaviour _003C_003E4__this;

			private _003C_003Ec__DisplayClass79_0 _003C_003E8__1;

			private _003C_003Ec__DisplayClass79_1 _003C_003E8__2;

			private bool _003CforceReposition_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRangedWeaponRoutine_003Ed__79(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRepositionToRangedWeaponRange_003Ed__80 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CombatBehaviour _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRepositionToRangedWeaponRange_003Ed__80(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CSearchRoutine_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CombatBehaviour _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSearchRoutine_003Ed__93(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public const float RECENT_VISIBILITY_THRESHOLD = 3.5f;

		public const float REPOSITION_TIME = 4f;

		public const float SEARCH_RADIUS_MIN = 25f;

		public const float SEARCH_RADIUS_MAX = 60f;

		public const float SEARCH_SPEED = 0.4f;

		public const float CONSECUTIVE_MISS_ACCURACY_BOOST = 0.1f;

		public const float REACHED_DESTINATION_DISTANCE = 2f;

		public bool DEBUG;

		[Header("General Setttings")]
		public float GiveUpRange;

		public int GiveUpAfterSuccessfulHits;

		public bool PlayAngryVO;

		[Range(0f, 1f)]
		[Header("Movement settings")]
		public float DefaultMovementSpeed;

		[Header("Weapon settings")]
		public AvatarWeapon DefaultWeapon;

		public AvatarMeleeWeapon VirtualPunchWeapon;

		[Header("Search settings")]
		public float DefaultSearchTime;

		[Header("References")]
		public SmoothedVelocityCalculator TargetVelocityTracker;

		[Header("Debug settings")]
		public bool CombatOnStart;

		public NetworkObject DebugTarget;

		protected float timeSinceLastSighting;

		protected Vector3 lastKnownTargetPosition;

		private float timeSinceLastReposition;

		private float timeWithinAttackRange;

		private bool visionEventReceived;

		protected AvatarWeapon currentWeapon;

		protected int successfulHits;

		protected int consecutiveMissedShots;

		protected Coroutine rangedWeaponRoutine;

		protected Coroutine searchRoutine;

		protected Vector3 currentSearchDestination;

		protected bool hasSearchDestination;

		private float nextAngryVO;

		public Action onSuccessfulHit;

		private bool NetworkInitialize___EarlyScheduleOne_002ECombat_002ECombatBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ECombat_002ECombatBehaviourAssembly_002DCSharp_002Edll_Excuted;

		public ICombatTargetable Target { get; protected set; }

		public bool IsSearching { get; protected set; }

		public float TimeSinceTargetReacquired { get; protected set; }

		public bool IsTargetRecentlyVisible { get; private set; }

		public bool IsTargetImmediatelyVisible { get; private set; }

		public override void Awake()
		{
		}

		private void Start()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void SetTargetAndEnable_Server(NetworkObject target)
		{
		}

		[TargetRpc]
		[ObserversRpc(RunLocally = true)]
		protected void SetTarget_Client(NetworkConnection conn, NetworkObject target)
		{
		}

		protected virtual void SetTarget(NetworkObject target)
		{
		}

		public override void Activate()
		{
		}

		public override void Resume()
		{
		}

		public override void Pause()
		{
		}

		public override void Deactivate()
		{
		}

		public override void Disable()
		{
		}

		protected virtual void StartCombat()
		{
		}

		protected virtual void EndCombat()
		{
		}

		public override void BehaviourUpdate()
		{
		}

		protected void UpdateTimeout()
		{
		}

		protected virtual void UpdateLookAt()
		{
		}

		protected void SetMovementSpeed(float speed, string label = "combat", int priority = 5)
		{
		}

		private void EnsureRangedWeaponRoutineIsRunning()
		{
		}

		protected Vector3 GetPredictedFutureTargetPosition(float lead_Min = 0f, float lead_Max = 2f)
		{
			return default(Vector3);
		}

		protected override void SetDestination(Vector3 position, bool teleportIfFail = true, float successThreshold = 1f)
		{
		}

		[ObserversRpc(RunLocally = true)]
		protected virtual void SetWeapon(string weaponPath)
		{
		}

		protected virtual void OnCurrentWeaponChanged(AvatarWeapon weapon)
		{
		}

		[ObserversRpc(RunLocally = true)]
		protected void ClearWeapon()
		{
		}

		protected virtual bool ReadyToAttack(bool checkTarget = true)
		{
			return false;
		}

		private bool IsCurrentWeaponMelee()
		{
			return false;
		}

		[ObserversRpc(RunLocally = true)]
		protected virtual void Attack()
		{
		}

		protected void SucessfulHit()
		{
		}

		[IteratorStateMachine(typeof(_003CRangedWeaponRoutine_003Ed__79))]
		private IEnumerator RangedWeaponRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRepositionToRangedWeaponRange_003Ed__80))]
		private IEnumerator RepositionToRangedWeaponRange()
		{
			return null;
		}

		protected virtual float GetIdealRangedWeaponDistance()
		{
			return 0f;
		}

		private bool Shoot()
		{
			return false;
		}

		private void SetWeaponRaised(bool raised)
		{
		}

		protected void CheckTargetVisibility()
		{
		}

		public void MarkPlayerVisible()
		{
		}

		protected bool IsTargetVisibleThisFrame()
		{
			return false;
		}

		protected void ProcessVisionEvent(VisionEventReceipt visionEventReceipt)
		{
		}

		protected virtual void TargetSpotted()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void NotifyServerTargetSeen()
		{
		}

		protected virtual float GetSearchTime()
		{
			return 0f;
		}

		private void StartSearching()
		{
		}

		private void StopSearching()
		{
		}

		[IteratorStateMachine(typeof(_003CSearchRoutine_003Ed__93))]
		private IEnumerator SearchRoutine()
		{
			return null;
		}

		private Vector3 GetNextSearchLocation()
		{
			return default(Vector3);
		}

		protected virtual bool IsTargetValid()
		{
			return false;
		}

		private void RepositionToTargetMeleeRange(Vector3 origin)
		{
		}

		private bool GetRandomReachablePointNear(Vector3 originPoint, float randomRadius, out Vector3 randomPoint, float minDistance = 0f)
		{
			randomPoint = default(Vector3);
			return false;
		}

		protected float GetMinTargetDistance()
		{
			return 0f;
		}

		protected float GetMaxTargetDistance()
		{
			return 0f;
		}

		protected bool IsTargetInRange(Vector3 origin = default(Vector3))
		{
			return false;
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Server_SetTargetAndEnable_Server_3323014238(NetworkObject target)
		{
		}

		public void RpcLogic___SetTargetAndEnable_Server_3323014238(NetworkObject target)
		{
		}

		private void RpcReader___Server_SetTargetAndEnable_Server_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Observers_SetTarget_Client_1824087381(NetworkConnection conn, NetworkObject target)
		{
		}

		protected void RpcLogic___SetTarget_Client_1824087381(NetworkConnection conn, NetworkObject target)
		{
		}

		private void RpcReader___Observers_SetTarget_Client_1824087381(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_SetTarget_Client_1824087381(NetworkConnection conn, NetworkObject target)
		{
		}

		private void RpcReader___Target_SetTarget_Client_1824087381(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_SetWeapon_3615296227(string weaponPath)
		{
		}

		protected virtual void RpcLogic___SetWeapon_3615296227(string weaponPath)
		{
		}

		private void RpcReader___Observers_SetWeapon_3615296227(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_ClearWeapon_2166136261()
		{
		}

		protected void RpcLogic___ClearWeapon_2166136261()
		{
		}

		private void RpcReader___Observers_ClearWeapon_2166136261(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_Attack_2166136261()
		{
		}

		protected virtual void RpcLogic___Attack_2166136261()
		{
		}

		private void RpcReader___Observers_Attack_2166136261(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Server_NotifyServerTargetSeen_2166136261()
		{
		}

		public void RpcLogic___NotifyServerTargetSeen_2166136261()
		{
		}

		private void RpcReader___Server_NotifyServerTargetSeen_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002ECombat_002ECombatBehaviour_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
