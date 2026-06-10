using System.Collections.Generic;
using System.Reflection;
using NSMedieval.AdditionalMenuItems;
using UnityEngine;

namespace NSMedieval
{
	public static class AdditionalMenuItemMap
	{
		private static Dictionary<string, ConstructorInfo> constructors;

		public static Dictionary<string, ConstructorInfo> Constuctors
		{
			get
			{
				if (constructors != null)
				{
					return constructors;
				}
				constructors = new Dictionary<string, ConstructorInfo>();
				constructors.Add("AttackMenuItem", typeof(AttackMenuItem).GetConstructors()[0]);
				constructors.Add("PileEquipMenuItem", typeof(PileEquipMenuItem).GetConstructors()[0]);
				constructors.Add("PileForceEatMenuItem", typeof(PileForceEatMenuItem).GetConstructors()[0]);
				constructors.Add("OperateTrebuchetMenuItem", typeof(OperateTrebuchetMenuItem).GetConstructors()[0]);
				constructors.Add("DeliverTrebuchetAmmoMenuItem", typeof(DeliverTrebuchetAmmoMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseHaulingMenuItem", typeof(PrioritiseHaulingMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseBuryMenuItem", typeof(PrioritiseBuryMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseBuildingMaterialsDeliveryMenuItem", typeof(PrioritiseBuildingMaterialsDeliveryMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseBuildingConstructionMenuItem", typeof(PrioritiseBuildingConstructionMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseChopMenuItem", typeof(PrioritiseChopMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseHarvestMenuItem", typeof(PrioritiseHarvestMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseFishingMenuItem", typeof(PrioritiseFishingMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseBuildingDeConstructionMenuItem", typeof(PrioritiseBuildingDeConstructionMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseBuildingUninstallMenuItem", typeof(PrioritiseBuildingUninstallMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseMineMenuItem", typeof(PrioritiseMineMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseProductionMenuItem", typeof(PrioritiseProductionMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseCarryWorkerToBedMenuItem", typeof(PrioritiseCarryWorkerToBedMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseTendWoundsMenuItem", typeof(PrioritiseTendWoundsMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseHuntingMenuItem", typeof(PrioritiseHuntingMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseTamingMenuItem", typeof(PrioritiseTamingMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseAnimalHarvestMenuItem", typeof(PrioritiseAnimalHarvestMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseReleaseAnimalMenuItem", typeof(PrioritiseReleaseAnimalMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseSlaughterAnimal", typeof(PrioritiseSlaughterAnimal).GetConstructors()[0]);
				constructors.Add("PrioritiseTrainAnimal", typeof(PrioritiseTrainAnimal).GetConstructors()[0]);
				constructors.Add("PrioritiseRopeAnimalMenuItem", typeof(PrioritiseRopeAnimalMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseLockDoorMenuItem", typeof(PrioritiseLockDoorMenuItem).GetConstructors()[0]);
				constructors.Add("PileForceDrinkMenuItem", typeof(PileForceDrinkMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseWindowMenuItem", typeof(PrioritiseWindowMenuItem).GetConstructors()[0]);
				constructors.Add("StorageBuildingActionMenuItem", typeof(StorageBuildingActionMenuItem).GetConstructors()[0]);
				constructors.Add("TradeMenuItem", typeof(TradeMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseShackleMenuItem", typeof(PrioritiseShackleMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseRefuelingMenuItem", typeof(PrioritiseRefuelingMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseSetupTrapMenuItem", typeof(PrioritiseSetupTrapMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseAnimalFeederHaulingGoal", typeof(PrioritiseAnimalFeederHaulingGoal).GetConstructors()[0]);
				constructors.Add("PrioritiseSelfTendWoundsMenuItem", typeof(PrioritiseSelfTendWoundsMenuItem).GetConstructors()[0]);
				constructors.Add("NegotiateMenuItem", typeof(NegotiateMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseAnimalTendWoundsMenuItem", typeof(PrioritiseAnimalTendWoundsMenuItem).GetConstructors()[0]);
				constructors.Add("TakeOutFireMenuItem", typeof(TakeOutFireMenuItem).GetConstructors()[0]);
				constructors.Add("IgniteMenuItem", typeof(IgniteMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritisePrisonStashHaulingGoal", typeof(PrioritisePrisonStashHaulingGoal).GetConstructors()[0]);
				constructors.Add("PrioritiseEscortPrisonerMenuItem", typeof(PrioritiseEscortPrisonerMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseStripPrisonerMenuItem", typeof(PrioritiseStripPrisonerMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseOpenShelf", typeof(PrioritiseOpenShelf).GetConstructors()[0]);
				constructors.Add("PrioritiseBarrelFill", typeof(PrioritiseBarrelFill).GetConstructors()[0]);
				constructors.Add("PrioritiseStripMenuItem", typeof(PrioritiseStripMenuItem).GetConstructors()[0]);
				constructors.Add("PrioritiseSowMenuItem", typeof(PrioritiseSowMenuItem).GetConstructors()[0]);
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
