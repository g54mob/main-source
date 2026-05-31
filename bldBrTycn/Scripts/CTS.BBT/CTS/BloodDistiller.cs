using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Emotes;
using CTS.StockInventory;
using CTS.UI;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class BloodDistiller : MachineBase, IProcessMachine, IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IMachine, IManageableFurniture
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		private int _selfStorageMaxCapacity = 30;

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
		private float _exitDuration = 2f;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animation Settings")]
		private Animator _animator;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _openDoorAnimatorTriggerClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _closeDoorInAnimatorTriggerClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string IdleMachineInAnimatorTrigger = "Idle";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string ProcessAnimatorTrigger = "Process";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string OpenDoorAnimatorTrigger = "OpenDoor";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string CloseDoorAnimatorTrigger = "CloseDoor";

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private StockItemSO _bloodBagSo;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private NavMeshObstacle _navMeshObstacle;

		private bool _victimIsInstalled;

		private bool _forceStopSuck;

		private bool _isInUnloadProcess;

		private float _timerUI;

		private float _processDuration;

		private float _efficiencyTimer;

		private float _efficiencyInterval;

		private StockStack _selfStorageStack;

		private WorkerChore _currentChore;

		public float Timer { get; private set; }

		public int BloodBagsAmountTarget { get; private set; }

		public int BloodBagsGenerated { get; private set; }

		public static event Action<BloodDistiller> ABloodDistiller;

		public static event Action<BloodDistiller, StockStack> BloodBagGenerated;

		public event Action ProcessStarted;

		public event Action ProcessEnded;

		private static bool ShouldMachineBeUnloaded(MachineBase machine)
		{
			if (!(machine is BloodDistiller bloodDistiller))
			{
				return false;
			}
			if (!bloodDistiller.HasAVictim)
			{
				return false;
			}
			return true;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			base.MachineUI.SetupMachineUI(MachineUI.EMachineUIType.ProgressDefine, MachineUI.EMachineClockwiseType.Clockwise, base.MachineUI.ProgressSprite, base.MachineUI._redColor);
			_selfStorageStack.SetupEmptyFrom(_bloodBagSo);
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
			_currentChore?.DestroyChore();
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

		protected override void OnMachineSwitchPower(EMachinePowerState value)
		{
			base.OnMachineSwitchPower(value);
			switch (value)
			{
			case EMachinePowerState.On:
				_forceStopSuck = false;
				if (base.HasAVictim && _victimIsInstalled && !doACycle)
				{
					StartCoroutine(GenerateBlood());
				}
				break;
			case EMachinePowerState.Off:
				if ((bool)base.MachineSoundManager)
				{
					base.MachineSoundManager.StopAllSFXMachine();
				}
				_forceStopSuck = true;
				break;
			}
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData changedData)
		{
			if (!(changedData.StockType != Stocks.VampireStockType) && MachinePowerState != EMachinePowerState.Off && Stocks.BarStock.GetStockTypeCapacity(Stocks.VampireStockType).HasCapacityFor(1) && base.HasAVictim && _victimIsInstalled && !doACycle && BloodBagsGenerated < BloodBagsAmountTarget)
			{
				StartCoroutine(GenerateBlood());
			}
		}

		public override Tween LoadPreparation()
		{
			Sequence sequence = DOTween.Sequence();
			_navMeshObstacle.enabled = false;
			if (!string.IsNullOrEmpty(OpenDoorAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(OpenDoorAnimatorTrigger);
					if ((bool)SFXMachineList)
					{
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
					}
				});
				sequence.AppendInterval(_openDoorAnimatorTriggerClip.length);
			}
			return sequence;
		}

		protected override Sequence LoadIn()
		{
			Sequence sequence = DOTween.Sequence();
			if (!string.IsNullOrEmpty(CloseDoorAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(CloseDoorAnimatorTrigger);
					if ((bool)SFXMachineList)
					{
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
					}
				});
				sequence.AppendInterval(_closeDoorInAnimatorTriggerClip.length);
			}
			_processDuration = (float)base.MachineUpgrade.CurrentProcessDuration * base.WorkerIntelligenceEffect;
			_navMeshObstacle.enabled = true;
			base.MachineUI.ResetFillArea(0f);
			CallDisplayOrHideUI(_value: true);
			_victim.SetVisualActive(value: false);
			_victimIsInstalled = true;
			sequence.AppendCallback(delegate
			{
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
			Sequence result = DOTween.Sequence();
			_forceStopSuck = false;
			ResetValuesBeforeGeneration();
			if (MachinePowerState == EMachinePowerState.On)
			{
				StartCoroutine(GenerateBlood());
			}
			return result;
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
				_isInUnloadProcess = true;
				_forceStopSuck = true;
				_navMeshObstacle.enabled = false;
				_victim.SetVisualActive(value: true);
				_victimIsInstalled = false;
			});
			if (!string.IsNullOrEmpty(OpenDoorAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(OpenDoorAnimatorTrigger);
					if ((bool)SFXMachineList)
					{
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
					}
				});
				sequence.AppendInterval(_openDoorAnimatorTriggerClip.length);
			}
			sequence.AppendCallback(delegate
			{
				_isInUnloadProcess = false;
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
			if (machineWillBeDestroyed)
			{
				return;
			}
			if (!string.IsNullOrEmpty(CloseDoorAnimatorTrigger))
			{
				_animator.SetTrigger(CloseDoorAnimatorTrigger);
				if ((bool)SFXMachineList)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
				}
			}
			_navMeshObstacle.enabled = true;
			CreateLoadChore();
		}

		private void ResetValuesBeforeGeneration()
		{
			BloodBagsAmountTarget = base.MachineUpgrade.CurrentEfficiency;
			_efficiencyInterval = _processDuration / (float)BloodBagsAmountTarget;
			_efficiencyTimer = 0f;
			BloodBagsGenerated = 0;
			_timerUI = 0f;
		}

		private void SetDoCycle(bool value)
		{
			if (value != doACycle)
			{
				doACycle = value;
				if (doACycle)
				{
					this.ProcessStarted?.Invoke();
				}
				else
				{
					this.ProcessEnded?.Invoke();
				}
			}
		}

		public IEnumerator GenerateBlood(float startTime = 0f)
		{
			Timer = startTime;
			SetDoCycle(value: true);
			if ((bool)SFXMachineList)
			{
				base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[2]);
			}
			if (!string.IsNullOrEmpty(ProcessAnimatorTrigger))
			{
				_animator.SetTrigger(ProcessAnimatorTrigger);
			}
			while (BloodBagsGenerated < BloodBagsAmountTarget)
			{
				float deltaTime = Time.deltaTime;
				if (!Stocks.IsAtMaxCapacityWithRestriction(_bloodBagSo) || _selfStorageStack.StackCount < _selfStorageMaxCapacity)
				{
					if (_forceStopSuck)
					{
						if (!_isInUnloadProcess)
						{
							_animator.SetTrigger(IdleMachineInAnimatorTrigger);
						}
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.StopAllSFXMachine();
						}
						SetDoCycle(value: false);
						break;
					}
					_efficiencyTimer += deltaTime;
					if (_efficiencyTimer >= _efficiencyInterval)
					{
						_efficiencyTimer = 0f;
						EmoteManager.Play<EmoteBBT>(_emoteAnchor.transform.position, $"<size={_emoteSize}%>{_emoteRef} <size=100%>+1").SetBackgroundColor(BBTPalette.GetColor(BBTPalette.EmoteRed)).SetContentColor(BBTPalette.GetColor(BBTPalette.EmoteWhite))
							.SetRoom(base.Furniture.RoomObject);
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[3]);
						}
						BloodDistiller.ABloodDistiller?.Invoke(this);
						StockStack stack = new StockStack(_bloodBagSo, 1, _victim.Cast<Customer>().BloodQuality);
						BloodDistiller.BloodBagGenerated?.Invoke(this, stack);
						_selfStorageStack = _selfStorageStack.AddStack(ref stack, 1);
						Stocks.TryAddWithRestriction(ref _selfStorageStack);
						BloodBagsGenerated++;
					}
					base.MachineUI.RunFillArea(_timerUI / _processDuration);
					Timer += deltaTime;
					_timerUI += deltaTime;
					yield return null;
					continue;
				}
				SetDoCycle(value: false);
				_processDuration -= Timer;
				_animator.SetTrigger(IdleMachineInAnimatorTrigger);
				break;
			}
			if ((bool)SFXMachineList)
			{
				base.MachineSoundManager.StopAllSFXMachine();
			}
			if (BloodBagsGenerated == BloodBagsAmountTarget)
			{
				SetDoCycle(value: false);
				_processDuration = 0f;
				_animator.SetTrigger(IdleMachineInAnimatorTrigger);
				CreateUnloadChore();
			}
			if (BloodBagsGenerated > 0)
			{
				InvokeVictimHarvested(_victim);
			}
		}
	}
}
