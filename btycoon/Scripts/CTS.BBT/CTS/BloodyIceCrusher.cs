using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Emotes;
using CTS.StockInventory;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class BloodyIceCrusher : MachineBase, IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Feedback Settings")]
		private GameObject _emoteAnchor;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private string _emoteRef;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private float _emoteSize;

		[SerializeField]
		[BoxGroup("Feedback Settings")]
		private Color _emoteBackgroundColor;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Waypoints Settings")]
		private float ExitDuration = 2f;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animation Settings")]
		private Animator _animator;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _loadMachineAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _unloadMachineAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimKey[] _frozenAnimations;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string OpenMachineInAnimatorTrigger;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string CloseMachineInAnimatorTrigger = "CloseMachine";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string ProcessInAnimatorTrigger = "ProcessIn";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string ProcessAnimatorTrigger = "Process";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string ProcessOutAnimatorTrigger = "ProcessOut";

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private StockItemSO _bloodSorbet;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private NavMeshObstacle _navMeshObstacle;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _smokeVFXGameObject;

		private bool _forceStopSuck;

		private float _timerUI;

		private float _processDuration;

		private float _efficiencyTimer;

		private float _efficiencyInterval;

		private WorkerChore _currentChore;

		private ParticleSystem _smokeVFX;

		public ReadOnlyArray<AnimKey> FrozenAnimations => _frozenAnimations;

		public float Timer { get; private set; }

		public int BloodBagsAmountTarget { get; private set; }

		public int BloodBagsGenerated { get; private set; }

		public static event Action<BloodyIceCrusher, StockStack> GranitasGenerated;

		private static bool ShouldMachineBeUnloaded(MachineBase machine)
		{
			if (!(machine is BloodyIceCrusher bloodyIceCrusher))
			{
				return false;
			}
			if (!bloodyIceCrusher.HasAVictim)
			{
				return false;
			}
			return bloodyIceCrusher._processDuration == 0f;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			if ((bool)_smokeVFX)
			{
				_smokeVFX = _smokeVFXGameObject.GetComponent<ParticleSystem>();
			}
			base.MachineUI.SetupMachineUI(MachineUI.EMachineUIType.ProgressDefine, MachineUI.EMachineClockwiseType.Clockwise, base.MachineUI.ProgressSprite, base.MachineUI._redColor);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CreateLoadChore();
			Stocks.BarStock.StockChanged += OnStockChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		public override void OnFurnitureDestroyed()
		{
			base.MachineSoundManager.StopAllSFXMachine();
			base.OnFurnitureDestroyed();
			DestroyChore();
		}

		protected override void OnFurniturePickedUp()
		{
			base.MachineSoundManager.StopAllSFXMachine();
			base.OnFurniturePickedUp();
		}

		public void DestroyChore()
		{
			_currentChore?.DestroyChore();
		}

		public void CreateLoadChore()
		{
			CreateChore(new WorkerChoreHub(ChoreCategory.Machines, new ActionHubLoadMachine(this), base.Furniture.RoomObject));
		}

		public void CreateUnloadChore()
		{
			CreateChore(new WorkerChoreUnloadMachine(ChoreCategory.Machines, this, ShouldMachineBeUnloaded));
		}

		private void CreateChore(WorkerChore chore)
		{
			_currentChore?.DestroyChore();
			_currentChore = chore;
			_currentChore.AddContext(this);
			_currentChore.VisibleInContextualMenu = false;
			MonoSingleton<ChoreList>.Instance.AddToList(_currentChore);
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData changedData)
		{
			if (!(changedData.StockType != Stocks.VampireStockType) && MachinePowerState != EMachinePowerState.Off && Stocks.BarStock.GetStockTypeCapacity(Stocks.VampireStockType).HasCapacityFor(1) && base.HasAVictim && !doACycle && BloodBagsGenerated < BloodBagsAmountTarget)
			{
				StartCoroutine(GenerateBloodIceCrushed());
			}
		}

		protected override void OnCanceled()
		{
			if ((bool)base.User)
			{
				base.User.Animator.SetIdleAndPlay(AgentAnim.Idle);
			}
		}

		public override Tween LoadPreparation()
		{
			Sequence result = DOTween.Sequence();
			_navMeshObstacle.enabled = false;
			return result;
		}

		protected override Sequence LoadIn()
		{
			Sequence sequence = DOTween.Sequence();
			_processDuration = (float)base.MachineUpgrade.CurrentProcessDuration * base.WorkerIntelligenceEffect;
			_navMeshObstacle.enabled = true;
			base.MachineUI.ResetFillArea(0f);
			CallDisplayOrHideUI(_value: true);
			if (!string.IsNullOrEmpty(CloseMachineInAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					if (!_smokeVFXGameObject.activeSelf)
					{
						_smokeVFXGameObject.SetActive(value: true);
					}
					if ((bool)_smokeVFX)
					{
						_smokeVFX.Play();
					}
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
					AnimateCloseMachine();
				});
				sequence.AppendInterval(_loadMachineAnimationClip.length * 0.7f);
			}
			sequence.AppendCallback(delegate
			{
				_victim.Animator.PlayPunctual(_frozenAnimations.GetRandom());
				CreateUnloadChore();
				Process();
			});
			return sequence;
		}

		protected override Sequence ProcessIn()
		{
			return DOTween.Sequence();
		}

		protected override Sequence Process()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				_forceStopSuck = false;
				ResetValuesBeforeGeneration();
				if (MachinePowerState == EMachinePowerState.On)
				{
					StartCoroutine(GenerateBloodIceCrushed());
				}
			});
			return sequence;
		}

		protected override Sequence ProcessOut()
		{
			return DOTween.Sequence();
		}

		protected override Sequence Unload()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				CallDisplayOrHideUI(_value: false);
				_forceStopSuck = true;
				_navMeshObstacle.enabled = false;
			});
			if (!string.IsNullOrEmpty(OpenMachineInAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[2]);
					_animator.SetTrigger(OpenMachineInAnimatorTrigger);
				});
				sequence.AppendInterval(_unloadMachineAnimationClip.length + ExitDuration);
			}
			sequence.AppendCallback(delegate
			{
				_victim.Animator.PlayPunctual(AgentAnim.Idle);
				if ((bool)_smokeVFX)
				{
					_smokeVFX.Stop();
				}
			});
			return sequence;
		}

		protected override void OnVictimUnloaded()
		{
			AddDrainedStat();
		}

		protected override void OnVictimFullyUnloaded()
		{
			base.OnVictimFullyUnloaded();
			if (!machineWillBeDestroyed)
			{
				CreateLoadChore();
			}
		}

		protected override void OnMachineSwitchPower(EMachinePowerState value)
		{
			base.OnMachineSwitchPower(value);
			switch (value)
			{
			case EMachinePowerState.On:
				_forceStopSuck = false;
				if (base.HasAVictim && !doACycle)
				{
					StartCoroutine(GenerateBloodIceCrushed());
				}
				break;
			case EMachinePowerState.Off:
				_forceStopSuck = true;
				break;
			}
		}

		private void ResetValuesBeforeGeneration()
		{
			BloodBagsAmountTarget = base.MachineUpgrade.CurrentEfficiency;
			_efficiencyInterval = _processDuration / (float)BloodBagsAmountTarget;
			BloodBagsGenerated = 0;
			_efficiencyTimer = 0f;
			_timerUI = 0f;
		}

		public void AnimateCloseMachine()
		{
			_animator.SetTrigger(CloseMachineInAnimatorTrigger);
		}

		public IEnumerator GenerateBloodIceCrushed(float time = 0f)
		{
			Timer = time;
			doACycle = true;
			while (BloodBagsGenerated < BloodBagsAmountTarget && Stocks.BarStock.GetStockTypeCapacity(Stocks.VampireStockType).HasCapacityFor(1) && !_forceStopSuck)
			{
				float deltaTime = Time.deltaTime;
				_efficiencyTimer += deltaTime;
				if (_efficiencyTimer >= _efficiencyInterval)
				{
					_efficiencyTimer = 0f;
					BloodBagsGenerated++;
					EmoteManager.Play<EmoteBBT>(_emoteAnchor.transform.position, $"<size={_emoteSize}%>{_emoteRef} <size=100%>+1").SetBackgroundColor(_emoteBackgroundColor).SetRoom(base.Furniture.RoomObject);
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
					StockStack itemStack = new StockStack(_bloodSorbet, 1, (_victim is Customer customer) ? customer.BloodQuality : 5);
					BloodyIceCrusher.GranitasGenerated?.Invoke(this, itemStack);
					Stocks.TryAdd(ref itemStack);
				}
				base.MachineUI.RunFillArea(_timerUI / _processDuration);
				Timer += deltaTime;
				_timerUI += deltaTime;
				yield return null;
			}
			doACycle = false;
			_processDuration = ((BloodBagsGenerated == BloodBagsAmountTarget) ? 0f : (_processDuration - Timer));
			if (BloodBagsGenerated > 0)
			{
				InvokeVictimHarvested(_victim);
			}
		}
	}
}
