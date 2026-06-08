using System;
using System.Collections.Generic;
using Controllers;
using Huey.Core.Utilities;
using Kitchen.Formatters.Controllers;
using Kitchen.Formatters.Huey.Core.Utilities;
using Kitchen.Formatters.Kitchen;
using Kitchen.Formatters.Kitchen.Layouts;
using Kitchen.Formatters.Kitchen.Layouts.Features;
using Kitchen.Formatters.Kitchen.Modules;
using Kitchen.Formatters.Kitchen.NetworkSupport;
using Kitchen.Formatters.Kitchen.ShopBuilder;
using Kitchen.Formatters.KitchenData;
using Kitchen.Formatters.Platforms;
using Kitchen.Layouts;
using Kitchen.Layouts.Features;
using Kitchen.Modules;
using Kitchen.NetworkSupport;
using Kitchen.ShopBuilder;
using KitchenData;
using MessagePack.Formatters;
using Platforms;
using UnityEngine;

namespace Kitchen.Resolvers
{
	internal static class GeneratedResolverGetFormatterHelper
	{
		private static readonly Dictionary<Type, int> lookup;

		static GeneratedResolverGetFormatterHelper()
		{
			lookup = new Dictionary<Type, int>(264)
			{
				{
					typeof((Vector3, Vector3)),
					0
				},
				{
					typeof(Dictionary<LayoutPosition, Room>),
					1
				},
				{
					typeof(Dictionary<string, PlayerProfile>),
					2
				},
				{
					typeof(Dictionary<string, string>),
					3
				},
				{
					typeof(HashSet<int>),
					4
				},
				{
					typeof(List<(Vector3, Vector3)>),
					5
				},
				{
					typeof(List<FileSystemInMemory.VFSEntity>),
					6
				},
				{
					typeof(List<INetworkData>),
					7
				},
				{
					typeof(List<InfoManagerPeerDetail>),
					8
				},
				{
					typeof(List<InfoManagerPlayerDetail>),
					9
				},
				{
					typeof(List<InfoManagerResponseUpdate>),
					10
				},
				{
					typeof(List<ISaveObject>),
					11
				},
				{
					typeof(List<ItemCollectionView.ItemData>),
					12
				},
				{
					typeof(List<Feature>),
					13
				},
				{
					typeof(List<PlayerInputData>),
					14
				},
				{
					typeof(List<int>),
					15
				},
				{
					typeof(List<string>),
					16
				},
				{
					typeof(List<Vector3>),
					17
				},
				{
					typeof(Button),
					18
				},
				{
					typeof(ButtonState),
					19
				},
				{
					typeof(GameStateRequest),
					20
				},
				{
					typeof(CApplianceInfo.ApplianceInfoMode),
					21
				},
				{
					typeof(CConveyPushItems.ConveyState),
					22
				},
				{
					typeof(CCustomerState.State),
					23
				},
				{
					typeof(CommandType),
					24
				},
				{
					typeof(EventType),
					25
				},
				{
					typeof(FixedDishReason),
					26
				},
				{
					typeof(GenericChoiceDecision),
					27
				},
				{
					typeof(GenericChoiceType),
					28
				},
				{
					typeof(InputIndicatorMessage),
					29
				},
				{
					typeof(KickReason),
					30
				},
				{
					typeof(FeatureType),
					31
				},
				{
					typeof(RoomType),
					32
				},
				{
					typeof(LossReason),
					33
				},
				{
					typeof(MessageType),
					34
				},
				{
					typeof(InputPromptAnimation),
					35
				},
				{
					typeof(ConnectionType),
					36
				},
				{
					typeof(Orientation),
					37
				},
				{
					typeof(PlayerOutfit),
					38
				},
				{
					typeof(ProfileFlags),
					39
				},
				{
					typeof(SaveState),
					40
				},
				{
					typeof(SceneType),
					41
				},
				{
					typeof(ShopStapleType),
					42
				},
				{
					typeof(SLoadoutStatus.RequiredActions),
					43
				},
				{
					typeof(StartDayWarning),
					44
				},
				{
					typeof(UnlockRewardType),
					45
				},
				{
					typeof(ViewMode),
					46
				},
				{
					typeof(ViewType),
					47
				},
				{
					typeof(WarningLevel),
					48
				},
				{
					typeof(DisplayedPatienceFactor),
					49
				},
				{
					typeof(NewsItemType),
					50
				},
				{
					typeof(PatienceReason),
					51
				},
				{
					typeof(PlayerShoe),
					52
				},
				{
					typeof(PopupType),
					53
				},
				{
					typeof(SoundEvent),
					54
				},
				{
					typeof(TutorialMessage),
					55
				},
				{
					typeof(WeatherMode),
					56
				},
				{
					typeof(PlatformType),
					57
				},
				{
					typeof(ICommandData),
					58
				},
				{
					typeof(ICommandUpdate),
					59
				},
				{
					typeof(IManagedPopupData),
					60
				},
				{
					typeof(INetworkData),
					61
				},
				{
					typeof(IResponseData),
					62
				},
				{
					typeof(ISaveObject),
					63
				},
				{
					typeof(IViewData),
					64
				},
				{
					typeof(InputState),
					65
				},
				{
					typeof(InputUpdateEvent),
					66
				},
				{
					typeof(SerializableVector2),
					67
				},
				{
					typeof(SourceIdentifier),
					68
				},
				{
					typeof(FileSystemInMemory),
					69
				},
				{
					typeof(FileSystemInMemory.VFSEntity),
					70
				},
				{
					typeof(AchievementDistributionView.ViewData),
					71
				},
				{
					typeof(AchievementTrackView.ViewData),
					72
				},
				{
					typeof(ApplianceDecorationView.ViewData),
					73
				},
				{
					typeof(ApplianceDrinkView.ViewData),
					74
				},
				{
					typeof(ApplianceGhostView.ViewData),
					75
				},
				{
					typeof(ApplianceInfoView.ViewData),
					76
				},
				{
					typeof(ApplianceInteractionView.ViewData),
					77
				},
				{
					typeof(ApplianceInteractorView.ViewData),
					78
				},
				{
					typeof(ApplianceProcessView.ViewData),
					79
				},
				{
					typeof(ApplianceView.ViewData),
					80
				},
				{
					typeof(AttachmentView.ViewData),
					81
				},
				{
					typeof(AutoPartnerView.ViewData),
					82
				},
				{
					typeof(BinView.ViewData),
					83
				},
				{
					typeof(BlueprintDeskView.ViewData),
					84
				},
				{
					typeof(BlueprintStoreView.ViewData),
					85
				},
				{
					typeof(BlueprintView.ViewData),
					86
				},
				{
					typeof(CardPedestalView.ViewData),
					87
				},
				{
					typeof(CardScrapperView.ViewData),
					88
				},
				{
					typeof(CardSelectorView.ViewData),
					89
				},
				{
					typeof(CardsSubview.ViewData),
					90
				},
				{
					typeof(CExpChange),
					91
				},
				{
					typeof(CGenericChoicePopup),
					92
				},
				{
					typeof(ChairView.ViewData),
					93
				},
				{
					typeof(CInputData),
					94
				},
				{
					typeof(CLocationChoice),
					95
				},
				{
					typeof(CLocationPopupRequest),
					96
				},
				{
					typeof(CommandUpdate),
					97
				},
				{
					typeof(ContractBubbleView.ViewData),
					98
				},
				{
					typeof(ContractChoiceView.ViewData),
					99
				},
				{
					typeof(ControlCommand),
					100
				},
				{
					typeof(ConveyItemsView.ViewData),
					101
				},
				{
					typeof(CostumeChangeIndicator.ResponseData),
					102
				},
				{
					typeof(CostumeChangeIndicator.ViewData),
					103
				},
				{
					typeof(CPopupEndDayData),
					104
				},
				{
					typeof(CPopupFloat),
					105
				},
				{
					typeof(CPopupRecipe),
					106
				},
				{
					typeof(CPopupSpeedrunCompleted),
					107
				},
				{
					typeof(CrateView.ViewData),
					108
				},
				{
					typeof(CreateFranchiseTextView.ViewData),
					109
				},
				{
					typeof(CreateViewData),
					110
				},
				{
					typeof(CRichPresenceData),
					111
				},
				{
					typeof(CustomerIndicatorView.ViewData),
					112
				},
				{
					typeof(CustomerNameSubview.ViewData),
					113
				},
				{
					typeof(CustomerView.ViewData),
					114
				},
				{
					typeof(DayDisplayView.ViewData),
					115
				},
				{
					typeof(DestroyViewData),
					116
				},
				{
					typeof(DiscountDeskView.ViewData),
					117
				},
				{
					typeof(DishChoiceView.ViewData),
					118
				},
				{
					typeof(DishIndicatorView.ViewData),
					119
				},
				{
					typeof(DishSelectionIndicator.ResponseData),
					120
				},
				{
					typeof(DishSelectionIndicator.ViewData),
					121
				},
				{
					typeof(DrawPathableGhostView.ViewData),
					122
				},
				{
					typeof(DrinkData),
					123
				},
				{
					typeof(EndgamePopupView.ResponseData),
					124
				},
				{
					typeof(EndgamePopupView.ViewData),
					125
				},
				{
					typeof(EndOfDayPopupView.ResponseData),
					126
				},
				{
					typeof(EndOfDayPopupView.ViewData),
					127
				},
				{
					typeof(EndPracticeView.ResponseData),
					128
				},
				{
					typeof(EndPracticeView.ViewData),
					129
				},
				{
					typeof(EntityUpdate),
					130
				},
				{
					typeof(EventIndicatorView.ViewData),
					131
				},
				{
					typeof(ExpTrackView.ViewData),
					132
				},
				{
					typeof(FixedDishView.ViewData),
					133
				},
				{
					typeof(FranchiseCardSetBubbleView.ViewData),
					134
				},
				{
					typeof(FranchiseCardSetView.ViewData),
					135
				},
				{
					typeof(FranchiseKitchenRecipeView.ViewData),
					136
				},
				{
					typeof(GameInfoTransferView.ViewData),
					137
				},
				{
					typeof(GenericChoiceView.ResponseData),
					138
				},
				{
					typeof(GenericChoiceView.ViewData),
					139
				},
				{
					typeof(GenericPopupView.ResponseData),
					140
				},
				{
					typeof(GenericPopupView.ViewData),
					141
				},
				{
					typeof(GenericPromptIndicatorView.ViewData),
					142
				},
				{
					typeof(GhostChairView.ViewData),
					143
				},
				{
					typeof(GrantExpView.ViewData),
					144
				},
				{
					typeof(GroupSelectorView.ViewData),
					145
				},
				{
					typeof(HeldApplianceView.ViewData),
					146
				},
				{
					typeof(IllusionWallView.ViewData),
					147
				},
				{
					typeof(INetworkDataList),
					148
				},
				{
					typeof(InfoManagerPeerDetail),
					149
				},
				{
					typeof(InfoManagerPlayerDetail),
					150
				},
				{
					typeof(InfoManagerResponseData),
					151
				},
				{
					typeof(InfoManagerResponseUpdate),
					152
				},
				{
					typeof(InfoManagerViewData),
					153
				},
				{
					typeof(InstantProcessToolView.ViewData),
					154
				},
				{
					typeof(ItemCollectionView.ItemData),
					155
				},
				{
					typeof(ItemCollectionView.ViewData),
					156
				},
				{
					typeof(ItemDrinksView.ViewData),
					157
				},
				{
					typeof(ItemHolderView.ItemHolderData),
					158
				},
				{
					typeof(ItemSourceView.ViewData),
					159
				},
				{
					typeof(ItemStorageView.ViewData),
					160
				},
				{
					typeof(ItemVariableStorageView.ItemData),
					161
				},
				{
					typeof(ItemVariableStorageView.ViewData),
					162
				},
				{
					typeof(ItemView.ViewData),
					163
				},
				{
					typeof(KickUserData),
					164
				},
				{
					typeof(LayoutChoiceView.ViewData),
					165
				},
				{
					typeof(LayoutDecorMap),
					166
				},
				{
					typeof(LayoutDecorView.DecorationUpdates),
					167
				},
				{
					typeof(Feature),
					168
				},
				{
					typeof(LayoutBlueprint),
					169
				},
				{
					typeof(LayoutPosition),
					170
				},
				{
					typeof(Room),
					171
				},
				{
					typeof(SerialisedLayoutBlueprint),
					172
				},
				{
					typeof(LayoutView.InitialViewData),
					173
				},
				{
					typeof(LimitedItemSourceLightsView.ViewData),
					174
				},
				{
					typeof(LimitedItemSourceView.ViewData),
					175
				},
				{
					typeof(LoadLocationView.ViewData),
					176
				},
				{
					typeof(LoadoutPedestalView.ViewData),
					177
				},
				{
					typeof(MaintainInViewData),
					178
				},
				{
					typeof(MoneyDisplayView.ViewData),
					179
				},
				{
					typeof(MoneyPopupView.ViewData),
					180
				},
				{
					typeof(NameplateView.ResponseData),
					181
				},
				{
					typeof(NameplateView.ViewData),
					182
				},
				{
					typeof(NewsItemView.ViewData),
					183
				},
				{
					typeof(NewsUIView.ResponseData),
					184
				},
				{
					typeof(NewsUIView.ViewData),
					185
				},
				{
					typeof(OpenFrontDoorView.ViewData),
					186
				},
				{
					typeof(OutfitSelectorView.ViewData),
					187
				},
				{
					typeof(PackSave),
					188
				},
				{
					typeof(PackSaveCardSets.V1),
					189
				},
				{
					typeof(PackSaveCardSets.V2),
					190
				},
				{
					typeof(PackSaveCardSets.V4),
					191
				},
				{
					typeof(PackSaveExpGrants.V1),
					192
				},
				{
					typeof(PackSaveLevel.V1),
					193
				},
				{
					typeof(PackSaveSpeedrun.V1),
					194
				},
				{
					typeof(PackSaveUpgrades.V1),
					195
				},
				{
					typeof(PackSaveUpgrades.V2),
					196
				},
				{
					typeof(ParametersDisplayView.ViewData),
					197
				},
				{
					typeof(PlayerColourView.ViewData),
					198
				},
				{
					typeof(PlayerCosmeticSubview.ViewData),
					199
				},
				{
					typeof(PlayerHoldingSubview.ViewData),
					200
				},
				{
					typeof(PlayerInfo),
					201
				},
				{
					typeof(PlayerInputData),
					202
				},
				{
					typeof(PlayerPingView.ViewData),
					203
				},
				{
					typeof(PlayerProfile),
					204
				},
				{
					typeof(PlayerShoeSubview.ViewData),
					205
				},
				{
					typeof(PlayerView.ResponseData),
					206
				},
				{
					typeof(PlayerView.ViewData),
					207
				},
				{
					typeof(ProfileEditorView.ResponseData),
					208
				},
				{
					typeof(ProfileEditorView.ViewData),
					209
				},
				{
					typeof(ProfileIdentifier),
					210
				},
				{
					typeof(ProfileSave),
					211
				},
				{
					typeof(ProgressView.ViewData),
					212
				},
				{
					typeof(RemoveLayoutDoorsView.ViewData),
					213
				},
				{
					typeof(RerollBlueprintView.ViewData),
					214
				},
				{
					typeof(ResponseUpdateCommand),
					215
				},
				{
					typeof(RestartDayPopup.SPopup),
					216
				},
				{
					typeof(SaveCardSets.V1),
					217
				},
				{
					typeof(SaveLevel.V1),
					218
				},
				{
					typeof(SaveResearch.V1),
					219
				},
				{
					typeof(SaveUpgrades.V1),
					220
				},
				{
					typeof(SaveUpgrades.V2),
					221
				},
				{
					typeof(SeededRunIndicatorView.ResponseData),
					222
				},
				{
					typeof(SeededRunIndicatorView.ViewData),
					223
				},
				{
					typeof(SeedInfoView.ViewData),
					224
				},
				{
					typeof(SerializableColor),
					225
				},
				{
					typeof(SerializableQuaternion),
					226
				},
				{
					typeof(SerializableVector3),
					227
				},
				{
					typeof(SetShoesView.ViewData),
					228
				},
				{
					typeof(SettingSelectorView.ViewData),
					229
				},
				{
					typeof(SiteView.ViewData),
					230
				},
				{
					typeof(SoundEventView.ViewData),
					231
				},
				{
					typeof(SpeedrunBoardView.ViewData),
					232
				},
				{
					typeof(SpeedrunScore),
					233
				},
				{
					typeof(SPlayerLevel),
					234
				},
				{
					typeof(SplittableItemView.ViewData),
					235
				},
				{
					typeof(StarIncreaseView.ResponseData),
					236
				},
				{
					typeof(StarIncreaseView.ViewData),
					237
				},
				{
					typeof(StartDayWarningView.ResponseData),
					238
				},
				{
					typeof(StartDayWarningView.ViewData),
					239
				},
				{
					typeof(StartGameTextView.ViewData),
					240
				},
				{
					typeof(StartPracticePopup.CRequest),
					241
				},
				{
					typeof(SteamRichPresenceView.ViewData),
					242
				},
				{
					typeof(TableIndicatorView.ViewData),
					243
				},
				{
					typeof(TeleportItemsView.ViewData),
					244
				},
				{
					typeof(TimeDisplayView.ViewData),
					245
				},
				{
					typeof(TransitionPopupView.ResponseData),
					246
				},
				{
					typeof(TransitionPopupView.ViewData),
					247
				},
				{
					typeof(TutorialBubbleView.ViewData),
					248
				},
				{
					typeof(TwitchOptionsView.ViewData),
					249
				},
				{
					typeof(UnlockSelectPopupView.ResponseData),
					250
				},
				{
					typeof(UnlockSelectPopupView.ViewData),
					251
				},
				{
					typeof(UpdateViewPositionData),
					252
				},
				{
					typeof(UpgradesTrackView.ViewData),
					253
				},
				{
					typeof(UserInputUpdate),
					254
				},
				{
					typeof(UserJoinData),
					255
				},
				{
					typeof(VariableProviderView.ViewData),
					256
				},
				{
					typeof(ViewIdentifier),
					257
				},
				{
					typeof(WeatherView.ViewData),
					258
				},
				{
					typeof(WorkshopActivatorView.ViewData),
					259
				},
				{
					typeof(WorkshopMachineView.ViewData),
					260
				},
				{
					typeof(WorkshopOutputView.ViewData),
					261
				},
				{
					typeof(DecorationValues),
					262
				},
				{
					typeof(PlatformUser),
					263
				}
			};
		}

		internal static object GetFormatter(Type t)
		{
			if (!lookup.TryGetValue(t, out var value))
			{
				return null;
			}
			return value switch
			{
				0 => new ValueTupleFormatter<Vector3, Vector3>(), 
				1 => new DictionaryFormatter<LayoutPosition, Room>(), 
				2 => new DictionaryFormatter<string, PlayerProfile>(), 
				3 => new DictionaryFormatter<string, string>(), 
				4 => new HashSetFormatter<int>(), 
				5 => new ListFormatter<(Vector3, Vector3)>(), 
				6 => new ListFormatter<FileSystemInMemory.VFSEntity>(), 
				7 => new ListFormatter<INetworkData>(), 
				8 => new ListFormatter<InfoManagerPeerDetail>(), 
				9 => new ListFormatter<InfoManagerPlayerDetail>(), 
				10 => new ListFormatter<InfoManagerResponseUpdate>(), 
				11 => new ListFormatter<ISaveObject>(), 
				12 => new ListFormatter<ItemCollectionView.ItemData>(), 
				13 => new ListFormatter<Feature>(), 
				14 => new ListFormatter<PlayerInputData>(), 
				15 => new ListFormatter<int>(), 
				16 => new ListFormatter<string>(), 
				17 => new ListFormatter<Vector3>(), 
				18 => new ButtonFormatter(), 
				19 => new ButtonStateFormatter(), 
				20 => new GameStateRequestFormatter(), 
				21 => new CApplianceInfo_ApplianceInfoModeFormatter(), 
				22 => new CConveyPushItems_ConveyStateFormatter(), 
				23 => new CCustomerState_StateFormatter(), 
				24 => new CommandTypeFormatter(), 
				25 => new EventTypeFormatter(), 
				26 => new FixedDishReasonFormatter(), 
				27 => new GenericChoiceDecisionFormatter(), 
				28 => new GenericChoiceTypeFormatter(), 
				29 => new InputIndicatorMessageFormatter(), 
				30 => new KickReasonFormatter(), 
				31 => new FeatureTypeFormatter(), 
				32 => new RoomTypeFormatter(), 
				33 => new LossReasonFormatter(), 
				34 => new MessageTypeFormatter(), 
				35 => new InputPromptAnimationFormatter(), 
				36 => new ConnectionTypeFormatter(), 
				37 => new OrientationFormatter(), 
				38 => new PlayerOutfitFormatter(), 
				39 => new ProfileFlagsFormatter(), 
				40 => new SaveStateFormatter(), 
				41 => new SceneTypeFormatter(), 
				42 => new ShopStapleTypeFormatter(), 
				43 => new SLoadoutStatus_RequiredActionsFormatter(), 
				44 => new StartDayWarningFormatter(), 
				45 => new UnlockRewardTypeFormatter(), 
				46 => new ViewModeFormatter(), 
				47 => new ViewTypeFormatter(), 
				48 => new WarningLevelFormatter(), 
				49 => new DisplayedPatienceFactorFormatter(), 
				50 => new NewsItemTypeFormatter(), 
				51 => new PatienceReasonFormatter(), 
				52 => new PlayerShoeFormatter(), 
				53 => new PopupTypeFormatter(), 
				54 => new SoundEventFormatter(), 
				55 => new TutorialMessageFormatter(), 
				56 => new WeatherModeFormatter(), 
				57 => new PlatformTypeFormatter(), 
				58 => new ICommandDataFormatter(), 
				59 => new ICommandUpdateFormatter(), 
				60 => new IManagedPopupDataFormatter(), 
				61 => new INetworkDataFormatter(), 
				62 => new IResponseDataFormatter(), 
				63 => new ISaveObjectFormatter(), 
				64 => new IViewDataFormatter(), 
				65 => new InputStateFormatter(), 
				66 => new InputUpdateEventFormatter(), 
				67 => new SerializableVector2Formatter(), 
				68 => new SourceIdentifierFormatter(), 
				69 => new FileSystemInMemoryFormatter(), 
				70 => new FileSystemInMemory_VFSEntityFormatter(), 
				71 => new AchievementDistributionView_ViewDataFormatter(), 
				72 => new AchievementTrackView_ViewDataFormatter(), 
				73 => new ApplianceDecorationView_ViewDataFormatter(), 
				74 => new ApplianceDrinkView_ViewDataFormatter(), 
				75 => new ApplianceGhostView_ViewDataFormatter(), 
				76 => new ApplianceInfoView_ViewDataFormatter(), 
				77 => new ApplianceInteractionView_ViewDataFormatter(), 
				78 => new ApplianceInteractorView_ViewDataFormatter(), 
				79 => new ApplianceProcessView_ViewDataFormatter(), 
				80 => new ApplianceView_ViewDataFormatter(), 
				81 => new AttachmentView_ViewDataFormatter(), 
				82 => new AutoPartnerView_ViewDataFormatter(), 
				83 => new BinView_ViewDataFormatter(), 
				84 => new BlueprintDeskView_ViewDataFormatter(), 
				85 => new BlueprintStoreView_ViewDataFormatter(), 
				86 => new BlueprintView_ViewDataFormatter(), 
				87 => new CardPedestalView_ViewDataFormatter(), 
				88 => new CardScrapperView_ViewDataFormatter(), 
				89 => new CardSelectorView_ViewDataFormatter(), 
				90 => new CardsSubview_ViewDataFormatter(), 
				91 => new CExpChangeFormatter(), 
				92 => new CGenericChoicePopupFormatter(), 
				93 => new ChairView_ViewDataFormatter(), 
				94 => new CInputDataFormatter(), 
				95 => new CLocationChoiceFormatter(), 
				96 => new CLocationPopupRequestFormatter(), 
				97 => new CommandUpdateFormatter(), 
				98 => new ContractBubbleView_ViewDataFormatter(), 
				99 => new ContractChoiceView_ViewDataFormatter(), 
				100 => new ControlCommandFormatter(), 
				101 => new ConveyItemsView_ViewDataFormatter(), 
				102 => new CostumeChangeIndicator_ResponseDataFormatter(), 
				103 => new CostumeChangeIndicator_ViewDataFormatter(), 
				104 => new CPopupEndDayDataFormatter(), 
				105 => new CPopupFloatFormatter(), 
				106 => new CPopupRecipeFormatter(), 
				107 => new CPopupSpeedrunCompletedFormatter(), 
				108 => new CrateView_ViewDataFormatter(), 
				109 => new CreateFranchiseTextView_ViewDataFormatter(), 
				110 => new CreateViewDataFormatter(), 
				111 => new CRichPresenceDataFormatter(), 
				112 => new CustomerIndicatorView_ViewDataFormatter(), 
				113 => new CustomerNameSubview_ViewDataFormatter(), 
				114 => new CustomerView_ViewDataFormatter(), 
				115 => new DayDisplayView_ViewDataFormatter(), 
				116 => new DestroyViewDataFormatter(), 
				117 => new DiscountDeskView_ViewDataFormatter(), 
				118 => new DishChoiceView_ViewDataFormatter(), 
				119 => new DishIndicatorView_ViewDataFormatter(), 
				120 => new DishSelectionIndicator_ResponseDataFormatter(), 
				121 => new DishSelectionIndicator_ViewDataFormatter(), 
				122 => new DrawPathableGhostView_ViewDataFormatter(), 
				123 => new DrinkDataFormatter(), 
				124 => new EndgamePopupView_ResponseDataFormatter(), 
				125 => new EndgamePopupView_ViewDataFormatter(), 
				126 => new EndOfDayPopupView_ResponseDataFormatter(), 
				127 => new EndOfDayPopupView_ViewDataFormatter(), 
				128 => new EndPracticeView_ResponseDataFormatter(), 
				129 => new EndPracticeView_ViewDataFormatter(), 
				130 => new EntityUpdateFormatter(), 
				131 => new EventIndicatorView_ViewDataFormatter(), 
				132 => new ExpTrackView_ViewDataFormatter(), 
				133 => new FixedDishView_ViewDataFormatter(), 
				134 => new FranchiseCardSetBubbleView_ViewDataFormatter(), 
				135 => new FranchiseCardSetView_ViewDataFormatter(), 
				136 => new FranchiseKitchenRecipeView_ViewDataFormatter(), 
				137 => new GameInfoTransferView_ViewDataFormatter(), 
				138 => new GenericChoiceView_ResponseDataFormatter(), 
				139 => new GenericChoiceView_ViewDataFormatter(), 
				140 => new GenericPopupView_ResponseDataFormatter(), 
				141 => new GenericPopupView_ViewDataFormatter(), 
				142 => new GenericPromptIndicatorView_ViewDataFormatter(), 
				143 => new GhostChairView_ViewDataFormatter(), 
				144 => new GrantExpView_ViewDataFormatter(), 
				145 => new GroupSelectorView_ViewDataFormatter(), 
				146 => new HeldApplianceView_ViewDataFormatter(), 
				147 => new IllusionWallView_ViewDataFormatter(), 
				148 => new INetworkDataListFormatter(), 
				149 => new InfoManagerPeerDetailFormatter(), 
				150 => new InfoManagerPlayerDetailFormatter(), 
				151 => new InfoManagerResponseDataFormatter(), 
				152 => new InfoManagerResponseUpdateFormatter(), 
				153 => new InfoManagerViewDataFormatter(), 
				154 => new InstantProcessToolView_ViewDataFormatter(), 
				155 => new ItemCollectionView_ItemDataFormatter(), 
				156 => new ItemCollectionView_ViewDataFormatter(), 
				157 => new ItemDrinksView_ViewDataFormatter(), 
				158 => new ItemHolderView_ItemHolderDataFormatter(), 
				159 => new ItemSourceView_ViewDataFormatter(), 
				160 => new ItemStorageView_ViewDataFormatter(), 
				161 => new ItemVariableStorageView_ItemDataFormatter(), 
				162 => new ItemVariableStorageView_ViewDataFormatter(), 
				163 => new ItemView_ViewDataFormatter(), 
				164 => new KickUserDataFormatter(), 
				165 => new LayoutChoiceView_ViewDataFormatter(), 
				166 => new LayoutDecorMapFormatter(), 
				167 => new LayoutDecorView_DecorationUpdatesFormatter(), 
				168 => new FeatureFormatter(), 
				169 => new LayoutBlueprintFormatter(), 
				170 => new LayoutPositionFormatter(), 
				171 => new RoomFormatter(), 
				172 => new SerialisedLayoutBlueprintFormatter(), 
				173 => new LayoutView_InitialViewDataFormatter(), 
				174 => new LimitedItemSourceLightsView_ViewDataFormatter(), 
				175 => new LimitedItemSourceView_ViewDataFormatter(), 
				176 => new LoadLocationView_ViewDataFormatter(), 
				177 => new LoadoutPedestalView_ViewDataFormatter(), 
				178 => new MaintainInViewDataFormatter(), 
				179 => new MoneyDisplayView_ViewDataFormatter(), 
				180 => new MoneyPopupView_ViewDataFormatter(), 
				181 => new NameplateView_ResponseDataFormatter(), 
				182 => new NameplateView_ViewDataFormatter(), 
				183 => new NewsItemView_ViewDataFormatter(), 
				184 => new NewsUIView_ResponseDataFormatter(), 
				185 => new NewsUIView_ViewDataFormatter(), 
				186 => new OpenFrontDoorView_ViewDataFormatter(), 
				187 => new OutfitSelectorView_ViewDataFormatter(), 
				188 => new PackSaveFormatter(), 
				189 => new PackSaveCardSets_V1Formatter(), 
				190 => new PackSaveCardSets_V2Formatter(), 
				191 => new PackSaveCardSets_V4Formatter(), 
				192 => new PackSaveExpGrants_V1Formatter(), 
				193 => new PackSaveLevel_V1Formatter(), 
				194 => new PackSaveSpeedrun_V1Formatter(), 
				195 => new PackSaveUpgrades_V1Formatter(), 
				196 => new PackSaveUpgrades_V2Formatter(), 
				197 => new ParametersDisplayView_ViewDataFormatter(), 
				198 => new PlayerColourView_ViewDataFormatter(), 
				199 => new PlayerCosmeticSubview_ViewDataFormatter(), 
				200 => new PlayerHoldingSubview_ViewDataFormatter(), 
				201 => new PlayerInfoFormatter(), 
				202 => new PlayerInputDataFormatter(), 
				203 => new PlayerPingView_ViewDataFormatter(), 
				204 => new PlayerProfileFormatter(), 
				205 => new PlayerShoeSubview_ViewDataFormatter(), 
				206 => new PlayerView_ResponseDataFormatter(), 
				207 => new PlayerView_ViewDataFormatter(), 
				208 => new ProfileEditorView_ResponseDataFormatter(), 
				209 => new ProfileEditorView_ViewDataFormatter(), 
				210 => new ProfileIdentifierFormatter(), 
				211 => new ProfileSaveFormatter(), 
				212 => new ProgressView_ViewDataFormatter(), 
				213 => new RemoveLayoutDoorsView_ViewDataFormatter(), 
				214 => new RerollBlueprintView_ViewDataFormatter(), 
				215 => new ResponseUpdateCommandFormatter(), 
				216 => new RestartDayPopup_SPopupFormatter(), 
				217 => new SaveCardSets_V1Formatter(), 
				218 => new SaveLevel_V1Formatter(), 
				219 => new SaveResearch_V1Formatter(), 
				220 => new SaveUpgrades_V1Formatter(), 
				221 => new SaveUpgrades_V2Formatter(), 
				222 => new SeededRunIndicatorView_ResponseDataFormatter(), 
				223 => new SeededRunIndicatorView_ViewDataFormatter(), 
				224 => new SeedInfoView_ViewDataFormatter(), 
				225 => new SerializableColorFormatter(), 
				226 => new SerializableQuaternionFormatter(), 
				227 => new SerializableVector3Formatter(), 
				228 => new SetShoesView_ViewDataFormatter(), 
				229 => new SettingSelectorView_ViewDataFormatter(), 
				230 => new SiteView_ViewDataFormatter(), 
				231 => new SoundEventView_ViewDataFormatter(), 
				232 => new SpeedrunBoardView_ViewDataFormatter(), 
				233 => new SpeedrunScoreFormatter(), 
				234 => new SPlayerLevelFormatter(), 
				235 => new SplittableItemView_ViewDataFormatter(), 
				236 => new StarIncreaseView_ResponseDataFormatter(), 
				237 => new StarIncreaseView_ViewDataFormatter(), 
				238 => new StartDayWarningView_ResponseDataFormatter(), 
				239 => new StartDayWarningView_ViewDataFormatter(), 
				240 => new StartGameTextView_ViewDataFormatter(), 
				241 => new StartPracticePopup_CRequestFormatter(), 
				242 => new SteamRichPresenceView_ViewDataFormatter(), 
				243 => new TableIndicatorView_ViewDataFormatter(), 
				244 => new TeleportItemsView_ViewDataFormatter(), 
				245 => new TimeDisplayView_ViewDataFormatter(), 
				246 => new TransitionPopupView_ResponseDataFormatter(), 
				247 => new TransitionPopupView_ViewDataFormatter(), 
				248 => new TutorialBubbleView_ViewDataFormatter(), 
				249 => new TwitchOptionsView_ViewDataFormatter(), 
				250 => new UnlockSelectPopupView_ResponseDataFormatter(), 
				251 => new UnlockSelectPopupView_ViewDataFormatter(), 
				252 => new UpdateViewPositionDataFormatter(), 
				253 => new UpgradesTrackView_ViewDataFormatter(), 
				254 => new UserInputUpdateFormatter(), 
				255 => new UserJoinDataFormatter(), 
				256 => new VariableProviderView_ViewDataFormatter(), 
				257 => new ViewIdentifierFormatter(), 
				258 => new WeatherView_ViewDataFormatter(), 
				259 => new WorkshopActivatorView_ViewDataFormatter(), 
				260 => new WorkshopMachineView_ViewDataFormatter(), 
				261 => new WorkshopOutputView_ViewDataFormatter(), 
				262 => new DecorationValuesFormatter(), 
				263 => new PlatformUserFormatter(), 
				_ => null, 
			};
		}
	}
}
