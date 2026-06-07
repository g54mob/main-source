using System;
using MalbersAnimations.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Damage/Attack Trigger")]
	[SelectionBase]
	public class MAttackTrigger : MDamager
	{
		[RequiredField]
		[Tooltip("Collider used for the Interaction")]
		public Collider Trigger;

		[Tooltip("When the Attack Trigger Exits a collider, Affect a Target Stats")]
		public StatModifier EnemyStatExit;

		public UnityEvent OnAttackBegin = new UnityEvent();

		public UnityEvent OnAttackEnd = new UnityEvent();

		public Color DebugColor = new Color(1f, 0.25f, 0f, 0.15f);

		[HideInInspector]
		public int Editor_Tabs1;

		protected TriggerProxy Proxy { get; private set; }

		public override bool CanCauseDamage
		{
			get
			{
				return Enabled;
			}
			set
			{
				Enabled = value;
				if (CanCauseDamage && AttackDirection)
				{
					if (C_Direction != null)
					{
						StopCoroutine(C_Direction);
						C_Direction = null;
					}
					StartCoroutine(C_Direction = I_CalculateDirection(Trigger));
				}
			}
		}

		private void Awake()
		{
			this.Delay_Action(1, delegate
			{
				if ((bool)animator)
				{
					defaultAnimatorSpeed = animator.speed;
				}
			});
			FindTrigger();
			if (!m_Active.Value)
			{
				base.enabled = false;
			}
			SetDefaultProfile();
			if (base.HitEffect != null && !base.HitEffect.IsPrefab())
			{
				base.HitEffect.SetActive(value: false);
			}
		}

		private void FindTrigger()
		{
			if (Owner == null)
			{
				IObjectCore componentInParent = base.transform.GetComponentInParent<IObjectCore>();
				Owner = ((componentInParent != null) ? componentInParent.transform.gameObject : base.transform.gameObject);
			}
			if ((bool)Trigger)
			{
				Proxy = TriggerProxy.CheckTriggerProxy(Trigger, base.Layer, base.TriggerInteraction, Owner.transform);
				Proxy.EnterTriggerInteraction = delegate
				{
				};
				Proxy.Tags = Tags;
			}
			else
			{
				Debug.LogWarning("Attack trigger " + base.name + " need a Collider", this);
			}
		}

		private void OnEnable()
		{
			if ((bool)Trigger)
			{
				Collider trigger = Trigger;
				Collider trigger2 = Trigger;
				bool flag = (Proxy.Active = true);
				bool flag3 = (trigger2.isTrigger = flag);
				trigger.enabled = flag3;
			}
			CheckAudioSource();
			TriggerProxy proxy = Proxy;
			proxy.EnterTriggerInteraction = (Action<GameObject, Collider>)Delegate.Combine(proxy.EnterTriggerInteraction, new Action<GameObject, Collider>(AttackTriggerEnter));
			TriggerProxy proxy2 = Proxy;
			proxy2.ExitTriggerInteraction = (Action<GameObject, Collider>)Delegate.Combine(proxy2.ExitTriggerInteraction, new Action<GameObject, Collider>(AttackTriggerExit));
			damagee = null;
			OnAttackBegin.Invoke();
			CanCauseDamage = base.enabled;
		}

		private void OnDisable()
		{
			if ((bool)Trigger)
			{
				Collider trigger = Trigger;
				bool flag = (Proxy.Active = false);
				trigger.enabled = flag;
			}
			TriggerProxy proxy = Proxy;
			proxy.EnterTriggerInteraction = (Action<GameObject, Collider>)Delegate.Remove(proxy.EnterTriggerInteraction, new Action<GameObject, Collider>(AttackTriggerEnter));
			TriggerProxy proxy2 = Proxy;
			proxy2.ExitTriggerInteraction = (Action<GameObject, Collider>)Delegate.Remove(proxy2.ExitTriggerInteraction, new Action<GameObject, Collider>(AttackTriggerExit));
			TryDamage(damagee, EnemyStatExit);
			OnAttackEnd.Invoke();
			if ((bool)animator)
			{
				animator.speed = defaultAnimatorSpeed;
			}
			damagee = null;
		}

		private void AttackTriggerEnter(GameObject newGo, Collider other)
		{
			if ((bool)dontHitOwner && Owner != null && other.transform.IsChildOf(Owner.transform))
			{
				return;
			}
			Vector3 center = Trigger.bounds.center;
			if (!AttackDirection)
			{
				base.Direction = Owner.transform.forward;
			}
			else
			{
				base.Direction = (other.bounds.center - center).normalized;
			}
			if (!MissAttack())
			{
				TryInteract(other.gameObject);
				TryPhysics(other.attachedRigidbody, other, center, Force);
				TryStopAnimator();
				damagee = other.GetComponentInParent<IMDamage>();
				if (damagee != null)
				{
					damagee.LastForceMode = forceMode;
				}
				TryHitEffect(other, Trigger.bounds.center, damagee);
				TryDamage(damagee, statModifier);
				if (damagee != null)
				{
					damagee.HitCollider = other;
				}
			}
		}

		private void AttackTriggerExit(GameObject newGo, Collider other)
		{
			if (!dontHitOwner || !(Owner != null) || !other.transform.IsChildOf(Owner.transform))
			{
				TryDamage(other.GetComponentInParent<IMDamage>(), EnemyStatExit);
			}
		}

		public override void DoDamage(bool value, int prof)
		{
			base.DoDamage(value, prof);
			CanCauseDamage = value;
		}
	}
}
