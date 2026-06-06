using System;
using MalbersAnimations.Events;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	[AddComponentMenu("Malbers/Weapons/Melee Weapon")]
	public class MMelee : MWeapon
	{
		[RequiredField]
		public Collider meleeTrigger;

		[Tooltip("Do not interact with Static Objects")]
		public bool ignoreStaticObjects = true;

		public BoolEvent OnCauseDamage = new BoolEvent();

		public Color DebugColor = new Color(1f, 0.25f, 0f, 0.5f);

		public bool UseCameraSide;

		public bool InvertCameraSide;

		[Tooltip("What Abilities to apply to the meleee weapons if they are not using any Combo")]
		public int[] GroundAttackAbilities;

		[Tooltip("What Abilities to apply to the meleee weapons if they are not using any Combo")]
		public int[] RidingAttackAbilities;

		protected bool canCauseDamage;

		public override bool CanCauseDamage
		{
			get
			{
				return canCauseDamage;
			}
			set
			{
				Debugging($"Can cause Damage [{value}]", this);
				canCauseDamage = value;
				if ((bool)Proxy)
				{
					Proxy.Active = value;
				}
				meleeTrigger.enabled = value;
				if (CanCauseDamage && AttackDirection)
				{
					if (C_Direction != null)
					{
						StopCoroutine(C_Direction);
						C_Direction = null;
					}
					StartCoroutine(C_Direction = I_CalculateDirection(meleeTrigger));
				}
			}
		}

		protected TriggerProxy Proxy { get; private set; }

		public override void ActivateDamager(int value, int profile)
		{
			switch (value)
			{
			case 0:
				CanCauseDamage = false;
				OnCauseDamage.Invoke(CanCauseDamage);
				if (CurrentProfileIndex != 0)
				{
					DefaultProfile.Modify(this);
					CurrentProfileIndex = 0;
					OnProfileChanged.Invoke(CurrentProfileIndex);
					Debugging("Setting Default Profile", this);
				}
				break;
			default:
				if (value != Index)
				{
					break;
				}
				goto case -1;
			case -1:
				base.ActivateDamager(value, profile);
				CanCauseDamage = true;
				OnCauseDamage.Invoke(CanCauseDamage);
				break;
			}
		}

		private void Awake()
		{
			if ((bool)animator)
			{
				defaultAnimatorSpeed = animator.speed;
			}
			Initialize();
			CanCauseDamage = false;
		}

		public override void Initialize()
		{
			base.Initialize();
			FindTrigger();
		}

		private void OnEnable()
		{
			if ((bool)Proxy)
			{
				TriggerProxy proxy = Proxy;
				proxy.EnterTriggerInteraction = (Action<GameObject, Collider>)Delegate.Combine(proxy.EnterTriggerInteraction, new Action<GameObject, Collider>(AttackTriggerEnter));
			}
		}

		private void OnDisable()
		{
			if (Proxy != null)
			{
				TriggerProxy proxy = Proxy;
				proxy.EnterTriggerInteraction = (Action<GameObject, Collider>)Delegate.Remove(proxy.EnterTriggerInteraction, new Action<GameObject, Collider>(AttackTriggerEnter));
			}
		}

		internal override void MainAttack_Start(IMWeaponOwner RC)
		{
			base.MainAttack_Start(RC);
			if (CanAttack)
			{
				base.WeaponAction(101);
			}
		}

		internal override void Attack_Charge(IMWeaponOwner RC, float time)
		{
			if (base.Automatic && CanAttack && CanCharge && base.Rate > 0f && Input)
			{
				MainAttack_Start(RC);
			}
		}

		private void AttackTriggerEnter(GameObject root, Collider other)
		{
			if (!IsInvalid(other) && !(other.transform.root == IgnoreTransform) && (!ignoreStaticObjects || !other.transform.gameObject.isStatic) && !MissAttack())
			{
				IMDamage componentInParent = other.GetComponentInParent<IMDamage>();
				if (!AttackDirection)
				{
					base.Direction = Owner.transform.forward;
				}
				Vector3 center = meleeTrigger.bounds.center;
				Debugging("Hit [" + other.name + "]", this);
				TryInteract(other.gameObject);
				TryPhysics(other.attachedRigidbody, other, center, Force);
				TryStopAnimator();
				TryHitEffect(other, meleeTrigger.bounds.center, componentInParent);
				StatModifier stat = new StatModifier(statModifier)
				{
					Value = Mathf.Lerp(base.MinDamage, base.MaxDamage, base.ChargedNormalized)
				};
				if (componentInParent != null)
				{
					componentInParent.HitCollider = other;
				}
				TryDamage(componentInParent, stat);
			}
		}

		public override void ResetWeapon()
		{
			if ((bool)meleeTrigger)
			{
				meleeTrigger.enabled = false;
				Proxy.Active = false;
			}
			base.ResetWeapon();
		}

		private void FindTrigger()
		{
			if (meleeTrigger == null)
			{
				meleeTrigger = GetComponent<Collider>();
			}
			if ((bool)meleeTrigger)
			{
				Proxy = TriggerProxy.CheckTriggerProxy(meleeTrigger, base.Layer, base.TriggerInteraction, Owner.transform);
				meleeTrigger.enabled = false;
				Proxy.Active = meleeTrigger.enabled;
				Proxy.EnterTriggerInteraction = delegate
				{
				};
			}
			else
			{
				Debug.LogError("Weapon [" + base.name + "] needs a collider. Please add one. Disabling Weapon", this);
				base.enabled = false;
			}
		}
	}
}
