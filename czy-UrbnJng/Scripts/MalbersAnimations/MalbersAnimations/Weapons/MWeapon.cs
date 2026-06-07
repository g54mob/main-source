using System;
using MalbersAnimations.Controller;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MalbersAnimations.Weapons
{
	[SelectionBase]
	public abstract class MWeapon : MDamager, IMWeapon, IMDamager, IMLayer, IObjectCore
	{
		[SerializeField]
		protected Sprite m_UI;

		[SerializeField]
		protected StringReference description = new StringReference(string.Empty);

		public FloatReference chargeTime = new FloatReference(0f);

		[Tooltip("Value of Charge.. from zero to Max")]
		public FloatReference m_MaxCharge = new FloatReference(1f);

		[SerializeField]
		private float chargeCharMultiplier = 1f;

		public AnimationCurve ChargeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Tooltip("Use a Arm Pose when the weapon is equipped while Grounded. It will keep playing in loop an animation for an arm while the weapon is equipped")]
		public bool GroundArmPose = true;

		[Tooltip("Use a Arm Pose when the weapon is equipped while Riding. It will keep playing in loop an animation for an arm while the weapon is equipped")]
		public bool RidingArmPose = true;

		[Tooltip("Is the weapon using Combo while grounded?.  Leave empty to not use combos!")]
		public ModeID GroundCombo;

		[Tooltip("Is the weapon using Combo while Riding?. Leave empty to not use combos!")]
		public ModeID RidingCombo;

		[SerializeField]
		[RequiredField]
		private Transform m_AimOrigin;

		[SerializeField]
		private AimSide m_AimSide;

		[SerializeField]
		protected WeaponID weaponType;

		[Tooltip("Identifier for the Holster that the weapon will be stored")]
		[SerializeField]
		protected HolsterID holster;

		[SerializeField]
		protected HolsterID holsterAnim;

		[Min(0f)]
		[Tooltip("A holster can have multiple Transform to be parent to. This is the Index of the Transform Slots Array")]
		[SerializeField]
		protected int m_holsterIndex;

		public BoolReference rightHand = new BoolReference(value: true);

		[SerializeField]
		protected FloatReference m_rate = new FloatReference(0f);

		[SerializeField]
		protected BoolReference m_Automatic = new BoolReference(value: false);

		[Tooltip("Ignore Draw Animations for the weapon")]
		[SerializeField]
		protected BoolReference m_IgnoreDraw = new BoolReference(value: false);

		[Tooltip("Ignore Store Animations for the weapon")]
		[SerializeField]
		protected BoolReference m_IgnoreStore = new BoolReference(value: false);

		[Tooltip("Stance Used by the Animal Controller for the Weapon")]
		public StanceID stance;

		[SerializeField]
		[Tooltip("Enable Strafing while Aiming")]
		private BoolReference strafeOnAim = new BoolReference();

		[Tooltip("When using the weapon on foot it will Try activate the Strafe on the Animal")]
		public BoolReference strafeOnEquip = new BoolReference(value: false);

		[Tooltip("When the weapon is  unequipped enable or disable straffing")]
		public BoolReference strafeOnUnequip = new BoolReference(value: false);

		[ExposeScriptableAsset]
		[Tooltip("Aim IK Modification to the Character Body to Aim Properly when the Weapon is RightHanded")]
		public IKProfile AimIKRight;

		[ExposeScriptableAsset]
		[Tooltip("Aim IK Modification to the Character Body to Aim Properly when the Weapon is LeftHanded")]
		public IKProfile AimIKLeft;

		[Tooltip("IK Modification to the Character Body to Aim Properly")]
		public BoolReference TwoHandIK;

		[Tooltip("Position and Rotation Reference for the secondary Hand IK Goal (Left) ")]
		[FormerlySerializedAs("IKHandPoint")]
		public TransformReference IKHandLeft = new TransformReference();

		[Tooltip("Position and Rotation Reference for the secondary Hand IK  (Right)  ")]
		public TransformReference IKHandRight = new TransformReference();

		public TransformOffset HolsterOffset = new TransformOffset(1);

		public TransformOffset LeftHandOffset = new TransformOffset(1);

		public TransformOffset RightHandOffset = new TransformOffset(1);

		public AudioClip[] Sounds;

		private bool isEquiped;

		private bool isCharging;

		private bool isReloading;

		protected bool canAttack;

		private bool m_MainInput;

		protected bool isAiming;

		public TransformEvent OnEquiped = new TransformEvent();

		public TransformEvent OnUnequiped = new TransformEvent();

		public FloatEvent OnCharged = new FloatEvent();

		public UnityEvent OnMaxCharged = new UnityEvent();

		public FloatEvent OnChargedFinished = new FloatEvent();

		public BoolEvent OnAiming = new BoolEvent();

		public UnityEvent OnUseFreeHand = new UnityEvent();

		public UnityEvent OnReleaseFreeHand = new UnityEvent();

		[HideInInspector]
		public int Editor_Tabs1;

		[HideInInspector]
		public int Editor_Tabs2;

		public bool Automatic
		{
			get
			{
				return m_Automatic.Value;
			}
			set
			{
				m_Automatic.Value = value;
			}
		}

		public bool AttackFromAutomatic { get; set; }

		public virtual bool HasAmmo => false;

		public bool IgnoreDraw
		{
			get
			{
				return m_IgnoreDraw.Value;
			}
			set
			{
				m_IgnoreDraw.Value = value;
			}
		}

		public bool IgnoreStore
		{
			get
			{
				return m_IgnoreStore.Value;
			}
			set
			{
				m_IgnoreStore.Value = value;
			}
		}

		public int HolsterSlot
		{
			get
			{
				return m_holsterIndex;
			}
			set
			{
				m_holsterIndex = value;
			}
		}

		public virtual Transform AimOrigin
		{
			get
			{
				return m_AimOrigin;
			}
			set
			{
				m_AimOrigin = value;
			}
		}

		public Vector3 AimOriginPos => AimOrigin.position;

		public IKProfile AimIK
		{
			get
			{
				if (!rightHand)
				{
					return AimIKLeft;
				}
				return AimIKRight;
			}
		}

		public Transform IKHandPoint
		{
			get
			{
				if (!rightHand)
				{
					return IKHandRight.Value;
				}
				return IKHandLeft.Value;
			}
		}

		public virtual int WeaponID => index;

		public override int Index => weaponType.ID;

		public virtual bool CanUnequip => true;

		public virtual int HolsterID
		{
			get
			{
				if (!(Holster != null))
				{
					return 0;
				}
				return Holster.ID;
			}
		}

		public HolsterID Holster
		{
			get
			{
				return holster;
			}
			set
			{
				holster = value;
			}
		}

		public WeaponID WeaponType => weaponType;

		public WeaponID WeaponMode => WeaponType;

		public int HolsterAnim
		{
			get
			{
				if (!(holsterAnim != null))
				{
					return holster.ID;
				}
				return holsterAnim.ID;
			}
		}

		public Action<int> WeaponAction { get; set; } = delegate
		{
		};

		public virtual bool IsEquiped
		{
			get
			{
				return isEquiped;
			}
			set
			{
				isEquiped = value;
				Debugging($"Equiped [{value}]", this, "green");
				if (isEquiped && (bool)Owner)
				{
					OnEquiped.Invoke(Owner.transform);
					MaxCharged = false;
					IsAttacking = false;
				}
				else
				{
					OnUnequiped.Invoke(Owner ? Owner.transform : null);
					Owner = null;
					CurrentOwner = null;
					IsReloading = false;
				}
			}
		}

		public virtual bool IsCharging
		{
			get
			{
				return isCharging;
			}
			set
			{
				isCharging = value;
			}
		}

		public virtual bool IsRiding { get; set; }

		public virtual bool IsReloading
		{
			get
			{
				return isReloading;
			}
			set
			{
				isReloading = value;
			}
		}

		public virtual bool CanAttack
		{
			get
			{
				return canAttack;
			}
			set
			{
				canAttack = value;
				if (canAttack)
				{
					return;
				}
				if (Rate > 0f)
				{
					this.Delay_Action(Rate, delegate
					{
						canAttack = true;
					});
				}
				else
				{
					canAttack = true;
				}
			}
		}

		public virtual bool IsAttacking { get; set; }

		public virtual bool Input
		{
			get
			{
				return m_MainInput;
			}
			set
			{
				if (m_MainInput != value)
				{
					Debugging($"Input → [{value}]", this);
				}
				m_MainInput = value;
			}
		}

		public string Description
		{
			get
			{
				return description.Value;
			}
			set
			{
				description.Value = value;
			}
		}

		public virtual bool IsAiming
		{
			get
			{
				return isAiming;
			}
			set
			{
				isAiming = value;
				OnAiming.Invoke(isAiming);
			}
		}

		public AimSide AimSide
		{
			get
			{
				return m_AimSide;
			}
			set
			{
				m_AimSide = value;
			}
		}

		public virtual bool CanAim => false;

		public float MinDamage => statModifier.MinValue.Value;

		public float MaxDamage => statModifier.MaxValue.Value;

		public float ChargeTime
		{
			get
			{
				return chargeTime.Value;
			}
			set
			{
				chargeTime.Value = value;
			}
		}

		public float MaxCharge
		{
			get
			{
				return m_MaxCharge.Value;
			}
			set
			{
				m_MaxCharge.Value = value;
			}
		}

		public virtual bool CanCharge => ChargeTime > 0f;

		public bool MaxCharged { get; internal set; }

		public float ChargeCharMultiplier
		{
			get
			{
				return chargeCharMultiplier;
			}
			set
			{
				chargeCharMultiplier = value;
			}
		}

		public float ChargeCurrentTime { get; set; }

		public bool IsRightHanded => rightHand.Value;

		public bool IsLefttHanded => !IsRightHanded;

		public float Rate
		{
			get
			{
				return m_rate.Value;
			}
			set
			{
				m_rate.Value = value;
			}
		}

		public float ChargedNormalized
		{
			get
			{
				if (!CanCharge)
				{
					return UnityEngine.Random.Range(0f, 1f);
				}
				return ChargeCurve.Evaluate(Charging);
			}
		}

		public float Charging => Mathf.Clamp01(ChargeCurrentTime / ChargeTime);

		public float CurrentCharge { get; set; }

		public float Power => Mathf.Lerp(MinForce, MaxForce, ChargedNormalized);

		public override bool Enabled
		{
			get
			{
				return base.enabled;
			}
			set
			{
				BoolReference active = m_Active;
				bool value2 = (base.enabled = value);
				active.Value = value2;
				Debugging($"Active [{value}]", this);
				if (!value && IsEquiped)
				{
					WeaponAction(100);
				}
			}
		}

		public IMWeaponOwner CurrentOwner { get; set; }

		public bool StrafeOnAim
		{
			get
			{
				return strafeOnAim.Value;
			}
			set
			{
				strafeOnAim.Value = value;
			}
		}

		public bool StrafeOnEquip
		{
			get
			{
				return strafeOnEquip.Value;
			}
			set
			{
				strafeOnEquip.Value = value;
			}
		}

		public bool StrafeOnUnequip
		{
			get
			{
				return strafeOnUnequip.Value;
			}
			set
			{
				strafeOnUnequip.Value = value;
			}
		}

		public bool FreeHand { get; set; }

		public ICollectable IsCollectable { get; private set; }

		Transform IObjectCore.transform => base.transform;

		public virtual void CheckAim()
		{
			WeaponAction?.Invoke(IsAiming ? 97 : 100);
			IsAttacking = false;
		}

		public override bool Equals(object a)
		{
			if (a is IMWeapon)
			{
				return WeaponID == (a as IMWeapon).WeaponID;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		internal virtual void MainAttack_Start(IMWeaponOwner RC)
		{
			Input = true;
			ResetCharge();
		}

		internal abstract void Attack_Charge(IMWeaponOwner RC, float time);

		internal virtual void MainAttack_Released(IMWeaponOwner RC)
		{
			Input = false;
			ResetCharge();
		}

		internal virtual void SecondAttack_Released(IMWeaponOwner RC)
		{
			Input = false;
			ResetCharge();
		}

		public void Unequip()
		{
			CurrentOwner?.UnEquip();
		}

		internal virtual void Reload(IMWeaponOwner RC)
		{
		}

		internal virtual void Weapon_LateUpdate(IMWeaponOwner RC)
		{
		}

		public virtual bool TryReload()
		{
			return false;
		}

		public virtual bool Equip(IMWeaponOwner _char)
		{
			if (base.gameObject.IsPrefab())
			{
				return false;
			}
			if (!Enabled)
			{
				Debugging("The weapon is Disable. It cannot be equipped", this);
				return false;
			}
			CurrentOwner = _char;
			Owner = CurrentOwner.Owner;
			IsEquiped = true;
			CanAttack = true;
			ChargeCurrentTime = 0f;
			IgnoreTransform = _char.IgnoreTransform;
			base.gameObject.SetActive(value: true);
			animator = _char.Anim;
			DisablePhysics();
			Debugging("Weapon [Prepared]", this);
			return true;
		}

		public virtual void ActivateDamager(int value, int prof)
		{
			DoDamage(value: true, prof);
		}

		public virtual void Charge(float time)
		{
			if (CanCharge)
			{
				ChargeCurrentTime += time;
				IsCharging = true;
				CurrentCharge = MaxCharge * ChargeCurve.Evaluate(Charging);
				if (Charging == 1f && !MaxCharged)
				{
					MaxCharged = true;
					OnMaxCharged.Invoke();
				}
				OnCharged.Invoke(CurrentCharge);
			}
			else
			{
				ReleaseCharge();
			}
		}

		public virtual void FreeHandRelease()
		{
			OnReleaseFreeHand.Invoke();
			FreeHand = true;
		}

		public virtual void FreeHandUse()
		{
			OnUseFreeHand.Invoke();
			FreeHand = false;
		}

		public virtual void ResetCharge()
		{
			if (CanCharge)
			{
				ChargeCurrentTime = 0f;
				IsCharging = false;
				CurrentCharge = 0f;
				OnCharged.Invoke(0f);
				MaxCharged = false;
				Debugging("Weapon [Charge Reseted]", this);
			}
		}

		public virtual void ReleaseCharge()
		{
			Debug.Log("RELEASE CHARGE");
			WeaponAction(101);
			ResetCharge();
		}

		public virtual void ResetWeapon()
		{
			Owner = null;
			CurrentOwner = null;
			IsEquiped = false;
			IsAiming = false;
			animator = null;
			IgnoreTransform = null;
			ResetCharge();
			Debugging("Weapon [Reseted]", this);
		}

		public virtual void Initialize()
		{
			isEquiped = false;
			if (Owner == null)
			{
				Owner = base.transform.root.gameObject;
			}
			CheckAudioSource();
			IsCollectable = GetComponent<ICollectable>();
			if (holsterAnim == null)
			{
				holsterAnim = holster;
			}
			SetDefaultProfile();
		}

		public virtual void ApplyOffset()
		{
			if (IsRightHanded)
			{
				RightHandOffset.SetOffset(base.transform);
			}
			else
			{
				LeftHandOffset.SetOffset(base.transform);
			}
		}

		public void DisablePhysics()
		{
			IsCollectable?.OnPickDisablePhysics();
		}

		public virtual void PlaySound(int ID)
		{
			if (ID < Sounds.Length && Sounds[ID] != null)
			{
				AudioClip newSound = Sounds[ID];
				PlaySound(newSound);
			}
		}

		internal virtual void StoringWeapon()
		{
		}

		[ContextMenu("Set Hand Offset Values")]
		private void CopyTransformToOffsets()
		{
			if (IsRightHanded)
			{
				RightHandOffset = new TransformOffset(base.transform);
			}
			else
			{
				LeftHandOffset = new TransformOffset(base.transform);
			}
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}
	}
}
