using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Almanac;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.RoomDetection;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class UIInputManager : MonoSingleton<UIInputManager>, IObserver
	{
		public const string SelectRoomLink = "select_room";

		public const string SelectPenLink = "select_pen";

		public const string SelectAnimalLink = "select_animal";

		public const string SelectNPCLink = "select_enemy";

		public const string SelectWorkerLink = "select_worker";

		public const string SelectResourcePileLink = "select_pile";

		public const string SelectStorageLink = "select_storage";

		public const string SelectFactionLink = "select_faction";

		public const string SelectMaterialLink = "select_material";

		public const string SelectResearchLink = "select_research";

		private void Start()
		{
			MonoSingleton<UIController>.Instance.LinkClickedEvent += OnLinkClicked;
		}

		private static void OnLinkClicked(string linkId)
		{
			if (linkId.Equals(string.Empty))
			{
				return;
			}
			if (Repository<AlmanacRepository, NSMedieval.Almanac.Almanac>.Instance.GetByID(linkId) != null || Repository<AlmanacEntriesRepository, AlmanacEntry>.Instance.GetByName(linkId) != null)
			{
				MonoSingleton<UIController>.Instance.ShowAlmanacEntry(linkId);
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_AlmanacClick");
				return;
			}
			if (linkId.StartsWith("select_pen"))
			{
				SelectObjectPen(linkId);
				return;
			}
			if (linkId.StartsWith("select_animal"))
			{
				SelectObjectAnimal(linkId);
				return;
			}
			if (linkId.StartsWith("select_worker"))
			{
				SelectObjectWorker(linkId);
				return;
			}
			if (linkId.StartsWith("select_room"))
			{
				SelectObjectsRoom();
			}
			if (linkId.StartsWith("select_pile"))
			{
				SelectObjectResourcePile(linkId);
			}
			if (linkId.StartsWith("select_storage"))
			{
				SelectStorage(linkId);
			}
			if (linkId.StartsWith("select_enemy"))
			{
				SelectEnemy(linkId);
			}
			if (linkId.StartsWith("select_faction"))
			{
				MonoSingleton<UIController>.Instance.ShowFactionsPanel(linkId);
			}
			if (linkId.StartsWith("select_material"))
			{
				SelectMaterial(linkId);
			}
			if (linkId.StartsWith("select_research"))
			{
				SelectResearch(linkId);
			}
		}

		private static void SelectResearch(string linkId)
		{
			string nodeId = linkId.Substring("select_research".Length + 1);
			MonoSingleton<ResearchUIController>.Instance.SelectNodeExternal(nodeId);
		}

		private static void SelectObjectResourcePile(string linkId)
		{
			if (!int.TryParse(linkId.Substring("select_pile".Length + 1), out var result))
			{
				return;
			}
			ResourcePileInstance resourcePileInstance = null;
			ResourcePileView resourcePileView = null;
			foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
			{
				if (allPile.Key.UniqueId.Equals(result))
				{
					resourcePileInstance = allPile.Key;
					resourcePileView = allPile.Value;
				}
			}
			if (resourcePileInstance != null)
			{
				MonoSingleton<RtsCamera>.Instance.JumpTo(resourcePileView.transform.position);
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(resourcePileView);
			}
		}

		private static void SelectEnemy(string linkId)
		{
			if (!int.TryParse(linkId.Substring("select_enemy".Length + 1), out var result))
			{
				return;
			}
			HumanoidInstance byCreationID = MonoSingleton<NPCManager>.Instance.GetByCreationID(result);
			if (byCreationID == null)
			{
				MissingHumanCheck(result);
				return;
			}
			MonoSingleton<RtsCamera>.Instance.JumpToAndFollow(byCreationID.GetTransform());
			NPCView agentView = byCreationID.GetAgentView<NPCView>();
			if (!(agentView == null))
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(agentView);
			}
		}

		private static void SelectObjectWorker(string linkId)
		{
			if (!int.TryParse(linkId.Substring("select_worker".Length + 1), out var result) || !MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				return;
			}
			HumanoidInstance workerByCreationID = GlobalSaveController.CurrentVillageData.GetWorkerByCreationID(result);
			if (workerByCreationID == null)
			{
				MissingWorkerCheck(result);
				return;
			}
			MonoSingleton<RtsCamera>.Instance.JumpToAndFollow(workerByCreationID.GetTransform());
			WorkerView agentView = workerByCreationID.GetAgentView<WorkerView>();
			if (!(agentView == null))
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(agentView);
			}
		}

		private static void SelectObjectAnimal(string linkId)
		{
			if (!int.TryParse(linkId.Substring("select_animal".Length + 1), out var result) || !MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				return;
			}
			AnimalInstance byCreationID = MonoSingleton<AnimalManager>.Instance.GetByCreationID(result);
			if (byCreationID == null)
			{
				MissingAnimalCheck(result);
				return;
			}
			MonoSingleton<RtsCamera>.Instance.JumpToAndFollow(byCreationID.GetTransform());
			AnimalView agentView = byCreationID.GetAgentView<AnimalView>();
			if (!(agentView == null))
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(agentView);
			}
		}

		private static void MissingAnimalCheck(int creationId)
		{
			if (!IsInCaravan(creationId) && !IsCarcass(creationId))
			{
				MissingCreatureCheck(creationId);
			}
		}

		private static void MissingWorkerCheck(int creationId)
		{
			if (!IsInCaravan(creationId))
			{
				MissingHumanCheck(creationId);
			}
		}

		private static void MissingHumanCheck(int creationId)
		{
			if (!IsHumanCarcass(creationId) && !IsInGrave(creationId))
			{
				MissingCreatureCheck(creationId);
			}
		}

		private static void MissingCreatureCheck(int creationId)
		{
			if (!IsTrophyRack(creationId) && !IsTrophy(creationId))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("bbt_settler_not_available"));
			}
		}

		private static bool IsInCaravan(int creationId)
		{
			foreach (CaravanInstance caravan in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.Caravans)
			{
				foreach (HumanoidInstance worker in caravan.Workers)
				{
					if (worker.UniqueId == creationId)
					{
						MonoSingleton<CaravanController>.Instance.SelectedCaravan(caravan);
						return true;
					}
				}
				foreach (CreatureBase creature in caravan.Creatures)
				{
					if (creature.UniqueId == creationId)
					{
						MonoSingleton<CaravanController>.Instance.SelectedCaravan(caravan);
						return true;
					}
				}
			}
			return false;
		}

		private static bool IsHumanCarcass(int creationId)
		{
			bool isHumanCarcass = false;
			MonoSingleton<ResourcePileManager>.Instance.CategoryInstancesSafeOperation(ResourceCategory.CtgCarcass, delegate(IEnumerable<ResourcePileInstance> carcasses)
			{
				if (carcasses == null)
				{
					return;
				}
				foreach (ResourcePileInstance carcass in carcasses)
				{
					if (carcass is HumanCarcassPileInstance humanCarcassPileInstance && humanCarcassPileInstance.BodyOwner.UniqueId.Equals(creationId))
					{
						ResourcePileView view = MonoSingleton<ResourcePileManager>.Instance.GetView(humanCarcassPileInstance);
						if ((object)view != null)
						{
							MonoSingleton<RtsCamera>.Instance.JumpTo(view.transform.position);
							MonoSingleton<SelectableObjectManager>.Instance.SelectObject(view);
							isHumanCarcass = true;
							break;
						}
					}
				}
			});
			return isHumanCarcass;
		}

		private static bool IsCarcass(int creationId)
		{
			bool isCreatureCarcass = false;
			MonoSingleton<ResourcePileManager>.Instance.CategoryInstancesSafeOperation(ResourceCategory.CtgCarcass, delegate(IEnumerable<ResourcePileInstance> carcasses)
			{
				foreach (ResourcePileInstance carcass in carcasses)
				{
					if (carcass.GetStorage().GetSingleResource().OwnerCreationID.Equals(creationId))
					{
						ResourcePileView view = MonoSingleton<ResourcePileManager>.Instance.GetView(carcass);
						if ((object)view != null)
						{
							MonoSingleton<RtsCamera>.Instance.JumpTo(view.transform.position);
							MonoSingleton<SelectableObjectManager>.Instance.SelectObject(view);
							isCreatureCarcass = true;
							break;
						}
					}
				}
			});
			return isCreatureCarcass;
		}

		private static bool IsTrophy(int creationId)
		{
			foreach (Resource item in Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup("Trophy"))
			{
				bool isPileTrophy = false;
				MonoSingleton<ResourcePileManager>.Instance.BlueprintInstancesSafeOperation(item, delegate(IEnumerable<ResourcePileInstance> piles)
				{
					foreach (ResourcePileInstance pile in piles)
					{
						if (pile.GetStorage().GetSingleResource().OwnerCreationID.Equals(creationId))
						{
							ResourcePileView view = MonoSingleton<ResourcePileManager>.Instance.GetView(pile);
							if ((object)view != null)
							{
								MonoSingleton<RtsCamera>.Instance.JumpTo(view.transform.position);
								MonoSingleton<SelectableObjectManager>.Instance.SelectObject(view);
								isPileTrophy = true;
								break;
							}
						}
					}
				});
				if (isPileTrophy)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsTrophyRack(int creationId)
		{
			foreach (Resource item in Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup("Trophy"))
			{
				bool isPileTrophyRack = false;
				MonoSingleton<ResourcePileManager>.Instance.BlueprintInstancesSafeOperation(item, delegate(IEnumerable<ResourcePileInstance> piles)
				{
					foreach (ResourcePileInstance pile in piles)
					{
						if (pile.IsPlacedOnStorageBuilding && pile.GetStorage().GetSingleResource().OwnerCreationID.Equals(creationId))
						{
							int storageUniqueId = ResourcePileUtils.GetStorageUniqueId(pile);
							if (!storageUniqueId.Equals(0))
							{
								SelectStorage(storageUniqueId);
								isPileTrophyRack = true;
								break;
							}
						}
					}
				});
				if (isPileTrophyRack)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsInGrave(int creationId)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (GraveComponentInstance componentInstance in map.GraveComponentManager.ComponentInstances)
			{
				if (componentInstance.GetBody(out var body) && body.Owner.UniqueId.Equals(creationId))
				{
					GraveComponent component = map.GraveComponentManager.GetComponent(componentInstance);
					if (!(component == null) && !(component.BaseBuildingViewComponent == null))
					{
						MonoSingleton<RtsCamera>.Instance.JumpTo(component.BaseBuildingViewComponent.transform.position);
						MonoSingleton<SelectableObjectManager>.Instance.SelectObject(component.BaseBuildingViewComponent);
						return true;
					}
				}
			}
			return false;
		}

		private static void SelectObjectPen(string linkId)
		{
			if (!int.TryParse(linkId.Substring("select_pen".Length + 1), out var result) || !MonoSingleton<PenViewManager>.IsInstantiated() || MonoSingleton<PenViewManager>.Instance.PenInstances.Count < result)
			{
				return;
			}
			AnimalPenInstance animalPenInstance = MonoSingleton<PenViewManager>.Instance.PenInstances[result];
			if (animalPenInstance != null && animalPenInstance.PenMarkers != null && animalPenInstance.PenMarkers.Count != 0)
			{
				PenMarkerComponentInstance penMarkerComponentInstance = animalPenInstance.PenMarkers.FirstOrDefault();
				if (penMarkerComponentInstance != null)
				{
					Vector3 worldPosition = penMarkerComponentInstance.WorldPosition;
					MonoSingleton<RtsCamera>.Instance.JumpTo(worldPosition);
					BaseBuildingViewComponent view = penMarkerComponentInstance.Map.BuildingsManagerMain.GetView(penMarkerComponentInstance.OwnerBuilding);
					MonoSingleton<SelectableObjectManager>.Instance.SelectObject(view);
				}
			}
		}

		private static void SelectObjectsRoom()
		{
			if (!MonoSingleton<SelectableObjectManager>.IsInstantiated() || MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count == 0)
			{
				return;
			}
			SelectableObject selectableObject = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.First();
			if (selectableObject == null)
			{
				return;
			}
			Room room = ((!(selectableObject is WorkerView { HumanoidInstance: not null } workerView)) ? selectableObject.GetAsWorldObject()?.GetRoom() : workerView.HumanoidInstance.Map.RoomDetection.GetSingleOwnerRoom(workerView.HumanoidInstance));
			if (room != null)
			{
				RoomView view = MonoSingleton<RoomViewManager>.Instance.GetView(room);
				if (!(view == null))
				{
					MonoSingleton<SelectableObjectManager>.Instance.SelectObject(view);
				}
			}
		}

		private static void SelectStorage(string linkId)
		{
			if (int.TryParse(linkId.Substring("select_storage".Length + 1), out var result))
			{
				SelectStorage(result);
			}
		}

		private static void SelectStorage(int uniqueId)
		{
			SelectableObject byId = MonoSingleton<SelectableObjectManager>.Instance.GetById(uniqueId);
			if (!(byId == null))
			{
				MonoSingleton<RtsCamera>.Instance.JumpTo(byId.transform.position);
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(byId);
			}
		}

		private static void SelectMaterial(string linkId)
		{
			MonoSingleton<UIController>.Instance.NotifyMaterialSelect(linkId.Substring("select_material".Length + 1));
		}
	}
}
