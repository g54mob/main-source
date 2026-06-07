using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Malbers/Damage/MDamageable")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/mdamageable")]
	public class MDamageable : MonoBehaviour, IMDamage
	{
		[Serializable]
		public class DamagerEvents
		{
			public FloatEvent OnReceivingDamage = new FloatEvent();

			public UnityEvent OnCriticalDamage = new UnityEvent();

			public GameObjectEvent OnDamager = new GameObjectEvent();

			public IntEvent OnElementDamage = new IntEvent();

			public IntEvent OnStatEmpty = new IntEvent();
		}

		public struct DamageData
		{
			public GameObject Damager;

			public GameObject Damagee;

			public StatModifier stat;

			public bool WasCritical;

			public ElementMultiplier Element;

			public readonly float Damage
			{
				get
				{
					if (stat.modify == StatOption.None)
					{
						return 0f;
					}
					return stat.Value;
				}
			}

			public DamageData(GameObject damager, GameObject damagee, StatModifier stat, bool wasCritical, ElementMultiplier element)
			{
				Damager = damager;
				Damagee = damagee;
				this.stat = new StatModifier(stat);
				WasCritical = wasCritical;
				Element = element;
			}
		}

		[Tooltip("Animal Reaction to apply when the damage is done")]
		public Component character;

		[Tooltip("Animal Reaction to apply when the damage is done")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction reaction;

		[Tooltip("Animal Reaction when it receives a critical damage")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction criticalReaction;

		[Tooltip("Reaction sent to the Damager if it hits this Damageable")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction damagerReaction;

		[Tooltip("Type of surface the Damageable is. (Flesh, Metal, Wood,etc)")]
		public SurfaceID surface;

		[Tooltip("The Damageable will ignore the Reaction coming from the Damager. Use this when this Damager Needs to have the Default Reaction")]
		[SerializeField]
		private BoolReference ignoreDamagerReaction = new BoolReference();

		[Tooltip("Stats component to apply the Damage")]
		public Stats stats;

		[Tooltip("Multiplier for the Stat modifier Value. Use this to increase or decrease the final value of the Stat")]
		public FloatReference multiplier = new FloatReference(1f);

		[Tooltip("When Enabled the animal will rotate towards the Damage direction")]
		public BoolReference AlignToDamage = new BoolReference();

		[Tooltip("Only Align to Damage when Movement is Not Detected")]
		public BoolReference OnlyOnMovementZero = new BoolReference(value: true);

		[Tooltip("Time to align to the damage direction")]
		public FloatReference AlignTime = new FloatReference(0.25f);

		[Tooltip("Aligmend curve")]
		public AnimationCurve AlignCurve = new AnimationCurve(MTools.DefaultCurve);

		[Tooltip("Point Forward to align the animal to the Damage, It will rotate around this point")]
		public FloatReference AlignOffset = new FloatReference();

		public MDamageable Root;

		public DamagerEvents events;

		public DamageData LastDamage;

		[Tooltip("Elements that affect the MDamageable")]
		public List<ElementMultiplier> elements = new List<ElementMultiplier>();

		protected string currentProfileName = "Default";

		[Tooltip("The Damageable can Change profiles to Change the way the Animal React to the Damage")]
		public List<MDamageableProfile> profiles = new List<MDamageableProfile>();

		[HideInInspector]
		public int Editor_Tabs1;

		private ICharacterMove characterMove;

		public Transform Transform => base.transform;

		public Vector3 HitDirection { get; set; }

		public Vector3 HitPosition { get; set; }

		public GameObject Damager { get; set; }

		public Collider HitCollider { get; set; }

		public ForceMode LastForceMode { get; set; }

		public SurfaceID Surface
		{
			get
			{
				return surface;
			}
			set
			{
				surface = value;
			}
		}

		public GameObject Damagee => base.gameObject;

		public bool IgnoreDamagerReaction
		{
			get
			{
				return ignoreDamagerReaction;
			}
			set
			{
				ignoreDamagerReaction.Value = value;
			}
		}

		public MDamageableProfile Default { get; set; }

		protected void Start()
		{
			if (stats != null)
			{
				if (character == null && reaction != null)
				{
					character = stats.GetComponent(reaction.ReactionType);
				}
				else
				{
					character = stats.transform;
				}
			}
			Default = new MDamageableProfile("Default", surface, reaction, criticalReaction, damagerReaction, ignoreDamagerReaction, multiplier, AlignToDamage, elements);
			if (profiles == null)
			{
				profiles = new List<MDamageableProfile>();
			}
			if (character != null)
			{
				characterMove = character.GetComponent<ICharacterMove>();
			}
		}

		protected void OnDisable()
		{
			StopAllCoroutines();
		}

		public virtual void Profile_Restore()
		{
			reaction = Default.reaction;
			surface = Default.surface;
			damagerReaction = Default.DamagerReaction;
			multiplier = Default.multiplier;
			AlignToDamage = Default.AlignToDamage;
			elements = Default.elements;
			ignoreDamagerReaction = Default.ignoreDamagerReaction;
			criticalReaction = Default.criticalReaction;
		}

		public virtual MDamageableProfile GetCurrentProfile()
		{
			return new MDamageableProfile
			{
				name = currentProfileName,
				surface = surface,
				AlignToDamage = AlignToDamage,
				DamagerReaction = damagerReaction,
				elements = elements,
				ignoreDamagerReaction = ignoreDamagerReaction,
				multiplier = multiplier,
				reaction = reaction,
				criticalReaction = criticalReaction
			};
		}

		public virtual void Profile_Set(string name)
		{
			if (string.IsNullOrEmpty(name) || name.ToLower() == "default")
			{
				Profile_Restore();
				return;
			}
			int num = profiles.FindIndex((MDamageableProfile p) => p.name == name);
			if (num != -1)
			{
				MDamageableProfile mDamageableProfile = profiles[num];
				currentProfileName = mDamageableProfile.name;
				surface = mDamageableProfile.surface;
				reaction = mDamageableProfile.reaction;
				damagerReaction = mDamageableProfile.DamagerReaction;
				ignoreDamagerReaction = mDamageableProfile.ignoreDamagerReaction;
				multiplier = mDamageableProfile.multiplier;
				AlignToDamage = mDamageableProfile.AlignToDamage;
				elements = mDamageableProfile.elements;
				criticalReaction = mDamageableProfile.criticalReaction;
			}
		}

		public virtual void ReceiveDamage(Vector3 Direction, Vector3 Position, GameObject Damager, StatModifier damage, bool isCritical, bool react, Reaction customReaction, bool pureDamage, StatElement element)
		{
			if (!base.enabled)
			{
				return;
			}
			HitDirection = Direction;
			HitPosition = Position;
			Stat stat = stats.Stat_Get(damage.ID);
			if (stat == null || !stat.Active || stat.IsEmpty || stat.IsImmune)
			{
				return;
			}
			ReactionLogic(isCritical, react, customReaction);
			ElementMultiplier element2 = new ElementMultiplier(element, 1f);
			if (element != null && elements.Count > 0)
			{
				element2 = elements.Find((ElementMultiplier x) => element.ID == x.element.ID);
				if (element2.multiplier != null)
				{
					damage.Value *= element2.multiplier;
					events.OnElementDamage.Invoke(element2.element.ID);
					if ((bool)Root)
					{
						Root.events.OnElementDamage.Invoke(element2.element.ID);
					}
				}
			}
			SetDamageable(Direction, Damager);
			if ((bool)Root)
			{
				Root.SetDamageable(Direction, Damager);
			}
			LastDamage = new DamageData(Damager, base.gameObject, damage, isCritical, element2);
			if ((bool)Root)
			{
				Root.LastDamage = LastDamage;
			}
			if (isCritical)
			{
				events.OnCriticalDamage.Invoke();
				if ((bool)Root)
				{
					Root.events.OnCriticalDamage.Invoke();
				}
			}
			if (!pureDamage)
			{
				damage.Value *= multiplier;
			}
			events.OnReceivingDamage.Invoke(damage.Value);
			events.OnDamager.Invoke(Damager);
			if ((bool)Root)
			{
				Root.events.OnReceivingDamage.Invoke(damage.Value);
				Root.events.OnDamager.Invoke(Damager);
			}
			damage.ModifyStat(stat);
			if (stat.IsEmpty)
			{
				events.OnStatEmpty.Invoke(stat.ID);
			}
			AlignmentLogic(Damager);
		}

		protected virtual void AlignmentLogic(GameObject Damager)
		{
			if (AlignToDamage.Value && (!OnlyOnMovementZero.Value || characterMove == null || !characterMove.MovementDetected))
			{
				AlignToDamageDirection(Damager);
			}
		}

		protected virtual void ReactionLogic(bool isCritical, bool react, Reaction customReaction)
		{
			if (react)
			{
				if (customReaction != null && !IgnoreDamagerReaction)
				{
					if (!customReaction.TryReact(character))
					{
						DoReaction(isCritical);
					}
				}
				else
				{
					DoReaction(isCritical);
				}
			}
			if ((bool)Damager)
			{
				damagerReaction?.React(Damager);
			}
		}

		protected virtual void DoReaction(bool isCritical)
		{
			if (isCritical)
			{
				criticalReaction?.React(character);
			}
			else
			{
				reaction?.React(character);
			}
		}

		protected virtual void AlignToDamageDirection(GameObject Direction)
		{
			if (base.isActiveAndEnabled && !Direction.IsDestroyed())
			{
				StopAllCoroutines();
				StartCoroutine(MTools.AlignLookAtTransform(character.transform, Direction.transform.position, AlignOffset, AlignTime.Value, stats.transform.localScale.y, AlignCurve));
			}
		}

		public virtual void ReceiveDamage(StatID stat, float amount)
		{
			StatModifier damage = new StatModifier
			{
				ID = stat,
				modify = StatOption.SubstractValue,
				Value = amount
			};
			ReceiveDamage(Vector3.forward, Vector3.forward, null, damage, isCritical: false, react: true, null, pureDamage: false, null);
		}

		public virtual void ReceiveDamage(StatID stat, float amount, StatOption modifyStat = StatOption.SubstractValue)
		{
			StatModifier damage = new StatModifier
			{
				ID = stat,
				modify = modifyStat,
				Value = amount
			};
			ReceiveDamage(Vector3.forward, base.transform.position, null, damage, isCritical: false, react: true, null, pureDamage: false, null);
		}

		public virtual void ReceiveDamage(Vector3 Direction, GameObject Damager, StatID stat, float amount, StatOption modifyStat = StatOption.SubstractValue, bool isCritical = false, bool react = true, Reaction customReaction = null, bool pureDamage = false, StatElement element = null)
		{
			StatModifier damage = new StatModifier
			{
				ID = stat,
				modify = modifyStat,
				Value = amount
			};
			ReceiveDamage(Direction, base.transform.position, Damager, damage, isCritical, react, customReaction, pureDamage, element);
		}

		public virtual void ReceiveDamage(Vector3 Direction, GameObject Damager, StatID stat, float amount, bool isCritical = false, bool react = true, Reaction customReaction = null, bool pureDamage = false)
		{
			StatModifier damage = new StatModifier
			{
				ID = stat,
				modify = StatOption.SubstractValue,
				Value = amount
			};
			ReceiveDamage(Direction, base.transform.position, Damager, damage, isCritical, react, customReaction, pureDamage, null);
		}

		public virtual void ReceiveDamage(Vector3 Direction, GameObject Damager, StatModifier damage, bool isCritical, bool react, Reaction customReaction, bool pureDamage)
		{
			ReceiveDamage(Direction, base.transform.position, Damager, damage, isCritical, react, customReaction, pureDamage, null);
		}

		internal void SetDamageable(Vector3 Direction, GameObject Damager)
		{
			HitDirection = Direction;
			this.Damager = Damager;
		}
	}
}
