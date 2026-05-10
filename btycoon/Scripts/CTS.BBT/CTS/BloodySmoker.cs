using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Emotes;
using CTS.StockInventory;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class BloodySmoker : MachineBase, IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IRepaint
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
		private Color _emoteContentColor;

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
		[AnimatorParam("_animator")]
		private string idleOnNMachineInAnimatorTrigger = "IdleON";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string turnOnMachineInAnimatorTrigger = "TurnON";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string turnOffMachineInAnimatorTrigger = "TurnOFF";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		[AnimatorParam("_animator")]
		private string processMachineInAnimatorTrigger = "Process";

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _loadCharacterAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _unloadCharacterAnimationClip;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private Renderer _smokerMaterial;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		public GameObject machineRotor;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private StockItemSO _smokedBlood;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private NavMeshObstacle _navMeshObstacle;

		private bool _forceStopSuck;

		private float _timerUI;

		private float _processDuration;

		private float _efficiencyTimer;

		private float _efficiencyInterval;

		private float _rotorRotationYValue;

		private WorkerChore _currentChore;

		private int _currentOutOfStockStock;

		private int _currentOutOfStockCapacity;

		public float Timer { get; private set; }

		public int BloodBagsAmountTarget { get; private set; }

		public int BloodBagsGenerated { get; private set; }

		public Vector3 VictimPositionLoaded { get; set; }

		public Quaternion VictimRotationLoaded { get; set; }

		public static event Action<BloodySmoker, StockStack> BloodBagGenerated;

		private static bool ShouldMachineBeUnloaded(MachineBase machine)
		{
			if (!(machine is BloodySmoker bloodySmoker))
			{
				return false;
			}
			if (!bloodySmoker.HasAVictim)
			{
				return false;
			}
			return bloodySmoker._processDuration == 0f;
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
			base.MachineSoundManager.StopAllSFXMachine();
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

		private void CreateLoadChore()
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
			if (!(changedData.StockType != Stocks.VampireStockType) && MachinePowerState != EMachinePowerState.Off && changedData.StockCapacity.HasCapacityFor(1) && base.HasAVictim && !doACycle && BloodBagsGenerated < BloodBagsAmountTarget)
			{
				StartCoroutine(GenerateSmokedBlood(Timer));
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
			sequence.AppendCallback(delegate
			{
				if ((bool)base.MachineSoundManager)
				{
					if (_victim.HasDeepVoice)
					{
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
					}
					else
					{
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
					}
				}
				_victim.Animator.PlayPunctual(AgentAnim.BloodySmokerStart);
			});
			sequence.AppendInterval(_loadCharacterAnimationClip.length);
			sequence.AppendCallback(delegate
			{
				_victim.transform.parent = machineRotor.transform;
				_victim.transform.position = base.LoadedPosition.transform.position;
				_animator.SetTrigger(processMachineInAnimatorTrigger);
				_victim.Animator.StartLoop(AgentAnim.BloodySmokerProcess);
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
					StartCoroutine(GenerateSmokedBlood());
				}
			});
			return sequence;
		}

		protected override Sequence ProcessOut()
		{
			if ((bool)base.MachineSoundManager)
			{
				base.MachineSoundManager.StopAllSFXMachine();
			}
			return DOTween.Sequence();
		}

		public override void UnloadPreparation()
		{
			_forceStopSuck = true;
			machineRotor.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			CallDisplayOrHideUI(_value: false);
		}

		protected override Sequence Unload()
		{
			Sequence sequence = DOTween.Sequence();
			sequence.AppendCallback(delegate
			{
				if (base.MachineUI.IsDisplayed)
				{
					CallDisplayOrHideUI(_value: false);
				}
				_navMeshObstacle.enabled = false;
				_victim.Animator.PlayPunctual(AgentAnim.BloodySmokerEnd);
				if ((bool)base.MachineSoundManager)
				{
					base.MachineSoundManager.StopAllSFXMachine();
					if (_victim.HasDeepVoice)
					{
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[4]);
					}
					else
					{
						base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[5]);
					}
				}
			});
			sequence.AppendInterval(_unloadCharacterAnimationClip.length);
			sequence.AppendCallback(delegate
			{
				_victim.transform.parent = null;
				_victim.transform.position = base.UnloadPosition.transform.position;
				_victim.transform.rotation = base.UnloadPosition.transform.rotation;
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
				StartCoroutine(PowerON());
				break;
			case EMachinePowerState.Off:
				StartCoroutine(PowerOFF());
				break;
			}
		}

		protected override void OnGameResume()
		{
			if ((bool)base.MachineSoundManager)
			{
				base.MachineSoundManager.StopAllSFXMachine();
			}
		}

		private void ResetValuesBeforeGeneration()
		{
			BloodBagsAmountTarget = base.MachineUpgrade.CurrentEfficiency;
			_efficiencyInterval = _processDuration / (float)BloodBagsAmountTarget;
			_efficiencyTimer = 0f;
			BloodBagsGenerated = 0;
			_timerUI = 0f;
		}

		public void Repaint()
		{
			if (MachinePowerState == EMachinePowerState.On)
			{
				if ((bool)_victim)
				{
					machineRotor.transform.localRotation = Quaternion.Euler(0f, _rotorRotationYValue, 0f);
					_victim.transform.parent = machineRotor.transform;
					_victim.transform.position = VictimPositionLoaded;
					_victim.transform.rotation = VictimRotationLoaded;
					_victim.Animator.StartLoop(AgentAnim.BloodySmokerProcess);
					CallDisplayOrHideUI(_value: true);
					CreateUnloadChore();
					if (BloodBagsGenerated < BloodBagsAmountTarget)
					{
						StopAllCoroutines();
						_animator.SetTrigger(processMachineInAnimatorTrigger);
						StartCoroutine(GenerateSmokedBlood(Timer));
						base.MachineUI.RunFillArea((float)BloodBagsGenerated / (float)BloodBagsAmountTarget);
					}
					else
					{
						_animator.SetTrigger(idleOnNMachineInAnimatorTrigger);
						base.MachineUI.RunFillArea(1f);
					}
				}
				else
				{
					_animator.SetTrigger(idleOnNMachineInAnimatorTrigger);
				}
			}
			else
			{
				_animator.SetTrigger(turnOffMachineInAnimatorTrigger);
			}
		}

		private IEnumerator PowerON()
		{
			_forceStopSuck = false;
			if (base.HasAVictim && !doACycle)
			{
				if (BloodBagsGenerated != BloodBagsAmountTarget)
				{
					_animator.SetTrigger(processMachineInAnimatorTrigger);
					StartCoroutine(GenerateSmokedBlood(Timer));
				}
				else
				{
					_animator.SetTrigger(idleOnNMachineInAnimatorTrigger);
				}
			}
			else
			{
				_animator.SetTrigger(turnOnMachineInAnimatorTrigger);
			}
			yield return null;
		}

		private IEnumerator PowerOFF()
		{
			_forceStopSuck = true;
			_animator.SetTrigger(turnOffMachineInAnimatorTrigger);
			yield return null;
		}

		private IEnumerator GenerateSmokedBlood(float time = 0f)
		{
			Timer = time;
			doACycle = true;
			if ((bool)base.MachineSoundManager)
			{
				if (_victim.HasDeepVoice)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[2]);
				}
				else
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[3]);
				}
			}
			while (BloodBagsGenerated < BloodBagsAmountTarget && Stocks.BarStock.GetStockTypeCapacity(Stocks.VampireStockType).HasCapacityFor(1) && !_forceStopSuck)
			{
				float deltaTime = Time.deltaTime;
				_efficiencyTimer += deltaTime;
				_rotorRotationYValue = Timer / _processDuration * 360f;
				machineRotor.transform.localRotation = Quaternion.Euler(0f, _rotorRotationYValue, 0f);
				if (_efficiencyTimer >= _efficiencyInterval)
				{
					_efficiencyTimer = 0f;
					BloodBagsGenerated++;
					EmoteManager.Play<EmoteBBT>(_emoteAnchor.transform.position, $"<size={_emoteSize}%>{_emoteRef} <size=100%>+1").SetContentColor(_emoteContentColor).SetBackgroundColor(_emoteBackgroundColor)
						.SetRoom(base.Furniture.RoomObject);
					StockStack itemStack = new StockStack(_smokedBlood, 1, (_victim is Customer customer) ? customer.BloodQuality : 5);
					BloodySmoker.BloodBagGenerated?.Invoke(this, itemStack);
					Stocks.TryAdd(ref itemStack);
				}
				base.MachineUI.RunFillArea(_timerUI / _processDuration);
				Timer += deltaTime;
				_timerUI += deltaTime;
				yield return null;
			}
			doACycle = false;
			_processDuration = ((BloodBagsGenerated == BloodBagsAmountTarget) ? 0f : _processDuration);
			base.MachineSoundManager.StopAllSFXMachine();
			if (BloodBagsGenerated == BloodBagsAmountTarget && MachinePowerState == EMachinePowerState.On)
			{
				_animator.SetTrigger(idleOnNMachineInAnimatorTrigger);
			}
			if (BloodBagsGenerated > 0)
			{
				InvokeVictimHarvested(_victim);
			}
		}
	}
}
