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
	public class BloodyShaker : MachineBase, IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IRepaint
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private int _cycleMinimalCount;

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
		private AnimationClip _loadCharacterAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _unloadCharacterAnimationClip;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animation Settings")]
		private AnimationClip _ScaleUPMachineAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _processMachineAnimationClip;

		[SerializeField]
		[BoxGroup("Animation Settings")]
		private AnimationClip _ScaleDOWNMachineAnimationClip;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Link Component")]
		private Animation _animation;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private StockItemSO _shakedBlood;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private Transform _seatMachine;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private NavMeshObstacle[] _navMeshObstacles;

		private bool _forceStopSuck;

		private float _timerUI;

		private float _processDuration;

		private float _efficiencyTimer;

		private float _efficiencyInterval;

		private WorkerChore _currentChore;

		private int _currentOutOfStockStock;

		private int _currentOutOfStockCapacity;

		public float Timer { get; private set; }

		public int BloodBagsAmountTarget { get; private set; }

		public int BloodBagsGenerated { get; private set; }

		public Vector3 VictimPositionLoaded { get; set; }

		public Quaternion VictimRotationLoaded { get; set; }

		public static event Action<BloodyShaker, StockStack> BloodBagGenerated;

		private static bool ShouldMachineBeUnloaded(MachineBase machine)
		{
			if (!(machine is BloodyShaker bloodyShaker))
			{
				return false;
			}
			if (!bloodyShaker.HasAVictim)
			{
				return false;
			}
			return bloodyShaker._processDuration == 0f;
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
				StartCoroutine(GenerateShakedBlood(Timer));
			}
		}

		public override Tween LoadPreparation()
		{
			Sequence result = DOTween.Sequence();
			EnableOrDisableNavMeshObstacle(value: false);
			return result;
		}

		protected override Sequence LoadIn()
		{
			Sequence sequence = DOTween.Sequence();
			_processDuration = (float)base.MachineUpgrade.CurrentProcessDuration * base.WorkerIntelligenceEffect;
			EnableOrDisableNavMeshObstacle(value: true);
			base.MachineUI.ResetFillArea(0f);
			CallDisplayOrHideUI(_value: true);
			sequence.AppendCallback(delegate
			{
				if ((bool)base.MachineSoundManager)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
				}
				_animation.Play(_ScaleUPMachineAnimationClip.name);
			});
			sequence.AppendInterval(_ScaleUPMachineAnimationClip.length);
			sequence.AppendCallback(delegate
			{
				_victim.Animator.PlayPunctual(AgentAnim.BloodyShakerLoad);
			});
			sequence.AppendInterval(_loadCharacterAnimationClip.length);
			sequence.AppendCallback(delegate
			{
				_victim.transform.parent = _seatMachine.transform;
				_victim.Animator.StartLoop(AgentAnim.BloodyShakerProcess);
			});
			sequence.AppendCallback(delegate
			{
				if ((bool)base.MachineSoundManager)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
				}
				_animation.Play(_ScaleDOWNMachineAnimationClip.name);
			});
			sequence.AppendInterval(_ScaleDOWNMachineAnimationClip.length);
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
					StartCoroutine(GenerateShakedBlood());
				}
			});
			return sequence;
		}

		protected override Sequence ProcessOut()
		{
			return DOTween.Sequence();
		}

		public override void UnloadPreparation()
		{
			_forceStopSuck = true;
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
				EnableOrDisableNavMeshObstacle(value: false);
				_victim.transform.parent = null;
				if ((bool)base.MachineSoundManager)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
				}
				_animation.Play(_ScaleUPMachineAnimationClip.name);
			});
			sequence.AppendInterval(_ScaleUPMachineAnimationClip.length);
			sequence.AppendCallback(delegate
			{
				_victim.Animator.PlayPunctual(AgentAnim.BloodyShakerUnload);
			});
			sequence.AppendInterval(_unloadCharacterAnimationClip.length);
			sequence.AppendCallback(delegate
			{
				_victim.transform.position = base.UnloadPosition.transform.position;
				if ((bool)base.MachineSoundManager)
				{
					base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
				}
				_animation.Play(_ScaleDOWNMachineAnimationClip.name);
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

		private void EnableOrDisableNavMeshObstacle(bool value)
		{
			NavMeshObstacle[] navMeshObstacles = _navMeshObstacles;
			for (int i = 0; i < navMeshObstacles.Length; i++)
			{
				navMeshObstacles[i].enabled = value;
			}
		}

		public void Repaint()
		{
			if (MachinePowerState == EMachinePowerState.On && (bool)_victim)
			{
				_victim.transform.parent = _seatMachine.transform;
				_victim.Animator.StartLoop(AgentAnim.BloodyShakerProcess);
				_victim.transform.position = VictimPositionLoaded;
				_victim.transform.rotation = VictimRotationLoaded;
				CallDisplayOrHideUI(_value: true);
				CreateUnloadChore();
				if (BloodBagsGenerated < BloodBagsAmountTarget)
				{
					StopAllCoroutines();
					StartCoroutine(GenerateShakedBlood(Timer));
					base.MachineUI.RunFillArea((float)BloodBagsGenerated / (float)BloodBagsAmountTarget);
				}
				else
				{
					base.MachineUI.RunFillArea(1f);
				}
			}
		}

		private IEnumerator PowerON()
		{
			_forceStopSuck = false;
			if (base.HasAVictim && !doACycle && BloodBagsGenerated != BloodBagsAmountTarget)
			{
				StartCoroutine(GenerateShakedBlood(Timer));
			}
			yield return null;
		}

		private IEnumerator PowerOFF()
		{
			_forceStopSuck = true;
			yield return null;
		}

		private IEnumerator GenerateShakedBlood(float time = 0f)
		{
			Timer = time;
			doACycle = true;
			if ((bool)base.MachineSoundManager)
			{
				base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[2]);
			}
			bool animationStarted = false;
			while (BloodBagsGenerated < BloodBagsAmountTarget && Stocks.BarStock.GetStockTypeCapacity(Stocks.VampireStockType).HasCapacityFor(1) && !_forceStopSuck)
			{
				float deltaTime = Time.deltaTime;
				_efficiencyTimer += deltaTime;
				if (!animationStarted)
				{
					animationStarted = true;
					_animation.wrapMode = WrapMode.Loop;
					_animation.Play(_processMachineAnimationClip.name);
				}
				if (_efficiencyTimer >= _efficiencyInterval)
				{
					_efficiencyTimer = 0f;
					BloodBagsGenerated++;
					EmoteManager.Play<EmoteBBT>(_emoteAnchor.transform.position, $"<size={_emoteSize}%>{_emoteRef} <size=100%>+1").SetContentColor(_emoteContentColor).SetBackgroundColor(_emoteBackgroundColor)
						.SetRoom(base.Furniture.RoomObject);
					StockStack itemStack = new StockStack(_shakedBlood, 1, (_victim is Customer customer) ? customer.BloodQuality : 5);
					BloodyShaker.BloodBagGenerated?.Invoke(this, itemStack);
					Stocks.TryAdd(ref itemStack);
				}
				base.MachineUI.RunFillArea(_timerUI / _processDuration);
				Timer += deltaTime;
				_timerUI += deltaTime;
				yield return null;
			}
			doACycle = false;
			_processDuration = ((BloodBagsGenerated == BloodBagsAmountTarget) ? 0f : _processDuration);
			_animation.wrapMode = WrapMode.Once;
			if (BloodBagsGenerated > 0)
			{
				InvokeVictimHarvested(_victim);
			}
		}
	}
}
