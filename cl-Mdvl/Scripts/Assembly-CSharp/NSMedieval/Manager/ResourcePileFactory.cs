using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class ResourcePileFactory
	{
		internal static ResourcePileInstance ProducePile(ResourceInstance resource, Vector3 worldPosition, bool isForbidden = false)
		{
			if (resource.Blueprint == null)
			{
				Log.Error("Tried to spawn pile with no blueprint. Blueprint probably removed from json.", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			ResourcePileInstance resourcePileInstance;
			if (resource is CarcassResourceInstance resource2)
			{
				resourcePileInstance = new HumanCarcassPileInstance(resource2, worldPosition);
			}
			else if (resource is MoveBuildingResourceInstance moveBuildingResourceInstance)
			{
				resourcePileInstance = new MovableBuildingPileInstance(moveBuildingResourceInstance, worldPosition);
				if (moveBuildingResourceInstance.TargetBuilding != null && !moveBuildingResourceInstance.TargetBuilding.HasDisposed)
				{
					moveBuildingResourceInstance.TargetBuilding?.SetMovableBuildingResourceInstance((MovableBuildingPileInstance)resourcePileInstance);
				}
			}
			else if (!string.IsNullOrEmpty(resource.Blueprint.BuildingBlueprintID))
			{
				MoveBuildingResourceInstance moveBuildingResourceInstance2 = new MoveBuildingResourceInstance(resource.Blueprint, resource.Amount, resource.Blueprint.BuildingBlueprintID);
				moveBuildingResourceInstance2.SetProducerUniqueId(resource.ProducerUniqueId);
				resourcePileInstance = new MovableBuildingPileInstance(moveBuildingResourceInstance2, worldPosition);
			}
			else
			{
				resourcePileInstance = new ResourcePileInstance(resource, worldPosition);
			}
			resourcePileInstance.IsForbidden = isForbidden;
			return resourcePileInstance;
		}

		internal static ResourcePileView ProducePileView(ResourcePileInstance pileInstance)
		{
			if (pileInstance is HumanCarcassPileInstance pile)
			{
				return ProduceHumanCarcassResourcePileView(pile);
			}
			if (pileInstance is MovableBuildingPileInstance pile2)
			{
				return ProduceBuildingResourcePileView(pile2);
			}
			Resource blueprint = pileInstance.Blueprint;
			GameObject prefabPile = ResourceUtils.GetPrefabPile(blueprint.PrefabPileID);
			if (prefabPile == null)
			{
				Log.Warning("Could not find prefab for pile " + pileInstance.Blueprint?.GetID(), "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			GameObject gameObject = Object.Instantiate(prefabPile, pileInstance.WorldPosition, Quaternion.identity, MonoSingleton<ResourcePileManager>.Instance.transform);
			if (gameObject == null)
			{
				Log.Warning("Could not instantiate pile " + pileInstance.BlueprintId, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			gameObject.name = blueprint.GetID() + "_pile";
			ResourcePileView component = gameObject.GetComponent<ResourcePileView>();
			if (component == null)
			{
				Log.Warning("Could not instantiate pile " + pileInstance.BlueprintId + ". View component not found", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			component.Setup(pileInstance);
			return component;
		}

		internal static ResourcePileView ProduceView(ResourceInstance resourceInstance)
		{
			GameObject prefabPile = ResourceUtils.GetPrefabPile(resourceInstance.Blueprint.PrefabPileID);
			if (prefabPile == null)
			{
				return null;
			}
			ResourcePileView resourcePileView = Object.Instantiate(prefabPile, Vector3.zero, Quaternion.identity, MonoSingleton<ResourcePileManager>.Instance.transform)?.GetComponent<ResourcePileView>();
			if ((object)resourcePileView == null)
			{
				return null;
			}
			resourcePileView.SetupMeshVariations(resourceInstance.Blueprint);
			return resourcePileView;
		}

		private static ResourcePileView ProduceHumanCarcassResourcePileView(HumanCarcassPileInstance pile)
		{
			if (!(pile.BodyOwner is HumanoidInstance))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(120, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trying to spawn carcass pile from invalid body owner ");
					messageBuilder.AppendFormatted(pile.BodyOwner.GetType());
					messageBuilder.AppendLiteral(". This is probably not a fatal problem. Pile just might be missing.");
				}
				Log.Error(messageBuilder);
				return null;
			}
			GameObject gameObject = Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(pile.Blueprint.PrefabPileID), pile.WorldPosition, Quaternion.identity, MonoSingleton<ResourcePileManager>.Instance.transform);
			if (gameObject == null)
			{
				Log.Warning("Could not instantiate pile " + pile.BlueprintId, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			HumanCarcassPileView componentInChildren = gameObject.GetComponentInChildren<HumanCarcassPileView>();
			if (componentInChildren == null)
			{
				Log.Warning("Could not instantiate carcass pile " + pile.BlueprintId + ". View component not found", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			componentInChildren.Setup(pile);
			return componentInChildren;
		}

		private static ResourcePileView ProduceBuildingResourcePileView(MovableBuildingPileInstance pile)
		{
			string prefabPileID = pile.MoveBuildingResourceInstance.Blueprint.PrefabPileID;
			GameObject prefabPile = ResourceUtils.GetPrefabPile(prefabPileID);
			if (prefabPile == null)
			{
				Log.Warning("Could not instantiate prefab " + prefabPileID, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			GameObject gameObject = Object.Instantiate(prefabPile, pile.WorldPosition, Quaternion.identity, MonoSingleton<ResourcePileManager>.Instance.transform);
			if (prefabPile == null)
			{
				Log.Warning("Could not instantiate prefab " + prefabPileID, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			BuildingPileView component = gameObject.GetComponent<BuildingPileView>();
			if (component == null)
			{
				Log.Warning("Could not instantiate carcass pile " + prefabPileID + ". View component not found", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileFactory.cs");
				return null;
			}
			component.Setup(pile);
			return component;
		}
	}
}
