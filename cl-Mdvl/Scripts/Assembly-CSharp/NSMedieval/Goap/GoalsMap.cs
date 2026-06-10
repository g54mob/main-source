using System.Collections.Generic;
using System.Reflection;
using NSMedieval.Goap.Goals;
using UnityEngine;

namespace NSMedieval.Goap
{
	public static class GoalsMap
	{
		private static Dictionary<string, ConstructorInfo> constructors;

		public static Dictionary<string, ConstructorInfo> Constuctors
		{
			get
			{
				if (constructors == null)
				{
					constructors = new Dictionary<string, ConstructorInfo>();
					constructors.Add("StockpileHaulingGoal", typeof(StockpileHaulingGoal).GetConstructors()[0]);
					constructors.Add("StockpileUrgentHaulingGoal", typeof(StockpileUrgentHaulingGoal).GetConstructors()[0]);
					constructors.Add("AnimalFeederHaulingGoal", typeof(AnimalFeederHaulingGoal).GetConstructors()[0]);
					constructors.Add("PrisonStashHaulingGoal", typeof(PrisonStashHaulingGoal).GetConstructors()[0]);
					constructors.Add("EquipGoal", typeof(EquipGoal).GetConstructors()[0]);
					constructors.Add("HarvestGoal", typeof(HarvestGoal).GetConstructors()[0]);
					constructors.Add("HungerGoal", typeof(HungerGoal).GetConstructors()[0]);
					constructors.Add("ConstructBuildingGoal", typeof(ConstructBuildingGoal).GetConstructors()[0]);
					constructors.Add("DeconstructGoal", typeof(DeconstructGoal).GetConstructors()[0]);
					constructors.Add("UninstallBuildingGoal", typeof(UninstallBuildingGoal).GetConstructors()[0]);
					constructors.Add("DeliverMoveBuildingResource", typeof(DeliverMoveBuildingResource).GetConstructors()[0]);
					constructors.Add("RepairBuildingGoal", typeof(RepairBuildingGoal).GetConstructors()[0]);
					constructors.Add("DeliverBuildingMaterialsGoal", typeof(DeliverBuildingMaterialsGoal).GetConstructors()[0]);
					constructors.Add("PlantCropsGoal", typeof(PlantCropsGoal).GetConstructors()[0]);
					constructors.Add("ChopTreeGoal", typeof(ChopTreeGoal).GetConstructors()[0]);
					constructors.Add("DigGoal", typeof(DigGoal).GetConstructors()[0]);
					constructors.Add("AttackGoal", typeof(AttackGoal).GetConstructors()[0]);
					constructors.Add("EnemySelfDefenseGoal", typeof(EnemySelfDefenseGoal).GetConstructors()[0]);
					constructors.Add("EnemyStepAsideGoal", typeof(EnemyStepAsideGoal).GetConstructors()[0]);
					constructors.Add("HuntingGoal", typeof(HuntingGoal).GetConstructors()[0]);
					constructors.Add("FishingGoal", typeof(FishingGoal).GetConstructors()[0]);
					constructors.Add("LeaveMapGoal", typeof(LeaveMapGoal).GetConstructors()[0]);
					constructors.Add("SleepGoal", typeof(SleepGoal).GetConstructors()[0]);
					constructors.Add("IdleGoal", typeof(IdleGoal).GetConstructors()[0]);
					constructors.Add("EnemyIdleGoal", typeof(EnemyIdleGoal).GetConstructors()[0]);
					constructors.Add("PrisonerSurrenderGoal", typeof(PrisonerSurrenderGoal).GetConstructors()[0]);
					constructors.Add("PrisonerEscapeGoal", typeof(PrisonerEscapeGoal).GetConstructors()[0]);
					constructors.Add("EnemyWithdrawalGoal", typeof(EnemyWithdrawalGoal).GetConstructors()[0]);
					constructors.Add("FleeGoal", typeof(FleeGoal).GetConstructors()[0]);
					constructors.Add("ForcedFleeGoal", typeof(ForcedFleeGoal).GetConstructors()[0]);
					constructors.Add("ProductionCookingGoal", typeof(ProductionCookingGoal).GetConstructors()[0]);
					constructors.Add("ProductionCarpentryGoal", typeof(ProductionCarpentryGoal).GetConstructors()[0]);
					constructors.Add("ProductionTailoringGoal", typeof(ProductionTailoringGoal).GetConstructors()[0]);
					constructors.Add("ProductionResearchGoal", typeof(ProductionResearchGoal).GetConstructors()[0]);
					constructors.Add("ProductionCraftingGoal", typeof(ProductionCraftingGoal).GetConstructors()[0]);
					constructors.Add("ProductionAnimalGoal", typeof(ProductionAnimalGoal).GetConstructors()[0]);
					constructors.Add("ProductionArtGoal", typeof(ProductionArtGoal).GetConstructors()[0]);
					constructors.Add("ProductionCarcassDisposalGoal", typeof(ProductionCarcassDisposalGoal).GetConstructors()[0]);
					constructors.Add("ProductionChemistryGoal", typeof(ProductionChemistryGoal).GetConstructors()[0]);
					constructors.Add("ProductionTrainGoal", typeof(ProductionTrainGoal).GetConstructors()[0]);
					constructors.Add("ProductionSmithingGoal", typeof(ProductionSmithingGoal).GetConstructors()[0]);
					constructors.Add("OperateTrebuchetGoal", typeof(OperateTrebuchetGoal).GetConstructors()[0]);
					constructors.Add("FaintGoal", typeof(FaintGoal).GetConstructors()[0]);
					constructors.Add("TendWoundsGoal", typeof(TendWoundsGoal).GetConstructors()[0]);
					constructors.Add("RestGoal", typeof(RestGoal).GetConstructors()[0]);
					constructors.Add("CarryToBedGoal", typeof(CarryToBedGoal).GetConstructors()[0]);
					constructors.Add("FollowGoal", typeof(FollowGoal).GetConstructors()[0]);
					constructors.Add("EnemyCombatIdleGoal", typeof(EnemyCombatIdleGoal).GetConstructors()[0]);
					constructors.Add("EnemyIdlePatrolGoal", typeof(EnemyIdlePatrolGoal).GetConstructors()[0]);
					constructors.Add("DrinkGoal", typeof(DrinkGoal).GetConstructors()[0]);
					constructors.Add("FaithGoal", typeof(FaithGoal).GetConstructors()[0]);
					constructors.Add("ChangeDoorLockStateGoal", typeof(ChangeDoorLockStateGoal).GetConstructors()[0]);
					constructors.Add("ChangeLockStateGoal", typeof(ChangeLockStateGoal).GetConstructors()[0]);
					constructors.Add("OpenShelfGoal", typeof(OpenShelfGoal).GetConstructors()[0]);
					constructors.Add("AutoEquipGoal", typeof(AutoEquipGoal).GetConstructors()[0]);
					constructors.Add("SetupTrapGoal", typeof(SetupTrapGoal).GetConstructors()[0]);
					constructors.Add("VomitGoal", typeof(VomitGoal).GetConstructors()[0]);
					constructors.Add("BackgammonEntertainmentGoal", typeof(BackgammonEntertainmentGoal).GetConstructors()[0]);
					constructors.Add("ShovelboardEntertainmentGoal", typeof(ShovelboardEntertainmentGoal).GetConstructors()[0]);
					constructors.Add("SkittlesEntertainmentGoal", typeof(SkittlesEntertainmentGoal).GetConstructors()[0]);
					constructors.Add("QuoitsEntertainmentGoal", typeof(QuoitsEntertainmentGoal).GetConstructors()[0]);
					constructors.Add("BuryBodyGoal", typeof(BuryBodyGoal).GetConstructors()[0]);
					constructors.Add("TradeGoal", typeof(TradeGoal).GetConstructors()[0]);
					constructors.Add("TraderIdleGoal", typeof(TraderIdleGoal).GetConstructors()[0]);
					constructors.Add("FormCaravanGoal", typeof(FormCaravanGoal).GetConstructors()[0]);
					constructors.Add("DeliverFuelGoal", typeof(DeliverFuelGoal).GetConstructors()[0]);
					constructors.Add("AnimalFleeingIdleGoal", typeof(AnimalFleeingIdleGoal).GetConstructors()[0]);
					constructors.Add("TameAnimalGoal", typeof(TameAnimalGoal).GetConstructors()[0]);
					constructors.Add("HarvestAnimalGoal", typeof(HarvestAnimalGoal).GetConstructors()[0]);
					constructors.Add("SlaughterAnimalGoal", typeof(SlaughterAnimalGoal).GetConstructors()[0]);
					constructors.Add("TrainAnimalGoal", typeof(TrainAnimalGoal).GetConstructors()[0]);
					constructors.Add("RopedFollowGoal", typeof(RopedFollowGoal).GetConstructors()[0]);
					constructors.Add("RopeAnimalGoal", typeof(RopeAnimalGoal).GetConstructors()[0]);
					constructors.Add("RopeEnemyGoal", typeof(RopeEnemyGoal).GetConstructors()[0]);
					constructors.Add("ReleaseAnimalGoal", typeof(ReleaseAnimalGoal).GetConstructors()[0]);
					constructors.Add("AnimalRaidIdleGoal", typeof(AnimalRaidIdleGoal).GetConstructors()[0]);
					constructors.Add("AnimalHungerGoal", typeof(AnimalHungerGoal).GetConstructors()[0]);
					constructors.Add("FillFoodStorageGoal", typeof(FillFoodStorageGoal).GetConstructors()[0]);
					constructors.Add("SelfTendWoundsGoal", typeof(SelfTendWoundsGoal).GetConstructors()[0]);
					constructors.Add("PatientGoal", typeof(PatientGoal).GetConstructors()[0]);
					constructors.Add("FillMedicineStorageGoal", typeof(FillMedicineStorageGoal).GetConstructors()[0]);
					constructors.Add("FeastEventGoal", typeof(FeastEventGoal).GetConstructors()[0]);
					constructors.Add("NegotiateGoal", typeof(NegotiateGoal).GetConstructors()[0]);
					constructors.Add("IdleOnFireGoal", typeof(IdleOnFireGoal).GetConstructors()[0]);
					constructors.Add("TakeOutFireGoal", typeof(TakeOutFireGoal).GetConstructors()[0]);
					constructors.Add("FeastEventGoalBard", typeof(FeastEventGoalBard).GetConstructors()[0]);
					constructors.Add("SermonEventGoal", typeof(SermonEventGoal).GetConstructors()[0]);
					constructors.Add("SermonEventGoalPriest", typeof(SermonEventGoalPriest).GetConstructors()[0]);
					constructors.Add("RitualEventGoal", typeof(RitualEventGoal).GetConstructors()[0]);
					constructors.Add("RitualEventGoalShaman", typeof(RitualEventGoalShaman).GetConstructors()[0]);
					constructors.Add("RitualAnimalEventGoal", typeof(RitualAnimalEventGoal).GetConstructors()[0]);
					constructors.Add("HangingEventGoal", typeof(HangingEventGoal).GetConstructors()[0]);
					constructors.Add("MasterClassEventGoal", typeof(MasterClassEventGoal).GetConstructors()[0]);
					constructors.Add("MasterClassEventGoalLibrarian", typeof(MasterClassEventGoalLibrarian).GetConstructors()[0]);
					constructors.Add("TrainingEventGoalRanged", typeof(TrainingEventGoalRanged).GetConstructors()[0]);
					constructors.Add("TrainingEventGoalMelee", typeof(TrainingEventGoalMelee).GetConstructors()[0]);
					constructors.Add("TrainingEventGoalSergeant", typeof(TrainingEventGoalSergeant).GetConstructors()[0]);
					constructors.Add("BardRoleGoal", typeof(BardRoleGoal).GetConstructors()[0]);
					constructors.Add("ShamanRoleGoal", typeof(ShamanRoleGoal).GetConstructors()[0]);
					constructors.Add("PriestRoleGoal", typeof(PriestRoleGoal).GetConstructors()[0]);
					constructors.Add("WardenRoleGoal", typeof(WardenRoleGoal).GetConstructors()[0]);
					constructors.Add("LibrarianRoleGoal", typeof(LibrarianRoleGoal).GetConstructors()[0]);
					constructors.Add("SergeantRoleGoal", typeof(SergeantRoleGoal).GetConstructors()[0]);
					constructors.Add("BrokerRoleGoal", typeof(BrokerRoleGoal).GetConstructors()[0]);
					constructors.Add("BardVisitorGoal", typeof(BardVisitorGoal).GetConstructors()[0]);
					constructors.Add("PriestVisitorGoal", typeof(PriestVisitorGoal).GetConstructors()[0]);
					constructors.Add("ShamanVisitorGoal", typeof(ShamanVisitorGoal).GetConstructors()[0]);
					constructors.Add("RopePrisonerToHangingEventGoal", typeof(RopePrisonerToHangingEventGoal).GetConstructors()[0]);
					constructors.Add("GallowsExecutionGoal", typeof(GallowsExecutionGoal).GetConstructors()[0]);
					constructors.Add("RecruitPrisonerGoal", typeof(RecruitPrisonerGoal).GetConstructors()[0]);
					constructors.Add("ShacklePrisonerGoal", typeof(ShacklePrisonerGoal).GetConstructors()[0]);
					constructors.Add("StripCaptiveGoal", typeof(StripCaptiveGoal).GetConstructors()[0]);
					constructors.Add("ReleasePrisonerGoal", typeof(ReleasePrisonerGoal).GetConstructors()[0]);
					constructors.Add("BarrelFillGoal", typeof(BarrelFillGoal).GetConstructors()[0]);
					constructors.Add("NPCIdleWalkGoal", typeof(NPCIdleWalkGoal).GetConstructors()[0]);
					constructors.Add("StripCarcassGoal", typeof(StripCarcassGoal).GetConstructors()[0]);
					constructors.Add("FollowMoveOrderGoal", typeof(FollowMoveOrderGoal).GetConstructors()[0]);
					constructors.Add("FollowAttackOrderGoal", typeof(FollowAttackOrderGoal).GetConstructors()[0]);
				}
				return constructors;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			constructors = null;
		}
	}
}
