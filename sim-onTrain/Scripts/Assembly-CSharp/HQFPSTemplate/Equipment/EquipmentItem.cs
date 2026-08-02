using System;
using HQFPSTemplate.Items;
using UnityEngine;
using UnityEngine.Events;

namespace HQFPSTemplate.Equipment
{
	public abstract class EquipmentItem : PlayerComponent
	{
		[Serializable]
		public class GeneralInfo
		{
			[HideInInspector]
			public PlayerInventory connectedInventory;

			public CollectableItemData bulletData;

			public CollectableItemData inventoryItemData;

			[DatabaseItem]
			public string CorrespondingItem;

			[Space(4f)]
			public EquipmentItemInfo EquipmentInfo;

			[Space(4f)]
			[BHeader("Animation", false, order = 2)]
			public EquipmentAnimationInfo EquipmentAnimationInfo;

			[EnableIf("EquipmentAnimationInfo", true, 6f)]
			public Animator Animator;

			[Space(4f)]
			[BHeader("Physics", false, order = 2)]
			public EquipmentPhysicsInfo EquipmentPhysicsInfo;

			[EnableIf("EquipmentPhysicsInfo", true, 6f)]
			public Transform PhysicsPivot;

			[Space(4f)]
			[BHeader("Model", false, order = 2)]
			public EquipmentModelHandler EquipmentModel;

			public float hitDamage;
		}

		[Serializable]
		public class GeneralEvents
		{
			[Serializable]
			public class SimpleBoolEvent : UnityEvent<bool>
			{
			}

			[BHeader("Equipped / Unequipped", true)]
			public SimpleBoolEvent OnEquipped = new SimpleBoolEvent();

			[BHeader("Reload Start / Reload Stop", true)]
			public SimpleBoolEvent OnReload = new SimpleBoolEvent();

			[BHeader("Aim Start / Aim Stop", true)]
			public SimpleBoolEvent OnAim = new SimpleBoolEvent();

			[Space]
			public UnityEvent OnUse;

			public UnityEvent OnChangeUseMode;
		}

		protected EastUpPlayerItemManager m_Chooser;

		private readonly int animHash_IdleIndex = Animator.StringToHash("Idle Index");

		private readonly int animHash_EquipSpeed = Animator.StringToHash("Equip Speed");

		private readonly int animHash_Equip = Animator.StringToHash("Equip");

		private readonly int animHash_Unequip = Animator.StringToHash("Unequip");

		private readonly int animHash_UnequipSpeed = Animator.StringToHash("Unequip Speed");

		[SerializeField]
		[Group]
		public GeneralInfo m_GeneralInfo;

		[SerializeField]
		[Group]
		public GeneralEvents m_GeneralEvents;

		protected float m_UseThreshold = 0.1f;

		protected float m_NextTimeCanUse;

		protected float m_NextTimeCanAim;

		public TPS_EquipmentItem tpsPart;

		public EquipmentHandler EHandler { get; private set; }

		public EquipmentModelHandler EModel => m_GeneralInfo.EquipmentModel;

		public EquipmentItemInfo EInfo => m_GeneralInfo.EquipmentInfo;

		public EquipmentAnimationInfo EAnimation => m_GeneralInfo.EquipmentAnimationInfo;

		public EquipmentPhysicsInfo EPhysics => m_GeneralInfo.EquipmentPhysicsInfo;

		public Transform PhysicsPivot => m_GeneralInfo.PhysicsPivot;

		public Animator Animator => m_GeneralInfo.Animator;

		public string CorrespondingItemName => m_GeneralInfo.CorrespondingItem;

		public virtual void Initialize(EquipmentHandler eHandler)
		{
			EHandler = eHandler;
			EAnimation.AssignEquipmentAnimation(Animator);
			m_GeneralInfo.connectedInventory = GetComponentInParent<PlayerInventory>(includeInactive: true);
			m_Chooser = GetComponentInParent<EastUpPlayerItemManager>(includeInactive: true);
		}

		public virtual void Equip(Item item)
		{
			EAnimation.AssignArmAnimations(EHandler.FPArmsHandler.Animator);
			EHandler.Animator_SetTrigger(animHash_Equip);
			EHandler.Animator_SetFloat(animHash_UnequipSpeed, m_GeneralInfo.EquipmentInfo.Unequipping.AnimationSpeed);
			EHandler.Animator_SetFloat(animHash_EquipSpeed, m_GeneralInfo.EquipmentInfo.Equipping.AnimationSpeed);
			EHandler.PlayDelayedSounds(m_GeneralInfo.EquipmentInfo.Equipping.Audio);
			base.Player.Camera.Physics.PlayDelayedCameraForces(m_GeneralInfo.EquipmentInfo.Equipping.CameraForces);
			base.Player.Camera.Physics.AimHeadbobMod = m_GeneralInfo.EquipmentInfo.Aiming.AimCamHeadbobMod;
			m_GeneralInfo.EquipmentModel.UpdateSkinIDProperty(item);
			m_GeneralInfo.EquipmentModel.UpdateMaterialsFov();
			m_GeneralEvents.OnEquipped.Invoke(arg0: true);
			if (tpsPart != null)
			{
				tpsPart.Equip(item);
			}
			GetComponentInParent<CameraRigController>().currentWeapon = GetComponent<WeaponTpsPositionSetter>();
		}

		public virtual void Unequip()
		{
			if (m_GeneralInfo.EquipmentInfo.Unequipping.Audio != null)
			{
				EHandler.PlayPersistentAudio(m_GeneralInfo.EquipmentInfo.Unequipping.Audio[0].Sound, 1f);
			}
			base.Player.Camera.Physics.PlayDelayedCameraForces(m_GeneralInfo.EquipmentInfo.Unequipping.CameraForces);
			EHandler.Animator_SetTrigger(animHash_Unequip);
			m_GeneralEvents.OnEquipped.Invoke(arg0: false);
			if (tpsPart != null)
			{
				tpsPart.Unequip();
			}
		}

		public virtual bool TryUseOnce(Ray[] itemUseRays, int useType = 0)
		{
			return false;
		}

		public virtual bool TryUseContinuously(Ray[] itemUseRays, int useType = 0)
		{
			return false;
		}

		public virtual void OnUseStart()
		{
		}

		public virtual void OnUseEnd()
		{
		}

		public virtual bool TryChangeUseMode()
		{
			return false;
		}

		public virtual float GetUseRaySpreadMod()
		{
			return 1f;
		}

		public virtual float GetTimeBetweenUses()
		{
			return m_UseThreshold;
		}

		public virtual bool CanBeUsed()
		{
			return true;
		}

		public virtual int GetUseRaysAmount()
		{
			return 1;
		}

		public virtual bool TryStartReload()
		{
			return false;
		}

		public virtual bool IsDoneReloading()
		{
			return false;
		}

		public virtual void OnReloadStop()
		{
		}

		public virtual bool CanAim()
		{
			return m_NextTimeCanAim < Time.time;
		}

		public virtual void OnAimStart()
		{
			EHandler.Animator_SetInteger(animHash_IdleIndex, 0);
			m_NextTimeCanAim = Time.time + m_GeneralInfo.EquipmentInfo.Aiming.AimThreshold;
			m_GeneralEvents.OnAim.Invoke(arg0: true);
		}

		public virtual void OnAimStop()
		{
			EHandler.Animator_SetInteger(animHash_IdleIndex, 1);
			m_GeneralEvents.OnAim.Invoke(arg0: false);
		}
	}
}
