using System;
using System.Collections;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Weapons
{
	[AddComponentMenu("Malbers/Weapons/Shootable")]
	public class MShootable : MWeapon, IShootableWeapon, IMWeapon, IMDamager, IMLayer, IObjectCore, IThrower
	{
		public enum Release_Projectile
		{
			Never = 0,
			OnAttackStart = 1,
			OnAttackReleased = 2
		}

		public enum Equip_Projectile
		{
			ByAnimation = 1,
			OnAim = 2,
			OnAttackStart = 4,
			OnAttackReleased = 8,
			AfterReload = 0x10,
			OnProjectileReleased = 0x20,
			OnEquip = 0x40
		}

		public enum AimingAction
		{
			Manual = 0,
			Automatic = 1,
			Ignore = 2
		}

		[Tooltip("When the projectile will be released")]
		public Release_Projectile releaseProjectile = Release_Projectile.OnAttackStart;

		[Flag]
		[Tooltip("When the projectile will be released")]
		public Equip_Projectile equipProjectile = (Equip_Projectile)3;

		[Tooltip("How the weapon will handle aiming")]
		public AimingAction aimAction;

		[Tooltip("Delay to release the projectile after the Attack is Played. E.g. the Trhow animation is played but the projectile will be released a seconds after")]
		public FloatReference releaseDelay = new FloatReference();

		[Tooltip("The projectile will be released by the Animator using Weapon message behavior")]
		public BoolReference releaseByAnimation = new BoolReference(value: false);

		[Tooltip("Projectile prefab the weapon fires")]
		public GameObjectReference m_Projectile = new GameObjectReference();

		[Tooltip("Parent of the Projectile")]
		public Transform m_ProjectileParent;

		public Vector3Reference gravity = new Vector3Reference(Physics.gravity);

		public BoolReference UseAimAngle = new BoolReference(value: false);

		[Tooltip("Does the weapon has Fire Animation? if not then does not require to exit Aim Animation")]
		public BoolReference HasFireAnim = new BoolReference(value: true);

		public FloatReference m_AimAngle = new FloatReference(0f);

		[MinMaxRange(-180f, 180f)]
		[Tooltip("Value to limit firing projectiles when the Character is on weird or dificult Positions. E.g. Firing Arrows on impossible angles")]
		public RangedFloat AimLimit = new RangedFloat(-180f, 180f);

		[Tooltip("Ignore Completely the Reload Logic")]
		public BoolReference noReload = new BoolReference(value: false);

		public IntReference m_Ammo = new IntReference(30);

		public IntReference m_AmmoInChamber = new IntReference(1);

		public IntReference m_ChamberSize = new IntReference(1);

		[Tooltip("Time needed to complete the reload of a weapon. Put a new projectile(s) the chamber ")]
		public FloatReference m_ReloadTime = new FloatReference(1.5f);

		[Tooltip("The weapon will Reload the weapon right after the last projectile of the chamber has been released")]
		public BoolReference m_AutoReload = new BoolReference(value: false);

		[Tooltip("Delay time to auto-Reload right after the weapon has no ammo in chamber and the last projectile has been released")]
		public FloatReference m_AutoReloadTime = new FloatReference(0.25f);

		[Tooltip("If the Weapon have reload animation then Play it")]
		public BoolReference HasReloadAnim = new BoolReference(value: false);

		public GameObjectEvent OnLoadProjectile = new GameObjectEvent();

		public GameObjectEvent OnFireProjectile = new GameObjectEvent();

		public UnityEvent OnReloadStart = new UnityEvent();

		public UnityEvent OnReload = new UnityEvent();

		private IEnumerator iCanAttack;

		private IEnumerator iReleaseDelay;

		[Tooltip("The Shootable can be stored if is aiming. ")]
		public BoolReference m_UnequipOnAim = new BoolReference(value: false);

		[SerializeField]
		[Tooltip("Apply Gravity after certain distance is reached")]
		private FloatReference m_AfterDistance = new FloatReference(0f);

		public override bool CanCharge
		{
			get
			{
				if (releaseProjectile == Release_Projectile.OnAttackReleased)
				{
					return base.ChargeTime > 0f;
				}
				return false;
			}
		}

		public override bool CanUnequip
		{
			get
			{
				if (IsAiming)
				{
					return UnequipOnAim;
				}
				return true;
			}
		}

		public override bool CanAttack
		{
			get
			{
				return canAttack;
			}
			set
			{
				if (base.Rate <= 0f)
				{
					canAttack = true;
					return;
				}
				canAttack = value;
				if (canAttack)
				{
					return;
				}
				this.Stop_Action(iCanAttack);
				iCanAttack = this.Delay_Action(base.Rate, delegate
				{
					CanAttack = true;
					if (!IsReloading && !InAutoReloadTime)
					{
						CheckAim();
					}
				});
			}
		}

		public virtual GameObject Projectile
		{
			get
			{
				return m_Projectile.Value;
			}
			set
			{
				m_Projectile.Value = value;
			}
		}

		public virtual float AutoReloadTime
		{
			get
			{
				return m_AutoReloadTime.Value;
			}
			set
			{
				m_AutoReloadTime.Value = value;
			}
		}

		public virtual float ReleaseDelay
		{
			get
			{
				return releaseDelay.Value;
			}
			set
			{
				releaseDelay.Value = value;
			}
		}

		public virtual bool ReleaseByAnimation
		{
			get
			{
				return releaseByAnimation.Value;
			}
			set
			{
				releaseByAnimation.Value = value;
			}
		}

		public virtual bool NoReload
		{
			get
			{
				return noReload.Value;
			}
			set
			{
				noReload.Value = value;
			}
		}

		public virtual bool HasReload => !NoReload;

		public virtual bool InAutoReloadTime { get; protected set; }

		public virtual GameObject ProjectileInstance { get; set; }

		public virtual bool ProjectileEquipped => ProjectileInstance != null;

		public MProjectile MProjectile { get; set; }

		public Transform ProjectileParent => m_ProjectileParent;

		public Vector3 Gravity
		{
			get
			{
				return gravity.Value;
			}
			set
			{
				gravity.Value = value;
			}
		}

		public float AimAngle
		{
			get
			{
				return m_AimAngle.Value;
			}
			set
			{
				m_AimAngle.Value = value;
			}
		}

		public Vector3 Velocity { get; set; }

		public Action<bool> Predict { get; set; }

		public int TotalAmmo
		{
			get
			{
				return m_Ammo.Value;
			}
			set
			{
				m_Ammo.Value = value;
			}
		}

		public int AmmoInChamber
		{
			get
			{
				return m_AmmoInChamber.Value;
			}
			set
			{
				m_AmmoInChamber.Value = value;
			}
		}

		public bool AutoReload
		{
			get
			{
				return m_AutoReload.Value;
			}
			set
			{
				m_AutoReload.Value = value;
			}
		}

		public int ChamberSize
		{
			get
			{
				return m_ChamberSize.Value;
			}
			set
			{
				m_ChamberSize.Value = value;
			}
		}

		public override bool HasAmmo
		{
			get
			{
				if (TotalAmmo != -1 && AmmoInChamber <= 0)
				{
					return NoReload;
				}
				return true;
			}
		}

		public float AimWeight { get; private set; }

		public bool CanShootWithAimLimit { get; private set; }

		public bool UnequipOnAim
		{
			get
			{
				return m_UnequipOnAim.Value;
			}
			set
			{
				m_UnequipOnAim.Value = value;
			}
		}

		public override bool IsEquiped
		{
			get
			{
				return base.IsEquiped;
			}
			set
			{
				base.IsEquiped = value;
				if (value)
				{
					if ((equipProjectile & Equip_Projectile.OnEquip) == Equip_Projectile.OnEquip)
					{
						EquipProjectile();
					}
					if (AutoReload)
					{
						TryReload();
					}
				}
				else
				{
					DestroyProjectileInstance();
				}
			}
		}

		public override bool IsAiming
		{
			set
			{
				base.IsAiming = value;
				if (value && (equipProjectile & Equip_Projectile.OnAim) == Equip_Projectile.OnAim)
				{
					EquipProjectile();
				}
			}
		}

		public float AfterDistance
		{
			get
			{
				return m_AfterDistance.Value;
			}
			set
			{
				m_AfterDistance.Value = value;
			}
		}

		public override bool CanAim => true;

		Transform IObjectCore.transform => base.transform;

		private void Awake()
		{
			Initialize();
			if (AimOrigin == null)
			{
				AimOrigin = base.transform;
			}
			if (ChamberSize < 0)
			{
				ChamberSize = 1;
			}
			if (ReleaseDelay < 0f)
			{
				releaseDelay = 0f;
			}
		}

		internal override void MainAttack_Start(IMWeaponOwner RC)
		{
			Input = true;
			base.MainAttack_Start(RC);
			if (IsReloading || RC.StoreWeapon)
			{
				return;
			}
			CanShootWithAimLimit = AimLimit.IsInRange(RC.HorizontalAngle);
			if (!RC.Aim && aimAction == AimingAction.Automatic)
			{
				RC.Aim_Set(value: true);
			}
			if ((aimAction != AimingAction.Ignore && !IsAiming) || !CanShootWithAimLimit || !CanAttack)
			{
				return;
			}
			if (HasAmmo)
			{
				if ((equipProjectile & Equip_Projectile.OnAttackStart) == Equip_Projectile.OnAttackStart)
				{
					EquipProjectile();
				}
				if (releaseProjectile == Release_Projectile.OnAttackStart)
				{
					Debugging("<color=white> Weapon <b>[Fire Projectile] On Start </b></color>", this);
					FireAnim_ReleaseProjectile();
				}
			}
			else
			{
				PlaySound(WSound.Empty);
				Debugging("<color=red> <b>[Empty Ammo]</b> </color>", this);
			}
		}

		internal override void MainAttack_Released(IMWeaponOwner RC)
		{
			Input = false;
			Debugging("Main Attack Released", this);
			base.AttackFromAutomatic = false;
			if ((aimAction == AimingAction.Ignore || IsAiming) && CanShootWithAimLimit && CanAttack && releaseProjectile == Release_Projectile.OnAttackReleased && HasAmmo)
			{
				if ((equipProjectile & Equip_Projectile.OnAttackReleased) == Equip_Projectile.OnAttackReleased)
				{
					EquipProjectile();
				}
				FireAnim_ReleaseProjectile();
			}
		}

		private void FireAnim_ReleaseProjectile()
		{
			if (HasFireAnim.Value)
			{
				base.WeaponAction?.Invoke(101);
			}
			if (!ReleaseByAnimation)
			{
				this.Delay_Action(ref iReleaseDelay, ReleaseDelay, delegate
				{
					ReleaseProjectile();
				});
			}
			CanAttack = false;
			IsAttacking = true;
		}

		internal override void Attack_Charge(IMWeaponOwner RC, float time)
		{
			if (!Input || !CanAttack || IsAttacking || (aimAction == AimingAction.Manual && !IsAiming))
			{
				return;
			}
			if (HasAmmo && CanCharge)
			{
				if (!CanShootWithAimLimit)
				{
					ResetCharge();
					return;
				}
				if (!IsCharging)
				{
					IsCharging = true;
					base.ChargeCurrentTime = 0f;
					Predict?.Invoke(obj: true);
					PlaySound(WSound.Charge);
					Debugging("[Charge: 0]", this);
				}
				else if (!IsAttacking)
				{
					Charge(time);
				}
			}
			if (!base.Automatic || !(base.Rate > 0f) || IsReloading || !HasAmmo)
			{
				return;
			}
			if (releaseProjectile == Release_Projectile.OnAttackStart)
			{
				Debugging("[**Automatic Fire** Attack Start]", this);
				base.ChargeCurrentTime = base.ChargeTime;
				MainAttack_Start(RC);
			}
			else
			{
				if (releaseProjectile != Release_Projectile.OnAttackReleased || !base.MaxCharged)
				{
					return;
				}
				Debugging("[**Automatic Fire** Attack Released]", this);
				if (HasAmmo)
				{
					if ((equipProjectile & Equip_Projectile.OnAttackReleased) == Equip_Projectile.OnAttackReleased)
					{
						EquipProjectile();
					}
					FireAnim_ReleaseProjectile();
				}
				Input = true;
			}
		}

		public virtual void ReduceAmmo(int amount)
		{
			AmmoInChamber -= amount;
			Debugging($"[Ammo: Reduced <b>-({amount})</b> ,Total<b>({TotalAmmo})</b>, In Chamber<b>({AmmoInChamber})</b>]", this);
			if (AmmoInChamber <= 0 && AutoReload)
			{
				if (!HasReloadAnim)
				{
					IsReloading = true;
				}
				InAutoReloadTime = true;
				this.Delay_Action(AutoReloadTime, delegate
				{
					TryReload();
					InAutoReloadTime = false;
				});
			}
		}

		internal override void Weapon_LateUpdate(IMWeaponOwner RC)
		{
			CanShootWithAimLimit = AimLimit.IsInRange(RC.HorizontalAngle);
		}

		public override void ResetCharge()
		{
			base.ResetCharge();
			Predict?.Invoke(obj: false);
			Velocity = Vector3.zero;
		}

		public override void Charge(float time)
		{
			if (releaseProjectile != Release_Projectile.OnAttackStart)
			{
				if (!base.MaxCharged)
				{
					base.Charge(time);
				}
				CalculateVelocity();
				Predict?.Invoke(obj: true);
			}
		}

		public virtual void EquipProjectile()
		{
			if (!HasAmmo)
			{
				return;
			}
			if (ProjectileInstance == null)
			{
				Vector3 position = (ProjectileParent ? ProjectileParent.position : base.AimOriginPos);
				Quaternion rotation = (ProjectileParent ? ProjectileParent.rotation : AimOrigin.rotation);
				if (Projectile.IsPrefab())
				{
					ProjectileInstance = UnityEngine.Object.Instantiate(Projectile, position, rotation, ProjectileParent);
				}
				else
				{
					ProjectileInstance = Projectile;
				}
				if (ProjectileInstance.TryGetComponent<MProjectile>(out var component))
				{
					MProjectile = component;
					ProjectileInstance.transform.Translate(MProjectile.PosOffset, Space.Self);
					ProjectileInstance.transform.Rotate(MProjectile.RotOffset, Space.Self);
					if (MProjectile.hitEffects == null || MProjectile.hitEffects.Count == 0)
					{
						MProjectile.hitEffects = hitEffects;
					}
					if (MProjectile.HitEffect == null)
					{
						MProjectile.HitEffect = base.HitEffect;
					}
					if (MProjectile.hitSound == null || MProjectile.hitSound.Value == null)
					{
						MProjectile.hitSound = hitSound;
					}
				}
				if (ProjectileInstance.TryGetComponent<Rigidbody>(out var component2))
				{
					component2.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
					component2.isKinematic = true;
				}
				if (ProjectileInstance.TryGetComponent<Collider>(out var component3))
				{
					component3.enabled = false;
				}
				OnLoadProjectile.Invoke(ProjectileInstance);
				Debugging("◘ [Projectile Equiped] [" + ProjectileInstance.name + "] ", ProjectileInstance);
			}
			else
			{
				Debugging("◘ [Projectile Already Equipped] Skip", ProjectileInstance, "gray");
			}
		}

		public virtual void SetProjectile(GameObject projectile)
		{
			Projectile = projectile;
		}

		public virtual void Fire()
		{
			ReleaseProjectile();
		}

		public virtual void ReleaseProjectile()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			Predict?.Invoke(obj: false);
			if (releaseProjectile == Release_Projectile.Never)
			{
				DestroyProjectileInstance();
				return;
			}
			if ((equipProjectile & Equip_Projectile.OnProjectileReleased) == Equip_Projectile.OnProjectileReleased)
			{
				EquipProjectile();
			}
			FireProjectile();
			if (HasReload)
			{
				this.Delay_Action(delegate
				{
					ReduceAmmo(1);
				});
			}
		}

		public void FireProjectile()
		{
			if (ProjectileInstance == null)
			{
				return;
			}
			ProjectileInstance.transform.parent = null;
			if (MProjectile != null)
			{
				ProjectileInstance.transform.position = AimOrigin.position;
				CalculateVelocity();
				ProjectileInstance.transform.forward = Velocity.normalized;
				ProjectileInstance.transform.Translate(MProjectile.PosOffset, Space.Self);
				MProjectile.Prepare(Owner, Gravity, Velocity, base.Layer, base.TriggerInteraction);
				MProjectile.AfterDistance = AfterDistance;
				if (base.HitEffect != null)
				{
					MProjectile.HitEffect = base.HitEffect;
				}
				StatModifier statModifier = new StatModifier(base.statModifier)
				{
					Value = Mathf.Lerp(base.MinDamage, base.MaxDamage, base.ChargedNormalized)
				};
				MProjectile.PrepareDamage(statModifier, base.CriticalChance, base.CriticalMultiplier, element);
				Debugging("◘ [Projectile Released] [" + ProjectileInstance.name + "]", ProjectileInstance);
				MProjectile.Fire();
			}
			OnFireProjectile.Invoke(ProjectileInstance);
			ProjectileInstance = null;
			MProjectile = null;
			PlaySound(WSound.Fire);
			ResetCharge();
		}

		private void CalculateVelocity()
		{
			Vector3 normalized = (base.CurrentOwner.Aimer.AimPoint - AimOrigin.position).normalized;
			if (UseAimAngle.Value)
			{
				Vector3 axis = Vector3.Cross(normalized, -Gravity);
				Velocity = Quaternion.AngleAxis(AimAngle, axis) * normalized * base.Power;
			}
			else
			{
				Velocity = normalized * base.Power;
			}
		}

		public virtual void DestroyProjectileInstance()
		{
			if (ProjectileInstance != null && ProjectileInstance != base.gameObject)
			{
				UnityEngine.Object.Destroy(ProjectileInstance);
				Debugging("[Destroy Projectile Instance]", this);
			}
			ProjectileInstance = null;
			MProjectile = null;
		}

		public override bool TryReload()
		{
			if (!HasReload)
			{
				return false;
			}
			if (TotalAmmo == 0)
			{
				return false;
			}
			if (ChamberSize == AmmoInChamber)
			{
				return false;
			}
			if (HasReloadAnim.Value)
			{
				if (CanReload())
				{
					PlaySound(WSound.Reload);
					base.WeaponAction(96);
					IsReloading = true;
					OnReloadStart.Invoke();
					this.Delay_Action(m_ReloadTime.Value, delegate
					{
						ReloadWeapon();
					});
					IsAttacking = false;
					return true;
				}
				base.WeaponAction(100);
				PlaySound(WSound.Empty);
				ReloadWeapon();
				return false;
			}
			if (aimAction == AimingAction.Automatic)
			{
				base.WeaponAction(97);
			}
			else
			{
				base.WeaponAction(100);
			}
			return ReloadWeapon();
		}

		public bool CanReload()
		{
			if (TotalAmmo == 0)
			{
				Debugging("X Cannot Reload. Total Ammo == 0", this);
				return false;
			}
			if (ChamberSize == AmmoInChamber)
			{
				Debugging("X Cannot Reload. Chamber is Full. No need to Reload", this);
				return false;
			}
			if (TotalAmmo == -1)
			{
				Debugging("Can Reload Infinite ammo.", this);
				return true;
			}
			int num = Mathf.Clamp(ChamberSize - AmmoInChamber, 0, TotalAmmo);
			int num2 = TotalAmmo - num;
			if (num2 >= 0)
			{
				Debugging("Can Reload", this);
				return true;
			}
			Debugging($"X Cannot Reload. AmmoLeft = {num2}", this);
			return false;
		}

		public bool ReloadWeapon()
		{
			if (HasReload)
			{
				int reloadAmount = ChamberSize - AmmoInChamber;
				if (ReloadLogic(reloadAmount))
				{
					FinishReload();
					return true;
				}
			}
			return false;
		}

		public bool ReloadLogic(int ReloadAmount)
		{
			if (TotalAmmo == -1)
			{
				AmmoInChamber = ChamberSize;
				OnReload.Invoke();
				return true;
			}
			if (TotalAmmo == 0 || ChamberSize == AmmoInChamber)
			{
				Debugging("[Cannot Reload no more ammo left]", this);
				return false;
			}
			ReloadAmount = Mathf.Clamp(ReloadAmount, 0, ChamberSize - AmmoInChamber);
			if (TotalAmmo - ReloadAmount >= 0)
			{
				AmmoInChamber += ReloadAmount;
				TotalAmmo -= ReloadAmount;
			}
			else
			{
				AmmoInChamber += TotalAmmo;
				TotalAmmo = 0;
			}
			Debugging($"[Reloading Ammo!: <B>[{ReloadAmount}]]</B>", this);
			OnReload.Invoke();
			return true;
		}

		public virtual void FinishReload()
		{
			if (IsEquiped && !base.CurrentOwner.DrawWeapon && !base.CurrentOwner.StoreWeapon)
			{
				IsReloading = false;
				if (aimAction == AimingAction.Automatic && base.CurrentOwner.Aim)
				{
					base.WeaponAction?.Invoke(97);
				}
				else
				{
					CheckAim();
				}
				if ((equipProjectile & Equip_Projectile.AfterReload) == Equip_Projectile.AfterReload)
				{
					EquipProjectile();
				}
				Debugging("[Finish Reload]", this);
			}
		}
	}
}
