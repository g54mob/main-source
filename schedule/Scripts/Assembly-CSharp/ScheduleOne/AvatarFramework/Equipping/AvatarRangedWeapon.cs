using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping
{
	public class AvatarRangedWeapon : AvatarWeapon
	{
		[CompilerGenerated]
		private sealed class _003CReload_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AvatarRangedWeapon _003C_003E4__this;

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
			public _003CReload_003Ed__37(int _003C_003E1__state)
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

		[Header("Weapon Settings")]
		public int MagazineSize;

		public float ReloadTime;

		public float MaxFireRate;

		public float EquipTime;

		public float RaiseTime;

		public float Damage;

		public float ImpactForce;

		public bool CanShootWhileMoving;

		public int MaxMovingShotsBeforeReposition;

		public int MaxStationaryShotsBeforeReposition;

		public bool RepositionAfterHit;

		[Header("Accuracy")]
		public float HitChance_MinRange;

		public float HitChance_MaxRange;

		[Header("Aiming")]
		public float AimTime_Min;

		public float AimTime_Max;

		[Header("References")]
		public Transform MuzzlePoint;

		public AudioSourceController FireSound;

		[Header("Animation Settings")]
		public string LoweredAnimationTrigger;

		public string RaisedAnimationTrigger;

		public string RecoilAnimationTrigger;

		private bool isReloading;

		private float timeEquipped;

		private float timeRaised;

		private float timeSinceLastShot;

		private int currentAmmo;

		public bool IsRaised { get; protected set; }

		public override void Equip(Avatar _avatar)
		{
		}

		public override void Unequip()
		{
		}

		public virtual void SetIsRaised(bool raised)
		{
		}

		private void Update()
		{
		}

		public override void ReceiveMessage(string message, object data)
		{
		}

		public bool CanShoot()
		{
			return false;
		}

		protected virtual void Shoot(Vector3 endPoint)
		{
		}

		public virtual void ApplyHitToDamageable(IDamageable damageable, Vector3 hitPoint)
		{
		}

		[IteratorStateMachine(typeof(_003CReload_003Ed__37))]
		private IEnumerator Reload()
		{
			return null;
		}

		public bool IsTargetInLoS(ICombatTargetable target)
		{
			return false;
		}

		public virtual float GetIdealUseRange()
		{
			return 0f;
		}
	}
}
