using System;
using GameCreator.Runtime.Characters.Animim;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Playables;

namespace GameCreator.Runtime.Characters
{
	[SelectionBase]
	[DisallowMultipleComponent]
	[HelpURL("https://docs.gamecreator.io/gamecreator/characters")]
	[DefaultExecutionOrder(-1)]
	[AddComponentMenu("Game Creator/Characters/Character")]
	public class Character : MonoBehaviour, ISpatialHash
	{
		public enum MovementType
		{
			None = 0,
			MoveToDirection = 1,
			MoveToPosition = 2
		}

		public struct ChangeOptions
		{
			[NonSerialized]
			public MaterialSoundsAsset materials;

			[NonSerialized]
			public RuntimeAnimatorController controller;

			[NonSerialized]
			public Vector3 offset;
		}

		public const float BIG_EPSILON = 0.01f;

		[SerializeField]
		protected bool m_IsPlayer;

		[SerializeField]
		protected TimeMode m_Time;

		[SerializeField]
		protected Busy m_Busy = new Busy();

		[SerializeReference]
		protected CharacterKernel m_Kernel = new CharacterKernel();

		[SerializeField]
		protected AnimimGraph m_AnimimGraph = new AnimimGraph();

		[SerializeField]
		protected InverseKinematics m_InverseKinematics = new InverseKinematics();

		[SerializeField]
		protected Interaction m_Interaction = new Interaction();

		[SerializeField]
		protected Footsteps m_Footsteps = new Footsteps();

		[SerializeField]
		protected Ragdoll m_Ragdoll = new Ragdoll();

		[SerializeField]
		protected Props m_Props = new Props();

		[SerializeField]
		protected Combat m_Combat = new Combat();

		[SerializeField]
		protected Jump m_Jump = new Jump();

		[SerializeField]
		protected Dash m_Dash = new Dash();

		[NonSerialized]
		private bool m_IsDead;

		public Busy Busy => m_Busy;

		public TimeMode Time
		{
			get
			{
				return m_Time;
			}
			set
			{
				m_Time = value;
			}
		}

		[field: NonSerialized]
		public Args Args { get; private set; }

		public bool IsPlayer
		{
			get
			{
				return m_IsPlayer;
			}
			set
			{
				ShortcutPlayer.Change(value ? base.gameObject : null);
				m_IsPlayer = value;
				if (m_IsPlayer)
				{
					this.EventChangeToPlayer?.Invoke();
				}
				else
				{
					this.EventChangeToNPC?.Invoke();
				}
			}
		}

		public bool IsDead
		{
			get
			{
				return m_IsDead;
			}
			set
			{
				if (m_IsDead != value)
				{
					m_IsDead = value;
					if (m_IsDead)
					{
						this.EventDie?.Invoke();
					}
					else
					{
						this.EventRevive?.Invoke();
					}
				}
			}
		}

		public CharacterKernel Kernel => m_Kernel;

		public InverseKinematics IK => m_InverseKinematics;

		public Interaction Interaction => m_Interaction;

		public Footsteps Footsteps => m_Footsteps;

		public Ragdoll Ragdoll => m_Ragdoll;

		public Props Props => m_Props;

		public Combat Combat => m_Combat;

		public Jump Jump => m_Jump;

		public Dash Dash => m_Dash;

		public PlayableGraph AnimationGraph => m_AnimimGraph.Graph;

		public StatesOutput States => m_AnimimGraph.States;

		public GesturesOutput Gestures => m_AnimimGraph.Gestures;

		public float RootMotionPosition => m_AnimimGraph.RootMotionPosition;

		public float RootMotionRotation => m_AnimimGraph.RootMotionRotation;

		public bool CanUseRootMotionPosition
		{
			set
			{
				m_AnimimGraph.UseRootMotionPosition = value;
			}
		}

		public bool CanUseRootMotionRotation
		{
			set
			{
				m_AnimimGraph.UseRootMotionRotation = value;
			}
		}

		public Phases Phases => m_AnimimGraph.Phases;

		public IUnitPlayer Player => m_Kernel?.Player;

		public IUnitMotion Motion => m_Kernel?.Motion;

		public IUnitDriver Driver => m_Kernel?.Driver;

		public IUnitFacing Facing => m_Kernel?.Facing;

		public IUnitAnimim Animim => m_Kernel?.Animim;

		public Vector3 Eyes
		{
			get
			{
				if (Animim.Animator != null && Animim.Animator.isHuman)
				{
					Transform boneTransform = Animim.Animator.GetBoneTransform(HumanBodyBones.Head);
					if (boneTransform != null)
					{
						return boneTransform.position;
					}
				}
				return base.transform.position + Vector3.up * (Motion.Height * 0.5f);
			}
		}

		public Vector3 Crown => base.transform.position + Vector3.up * Motion.Height * 0.5f;

		public Vector3 Feet => base.transform.position - Vector3.up * Motion.Height * 0.5f;

		public event Action EventEnable;

		public event Action EventDisable;

		public event Action EventDestroy;

		public event Action EventBeforeUpdate;

		public event Action EventAfterUpdate;

		public event Action EventBeforeLateUpdate;

		public event Action EventAfterLateUpdate;

		public event Action EventBeforeFixedUpdate;

		public event Action EventAfterFixedUpdate;

		public event Action EventDie;

		public event Action EventRevive;

		public event Action<float> EventLand;

		public event Action<float> EventJump;

		public event Action EventBeforeChangeModel;

		public event Action EventAfterChangeModel;

		public event Action EventChangeToPlayer;

		public event Action EventChangeToNPC;

		protected virtual void Awake()
		{
			Args = new Args(this);
			if (IsPlayer)
			{
				ShortcutPlayer.Change(base.gameObject);
			}
			m_Busy?.OnStartup(this);
			m_Kernel?.OnStartup(this);
			m_AnimimGraph?.OnStartup(this);
			m_Footsteps?.OnStartup(this);
			m_InverseKinematics?.OnStartup(this);
			m_Interaction?.OnStartup(this);
			m_Ragdoll?.OnStartup(this);
			m_Props?.OnStartup(this);
			m_Combat?.OnStartup(this);
			m_Jump?.OnStartup(this);
			m_Dash?.OnStartup(this);
			SpatialHashCharacters.Insert(this);
		}

		protected void Start()
		{
			m_Busy?.AfterStartup(this);
			m_Kernel?.AfterStartup(this);
			m_AnimimGraph?.AfterStartup(this);
			m_Footsteps?.AfterStartup(this);
			m_InverseKinematics?.AfterStartup(this);
			m_Interaction?.AfterStartup(this);
			m_Props?.AfterStartup(this);
			m_Combat?.AfterStartup(this);
			m_Jump?.AfterStartup(this);
			m_Dash?.AfterStartup(this);
		}

		protected virtual void OnDestroy()
		{
			m_Kernel?.OnDispose(this);
			m_AnimimGraph?.OnDispose(this);
			m_Footsteps?.OnDispose(this);
			m_Interaction?.OnDispose(this);
			m_Ragdoll?.OnDispose(this);
			m_Props?.OnDispose(this);
			m_Combat?.OnDispose(this);
			m_Jump?.OnDispose(this);
			m_Dash?.OnDispose(this);
			SpatialHashCharacters.Remove(this);
			this.EventDestroy?.Invoke();
		}

		protected virtual void OnEnable()
		{
			m_Kernel?.OnEnable();
			m_InverseKinematics?.OnEnable();
			m_Footsteps?.OnEnable();
			m_Interaction?.OnEnable();
			m_Ragdoll?.OnEnable();
			m_Props?.OnEnable();
			m_Combat?.OnEnable();
			m_Jump?.OnEnable();
			m_Dash?.OnEnable();
			this.EventEnable?.Invoke();
		}

		protected virtual void OnDisable()
		{
			m_Kernel?.OnDisable();
			m_Footsteps?.OnDisable();
			m_InverseKinematics?.OnDisable();
			m_Interaction?.OnDisable();
			m_Ragdoll?.OnDisable();
			m_Props?.OnDisable();
			m_Combat?.OnDisable();
			m_Jump?.OnDisable();
			m_Dash?.OnDisable();
			this.EventDisable?.Invoke();
		}

		protected virtual void Update()
		{
			this.EventBeforeUpdate?.Invoke();
			m_Kernel?.OnUpdate();
			m_AnimimGraph?.OnUpdate();
			m_Ragdoll?.OnUpdate();
			m_Footsteps?.OnUpdate();
			m_InverseKinematics?.OnUpdate();
			m_Interaction?.OnUpdate();
			this.EventAfterUpdate?.Invoke();
		}

		protected virtual void LateUpdate()
		{
			this.EventBeforeLateUpdate?.Invoke();
			Combat?.OnLateUpdate();
			m_Ragdoll.OnLateUpdate();
			this.EventAfterLateUpdate?.Invoke();
		}

		protected virtual void FixedUpdate()
		{
			this.EventBeforeFixedUpdate?.Invoke();
			m_Kernel?.OnFixedUpdate();
			this.EventAfterFixedUpdate?.Invoke();
		}

		protected virtual void OnDrawGizmosSelected()
		{
			m_Kernel?.OnDrawGizmos(this);
			m_Ragdoll?.OnDrawGizmos(this);
			m_Footsteps?.OnDrawGizmos(this);
			m_InverseKinematics?.OnDrawGizmos(this);
			m_Interaction?.OnDrawGizmos(this);
			m_Combat?.OnDrawGizmos(this);
		}

		public void OnLand(float velocity)
		{
			this.EventLand?.Invoke(velocity);
		}

		public void OnJump(float force)
		{
			this.EventJump?.Invoke(force);
		}

		public GameObject ChangeModel(GameObject prefab, ChangeOptions options)
		{
			if (prefab == null)
			{
				return null;
			}
			this.EventBeforeChangeModel?.Invoke();
			Transform mannequin = Animim.Mannequin;
			if (Animim.Animator != null)
			{
				UnityEngine.Object.Destroy(Animim.Animator.gameObject);
			}
			if (mannequin == null)
			{
				Animim.Mannequin = new GameObject("Mannequin").transform;
				Animim.Mannequin.transform.SetParent(base.transform);
			}
			Vector3 vector = Vector3.down * (Motion.Height * 0.5f);
			Animim.Mannequin.transform.localPosition = vector + options.offset;
			Animim.Mannequin.transform.localRotation = Quaternion.identity;
			Animim.Mannequin.transform.localScale = Vector3.one;
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, Animim.Mannequin);
			gameObject.name = prefab.name;
			Animator animator = gameObject.GetComponentInChildren<Animator>(includeInactive: true);
			if (animator == null)
			{
				animator = gameObject.AddComponent<Animator>();
			}
			Animim.Animator = animator;
			if (Application.isPlaying)
			{
				Animim.ApplyMannequinPosition();
				Animim.ApplyMannequinRotation();
				Animim.ApplyMannequinScale();
			}
			if (animator != null && options.controller != null)
			{
				animator.runtimeAnimatorController = options.controller;
			}
			if (options.materials != null)
			{
				m_Footsteps.ChangeFootstepSounds(options.materials);
			}
			this.EventAfterChangeModel?.Invoke();
			return gameObject;
		}

		private void OnValidate()
		{
			if (m_Busy == null)
			{
				m_Busy = new Busy();
			}
			if (m_Kernel == null)
			{
				m_Kernel = new CharacterKernel();
			}
			if (m_AnimimGraph == null)
			{
				m_AnimimGraph = new AnimimGraph();
			}
			if (m_InverseKinematics == null)
			{
				m_InverseKinematics = new InverseKinematics();
			}
			if (m_Footsteps == null)
			{
				m_Footsteps = new Footsteps();
			}
			if (m_Ragdoll == null)
			{
				m_Ragdoll = new Ragdoll();
			}
			if (m_Props == null)
			{
				m_Props = new Props();
			}
			if (m_Combat == null)
			{
				m_Combat = new Combat();
			}
			if (m_Jump == null)
			{
				m_Jump = new Jump();
			}
			if (m_Interaction == null)
			{
				m_Interaction = new Interaction();
			}
		}
	}
}
