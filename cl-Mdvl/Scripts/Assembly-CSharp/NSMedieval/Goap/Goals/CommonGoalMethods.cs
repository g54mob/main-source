using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public static class CommonGoalMethods
	{
		public static bool CheckPrisonConditions(HumanoidInstance human, Room room)
		{
			if (human != null)
			{
				if (human.IsCaptive() && (room == null || !room.RoomType.Prison))
				{
					return false;
				}
				if (!human.IsCaptive() && room != null && room.RoomType.Prison)
				{
					return false;
				}
			}
			return true;
		}

		public static bool CheckPrisonConditions(CreatureBase creature, Room room)
		{
			if (creature is AnimalInstance && room != null && room.RoomType.Prison)
			{
				return false;
			}
			if (creature is HumanoidInstance human)
			{
				return CheckPrisonConditions(human, room);
			}
			return true;
		}

		public static float GetFoodScore(WorldObject worldObject, Vec3Int gridPosition, DietModel dietModel)
		{
			bool isInHomeArea = worldObject.Map.HomeArea.IsHomeArea(gridPosition);
			float result = 0f;
			if ((worldObject.GridDataType & GridDataType.ResourcePile) != GridDataType.None)
			{
				ResourcePileInstance resourcePile = (ResourcePileInstance)worldObject;
				result = dietModel.GetPriority(resourcePile, isInHomeArea, isWildAnimal: false);
			}
			else if ((worldObject.GridDataType & GridDataType.PlantMapResource) != GridDataType.None)
			{
				PlantMapResourceInstance plantMapResource = (PlantMapResourceInstance)worldObject;
				result = dietModel.GetPriority(plantMapResource, isInHomeArea, isWildAnimal: false);
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetFoodScore(ResourceInstance resourceInstance, DietModel dietModel)
		{
			return dietModel.GetPriority(resourceInstance, isInHomeArea: true);
		}

		public static float GetMedicineScore(ResourcePileInstance medicineResourcePile, Vec3Int requesterPosition)
		{
			float num = Vec3Int.Distance(in requesterPosition, medicineResourcePile.GridDataPosition);
			return medicineResourcePile.Blueprint.Healing * 100f - num;
		}

		public static ResourcePileInstance FindMedicine(IPathfindingAgent pathfindingAgent, Vec3Int requesterPosition, bool mustBeInStorage = false, float minHealingAmount = 0f, float medicineSearchLimit = 50f)
		{
			int medicineFound = 0;
			float optimalMedicineScore = 0f;
			ResourcePileInstance optimalMedicine = null;
			PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = pathfindingAgent,
				GridData = GridDataType.ResourcePile,
				Condition = delegate(WorldObject obj)
				{
					if (mustBeInStorage && (obj.GetNode().DataType & (GridDataType.Stockpile | GridDataType.Furniture)) == 0)
					{
						return false;
					}
					ResourcePileInstance resourcePileInstance = (ResourcePileInstance)obj;
					return !resourcePileInstance.IsForbidden && (resourcePileInstance.Blueprint.Category & ResourceCategory.CtgHealPack) != ResourceCategory.None && resourcePileInstance.Blueprint.Healing > minHealingAmount;
				},
				OnFound = delegate(WorldObject obj, Vec3Int pos)
				{
					ResourcePileInstance resourcePileInstance = (ResourcePileInstance)obj;
					float medicineScore = GetMedicineScore(resourcePileInstance, requesterPosition);
					bool flag = false;
					if (optimalMedicine == null || medicineScore > optimalMedicineScore)
					{
						flag = true;
						optimalMedicineScore = medicineScore;
						optimalMedicine = resourcePileInstance;
					}
					if ((float)medicineFound++ >= medicineSearchLimit)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					return flag ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
				}
			});
			return optimalMedicine;
		}

		public static GameObject CreateRopeEffect(HumanoidInstance ropeOwner, HumanoidInstance ropedCaptive)
		{
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("RopeEffect");
			if (byAddress == null)
			{
				Log.Error("Rope effect, prefab for RopeEffect is null", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\CommonGoalMethods.cs");
				return null;
			}
			GameObject gameObject = Object.Instantiate(byAddress);
			RopeEffect componentInChildren = gameObject.GetComponentInChildren<RopeEffect>();
			if (componentInChildren == null)
			{
				Log.Warning("Rope effect failed....  Continuing goal without effect", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\CommonGoalMethods.cs");
			}
			else
			{
				componentInChildren.SetStart(ropeOwner.GetAgentView<HumanoidView>().RopeHookBone);
				Transform ropeHookBone = ropedCaptive.GetAgentView<HumanoidView>().RopeHookBone;
				if (ropeHookBone == null)
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\CommonGoalMethods.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(ropedCaptive);
						messageBuilder.AppendLiteral(" doesn't have RopeHookBone set up, continuing with general position");
					}
					Log.Warning(messageBuilder);
					componentInChildren.SetTarget(ropedCaptive);
				}
				else
				{
					componentInChildren.SetTarget(ropeHookBone);
				}
			}
			if (componentInChildren != null)
			{
				componentInChildren.SelectMaterial(RopeMaterial.Chains);
			}
			return gameObject;
		}

		public static bool CheckCanRopePrisoner(HumanoidInstance possiblePrisoner)
		{
			if (possiblePrisoner.HasDisposed || !possiblePrisoner.IsCaptive())
			{
				return false;
			}
			return possiblePrisoner.CaptiveNpcBehaviour.Owner == null;
		}
	}
}
