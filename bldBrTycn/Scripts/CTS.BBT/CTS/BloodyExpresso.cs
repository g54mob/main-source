using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.Emotes;
using CTS.StockInventory;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class BloodyExpresso : MachineBase
	{
		public enum EScreenColor
		{
			Default = 0,
			Blue = 1,
			Orange = 2,
			Red = 3
		}

		public enum EScreenIcon
		{
			PowerIcon = 0,
			CoffeeIcon = 1,
			RepairIcon = 2,
			DeadIcon = 3,
			StockIcon = 4
		}

		[Space(10f)]
		[BoxGroup("Base Settings")]
		public bool SecurityMode;

		[SerializeField]
		[BoxGroup("Base Settings")]
		[MinMaxSlider(10f, 50f)]
		private Vector2 _damagesToTheVictim;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private Color _ledColorOn;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private Color _ledColorOff;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Waypoints Settings")]
		private float EntryDuration = 2f;

		[SerializeField]
		[BoxGroup("Waypoints Settings")]
		private Transform[] UserEntryWaypoints;

		[SerializeField]
		[BoxGroup("Waypoints Settings")]
		private float ProcessDuration = 2f;

		[SerializeField]
		[BoxGroup("Waypoints Settings")]
		private float ExitDuration = 2f;

		[SerializeField]
		[BoxGroup("Waypoints Settings")]
		private Transform[] UserExitWaypoints;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Animations Settings")]
		private Animator _animator;

		[SerializeField]
		[BoxGroup("Animations Settings")]
		private AnimationClip _openCloseMachineAnimationClip;

		[SerializeField]
		[BoxGroup("Animations Settings")]
		[AnimatorParam("_animator")]
		private string OpenMachineInAnimatorTrigger;

		[SerializeField]
		[BoxGroup("Animations Settings")]
		[AnimatorParam("_animator")]
		private string CloseMachineInAnimatorTrigger = "CloseMachine";

		[SerializeField]
		[BoxGroup("Animations Settings")]
		[AnimatorParam("_animator")]
		private string ProcessInAnimatorTrigger = "ProcessIn";

		[SerializeField]
		[BoxGroup("Animations Settings")]
		[AnimatorParam("_animator")]
		private string ProcessAnimatorTrigger = "Process";

		[SerializeField]
		[BoxGroup("Animations Settings")]
		[AnimatorParam("_animator")]
		private string ProcessOutAnimatorTrigger = "ProcessOut";

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private Renderer _led;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private Renderer _humanFeedback;

		private int _damagesApplied;

		private int _totalDamages;

		private int _victimHealth;

		private StockItemSO _coffeeStockItem;

		private Vector3[] waypoints;

		private WorkerChore _currentChore;

		private EScreenIcon _tmpScreenIcon;

		[field: SerializeField]
		[field: BoxGroup("GameObject Links")]
		public DrinkSO CoffeeSo { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("GameObject Links")]
		public DrinkSO BloodyCoffeeSo { get; private set; }

		private static bool ShouldMachineBeUnloaded(MachineBase machine)
		{
			if (!(machine is BloodyExpresso bloodyExpresso))
			{
				return false;
			}
			return bloodyExpresso._victim.Health.CalculateLeftBeforeInjured(bloodyExpresso._victimHealth) < 0;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_coffeeStockItem = CoffeeSo.Recipe.Ingredients[0].ScriptableObject;
			base.MachineUI.SetupMachineUI(MachineUI.EMachineUIType.ProgressDefine, MachineUI.EMachineClockwiseType.CounterClockwise, base.MachineUI.HumanSadSprite, base.MachineUI._redColor, _normalizeValue: true);
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
			_currentChore?.DestroyChore();
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		private void CreateLoadChore()
		{
			CreateChore(new WorkerChoreHub(ChoreCategory.Machines, new ActionHubLoadMachine(this), base.Furniture.RoomObject));
		}

		private void CreateUnloadChore()
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
			CheckCoffeeInStock();
		}

		public override void OnFurniturePlaced()
		{
			base.OnFurniturePlaced();
			if (base.HasAVictim)
			{
				_victim.transform.DOMove(UserExitWaypoints[0].transform.position, 0f);
				PrepareVictimForUnload();
			}
		}

		public override void OnFurnitureDestroyed()
		{
			base.OnFurnitureDestroyed();
			if (base.HasAVictim)
			{
				if (_victim.IsAlive)
				{
					_victim.Health.Damage(_totalDamages, checkRandomDeath: false);
				}
				if (_victim.IsAlive)
				{
					_victim.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Alcohol, 0.5f);
				}
			}
		}

		public override Tween LoadPreparation()
		{
			Sequence sequence = DOTween.Sequence();
			if (!string.IsNullOrEmpty(OpenMachineInAnimatorTrigger))
			{
				base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[0]);
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(OpenMachineInAnimatorTrigger);
				});
				sequence.AppendInterval(_openCloseMachineAnimationClip.length);
			}
			return sequence;
		}

		protected override Sequence LoadIn()
		{
			waypoints = new Vector3[UserEntryWaypoints.Length];
			for (int i = 0; i < UserEntryWaypoints.Length; i++)
			{
				waypoints[i] = UserEntryWaypoints[i].position;
			}
			Sequence sequence = DOTween.Sequence();
			sequence.Append(_victim.transform.DOPath(waypoints, EntryDuration, PathType.Linear, PathMode.TopDown2D)).SetEase(Ease.Linear);
			sequence.AppendCallback(delegate
			{
				_victim.SetVisualActive(value: false);
			});
			if (!string.IsNullOrEmpty(CloseMachineInAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(CloseMachineInAnimatorTrigger);
				});
				sequence.AppendInterval(_openCloseMachineAnimationClip.length);
			}
			_victimHealth = _victim.Health.CurrentHealth;
			_totalDamages = 0;
			Power(EMachinePowerState.On);
			sequence.AppendCallback(CreateUnloadChore);
			base.MachineUI.RunFillArea(_victim.Health.CurrentHealth);
			CallDisplayOrHideUI(_value: true);
			return sequence;
		}

		public override bool UsageCondition(Agent agent)
		{
			if (MachinePowerState == EMachinePowerState.Off)
			{
				return false;
			}
			if (agent is Worker)
			{
				if (base.HasAVictim)
				{
					return CoffeeSo.CanBePrepared();
				}
				return false;
			}
			if (!(agent is Customer customer))
			{
				return false;
			}
			_ = customer.IsVampire;
			if (customer.CanGetDrink(CoffeeSo))
			{
				return CoffeeSo.CanBePrepared();
			}
			return false;
		}

		protected override Sequence ProcessIn()
		{
			Sequence sequence = DOTween.Sequence();
			if (!string.IsNullOrEmpty(ProcessInAnimatorTrigger))
			{
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(ProcessInAnimatorTrigger);
				});
				sequence.AppendInterval(_animator.GetCurrentAnimatorStateInfo(0).length);
			}
			return sequence;
		}

		protected override Sequence Process()
		{
			Sequence sequence = DOTween.Sequence();
			base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[1]);
			sequence.AppendInterval(ProcessDuration * base.WorkerIntelligenceEffect);
			sequence.AppendCallback(delegate
			{
				List<StockStack> stockStacks = new List<StockStack>();
				int currentPrice = BloodyCoffeeSo.GetCurrentPrice();
				if (CoffeeSo.TryGetIngredients(stockStacks))
				{
					Agent user = base.User;
					if ((user is Worker || user is Customer { IsVampire: not false }) ? true : false)
					{
						_damagesApplied = (int)Random.Range(_damagesToTheVictim.x, _damagesToTheVictim.y);
						_totalDamages += _damagesApplied;
						_victimHealth -= _damagesApplied;
					}
					base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Hunger, CoffeeSo.ThirstPercent);
					base.User.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Thirst, CoffeeSo.ThirstPercent);
					DrinkSO drinkSO = null;
					if (base.User is Customer customer2)
					{
						if (customer2.IsVampire)
						{
							drinkSO = BloodyCoffeeSo;
							customer2.SpendMoney(BloodyCoffeeSo.GetCurrentPrice());
							MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, BloodyCoffeeSo.GetCurrentPrice(), TransactionTag.VampireCustomer);
						}
						else
						{
							drinkSO = CoffeeSo;
							customer2.SpendMoney(CoffeeSo.GetCurrentPrice());
							MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, CoffeeSo.GetCurrentPrice(), TransactionTag.HumanCustomer);
						}
					}
					else if (base.User is Worker worker)
					{
						drinkSO = BloodyCoffeeSo;
						worker.PayForDrink(currentPrice);
					}
					if ((bool)drinkSO)
					{
						EmoteManager.Play<EmoteBBT>(base.User.transform.position + Vector3.up * 1.7f, $"${drinkSO.GetCurrentPrice()}").SetRoom(base.User.RoomObject);
					}
					if (MachinePowerState != EMachinePowerState.Off)
					{
						CheckHumanHealth();
					}
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
			CallDisplayOrHideUI(_value: false);
			waypoints = new Vector3[UserExitWaypoints.Length];
			for (int i = 0; i < UserExitWaypoints.Length; i++)
			{
				waypoints[i] = UserExitWaypoints[i].position;
			}
			Sequence sequence = DOTween.Sequence();
			if (!string.IsNullOrEmpty(OpenMachineInAnimatorTrigger))
			{
				base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[3]);
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(OpenMachineInAnimatorTrigger);
				});
				sequence.AppendInterval(_openCloseMachineAnimationClip.length);
			}
			sequence.AppendCallback(delegate
			{
				_victim.transform.rotation = Quaternion.Euler(0f, 90f, 0f) * _victim.transform.rotation;
				_victim.SetVisualActive(value: true);
			});
			sequence.Append(_victim.transform.DOPath(waypoints, ExitDuration, PathType.Linear, PathMode.TopDown2D)).SetEase(Ease.Linear);
			if (!string.IsNullOrEmpty(CloseMachineInAnimatorTrigger))
			{
				sequence.AppendInterval(_openCloseMachineAnimationClip.length);
				sequence.AppendCallback(delegate
				{
					_animator.SetTrigger(CloseMachineInAnimatorTrigger);
				});
			}
			return sequence;
		}

		protected override void OnVictimFullyUnloaded()
		{
			base.OnVictimFullyUnloaded();
			if (_victim.IsAlive)
			{
				_victim.Health.Damage(_totalDamages, checkRandomDeath: false);
			}
			if (_victim.IsAlive)
			{
				_victim.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Alcohol, 0.5f);
			}
			_victim = null;
			CreateLoadChore();
			CheckCoffeeInStock();
		}

		private void KillTheCustomer()
		{
			if ((bool)_victim)
			{
				_totalDamages = _victim.Health.CurrentHealth;
				_victim.ActionPlayer.PlayInstantly(new CustomerActionGetUnloaded(this));
			}
		}

		private void CheckHumanHealth()
		{
			if (!base.HasAVictim)
			{
				return;
			}
			if (base.User is Customer customer)
			{
				if (customer.IsVampire)
				{
					base.MachineUI.RunFillArea(_victimHealth);
				}
			}
			else if (base.User is Worker)
			{
				base.MachineUI.RunFillArea(_victimHealth);
			}
			if (_victimHealth <= 0)
			{
				SetScreen(EScreenColor.Red, EScreenIcon.DeadIcon);
				PrepareVictimForUnload();
			}
			else if (_victimHealth <= 20)
			{
				if (SecurityMode)
				{
					PrepareVictimForUnload();
				}
			}
			else if (_victimHealth <= 50)
			{
				SetScreen(EScreenColor.Orange, EScreenIcon.RepairIcon);
			}
			else if (_victimHealth >= 50)
			{
				SetScreen(EScreenColor.Blue, EScreenIcon.CoffeeIcon);
			}
		}

		private void CheckCoffeeInStock()
		{
			if (MachinePowerState == EMachinePowerState.Off)
			{
				return;
			}
			if (Stocks.GetStockedCount(_coffeeStockItem) > 0)
			{
				if (base.HasAVictim && _victimHealth <= 50)
				{
					CheckHumanHealth();
				}
				else
				{
					SetScreen(EScreenColor.Blue, EScreenIcon.CoffeeIcon);
				}
			}
			else
			{
				SetScreen(EScreenColor.Red, EScreenIcon.StockIcon);
			}
		}

		private void SetScreen(EScreenColor _screenColor, EScreenIcon _screenIcon)
		{
			_humanFeedback.material.SetFloat("_screenColor", (float)_screenColor);
			if (_tmpScreenIcon != _screenIcon)
			{
				_tmpScreenIcon = _screenIcon;
				_humanFeedback.material.SetFloat("_screenIcon", (float)_screenIcon);
				base.MachineSoundManager.CallPlaySFXMachine(SFXMachineList.SoundsList[2]);
			}
		}

		public void Power(EMachinePowerState PowerState)
		{
			MachinePowerState = PowerState;
			if (PowerState == EMachinePowerState.On)
			{
				CheckHumanHealth();
				CheckCoffeeInStock();
				_led.material.SetColor("_EmissionColor", _ledColorOn * 7f);
			}
			else
			{
				_led.material.SetColor("_EmissionColor", _ledColorOff * 7f);
				SetScreen(EScreenColor.Default, EScreenIcon.PowerIcon);
			}
		}

		protected override void OnVictimUnloaded()
		{
		}
	}
}
