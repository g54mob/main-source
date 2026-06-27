namespace Restory.Utils
{
	public static class LocalizationKeysConstants
	{
		public static class ItemActivatorMessages
		{
			public const string ItemIsNotUsableId = "UI_ITEM_CAN_NOT_BE_USED";

			public const string StorageIsFullId = "ACTION_REQUIREMENT_MESSAGE_STORAGE_FULL";

			public const string CanNotPutItemIntoStorage = "UI_MESSAGE_CANNOT_PUT_ITEM_INTO_STORAGE";

			public const string InventoryIsFullId = "ACTION_REQUIREMENT_MESSAGE_INVENTORY_FULL";
		}

		public static class CharacterPhrases
		{
			public const string TooHungryToSleep = "CHAR_PHRASE_TOO_HUNGRY_TO_SLEEP";

			public const string TooHungryToRest = "CHAR_PHRASE_TOO_HUNGRY_TO_REST";
		}

		public static class GuiTexts
		{
			public static class WebBrowser
			{
				public static class Shop
				{
					public const string TotalItemsInCart = "UI_SHOP_TEXT_ITEMS";
				}

				public const string BankBalance = "UI_BROWSER_TEXT_BANK_BALANCE";
			}

			public static class Fishing
			{
				public const string ButtonStartFishingWithBait = "UI_START_FISHING";

				public const string ButtonStartFishingWithNoBait = "UI_START_FISHING_WITH_NO_BAIT";
			}

			public static class FishCutting
			{
				public const string CuttingBoardMainInfoName = "UI_FISH_CUTTING_BOARD_NAME";

				public const string CuttingBoardMainInfoDescription = "UI_FISH_CUTTING_BOARD_DESC";

				public const string PossibleRewardsText = "UI_TEXT_FISH_CUTTING_POSSIBLE_REWARDS";

				public const string FoundRewardsText = "UI_TEXT_FISH_CUTTING_FOUND_REWARDS";

				public const string CuttingButtonStartText = "UI_BUTTON_CUT_FISH";

				public const string CuttingButtonContinueText = "UI_BUTTON_CUT_FISH_AGAIN";
			}

			public static class Minions
			{
				public const string PauseMinion = "UI_MINION_PANEL_BUTTON_PAUSE";

				public const string UnpauseMinion = "UI_MINION_PANEL_BUTTON_PLAY";
			}

			public static class DayTime
			{
				public const string Today = "UI_DAY_OF_WEEK_TODAY";

				public const string Tomorrow = "UI_DAY_OF_WEEK_TOMORROW";

				public const string Day = "UI_DAYS_PASSED_DAY";

				public const string Night = "UI_TIME_OF_DAY_NIGHT";
			}

			public const string CurrentGameVersionId = "UI_TEXT_GAME_VERSION";

			public const string BuildingNeedsToBeUpgradedTo = "UI_BUILDING_UPGRADE_REQUIREMENT";

			public const string WhereToFind = "UI_TEXT_WHERE_TO_FIND";

			public const string ChestName = "UI_STORAGE_SEGMENT_DEFAULT_LOOT";

			public const string ElectricityNetworkIsOnline = "UI_TEXT_ELECTRICITY_NETWORK_IS_ONLINE";

			public const string ElectricityNetworkIsOffline = "UI_TEXT_ELECTRICITY_NETWORK_IS_OFFLINE";

			public const string AllModelsText = "UI_TEXT_ALL";
		}

		public static class ActionMessages
		{
			public const string DestroyBuildingConfirmationId = "ACTION_DESTROY_BUILDING_CONFIRM";

			public const string BlockEnemyNestConfirmationId = "ACTION_BLOCK_ENEMY_NEST_CONFIRM";

			public const string RemainingLootDroppedWhenTryingToCollectId = "ACTION_COLLECT_LOOT_DROP_REMAINDER";

			public const string RemainingLootLeftWhenTryingToCollectId = "ACTION_COLLECT_LOOT_LEAVE_REMAINDER";

			public const string BucketIsAlreadyFilledId = "BUCKET_ALREADY_FILLED";
		}

		public static class GameMessages
		{
			public const string NoSprayLeftId = "PLAYER_HAS_NO_DISINFECTION_SPRAY_LEFT_MESSAGE";
		}

		public static class RequirementsNotPleased
		{
			public static class SystemNotifications
			{
				public const string ActorHasNoComponentId = "ACTION_REQUIREMENT_MESSAGE_ACTOR_HAS_NO_COMPONENT";

				public const string ActorStateMachineHasNoStateId = "ACTION_REQUIREMENT_MESSAGE_ACTOR_STATE_MACHINE_HAS_NO_STATE";

				public const string ActorHasDifferentTagId = "ACTION_REQUIREMENT_MESSAGE_ACTOR_HAS_DIFFERENT_TAG";

				public const string ActorIsNullId = "ACTION_REQUIREMENT_MESSAGE_ACTOR_IS_NULL";

				public const string InteractiveObjectIsNullId = "ACTION_REQUIREMENT_MESSAGE_INTERACTIVE_OBJECT_IS_NULL";

				public const string InteractiveObjectHasNoComponentId = "ACTION_REQUIREMENT_MESSAGE_INTERACTIVE_OBJECT_HAS_NO_COMPONENT";

				public const string InteractiveObjectHasDifferentTagId = "ACTION_REQUIREMENT_MESSAGE_INTERACTIVE_OBJECT_HAS_DIFFERENT_TAG";

				public const string InteractiveObjectHasActiveModalId = "ACTION_REQUIREMENT_MESSAGE_INTERACTIVE_OBJECT_HAS_ACTIVE_MODAL";

				public const string LootsetHoldsDifferentTypeOfLootId = "ACTION_REQUIREMENT_MESSAGE_LOOTSET_HOLDS_DIFFERENT_TYPE_OF_LOOT";
			}

			public static class UserNotifications
			{
				public class Minions
				{
					public const string MinionIsNotActive = "MINION_ACTION_REQUIREMENT_MINION_IS_NOT_ACTIVE";

					public const string MinionIsBroken = "MINION_ACTION_REQUIREMENT_MINION_IS_BROKEN";
				}

				public const string ItemIsNotUsableId = "UI_ITEM_CAN_NOT_BE_USED";

				public const string StorageIsFullId = "ACTION_REQUIREMENT_MESSAGE_STORAGE_FULL";

				public const string StorageIsEmptyId = "ACTION_REQUIREMENT_MESSAGE_STORAGE_EMPTY";

				public const string InventoryIsFullId = "ACTION_REQUIREMENT_MESSAGE_INVENTORY_FULL";

				public const string StackIsFullId = "ACTION_REQUIREMENT_MESSAGE_STACK_IS_FULL";

				public const string NoPlaceForCraftingResultId = "ACTION_REQUIREMENT_MESSAGE_NO_PLACE_FOR_CRAFT_RESULT";

				public const string CraftingStationIsBusyId = "ACTION_REQUIREMENT_MESSAGE_CRAFTING_STATION_IS_BUSY";

				public const string LootIsEmptyId = "ACTION_REQUIREMENT_MESSAGE_EMPTY_LOOT";

				public const string SourceIsEmptyId = "ACTION_REQUIREMENT_MESSAGE_SOURCE_EMPTY";

				public const string ActorIsTooFarId = "ACTION_REQUIREMENT_MESSAGE_TOO_FAR";

				public const string ActorIsBusyId = "ACTION_REQUIREMENT_MESSAGE_ACTOR_BUSY";

				public const string ActorNeedsMoreId = "ACTION_REQUIREMENT_MESSAGE_NEED_MORE";

				public const string ActorIsNotAllowedToPerformActionId = "ACTION_REQUIREMENT_MESSAGE_NOT_ALLOWED";

				public const string CharacterBackpackFullyExpandedId = "CHAR_BACK_PACK_FULLY_EXPANDED";

				public const string CarryingWrongObjectId = "ACTION_REQUIREMENT_MESSAGE_THE_CARRIED_OBJECT_IS_NOT_THE_ONE_REQUIRED";

				public const string CarryingObjectNotAcceptedByStorageId = "ACTION_REQUIREMENT_MESSAGE_THE_CARRIED_OBJECT_IS_NOT_ACCEPTED_BY_THIS_STORAGE";

				public const string CarryingResourceNotCurrentlySelectedInNanoForgeId = "UI_ADVICE_SELECT_OTHER_ITEM";

				public const string NanoForgeHasNoRecipeSelectedId = "UI_ADVICE_SELECT_RECIPE";

				public const string CharacterIsNotInCarryModeId = "ACTION_REQUIREMENT_MESSAGE_NOT_CARRY";

				public const string CharacterIsInCarryModeId = "ACTION_REQUIREMENT_MESSAGE_CARRY";

				public const string CharacterIsNotCarryingAnItemId = "ACTION_REQUIREMENT_MESSAGE_CHARACTER_NOT_CARRY";

				public const string NotEnoughSpaceInInventoryId = "ACTION_REQUIREMENT_MESSAGE_CHARACTER_NOT_ENOUGH_SPACE";

				public const string CharacterCannotTransferObjectToTableId = "ACTION_REQUIREMENT_MESSAGE_CAN_NOT_TRANSFER_TO_TABLE";

				public const string CharacterIsTooHungryToSleepId = "ACTION_REQUIREMENT_MESSAGE_CAN_NOT_FALL_ASLEEP";

				public const string CharacterIsTooHungryToRestId = "ACTION_REQUIREMENT_MESSAGE_TOO_HUNGRY_TO_REST";

				public const string InteractiveObjectIsNotFuelConsumerId = "ACTION_REQUIREMENT_MESSAGE_NOT_FUEL_CONSUMER";

				public const string InteractiveObjectIsNotElectricityNodeId = "ACTION_REQUIREMENT_MESSAGE_NOT_ELECTRICITY_NODE";

				public const string CableHasConnectionId = "ACTION_REQUIREMENT_MESSAGE_CABLE_HAS_CONNECTION";

				public const string CableIsNotLongEnoughId = "ACTION_REQUIREMENT_MESSAGE_CABLE_NOT_LENGTH_ENOUGH";

				public const string HeightDifferenceIsTooBigId = "ACTION_REQUIREMENT_MESSAGE_MUCH_HEIGHT_DIFFERENCE";

				public const string DialogueActorHasNothingToDiscussId = "ACTION_REQUIREMENT_MESSAGE_NOTHING_TO_DISCUSS";

				public const string BuildingIsAlreadyInTargetStateId = "ACTION_REQUIREMENT_MESSAGE_BUILDING_IS_ALREADY_IN_TARGET_STATE";

				public const string NothingToDisassembleId = "ACTION_REQUIREMENT_MESSAGE_NOTHING_DISASSEMBLE";

				public const string CantStoreDisassembledObject = "ACTION_REQUIREMENT_DENIED_STORAGE_OF_DISASSEMBLED_OBJECTS";

				public const string CannotCompleteActionThatHasNotBeenStartedId = "ACTION_REQUIREMENT_MESSAGE_ACTION_NOT_STARTED";

				public const string NoAvailableSlotsForConnectionId = "ACTION_REQUIREMENT_MESSAGE_NOT_AVAILABLE_SLOTS";

				public const string ElectricityNodesAreNotConnectedId = "ACTION_REQUIREMENT_MESSAGE_NO_CONNECTION";

				public const string IsFullId = "ACTION_REQUIREMENT_MESSAGE_FULL";

				public const string IsAlreadyDeadId = "ACTION_REQUIREMENT_MESSAGE_DEAD";

				public const string IsNotBrokenId = "ACTION_REQUIREMENT_MESSAGE_NOT_BROKEN";

				public const string IsNotTheTimeToBeWateredId = "ACTION_REQUIREMENT_MESSAGE_NOT_TIME_FOR_WATER_PLANT";

				public const string RepairingProcessHasAlreadyStartedId = "ACTION_REQUIREMENT_MESSAGE_REPAIRING_STARTED";

				public const string NotEnoughHpId = "NOT_ENOUGH_HP";

				public const string CannotBeRepairedId = "ACTION_REQUIREMENT_MESSAGE_CAN_NOT_REPAIRED";

				public const string QteInProcessId = "ACTION_REQUIREMENT_MESSAGE_QTE_IN_PROCESS";

				public const string WaterStorageNotEnoughWaterId = "WATER_STORAGE_NOT_ENOUGH_WATER";

				public const string WaterStorageIsFullId = "WATER_STORAGE_IS_FULL";

				public const string WaterStorageAlreadyHasDifferentWaterType = "WATER_STORAGE_HAS_DIFFERENT_WATER_TYPE";

				public const string WaterStorageHasNoWaterOfRequiredType = "WATER_STORAGE_HAS_NO_WATER_OF_REQUIRED_TYPE";

				public const string NoSuitableBucketInInventory = "ACTION_REQUIREMENT_NO_SUITABLE_BUCKET_IN_INVENTORY";

				public const string NeedMoreFuel = "ACTION_REQUIREMENT_NEED_MORE_FUEL";

				public const string NoItemsFromOutsideAllowed = "ACTION_REQUIREMENT_MESSAGE_NOT_ALLOW_ITEMS_FROM_OUTSIDE";

				public const string NPCSlotNotFree = "ACTION_REQUIREMENT_NPC_SLOT_NOT_FREE";

				public const string IngredientsAlreadyLoaded = "ACTION_REQUIRMENT_MESSAGE_INGREDIENTS_ARE_ALREADY_LOADED";

				public const string IngredientsNotLoaded = "ACTION_REQUIRMENT_MESSAGE_INGREDIENTS_ARE_NOT_LOADED";

				public const string NotEnoughIngredientsInInventory = "ACTION_REQUIRMENT_MESSAGE_NOT_ENOUGH_INGREDIENTS_IN_INVENTORY";

				public const string NeedEhancementModule = "ACTION_REQUIREMENT_ENHANCEMENT_MODULE";

				public const string ExpeditionDeniedAtNight = "ACTION_REQUIREMENT_EXPEDITION_DENIED_AT_NIGHT";

				public const string CharacterCannotPickUpMore = "ACTION_REQUIREMENT_MESSAGE_CHARACTER_CANNOT_CARRY_MORE";

				public const string CharacterCannotHarvestPlant = "ACTION_REQUIREMENT_MESSAGE_CANNOT_HARVEST_PLANT";

				public const string TransferInProgress = "UI_CHARACTER_ACTIVITY_ADVICE_TRANSFER_IN_PROGRESS";

				public const string AlreadyOpen = "ALREADY_OPEN";

				public const string AlreadyClosed = "ALREADY_CLOSED";

				public const string GiftAlreadyReceivedToday = "ACTION_REQUIREMENT_MESSAGE_GIFT_ALREADY_RECEIVED_TODAY";

				public const string NoAcceptableGiftInInventory = "ACTION_REQUIREMENT_MESSAGE_NO_ACCEPTABLE_GIFT_IN_INVENTORY";

				public const string RelationshipLevelIsTooLow = "ACTION_REQUIREMENT_MESSAGE_RELATIONSHIP_LEVEL_IS_TOO_LOW";

				public const string NpcCannotPlayMoreMiniGamesToday = "ACTION_REQUIREMENT_MESSAGE_NPC_CANNOT_PLAY_MORE_MINIGAMES_TODAY";

				public const string DailyQuestUnavailableYet = "ACTION_REQUIREMENT_MESSAGE_DAILY_QUEST_UNAVAILABLE_YET";

				public const string CannotRideElevatorDuringHighTide = "ACTION_BLOCK_NAME_TIDE_UP";

				public const string NoTeleportationDestination = "ACTION_REQUIREMENT_MESSAGE_NO_TARGET_TELEPORTERS_AVAILABLE";

				public const string ClearWayToDecorativeBuilding = "ACTION_BLOCK_NAME_NO_SPACE_FOR_USING";
			}
		}
	}
}
