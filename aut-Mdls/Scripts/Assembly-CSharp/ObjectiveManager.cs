#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections;
using Data.FactoryFloor.Resources;
using Data.Objectives;
using Data.Shapes;
using Data.Statistics;
using Events;
using Events.FactoryFloor;
using Events.UI.Overlays;
using Presentation.Locators;
using Presentation.UI.Overlays.Notifications;
using UnityEngine;
using Utils;

public class ObjectiveManager : MonoBehaviour
{
	[SerializeField]
	private ObjectivesManagerLocator _objectivesManagerLocator;

	[SerializeField]
	private ObjectivesPersistentSO _objectivesPersistentSO;

	[SerializeField]
	private DeliveryTargetSO _deliveryTargetSO;

	[SerializeField]
	private ModuleChallengeSO _moduleChallengeSO;

	[SerializeField]
	private StatisticsSO _statisticsSO;

	[SerializeField]
	private BotCatogoryUILibrary _botCategoryUILibrary;

	[SerializeField]
	private ChallengesUILibrary _challengesUILibrary;

	[SerializeField]
	private CurrencyUILibrary _currencyUILibrary;

	[SerializeField]
	private AudioManagerLocator _audioManagerLocator;

	[Header("Events")]
	[SerializeField]
	private AddXPEvent _addXPEvent;

	[SerializeField]
	private AddCurrencyEvent _addCurrencyEvent;

	[SerializeField]
	private BaseEvent _finishedLoadingSaveEvent;

	[SerializeField]
	private ResourceDeliveredEventSO _resourceDeliveredEvent;

	[SerializeField]
	private ShowIngameNotificationEvent _showIngameNotificationEvent;

	[SerializeField]
	private BaseEvent _moduleChallengeCompleted;

	public ModuleChallengeSO ModuleChallengeSO => _moduleChallengeSO;

	public ObjectivesPersistentSO ObjectivesPersistentSO => _objectivesPersistentSO;

	private void Awake()
	{
		_objectivesManagerLocator.ObjectivesManager = this;
		_moduleChallengeSO.InitModuleViewerDatas();
		_finishedLoadingSaveEvent.Register(SetupAllResources);
	}

	private void Start()
	{
		_resourceDeliveredEvent.RegisterMainThread(HandleResourceDelivered);
	}

	private void OnDestroy()
	{
		_resourceDeliveredEvent.UnRegisterMainThread(HandleResourceDelivered);
		_finishedLoadingSaveEvent.UnRegister(SetupAllResources);
	}

	private void SetupAllResources()
	{
		foreach (ObjectiveTargetCategorySO category in _deliveryTargetSO.Categories)
		{
			SetupResourceObjective(category, XPEarnedSource.DeliveryTargets);
		}
		foreach (ModuleChallengeSet set in _moduleChallengeSO.Sets)
		{
			foreach (ObjectiveTargetCategorySO category2 in set.Categories)
			{
				SetupResourceObjective(category2, XPEarnedSource.ModuleChallenges);
			}
		}
	}

	private void HandleResourceDelivered(Resource resource)
	{
		if (resource is ShapeResource shapeResource)
		{
			HandleShapeResourceDelivered(shapeResource.ShapeData.RotationIndependantHash);
		}
		else
		{
			HandleNonShapeResourceDelivered(resource.Data.ID);
		}
	}

	private void HandleNonShapeResourceDelivered(int resourceID)
	{
		foreach (ObjectiveTargetCategorySO objectiveTargetCategory in _deliveryTargetSO.Categories)
		{
			if (objectiveTargetCategory.Resource.GetResourceID() == resourceID)
			{
				Action<int> onItemClaimedCallback = delegate(int currentTier)
				{
					AwardObjectiveRewards(objectiveTargetCategory, XPEarnedSource.DeliveryTargets, currentTier);
				};
				SetupResourceObjective(objectiveTargetCategory, XPEarnedSource.DeliveryTargets, onItemClaimedCallback);
				break;
			}
		}
	}

	private void HandleShapeResourceDelivered(RotationIndependentHash rotationIndependentHash)
	{
		foreach (ModuleChallengeSet set in _moduleChallengeSO.Sets)
		{
			foreach (ObjectiveTargetCategorySO category in set.Categories)
			{
				ObjectiveTargetCategorySO objectiveTargetCategory = category;
				if (!(objectiveTargetCategory.Resource.GetRotationIndependentHash() != rotationIndependentHash))
				{
					SetupResourceObjective(objectiveTargetCategory, XPEarnedSource.ModuleChallenges, onItemClaimedCallback);
					return;
				}
				void onItemClaimedCallback(int currentTier)
				{
					AwardObjectiveRewards(objectiveTargetCategory, XPEarnedSource.ModuleChallenges, currentTier);
				}
			}
		}
	}

	private void SetupResourceObjective(ObjectiveTargetCategorySO objectiveTargetCategory, XPEarnedSource xpEarnedSource, Action<int> onItemClaimedCallback = null)
	{
		if (!objectiveTargetCategory.Resource.HasResourceData && !objectiveTargetCategory.Resource.HasShapeData)
		{
			this.DevException("Current object has no resource or shape data: " + objectiveTargetCategory.name, "SetupResourceObjective", 121);
			return;
		}
		uint deliveredAmount = objectiveTargetCategory.DeliveredAmount;
		int alreadyClaimedTiers;
		Action<int> action = ((!objectiveTargetCategory.Resource.HasResourceData) ? SetupShapeDataObjective(objectiveTargetCategory, deliveredAmount, out alreadyClaimedTiers) : SetupResourceDataObjective(objectiveTargetCategory, out alreadyClaimedTiers));
		if (alreadyClaimedTiers >= objectiveTargetCategory.Items.Count)
		{
			return;
		}
		if (onItemClaimedCallback != null)
		{
			action = (Action<int>)Delegate.Combine(action, onItemClaimedCallback);
		}
		if (alreadyClaimedTiers < objectiveTargetCategory.CurrentTier)
		{
			for (int i = alreadyClaimedTiers; i < objectiveTargetCategory.CurrentTier; i++)
			{
				action(i);
			}
		}
	}

	private Action<int> SetupResourceDataObjective(ObjectiveTargetCategorySO objectiveTargetCategory, out int alreadyClaimedTiers)
	{
		int resourceId = objectiveTargetCategory.Resource.GetResourceID();
		alreadyClaimedTiers = _objectivesPersistentSO.GetDeliveryTargetClaimedTiersAmount(resourceId);
		return delegate(int claimedTier)
		{
			_objectivesPersistentSO.SetDeliveryTargetClaimedTier(resourceId, claimedTier);
		};
	}

	private Action<int> SetupShapeDataObjective(ObjectiveTargetCategorySO objectiveTargetCategory, uint deliveredAmount, out int alreadyClaimedTiers)
	{
		RotationIndependentHash shapeHash = objectiveTargetCategory.Resource.GetRotationIndependentHash();
		alreadyClaimedTiers = _objectivesPersistentSO.GetModuleChallengeClaimedTier(shapeHash);
		_moduleChallengeSO.SetShapeDeliveredModuleChallenge(shapeHash, deliveredAmount);
		return delegate(int claimedTier)
		{
			_objectivesPersistentSO.SetModuleChallengeClaimedTier(shapeHash, claimedTier);
		};
	}

	private void AwardObjectiveRewards(ObjectiveTargetCategorySO objectiveTargetCategory, XPEarnedSource xpEarnedSource, int currentTier)
	{
		ObjectiveTargetItem objectiveTargetItem = objectiveTargetCategory.Items[currentTier];
		_addXPEvent.Fire((int)objectiveTargetItem.XpReward, xpEarnedSource);
		_addCurrencyEvent.Fire(new AddCurrencyEventDto(objectiveTargetItem.CurrenyRewardResourceData, (int)objectiveTargetItem.CurrencyReward));
		if (objectiveTargetCategory.Resource.HasResourceData)
		{
			AwardDeliveryTarget(objectiveTargetCategory, currentTier, objectiveTargetItem);
		}
		else if (objectiveTargetCategory.Resource.HasShapeData)
		{
			AwardModuleChallenge(objectiveTargetCategory, currentTier, objectiveTargetItem);
		}
	}

	private void AwardDeliveryTarget(ObjectiveTargetCategorySO objectiveTargetCategory, int currentTier, ObjectiveTargetItem currentTierItem)
	{
		InGameNotificationDto data = new InGameNotificationDto(deliveriesNotificationDto: new InGameObjectivesNotificationDto(_botCategoryUILibrary.CategoryUIs[objectiveTargetCategory].color, currentTier, currentTierItem.XpReward), labelText: string.Format(LocalizationUtility.GetLocalizedText("DeliverTargets.Notification"), LocalizationUtility.GetLocalizedText(objectiveTargetCategory.Resource.ResourceData.NameLocaKey), currentTier + 1), sprite: objectiveTargetCategory.Resource.Icon, type: InGameNotificationType.Delivery);
		_showIngameNotificationEvent.Fire(data);
		_audioManagerLocator.AudioManager.PlayDeliveryTargetComplete();
	}

	private void AwardModuleChallenge(ObjectiveTargetCategorySO objectiveTargetCategory, int currentTier, ObjectiveTargetItem currentTierItem)
	{
		InGameNotificationDto data = new InGameNotificationDto(deliveriesNotificationDto: new InGameObjectivesNotificationDto(Color.white, currentTier, currentTierItem.XpReward, _currencyUILibrary.CurrencyUIs[currentTierItem.CurrenyRewardResourceData].Sprite, currentTierItem.CurrencyReward), labelText: LocalizationUtility.GetLocalizedText(objectiveTargetCategory.ModuleNameLocaKey) + " - " + LocalizationUtility.GetLocalizedText(_challengesUILibrary.TierLocaKeys[currentTier]), sprite: objectiveTargetCategory.Resource.Icon, type: InGameNotificationType.Challenge);
		_showIngameNotificationEvent.Fire(data);
		_moduleChallengeCompleted.Fire();
		if (_moduleChallengeSO.CheckChallengeSetCompleted(currentTierItem, out var claimedItemSet))
		{
			_audioManagerLocator.AudioManager.PlayModuleChallengeComplete();
			StartCoroutine(RewardCosmetic(claimedItemSet));
		}
		else
		{
			_audioManagerLocator.AudioManager.PlayNotificationReward();
		}
	}

	private IEnumerator RewardCosmetic(ModuleChallengeSet completedSet)
	{
		yield return new WaitForSeconds(0.3f);
		InGameNotificationDto data = new InGameNotificationDto(LocalizationUtility.GetLocalizedText("ModuleChallenges.CosmeticUnlocked"), completedSet.RewardThumbnail, InGameNotificationType.Reward);
		_showIngameNotificationEvent.Fire(data);
	}
}
