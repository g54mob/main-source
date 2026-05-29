using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Emotes;
using CTS.StockInventory;
using CTS.UI;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class BloodyWineBarrel : MachineBase, IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
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
		private AnimationClip _customerMachineEnterClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _customerMachineExitClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _openDoorAnimatorTriggerClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _closeDoorAnimatorTriggerClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string IdleMachineInAnimatorTrigger = "Idle";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string OpenMachineInAnimatorTrigger = "OpenMachine";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string CloseMachineInAnimatorTrigger = "CloseMachine";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string ProcessAnimatorTrigger = "Process";

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private StockItemSO _bloodWine;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private NavMeshObstacle _navMeshObstacle;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _bloodVFXGameObject;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _bloodVFXQuadsGameObject;

		private bool _alreadyPump;

		private bool _forceStopSuck;

		private float _timerUI;

		private float _processDuration;

		private float _efficiencyTimer;

		private float _efficiencyInterval;

		private WorkerChore _currentChore;

		public float Timer { get; private set; }

		public int BloodBagsAmountTarget { get; private set; }

		public int BloodBagsGenerated { get; private set; }

		public static event Action<BloodyWineBarrel, StockStack> BloodBagGenerated;

		private static bool ShouldMachineBeUnloaded(MachineBase machine)
		{
			if (!(machine is BloodyWineBarrel bloodyWineBarrel))
			{
				return false;
			}
			if (!bloodyWineBarrel.HasAVictim)
			{
				return false;
			}
			return bloodyWineBarrel._processDuration == 0f;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
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

		public override void OnFurniturePlaced()
		{
			base.OnFurniturePlaced();
			if (!base.HasAVictim)
			{
				_animator.SetTrigger(OpenMachineInAnimatorTrigger);
				if ((bool)SFXMachineList)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
				}
			}
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
				StartCoroutine(GenerateBloodWine());
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
			sequence.AppendCallback(delegate
			{
				_victim.Animator.PlayPunctualInstantly(AgentAnim.BloodyWineBarrelCustomerEnter);
			});
			sequence.AppendInterval(1.5f);
			_processDuration = (float)base.MachineUpgrade.CurrentProcessDuration * base.WorkerIntelligenceEffect;
			_navMeshObstacle.enabled = true;
			base.MachineUI.ResetFillArea(0f);
			CallDisplayOrHideUI(_value: true);
			if (!string.IsNullOrEmpty(CloseMachineInAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(CloseMachineInAnimatorTrigger);
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
				});
				sequence.AppendInterval(_closeDoorAnimatorTriggerClip.length);
			}
			sequence.AppendCallback(delegate
			{
				_victim.SetVisualActive(value: false);
			});
			sequence.AppendCallback(delegate
			{
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
					StartCoroutine(GenerateBloodWine());
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
					if ((bool)SFXMachineList)
					{
						base.MachineSoundManager.StopAllSFXMachine();
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
					}
					_animator.SetTrigger(OpenMachineInAnimatorTrigger);
				});
				sequence.AppendInterval(1f);
				sequence.AppendCallback(delegate
				{
					_victim.Animator.PlayPunctual(AgentAnim.BloodyWineBarrelCustomerExit);
				});
				sequence.AppendInterval(0.2f);
				sequence.AppendCallback(delegate
				{
					_victim.SetVisualActive(value: true);
				});
			}
			sequence.AppendInterval(1f);
			return sequence;
		}

		protected override void OnVictimUnloaded()
		{
			AddDrainedStat();
		}

		protected override void OnVictimFullyUnloaded()
		{
			base.OnVictimFullyUnloaded();
			_navMeshObstacle.enabled = true;
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
					StartCoroutine(GenerateBloodWine());
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

		public void ResetSave()
		{
			if (!_victim)
			{
				_animator.SetTrigger(OpenMachineInAnimatorTrigger);
				return;
			}
			_animator.SetTrigger(CloseMachineInAnimatorTrigger);
			_alreadyPump = true;
			_bloodVFXQuadsGameObject.SetActive(value: true);
		}

		public IEnumerator GenerateBloodWine(float startTime = 0f)
		{
			Timer = startTime;
			doACycle = true;
			if ((bool)SFXMachineList)
			{
				base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[2]);
			}
			if (!string.IsNullOrEmpty(ProcessAnimatorTrigger))
			{
				_animator.SetTrigger(ProcessAnimatorTrigger);
			}
			if ((bool)_bloodVFXGameObject)
			{
				_bloodVFXGameObject.SetActive(value: true);
			}
			if (!_alreadyPump)
			{
				_alreadyPump = true;
				_bloodVFXQuadsGameObject.SetActive(value: true);
			}
			while (BloodBagsGenerated < BloodBagsAmountTarget)
			{
				float deltaTime = Time.deltaTime;
				if (!Stocks.IsAtMaxCapacityWithRestriction(_bloodWine))
				{
					if (_forceStopSuck)
					{
						_animator.SetTrigger(IdleMachineInAnimatorTrigger);
						if ((bool)SFXMachineList)
						{
							base.MachineSoundManager.StopAllSFXMachine();
						}
						doACycle = false;
						break;
					}
					_efficiencyTimer += deltaTime;
					if (_efficiencyTimer >= _efficiencyInterval)
					{
						_efficiencyTimer = 0f;
						EmoteManager.Play<EmoteBBT>(_emoteAnchor.transform.position, $"<size={_emoteSize}%>{_emoteRef} <size=100%>+1").SetBackgroundColor(BBTPalette.GetColor(BBTPalette.EmoteRed)).SetContentColor(BBTPalette.GetColor(BBTPalette.EmoteWhite))
							.SetRoom(base.Furniture.RoomObject);
						StockStack itemStack = new StockStack(_bloodWine, 1, (_victim is Customer customer) ? customer.BloodQuality : 5);
						BloodyWineBarrel.BloodBagGenerated?.Invoke(this, itemStack);
						Stocks.TryAdd(ref itemStack);
						BloodBagsGenerated++;
					}
					base.MachineUI.RunFillArea(_timerUI / _processDuration);
					Timer += deltaTime;
					_timerUI += deltaTime;
					yield return null;
					continue;
				}
				doACycle = false;
				_processDuration -= Timer;
				_animator.SetTrigger(IdleMachineInAnimatorTrigger);
				break;
			}
			if ((bool)_bloodVFXGameObject)
			{
				_bloodVFXGameObject.SetActive(value: false);
			}
			if (BloodBagsGenerated == BloodBagsAmountTarget)
			{
				doACycle = false;
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
