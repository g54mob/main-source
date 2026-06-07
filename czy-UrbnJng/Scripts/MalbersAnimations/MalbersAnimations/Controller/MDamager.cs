using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	public abstract class MDamager : MonoBehaviour, IMDamager, IMLayer, IInteractor
	{
		[SerializeField]
		[Tooltip("Index of the Damager, You can have multiple swords ... this identifies if a sword is different from another")]
		protected int index = 1;

		[SerializeField]
		[Tooltip("Enable/Disable the Damager")]
		protected BoolReference m_Active = new BoolReference(value: true);

		[Tooltip("Hit Layer to interact with Objects")]
		[ContextMenuItem("Get Layer from Root", "GetLayerFromRoot")]
		public LayerReference m_hitLayer = new LayerReference(-1);

		[Tooltip("Search only Tags")]
		public Tag[] Tags;

		[Tooltip("True: the Attack Direction is calculated using the movement.\nFalse: The Attact Direction is the Character Forward Direction")]
		public bool AttackDirection;

		[SerializeField]
		[Tooltip("What to do with Triggers")]
		protected QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

		[SerializeField]
		[Tooltip("Owner. usually the Character Owns the Damager")]
		[ContextMenuItem("Find Owner", "Find_Owner")]
		protected GameObject owner;

		[SerializeField]
		[Tooltip("Default Hit Effect. This Gameobject will be enabled on Impact, if its a Prefab it will be instantiated")]
		internal GameObjectReference m_HitEffect;

		[Tooltip("Custom Hit Effects if the Damageable has a Surface ID")]
		public List<EffectType> hitEffects = new List<EffectType>();

		[Tooltip("Default Audio Clip to play when the Damager hit something")]
		public AudioClipReference hitSound;

		[Tooltip("The Effect will be destroyed If is a Prefab. after this time has elapsed. If this value is zero, the effect will not be destroyed")]
		[Min(0f)]
		public float DestroyHitEffect;

		[Tooltip("Dont Hit any objects on the Owner's hierarchy")]
		public BoolReference dontHitOwner = new BoolReference(value: true);

		[Tooltip("Don't use the Default Reaction of the Damageable Component")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction CustomReaction;

		[Tooltip("Type of element damage the Damager can do")]
		public StatElement element;

		[Tooltip("Interactor ID to enable with who interactable the Interactor can react")]
		public IntReference interactorID = new IntReference(0);

		[Tooltip("Damager can activate interactables")]
		public BoolReference interact = new BoolReference(value: true);

		[Tooltip("Damager allows the Damagee to apply an animal reaction")]
		public BoolReference react = new BoolReference(value: true);

		[Tooltip("If true the Damage Receiver will not apply its Default Multiplier")]
		public BoolReference pureDamage = new BoolReference(value: false);

		[Tooltip("Stat to modify on the Damagee")]
		[ContextMenuItem("Set Default Damage", "Set_DefaultDamage")]
		public StatModifier statModifier = new StatModifier();

		[SerializeField]
		[Tooltip("Miss Chance (0 - 1)\n1 means it will always Miss")]
		protected FloatReference m_MissChance = new FloatReference(0f);

		[SerializeField]
		[Tooltip("Critical Change (0 - 1)\n1 means it will be always critical")]
		protected FloatReference m_cChance = new FloatReference(0f);

		[SerializeField]
		[Tooltip("If the Damage is critical, the Stat modifier value will be multiplied by the Critical Multiplier")]
		protected FloatReference cMultiplier = new FloatReference(2f);

		[SerializeField]
		[Tooltip("MAX Force to Apply to RigidBodies when the Damager hit them")]
		protected FloatReference m_Force = new FloatReference(50f);

		[SerializeField]
		[Tooltip("MIN Force to Apply to RigidBodies when the Damager hit them")]
		protected FloatReference minForce = new FloatReference(20f);

		[Tooltip("Force mode to apply to the Object that the Damager Hits")]
		public ForceMode forceMode = ForceMode.VelocityChange;

		public TransformEvent OnHit = new TransformEvent();

		public Vector3Event OnHitPosition = new Vector3Event();

		public IntEvent OnHitInteractable = new IntEvent();

		public IntEvent OnProfileChanged = new IntEvent();

		public UnityEvent OnAttackMissed = new UnityEvent();

		[Tooltip("If there's an Animator Controller it will be stopped")]
		[ContextMenuItem("Find Animator", "Find_Animator")]
		[ContextMenuItem("Clear Animator", "Clear_Animator")]
		public Animator animator;

		[Tooltip("Value of the Animator Speed when its stopped")]
		public FloatReference AnimatorSpeed = new FloatReference(0.05f);

		[Tooltip("Time the Animator will be stopped. If its zero, stopping the animator is ignored")]
		public FloatReference AnimatorStopTime = new FloatReference(0.1f);

		[Tooltip("Profiles to change the values of a Damager")]
		public List<DamagerProfile> Profiles;

		private float DamageMultiplier = 1f;

		protected int CurrentProfileIndex;

		public DamagerProfile DefaultProfile;

		protected IMDamage damagee;

		public bool debug;

		public AudioSource m_audio;

		protected bool playingSound;

		protected IEnumerator C_Direction;

		protected IEnumerator C_StopAnim;

		protected float defaultAnimatorSpeed = 1f;

		public virtual bool CanCauseDamage { get; set; }

		public GameObject HitEffect
		{
			get
			{
				return m_HitEffect.Value;
			}
			set
			{
				m_HitEffect.Value = value;
			}
		}

		public virtual Transform IgnoreTransform { get; set; }

		[Tooltip("Stores the Direction of the Attack. Used to apply the Force and to know the Direction of the Hit from the Damager")]
		protected Vector3 Direction { get; set; }

		public Vector3 HitPosition { get; protected set; }

		public Quaternion HitRotation { get; protected set; }

		public virtual GameObject Owner
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
			}
		}

		public virtual float Force => Mathf.Lerp(MinForce, MaxForce, Random.Range(0f, 1f));

		public virtual float MinForce
		{
			get
			{
				return minForce.Value;
			}
			set
			{
				minForce.Value = value;
			}
		}

		public virtual float MaxForce
		{
			get
			{
				return m_Force.Value;
			}
			set
			{
				m_Force.Value = value;
			}
		}

		public LayerMask Layer
		{
			get
			{
				return m_hitLayer.Value;
			}
			set
			{
				m_hitLayer.Value = value;
			}
		}

		public QueryTriggerInteraction TriggerInteraction
		{
			get
			{
				return triggerInteraction;
			}
			set
			{
				triggerInteraction = value;
			}
		}

		public bool IsCritical { get; set; }

		public float CriticalMultiplier
		{
			get
			{
				return cMultiplier.Value;
			}
			set
			{
				cMultiplier.Value = value;
			}
		}

		public float CriticalChance
		{
			get
			{
				return m_cChance.Value;
			}
			set
			{
				m_cChance.Value = value;
			}
		}

		public float MissChance
		{
			get
			{
				return m_MissChance.Value;
			}
			set
			{
				m_MissChance.Value = value;
			}
		}

		public virtual int Index => index;

		public virtual int ID => interactorID.Value;

		public virtual bool Enabled
		{
			get
			{
				return m_Active.Value;
			}
			set
			{
				BoolReference active = m_Active;
				bool value2 = (base.enabled = value);
				active.Value = value2;
			}
		}

		public virtual void SetDamageMultiplier(float multiplier)
		{
			DamageMultiplier = multiplier;
		}

		protected void PlaySound(AudioClip newSound)
		{
			if ((bool)m_audio && !playingSound && base.gameObject.activeInHierarchy)
			{
				playingSound = true;
				m_audio.clip = newSound;
				m_audio.Play();
				playingSound = false;
			}
		}

		protected virtual bool MissAttack()
		{
			bool num = (float)m_MissChance >= Random.value;
			if (num)
			{
				OnAttackMissed.Invoke();
			}
			return num;
		}

		protected void CheckAudioSource()
		{
			if (!m_audio)
			{
				m_audio = base.gameObject.FindComponent<AudioSource>();
			}
			if (!m_audio)
			{
				m_audio = base.gameObject.AddComponent<AudioSource>();
			}
			m_audio.spatialBlend = 1f;
		}

		protected IEnumerator I_CalculateDirection(Collider Trigger)
		{
			Vector3 lastPos = Trigger.bounds.center;
			Color debColor = (Color.red + Color.yellow) / 2f;
			debColor.a = 0.7f;
			while (CanCauseDamage)
			{
				Vector3 normalized = (Trigger.bounds.center - lastPos).normalized;
				if (normalized != Vector3.zero)
				{
					Direction = normalized;
				}
				lastPos = Trigger.bounds.center;
				if (debug)
				{
					MDebug.Draw_Arrow(Trigger.bounds.center, Direction, debColor, 0.5f);
				}
				yield return null;
			}
		}

		public virtual bool IsInvalid(Collider damagee)
		{
			if (Tags != null && Tags.Length != 0 && !damagee.gameObject.HasMalbersTagInParent(Tags))
			{
				return true;
			}
			if (damagee.isTrigger && TriggerInteraction == QueryTriggerInteraction.Ignore)
			{
				return true;
			}
			if (!MTools.Layer_in_LayerMask(damagee.gameObject.layer, Layer))
			{
				return true;
			}
			if ((bool)dontHitOwner && Owner != null && damagee.transform.IsChildOf(Owner.transform))
			{
				return true;
			}
			return false;
		}

		protected virtual bool TryDamage(IMDamage damagee, StatModifier stat)
		{
			if (damagee != null)
			{
				damagee.LastForceMode = forceMode;
				if (!stat.IsNull)
				{
					StatModifier stat2 = CheckCriticalCheckMultiplier(stat);
					damagee.ReceiveDamage(Direction, HitPosition, Owner, stat2, IsCritical, react.Value, CustomReaction, pureDamage.Value, element);
					Debugging("Do Damage to [" + damagee.Damagee.name + "]", damagee.Damagee);
					return true;
				}
			}
			return false;
		}

		protected void TryHitEffect(Collider col, Vector3 DamageCenter, IMDamage damagee)
		{
			if ((col is MeshCollider && !(col as MeshCollider).convex) || col is TerrainCollider)
			{
				return;
			}
			HitPosition = col.ClosestPoint(DamageCenter);
			HitRotation = Quaternion.FromToRotation(Vector3.up, col.bounds.center - DamageCenter);
			OnHitPosition.Invoke(HitPosition);
			if (debug)
			{
				MDebug.DrawWireSphere(HitPosition, Color.red, 0.175f, 1f);
			}
			GameObject gameObject = HitEffect;
			AudioClipReference sound = hitSound;
			if (damagee != null && hitEffects != null && hitEffects.Count > 0)
			{
				EffectType effectType = hitEffects.Find((EffectType x) => x.surface == damagee.Surface);
				if (effectType != null)
				{
					if (effectType.effect.Value != null)
					{
						gameObject = effectType.effect.Value;
					}
					if (effectType.sound != null)
					{
						sound = effectType.sound;
					}
				}
			}
			if (gameObject != null)
			{
				if (gameObject.IsPrefab())
				{
					GameObject gameObject2 = Object.Instantiate(gameObject, HitPosition, HitRotation);
					CheckHitEffect(gameObject2);
					if (DestroyHitEffect > 0f)
					{
						Object.Destroy(gameObject2, DestroyHitEffect);
					}
				}
				else
				{
					gameObject.transform.parent = null;
					gameObject.transform.SetPositionAndRotation(HitPosition, HitRotation);
					CheckHitEffect(gameObject);
				}
			}
			if (m_audio != null)
			{
				PlaySound(sound.Value);
			}
			OnHit.Invoke(col.transform);
		}

		protected void CheckHitEffect(GameObject hit)
		{
			MDamager component = hit.GetComponent<MDamager>();
			if ((bool)component)
			{
				component.Owner = Owner;
				component.Layer = Layer;
				component.TriggerInteraction = TriggerInteraction;
			}
			if (!hit.IsPrefab())
			{
				hit.SetActive(value: false);
				hit.SetActive(value: true);
			}
		}

		protected virtual bool TryDamage(GameObject other, StatModifier stat)
		{
			return TryDamage(other.FindInterface<IMDamage>(), stat);
		}

		public virtual void DoDamage(bool value, int profileIndex)
		{
			if (Profiles != null && profileIndex != CurrentProfileIndex)
			{
				if (profileIndex == 0)
				{
					DefaultProfile.Modify(this);
					CurrentProfileIndex = 0;
					OnProfileChanged.Invoke(CurrentProfileIndex);
					Debugging("Setting Default Profile", this);
				}
				else if (profileIndex <= Profiles.Count)
				{
					Profiles[profileIndex - 1].Modify(this);
					CurrentProfileIndex = profileIndex;
					OnProfileChanged.Invoke(CurrentProfileIndex);
					Debugging($"Setting Profile {CurrentProfileIndex}", this);
				}
			}
		}

		protected void TryStopAnimator()
		{
			if (animator != null && C_StopAnim == null)
			{
				C_StopAnim = C_StopAnimator();
				StartCoroutine(C_StopAnim);
			}
		}

		protected IEnumerator C_StopAnimator()
		{
			animator.speed = AnimatorSpeed;
			yield return new WaitForSeconds(AnimatorStopTime.Value);
			if ((bool)animator)
			{
				animator.speed = defaultAnimatorSpeed;
			}
			C_StopAnim = null;
		}

		protected bool TryInteract(GameObject damagee)
		{
			if ((bool)interact)
			{
				IInteractable interactable = damagee.FindInterface<IInteractable>();
				if (interactable != null && interactable.Active)
				{
					return Interact(interactable);
				}
			}
			return false;
		}

		public void Focus(IInteractable item)
		{
			if (item.Active)
			{
				item.CurrentInteractor = this;
				item.Focused = true;
				if (item.Auto)
				{
					Interact(item);
				}
			}
		}

		public void UnFocus(IInteractable item)
		{
			if (item != null)
			{
				item.CurrentInteractor = this;
				item.Focused = false;
				item.CurrentInteractor = null;
			}
		}

		public virtual bool Interact(IInteractable interactable)
		{
			if (interactable != null)
			{
				Debugging("Interact with <B>[" + interactable.Owner.name + "]</B>", interactable.Owner);
				if (interactable.Interact(this))
				{
					OnHitInteractable.Invoke(interactable.Index);
					return true;
				}
				return false;
			}
			return false;
		}

		public virtual void Restart()
		{
		}

		protected virtual bool TryPhysics(Rigidbody rb, Collider col, Vector3 Origin, float force)
		{
			if ((bool)rb && force > 0f)
			{
				Direction *= force;
				if ((bool)col)
				{
					Vector3 vector = col.ClosestPoint(Origin);
					rb.AddForceAtPosition(Direction, vector, forceMode);
					if (debug)
					{
						MDebug.DrawWireSphere(vector, Color.red, 0.1f, 2f);
						MDebug.Draw_Arrow(vector, Direction, Color.red, 2f);
					}
				}
				else
				{
					rb.AddForce(Direction, forceMode);
				}
				Debugging("Apply Force to [" + rb.name + "]", this);
				return true;
			}
			return false;
		}

		public virtual void SetOwner(GameObject owner)
		{
			Owner = owner;
		}

		public virtual void SetOwner(Transform owner)
		{
			Owner = owner.gameObject;
		}

		protected virtual StatModifier CheckCriticalCheckMultiplier(StatModifier mod)
		{
			IsCritical = (float)m_cChance > Random.value;
			StatModifier statModifier = new StatModifier(mod);
			if (IsCritical && CriticalChance > 0f)
			{
				statModifier.Value = mod.Value * CriticalMultiplier;
			}
			statModifier.MinValue.Value *= DamageMultiplier;
			statModifier.MaxValue.Value *= DamageMultiplier;
			DamageMultiplier = 1f;
			return statModifier;
		}

		protected void Find_Owner()
		{
			if (Owner == null)
			{
				Owner = base.transform.root.gameObject;
			}
			MTools.SetDirty(this);
		}

		protected void Find_Animator()
		{
			if (animator == null)
			{
				animator = base.gameObject.FindComponent<Animator>();
			}
			MTools.SetDirty(this);
		}

		protected void Clear_Animator()
		{
			animator = null;
			MTools.SetDirty(this);
		}

		public virtual void Stat_SetMaxValue(float value)
		{
			statModifier.MaxValue = value;
		}

		public virtual void Stat_SetMinValue(float value)
		{
			statModifier.MinValue = value;
		}

		protected virtual void SetDefaultProfile()
		{
			DefaultProfile = GetProfile();
		}

		internal virtual DamagerProfile GetProfile()
		{
			return new DamagerProfile
			{
				Name = "Default",
				CustomReaction = CustomReaction,
				element = element,
				forceMode = forceMode,
				interact = new BoolReference(interact),
				react = new BoolReference(react),
				interactorID = new IntReference(interactorID),
				maxForce = new FloatReference(m_Force),
				minForce = new FloatReference(minForce),
				m_cChance = new FloatReference(m_cChance),
				cMultiplier = new FloatReference(cMultiplier),
				m_HitEffect = m_HitEffect,
				pureDamage = new BoolReference(pureDamage),
				statModifier = new StatModifier(statModifier),
				modify = (DamagerProfile.DamageProfileModif)(-1)
			};
		}

		protected virtual void SetProfile(DamagerProfile newProfile)
		{
			newProfile.Modify(this);
		}

		public void Debugging(string value, Object obj, string m_color = "yellow")
		{
		}
	}
}
