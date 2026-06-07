using System;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public abstract class MachineBase : FurnitureInteractor, IMachine, IManageableFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IContextActor
	{
		[SerializeField]
		[BoxGroup("State Machine Settings")]
		[Space(10f)]
		public EUsableFurnituresTypes UsableFurnituresTypes;

		[SerializeField]
		[BoxGroup("State Machine Settings")]
		public EMachinePowerState MachinePowerState;

		[SerializeField]
		[BoxGroup("Sounds Settings")]
		[Space(10f)]
		public MachineSoundsScriptableObject SFXMachineList;

		[SerializeField]
		[HideInInspector]
		public bool machineWillBeDestroyed;

		[SerializeField]
		[HideInInspector]
		public bool doACycle;

		private bool _gameWasInPause;

		protected Sequence MachineBaseProcessSequence;

		protected Sequence MachineBaseUseSequence;

		protected Agent _victim;

		private Vector3 _droppingPointsCoords;

		private float _riskDeathPercent;

		private float _tmpStillAlivePercent;

		private Addressable<PrestigeUIStatsSO> _humanDrainedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/DrainedHumans.asset");

		public static readonly Func<MachineBase, bool> IsOn = (MachineBase machine) => machine.MachinePowerState == EMachinePowerState.On;

		public static readonly Func<MachineBase, bool> IsNotLoaded = (MachineBase machine) => !machine.HasAVictim;

		[field: SerializeField]
		[field: BoxGroup("Base Settings")]
		[field: Space(10f)]
		public UsableFurnituresCategoriesSO UsableFurnitureCategoryData { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("State Machine Settings")]
		public EMachineProductionMode MachineProductionMode { get; set; }

		[field: SerializeField]
		[field: BoxGroup("Usable Settings")]
		[field: Space(10f)]
		public bool Usable { get; set; }

		[field: SerializeField]
		[field: BoxGroup("Usable Settings")]
		[field: ShowIf("Usable")]
		public MoveTarget WorkerStation { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Usable Settings")]
		[field: ShowIf("Usable")]
		public MoveTarget Entry { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Usable Settings")]
		[field: ShowIf("Usable")]
		public bool UnloadAfterProcess { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("AI Settings")]
		[field: Space(10f)]
		public AnimKey UseAnimation { get; private set; } = AgentAnim.Use;

		[field: SerializeField]
		[field: BoxGroup("AI Settings")]
		public bool UnloadVictimAfterPlacingTheFurniture { get; set; } = true;

		[field: SerializeField]
		[field: BoxGroup("AI Settings")]
		public bool VictimPanicWhenFurniturePlaced { get; set; }

		[field: SerializeField]
		[field: BoxGroup("AI Settings")]
		public bool UnloadVictimAfterSellingTheFurniture { get; set; } = true;

		[field: SerializeField]
		[field: BoxGroup("AI Settings")]
		public bool VictimPanicWhenFurnitureSold { get; set; }

		[field: SerializeField]
		[field: BoxGroup("AI Settings")]
		public bool UnloadVictimAfterDestroyingTheFurniture { get; set; } = true;

		[field: SerializeField]
		[field: BoxGroup("AI Settings")]
		public bool VictimPanicWhenFurnitureDestroyed { get; set; }

		[field: SerializeField]
		[field: BoxGroup("Link Component")]
		[field: Space(10f)]
		public MachineUI MachineUI { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Component")]
		public MachineSoundManager MachineSoundManager { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Component")]
		public MachineUpgrade MachineUpgrade { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Component")]
		public MachineTechTree MachineTechTree { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Component")]
		public MachineBloodQuality MachineBloodQuality { get; private set; }

		[field: Inject(false)]
		public BodyDisposalCredibility MachineCredibility { get; }

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		[field: Space(10f)]
		public ContextActorData ContextActorData { get; private set; } = new ContextActorData();

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		public MoveTarget LoaderPosition { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		public MoveTarget LoadingPosition { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		public MoveTarget LoadedPosition { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		public bool MovingToLoaded { get; set; } = true;

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		public MoveTarget UnloaderPosition { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		public MoveTarget UnloadPosition { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Link Positions")]
		public bool MovingToUnload { get; set; } = true;

		public Agent Victim => _victim;

		public bool IsAvailable
		{
			get
			{
				if (!_victim)
				{
					return !base.InUse;
				}
				return false;
			}
		}

		public bool HasAVictim => _victim;

		protected float WorkerIntelligenceEffect
		{
			get
			{
				if (!(base.User is Worker worker))
				{
					return 1f;
				}
				return Mathf.Lerp(1.5f, 0.5f, worker.Characteristics.Intellect.UnitInterval);
			}
		}

		public event Action<bool> LoadingStateChanging;

		public event Action<bool> LoadingStateChanged;

		public event Action<bool> ProcessStateChanged;

		public event Action<bool> DisplayOrHideUI;

		public static event Action<EMachinePowerState> PowerStateChanged;

		public static event Action<MachineBase, int> BloodQualityChanged;

		public event Action ProductionModeChanged;

		public event Action<Agent> VictimChanged;

		public static event Action<MachineBase, Agent> VictimHarvested;

		public static event Action<MachineBase, Agent> VictimCaptured;

		public static event Action<MachineBase> CorpseDisposed;

		public static event Action HumanKill;

		public static event Action VictimDead;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			TimeController.OnTimeScaleChanged += CheckTimeScale;
			if ((bool)MachineBloodQuality)
			{
				MachineBloodQuality.BloodyQualityChanged += OnBloodQualityChanged;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			TimeController.OnTimeScaleChanged -= CheckTimeScale;
			if ((bool)MachineBloodQuality)
			{
				MachineBloodQuality.BloodyQualityChanged -= OnBloodQualityChanged;
			}
		}

		private void CheckTimeScale(float timescale)
		{
			if (timescale == 0f)
			{
				OnGamePause();
				_gameWasInPause = true;
			}
			else if (_gameWasInPause)
			{
				_gameWasInPause = false;
				OnGameResume();
			}
		}

		private void OnBloodQualityChanged(int value)
		{
			MachineBase.BloodQualityChanged?.Invoke(this, value);
		}

		public virtual void SetVictim(Agent victim)
		{
			if (!(_victim == victim))
			{
				_victim = victim;
				this.VictimChanged?.Invoke(_victim);
			}
		}

		public void SetMachinePowerState(EMachinePowerState machinePowerState)
		{
			MachinePowerState = machinePowerState;
			OnMachineSwitchPower(machinePowerState);
			MachineBase.PowerStateChanged?.Invoke(machinePowerState);
		}

		public void SetProductionMode(EMachineProductionMode machineProductionMode)
		{
			if (MachineProductionMode != machineProductionMode)
			{
				MachineProductionMode = machineProductionMode;
				this.ProductionModeChanged?.Invoke();
			}
		}

		public virtual bool LoadCondition(Agent agent)
		{
			if (HasAVictim)
			{
				return false;
			}
			return agent is Worker;
		}

		public virtual bool UsageCondition(Agent agent)
		{
			return HasAVictim;
		}

		public virtual bool UnloadCondition(Agent agent)
		{
			return HasAVictim;
		}

		public virtual Tween LoadPreparation()
		{
			return DOTween.Sequence();
		}

		public Tween LoadVictim(Agent victim)
		{
			if (_victim != null || victim == null)
			{
				return null;
			}
			SetVictim(victim);
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				this.LoadingStateChanging?.Invoke(obj: true);
				_victim.ContextualFSM.SetStateStuck();
			});
			sequence.Append(LoadIn());
			sequence.AppendCallback(delegate
			{
				this.LoadingStateChanged?.Invoke(obj: true);
			});
			return sequence;
		}

		public Tween UseMachine(Agent user)
		{
			MachineBaseUseSequence = DOTween.Sequence();
			MachineBaseUseSequence.Append(ProcessIn());
			MachineBaseUseSequence.AppendCallback(delegate
			{
				if ((bool)MachineUI)
				{
					MachineUI.TrySetIcon(MachineUI.ProgressSprite);
				}
				this.ProcessStateChanged?.Invoke(obj: true);
			});
			MachineBaseUseSequence.Append(Process());
			MachineBaseUseSequence.AppendCallback(delegate
			{
				if ((bool)MachineUI)
				{
					MachineUI.TrySetIcon(MachineUI.DefaultSprite);
				}
				this.ProcessStateChanged?.Invoke(obj: false);
			});
			MachineBaseUseSequence.Append(ProcessOut());
			if (UnloadAfterProcess)
			{
				MachineBaseUseSequence.Append(PrepareVictimForUnload());
			}
			return MachineBaseUseSequence.Play();
		}

		public virtual void UnloadPreparation()
		{
		}

		public Tween PrepareVictimForUnload()
		{
			if (_victim == null)
			{
				return null;
			}
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				this.LoadingStateChanging?.Invoke(obj: false);
			});
			sequence.Append(Unload());
			sequence.AppendCallback(delegate
			{
				_victim.SetVisualActive(value: true);
				_victim.Animator.ReturnToIdle();
				_victim.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Alcohol, 0.5f);
				this.LoadingStateChanged?.Invoke(obj: false);
				OnVictimUnloaded();
			});
			return sequence;
		}

		protected abstract void OnVictimUnloaded();

		protected void AddDrainedStat()
		{
			_humanDrainedStat.Value.AddToCurrentValue(1);
		}

		public void FinalizeUnload()
		{
			OnVictimFullyUnloaded();
		}

		public override void OnFurniturePlaced()
		{
			base.OnFurniturePlaced();
			SetMachinePowerState(EMachinePowerState.On);
			if (HasAVictim)
			{
				_victim.transform.parent = null;
				_victim.transform.position = LoadedPosition.transform.position;
				if (HasAVictim && !(_droppingPointsCoords == base.transform.position) && UnloadVictimAfterPlacingTheFurniture)
				{
					_victim.ActionPlayer.PlayInstantly(new CustomerActionGetUnloaded(this, VictimPanicWhenFurniturePlaced));
				}
			}
		}

		protected override void OnFurniturePickedUp()
		{
			base.OnFurniturePickedUp();
			OnCanceled();
			SetMachinePowerState(EMachinePowerState.Off);
			if ((bool)MachineSoundManager)
			{
				MachineSoundManager.StopAllSFXMachine();
			}
			if (HasAVictim)
			{
				_droppingPointsCoords = base.transform.position;
				_victim.transform.parent = base.gameObject.transform;
			}
		}

		public override void OnFurnitureSold()
		{
			base.OnFurnitureSold();
			if (HasAVictim)
			{
				_victim.transform.parent = null;
				_victim.transform.position = ((_droppingPointsCoords == Vector3.zero) ? base.transform.position : _droppingPointsCoords);
				machineWillBeDestroyed = true;
				if (!_victim.AgentVisual.activeSelf)
				{
					_victim.SetVisualActive(value: true);
				}
				if (UnloadVictimAfterSellingTheFurniture)
				{
					_victim.ActionPlayer.PlayInstantly(new CustomerActionGetUnloaded(this, VictimPanicWhenFurnitureSold));
				}
			}
		}

		public override void OnFurnitureDestroyed()
		{
			base.OnFurnitureDestroyed();
			if (HasAVictim)
			{
				_victim.transform.parent = null;
				_victim.transform.position = ((_droppingPointsCoords == Vector3.zero) ? base.transform.position : _droppingPointsCoords);
				machineWillBeDestroyed = true;
				if (!_victim.AgentVisual.activeSelf)
				{
					_victim.SetVisualActive(value: true);
				}
				if (UnloadVictimAfterDestroyingTheFurniture)
				{
					_victim.ActionPlayer.PlayInstantly(new CustomerActionGetUnloaded(this, VictimPanicWhenFurnitureDestroyed));
				}
			}
		}

		public virtual void OnFurnitureUsageEndUnload()
		{
		}

		protected abstract Sequence LoadIn();

		protected abstract Sequence Unload();

		protected abstract Sequence ProcessIn();

		protected abstract Sequence Process();

		protected abstract Sequence ProcessOut();

		protected virtual void OnVictimFullyUnloaded()
		{
			_victim.Animator.ReturnToIdle();
			if (_victim.ContextualFSM.CurrentStateEquals<ContextualStateStuck>())
			{
				_victim.ContextualFSM.SetStateNormal();
			}
			if ((bool)MachineUpgrade)
			{
				_tmpStillAlivePercent = 100f;
				if (MachineUpgrade.hasARiskToKill)
				{
					switch (MachineProductionMode)
					{
					case EMachineProductionMode.Safe:
						MachineUpgrade.safeRiskValue.TryGetValue(MachineUpgrade.currentLevel, out _riskDeathPercent);
						break;
					case EMachineProductionMode.Normal:
						MachineUpgrade.normalSafeRiskValue.TryGetValue(MachineUpgrade.currentLevel, out _riskDeathPercent);
						break;
					case EMachineProductionMode.Overclocked:
						MachineUpgrade.overclockSafeRiskValue.TryGetValue(MachineUpgrade.currentLevel, out _riskDeathPercent);
						break;
					}
					_tmpStillAlivePercent = UnityEngine.Random.Range(0f, 100f);
				}
				if (_tmpStillAlivePercent <= _riskDeathPercent)
				{
					_victim.Health.ForceDeath();
					MachineBase.HumanKill?.Invoke();
					if (_victim is Customer customer)
					{
						MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(customer.VigilanceMultipliersData.GetVigilanceForKilling(customer), customer, EBone.HeadTop);
					}
					MachineBase.VictimDead?.Invoke();
				}
				else
				{
					_victim.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Alcohol, 0.5f);
					_victim.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
				}
			}
			SetVictim(null);
		}

		protected virtual void OnMachineSwitchPower(EMachinePowerState value)
		{
		}

		protected virtual void OnCanceled()
		{
		}

		protected virtual void OnGamePause()
		{
		}

		protected virtual void OnGameResume()
		{
		}

		protected void InvokeVictimHarvested(Agent victim)
		{
			MachineBase.VictimHarvested?.Invoke(this, victim);
		}

		protected void InvokeVictimCaptured(Agent victim)
		{
			MachineBase.VictimCaptured?.Invoke(this, victim);
		}

		protected void InvokeCorpseDisposed()
		{
			MachineBase.CorpseDisposed?.Invoke(this);
		}

		protected void CallDisplayOrHideUI(bool _value)
		{
			this.DisplayOrHideUI?.Invoke(_value);
		}
	}
}
