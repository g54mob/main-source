#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.EventStaffHired;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class FinanceManager : MustCallDestroy, IGameEventsBase, Interface, IGameEventCallback
	{
		public delegate void PatientChargedForDiagnosisDelegate(Patient patient, Staff staff, Room room, float certaintyIncrement, int amount, int baseAmount);

		public delegate void PatientChargedForTreatmentDelegate(Patient patient, Staff staff, Room room, int amount, int baseAmount);

		public delegate void PatientRefusedToPayForDiagnosisDelegate(Patient patient, Staff staff, Room room, float increment, int amount);

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[SerializeField]
			private int InitialBalance = 1000000;

			public float LocalMarketRateModifier = 1f;

			public int GetInitialBalance()
			{
				if (SandboxSaveManager.CurrentSettings == null)
				{
					return InitialBalance;
				}
				return SandboxSaveManager.CurrentSettings.Balance;
			}
		}

		private class ModifyBalanceParams
		{
			public int Amount;

			public bool ConsiderAsEarned;

			public bool ConsiderAsRegularExpense;

			public Room Room;

			public Vector3? InWorldMessagePosition;
		}

		public Action<int, Vector3?> OnMoneyEarned;

		public Action<int> OnSporadicExpense;

		public Action<int> OnRegularExpense;

		public Action<int, Room> OnMoneyEarnedInRoom;

		public Action<int> OnBalanceUpdated;

		public Action<int> OnMonthlyEnergyBillPaid;

		public Action<int> OnMonthlyWagesPaid;

		public Action<Staff, int> OnStaffPaid;

		public Action<Room, int> OnRoomPurchased;

		public Action<Room, int> OnRoomSold;

		public Action<int> OnMoneyAwarded;

		public Action<int> OnBudgetRefund;

		public Action<Character, FinanceModifier, int, int> OnCharacterChargedForInteraction;

		public PatientChargedForDiagnosisDelegate OnPatientChargedForDiagnosis;

		public PatientChargedForTreatmentDelegate OnPatientChargedForTreatment;

		public Action<Character, int, RoomItem> OnCharacterRefusedToPayForItem;

		public Action<Patient, Staff, Room, int> OnPatientRefusedToPayForTreatment;

		public PatientRefusedToPayForDiagnosisDelegate OnPatientRefusedToPayForDiagnosis;

		private int _balance;

		private int _energyBill;

		private int _energyBillPerUse;

		private readonly Config _config;

		private readonly Level _level;

		private readonly List<Staff> _staffToPay;

		private PriceModifiers _priceModifiers;

		public int Balance
		{
			get
			{
				return _balance;
			}
			set
			{
				_balance = Mathf.Clamp(value, int.MinValue, int.MaxValue);
				OnBalanceUpdated.InvokeSafe(_balance);
			}
		}

		public PriceModifiers PriceModifiers
		{
			get
			{
				if (_priceModifiers == null)
				{
					Logging.Error(LogChannels.Finance, "_priceModifiers == null creating a new instance");
					_priceModifiers = new PriceModifiers();
				}
				return _priceModifiers;
			}
		}

		public int TotalStaffWages
		{
			get
			{
				int num = 0;
				foreach (Staff item in _staffToPay)
				{
					num += item.GetSalary();
				}
				return num;
			}
		}

		public int EnergyBills => _energyBill + _energyBillPerUse;

		public float IncomeMultiplier { private get; set; }

		public float LocalMarketRateModifier
		{
			get
			{
				if (!(IncomeMultiplier > 0f))
				{
					return _config.LocalMarketRateModifier;
				}
				return _config.LocalMarketRateModifier * IncomeMultiplier;
			}
		}

		public bool IsBankrupt => Balance <= _level.Config.FailStateBalanceGameOver;

		public bool CanAfford(int amount)
		{
			if (amount > 0)
			{
				return _balance - amount >= 0;
			}
			return true;
		}

		public FinanceManager(Config config, Level level)
		{
			_config = config;
			_level = level;
			_staffToPay = new List<Staff>();
			_priceModifiers = new PriceModifiers();
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = config.GetInitialBalance()
			});
			level.PostConstruct = (System.Action)Delegate.Combine(level.PostConstruct, new System.Action(PostConstruct));
			Initialise();
		}

		private void Initialise()
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			OnMoneyAwarded = (Action<int>)Delegate.Combine(OnMoneyAwarded, new Action<int>(MoneyAwarded));
			OnBudgetRefund = (Action<int>)Delegate.Combine(OnBudgetRefund, new Action<int>(MoneyAwarded));
			ConsoleCommandsDatabase.RegisterCommand("ModifyBalance", "Changes bank balance by some amount", "ModifyBalance Amount, e.g. ChangeBalance -100", Debug_ModifyBalance);
			ConsoleCommandsDatabase.RegisterCommand("EarnMoney", "Change bank balance by some amount, and counts as earned", "EarnMoney Amount, e.g. EarnMoney -100", Debug_EarnBalance);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			Initialise();
			PostConstruct();
			if (_priceModifiers == null)
			{
				Logging.Error(LogChannels.Finance, "_priceModifiers == null when restoring save, creating a new instance");
				_priceModifiers = new PriceModifiers();
			}
			else if (_priceModifiers.IsCorrupt())
			{
				Logging.Error(LogChannels.Finance, "_priceModifiers is corrupt");
			}
			_staffToPay.RemoveAll((Staff staff) => staff.HasBeenFired());
		}

		private void PostConstruct()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomCancelled = (Action<Room, int>)Delegate.Combine(buildEvents3.OnRoomCancelled, new Action<Room, int>(OnRoomCancelled));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Combine(buildEvents4.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnRoomItemSold = (Action<RoomItem>)Delegate.Combine(buildEvents5.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Combine(buildEvents6.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Combine(buildEvents7.OnRoomItemRequestUpgrade, new Action<RoomItem>(OnRoomItemRequestUpgrade));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnRoomItemCancelUpgrade = (Action<RoomItem>)Delegate.Combine(buildEvents8.OnRoomItemCancelUpgrade, new Action<RoomItem>(OnRoomItemCancelUpgrade));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents9.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents10.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents11.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnRoomItemUpgradeComplete));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents3.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents4.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Combine(characterEvents5.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnStaffStartTeaching = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Combine(characterEvents6.OnStaffStartTeaching, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartTeaching));
			ResearchManager researchManager = _level.ResearchManager;
			researchManager.OnResearchProjectAssigned = (Action<ResearchProject, RoomItem>)Delegate.Combine(researchManager.OnResearchProjectAssigned, new Action<ResearchProject, RoomItem>(OnResearchProjectAssigned));
			LoanManager loanManager = _level.LoanManager;
			loanManager.OnTakeOutLoan = (Action<LoanOffer>)Delegate.Combine(loanManager.OnTakeOutLoan, new Action<LoanOffer>(OnTakeOutLoan));
			LoanManager loanManager2 = _level.LoanManager;
			loanManager2.OnRepayLoan = (Action<LoanOffer>)Delegate.Combine(loanManager2.OnRepayLoan, new Action<LoanOffer>(OnRepayLoan));
			LoanManager loanManager3 = _level.LoanManager;
			loanManager3.OnMonthlyPayment = (Action<int, int>)Delegate.Combine(loanManager3.OnMonthlyPayment, new Action<int, int>(OnMonthlyPayment));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			_level.CharacterEvents.OnStaffHired.AddAndDontSave(this);
		}

		public static int AddBalance(int balance, int amount)
		{
			long num = balance;
			num += amount;
			if (num < int.MinValue)
			{
				num = -2147483648L;
			}
			else if (num > int.MaxValue)
			{
				num = 2147483647L;
			}
			return (int)num;
		}

		private void ModifyBalance(ModifyBalanceParams modifyParams)
		{
			if (modifyParams.Amount == 0 || (_balance <= _level.Config.FailStateBalanceGameOver && !DebugVars.DisableBankruptcyFailure.Value))
			{
				return;
			}
			_balance = AddBalance(_balance, modifyParams.Amount);
			OnBalanceUpdated.InvokeSafe(_balance);
			if (modifyParams.Amount > 0 && modifyParams.ConsiderAsEarned)
			{
				OnMoneyEarned.InvokeSafe(modifyParams.Amount, modifyParams.InWorldMessagePosition);
				if (modifyParams.Room != null)
				{
					modifyParams.Room.OnRevenueEarned(modifyParams.Amount);
					OnMoneyEarnedInRoom.InvokeSafe(modifyParams.Amount, modifyParams.Room);
				}
			}
			if (modifyParams.Amount < 0)
			{
				if (modifyParams.ConsiderAsRegularExpense)
				{
					OnRegularExpense.InvokeSafe(-modifyParams.Amount);
				}
				else
				{
					OnSporadicExpense.InvokeSafe(-modifyParams.Amount);
				}
			}
			if (modifyParams.InWorldMessagePosition.HasValue && _level.InWorldMessages != null)
			{
				_level.InWorldMessages.ShowMessage(StringUtils.FormatCurrency(modifyParams.Amount), modifyParams.InWorldMessagePosition.Value, 2f, (modifyParams.Amount >= 0) ? InWorldMessages.MessageType.Income : InWorldMessages.MessageType.Cost);
			}
		}

		private ConsoleCommandResult Debug_ModifyBalance(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int amount)
			{
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = amount,
					ConsiderAsEarned = false
				});
			}, args);
		}

		private ConsoleCommandResult Debug_EarnBalance(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int amount)
			{
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = amount,
					ConsiderAsEarned = true
				});
			}, args);
		}

		private bool IsCharacterHappyToPay(Character character, int amount, int baseAmount)
		{
			if (GameAlgorithms.IsCharacterHappyToPay(character, amount, baseAmount))
			{
				return true;
			}
			if (_level.InWorldMessages != null)
			{
				_level.InWorldMessages.ShowMessage(ScriptLocalization.Notification.RefusedToPay_CS, character.Position, 2f, InWorldMessages.MessageType.Info);
			}
			return false;
		}

		public void ModifyBalanceFromObjectInteraction(Character character, RoomItem roomItem, FinanceModifier financeModifier, float multiplier)
		{
			int baseAmount;
			int objectInteractionBalanceModification = GetObjectInteractionBalanceModification(financeModifier, multiplier, out baseAmount);
			if (IsCharacterHappyToPay(character, objectInteractionBalanceModification, baseAmount))
			{
				character.MoneySpent += objectInteractionBalanceModification;
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = objectInteractionBalanceModification,
					InWorldMessagePosition = character.Position,
					ConsiderAsEarned = true,
					Room = roomItem.OwningRoom
				});
				OnCharacterChargedForInteraction.InvokeSafe(character, financeModifier, objectInteractionBalanceModification, baseAmount);
			}
			else
			{
				OnCharacterRefusedToPayForItem.InvokeSafe(character, objectInteractionBalanceModification, roomItem);
			}
			_energyBillPerUse += financeModifier.EnergyCost;
		}

		public int GetObjectInteractionBalanceModification(FinanceModifier financeModifier, float multiplier, out int baseAmount)
		{
			int cost = financeModifier.GetCost(multiplier);
			baseAmount = Mathf.CeilToInt((float)cost * LocalMarketRateModifier);
			return baseAmount + _priceModifiers.Percent(financeModifier, baseAmount);
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
		{
			int treatmentCharge = GetTreatmentCharge(patient.Illness, room.Definition, patient.Level.ResearchManager);
			int treatmentBaseCharge = GetTreatmentBaseCharge(patient.Illness, room.Definition, patient.Level.ResearchManager);
			if (IsCharacterHappyToPay(patient, treatmentCharge, treatmentBaseCharge))
			{
				patient.MoneySpent += treatmentCharge;
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = treatmentCharge,
					InWorldMessagePosition = patient.Position,
					ConsiderAsEarned = true,
					Room = room
				});
				if (OnPatientChargedForTreatment != null)
				{
					OnPatientChargedForTreatment(patient, staff, room, treatmentCharge, treatmentBaseCharge);
				}
			}
			else
			{
				OnPatientRefusedToPayForTreatment.InvokeSafe(patient, staff, room, treatmentCharge);
			}
		}

		private void OnPatientReceivedDiagnosis(Patient patient, Staff staff, Room room, float increment)
		{
			int diagnosisCharge = GetDiagnosisCharge(room.Definition);
			int diagnosisBaseCharge = GetDiagnosisBaseCharge(room.Definition);
			if (IsCharacterHappyToPay(patient, diagnosisCharge, diagnosisBaseCharge))
			{
				patient.MoneySpent += diagnosisCharge;
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = diagnosisCharge,
					InWorldMessagePosition = patient.Position,
					ConsiderAsEarned = true,
					Room = room
				});
				if (OnPatientChargedForDiagnosis != null)
				{
					OnPatientChargedForDiagnosis(patient, staff, room, increment, diagnosisCharge, diagnosisBaseCharge);
				}
			}
			else if (OnPatientRefusedToPayForDiagnosis != null)
			{
				OnPatientRefusedToPayForDiagnosis(patient, staff, room, increment, diagnosisCharge);
			}
		}

		private void OnStaffStartLearning(Staff staff, RoomLogicTrainingRoom logic)
		{
			if (logic.Teacher is GuestTrainer guestTrainer)
			{
				GuestTrainerDefinition.Skill skill = guestTrainer.Definition.GetSkill(logic.Qualification);
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = -skill.GetCostPerTrainee(staff.Level),
					InWorldMessagePosition = staff.Position
				});
			}
		}

		private void OnStaffStartTeaching(Staff staff, RoomLogicTrainingRoom logic)
		{
			if (staff is GuestTrainer guestTrainer)
			{
				GuestTrainerDefinition.Skill skill = guestTrainer.Definition.GetSkill(logic.Qualification);
				Vector3 value = logic.GetLecternComponent()?.GetOwner<RoomItem>().WorldPosition ?? staff.Position;
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = -skill.GetUpfrontCost(staff.Level),
					InWorldMessagePosition = value
				});
			}
		}

		private void OnMonthlyPayment(int amount, int interest)
		{
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -amount,
				ConsiderAsEarned = false
			});
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -interest,
				ConsiderAsEarned = false,
				ConsiderAsRegularExpense = true
			});
		}

		private void OnTakeOutLoan(LoanOffer offer)
		{
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = offer.Amount,
				ConsiderAsEarned = false
			});
		}

		private void OnRepayLoan(LoanOffer offer)
		{
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -offer.OutstandingBalance,
				ConsiderAsEarned = false
			});
		}

		private void OnCampaignStarted(MarketingCampaignComponent component)
		{
			Vector3 worldPosition = component.GetOwner<RoomItem>().WorldPosition;
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -component.Cost,
				InWorldMessagePosition = worldPosition,
				ConsiderAsEarned = false
			});
		}

		private void OnStaffDestroyed(Staff staff)
		{
			_staffToPay.Remove(staff);
		}

		private void OnRoomItemPurchased(RoomItem roomItem)
		{
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -roomItem.Cost,
				InWorldMessagePosition = roomItem.WorldPosition,
				Room = roomItem.OwningRoom
			});
		}

		private void OnRoomItemSold(RoomItem roomItem)
		{
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = roomItem.SellValue(),
				InWorldMessagePosition = roomItem.WorldPosition,
				Room = roomItem.OwningRoom
			});
		}

		private void OnHospitalPlotBought(HospitalPlot hospitalPlot)
		{
			Vector3 value = ((hospitalPlot.HospitalMap != null) ? hospitalPlot.HospitalMap.Room.GetCameraTrackObject().transform.position : Vector3.zero);
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -hospitalPlot.Definition.Cost,
				InWorldMessagePosition = value
			});
		}

		private void OnRoomItemRequestUpgrade(RoomItem roomItem)
		{
			RoomItemUpgradeDefinition nextUpgrade = roomItem.Definition.GetNextUpgrade(roomItem.UpgradeLevel);
			if (nextUpgrade != null)
			{
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = -nextUpgrade.Cost,
					InWorldMessagePosition = roomItem.WorldPosition,
					Room = roomItem.OwningRoom
				});
			}
		}

		private void OnRoomItemCancelUpgrade(RoomItem roomItem)
		{
			RoomItemUpgradeDefinition nextUpgrade = roomItem.Definition.GetNextUpgrade(roomItem.UpgradeLevel);
			if (nextUpgrade != null)
			{
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = nextUpgrade.Cost,
					InWorldMessagePosition = roomItem.WorldPosition,
					Room = roomItem.OwningRoom
				});
			}
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			_energyBill += roomItem.EnergyCost;
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			_energyBill -= roomItem.EnergyCost;
		}

		private void OnRoomItemUpgradeComplete(RoomItem roomItem, Staff staff)
		{
			_energyBill -= roomItem.Definition.EnergyCost(roomItem.UpgradeLevel - 1);
			_energyBill += roomItem.Definition.EnergyCost(roomItem.UpgradeLevel);
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			_staffToPay.Add(staff);
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -fee,
				InWorldMessagePosition = staff.Position,
				ConsiderAsRegularExpense = true
			});
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -cost,
				InWorldMessagePosition = room.GetMenuAnchorPosition(),
				Room = room
			});
			if (cost != 0)
			{
				OnRoomPurchased.InvokeSafe(room, cost);
			}
		}

		private void OnRoomDeleted(Room room)
		{
			int num = GameAlgorithms.CalculateSellCostOfRoom(room.FloorPlan);
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = num,
				InWorldMessagePosition = room.GetMenuAnchorPosition(),
				Room = room
			});
			if (num != 0)
			{
				OnRoomSold.InvokeSafe(room, num);
			}
		}

		private void OnRoomCancelled(Room room, int cost)
		{
			if (cost != 0)
			{
				if (room == null)
				{
					ModifyBalance(new ModifyBalanceParams
					{
						Amount = cost
					});
					return;
				}
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = cost,
					InWorldMessagePosition = room.GetMenuAnchorPosition(),
					Room = room
				});
			}
		}

		private void OnResearchProjectAssigned(ResearchProject researchProject, RoomItem roomItem)
		{
			if (!(roomItem.FloorPlan is BlueprintFloorPlan))
			{
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = -researchProject.Definition.GreenlightCost,
					InWorldMessagePosition = roomItem.WorldPosition,
					Room = roomItem.OwningRoom
				});
			}
		}

		public void PayBillsAndWages()
		{
			PayEnergyBill();
			PayStaffWages();
		}

		private void PayEnergyBill()
		{
			int num = _energyBill + _energyBillPerUse;
			if (num != 0)
			{
				ModifyBalance(new ModifyBalanceParams
				{
					Amount = -num,
					ConsiderAsRegularExpense = true
				});
				OnMonthlyEnergyBillPaid.InvokeSafe(num);
			}
			_energyBillPerUse = 0;
		}

		private void PayStaffWages()
		{
			int num = 0;
			foreach (Staff item in _staffToPay)
			{
				int salary = item.GetSalary();
				num += salary;
				OnStaffPaid.InvokeSafe(item, salary / 12);
			}
			num /= 12;
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = -num,
				ConsiderAsRegularExpense = true
			});
			if (num != 0)
			{
				OnMonthlyWagesPaid.InvokeSafe(num);
			}
		}

		private void MoneyAwarded(int amount)
		{
			ModifyBalance(new ModifyBalanceParams
			{
				Amount = amount,
				ConsiderAsEarned = true
			});
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ModifyBalance");
			ConsoleCommandsDatabase.UnRegisterCommand("EarnMoney");
			OnMoneyAwarded = (Action<int>)Delegate.Remove(OnMoneyAwarded, new Action<int>(MoneyAwarded));
			OnBudgetRefund = (Action<int>)Delegate.Remove(OnBudgetRefund, new Action<int>(MoneyAwarded));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomCancelled = (Action<Room, int>)Delegate.Remove(buildEvents3.OnRoomCancelled, new Action<Room, int>(OnRoomCancelled));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Remove(buildEvents4.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
			BuildEvents buildEvents5 = _level.BuildEvents;
			buildEvents5.OnRoomItemSold = (Action<RoomItem>)Delegate.Remove(buildEvents5.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			BuildEvents buildEvents6 = _level.BuildEvents;
			buildEvents6.OnHospitalPlotBought = (Action<HospitalPlot>)Delegate.Remove(buildEvents6.OnHospitalPlotBought, new Action<HospitalPlot>(OnHospitalPlotBought));
			BuildEvents buildEvents7 = _level.BuildEvents;
			buildEvents7.OnRoomItemRequestUpgrade = (Action<RoomItem>)Delegate.Remove(buildEvents7.OnRoomItemRequestUpgrade, new Action<RoomItem>(OnRoomItemRequestUpgrade));
			BuildEvents buildEvents8 = _level.BuildEvents;
			buildEvents8.OnRoomItemCancelUpgrade = (Action<RoomItem>)Delegate.Remove(buildEvents8.OnRoomItemCancelUpgrade, new Action<RoomItem>(OnRoomItemCancelUpgrade));
			BuildEvents buildEvents9 = _level.BuildEvents;
			buildEvents9.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents9.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents10 = _level.BuildEvents;
			buildEvents10.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents10.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents11 = _level.BuildEvents;
			buildEvents11.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(buildEvents11.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnRoomItemUpgradeComplete));
			_level.CharacterEvents.OnStaffHired.Remove(this);
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents3.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents4.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Remove(characterEvents5.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnStaffStartTeaching = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Remove(characterEvents6.OnStaffStartTeaching, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartTeaching));
			ResearchManager researchManager = _level.ResearchManager;
			researchManager.OnResearchProjectAssigned = (Action<ResearchProject, RoomItem>)Delegate.Remove(researchManager.OnResearchProjectAssigned, new Action<ResearchProject, RoomItem>(OnResearchProjectAssigned));
			LoanManager loanManager = _level.LoanManager;
			loanManager.OnTakeOutLoan = (Action<LoanOffer>)Delegate.Remove(loanManager.OnTakeOutLoan, new Action<LoanOffer>(OnTakeOutLoan));
			LoanManager loanManager2 = _level.LoanManager;
			loanManager2.OnRepayLoan = (Action<LoanOffer>)Delegate.Remove(loanManager2.OnRepayLoan, new Action<LoanOffer>(OnRepayLoan));
			LoanManager loanManager3 = _level.LoanManager;
			loanManager3.OnMonthlyPayment = (Action<int, int>)Delegate.Remove(loanManager3.OnMonthlyPayment, new Action<int, int>(OnMonthlyPayment));
			MarketingManager marketingManager = _level.MarketingManager;
			marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnMoneyEarned.VerifyIsNull();
			OnSporadicExpense.VerifyIsNull();
			OnRegularExpense.VerifyIsNull();
			OnMoneyEarnedInRoom.VerifyIsNull();
			OnBalanceUpdated.VerifyIsNull();
			OnMonthlyWagesPaid.VerifyIsNull();
			OnStaffPaid.VerifyIsNull();
			OnRoomPurchased.VerifyIsNull();
			OnRoomSold.VerifyIsNull();
			OnMoneyAwarded.VerifyIsNull();
			OnBudgetRefund.VerifyIsNull();
			OnCharacterChargedForInteraction.VerifyIsNull();
			OnCharacterRefusedToPayForItem.VerifyIsNull();
			OnPatientRefusedToPayForTreatment.VerifyIsNull();
		}

		public int GetDiagnosisCharge(RoomDefinition roomDefinition)
		{
			int diagnosisBaseCharge = GetDiagnosisBaseCharge(roomDefinition);
			return diagnosisBaseCharge + _priceModifiers.Percent(roomDefinition, diagnosisBaseCharge);
		}

		public int GetDiagnosisBaseCharge(RoomDefinition roomDefinition)
		{
			return Mathf.CeilToInt((float)roomDefinition._diagnosisCost * LocalMarketRateModifier);
		}

		public int GetTreatmentCharge(IllnessDefinition illness, RoomDefinition roomDefinition, ResearchManager researchManager)
		{
			int treatmentBaseCharge = GetTreatmentBaseCharge(illness, roomDefinition, researchManager);
			return treatmentBaseCharge + _priceModifiers.Percent(illness, treatmentBaseCharge);
		}

		public int GetTreatmentBaseCharge(IllnessDefinition illness, RoomDefinition roomDefinition, ResearchManager researchManager)
		{
			return illness.GetTreatmentCostForRoom(roomDefinition, researchManager, this);
		}
	}
}
