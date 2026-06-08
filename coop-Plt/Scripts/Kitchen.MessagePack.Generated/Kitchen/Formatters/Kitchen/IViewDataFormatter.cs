using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class IViewDataFormatter : IMessagePackFormatter<IViewData>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public IViewDataFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(118, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(ConveyItemsView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-2093930176, 0)
				},
				{
					typeof(DiscountDeskView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-2080829720, 1)
				},
				{
					typeof(CustomerNameSubview.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-2012971365, 2)
				},
				{
					typeof(LimitedItemSourceLightsView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1981947763, 3)
				},
				{
					typeof(ISpecificViewData).TypeHandle,
					new KeyValuePair<int, int>(-1975000206, 4)
				},
				{
					typeof(ItemHolderView.ItemHolderData).TypeHandle,
					new KeyValuePair<int, int>(-1970633620, 5)
				},
				{
					typeof(CardSelectorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1953478622, 6)
				},
				{
					typeof(EventIndicatorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1945591696, 7)
				},
				{
					typeof(TeleportItemsView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1910957418, 8)
				},
				{
					typeof(DestroyViewData).TypeHandle,
					new KeyValuePair<int, int>(-1907074164, 9)
				},
				{
					typeof(MoneyDisplayView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1899607249, 10)
				},
				{
					typeof(InfoManagerViewData).TypeHandle,
					new KeyValuePair<int, int>(-1828042203, 11)
				},
				{
					typeof(ApplianceDecorationView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1816102547, 12)
				},
				{
					typeof(ApplianceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1729164495, 13)
				},
				{
					typeof(ApplianceInfoView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1714441944, 14)
				},
				{
					typeof(CreateFranchiseTextView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1613354926, 15)
				},
				{
					typeof(WorkshopOutputView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1588260273, 16)
				},
				{
					typeof(CardScrapperView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1541724795, 17)
				},
				{
					typeof(SetShoesView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1535044939, 18)
				},
				{
					typeof(AttachmentView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1463046076, 19)
				},
				{
					typeof(SteamRichPresenceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1436683401, 20)
				},
				{
					typeof(SettingSelectorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1419038112, 21)
				},
				{
					typeof(BlueprintView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1307597435, 22)
				},
				{
					typeof(TimeDisplayView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1290631317, 23)
				},
				{
					typeof(MoneyPopupView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1237947197, 24)
				},
				{
					typeof(ItemSourceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1230056088, 25)
				},
				{
					typeof(CreateViewData).TypeHandle,
					new KeyValuePair<int, int>(-1161503201, 26)
				},
				{
					typeof(BlueprintDeskView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1136125524, 27)
				},
				{
					typeof(DishSelectionIndicator.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1121798410, 28)
				},
				{
					typeof(SiteView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1092042543, 29)
				},
				{
					typeof(LayoutView.InitialViewData).TypeHandle,
					new KeyValuePair<int, int>(-1057704504, 30)
				},
				{
					typeof(StartDayWarningView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1057084671, 31)
				},
				{
					typeof(SpeedrunBoardView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1040606918, 32)
				},
				{
					typeof(CrateView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-1002830236, 33)
				},
				{
					typeof(ChairView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-897512501, 34)
				},
				{
					typeof(SoundEventView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-844166378, 35)
				},
				{
					typeof(EndOfDayPopupView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-816935208, 36)
				},
				{
					typeof(PlayerShoeSubview.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-757255403, 37)
				},
				{
					typeof(ItemDrinksView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-750327590, 38)
				},
				{
					typeof(GameInfoTransferView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-739507061, 39)
				},
				{
					typeof(TableIndicatorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-710271221, 40)
				},
				{
					typeof(WeatherView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-701062797, 41)
				},
				{
					typeof(WorkshopMachineView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-656179093, 42)
				},
				{
					typeof(LoadoutPedestalView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-642502585, 43)
				},
				{
					typeof(FranchiseCardSetBubbleView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-627399234, 44)
				},
				{
					typeof(ItemStorageView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-554259660, 45)
				},
				{
					typeof(ApplianceDrinkView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-523100114, 46)
				},
				{
					typeof(IllusionWallView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-439077537, 47)
				},
				{
					typeof(MaintainInViewData).TypeHandle,
					new KeyValuePair<int, int>(-414177863, 48)
				},
				{
					typeof(ParametersDisplayView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-374628542, 49)
				},
				{
					typeof(PlayerHoldingSubview.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-367074599, 50)
				},
				{
					typeof(WorkshopActivatorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-326508138, 51)
				},
				{
					typeof(LayoutDecorView.DecorationUpdates).TypeHandle,
					new KeyValuePair<int, int>(-326156388, 52)
				},
				{
					typeof(NewsUIView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-294980599, 53)
				},
				{
					typeof(NameplateView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-239892731, 54)
				},
				{
					typeof(FranchiseKitchenRecipeView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(-39693602, 55)
				},
				{
					typeof(UpdateViewPositionData).TypeHandle,
					new KeyValuePair<int, int>(-9895294, 56)
				},
				{
					typeof(DishIndicatorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(137780103, 57)
				},
				{
					typeof(GenericChoiceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(145637224, 58)
				},
				{
					typeof(AutoPartnerView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(177187202, 59)
				},
				{
					typeof(GenericPopupView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(218938220, 60)
				},
				{
					typeof(DishChoiceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(236236349, 61)
				},
				{
					typeof(HeldApplianceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(249281382, 62)
				},
				{
					typeof(UpgradesTrackView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(253176873, 63)
				},
				{
					typeof(TransitionPopupView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(317250950, 64)
				},
				{
					typeof(BlueprintStoreView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(354005288, 65)
				},
				{
					typeof(LayoutChoiceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(365758950, 66)
				},
				{
					typeof(FranchiseCardSetView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(425145146, 67)
				},
				{
					typeof(ExpTrackView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(450227507, 68)
				},
				{
					typeof(RemoveLayoutDoorsView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(454895924, 69)
				},
				{
					typeof(EndgamePopupView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(508057793, 70)
				},
				{
					typeof(ApplianceInteractorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(522422840, 71)
				},
				{
					typeof(NewsItemView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(527228359, 72)
				},
				{
					typeof(GhostChairView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(615299660, 73)
				},
				{
					typeof(GenericPromptIndicatorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(650071014, 74)
				},
				{
					typeof(ProgressView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(664715329, 75)
				},
				{
					typeof(ApplianceProcessView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(737980106, 76)
				},
				{
					typeof(StartGameTextView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(756624327, 77)
				},
				{
					typeof(GrantExpView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(804867717, 78)
				},
				{
					typeof(ContractBubbleView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(861103182, 79)
				},
				{
					typeof(EndPracticeView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(886290766, 80)
				},
				{
					typeof(TutorialBubbleView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(936201831, 81)
				},
				{
					typeof(ItemView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(945462225, 82)
				},
				{
					typeof(OutfitSelectorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(963332295, 83)
				},
				{
					typeof(LoadLocationView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(974281438, 84)
				},
				{
					typeof(ApplianceInteractionView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1138322301, 85)
				},
				{
					typeof(DrawPathableGhostView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1161114074, 86)
				},
				{
					typeof(VariableProviderView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1191563036, 87)
				},
				{
					typeof(ApplianceGhostView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1210450643, 88)
				},
				{
					typeof(CardPedestalView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1224416030, 89)
				},
				{
					typeof(TwitchOptionsView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1319158885, 90)
				},
				{
					typeof(FixedDishView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1319934173, 91)
				},
				{
					typeof(BinView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1371434965, 92)
				},
				{
					typeof(SplittableItemView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1384018213, 93)
				},
				{
					typeof(UnlockSelectPopupView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1398537634, 94)
				},
				{
					typeof(ProfileEditorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1412075494, 95)
				},
				{
					typeof(InstantProcessToolView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1441285544, 96)
				},
				{
					typeof(LimitedItemSourceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1443884678, 97)
				},
				{
					typeof(ContractChoiceView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1528244500, 98)
				},
				{
					typeof(CostumeChangeIndicator.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1570731739, 99)
				},
				{
					typeof(DayDisplayView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1594611929, 100)
				},
				{
					typeof(GroupSelectorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1628460881, 101)
				},
				{
					typeof(ItemVariableStorageView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1660987201, 102)
				},
				{
					typeof(CardsSubview.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1694469305, 103)
				},
				{
					typeof(SeedInfoView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1699527801, 104)
				},
				{
					typeof(RerollBlueprintView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1742816861, 105)
				},
				{
					typeof(StarIncreaseView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1815165616, 106)
				},
				{
					typeof(OpenFrontDoorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1845914352, 107)
				},
				{
					typeof(AchievementTrackView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1863912396, 108)
				},
				{
					typeof(AchievementDistributionView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1882179944, 109)
				},
				{
					typeof(ItemCollectionView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1953696251, 110)
				},
				{
					typeof(PlayerPingView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1967614014, 111)
				},
				{
					typeof(PlayerColourView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(1973558834, 112)
				},
				{
					typeof(SeededRunIndicatorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(2017723735, 113)
				},
				{
					typeof(PlayerView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(2086117907, 114)
				},
				{
					typeof(CustomerView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(2094760762, 115)
				},
				{
					typeof(CustomerIndicatorView.ViewData).TypeHandle,
					new KeyValuePair<int, int>(2113946149, 116)
				},
				{
					typeof(PlayerCosmeticSubview.ViewData).TypeHandle,
					new KeyValuePair<int, int>(2126489073, 117)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(118)
			{
				{ -2093930176, 0 },
				{ -2080829720, 1 },
				{ -2012971365, 2 },
				{ -1981947763, 3 },
				{ -1975000206, 4 },
				{ -1970633620, 5 },
				{ -1953478622, 6 },
				{ -1945591696, 7 },
				{ -1910957418, 8 },
				{ -1907074164, 9 },
				{ -1899607249, 10 },
				{ -1828042203, 11 },
				{ -1816102547, 12 },
				{ -1729164495, 13 },
				{ -1714441944, 14 },
				{ -1613354926, 15 },
				{ -1588260273, 16 },
				{ -1541724795, 17 },
				{ -1535044939, 18 },
				{ -1463046076, 19 },
				{ -1436683401, 20 },
				{ -1419038112, 21 },
				{ -1307597435, 22 },
				{ -1290631317, 23 },
				{ -1237947197, 24 },
				{ -1230056088, 25 },
				{ -1161503201, 26 },
				{ -1136125524, 27 },
				{ -1121798410, 28 },
				{ -1092042543, 29 },
				{ -1057704504, 30 },
				{ -1057084671, 31 },
				{ -1040606918, 32 },
				{ -1002830236, 33 },
				{ -897512501, 34 },
				{ -844166378, 35 },
				{ -816935208, 36 },
				{ -757255403, 37 },
				{ -750327590, 38 },
				{ -739507061, 39 },
				{ -710271221, 40 },
				{ -701062797, 41 },
				{ -656179093, 42 },
				{ -642502585, 43 },
				{ -627399234, 44 },
				{ -554259660, 45 },
				{ -523100114, 46 },
				{ -439077537, 47 },
				{ -414177863, 48 },
				{ -374628542, 49 },
				{ -367074599, 50 },
				{ -326508138, 51 },
				{ -326156388, 52 },
				{ -294980599, 53 },
				{ -239892731, 54 },
				{ -39693602, 55 },
				{ -9895294, 56 },
				{ 137780103, 57 },
				{ 145637224, 58 },
				{ 177187202, 59 },
				{ 218938220, 60 },
				{ 236236349, 61 },
				{ 249281382, 62 },
				{ 253176873, 63 },
				{ 317250950, 64 },
				{ 354005288, 65 },
				{ 365758950, 66 },
				{ 425145146, 67 },
				{ 450227507, 68 },
				{ 454895924, 69 },
				{ 508057793, 70 },
				{ 522422840, 71 },
				{ 527228359, 72 },
				{ 615299660, 73 },
				{ 650071014, 74 },
				{ 664715329, 75 },
				{ 737980106, 76 },
				{ 756624327, 77 },
				{ 804867717, 78 },
				{ 861103182, 79 },
				{ 886290766, 80 },
				{ 936201831, 81 },
				{ 945462225, 82 },
				{ 963332295, 83 },
				{ 974281438, 84 },
				{ 1138322301, 85 },
				{ 1161114074, 86 },
				{ 1191563036, 87 },
				{ 1210450643, 88 },
				{ 1224416030, 89 },
				{ 1319158885, 90 },
				{ 1319934173, 91 },
				{ 1371434965, 92 },
				{ 1384018213, 93 },
				{ 1398537634, 94 },
				{ 1412075494, 95 },
				{ 1441285544, 96 },
				{ 1443884678, 97 },
				{ 1528244500, 98 },
				{ 1570731739, 99 },
				{ 1594611929, 100 },
				{ 1628460881, 101 },
				{ 1660987201, 102 },
				{ 1694469305, 103 },
				{ 1699527801, 104 },
				{ 1742816861, 105 },
				{ 1815165616, 106 },
				{ 1845914352, 107 },
				{ 1863912396, 108 },
				{ 1882179944, 109 },
				{ 1953696251, 110 },
				{ 1967614014, 111 },
				{ 1973558834, 112 },
				{ 2017723735, 113 },
				{ 2086117907, 114 },
				{ 2094760762, 115 },
				{ 2113946149, 116 },
				{ 2126489073, 117 }
			};
		}

		public void Serialize(ref MessagePackWriter writer, IViewData value, MessagePackSerializerOptions options)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				writer.WriteArrayHeader(2);
				writer.WriteInt32(value2.Key);
				switch (value2.Value)
				{
				case 0:
					options.Resolver.GetFormatterWithVerify<ConveyItemsView.ViewData>().Serialize(ref writer, (ConveyItemsView.ViewData)(object)value, options);
					break;
				case 1:
					options.Resolver.GetFormatterWithVerify<DiscountDeskView.ViewData>().Serialize(ref writer, (DiscountDeskView.ViewData)(object)value, options);
					break;
				case 2:
					options.Resolver.GetFormatterWithVerify<CustomerNameSubview.ViewData>().Serialize(ref writer, (CustomerNameSubview.ViewData)(object)value, options);
					break;
				case 3:
					options.Resolver.GetFormatterWithVerify<LimitedItemSourceLightsView.ViewData>().Serialize(ref writer, (LimitedItemSourceLightsView.ViewData)(object)value, options);
					break;
				case 4:
					options.Resolver.GetFormatterWithVerify<ISpecificViewData>().Serialize(ref writer, (ISpecificViewData)value, options);
					break;
				case 5:
					options.Resolver.GetFormatterWithVerify<ItemHolderView.ItemHolderData>().Serialize(ref writer, (ItemHolderView.ItemHolderData)(object)value, options);
					break;
				case 6:
					options.Resolver.GetFormatterWithVerify<CardSelectorView.ViewData>().Serialize(ref writer, (CardSelectorView.ViewData)(object)value, options);
					break;
				case 7:
					options.Resolver.GetFormatterWithVerify<EventIndicatorView.ViewData>().Serialize(ref writer, (EventIndicatorView.ViewData)(object)value, options);
					break;
				case 8:
					options.Resolver.GetFormatterWithVerify<TeleportItemsView.ViewData>().Serialize(ref writer, (TeleportItemsView.ViewData)(object)value, options);
					break;
				case 9:
					options.Resolver.GetFormatterWithVerify<DestroyViewData>().Serialize(ref writer, (DestroyViewData)(object)value, options);
					break;
				case 10:
					options.Resolver.GetFormatterWithVerify<MoneyDisplayView.ViewData>().Serialize(ref writer, (MoneyDisplayView.ViewData)(object)value, options);
					break;
				case 11:
					options.Resolver.GetFormatterWithVerify<InfoManagerViewData>().Serialize(ref writer, (InfoManagerViewData)(object)value, options);
					break;
				case 12:
					options.Resolver.GetFormatterWithVerify<ApplianceDecorationView.ViewData>().Serialize(ref writer, (ApplianceDecorationView.ViewData)(object)value, options);
					break;
				case 13:
					options.Resolver.GetFormatterWithVerify<ApplianceView.ViewData>().Serialize(ref writer, (ApplianceView.ViewData)(object)value, options);
					break;
				case 14:
					options.Resolver.GetFormatterWithVerify<ApplianceInfoView.ViewData>().Serialize(ref writer, (ApplianceInfoView.ViewData)(object)value, options);
					break;
				case 15:
					options.Resolver.GetFormatterWithVerify<CreateFranchiseTextView.ViewData>().Serialize(ref writer, (CreateFranchiseTextView.ViewData)(object)value, options);
					break;
				case 16:
					options.Resolver.GetFormatterWithVerify<WorkshopOutputView.ViewData>().Serialize(ref writer, (WorkshopOutputView.ViewData)(object)value, options);
					break;
				case 17:
					options.Resolver.GetFormatterWithVerify<CardScrapperView.ViewData>().Serialize(ref writer, (CardScrapperView.ViewData)(object)value, options);
					break;
				case 18:
					options.Resolver.GetFormatterWithVerify<SetShoesView.ViewData>().Serialize(ref writer, (SetShoesView.ViewData)(object)value, options);
					break;
				case 19:
					options.Resolver.GetFormatterWithVerify<AttachmentView.ViewData>().Serialize(ref writer, (AttachmentView.ViewData)(object)value, options);
					break;
				case 20:
					options.Resolver.GetFormatterWithVerify<SteamRichPresenceView.ViewData>().Serialize(ref writer, (SteamRichPresenceView.ViewData)(object)value, options);
					break;
				case 21:
					options.Resolver.GetFormatterWithVerify<SettingSelectorView.ViewData>().Serialize(ref writer, (SettingSelectorView.ViewData)(object)value, options);
					break;
				case 22:
					options.Resolver.GetFormatterWithVerify<BlueprintView.ViewData>().Serialize(ref writer, (BlueprintView.ViewData)(object)value, options);
					break;
				case 23:
					options.Resolver.GetFormatterWithVerify<TimeDisplayView.ViewData>().Serialize(ref writer, (TimeDisplayView.ViewData)(object)value, options);
					break;
				case 24:
					options.Resolver.GetFormatterWithVerify<MoneyPopupView.ViewData>().Serialize(ref writer, (MoneyPopupView.ViewData)(object)value, options);
					break;
				case 25:
					options.Resolver.GetFormatterWithVerify<ItemSourceView.ViewData>().Serialize(ref writer, (ItemSourceView.ViewData)(object)value, options);
					break;
				case 26:
					options.Resolver.GetFormatterWithVerify<CreateViewData>().Serialize(ref writer, (CreateViewData)(object)value, options);
					break;
				case 27:
					options.Resolver.GetFormatterWithVerify<BlueprintDeskView.ViewData>().Serialize(ref writer, (BlueprintDeskView.ViewData)(object)value, options);
					break;
				case 28:
					options.Resolver.GetFormatterWithVerify<DishSelectionIndicator.ViewData>().Serialize(ref writer, (DishSelectionIndicator.ViewData)(object)value, options);
					break;
				case 29:
					options.Resolver.GetFormatterWithVerify<SiteView.ViewData>().Serialize(ref writer, (SiteView.ViewData)(object)value, options);
					break;
				case 30:
					options.Resolver.GetFormatterWithVerify<LayoutView.InitialViewData>().Serialize(ref writer, (LayoutView.InitialViewData)(object)value, options);
					break;
				case 31:
					options.Resolver.GetFormatterWithVerify<StartDayWarningView.ViewData>().Serialize(ref writer, (StartDayWarningView.ViewData)(object)value, options);
					break;
				case 32:
					options.Resolver.GetFormatterWithVerify<SpeedrunBoardView.ViewData>().Serialize(ref writer, (SpeedrunBoardView.ViewData)(object)value, options);
					break;
				case 33:
					options.Resolver.GetFormatterWithVerify<CrateView.ViewData>().Serialize(ref writer, (CrateView.ViewData)(object)value, options);
					break;
				case 34:
					options.Resolver.GetFormatterWithVerify<ChairView.ViewData>().Serialize(ref writer, (ChairView.ViewData)(object)value, options);
					break;
				case 35:
					options.Resolver.GetFormatterWithVerify<SoundEventView.ViewData>().Serialize(ref writer, (SoundEventView.ViewData)(object)value, options);
					break;
				case 36:
					options.Resolver.GetFormatterWithVerify<EndOfDayPopupView.ViewData>().Serialize(ref writer, (EndOfDayPopupView.ViewData)(object)value, options);
					break;
				case 37:
					options.Resolver.GetFormatterWithVerify<PlayerShoeSubview.ViewData>().Serialize(ref writer, (PlayerShoeSubview.ViewData)(object)value, options);
					break;
				case 38:
					options.Resolver.GetFormatterWithVerify<ItemDrinksView.ViewData>().Serialize(ref writer, (ItemDrinksView.ViewData)(object)value, options);
					break;
				case 39:
					options.Resolver.GetFormatterWithVerify<GameInfoTransferView.ViewData>().Serialize(ref writer, (GameInfoTransferView.ViewData)(object)value, options);
					break;
				case 40:
					options.Resolver.GetFormatterWithVerify<TableIndicatorView.ViewData>().Serialize(ref writer, (TableIndicatorView.ViewData)(object)value, options);
					break;
				case 41:
					options.Resolver.GetFormatterWithVerify<WeatherView.ViewData>().Serialize(ref writer, (WeatherView.ViewData)(object)value, options);
					break;
				case 42:
					options.Resolver.GetFormatterWithVerify<WorkshopMachineView.ViewData>().Serialize(ref writer, (WorkshopMachineView.ViewData)(object)value, options);
					break;
				case 43:
					options.Resolver.GetFormatterWithVerify<LoadoutPedestalView.ViewData>().Serialize(ref writer, (LoadoutPedestalView.ViewData)(object)value, options);
					break;
				case 44:
					options.Resolver.GetFormatterWithVerify<FranchiseCardSetBubbleView.ViewData>().Serialize(ref writer, (FranchiseCardSetBubbleView.ViewData)(object)value, options);
					break;
				case 45:
					options.Resolver.GetFormatterWithVerify<ItemStorageView.ViewData>().Serialize(ref writer, (ItemStorageView.ViewData)(object)value, options);
					break;
				case 46:
					options.Resolver.GetFormatterWithVerify<ApplianceDrinkView.ViewData>().Serialize(ref writer, (ApplianceDrinkView.ViewData)(object)value, options);
					break;
				case 47:
					options.Resolver.GetFormatterWithVerify<IllusionWallView.ViewData>().Serialize(ref writer, (IllusionWallView.ViewData)(object)value, options);
					break;
				case 48:
					options.Resolver.GetFormatterWithVerify<MaintainInViewData>().Serialize(ref writer, (MaintainInViewData)(object)value, options);
					break;
				case 49:
					options.Resolver.GetFormatterWithVerify<ParametersDisplayView.ViewData>().Serialize(ref writer, (ParametersDisplayView.ViewData)(object)value, options);
					break;
				case 50:
					options.Resolver.GetFormatterWithVerify<PlayerHoldingSubview.ViewData>().Serialize(ref writer, (PlayerHoldingSubview.ViewData)(object)value, options);
					break;
				case 51:
					options.Resolver.GetFormatterWithVerify<WorkshopActivatorView.ViewData>().Serialize(ref writer, (WorkshopActivatorView.ViewData)(object)value, options);
					break;
				case 52:
					options.Resolver.GetFormatterWithVerify<LayoutDecorView.DecorationUpdates>().Serialize(ref writer, (LayoutDecorView.DecorationUpdates)(object)value, options);
					break;
				case 53:
					options.Resolver.GetFormatterWithVerify<NewsUIView.ViewData>().Serialize(ref writer, (NewsUIView.ViewData)(object)value, options);
					break;
				case 54:
					options.Resolver.GetFormatterWithVerify<NameplateView.ViewData>().Serialize(ref writer, (NameplateView.ViewData)(object)value, options);
					break;
				case 55:
					options.Resolver.GetFormatterWithVerify<FranchiseKitchenRecipeView.ViewData>().Serialize(ref writer, (FranchiseKitchenRecipeView.ViewData)(object)value, options);
					break;
				case 56:
					options.Resolver.GetFormatterWithVerify<UpdateViewPositionData>().Serialize(ref writer, (UpdateViewPositionData)(object)value, options);
					break;
				case 57:
					options.Resolver.GetFormatterWithVerify<DishIndicatorView.ViewData>().Serialize(ref writer, (DishIndicatorView.ViewData)(object)value, options);
					break;
				case 58:
					options.Resolver.GetFormatterWithVerify<GenericChoiceView.ViewData>().Serialize(ref writer, (GenericChoiceView.ViewData)(object)value, options);
					break;
				case 59:
					options.Resolver.GetFormatterWithVerify<AutoPartnerView.ViewData>().Serialize(ref writer, (AutoPartnerView.ViewData)(object)value, options);
					break;
				case 60:
					options.Resolver.GetFormatterWithVerify<GenericPopupView.ViewData>().Serialize(ref writer, (GenericPopupView.ViewData)(object)value, options);
					break;
				case 61:
					options.Resolver.GetFormatterWithVerify<DishChoiceView.ViewData>().Serialize(ref writer, (DishChoiceView.ViewData)(object)value, options);
					break;
				case 62:
					options.Resolver.GetFormatterWithVerify<HeldApplianceView.ViewData>().Serialize(ref writer, (HeldApplianceView.ViewData)(object)value, options);
					break;
				case 63:
					options.Resolver.GetFormatterWithVerify<UpgradesTrackView.ViewData>().Serialize(ref writer, (UpgradesTrackView.ViewData)(object)value, options);
					break;
				case 64:
					options.Resolver.GetFormatterWithVerify<TransitionPopupView.ViewData>().Serialize(ref writer, (TransitionPopupView.ViewData)(object)value, options);
					break;
				case 65:
					options.Resolver.GetFormatterWithVerify<BlueprintStoreView.ViewData>().Serialize(ref writer, (BlueprintStoreView.ViewData)(object)value, options);
					break;
				case 66:
					options.Resolver.GetFormatterWithVerify<LayoutChoiceView.ViewData>().Serialize(ref writer, (LayoutChoiceView.ViewData)(object)value, options);
					break;
				case 67:
					options.Resolver.GetFormatterWithVerify<FranchiseCardSetView.ViewData>().Serialize(ref writer, (FranchiseCardSetView.ViewData)(object)value, options);
					break;
				case 68:
					options.Resolver.GetFormatterWithVerify<ExpTrackView.ViewData>().Serialize(ref writer, (ExpTrackView.ViewData)(object)value, options);
					break;
				case 69:
					options.Resolver.GetFormatterWithVerify<RemoveLayoutDoorsView.ViewData>().Serialize(ref writer, (RemoveLayoutDoorsView.ViewData)(object)value, options);
					break;
				case 70:
					options.Resolver.GetFormatterWithVerify<EndgamePopupView.ViewData>().Serialize(ref writer, (EndgamePopupView.ViewData)(object)value, options);
					break;
				case 71:
					options.Resolver.GetFormatterWithVerify<ApplianceInteractorView.ViewData>().Serialize(ref writer, (ApplianceInteractorView.ViewData)(object)value, options);
					break;
				case 72:
					options.Resolver.GetFormatterWithVerify<NewsItemView.ViewData>().Serialize(ref writer, (NewsItemView.ViewData)(object)value, options);
					break;
				case 73:
					options.Resolver.GetFormatterWithVerify<GhostChairView.ViewData>().Serialize(ref writer, (GhostChairView.ViewData)(object)value, options);
					break;
				case 74:
					options.Resolver.GetFormatterWithVerify<GenericPromptIndicatorView.ViewData>().Serialize(ref writer, (GenericPromptIndicatorView.ViewData)(object)value, options);
					break;
				case 75:
					options.Resolver.GetFormatterWithVerify<ProgressView.ViewData>().Serialize(ref writer, (ProgressView.ViewData)(object)value, options);
					break;
				case 76:
					options.Resolver.GetFormatterWithVerify<ApplianceProcessView.ViewData>().Serialize(ref writer, (ApplianceProcessView.ViewData)(object)value, options);
					break;
				case 77:
					options.Resolver.GetFormatterWithVerify<StartGameTextView.ViewData>().Serialize(ref writer, (StartGameTextView.ViewData)(object)value, options);
					break;
				case 78:
					options.Resolver.GetFormatterWithVerify<GrantExpView.ViewData>().Serialize(ref writer, (GrantExpView.ViewData)(object)value, options);
					break;
				case 79:
					options.Resolver.GetFormatterWithVerify<ContractBubbleView.ViewData>().Serialize(ref writer, (ContractBubbleView.ViewData)(object)value, options);
					break;
				case 80:
					options.Resolver.GetFormatterWithVerify<EndPracticeView.ViewData>().Serialize(ref writer, (EndPracticeView.ViewData)(object)value, options);
					break;
				case 81:
					options.Resolver.GetFormatterWithVerify<TutorialBubbleView.ViewData>().Serialize(ref writer, (TutorialBubbleView.ViewData)(object)value, options);
					break;
				case 82:
					options.Resolver.GetFormatterWithVerify<ItemView.ViewData>().Serialize(ref writer, (ItemView.ViewData)(object)value, options);
					break;
				case 83:
					options.Resolver.GetFormatterWithVerify<OutfitSelectorView.ViewData>().Serialize(ref writer, (OutfitSelectorView.ViewData)(object)value, options);
					break;
				case 84:
					options.Resolver.GetFormatterWithVerify<LoadLocationView.ViewData>().Serialize(ref writer, (LoadLocationView.ViewData)(object)value, options);
					break;
				case 85:
					options.Resolver.GetFormatterWithVerify<ApplianceInteractionView.ViewData>().Serialize(ref writer, (ApplianceInteractionView.ViewData)(object)value, options);
					break;
				case 86:
					options.Resolver.GetFormatterWithVerify<DrawPathableGhostView.ViewData>().Serialize(ref writer, (DrawPathableGhostView.ViewData)(object)value, options);
					break;
				case 87:
					options.Resolver.GetFormatterWithVerify<VariableProviderView.ViewData>().Serialize(ref writer, (VariableProviderView.ViewData)(object)value, options);
					break;
				case 88:
					options.Resolver.GetFormatterWithVerify<ApplianceGhostView.ViewData>().Serialize(ref writer, (ApplianceGhostView.ViewData)(object)value, options);
					break;
				case 89:
					options.Resolver.GetFormatterWithVerify<CardPedestalView.ViewData>().Serialize(ref writer, (CardPedestalView.ViewData)(object)value, options);
					break;
				case 90:
					options.Resolver.GetFormatterWithVerify<TwitchOptionsView.ViewData>().Serialize(ref writer, (TwitchOptionsView.ViewData)(object)value, options);
					break;
				case 91:
					options.Resolver.GetFormatterWithVerify<FixedDishView.ViewData>().Serialize(ref writer, (FixedDishView.ViewData)(object)value, options);
					break;
				case 92:
					options.Resolver.GetFormatterWithVerify<BinView.ViewData>().Serialize(ref writer, (BinView.ViewData)(object)value, options);
					break;
				case 93:
					options.Resolver.GetFormatterWithVerify<SplittableItemView.ViewData>().Serialize(ref writer, (SplittableItemView.ViewData)(object)value, options);
					break;
				case 94:
					options.Resolver.GetFormatterWithVerify<UnlockSelectPopupView.ViewData>().Serialize(ref writer, (UnlockSelectPopupView.ViewData)(object)value, options);
					break;
				case 95:
					options.Resolver.GetFormatterWithVerify<ProfileEditorView.ViewData>().Serialize(ref writer, (ProfileEditorView.ViewData)(object)value, options);
					break;
				case 96:
					options.Resolver.GetFormatterWithVerify<InstantProcessToolView.ViewData>().Serialize(ref writer, (InstantProcessToolView.ViewData)(object)value, options);
					break;
				case 97:
					options.Resolver.GetFormatterWithVerify<LimitedItemSourceView.ViewData>().Serialize(ref writer, (LimitedItemSourceView.ViewData)(object)value, options);
					break;
				case 98:
					options.Resolver.GetFormatterWithVerify<ContractChoiceView.ViewData>().Serialize(ref writer, (ContractChoiceView.ViewData)(object)value, options);
					break;
				case 99:
					options.Resolver.GetFormatterWithVerify<CostumeChangeIndicator.ViewData>().Serialize(ref writer, (CostumeChangeIndicator.ViewData)(object)value, options);
					break;
				case 100:
					options.Resolver.GetFormatterWithVerify<DayDisplayView.ViewData>().Serialize(ref writer, (DayDisplayView.ViewData)(object)value, options);
					break;
				case 101:
					options.Resolver.GetFormatterWithVerify<GroupSelectorView.ViewData>().Serialize(ref writer, (GroupSelectorView.ViewData)(object)value, options);
					break;
				case 102:
					options.Resolver.GetFormatterWithVerify<ItemVariableStorageView.ViewData>().Serialize(ref writer, (ItemVariableStorageView.ViewData)(object)value, options);
					break;
				case 103:
					options.Resolver.GetFormatterWithVerify<CardsSubview.ViewData>().Serialize(ref writer, (CardsSubview.ViewData)(object)value, options);
					break;
				case 104:
					options.Resolver.GetFormatterWithVerify<SeedInfoView.ViewData>().Serialize(ref writer, (SeedInfoView.ViewData)(object)value, options);
					break;
				case 105:
					options.Resolver.GetFormatterWithVerify<RerollBlueprintView.ViewData>().Serialize(ref writer, (RerollBlueprintView.ViewData)(object)value, options);
					break;
				case 106:
					options.Resolver.GetFormatterWithVerify<StarIncreaseView.ViewData>().Serialize(ref writer, (StarIncreaseView.ViewData)(object)value, options);
					break;
				case 107:
					options.Resolver.GetFormatterWithVerify<OpenFrontDoorView.ViewData>().Serialize(ref writer, (OpenFrontDoorView.ViewData)(object)value, options);
					break;
				case 108:
					options.Resolver.GetFormatterWithVerify<AchievementTrackView.ViewData>().Serialize(ref writer, (AchievementTrackView.ViewData)(object)value, options);
					break;
				case 109:
					options.Resolver.GetFormatterWithVerify<AchievementDistributionView.ViewData>().Serialize(ref writer, (AchievementDistributionView.ViewData)(object)value, options);
					break;
				case 110:
					options.Resolver.GetFormatterWithVerify<ItemCollectionView.ViewData>().Serialize(ref writer, (ItemCollectionView.ViewData)(object)value, options);
					break;
				case 111:
					options.Resolver.GetFormatterWithVerify<PlayerPingView.ViewData>().Serialize(ref writer, (PlayerPingView.ViewData)(object)value, options);
					break;
				case 112:
					options.Resolver.GetFormatterWithVerify<PlayerColourView.ViewData>().Serialize(ref writer, (PlayerColourView.ViewData)(object)value, options);
					break;
				case 113:
					options.Resolver.GetFormatterWithVerify<SeededRunIndicatorView.ViewData>().Serialize(ref writer, (SeededRunIndicatorView.ViewData)(object)value, options);
					break;
				case 114:
					options.Resolver.GetFormatterWithVerify<PlayerView.ViewData>().Serialize(ref writer, (PlayerView.ViewData)(object)value, options);
					break;
				case 115:
					options.Resolver.GetFormatterWithVerify<CustomerView.ViewData>().Serialize(ref writer, (CustomerView.ViewData)(object)value, options);
					break;
				case 116:
					options.Resolver.GetFormatterWithVerify<CustomerIndicatorView.ViewData>().Serialize(ref writer, (CustomerIndicatorView.ViewData)(object)value, options);
					break;
				case 117:
					options.Resolver.GetFormatterWithVerify<PlayerCosmeticSubview.ViewData>().Serialize(ref writer, (PlayerCosmeticSubview.ViewData)(object)value, options);
					break;
				}
			}
			else
			{
				writer.WriteNil();
			}
		}

		public IViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			if (reader.ReadArrayHeader() != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::Kitchen.IViewData");
			}
			options.Security.DepthStep(ref reader);
			int value = reader.ReadInt32();
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			IViewData result = null;
			switch (value)
			{
			case 0:
				result = options.Resolver.GetFormatterWithVerify<ConveyItemsView.ViewData>().Deserialize(ref reader, options);
				break;
			case 1:
				result = options.Resolver.GetFormatterWithVerify<DiscountDeskView.ViewData>().Deserialize(ref reader, options);
				break;
			case 2:
				result = options.Resolver.GetFormatterWithVerify<CustomerNameSubview.ViewData>().Deserialize(ref reader, options);
				break;
			case 3:
				result = options.Resolver.GetFormatterWithVerify<LimitedItemSourceLightsView.ViewData>().Deserialize(ref reader, options);
				break;
			case 4:
				result = options.Resolver.GetFormatterWithVerify<ISpecificViewData>().Deserialize(ref reader, options);
				break;
			case 5:
				result = options.Resolver.GetFormatterWithVerify<ItemHolderView.ItemHolderData>().Deserialize(ref reader, options);
				break;
			case 6:
				result = options.Resolver.GetFormatterWithVerify<CardSelectorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 7:
				result = options.Resolver.GetFormatterWithVerify<EventIndicatorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 8:
				result = options.Resolver.GetFormatterWithVerify<TeleportItemsView.ViewData>().Deserialize(ref reader, options);
				break;
			case 9:
				result = options.Resolver.GetFormatterWithVerify<DestroyViewData>().Deserialize(ref reader, options);
				break;
			case 10:
				result = options.Resolver.GetFormatterWithVerify<MoneyDisplayView.ViewData>().Deserialize(ref reader, options);
				break;
			case 11:
				result = options.Resolver.GetFormatterWithVerify<InfoManagerViewData>().Deserialize(ref reader, options);
				break;
			case 12:
				result = options.Resolver.GetFormatterWithVerify<ApplianceDecorationView.ViewData>().Deserialize(ref reader, options);
				break;
			case 13:
				result = options.Resolver.GetFormatterWithVerify<ApplianceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 14:
				result = options.Resolver.GetFormatterWithVerify<ApplianceInfoView.ViewData>().Deserialize(ref reader, options);
				break;
			case 15:
				result = options.Resolver.GetFormatterWithVerify<CreateFranchiseTextView.ViewData>().Deserialize(ref reader, options);
				break;
			case 16:
				result = options.Resolver.GetFormatterWithVerify<WorkshopOutputView.ViewData>().Deserialize(ref reader, options);
				break;
			case 17:
				result = options.Resolver.GetFormatterWithVerify<CardScrapperView.ViewData>().Deserialize(ref reader, options);
				break;
			case 18:
				result = options.Resolver.GetFormatterWithVerify<SetShoesView.ViewData>().Deserialize(ref reader, options);
				break;
			case 19:
				result = options.Resolver.GetFormatterWithVerify<AttachmentView.ViewData>().Deserialize(ref reader, options);
				break;
			case 20:
				result = options.Resolver.GetFormatterWithVerify<SteamRichPresenceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 21:
				result = options.Resolver.GetFormatterWithVerify<SettingSelectorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 22:
				result = options.Resolver.GetFormatterWithVerify<BlueprintView.ViewData>().Deserialize(ref reader, options);
				break;
			case 23:
				result = options.Resolver.GetFormatterWithVerify<TimeDisplayView.ViewData>().Deserialize(ref reader, options);
				break;
			case 24:
				result = options.Resolver.GetFormatterWithVerify<MoneyPopupView.ViewData>().Deserialize(ref reader, options);
				break;
			case 25:
				result = options.Resolver.GetFormatterWithVerify<ItemSourceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 26:
				result = options.Resolver.GetFormatterWithVerify<CreateViewData>().Deserialize(ref reader, options);
				break;
			case 27:
				result = options.Resolver.GetFormatterWithVerify<BlueprintDeskView.ViewData>().Deserialize(ref reader, options);
				break;
			case 28:
				result = options.Resolver.GetFormatterWithVerify<DishSelectionIndicator.ViewData>().Deserialize(ref reader, options);
				break;
			case 29:
				result = options.Resolver.GetFormatterWithVerify<SiteView.ViewData>().Deserialize(ref reader, options);
				break;
			case 30:
				result = options.Resolver.GetFormatterWithVerify<LayoutView.InitialViewData>().Deserialize(ref reader, options);
				break;
			case 31:
				result = options.Resolver.GetFormatterWithVerify<StartDayWarningView.ViewData>().Deserialize(ref reader, options);
				break;
			case 32:
				result = options.Resolver.GetFormatterWithVerify<SpeedrunBoardView.ViewData>().Deserialize(ref reader, options);
				break;
			case 33:
				result = options.Resolver.GetFormatterWithVerify<CrateView.ViewData>().Deserialize(ref reader, options);
				break;
			case 34:
				result = options.Resolver.GetFormatterWithVerify<ChairView.ViewData>().Deserialize(ref reader, options);
				break;
			case 35:
				result = options.Resolver.GetFormatterWithVerify<SoundEventView.ViewData>().Deserialize(ref reader, options);
				break;
			case 36:
				result = options.Resolver.GetFormatterWithVerify<EndOfDayPopupView.ViewData>().Deserialize(ref reader, options);
				break;
			case 37:
				result = options.Resolver.GetFormatterWithVerify<PlayerShoeSubview.ViewData>().Deserialize(ref reader, options);
				break;
			case 38:
				result = options.Resolver.GetFormatterWithVerify<ItemDrinksView.ViewData>().Deserialize(ref reader, options);
				break;
			case 39:
				result = options.Resolver.GetFormatterWithVerify<GameInfoTransferView.ViewData>().Deserialize(ref reader, options);
				break;
			case 40:
				result = options.Resolver.GetFormatterWithVerify<TableIndicatorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 41:
				result = options.Resolver.GetFormatterWithVerify<WeatherView.ViewData>().Deserialize(ref reader, options);
				break;
			case 42:
				result = options.Resolver.GetFormatterWithVerify<WorkshopMachineView.ViewData>().Deserialize(ref reader, options);
				break;
			case 43:
				result = options.Resolver.GetFormatterWithVerify<LoadoutPedestalView.ViewData>().Deserialize(ref reader, options);
				break;
			case 44:
				result = options.Resolver.GetFormatterWithVerify<FranchiseCardSetBubbleView.ViewData>().Deserialize(ref reader, options);
				break;
			case 45:
				result = options.Resolver.GetFormatterWithVerify<ItemStorageView.ViewData>().Deserialize(ref reader, options);
				break;
			case 46:
				result = options.Resolver.GetFormatterWithVerify<ApplianceDrinkView.ViewData>().Deserialize(ref reader, options);
				break;
			case 47:
				result = options.Resolver.GetFormatterWithVerify<IllusionWallView.ViewData>().Deserialize(ref reader, options);
				break;
			case 48:
				result = options.Resolver.GetFormatterWithVerify<MaintainInViewData>().Deserialize(ref reader, options);
				break;
			case 49:
				result = options.Resolver.GetFormatterWithVerify<ParametersDisplayView.ViewData>().Deserialize(ref reader, options);
				break;
			case 50:
				result = options.Resolver.GetFormatterWithVerify<PlayerHoldingSubview.ViewData>().Deserialize(ref reader, options);
				break;
			case 51:
				result = options.Resolver.GetFormatterWithVerify<WorkshopActivatorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 52:
				result = options.Resolver.GetFormatterWithVerify<LayoutDecorView.DecorationUpdates>().Deserialize(ref reader, options);
				break;
			case 53:
				result = options.Resolver.GetFormatterWithVerify<NewsUIView.ViewData>().Deserialize(ref reader, options);
				break;
			case 54:
				result = options.Resolver.GetFormatterWithVerify<NameplateView.ViewData>().Deserialize(ref reader, options);
				break;
			case 55:
				result = options.Resolver.GetFormatterWithVerify<FranchiseKitchenRecipeView.ViewData>().Deserialize(ref reader, options);
				break;
			case 56:
				result = options.Resolver.GetFormatterWithVerify<UpdateViewPositionData>().Deserialize(ref reader, options);
				break;
			case 57:
				result = options.Resolver.GetFormatterWithVerify<DishIndicatorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 58:
				result = options.Resolver.GetFormatterWithVerify<GenericChoiceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 59:
				result = options.Resolver.GetFormatterWithVerify<AutoPartnerView.ViewData>().Deserialize(ref reader, options);
				break;
			case 60:
				result = options.Resolver.GetFormatterWithVerify<GenericPopupView.ViewData>().Deserialize(ref reader, options);
				break;
			case 61:
				result = options.Resolver.GetFormatterWithVerify<DishChoiceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 62:
				result = options.Resolver.GetFormatterWithVerify<HeldApplianceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 63:
				result = options.Resolver.GetFormatterWithVerify<UpgradesTrackView.ViewData>().Deserialize(ref reader, options);
				break;
			case 64:
				result = options.Resolver.GetFormatterWithVerify<TransitionPopupView.ViewData>().Deserialize(ref reader, options);
				break;
			case 65:
				result = options.Resolver.GetFormatterWithVerify<BlueprintStoreView.ViewData>().Deserialize(ref reader, options);
				break;
			case 66:
				result = options.Resolver.GetFormatterWithVerify<LayoutChoiceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 67:
				result = options.Resolver.GetFormatterWithVerify<FranchiseCardSetView.ViewData>().Deserialize(ref reader, options);
				break;
			case 68:
				result = options.Resolver.GetFormatterWithVerify<ExpTrackView.ViewData>().Deserialize(ref reader, options);
				break;
			case 69:
				result = options.Resolver.GetFormatterWithVerify<RemoveLayoutDoorsView.ViewData>().Deserialize(ref reader, options);
				break;
			case 70:
				result = options.Resolver.GetFormatterWithVerify<EndgamePopupView.ViewData>().Deserialize(ref reader, options);
				break;
			case 71:
				result = options.Resolver.GetFormatterWithVerify<ApplianceInteractorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 72:
				result = options.Resolver.GetFormatterWithVerify<NewsItemView.ViewData>().Deserialize(ref reader, options);
				break;
			case 73:
				result = options.Resolver.GetFormatterWithVerify<GhostChairView.ViewData>().Deserialize(ref reader, options);
				break;
			case 74:
				result = options.Resolver.GetFormatterWithVerify<GenericPromptIndicatorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 75:
				result = options.Resolver.GetFormatterWithVerify<ProgressView.ViewData>().Deserialize(ref reader, options);
				break;
			case 76:
				result = options.Resolver.GetFormatterWithVerify<ApplianceProcessView.ViewData>().Deserialize(ref reader, options);
				break;
			case 77:
				result = options.Resolver.GetFormatterWithVerify<StartGameTextView.ViewData>().Deserialize(ref reader, options);
				break;
			case 78:
				result = options.Resolver.GetFormatterWithVerify<GrantExpView.ViewData>().Deserialize(ref reader, options);
				break;
			case 79:
				result = options.Resolver.GetFormatterWithVerify<ContractBubbleView.ViewData>().Deserialize(ref reader, options);
				break;
			case 80:
				result = options.Resolver.GetFormatterWithVerify<EndPracticeView.ViewData>().Deserialize(ref reader, options);
				break;
			case 81:
				result = options.Resolver.GetFormatterWithVerify<TutorialBubbleView.ViewData>().Deserialize(ref reader, options);
				break;
			case 82:
				result = options.Resolver.GetFormatterWithVerify<ItemView.ViewData>().Deserialize(ref reader, options);
				break;
			case 83:
				result = options.Resolver.GetFormatterWithVerify<OutfitSelectorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 84:
				result = options.Resolver.GetFormatterWithVerify<LoadLocationView.ViewData>().Deserialize(ref reader, options);
				break;
			case 85:
				result = options.Resolver.GetFormatterWithVerify<ApplianceInteractionView.ViewData>().Deserialize(ref reader, options);
				break;
			case 86:
				result = options.Resolver.GetFormatterWithVerify<DrawPathableGhostView.ViewData>().Deserialize(ref reader, options);
				break;
			case 87:
				result = options.Resolver.GetFormatterWithVerify<VariableProviderView.ViewData>().Deserialize(ref reader, options);
				break;
			case 88:
				result = options.Resolver.GetFormatterWithVerify<ApplianceGhostView.ViewData>().Deserialize(ref reader, options);
				break;
			case 89:
				result = options.Resolver.GetFormatterWithVerify<CardPedestalView.ViewData>().Deserialize(ref reader, options);
				break;
			case 90:
				result = options.Resolver.GetFormatterWithVerify<TwitchOptionsView.ViewData>().Deserialize(ref reader, options);
				break;
			case 91:
				result = options.Resolver.GetFormatterWithVerify<FixedDishView.ViewData>().Deserialize(ref reader, options);
				break;
			case 92:
				result = options.Resolver.GetFormatterWithVerify<BinView.ViewData>().Deserialize(ref reader, options);
				break;
			case 93:
				result = options.Resolver.GetFormatterWithVerify<SplittableItemView.ViewData>().Deserialize(ref reader, options);
				break;
			case 94:
				result = options.Resolver.GetFormatterWithVerify<UnlockSelectPopupView.ViewData>().Deserialize(ref reader, options);
				break;
			case 95:
				result = options.Resolver.GetFormatterWithVerify<ProfileEditorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 96:
				result = options.Resolver.GetFormatterWithVerify<InstantProcessToolView.ViewData>().Deserialize(ref reader, options);
				break;
			case 97:
				result = options.Resolver.GetFormatterWithVerify<LimitedItemSourceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 98:
				result = options.Resolver.GetFormatterWithVerify<ContractChoiceView.ViewData>().Deserialize(ref reader, options);
				break;
			case 99:
				result = options.Resolver.GetFormatterWithVerify<CostumeChangeIndicator.ViewData>().Deserialize(ref reader, options);
				break;
			case 100:
				result = options.Resolver.GetFormatterWithVerify<DayDisplayView.ViewData>().Deserialize(ref reader, options);
				break;
			case 101:
				result = options.Resolver.GetFormatterWithVerify<GroupSelectorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 102:
				result = options.Resolver.GetFormatterWithVerify<ItemVariableStorageView.ViewData>().Deserialize(ref reader, options);
				break;
			case 103:
				result = options.Resolver.GetFormatterWithVerify<CardsSubview.ViewData>().Deserialize(ref reader, options);
				break;
			case 104:
				result = options.Resolver.GetFormatterWithVerify<SeedInfoView.ViewData>().Deserialize(ref reader, options);
				break;
			case 105:
				result = options.Resolver.GetFormatterWithVerify<RerollBlueprintView.ViewData>().Deserialize(ref reader, options);
				break;
			case 106:
				result = options.Resolver.GetFormatterWithVerify<StarIncreaseView.ViewData>().Deserialize(ref reader, options);
				break;
			case 107:
				result = options.Resolver.GetFormatterWithVerify<OpenFrontDoorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 108:
				result = options.Resolver.GetFormatterWithVerify<AchievementTrackView.ViewData>().Deserialize(ref reader, options);
				break;
			case 109:
				result = options.Resolver.GetFormatterWithVerify<AchievementDistributionView.ViewData>().Deserialize(ref reader, options);
				break;
			case 110:
				result = options.Resolver.GetFormatterWithVerify<ItemCollectionView.ViewData>().Deserialize(ref reader, options);
				break;
			case 111:
				result = options.Resolver.GetFormatterWithVerify<PlayerPingView.ViewData>().Deserialize(ref reader, options);
				break;
			case 112:
				result = options.Resolver.GetFormatterWithVerify<PlayerColourView.ViewData>().Deserialize(ref reader, options);
				break;
			case 113:
				result = options.Resolver.GetFormatterWithVerify<SeededRunIndicatorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 114:
				result = options.Resolver.GetFormatterWithVerify<PlayerView.ViewData>().Deserialize(ref reader, options);
				break;
			case 115:
				result = options.Resolver.GetFormatterWithVerify<CustomerView.ViewData>().Deserialize(ref reader, options);
				break;
			case 116:
				result = options.Resolver.GetFormatterWithVerify<CustomerIndicatorView.ViewData>().Deserialize(ref reader, options);
				break;
			case 117:
				result = options.Resolver.GetFormatterWithVerify<PlayerCosmeticSubview.ViewData>().Deserialize(ref reader, options);
				break;
			default:
				reader.Skip();
				break;
			}
			reader.Depth--;
			return result;
		}
	}
}
