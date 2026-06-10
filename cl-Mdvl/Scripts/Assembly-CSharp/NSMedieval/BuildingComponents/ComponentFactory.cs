namespace NSMedieval.BuildingComponents
{
	public static class ComponentFactory
	{
		public static BeamComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, BeamComponentBlueprint blueprint)
		{
			BeamComponentInstance beamComponentInstance = new BeamComponentInstance(ownerBuilding, blueprint);
			beamComponentInstance.SetupAfterInstantiation();
			return beamComponentInstance;
		}

		public static BedComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, BedComponentBlueprint blueprint)
		{
			BedComponentInstance bedComponentInstance = new BedComponentInstance(ownerBuilding, blueprint);
			bedComponentInstance.SetupAfterInstantiation();
			return bedComponentInstance;
		}

		public static CaravanPostComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, CaravanPostComponentBlueprint blueprint)
		{
			CaravanPostComponentInstance caravanPostComponentInstance = new CaravanPostComponentInstance(ownerBuilding, blueprint);
			caravanPostComponentInstance.SetupAfterInstantiation();
			return caravanPostComponentInstance;
		}

		public static ChairComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, ChairComponentBlueprint blueprint)
		{
			ChairComponentInstance chairComponentInstance = new ChairComponentInstance(ownerBuilding, blueprint);
			chairComponentInstance.SetupAfterInstantiation();
			return chairComponentInstance;
		}

		public static DecorationComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, DecorationComponentBlueprint blueprint)
		{
			DecorationComponentInstance decorationComponentInstance = new DecorationComponentInstance(ownerBuilding, blueprint);
			decorationComponentInstance.SetupAfterInstantiation();
			return decorationComponentInstance;
		}

		public static DoorComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, DoorComponentBlueprint blueprint)
		{
			DoorComponentInstance doorComponentInstance = new DoorComponentInstance(ownerBuilding, blueprint);
			doorComponentInstance.SetupAfterInstantiation();
			return doorComponentInstance;
		}

		public static EntertainmentComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, EntertainmentComponentBlueprint blueprint, ReservablePositionsComponentInstance reservablePositionsComponentInstance)
		{
			EntertainmentComponentInstance entertainmentComponentInstance = new EntertainmentComponentInstance(ownerBuilding, blueprint, reservablePositionsComponentInstance);
			entertainmentComponentInstance.SetupAfterInstantiation();
			return entertainmentComponentInstance;
		}

		public static FuelConsumerComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, FuelConsumerComponentBlueprint blueprint)
		{
			FuelConsumerComponentInstance fuelConsumerComponentInstance = new FuelConsumerComponentInstance(ownerBuilding, blueprint);
			fuelConsumerComponentInstance.SetupAfterInstantiation();
			return fuelConsumerComponentInstance;
		}

		public static GallowsComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, GallowsComponentBlueprint blueprint)
		{
			GallowsComponentInstance gallowsComponentInstance = new GallowsComponentInstance(ownerBuilding, blueprint);
			gallowsComponentInstance.SetupAfterInstantiation();
			return gallowsComponentInstance;
		}

		public static GraveComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, GraveComponentBlueprint blueprint)
		{
			GraveComponentInstance graveComponentInstance = new GraveComponentInstance(ownerBuilding, blueprint);
			graveComponentInstance.SetupAfterInstantiation();
			return graveComponentInstance;
		}

		public static LadderComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, LadderComponentBlueprint blueprint)
		{
			LadderComponentInstance ladderComponentInstance = new LadderComponentInstance(ownerBuilding, blueprint);
			ladderComponentInstance.SetupAfterInstantiation();
			return ladderComponentInstance;
		}

		public static MapTableComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, MapTableComponentBlueprint blueprint)
		{
			MapTableComponentInstance mapTableComponentInstance = new MapTableComponentInstance(ownerBuilding, blueprint);
			mapTableComponentInstance.SetupAfterInstantiation();
			return mapTableComponentInstance;
		}

		public static PenMarkerComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, PenMarkerComponentBlueprint blueprint)
		{
			PenMarkerComponentInstance penMarkerComponentInstance = new PenMarkerComponentInstance(ownerBuilding, blueprint);
			penMarkerComponentInstance.SetupAfterInstantiation();
			return penMarkerComponentInstance;
		}

		public static RallyPointMarkerComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, RallyPointMarkerComponentBlueprint blueprint)
		{
			RallyPointMarkerComponentInstance rallyPointMarkerComponentInstance = new RallyPointMarkerComponentInstance(ownerBuilding, blueprint);
			rallyPointMarkerComponentInstance.SetupAfterInstantiation();
			return rallyPointMarkerComponentInstance;
		}

		public static ProductionComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, ProductionComponentBlueprint blueprint)
		{
			ProductionComponentInstance productionComponentInstance = new ProductionComponentInstance(ownerBuilding, blueprint);
			productionComponentInstance.SetupAfterInstantiation();
			return productionComponentInstance;
		}

		public static RoofComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, RoofComponentBlueprint blueprint, Vec3Int scale)
		{
			RoofComponentInstance roofComponentInstance = new RoofComponentInstance(ownerBuilding, blueprint, scale);
			roofComponentInstance.SetupAfterInstantiation();
			return roofComponentInstance;
		}

		public static RugComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, RugComponentBlueprint blueprint)
		{
			RugComponentInstance rugComponentInstance = new RugComponentInstance(ownerBuilding, blueprint);
			rugComponentInstance.SetupAfterInstantiation();
			return rugComponentInstance;
		}

		public static ShelfComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, ShelfComponentBlueprint blueprint)
		{
			ShelfComponentInstance shelfComponentInstance = new ShelfComponentInstance(ownerBuilding, blueprint);
			shelfComponentInstance.SetupAfterInstantiation();
			return shelfComponentInstance;
		}

		public static ShrineComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, ShrineComponentBlueprint blueprint, ReservablePositionsComponentInstance reservablePositionsComponentInstance)
		{
			ShrineComponentInstance shrineComponentInstance = new ShrineComponentInstance(ownerBuilding, blueprint, reservablePositionsComponentInstance);
			shrineComponentInstance.SetupAfterInstantiation();
			return shrineComponentInstance;
		}

		public static SignComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, SignComponentBlueprint blueprint)
		{
			SignComponentInstance signComponentInstance = new SignComponentInstance(ownerBuilding, blueprint);
			signComponentInstance.SetupAfterInstantiation();
			return signComponentInstance;
		}

		public static SocketComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding)
		{
			SocketComponentInstance socketComponentInstance = new SocketComponentInstance(ownerBuilding);
			socketComponentInstance.SetupAfterInstantiation();
			return socketComponentInstance;
		}

		public static StairsComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, StairsComponentBlueprint blueprint)
		{
			StairsComponentInstance stairsComponentInstance = new StairsComponentInstance(ownerBuilding, blueprint);
			stairsComponentInstance.SetupAfterInstantiation();
			return stairsComponentInstance;
		}

		public static TableComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, TableComponentBlueprint blueprint)
		{
			TableComponentInstance tableComponentInstance = new TableComponentInstance(ownerBuilding, blueprint);
			tableComponentInstance.SetupAfterInstantiation();
			return tableComponentInstance;
		}

		public static TradingPostComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, TradingPostComponentBlueprint blueprint)
		{
			TradingPostComponentInstance tradingPostComponentInstance = new TradingPostComponentInstance(ownerBuilding, blueprint);
			tradingPostComponentInstance.SetupAfterInstantiation();
			return tradingPostComponentInstance;
		}

		public static TrapComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, TrapComponentBlueprint blueprint)
		{
			TrapComponentInstance trapComponentInstance = new TrapComponentInstance(ownerBuilding, blueprint);
			trapComponentInstance.SetupAfterInstantiation();
			return trapComponentInstance;
		}

		public static WindowComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, WindowComponentBlueprint blueprint)
		{
			WindowComponentInstance windowComponentInstance = new WindowComponentInstance(ownerBuilding, blueprint);
			windowComponentInstance.SetupAfterInstantiation();
			return windowComponentInstance;
		}

		public static WellComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, WellComponentBlueprint blueprint)
		{
			WellComponentInstance wellComponentInstance = new WellComponentInstance(ownerBuilding, blueprint);
			wellComponentInstance.SetupAfterInstantiation();
			return wellComponentInstance;
		}

		public static SiegeWeaponComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, SiegeWeaponComponentBlueprint blueprint)
		{
			SiegeWeaponComponentInstance siegeWeaponComponentInstance = new SiegeWeaponComponentInstance(ownerBuilding, blueprint);
			siegeWeaponComponentInstance.SetupAfterInstantiation();
			return siegeWeaponComponentInstance;
		}

		public static BellComponentInstance CreateComponentInstance(BaseBuildingInstance ownerBuilding, BellComponentBlueprint blueprint)
		{
			BellComponentInstance bellComponentInstance = new BellComponentInstance(ownerBuilding, blueprint);
			bellComponentInstance.SetupAfterInstantiation();
			return bellComponentInstance;
		}
	}
}
