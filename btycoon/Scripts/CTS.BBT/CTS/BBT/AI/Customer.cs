using System;
using System.Collections.Generic;
using System.Linq;
using CTS.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.DevConsole.Variables;
using CTS.Emotes;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	public sealed class Customer : Agent
	{
		private LockToggle _crimeWitnessToggle;

		[SerializeField]
		public Behaviour[] ToDisableOnHuman;

		[SerializeField]
		public Behaviour[] ToDisableOnVampire;

		[SerializeField]
		private GameObject _deadBodyCrime;

		private Customer _deadBody;

		private SpawnPoint _spawnPoint;

		private static readonly List<DrinkSO> _tempList = new List<DrinkSO>();

		[field: Inject(false)]
		internal CustomerFSM FSM { get; }

		[field: InjectScope(EGetScope.Children)]
		[field: Inject(false)]
		public CrimeWitness CrimeWitness { get; }

		public bool IsVampire => SpawnParameters.IsVampire;

		public bool IsInvestigator => base.Tags.HasTag(EAgentTag.Investigator);

		public bool IsHunter => base.Tags.HasTag(EAgentTag.Hunter);

		public string CustomerStyleName => SpawnParameters.Type.ToString();

		public ESubSpecies CustomerType => SpawnParameters.Type;

		public SimpleToggle Business { get; set; } = new SimpleToggle();

		[field: SerializeField]
		public VigilanceMultipliersData VigilanceMultipliersData { get; private set; }

		public int Credibility => SpawnParameters.Credibility;

		[field: SerializeField]
		public bool Debug { get; private set; }

		[field: SerializeField]
		[field: ReadOnly]
		public CustomerParameters SpawnParameters { get; set; }

		public Worker ControllingVampire { get; private set; }

		public SpawnPoint SpawnPoint
		{
			get
			{
				if (_spawnPoint == null)
				{
					_spawnPoint = CTSSingleton<CustomerSpawner>.Instance.GetRandomSpawnPoint();
				}
				return _spawnPoint;
			}
			set
			{
				_spawnPoint = value;
			}
		}

		public bool IsControlled => ControllingVampire;

		public static CVarBoolReference CVarInfiniteMoney { get; private set; }

		public int BloodQuality { get; private set; }

		public Action<Agent> MemoryWiped { get; set; }

		[field: Header("Path Finding")]
		[field: SerializeField]
		[field: NavArea(true)]
		public int VampireAreaMask { get; private set; }

		[field: SerializeField]
		[field: NavArea(true)]
		public int HumanAreaMask { get; private set; }

		[field: SerializeField]
		[field: NavArea(false)]
		public int VampireFavoriteRoom { get; private set; }

		[field: SerializeField]
		[field: NavArea(false)]
		public int HumanFavoriteRoom { get; private set; }

		[field: SerializeField]
		[field: NavArea(true)]
		public int VampireRandomMovementAreaMask { get; private set; }

		[field: SerializeField]
		[field: NavArea(true)]
		public int HumanRandomMovementAreaMask { get; private set; }

		[field: SerializeField]
		public SituationnalBarks_Customer BarksCustomer { get; private set; }

		public CustomerGroupData GroupData { get; private set; }

		public int GroupIndex { get; private set; }

		public Seat AssignedSeat { get; private set; }

		public CustomerOrder CurrentOrder { get; set; }

		public bool IsGroupLeader => GroupIndex == 0;

		public bool AtTable
		{
			get
			{
				if ((bool)AssignedSeat)
				{
					return base.FurnitureAssignment.CurrentSeat == AssignedSeat;
				}
				return false;
			}
		}

		public int MaxDrinksBeforeLeaving { get; private set; } = 3;

		public int CurrentDrinks { get; set; }

		public int Money { get; private set; }

		public override int RandomMovementMask
		{
			get
			{
				if (!IsVampire)
				{
					return HumanRandomMovementAreaMask;
				}
				return VampireRandomMovementAreaMask;
			}
		}

		public static event Action<Agent, bool> HypnosisStateChanging;

		public static event Action<Customer> SpawnCustomer;

		public static event Func<Currencies, int, int> OnSpendMoney;

		protected override void OnAwake()
		{
			base.OnAwake();
			_crimeWitnessToggle = new LockToggle(CrimeWitness);
			if ((object)CVarInfiniteMoney == null)
			{
				CVarInfiniteMoney = ConsoleVar.GetVariable<CVarBoolReference>("CustomersInfiniteMoney");
			}
		}

		public void Spawn(CustomerParameters data, SpawnPoint spawnPoint, Vector3? moveTarget = null, CharacterData? dataOverride = null)
		{
			CharacterData generateData = dataOverride ?? data.CharacterData;
			SpawnParameters = data;
			base.Statistics.LoadStatistics();
			SpawnPoint = spawnPoint;
			SituationnalBarks_CustomerHuman component = GetComponent<SituationnalBarks_CustomerHuman>();
			SituationnalBarks_CustomerVampire component2 = GetComponent<SituationnalBarks_CustomerVampire>();
			if (SpawnParameters.IsVampire)
			{
				UnityEngine.Object.Destroy(component);
				BarksCustomer = component2;
			}
			else
			{
				UnityEngine.Object.Destroy(component2);
				BarksCustomer = component;
			}
			MaxDrinksBeforeLeaving = UnityEngine.Random.Range(data.MaxDrinksPerLife.x, data.MaxDrinksPerLife.y + 1);
			if ((bool)data.BloodQuality)
			{
				BloodQuality = data.BloodQuality.GetRandomQuality();
			}
			else
			{
				BloodQuality = 5;
			}
			Transform transform = SpawnPoint.transform;
			Vector3 vector = UnityEngine.Random.insideUnitCircle.ToHorizontal3D() * spawnPoint.SpawnRadius + transform.position;
			if (!NavMesh.SamplePosition(vector, out var hit, 1.5f, -1))
			{
				base.transform.SetPositionAndRotation(vector, transform.rotation);
			}
			else
			{
				base.transform.SetPositionAndRotation(hit.position, transform.rotation);
			}
			Money = data.GetStartingMoneyWithDifficulty();
			if ((object)GroupData != null && !GroupData.LeavePoint)
			{
				GroupData.LeavePoint = SpawnPoint.GetGroupDestination();
			}
			for (int i = 0; i < ToDisableOnVampire.Length; i++)
			{
				ToDisableOnVampire[i].enabled = !IsVampire;
			}
			for (int j = 0; j < ToDisableOnHuman.Length; j++)
			{
				ToDisableOnHuman[j].enabled = IsVampire;
			}
			base.gameObject.SetActive(value: true);
			_deadBodyCrime.SetActive(value: false);
			base.RoomObject.TryFindCurrentRoom();
			base.AgentVisualControler.RigSelection(generateData);
			EGender gender = ((UnityEngine.Random.value > 0.75f) ? EGender.NonBinary : ((!base.HasDeepVoice) ? EGender.Female : EGender.Male));
			GenerateName(this, gender);
			if (IsVampire && !base.HasDeepVoice)
			{
				base.Animator.EnableOverride("Vampire");
			}
			else
			{
				base.Animator.DisableOverride("Vampire");
			}
			base.ContextualFSM.SetStateNormal();
			base.Selection.Selectable = false;
			base.Material.SetFloat(Shader.PropertyToID("_DebugDissolve"), 1f);
			base.Movement.OverrideDefaultArea(IsVampire ? VampireAreaMask : HumanAreaMask);
			Customer.SpawnCustomer?.Invoke(this);
			InvokeSpawned();
		}

		public void SetBarks(SituationnalBarks_Customer situationnalBarks)
		{
			BarksCustomer = situationnalBarks;
		}

		protected override void OnPushedToPool()
		{
			base.OnPushedToPool();
			EmoteManagerBBT.Kill(this);
			ClearLivingState();
			if ((bool)base.FurnitureAssignment.CurrentSeat)
			{
				base.FurnitureAssignment.ReleaseSeat();
			}
			if ((bool)GroupData && GroupData.Members.Length == 1)
			{
				CustomerGroups.Push(GroupData);
			}
			GroupData = null;
			CurrentDrinks = 0;
			AssignedSeat = null;
			CurrentOrder = null;
			base.Tags.Clear();
			CustomerManager.RemoveCustomer(this);
			if ((bool)ControllingVampire)
			{
				ClearControllingVampire();
			}
		}

		public void ClearLivingState()
		{
			base.ContextActorData.ClearAssociatedChores();
			CurrentOrder?.Chore?.DestroyChore();
			ClearOrder();
			SeparateFromGroup();
			ReleaseSeat();
			if ((bool)ControllingVampire)
			{
				ClearControllingVampire();
			}
		}

		protected override void OnAgentSelected()
		{
			base.OnAgentSelected();
			MonoSingleton<AgentPanelGroup>.Instance.UpdateAgent(this);
			try
			{
				MonoSingleton<DeveloperEditorCharacterEditor>.Instance.UpdateCurrentAgent(this);
			}
			catch
			{
			}
		}

		protected override void OnAgentDeselected()
		{
			base.OnAgentDeselected();
			MonoSingleton<AgentPanelGroup>.Instance.HidePanel();
			try
			{
				MonoSingleton<DeveloperEditorCharacterEditor>.Instance.CleanUP();
			}
			catch
			{
			}
		}

		public void SetControllingVampire(Worker p_controllingVampire)
		{
			if (ControllingVampire == p_controllingVampire)
			{
				return;
			}
			Customer.HypnosisStateChanging?.Invoke(this, p_controllingVampire);
			if ((bool)p_controllingVampire)
			{
				_crimeWitnessToggle.Lock();
				base.Animator.Events.TriggerVFX(VFXList.HypnosisLoop);
				if (base.SkeletonData.TryGetBone(EBone.Eyes, out var boneTransform) && p_controllingVampire.SkeletonData.TryGetBone(EBone.Eyes, out var boneTransform2))
				{
					base.VFXManager.SetTrailTarget(VFXList.HypnosisSimpleTether, boneTransform2);
					base.VFXManager.Play(VFXList.HypnosisSimpleTether, boneTransform);
				}
			}
			else
			{
				_crimeWitnessToggle.Unlock();
				base.Animator.Events.TriggerStopVFX(VFXList.HypnosisLoop);
				base.VFXManager.Kill(VFXList.HypnosisSimpleTether);
			}
			if (!p_controllingVampire && base.ActionPlayer.CurrentAction != null)
			{
				base.ActionPlayer.CurrentAction.CancelAction("cancelled from controlling vampire");
			}
			ControllingVampire = p_controllingVampire;
			base.Movement.OverrideNavArea(ControllingVampire ? new int?(-1) : ((int?)null));
		}

		public void ClearControllingVampire()
		{
			if (ControllingVampire.ControlledHuman == this)
			{
				ControllingVampire.SetControlledHuman(null);
			}
			else
			{
				SetControllingVampire(null);
			}
		}

		public void SetCrimeState(bool p_active)
		{
			_deadBodyCrime.SetActive(p_active);
		}

		public override void SetActive(bool p_value)
		{
			base.SetActive(p_value);
			if ((bool)_deadBodyCrime)
			{
				_deadBodyCrime.SetActive(p_value && base.Health.IsDead);
			}
		}

		public void SetGroup(CustomerGroupData p_groupData, int p_index)
		{
			GroupData = p_groupData;
			GroupIndex = p_index;
			GroupData.Members[GroupIndex] = this;
		}

		public void SeparateFromGroup()
		{
			if ((object)GroupData != null && GroupData.Count > 1)
			{
				ReleaseSeat();
				List<Customer> list = GroupData.Members.ToList();
				list.Remove(this);
				GroupData.SetMembers(list.ToArray());
				MoveTarget leavePoint = GroupData.LeavePoint;
				GroupData = CustomerGroups.GetOrCreateGroup();
				GroupData.LeavePoint = leavePoint;
				GroupData.SetMembers(this);
			}
		}

		public void AssignSeat(Seat p_seat)
		{
			if ((bool)AssignedSeat && AssignedSeat != p_seat)
			{
				ReleaseSeat();
			}
			AssignedSeat = p_seat;
			AssignedSeat.StartUsing(this);
		}

		public void ReleaseSeat()
		{
			if ((bool)AssignedSeat)
			{
				ClearOrder();
				AssignedSeat.StopUsing();
				AssignedSeat = null;
			}
			if ((bool)GroupData && GroupData.AssignedSeats <= 0)
			{
				GroupData.ReleaseTable();
			}
		}

		public EOrderResult TryGetDrink(out DrinkSO outDrink)
		{
			if (TryGetDrinkFromArray(SpawnParameters.DrinksLiked, out outDrink))
			{
				return EOrderResult.Good;
			}
			if (TryGetDrinkFromArray(SpawnParameters.DrinksNormal, out outDrink))
			{
				return EOrderResult.Normal;
			}
			if (TryGetDrinkFromArray(SpawnParameters.DrinksHate, out outDrink))
			{
				return EOrderResult.Bad;
			}
			return EOrderResult.None;
			bool TryGetDrinkFromArray(IReadOnlyList<DrinkSO> drinks, out DrinkSO outSubDrink)
			{
				_tempList.Clear();
				_tempList.AddRange(drinks);
				while (_tempList.Count > 0)
				{
					DrinkSO drinkSO = _tempList[UnityEngine.Random.Range(0, _tempList.Count)];
					_tempList.Remove(drinkSO);
					if (drinkSO.CanBeServedAtPump && CanGetDrink(drinkSO) && drinkSO.CanBePrepared())
					{
						outSubDrink = drinkSO;
						return true;
					}
				}
				outSubDrink = null;
				return false;
			}
		}

		public bool CanGetDrink(DrinkSO drink)
		{
			int currentPriceWithDifficulty = drink.GetCurrentPriceWithDifficulty();
			if (currentPriceWithDifficulty <= 0)
			{
				return false;
			}
			return Money - currentPriceWithDifficulty >= 0;
		}

		public bool CanGetDrink()
		{
			if (CanGetDrink(SpawnParameters.DrinksLiked))
			{
				return true;
			}
			if (CanGetDrink(SpawnParameters.DrinksNormal))
			{
				return true;
			}
			return CanGetDrink(SpawnParameters.DrinksHate);
		}

		private bool CanGetDrink(DrinkSO[] drinkArray)
		{
			foreach (DrinkSO drink in drinkArray)
			{
				if (CanGetDrink(drink))
				{
					return true;
				}
			}
			return false;
		}

		private bool CanGetDrink(List<DrinkSO> drinkList)
		{
			foreach (DrinkSO drink in drinkList)
			{
				if (CanGetDrink(drink))
				{
					return true;
				}
			}
			return false;
		}

		public void ClearOrder()
		{
			if (CurrentOrder != null)
			{
				CurrentOrder.Clear();
				CurrentOrder = null;
			}
		}

		public void SpendMoney(int p_amount)
		{
			if (!CVarInfiniteMoney.GetCurrentValue())
			{
				Money -= p_amount;
			}
			if (CurrentOrder != null && CurrentOrder.PreparedDrink.TryGetValue(out var outValue))
			{
				EmoteManager.Play<EmoteBBT>(outValue.transform.position, $"${p_amount}").SetRoom(outValue.RoomObject);
			}
			Customer.OnSpendMoney?.Invoke(Currencies.Dollars, p_amount);
		}
	}
}
