using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs
{
	[DisallowMultipleComponent]
	public class NPCHealth : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAfflictWithLethalEffect_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCHealth _003C_003E4__this;

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
			public _003CAfflictWithLethalEffect_003Ed__38(int _003C_003E1__state)
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

		public const int REVIVE_DAYS = 3;

		[Header("Settings")]
		public bool Invincible;

		public float MaxHealth;

		public bool CanRevive;

		private NPC npc;

		public UnityEvent onDie;

		public UnityEvent onKnockedOut;

		public UnityEvent onDieOrKnockedOut;

		public UnityEvent onRevive;

		public Action<float> onTakeDamage;

		private bool AfflictedWithLethalEffect;

		public SyncVar<float> syncVar____003CHealth_003Ek__BackingField;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCHealthAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCHealthAssembly_002DCSharp_002Edll_Excuted;

		public float Health
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public float NormalizedHealth => 0f;

		public bool IsDead { get; private set; }

		public bool IsKnockedOut { get; private set; }

		public int DaysPassedSinceDeath { get; private set; }

		public int HoursSinceAttackedByPlayer { get; private set; }

		public float SyncAccessor__003CHealth_003Ek__BackingField
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public override void OnStartServer()
		{
		}

		public void Load(NPCHealthData healthData)
		{
		}

		[IteratorStateMachine(typeof(_003CAfflictWithLethalEffect_003Ed__38))]
		private IEnumerator AfflictWithLethalEffect()
		{
			return null;
		}

		protected virtual void OnHourPass()
		{
		}

		public void SetAfflictedWithLethalEffect(bool value)
		{
		}

		public void SleepStart()
		{
		}

		public virtual void NotifyAttackedByPlayer(Player player)
		{
		}

		public void TakeDamage(float damage, bool isLethal = true)
		{
		}

		public virtual void Die()
		{
		}

		public virtual void KnockOut()
		{
		}

		public virtual void Revive()
		{
		}

		public void RestoreHealth()
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		public virtual bool ReadSyncVar___ScheduleOne_002ENPCs_002ENPCHealth(PooledReader PooledReader0, uint UInt321, bool Boolean2)
		{
			return false;
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCHealth_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
