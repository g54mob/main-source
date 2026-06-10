using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Village;

namespace NSMedieval.State
{
	public class HumanoidProximityBehaviour : ProximityBehaviour
	{
		public HumanoidProximityBehaviour(HumanoidInstance humanoidInstance)
			: base(humanoidInstance)
		{
		}

		public override void HandleOnWorldObjectEnterProximity(WorldObject worldObject)
		{
			if (!OnResourcePileEnterProximity(worldObject) && !OnBaseBuildableEnterProximity(worldObject))
			{
				OnProductionEnterProximity(worldObject);
			}
		}

		public override void HandleOnWorldObjectExitProximity(WorldObject worldObject)
		{
			if (worldObject is ResourcePileInstance resourcePileInstance)
			{
				string text = resourcePileInstance.Blueprint?.ProximityEffector;
				if (!string.IsNullOrEmpty(text))
				{
					HumanoidInstance.Stats.EndEffector(text);
				}
			}
		}

		public override void HandleOnCreatureEnterProximity(CreatureBase creature)
		{
		}

		private bool OnProductionEnterProximity(WorldObject worldObject)
		{
			if (!(worldObject is BaseBuildingInstance baseBuildingInstance))
			{
				return false;
			}
			ProductionComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<ProductionComponentInstance>();
			if (componentInstance == null)
			{
				return false;
			}
			if (!(componentInstance.ProductionSystemInstance.OperatingAgent is HumanoidInstance humanoidInstance) || humanoidInstance == HumanoidInstance)
			{
				return false;
			}
			if (!humanoidInstance.GetGoapAgent().CurrentGoalName.Equals("ProductionCookingGoal"))
			{
				return false;
			}
			ProductionInstance currentProduction = componentInstance.ProductionSystemInstance.CurrentProduction;
			Resource resource = currentProduction?.Storage?.Resources?.FirstOrDefault((ResourceInstance resourceInstance) => resourceInstance.Blueprint.IsHumanSource)?.Blueprint;
			if (resource == null)
			{
				resource = currentProduction?.SecondaryIngredientStorage?.Resources?.FirstOrDefault((ResourceInstance resourceInstance) => resourceInstance.Blueprint.IsHumanSource)?.Blueprint;
				if (resource == null)
				{
					return false;
				}
			}
			if (resource.Category.HasFlag(ResourceCategory.CtgHumanCarcass))
			{
				MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(HumanoidInstance.IsCannibal() ? "saw_cannibal_butchering_positive" : "saw_cannibal_butchering_negative", HumanoidInstance, humanoidInstance);
				return true;
			}
			return false;
		}

		private bool OnResourcePileEnterProximity(WorldObject worldObject)
		{
			if (!(worldObject is ResourcePileInstance resourcePileInstance))
			{
				return false;
			}
			string text = resourcePileInstance.Blueprint?.ProximityEffector;
			string text2 = resourcePileInstance.Blueprint?.ProximityEnterEffector;
			if (!string.IsNullOrEmpty(text))
			{
				HumanoidInstance.Stats.StartEffector(text);
			}
			if (!string.IsNullOrEmpty(text2))
			{
				HumanoidInstance.Stats.StartEffector(text2);
			}
			return true;
		}

		private bool OnBaseBuildableEnterProximity(WorldObject worldObject)
		{
			if (!(worldObject is BaseBuildingInstance baseBuildingInstance))
			{
				return false;
			}
			if (!baseBuildingInstance.Blueprint.BuildingType.HasFlag(BuildingType.Decoration))
			{
				return false;
			}
			if (IsQualityPositive(GetBuildableQuality(baseBuildingInstance)))
			{
				ProducedItemData producedItemData = new ProducedItemData(BuildingUtils.GetLocalizedName(baseBuildingInstance.Blueprint), baseBuildingInstance.ProducerUniqueId);
				MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("interacted_with_art_positive", HumanoidInstance, producedItemData);
				return true;
			}
			if (IsQualityNegative(GetBuildableQuality(baseBuildingInstance)))
			{
				ProducedItemData producedItemData2 = new ProducedItemData(BuildingUtils.GetLocalizedName(baseBuildingInstance.Blueprint), baseBuildingInstance.ProducerUniqueId);
				MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction("interacted_with_art_negative", HumanoidInstance, producedItemData2);
				return true;
			}
			return false;
		}

		public bool IsQualityPositive(ProductQuality quality)
		{
			if (quality != ProductQuality.Superior)
			{
				return quality == ProductQuality.Flawless;
			}
			return true;
		}

		public bool IsQualityNegative(ProductQuality quality)
		{
			if (quality != ProductQuality.Flimsy)
			{
				return quality == ProductQuality.Sturdy;
			}
			return true;
		}

		private ProductQuality GetBuildableQuality(BaseBuildingInstance baseBuildableObject)
		{
			return baseBuildableObject.Blueprint.Quality;
		}
	}
}
