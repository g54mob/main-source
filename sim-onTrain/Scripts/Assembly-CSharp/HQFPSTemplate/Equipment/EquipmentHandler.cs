using System;
using System.Collections.Generic;
using HQFPSTemplate.Items;
using UnityEngine;
using UnityEngine.Audio;

namespace HQFPSTemplate.Equipment
{
	public class EquipmentHandler : PlayerComponent
	{
		[Serializable]
		public struct UseRaySpread
		{
			[Range(0.01f, 10f)]
			public float JumpSpreadMod;

			[Range(0.01f, 10f)]
			public float RunSpreadMod;

			[Range(0.01f, 10f)]
			public float CrouchSpreadMod;

			[Range(0.01f, 10f)]
			public float ProneSpreadMod;

			[Range(0.01f, 10f)]
			public float WalkSpreadMod;

			[Range(0.01f, 10f)]
			public float AimSpreadMod;
		}

		[Serializable]
		public class ItemPropertiesDictionary
		{
			[DatabaseProperty]
			public string m_AmmoProperty = "Ammo";

			[DatabaseProperty]
			public string m_AmmoTypeProperty = "Ammo Type";

			[DatabaseProperty]
			public string m_FireModeProperty = "Fire Mode";

			public string AmmoProperty => m_AmmoProperty;

			public string AmmoTypeProperty => m_AmmoTypeProperty;

			public string FireModeProperty => m_FireModeProperty;
		}

		public Message OnChangeItem = new Message();

		public Activity UsingItem = new Activity();

		[SerializeField]
		protected EquipmentPhysicsHandler m_EquipmentPhysicsHandler;

		[SerializeField]
		protected FPArmsHandler m_FPArmsHandler;

		[Space]
		[SerializeField]
		protected Transform m_ItemUseTransform;

		[SerializeField]
		[Group("Inverse of Accuracy - ", true)]
		protected UseRaySpread m_UseRaySpread;

		[SerializeField]
		[Group]
		public ItemPropertiesDictionary m_ItemProperties;

		protected EquipmentItem m_AttachedEquipmentItem;

		protected Item m_AttachedItem;

		protected Unarmed m_Unarmed;

		[SerializeField]
		[Tooltip("Silah sesleri (dry-fire, reload, kovan, aim, equip) icin mixer grubu. Bossa mixer bypass edilir ve ses ayarlari bu sesleri etkilemez!")]
		protected AudioMixerGroup m_WeaponMixerGroup;

		protected AudioSource m_AudioSource;

		protected AudioSource m_PersistentAudioSource;

		protected int m_ContinuouslyUsedTimes;

		protected float m_NextTimeCanUseItem = -1f;

		protected List<QueuedSound> m_QueuedSounds = new List<QueuedSound>();

		protected Dictionary<int, EquipmentItem> m_EquipmentItems = new Dictionary<int, EquipmentItem>();

		public EASTUP_WeaponAnimationHandler animationHandler;

		public EastUpPlayerItemManager itemChooser;

		public int ContinuouslyUsedTimes => m_ContinuouslyUsedTimes;

		public Transform ItemUseTransform => m_ItemUseTransform;

		public Item Item
		{
			get
			{
				if (m_AttachedItem == null)
				{
					return base.Player.EquippedItem.Get();
				}
				return m_AttachedItem;
			}
			protected set
			{
				m_AttachedItem = value;
			}
		}

		public ItemPropertiesDictionary ItemProperties => m_ItemProperties;

		public FPArmsHandler FPArmsHandler => m_FPArmsHandler;

		public EquipmentPhysicsHandler EPhysicsHandler => m_EquipmentPhysicsHandler;

		public EquipmentItem EquipmentItem
		{
			get
			{
				if (!(m_AttachedEquipmentItem != null))
				{
					return m_Unarmed;
				}
				return m_AttachedEquipmentItem;
			}
		}

		public EquipmentItem GetEquipmentItem(int itemId)
		{
			if (itemId == 0)
			{
				return m_Unarmed;
			}
			if (m_EquipmentItems.TryGetValue(itemId, out var value))
			{
				return value;
			}
			return null;
		}

		public virtual void Reset()
		{
			UnequipItem();
			m_AttachedEquipmentItem = null;
			m_AttachedItem = null;
			m_ContinuouslyUsedTimes = 0;
			m_NextTimeCanUseItem = -1f;
			ClearDelayedCamForces();
			ClearDelayedSounds();
		}

		public bool ContainsEquipmentItem(int itemId)
		{
			return m_EquipmentItems.ContainsKey(itemId);
		}

		public virtual void EquipItem(Item item)
		{
			ClearDelayedSounds();
			ClearDelayedCamForces();
			m_AttachedItem = item;
			if (m_AttachedEquipmentItem != null)
			{
				m_AttachedEquipmentItem.gameObject.SetActive(value: false);
			}
			int itemId = item?.Id ?? 0;
			m_AttachedEquipmentItem = GetEquipmentItem(itemId);
			m_AttachedEquipmentItem.gameObject.SetActive(value: true);
			CollectableInventoryItem component = m_AttachedEquipmentItem.GetComponent<CollectableInventoryItem>();
			if (component != null && component.multipleItemBehavior && itemChooser != null)
			{
				CollectableItemData selectedSlotItemData = itemChooser.GetSelectedSlotItemData();
				if (selectedSlotItemData != null && selectedSlotItemData.itemType == ItemType.Syringe)
				{
					foreach (CollectableItemData multipleItem in component.multipleItems)
					{
						if (multipleItem == selectedSlotItemData)
						{
							m_AttachedEquipmentItem.m_GeneralInfo.inventoryItemData = selectedSlotItemData;
							break;
						}
					}
				}
			}
			IEquipmentComponent[] components = m_AttachedEquipmentItem.GetComponents<IEquipmentComponent>();
			if (components.Length != 0)
			{
				IEquipmentComponent[] array = components;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].OnSelected();
				}
			}
			SetCharacterMovementSpeed(base.Player.Aim.Active ? m_AttachedEquipmentItem.EInfo.Aiming.AimMovementSpeedMod : 1f);
			m_NextTimeCanUseItem = Time.time + m_AttachedEquipmentItem.EInfo.Equipping.Duration;
			OnChangeItem.Send();
			m_AttachedEquipmentItem.Equip(item);
		}

		public virtual void UnequipItem()
		{
			if (!(m_AttachedEquipmentItem == null))
			{
				m_AttachedItem = null;
				m_NextTimeCanUseItem = Time.time + m_AttachedEquipmentItem.EInfo.Unequipping.Duration;
				EquipmentItem.Unequip();
			}
		}

		public virtual bool TryUse(bool continuously, int useType = 0)
		{
			if (!TrainGameManager.isInputActive || TrainGameManager.isMouseLocked)
			{
				return false;
			}
			if (itemChooser.isFireBlocked)
			{
				return false;
			}
			bool flag = false;
			if (m_NextTimeCanUseItem < Time.time || continuously)
			{
				Ray[] itemUseRays = GenerateItemUseRays(base.Player, m_ItemUseTransform, m_AttachedEquipmentItem.GetUseRaysAmount(), m_AttachedEquipmentItem.GetUseRaySpreadMod());
				flag = ((!continuously) ? m_AttachedEquipmentItem.TryUseOnce(itemUseRays, useType) : m_AttachedEquipmentItem.TryUseContinuously(itemUseRays, useType));
				if (flag)
				{
					if (!UsingItem.Active)
					{
						UsingItem.ForceStart();
						EquipmentItem.OnUseStart();
					}
					if (UsingItem.Active)
					{
						m_ContinuouslyUsedTimes++;
					}
					else
					{
						m_ContinuouslyUsedTimes = 1;
					}
				}
			}
			return flag;
		}

		public virtual bool TryUseRepeat(bool continuously, int useType = 0)
		{
			Debug.Log("tekrar vuruluyor");
			if (!TrainGameManager.isInputActive || TrainGameManager.isMouseLocked)
			{
				return false;
			}
			bool flag = false;
			if (m_NextTimeCanUseItem < Time.time || continuously)
			{
				Debug.Log("tekrar vuruluyor ife girdi");
				Ray[] itemUseRays = GenerateItemUseRays(base.Player, m_ItemUseTransform, m_AttachedEquipmentItem.GetUseRaysAmount(), m_AttachedEquipmentItem.GetUseRaySpreadMod());
				flag = m_AttachedEquipmentItem.TryUseOnce(itemUseRays, useType);
				if (flag)
				{
					if (!UsingItem.Active)
					{
						UsingItem.ForceStart();
						EquipmentItem.OnUseStart();
					}
					if (UsingItem.Active)
					{
						m_ContinuouslyUsedTimes++;
					}
					else
					{
						m_ContinuouslyUsedTimes = 1;
					}
				}
			}
			return flag;
		}

		public Ray[] GenerateItemUseRays(Humanoid humanoid, Transform anchor, int raysAmount, float equipmentSpreadMod)
		{
			Ray[] array = new Ray[raysAmount];
			float num = 1f;
			if (humanoid != null)
			{
				if (humanoid.Jump.Active)
				{
					num *= m_UseRaySpread.JumpSpreadMod;
				}
				else if (humanoid.Run.Active)
				{
					num *= m_UseRaySpread.RunSpreadMod;
				}
				else if (humanoid.Crouch.Active)
				{
					num *= m_UseRaySpread.CrouchSpreadMod;
				}
				else if (humanoid.Prone.Active)
				{
					num *= m_UseRaySpread.ProneSpreadMod;
				}
				else if (humanoid.Walk.Active)
				{
					num *= m_UseRaySpread.WalkSpreadMod;
				}
				if (humanoid.Aim.Active)
				{
					num *= m_UseRaySpread.AimSpreadMod;
				}
			}
			float num2 = equipmentSpreadMod * num;
			if (m_ContinuouslyUsedTimes == 0 && array.Length <= 1)
			{
				num2 = 0f;
			}
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 direction = Quaternion.Euler(anchor.TransformVector(new Vector3(UnityEngine.Random.Range(0f - num2, num2), UnityEngine.Random.Range(0f - num2, num2), 0f))) * anchor.forward;
				array[i] = new Ray(anchor.position, direction);
			}
			return array;
		}

		public virtual bool TryStartAim()
		{
			if (TrainGameManager.isMouseLocked)
			{
				return false;
			}
			if (m_NextTimeCanUseItem > Time.time || (!m_AttachedEquipmentItem.EInfo.Aiming.AimWhileAirborne && !base.Player.IsGrounded.Get()) || !m_AttachedEquipmentItem.EInfo.Aiming.Enabled || !m_AttachedEquipmentItem.CanAim())
			{
				return false;
			}
			SetCharacterMovementSpeed(m_AttachedEquipmentItem.EInfo.Aiming.AimMovementSpeedMod);
			m_AttachedEquipmentItem.OnAimStart();
			return true;
		}

		public virtual void OnAimStop()
		{
			SetCharacterMovementSpeed(1f);
			if (m_AttachedEquipmentItem != null)
			{
				m_AttachedEquipmentItem.OnAimStop();
			}
		}

		public virtual bool TryStartReload()
		{
			return m_AttachedEquipmentItem.TryStartReload();
		}

		public virtual bool IsDoneReloading()
		{
			return m_AttachedEquipmentItem.IsDoneReloading();
		}

		public virtual void OnReloadStop()
		{
			ClearDelayedCamForces();
			m_AttachedEquipmentItem.OnReloadStop();
		}

		public virtual void OnGroundedChange(bool grounded)
		{
			if (m_AttachedEquipmentItem != null && !grounded && !m_AttachedEquipmentItem.EInfo.Aiming.AimWhileAirborne)
			{
				base.Player.Aim.ForceStop();
			}
		}

		protected virtual void SetCharacterMovementSpeed(float multiplier)
		{
			base.Player.MovementSpeedFactor.Set(m_AttachedEquipmentItem.EInfo.General.MovementSpeedMod * multiplier);
		}

		protected virtual void Awake()
		{
			m_Unarmed = GetComponentInChildren<Unarmed>(includeInactive: true);
			m_EquipmentPhysicsHandler = GetComponent<EquipmentPhysicsHandler>();
			EquipmentItem[] componentsInChildren = GetComponentsInChildren<EquipmentItem>(includeInactive: true);
			foreach (EquipmentItem equipmentItem in componentsInChildren)
			{
				ItemInfo itemByName = ItemDatabase.GetItemByName(equipmentItem.CorrespondingItemName);
				if (equipmentItem != m_Unarmed)
				{
					int id = itemByName.Id;
					if (!m_EquipmentItems.ContainsKey(id))
					{
						m_EquipmentItems.Add(id, equipmentItem);
					}
					else
					{
						Debug.LogWarning("There are multiple equipment items that correspond to the same item under '" + base.gameObject.name + "'");
					}
				}
				equipmentItem.Initialize(this);
				IEquipmentComponent[] components = equipmentItem.gameObject.GetComponents<IEquipmentComponent>();
				if (components.Length != 0)
				{
					IEquipmentComponent[] array = components;
					for (int j = 0; j < array.Length; j++)
					{
						array[j].Initialize(equipmentItem);
					}
				}
				equipmentItem.gameObject.SetActive(value: false);
			}
			m_AudioSource = AudioUtils.CreateAudioSource("Audio Source", base.transform, Vector3.zero);
			AudioSource audioSource = m_AudioSource;
			AudioSource audioSource2 = m_AudioSource;
			bool flag = (m_AudioSource.bypassReverbZones = false);
			bool bypassEffects = (audioSource2.bypassListenerEffects = flag);
			audioSource.bypassEffects = bypassEffects;
			m_AudioSource.maxDistance = 500f;
			if (m_WeaponMixerGroup != null)
			{
				m_AudioSource.outputAudioMixerGroup = m_WeaponMixerGroup;
			}
			m_PersistentAudioSource = AudioUtils.CreateAudioSource("Persistent Audio Source", base.transform, Vector3.zero, is2D: true, 1f, 2.5f);
			AudioSource persistentAudioSource = m_PersistentAudioSource;
			AudioSource persistentAudioSource2 = m_PersistentAudioSource;
			flag = (m_PersistentAudioSource.bypassReverbZones = false);
			bypassEffects = (persistentAudioSource2.bypassListenerEffects = flag);
			persistentAudioSource.bypassEffects = bypassEffects;
			m_PersistentAudioSource.maxDistance = 500f;
			if (m_WeaponMixerGroup != null)
			{
				m_PersistentAudioSource.outputAudioMixerGroup = m_WeaponMixerGroup;
			}
		}

		protected virtual void Update()
		{
			for (int i = 0; i < m_QueuedSounds.Count; i++)
			{
				if (Time.time >= m_QueuedSounds[i].PlayTime)
				{
					m_QueuedSounds[i].DelayedSound.Sound.Play(ItemSelection.Method.RandomExcludeLast, m_AudioSource);
					m_QueuedSounds.RemoveAt(i);
				}
			}
			if (m_AttachedEquipmentItem != null && base.Player.UseItem.LastExecutionTime + Mathf.Clamp(m_AttachedEquipmentItem.GetTimeBetweenUses() * 2f, 0f, 0.3f) < Time.time && UsingItem.Active)
			{
				UsingItem.ForceStop();
				m_AttachedEquipmentItem.OnUseEnd();
				m_ContinuouslyUsedTimes = 0;
			}
		}

		protected virtual void ClearDelayedCamForces()
		{
			base.Player.Camera.Physics.ClearQueuedCamForces();
		}

		public void PlayPersistentAudio(SoundPlayer soundPlayer, float volume, ItemSelection.Method selectionMethod = ItemSelection.Method.RandomExcludeLast)
		{
			soundPlayer.Play(selectionMethod, m_PersistentAudioSource, volume);
		}

		public void PlayPersistentAudio(AudioClip clip, float volume)
		{
			m_PersistentAudioSource.PlayOneShot(clip, volume);
		}

		public void ClearDelayedSounds()
		{
			m_QueuedSounds.Clear();
		}

		public void PlayDelayedSound(DelayedSound delayedSound)
		{
			m_QueuedSounds.Add(new QueuedSound(delayedSound, Time.time + delayedSound.Delay));
		}

		public void PlayDelayedSounds(DelayedSound[] clipsData)
		{
			for (int i = 0; i < clipsData.Length; i++)
			{
				PlayDelayedSound(clipsData[i]);
			}
		}

		public void PlaySound(SoundPlayer soundPlayer, float volume, ItemSelection.Method selectionMethod = ItemSelection.Method.RandomExcludeLast)
		{
			soundPlayer.Play(selectionMethod, m_AudioSource, volume);
		}

		public virtual void Animator_SetTrigger(string _string)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetTrigger(_string);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetTrigger(_string);
			}
		}

		public virtual void Animator_SetTrigger(int _hashCode)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetTrigger(_hashCode);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetTrigger(_hashCode);
			}
		}

		public virtual void Animator_SetBool(string _string, bool _bool)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetBool(_string, _bool);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetBool(_string, _bool);
			}
		}

		public virtual void Animator_SetBool(int _hashCode, bool _bool)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetBool(_hashCode, _bool);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetBool(_hashCode, _bool);
			}
		}

		public virtual void Animator_SetInteger(string _string, int _int)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetInteger(_string, _int);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetInteger(_string, _int);
			}
		}

		public virtual void Animator_SetInteger(int _hashCode, int _int)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetInteger(_hashCode, _int);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetInteger(_hashCode, _int);
			}
		}

		public virtual void Animator_SetFloat(string _string, float _float)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetFloat(_string, _float);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetFloat(_string, _float);
			}
		}

		public virtual void Animator_SetFloat(int _hashCode, float _float)
		{
			if ((bool)m_AttachedEquipmentItem.Animator)
			{
				m_AttachedEquipmentItem.Animator.SetFloat(_hashCode, _float);
			}
			if ((bool)m_FPArmsHandler.Animator)
			{
				m_FPArmsHandler.Animator.SetFloat(_hashCode, _float);
			}
		}
	}
}
