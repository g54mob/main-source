using System;
using System.Collections;
using System.Collections.Generic;
using CTS.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CTS.BBT.AI
{
	public abstract class Agent : CTSBehaviour, IContextActor, IPoolable, IPoolCallbackReceiver, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		public Guid LifeGuid;

		[SerializeField]
		private DecalProjector _blobShadow;

		private Addressable<PrestigeUIStatsSO> _humanCustomerDiedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/HumansKilled.asset");

		private Addressable<PrestigeUIStatsSO> _investigatorDiedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/InvestigatorsKilled.asset");

		private Addressable<PrestigeUIStatsSO> _hunterCustomerDiedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/HunterKilled.asset");

		private readonly HashSet<Crime> _generatedCrimes = new HashSet<Crime>();

		private LockToggle _crimeToggle = new LockToggle();

		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; }

		[field: SerializeField]
		public AgentActionList ActionList { get; private set; }

		PoolGuid IPoolable.PoolGuid { get; set; }

		public Action WasSeen { get; set; }

		[field: Inject(false)]
		public AgentStatistics Statistics { get; }

		[field: Inject(false)]
		public AgentMovement Movement { get; }

		[field: Inject(false)]
		public AgentActionPlayer ActionPlayer { get; }

		[field: Inject(false)]
		public AgentAutonomyCalculator AutonomousActions { get; }

		[field: Inject(false)]
		public ContextualFSM ContextualFSM { get; }

		[field: SerializeField]
		public FSM AgentFSM { get; private set; }

		[field: Inject(false)]
		public AgentObjectHolding ObjectHolding { get; }

		[field: Inject(false)]
		internal AgentFurnitureAssignment FurnitureAssignment { get; }

		[field: Inject(false)]
		internal UnitHealth Health { get; }

		[field: Inject(false)]
		public AgentAnimator Animator { get; }

		[field: Inject(false)]
		public AgentCollider Selection { get; }

		[field: Inject(false)]
		public AudioSource StepsAudioSource { get; }

		[field: Inject(false)]
		public AgentEyesBlinkControler AgentEyesBlinkControler { get; }

		[field: Inject(false)]
		public AgentCaptureHead AgentCaptureHead { get; }

		[field: Inject(false)]
		public AlcoholLevel AlcoholLevel { get; }

		[field: Inject(false)]
		public AgentSatisfaction Satisfaction { get; }

		[field: Inject(false)]
		public CooldownManager Cooldowns { get; }

		[field: InjectScope(EGetScope.Children)]
		[field: Inject(false)]
		public AgentProceduralAnimations ProceduralAnimator { get; private set; }

		[field: Inject(false)]
		public BarVisualObject BarVisualObject { get; }

		[field: Inject(false)]
		public RoomObject RoomObject { get; }

		[field: Inject(false)]
		public RoomDetection RoomDetection { get; }

		[field: Inject(false)]
		public CharacterVisualControler AgentVisualControler { get; protected set; }

		[field: Inject(false)]
		public AgentSkeletonData SkeletonData { get; set; }

		[field: Inject(false)]
		public Vision CrimeVision { get; }

		[field: Inject(false)]
		public AgentVisual Material { get; }

		[field: Inject(false)]
		public VFXManager VFXManager { get; }

		[field: Inject(false)]
		public ReaperTarget ReaperTarget { get; }

		public Transform Transform => base.transform;

		public AudioSource AudioSource { get; private set; }

		public AgentToolUsage Tools { get; set; }

		public AgentTags Tags { get; set; } = AgentTags.Default;

		[field: SerializeField]
		public bool HasDeepVoice { get; set; }

		public bool IsVisible { get; private set; } = true;

		[field: SerializeField]
		public GameObject AgentVisual { get; private set; }

		public abstract int RandomMovementMask { get; }

		public MeshChanger MeshChanger { get; set; }

		public string agentName { get; private set; }

		public string agentFirstName { get; private set; }

		public bool AlreadyNameChanged { get; set; }

		public bool TwitchNameUsed { get; set; }

		public bool IsDead => Health.IsDead;

		public bool IsAlive => Health.IsAlive;

		public bool IsVigilant
		{
			get
			{
				if (!Cooldowns.IsOnCooldown(BBTAgentTags.Oblivious))
				{
					return !Tags.HasTag(EAgentTag.WentInMachine);
				}
				return false;
			}
		}

		public bool IsHuman
		{
			get
			{
				if (!(this is Worker) && this is Customer customer)
				{
					return !customer.IsVampire;
				}
				return false;
			}
		}

		public CharacterData Skin
		{
			get
			{
				return AgentVisualControler.CharacterData;
			}
			set
			{
				AgentVisualControler.RigSelection(value);
			}
		}

		public event Action OnSelected;

		public event Action OnDeselected;

		public static event Action<Agent> EnteringBar;

		public static event Action<Agent> LeavingBar;

		public static event Action<Agent> Died;

		public event Action Spawned;

		public event Action<Agent> Despawned;

		public static event Action<Agent> AgentDespawned;

		protected void InvokeSpawned()
		{
			this.Spawned?.Invoke();
		}

		protected void InvokeDespawned()
		{
			this.Despawned?.Invoke(this);
			Agent.AgentDespawned?.Invoke(this);
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			foreach (Transform child in base.transform.GetChildren())
			{
				AudioSource = child.GetComponent<AudioSource>();
				if ((bool)AudioSource)
				{
					break;
				}
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Selection.SelectableObject.Selected += SelectEvent;
			Selection.SelectableObject.Deselected += DeselectEvent;
			AlcoholLevel.BecameDrunk += OnBecameDrunk;
			AlcoholLevel.BecameSober += OnBecameSober;
			Health.Died += OnDied;
			AgentEyesBlinkControler.CurrentEyesState = AgentEyesBlinkControler.e_eyesState.Normal;
			LifeGuid = Guid.NewGuid();
			if (HasDeepVoice)
			{
				Animator.EnableOverride("Man");
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			ContextualFSM.SetStateNormal();
			Selection.SelectableObject.Selected -= SelectEvent;
			Selection.SelectableObject.Deselected -= DeselectEvent;
			AlcoholLevel.BecameDrunk -= OnBecameDrunk;
			AlcoholLevel.BecameSober -= OnBecameSober;
			Health.Died -= OnDied;
		}

		public void AddCrime(Crime crime)
		{
			if (!_generatedCrimes.Contains(crime))
			{
				_generatedCrimes.Add(crime);
				_crimeToggle.Add(crime);
				crime.WasSeen = (Action)Delegate.Combine(crime.WasSeen, new Action(OnCrimeSeen));
			}
		}

		public void RemoveCrime(Crime crime)
		{
			_crimeToggle.Remove(crime);
			_generatedCrimes.Remove(crime);
			crime.WasSeen = (Action)Delegate.Remove(crime.WasSeen, new Action(OnCrimeSeen));
		}

		private void OnCrimeSeen()
		{
			WasSeen?.Invoke();
		}

		public void SetVisible(bool value)
		{
			if (value != IsVisible)
			{
				IsVisible = value;
				_crimeToggle.SetLock(!IsVisible);
				if (!IsVisible)
				{
					Material.SetOverrideMaterial(CTSSingleton<Materials>.Instance.GetSharedMaterial(MaterialTags.Invisibility));
				}
				else
				{
					Material.SetOverrideMaterial(null);
				}
			}
		}

		private void OnDied()
		{
			AgentEyesBlinkControler.CurrentEyesState = AgentEyesBlinkControler.e_eyesState.StayClose;
			Agent.Died?.Invoke(this);
			if (AgentVisualControler.CharacterData.SubSpecies == ESubSpecies.Investigateur)
			{
				_investigatorDiedStat.Value?.AddToCurrentValue(1);
			}
			else if (AgentVisualControler.CharacterData.SubSpecies == ESubSpecies.Hunter)
			{
				_hunterCustomerDiedStat?.Value.AddToCurrentValue(1);
			}
			else if (IsHuman)
			{
				_humanCustomerDiedStat.Value?.AddToCurrentValue(1);
			}
		}

		private void OnBecameSober()
		{
			Animator.DisableOverride("Drunk");
			Movement.RemoveSpeedModifier("Drunk");
			AgentEyesBlinkControler.IsDrunk = false;
		}

		private void OnBecameDrunk()
		{
			Animator.EnableOverride("Drunk");
			Movement.AddSpeedModifier("Drunk", 0.5f);
			AgentEyesBlinkControler.IsDrunk = true;
		}

		public void UpdateLighting(float target)
		{
			StartCoroutine(Updating(target));
			IEnumerator Updating(float pTarget)
			{
				float origin = 1f - pTarget;
				int id = Shader.PropertyToID("_DebugDissolve");
				for (float time = 0f; time < 1f; time += Time.deltaTime)
				{
					Material.SetFloat(id, Mathf.Lerp(origin, pTarget, time));
					yield return null;
				}
				Material.SetFloat(id, pTarget);
			}
		}

		public virtual void ForceStop()
		{
			FurnitureAssignment.ReleaseSeat();
			FurnitureAssignment.StopUsing();
			ActionPlayer.ForceStopAll();
			Movement.ResetPath();
			Movement.Velocity = Vector3.zero;
			if (!ContextualFSM.CurrentStateEquals<ContextualStateDead>())
			{
				Animator.SetIdleAndPlay(AgentAnim.Idle);
			}
		}

		public void SetSpeed(float speed)
		{
			Movement.SetSpeed(speed);
		}

		public void ResetPath()
		{
			Movement.ResetPath();
		}

		public virtual void SetActive(bool p_value)
		{
			SetVisualActive(p_value);
			AgentFSM.enabled = p_value;
			ContextualFSM.enabled = p_value;
			Selection.Collider.enabled = p_value;
			Selection.Selectable = p_value;
		}

		public void SetVisualActive(bool value)
		{
			if ((bool)AgentVisual)
			{
				AgentVisual.SetActive(value);
			}
			_blobShadow.gameObject.SetActive(value);
		}

		public void SetVisualFormReferenceDispatcher(GameObject visual, AgentProceduralAnimations agentProceduralAnimation)
		{
			AgentVisual = visual;
			ProceduralAnimator = agentProceduralAnimation;
		}

		public void SetName(string firstName, string lastName)
		{
			agentFirstName = firstName;
			agentName = lastName;
		}

		public void TwitchDeleteEvent()
		{
			TwitchNameUsed = true;
		}

		public void GenerateName(Agent agent, EGender gender)
		{
			if ((bool)MonoSingleton<NameGeneratorManager>.Instance)
			{
				string text = (agentName = MonoSingleton<NameGeneratorManager>.Instance.NameDataSO.NeedName(agent, gender).GetLocalizedString());
				agentFirstName = text;
			}
		}

		public virtual void ClearObject()
		{
			InvokeDespawned();
			Pooler.Push(this);
		}

		private void SelectEvent(SelectionMode selectionMode)
		{
			OnAgentSelected();
		}

		protected virtual void OnAgentSelected()
		{
			this.OnSelected?.Invoke();
			MonoSingleton<CameraFollowing>.Instance.Lock(base.transform);
			InterfaceButton.CurrentSelectedAgent = this;
			if ((bool)MonoSingleton<AgentVisualCopy>.Instance)
			{
				MonoSingleton<AgentVisualCopy>.Instance.SetVisual(this);
			}
		}

		private void DeselectEvent(SelectionMode selectionMode)
		{
			OnAgentDeselected();
		}

		protected virtual void OnAgentDeselected()
		{
			this.OnDeselected?.Invoke();
			if (MonoSingleton<CameraFollowing>.InstanceExists())
			{
				MonoSingleton<CameraFollowing>.Instance.Lock(null);
			}
			InterfaceButton.CurrentSelectedAgent = null;
		}

		private void OnDrawGizmos()
		{
		}

		void IPoolCallbackReceiver.OnPulled()
		{
			OnPulledFromPool();
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			OnPushedToPool();
		}

		public float GetSpeedMultiplier()
		{
			if (Statistics.TryGetStatisticValue(EAgentStatistics.Speed, out var statisticValue))
			{
				return statisticValue / 100f;
			}
			return 1f;
		}

		protected virtual void OnPulledFromPool()
		{
		}

		protected virtual void OnPushedToPool()
		{
			Statistics.Paused = false;
			if ((bool)Satisfaction)
			{
				Satisfaction.ApplyAllModifiers();
			}
			SetVisible(value: true);
			_crimeToggle.Clear();
			_generatedCrimes.Clear();
			base.gameObject.RemoveAllTags();
			ObjectHolding.DropObject();
			ProceduralAnimator.DisableGrab();
			AutonomousActions.Paused = false;
			Animator.SetIdle(AgentAnim.Idle);
			SetActive(p_value: true);
			FurnitureAssignment.StopUsing();
		}

		public void SetEnterBarTag()
		{
			Tags.AddTag(EAgentTag.IsInside);
			Agent.EnteringBar?.Invoke(this);
		}

		public void SetLeaveBarTag()
		{
			Tags.AddTag(EAgentTag.Leaving);
			Tags.RemoveTag(EAgentTag.IsInside);
			Agent.LeavingBar?.Invoke(this);
		}
	}
}
