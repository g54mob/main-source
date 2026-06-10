using System.Collections;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using TwitchIntegration;
using UnityEngine;
using UnityEngine.Networking;

namespace NSMedieval
{
	public class TwitchController : MonoSingleton<TwitchController>
	{
		private OptimizedTwitchNameCollection usedUsersNames;

		private OptimizedTwitchNameCollection usersWaitingForNames;

		private OptimizedTwitchNameCollection usersInChat;

		private bool isGameWorking;

		private float lastGiftTime;

		private float lastStrikeTime;

		private Vector3 mysteryManResourceSpawnPosition;

		private void Start()
		{
			lastGiftTime = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchGiftCommandCooldown;
			lastStrikeTime = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchStrikeCommandCooldown;
			base.gameObject.AddComponent<TwitchCommandListener>();
			usersWaitingForNames = new OptimizedTwitchNameCollection();
			usedUsersNames = new OptimizedTwitchNameCollection();
			usersInChat = new OptimizedTwitchNameCollection();
			TwitchManager.OnTwitchMessageReceived += OnChatMessage;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += SubscribeGameEvents;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += HandleLeavingToMainSceneEvent;
		}

		protected override void OnDestroy()
		{
			usersWaitingForNames = null;
			usedUsersNames = null;
			usersInChat = null;
			TwitchManager.OnTwitchMessageReceived -= OnChatMessage;
			if (MonoSingleton<CreatureManager>.IsInstantiated())
			{
				MonoSingleton<CreatureManager>.Instance.CreatureCreatedEvent -= TrySetTwitchName;
				MonoSingleton<CreatureManager>.Instance.CreatureDestroyedEvent -= ClearUsedTwitchName;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= SubscribeGameEvents;
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= HandleLeavingToMainSceneEvent;
			}
			base.OnDestroy();
		}

		private void Update()
		{
			lastGiftTime += Time.deltaTime;
			lastStrikeTime += Time.deltaTime;
		}

		private void SubscribeGameEvents()
		{
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= SubscribeGameEvents;
			MonoSingleton<CreatureManager>.Instance.CreatureCreatedEvent += TrySetTwitchName;
			MonoSingleton<CreatureManager>.Instance.CreatureDestroyedEvent += ClearUsedTwitchName;
		}

		private void HandleLeavingToMainSceneEvent()
		{
			if (MonoSingleton<CreatureManager>.IsInstantiated())
			{
				MonoSingleton<CreatureManager>.Instance.CreatureCreatedEvent -= TrySetTwitchName;
				MonoSingleton<CreatureManager>.Instance.CreatureDestroyedEvent -= ClearUsedTwitchName;
			}
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += SubscribeGameEvents;
		}

		public void CheckDrops()
		{
			StopAllCoroutines();
			StartCoroutine(GetTwitchDrops());
		}

		private IEnumerator GetTwitchDrops()
		{
			if (!TwitchManager.IsAuthenticated)
			{
				yield break;
			}
			using UnityWebRequest request = UnityWebRequest.Get("https://api.twitch.tv/helix/entitlements/drops");
			request.SetRequestHeader("Authorization", "Bearer " + TwitchManager.Authenticator.GetAccessToken());
			request.SetRequestHeader("Client-Id", TwitchManager.Authenticator.GetClientId());
			yield return request.SendWebRequest();
			if (request.result != UnityWebRequest.Result.Success || request.downloadHandler == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\TwitchController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error fetching drops: ");
					messageBuilder.AppendFormatted(request.error);
				}
				Log.Error(messageBuilder);
				string text = MonoSingleton<LocalizationController>.Instance.GetText("twitch_drops_bbt_none");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
				yield break;
			}
			int num = 0;
			TwitchDropsContainer twitchDropsContainer = JsonUtility.FromJson<TwitchDropsContainer>(request.downloadHandler.text);
			if (twitchDropsContainer?.data == null)
			{
				Log.Warning("No drops data received or failed to parse JSON.", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\TwitchController.cs");
				string text2 = MonoSingleton<LocalizationController>.Instance.GetText("twitch_drops_bbt_none");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text2);
				yield break;
			}
			foreach (TwitchDropData datum in twitchDropsContainer.data)
			{
				if (MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(datum.benefit_id))
				{
					MonoSingleton<GlobalSaveController>.Instance.RemoveFromLockedBuildings(datum.benefit_id);
					string text3 = MonoSingleton<LocalizationController>.Instance.GetText("twitch_drops_bbt");
					string localizedName = BuildingUtils.GetLocalizedName(datum.benefit_id);
					text3 = text3.Replace("{drop}", localizedName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text3);
					num++;
				}
			}
			if (num <= 0)
			{
				string text4 = MonoSingleton<LocalizationController>.Instance.GetText("twitch_drops_bbt_none");
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text4);
			}
			else
			{
				MonoSingleton<GlobalSaveController>.Instance.SerializeUserData();
			}
		}

		public void TwitchNameCommand(TwitchUser user)
		{
			if (LoadingController.IsLoadingComplete && !LoadingController.IsLeavingMainScene && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchNameCommandEnabled)
			{
				string displayname = user.displayname;
				if (!usersWaitingForNames.Contains(displayname) && !usedUsersNames.Contains(displayname))
				{
					usersWaitingForNames.AddName(displayname);
				}
			}
		}

		public void AnimalAppearCommand(TwitchUser user)
		{
			if (LoadingController.IsLoadingComplete && !LoadingController.IsLeavingMainScene && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchAppearCommandEnabled && !usedUsersNames.Contains(user.displayname))
			{
				SmallAnimalEvent(user.displayname);
			}
		}

		public void MysteryGiftCommand(TwitchUser user)
		{
			if (LoadingController.IsLoadingComplete && !LoadingController.IsLeavingMainScene && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchGiftCommandEnabled && !((float)MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchGiftCommandCooldown > lastGiftTime))
			{
				lastGiftTime = 0f;
				MysteriousManEvent(user.displayname);
			}
		}

		public void StrikeCommand(TwitchUser user)
		{
			if (LoadingController.IsLoadingComplete && !LoadingController.IsLeavingMainScene && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchStrikeCommandEnabled && !((float)MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchStrikeCommandCooldown > lastStrikeTime))
			{
				lastStrikeTime = 0f;
				StrikeEvent(user.displayname);
			}
		}

		public string GetTwitchName()
		{
			string result = string.Empty;
			if (usersWaitingForNames.Count > 0)
			{
				result = usersWaitingForNames.GetRandomName();
				usersWaitingForNames.RemoveName(result);
			}
			else if (usersInChat.Count > 0)
			{
				result = usersInChat.GetRandomName();
				usersInChat.RemoveName(result);
			}
			usedUsersNames.AddName(result);
			return result;
		}

		private void TrySetTwitchName(CreatureBase creature)
		{
			if (usersWaitingForNames.Count <= 0)
			{
				return;
			}
			string randomName = usersWaitingForNames.GetRandomName();
			usersWaitingForNames.RemoveName(randomName);
			usedUsersNames.AddName(randomName);
			if (creature is AnimalInstance animalInstance)
			{
				animalInstance.SetName(randomName);
				return;
			}
			creature.GetCharacterInfo().SetFirstName(randomName);
			if (creature is HumanoidInstance humanoidInstance)
			{
				NPCView agentView = humanoidInstance.GetAgentView<NPCView>();
				if (agentView != null)
				{
					agentView.HandleUpdateName();
				}
				if (humanoidInstance.IsWorker())
				{
					MonoSingleton<WorkerController>.Instance.WorkerNameChanged(humanoidInstance);
				}
			}
		}

		public void ClearUsedTwitchName(CreatureBase creature)
		{
			if (creature is AnimalInstance animalInstance)
			{
				ClearUsedTwitchName(animalInstance.GetFullName());
			}
			else
			{
				ClearUsedTwitchName(creature.GetCharacterInfo().FirstName);
			}
		}

		private void ClearUsedTwitchName(string twitchName)
		{
			if (usedUsersNames.Contains(twitchName))
			{
				usedUsersNames.RemoveName(twitchName);
			}
		}

		private void OnChatMessage(TwitchUser user, string message)
		{
			if (!usersInChat.Contains(user.displayname) && !usedUsersNames.Contains(user.displayname))
			{
				usersInChat.AddName(user.displayname);
			}
		}

		private void SmallAnimalEvent(string twitchName)
		{
			AnimalInstance animal = SpawnAnimal();
			if (animal == null)
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitFor(0.5f).Then(delegate
			{
				if (animal != null && !animal.HasDisposed)
				{
					animal.GetGoapAgent()?.StartTicker();
				}
			});
			string text = MonoSingleton<LocalizationController>.Instance.GetText("TwitchAnimalSpawnBbt");
			string localizedName = AnimalUtils.GetLocalizedName(animal.Blueprint);
			text = text.Replace("{Animal}", localizedName);
			text = text.Replace("{Twitch Name}", twitchName);
			MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(text, animal.GetGoapAgent().GetView());
			animal.SetName(twitchName);
			usersWaitingForNames.RemoveName(twitchName);
			usedUsersNames.AddName(twitchName);
		}

		private AnimalInstance SpawnAnimal()
		{
			TwitchEventsData byID = Repository<TwitchEventsRepository, TwitchEventsData>.Instance.GetByID("AnimalSpawn");
			float animalPoints = byID.GetInterpolatedValue((int)MonoSingleton<BaseWealth>.Instance.GetTotalWealth());
			Animal animal = Repository<AnimalBaseRepository, Animal>.Instance.GetAllItems().PickRandom((Animal animal2) => (float)animal2.GetPrice() < animalPoints);
			BodyType bodyType = ((!(Random.Range(0f, 1f) <= 0.5f)) ? BodyType.Male : BodyType.Female);
			float lifePhasePercent = Random.Range(0f, 0.95f);
			MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoors(), out var _, out var outStartingNodes, 1);
			if (outStartingNodes.Count <= 0)
			{
				return null;
			}
			Vector3 worldPosition = outStartingNodes[0].WorldPosition;
			AnimalType randomAnimalType = byID.GetRandomAnimalType();
			return MonoSingleton<AnimalManager>.Instance.SpawnAnimal(animal.GetID(), worldPosition, bodyType, -1, lifePhasePercent, isInIncognitoMode: false, randomAnimalType);
		}

		private void MysteriousManEvent(string mysteryName)
		{
			MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoors(), out var _, out var outStartingNodes, 1);
			if (outStartingNodes.Count <= 0)
			{
				return;
			}
			mysteryManResourceSpawnPosition = outStartingNodes[0].WorldPosition;
			TwitchEventsData byID = Repository<TwitchEventsRepository, TwitchEventsData>.Instance.GetByID("MysteryGift");
			float giftValue = byID.GetInterpolatedValue((int)MonoSingleton<BaseWealth>.Instance.GetTotalWealth());
			ResourceCategory resourceCategory = EnumValues.AllResourceCategories.PickRandom((ResourceCategory item) => item != ResourceCategory.None);
			Resource resource = Repository<ResourceRepository, Resource>.Instance.GetAllResourcesByResourceCategory(resourceCategory).PickRandom(delegate(Resource item)
			{
				if (item.WealthPoints > giftValue || item.UniqueResource)
				{
					return false;
				}
				if ((item.Category & (ResourceCategory.CtgHumanCarcass | ResourceCategory.CtgCarcass)) != ResourceCategory.None)
				{
					return false;
				}
				return ((item.Category & ResourceCategory.CtgStructure) == 0 || !LockedBuildingsManager.DefaultLockedBuildings.Contains(item.BuildingBlueprintID)) ? true : false;
			});
			if (resource == null)
			{
				lastGiftTime = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchGiftCommandCooldown;
				return;
			}
			int amount = Mathf.FloorToInt(giftValue / resource.WealthPoints);
			ResourceInstance resourceInstance = new ResourceInstance(resource, amount);
			resourceInstance.SetProducerUniqueId(MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.PickRandom()?.UniqueId ?? 0);
			MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance, mysteryManResourceSpawnPosition);
			string text = MonoSingleton<LocalizationController>.Instance.GetText("TwitchMysteryGiftBody");
			text = text.Replace("{mysteryName}", mysteryName);
			DialogContent dialogContent = new DialogContent
			{
				WindowTitle = "TwitchMysteryGiftWindowTitle",
				ContentTitle = "TwitchMysteryGiftContentTitle",
				ContentBodyText = text,
				ContentBodyImagePath = "event_ambush",
				ShowCloseButton = true,
				Options = new List<DialogOption>
				{
					new DialogOption
					{
						Text = "general_ok"
					},
					new DialogOption
					{
						Text = "general_jump_to_location"
					}
				}
			};
			dialogContent.Localize();
			NewsData newsData = new NewsData("TwitchMysteryGiftWindowTitle", "NewsGray", "", dialogContent, mysteryManResourceSpawnPosition, 1);
			newsData.Localize();
			MonoSingleton<AudioManager>.Instance.PlayStinger("EventDefault");
			MonoSingleton<NewsManager>.Instance.Publish(newsData);
			MonoSingleton<NewsManager>.Instance.OnDialogClosed += OnMysteryManDialogClosed;
		}

		private void OnMysteryManDialogClosed(uint newsId, int chosenOptionIndex)
		{
			MonoSingleton<NewsManager>.Instance.OnDialogClosed -= OnMysteryManDialogClosed;
			if (chosenOptionIndex != 0 && chosenOptionIndex == 1)
			{
				MonoSingleton<RtsCamera>.Instance.JumpTo(mysteryManResourceSpawnPosition);
			}
		}

		private void StrikeEvent(string twitchName)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText("twitch_strike_event_bbt");
			text = text.Replace("{Twitch Name}", twitchName);
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
			ThunderstormEvent thunderstormEvent = new ThunderstormEvent();
			thunderstormEvent.SetBlueprint(Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID("game_event_twitch_thunder"));
			thunderstormEvent.Start();
		}
	}
}
