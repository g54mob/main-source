using System.Collections.Generic;
using DV.ThingTypes;

public static class TrainCarAndCargoDamageProperties
{
	public const float STRESS_DAMAGE_INFLICTION_THRESHOLD = 1f;

	public const float STRESS_DAMAGE_DESTRUCTION = 7f;

	public const float BASE_HEALTH = 8000f;

	public const float CARGO_TO_CAR_HEALTH_MULT = 0.7f;

	public const float BASE_ARMOR = 50f;

	public const float CARGO_TO_CAR_ARMOR_MULT = 0.5f;

	public const float BASE_FIRE_RESISTANCE = 7.5f;

	public const float BASE_DAMAGE_TOLERANCE = 0.01f;

	public const float DAMAGE_PER_STRESS = 1383.3334f;

	public const float TANK_DAMAGE_TOLERANCE_MULTIPLIER = 50f;

	public const float FIRE_DAMAGE_PER_S = 82.5f;

	public static Dictionary<TrainCarType, CarDamageProperties> carDamageProperties = new Dictionary<TrainCarType, CarDamageProperties>
	{
		{
			TrainCarType.LocoShunter,
			new CarDamageProperties(5600f, 25f, 1f, 7.5f, 1f, 0.01f)
		},
		{
			TrainCarType.LocoSteamHeavy,
			new CarDamageProperties(17920f, 37.5f, 1f, 37.5f, 1f, 0.04f)
		},
		{
			TrainCarType.Tender,
			new CarDamageProperties(7279.9995f, 37.5f, 1f, 37.5f, 1f, 0.04f)
		},
		{
			TrainCarType.LocoS060,
			new CarDamageProperties(11200f, 37.5f, 1f, 37.5f, 1f, 0.04f)
		},
		{
			TrainCarType.LocoDiesel,
			new CarDamageProperties(8400f, 37.5f, 1f, 11.25f, 1f, 0.02f)
		},
		{
			TrainCarType.LocoDE6Slug,
			new CarDamageProperties(5600f, 37.5f, 1f, 11.25f, 1f, 0.02f)
		},
		{
			TrainCarType.LocoDH4,
			new CarDamageProperties(5600f, 27.5f, 1f, 11.25f, 1f, 0.015f)
		},
		{
			TrainCarType.LocoDM3,
			new CarDamageProperties(7279.9995f, 50f, 1f, 15f, 1f, 0.022f)
		},
		{
			TrainCarType.CabooseRed,
			new CarDamageProperties(7279.9995f, 50f, 1f, 15f, 1f, 0.022f, ignoreDamage: true)
		},
		{
			TrainCarType.FlatbedEmpty,
			new CarDamageProperties(7840f, 50f, 1f, 9f, 1f, 0.049999997f)
		},
		{
			TrainCarType.FlatbedStakes,
			new CarDamageProperties(8400f, 50f, 1f, 9f, 1f, 0.044999998f)
		},
		{
			TrainCarType.FlatbedMilitary,
			new CarDamageProperties(11200f, 50f, 1f, 9f, 1f, 0.049999997f)
		},
		{
			TrainCarType.FlatbedShort,
			new CarDamageProperties(6720.0005f, 25f, 1f, 7.5f, 1f, 0.02f, ignoreDamage: true)
		},
		{
			TrainCarType.HopperBrown,
			new CarDamageProperties(10080f, 27.5f, 1f, 16.5f, 1f, 0.07f)
		},
		{
			TrainCarType.HopperTeal,
			new CarDamageProperties(10080f, 27.5f, 1f, 16.5f, 1f, 0.07f)
		},
		{
			TrainCarType.HopperYellow,
			new CarDamageProperties(10080f, 27.5f, 1f, 16.5f, 1f, 0.07f)
		},
		{
			TrainCarType.HopperCoveredBrown,
			new CarDamageProperties(9520f, 35f, 1f, 16.5f, 1f, 0.06f)
		},
		{
			TrainCarType.GondolaRed,
			new CarDamageProperties(8960f, 35f, 1f, 16.5f, 1f, 0.06f)
		},
		{
			TrainCarType.GondolaGreen,
			new CarDamageProperties(8960f, 35f, 1f, 16.5f, 1f, 0.06f)
		},
		{
			TrainCarType.GondolaGray,
			new CarDamageProperties(8960f, 35f, 1f, 16.5f, 1f, 0.06f)
		},
		{
			TrainCarType.TankOrange,
			new CarDamageProperties(9520f, 27.5f, 1f, 9f, 1f, 0.02f)
		},
		{
			TrainCarType.TankYellow,
			new CarDamageProperties(7279.9995f, 27.5f, 1f, 9f, 1f, 0.02f)
		},
		{
			TrainCarType.TankWhite,
			new CarDamageProperties(7279.9995f, 27.5f, 1f, 9f, 1f, 0.02f)
		},
		{
			TrainCarType.TankBlue,
			new CarDamageProperties(9520f, 27.5f, 1f, 15f, 1f, 0.02f)
		},
		{
			TrainCarType.TankBlack,
			new CarDamageProperties(11200f, 27.5f, 1f, 22.5f, 1f, 0.02f)
		},
		{
			TrainCarType.TankChrome,
			new CarDamageProperties(7279.9995f, 27.5f, 1f, 9f, 1f, 0.02f)
		},
		{
			TrainCarType.TankShortMilk,
			new CarDamageProperties(7279.9995f, 27.5f, 1f, 9f, 1f, 0.02f)
		},
		{
			TrainCarType.StockRed,
			new CarDamageProperties(4480f, 22.5f, 1f, 6f, 1f, 0.02f)
		},
		{
			TrainCarType.StockGreen,
			new CarDamageProperties(4480f, 22.5f, 1f, 6f, 1f, 0.02f)
		},
		{
			TrainCarType.StockBrown,
			new CarDamageProperties(4480f, 22.5f, 1f, 6f, 1f, 0.02f)
		},
		{
			TrainCarType.BoxcarBrown,
			new CarDamageProperties(4480f, 22.5f, 1f, 6f, 1f, 0.02f)
		},
		{
			TrainCarType.BoxcarGreen,
			new CarDamageProperties(4480f, 22.5f, 1f, 6f, 1f, 0.02f)
		},
		{
			TrainCarType.BoxcarPink,
			new CarDamageProperties(4480f, 22.5f, 1f, 6f, 1f, 0.02f)
		},
		{
			TrainCarType.BoxcarRed,
			new CarDamageProperties(4480f, 22.5f, 1f, 6f, 1f, 0.02f)
		},
		{
			TrainCarType.BoxcarMilitary,
			new CarDamageProperties(7840f, 25f, 1f, 7.5f, 1f, 0.02f)
		},
		{
			TrainCarType.RefrigeratorWhite,
			new CarDamageProperties(5040f, 25f, 1f, 9f, 1f, 0.0139999995f)
		},
		{
			TrainCarType.PassengerRed,
			new CarDamageProperties(14559.999f, 15.000001f, 1f, 4.5f, 1f, 0.01f)
		},
		{
			TrainCarType.PassengerGreen,
			new CarDamageProperties(14559.999f, 15.000001f, 1f, 4.5f, 1f, 0.01f)
		},
		{
			TrainCarType.PassengerBlue,
			new CarDamageProperties(14559.999f, 15.000001f, 1f, 4.5f, 1f, 0.01f)
		},
		{
			TrainCarType.AutorackRed,
			new CarDamageProperties(8400f, 22.5f, 1f, 30f, 1f, 0.049999997f)
		},
		{
			TrainCarType.AutorackBlue,
			new CarDamageProperties(8400f, 22.5f, 1f, 30f, 1f, 0.049999997f)
		},
		{
			TrainCarType.AutorackGreen,
			new CarDamageProperties(8400f, 22.5f, 1f, 30f, 1f, 0.049999997f)
		},
		{
			TrainCarType.AutorackYellow,
			new CarDamageProperties(8400f, 22.5f, 1f, 30f, 1f, 0.049999997f)
		},
		{
			TrainCarType.HandCar,
			new CarDamageProperties(280f, 125f, 1f, 15f, 1f, 0.099999994f, ignoreDamage: true)
		},
		{
			TrainCarType.NuclearFlask,
			new CarDamageProperties(14000f, 37.5f, 1f, 30f, 1f, 0.08f)
		}
	};

	public static HashSet<CargoType> Liquids = new HashSet<CargoType>
	{
		CargoType.Alcohol,
		CargoType.Ammonia,
		CargoType.Biohazard,
		CargoType.CrudeOil,
		CargoType.Diesel,
		CargoType.Gasoline,
		CargoType.SodiumHydroxide,
		CargoType.Milk
	};

	public static HashSet<CargoType> Oils = new HashSet<CargoType>
	{
		CargoType.CrudeOil,
		CargoType.Diesel
	};

	public static HashSet<CargoType> FlammableLiquids = new HashSet<CargoType>
	{
		CargoType.CrudeOil,
		CargoType.Gasoline,
		CargoType.Diesel,
		CargoType.Alcohol
	};

	public static HashSet<CargoType> CorosiveLiquids = new HashSet<CargoType>
	{
		CargoType.Ammonia,
		CargoType.SodiumHydroxide
	};

	public static HashSet<CargoType> Gases = new HashSet<CargoType>
	{
		CargoType.Acetylene,
		CargoType.Argon,
		CargoType.CryoHydrogen,
		CargoType.Nitrogen,
		CargoType.CryoOxygen,
		CargoType.Methane
	};

	public static HashSet<CargoType> FlammableGases = new HashSet<CargoType>
	{
		CargoType.Acetylene,
		CargoType.CryoHydrogen,
		CargoType.Methane
	};

	public static HashSet<CargoType> FlammableSolids = new HashSet<CargoType>
	{
		CargoType.Boards,
		CargoType.Coal,
		CargoType.Corn,
		CargoType.Logs,
		CargoType.Plywood,
		CargoType.Wheat,
		CargoType.Sleepers,
		CargoType.ScrapWood,
		CargoType.WoodChips
	};

	public static HashSet<CargoType> RadioactiveCargo = new HashSet<CargoType> { CargoType.SpentNuclearFuel };

	private static HashSet<CargoType> _flammableCargo = new HashSet<CargoType>();

	public static HashSet<CargoType> ExplosiveCargo = new HashSet<CargoType>
	{
		CargoType.Acetylene,
		CargoType.Alcohol,
		CargoType.Ammunition,
		CargoType.CryoHydrogen,
		CargoType.Gasoline,
		CargoType.Methane,
		CargoType.Missiles,
		CargoType.AmmoniumNitrate
	};

	public static HashSet<CargoType> ExtinguishingGases = new HashSet<CargoType>
	{
		CargoType.Argon,
		CargoType.Nitrogen
	};

	public static HashSet<CargoType> Oxidizers = new HashSet<CargoType> { CargoType.CryoOxygen };

	public static Dictionary<CargoType, CargoDamageProperties> CargoDamageProperties = new Dictionary<CargoType, CargoDamageProperties>
	{
		{
			CargoType.Coal,
			new CargoDamageProperties(40000f, 0.049999997f, 1f, 200f, 2f, 5.25f)
		},
		{
			CargoType.IronOre,
			new CargoDamageProperties(64000f, 0.049999997f, 1f, 200f, 1f, 37.5f)
		},
		{
			CargoType.CrudeOil,
			new CargoDamageProperties(8000f, 0.5f, 1f, 100f, 1f, 6f)
		},
		{
			CargoType.Logs,
			new CargoDamageProperties(48000f, 0.02f, 1f, 150f, 2f, 0.75f)
		},
		{
			CargoType.Boards,
			new CargoDamageProperties(32000f, 0.02f, 1f, 100f, 5f, 0.375f)
		},
		{
			CargoType.Plywood,
			new CargoDamageProperties(4000f, 0.02f, 1f, 75f, 5f, 0.074999996f)
		},
		{
			CargoType.Sleepers,
			new CargoDamageProperties(40000f, 0.02f, 1f, 100f, 5f, 1.5f)
		},
		{
			CargoType.Wheat,
			new CargoDamageProperties(40000f, 0.049999997f, 1f, 250f, 2f, 0.375f)
		},
		{
			CargoType.Corn,
			new CargoDamageProperties(40000f, 0.049999997f, 1f, 250f, 2f, 0.375f)
		},
		{
			CargoType.SunflowerSeeds,
			new CargoDamageProperties(32000f, 0.049999997f, 1f, 250f, 1f, 0.375f)
		},
		{
			CargoType.Flour,
			new CargoDamageProperties(40000f, 0.049999997f, 1f, 250f, 1f, 0.375f)
		},
		{
			CargoType.Pigs,
			new CargoDamageProperties(2400f, 0.01f, 1f, 150f, 5f, 0.75f)
		},
		{
			CargoType.Cows,
			new CargoDamageProperties(3200f, 0.01f, 1f, 150f, 5f, 0.75f)
		},
		{
			CargoType.Poultry,
			new CargoDamageProperties(4800f, 0.01f, 1f, 200f, 5f, 0.75f)
		},
		{
			CargoType.Sheep,
			new CargoDamageProperties(2400f, 0.01f, 1f, 150f, 5f, 0.75f)
		},
		{
			CargoType.Goats,
			new CargoDamageProperties(2400f, 0.01f, 1f, 150f, 5f, 0.75f)
		},
		{
			CargoType.Fish,
			new CargoDamageProperties(2400f, 0.01f, 1f, 100f, 2f, 3f)
		},
		{
			CargoType.Bread,
			new CargoDamageProperties(3200f, 0.02f, 1f, 200f, 3f, 2.25f)
		},
		{
			CargoType.DairyProducts,
			new CargoDamageProperties(2400f, 0.01f, 1f, 50f, 2f, 3f)
		},
		{
			CargoType.MeatProducts,
			new CargoDamageProperties(3200f, 0.01f, 1f, 100f, 2f, 3f)
		},
		{
			CargoType.CannedFood,
			new CargoDamageProperties(5600f, 0.03f, 1f, 75f, 1f, 4.5f)
		},
		{
			CargoType.CatFood,
			new CargoDamageProperties(3200f, 0.03f, 1f, 200f, 2f, 0.75f)
		},
		{
			CargoType.TemperateFruits,
			new CargoDamageProperties(1600f, 0.01f, 1f, 50f, 2f, 2.25f)
		},
		{
			CargoType.Vegetables,
			new CargoDamageProperties(3200f, 0.02f, 1f, 100f, 2f, 3f)
		},
		{
			CargoType.Milk,
			new CargoDamageProperties(8000f, 0.5f, 1f, 100f, 2f, 5.25f)
		},
		{
			CargoType.Eggs,
			new CargoDamageProperties(800f, 0.002f, 1f, 10f, 2f, 0.75f)
		},
		{
			CargoType.Cotton,
			new CargoDamageProperties(16000f, 0.04f, 1f, 500f, 3f, 1.5f)
		},
		{
			CargoType.Wool,
			new CargoDamageProperties(16000f, 0.04f, 1f, 500f, 3f, 1.5f)
		},
		{
			CargoType.TropicalFruits,
			new CargoDamageProperties(1600f, 0.01f, 1f, 50f, 2f, 2.25f)
		},
		{
			CargoType.Diesel,
			new CargoDamageProperties(8000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.Gasoline,
			new CargoDamageProperties(8000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.Methane,
			new CargoDamageProperties(8000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.SteelRolls,
			new CargoDamageProperties(64000f, 0.04f, 1f, 200f, 1f, 22.5f)
		},
		{
			CargoType.SteelBillets,
			new CargoDamageProperties(64000f, 0.04f, 1f, 200f, 1f, 22.5f)
		},
		{
			CargoType.SteelSlabs,
			new CargoDamageProperties(64000f, 0.04f, 1f, 200f, 1f, 22.5f)
		},
		{
			CargoType.SteelBentPlates,
			new CargoDamageProperties(48000f, 0.04f, 1f, 200f, 1f, 22.5f)
		},
		{
			CargoType.SteelRails,
			new CargoDamageProperties(64000f, 0.04f, 1f, 200f, 1f, 22.5f)
		},
		{
			CargoType.CraneParts,
			new CargoDamageProperties(32000f, 0.03f, 1f, 200f, 1f, 22.5f)
		},
		{
			CargoType.ScrapMetal,
			new CargoDamageProperties(64000f, 0.049999997f, 1f, 200f, 1f, 37.5f)
		},
		{
			CargoType.ScrapWood,
			new CargoDamageProperties(40000f, 0.02f, 1f, 100f, 5f, 0.14999999f)
		},
		{
			CargoType.WoodChips,
			new CargoDamageProperties(40000f, 0.02f, 1f, 100f, 6f, 0.074999996f)
		},
		{
			CargoType.ScrapContainers,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 37.5f)
		},
		{
			CargoType.ElectronicsIskar,
			new CargoDamageProperties(1600f, 0.02f, 1f, 50f, 2f, 3.75f)
		},
		{
			CargoType.ElectronicsKrugmann,
			new CargoDamageProperties(1600f, 0.02f, 1f, 50f, 2f, 3.75f)
		},
		{
			CargoType.ElectronicsAAG,
			new CargoDamageProperties(1600f, 0.02f, 1f, 50f, 2f, 3.75f)
		},
		{
			CargoType.ElectronicsNovae,
			new CargoDamageProperties(1600f, 0.02f, 1f, 50f, 2f, 3.75f)
		},
		{
			CargoType.ElectronicsTraeg,
			new CargoDamageProperties(1600f, 0.02f, 1f, 50f, 2f, 3.75f)
		},
		{
			CargoType.ToolsIskar,
			new CargoDamageProperties(12000f, 0.02f, 1f, 150f, 1f, 5.25f)
		},
		{
			CargoType.ToolsBrohm,
			new CargoDamageProperties(12000f, 0.02f, 1f, 150f, 1f, 5.25f)
		},
		{
			CargoType.ToolsAAG,
			new CargoDamageProperties(12000f, 0.02f, 1f, 150f, 1f, 5.25f)
		},
		{
			CargoType.ToolsNovae,
			new CargoDamageProperties(12000f, 0.02f, 1f, 150f, 1f, 5.25f)
		},
		{
			CargoType.ToolsTraeg,
			new CargoDamageProperties(12000f, 0.02f, 1f, 150f, 1f, 5.25f)
		},
		{
			CargoType.Furniture,
			new CargoDamageProperties(2400f, 0.02f, 1f, 50f, 3f, 0.75f)
		},
		{
			CargoType.ClothingObco,
			new CargoDamageProperties(4000f, 0.02f, 1f, 500f, 2f, 2.25f)
		},
		{
			CargoType.ClothingNeoGamma,
			new CargoDamageProperties(4000f, 0.02f, 1f, 500f, 2f, 2.25f)
		},
		{
			CargoType.ClothingNovae,
			new CargoDamageProperties(4000f, 0.02f, 1f, 500f, 2f, 2.25f)
		},
		{
			CargoType.ClothingTraeg,
			new CargoDamageProperties(4000f, 0.02f, 1f, 500f, 2f, 2.25f)
		},
		{
			CargoType.Pipes,
			new CargoDamageProperties(40000f, 0.02f, 1f, 150f, 1f, 22.5f)
		},
		{
			CargoType.NewCars,
			new CargoDamageProperties(4000f, 0.01f, 1f, 100f, 2f, 7.5f)
		},
		{
			CargoType.ImportedNewCars,
			new CargoDamageProperties(4000f, 0.01f, 1f, 100f, 2f, 7.5f)
		},
		{
			CargoType.Tractors,
			new CargoDamageProperties(5600f, 0.015f, 1f, 100f, 2f, 7.5f)
		},
		{
			CargoType.Excavators,
			new CargoDamageProperties(20000f, 0.02f, 1f, 125f, 1f, 15f)
		},
		{
			CargoType.MiningTrucks,
			new CargoDamageProperties(28000f, 0.03f, 1f, 150f, 1f, 15f)
		},
		{
			CargoType.CityBuses,
			new CargoDamageProperties(5600f, 0.01f, 1f, 100f, 2f, 15f)
		},
		{
			CargoType.Trams,
			new CargoDamageProperties(8000f, 0.01f, 1f, 110f, 2f, 18.75f)
		},
		{
			CargoType.SemiTrailers,
			new CargoDamageProperties(8000f, 0.04f, 1f, 100f, 2f, 11.25f)
		},
		{
			CargoType.ForestryTrailers,
			new CargoDamageProperties(8000f, 0.02f, 1f, 100f, 2f, 11.25f)
		},
		{
			CargoType.Acetylene,
			new CargoDamageProperties(4000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.Medicine,
			new CargoDamageProperties(4000f, 0.02f, 1f, 200f, 2f, 3.75f)
		},
		{
			CargoType.CryoOxygen,
			new CargoDamageProperties(4000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.CryoHydrogen,
			new CargoDamageProperties(4000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.Argon,
			new CargoDamageProperties(4000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.Nitrogen,
			new CargoDamageProperties(4000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.SpentNuclearFuel,
			new CargoDamageProperties(24000f, 0.95f, 1f, 800f, 1f, 22.5f)
		},
		{
			CargoType.Ammunition,
			new CargoDamageProperties(800f, 0.95f, 1f, 0.5f, 1f, 0.75f)
		},
		{
			CargoType.Missiles,
			new CargoDamageProperties(800f, 0.95f, 1f, 0.5f, 1f, 0.75f)
		},
		{
			CargoType.Alcohol,
			new CargoDamageProperties(8000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.Ammonia,
			new CargoDamageProperties(8000f, 0.5f, 1f, 150f, 1f, 7.5f)
		},
		{
			CargoType.SodiumHydroxide,
			new CargoDamageProperties(8000f, 0.5f, 1f, 150f, 1f, 7.5f)
		},
		{
			CargoType.AmmoniumNitrate,
			new CargoDamageProperties(4000f, 0.5f, 1f, 100f, 1f, 5.25f)
		},
		{
			CargoType.Biohazard,
			new CargoDamageProperties(8000f, 0.5f, 1f, 250f, 1f, 0.75f)
		},
		{
			CargoType.ChemicalsIskar,
			new CargoDamageProperties(3200f, 0.02f, 1f, 100f, 2f, 3.75f)
		},
		{
			CargoType.ChemicalsSperex,
			new CargoDamageProperties(3200f, 0.02f, 1f, 100f, 2f, 3.75f)
		},
		{
			CargoType.Tanks,
			new CargoDamageProperties(28000f, 0.03f, 1f, 150f, 1f, 15f)
		},
		{
			CargoType.AttackHelicopters,
			new CargoDamageProperties(4000f, 0.01f, 1f, 100f, 2f, 3.75f)
		},
		{
			CargoType.MilitaryTrucks,
			new CargoDamageProperties(16000f, 0.015f, 1f, 110f, 1f, 9f)
		},
		{
			CargoType.MilitaryCars,
			new CargoDamageProperties(6000f, 0.01f, 1f, 100f, 1f, 7.5f)
		},
		{
			CargoType.MilitarySupplies,
			new CargoDamageProperties(12000f, 0.02f, 1f, 125f, 2f, 11.25f)
		},
		{
			CargoType.EmptySunOmni,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyIskar,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyObco,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyGoorsk,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyKrugmann,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyBrohm,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyAAG,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptySperex,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyNovae,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyTraeg,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyChemlek,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.EmptyNeoGamma,
			new CargoDamageProperties(16000f, 0.02f, 1f, 250f, 1f, 15f)
		},
		{
			CargoType.TrainPartsDE2,
			new CargoDamageProperties(16000f, 0.02f, 0f, 150f, 0f, 15f)
		},
		{
			CargoType.TrainPartsDE6,
			new CargoDamageProperties(16000f, 0.02f, 0f, 150f, 0f, 15f)
		},
		{
			CargoType.TrainPartsDH4,
			new CargoDamageProperties(16000f, 0.02f, 0f, 150f, 0f, 15f)
		},
		{
			CargoType.TrainPartsDM3,
			new CargoDamageProperties(16000f, 0.02f, 0f, 150f, 0f, 15f)
		},
		{
			CargoType.TrainPartsS060,
			new CargoDamageProperties(16000f, 0.02f, 0f, 150f, 0f, 15f)
		},
		{
			CargoType.TrainPartsS282A,
			new CargoDamageProperties(16000f, 0.02f, 0f, 150f, 0f, 15f)
		}
	};

	public static Dictionary<CargoType, CargoReactionProperties> CargoReactionProperties = new Dictionary<CargoType, CargoReactionProperties>
	{
		{
			CargoType.CryoHydrogen,
			new CargoReactionProperties(0.75f, 0f, 0.7f, 0.95f, 4000f, 6000f, 1.5f)
		},
		{
			CargoType.Nitrogen,
			new CargoReactionProperties(-5f, -2f)
		},
		{
			CargoType.Argon,
			new CargoReactionProperties(-5f, -2f)
		},
		{
			CargoType.Methane,
			new CargoReactionProperties(0.5f, 0f, 0.7f, 0.85f, 4000f, 6000f, 1.5f)
		},
		{
			CargoType.Acetylene,
			new CargoReactionProperties(0.5f, 0f, 0.7f, 0.85f, 4000f, 6000f, 1.5f)
		},
		{
			CargoType.CryoOxygen,
			new CargoReactionProperties(0f, 0.5f)
		},
		{
			CargoType.Gasoline,
			new CargoReactionProperties(0.65f, 0f, 0.7f, 0.9f, float.PositiveInfinity, float.PositiveInfinity, 2.3f)
		},
		{
			CargoType.CrudeOil,
			new CargoReactionProperties(0.65f, 0f, 0.7f, 0.9f, float.PositiveInfinity, float.PositiveInfinity, 2.3f)
		},
		{
			CargoType.Diesel,
			new CargoReactionProperties(0.65f, 0f, 0.7f, 0.9f, float.PositiveInfinity, float.PositiveInfinity, 2.3f)
		},
		{
			CargoType.Alcohol,
			new CargoReactionProperties(0.65f, 0f, 0.7f, 0.9f, float.PositiveInfinity, float.PositiveInfinity, 2.3f)
		},
		{
			CargoType.Coal,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.Logs,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.Sleepers,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.Boards,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.Plywood,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.ScrapWood,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.WoodChips,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.Wheat,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.Corn,
			new CargoReactionProperties(0.3f, 0f, 100f, 200f)
		},
		{
			CargoType.Ammunition,
			new CargoReactionProperties(-10f, 0f, 100f, 200f, float.PositiveInfinity, float.PositiveInfinity, 0.1f)
		},
		{
			CargoType.Missiles,
			new CargoReactionProperties(-5f, 0f, 100f, 200f, float.PositiveInfinity, float.PositiveInfinity, 0.1f)
		},
		{
			CargoType.Ammonia,
			new CargoReactionProperties(-5f, -0.5f)
		},
		{
			CargoType.SodiumHydroxide,
			new CargoReactionProperties(-5f, -0.5f)
		},
		{
			CargoType.AmmoniumNitrate,
			new CargoReactionProperties(-5f, 0f, 100f, 200f, float.PositiveInfinity, float.PositiveInfinity, 0.2f)
		}
	};

	public static Dictionary<CargoType, CargoLeakProperties> CargoLeakProperties = new Dictionary<CargoType, CargoLeakProperties>
	{
		{
			CargoType.CryoHydrogen,
			new CargoLeakProperties(500f, 100f, 1f, 250f, 0.2f)
		},
		{
			CargoType.Nitrogen,
			new CargoLeakProperties(500f, 100f, 1f, 250f, 0.2f)
		},
		{
			CargoType.Argon,
			new CargoLeakProperties(500f, 100f, 1f, 250f, 0.2f)
		},
		{
			CargoType.Methane,
			new CargoLeakProperties(500f, 100f, 1f, 250f, 0.2f)
		},
		{
			CargoType.Acetylene,
			new CargoLeakProperties(500f, 100f, 1f, 250f, 0.2f)
		},
		{
			CargoType.CryoOxygen,
			new CargoLeakProperties(500f, 100f, 1f, 250f, 0.5f)
		},
		{
			CargoType.Gasoline,
			new CargoLeakProperties(1000f, 200f, 0f, 125f)
		},
		{
			CargoType.CrudeOil,
			new CargoLeakProperties(1000f, 200f, 0f, 125f)
		},
		{
			CargoType.Diesel,
			new CargoLeakProperties(1000f, 200f, 0f, 125f)
		},
		{
			CargoType.Alcohol,
			new CargoLeakProperties(1000f, 200f, 0f, 125f)
		},
		{
			CargoType.Ammonia,
			new CargoLeakProperties(1000f, 200f, 0f, 250f)
		},
		{
			CargoType.SodiumHydroxide,
			new CargoLeakProperties(1000f, 200f, 1f, 250f, 0.2f)
		},
		{
			CargoType.Biohazard,
			new CargoLeakProperties(1000f, 200f, 0f, 250f)
		}
	};

	public static CarDamageProperties StandardCarDamageProperties { get; private set; } = new CarDamageProperties(8000f, 50f, 1f, 7.5f, 1f, 0.01f);

	public static HashSet<CargoType> FlammableCargo => GetAllFlammableCargo();

	public static CargoDamageProperties StandardCargoDamageProperties { get; private set; } = new CargoDamageProperties(8000f, 0.01f, 1f, 50f, 1f, 7.5f);

	public static CargoReactionProperties StandardReactionProperties { get; private set; } = new CargoReactionProperties(-5f);

	public static CargoLeakProperties StandardLeakProperties { get; private set; } = new CargoLeakProperties(500f, 100f);

	public static bool IsCargoLiquid(CargoType cargoType)
	{
		return Liquids.Contains(cargoType);
	}

	public static bool IsCargoOil(CargoType cargoType)
	{
		return Oils.Contains(cargoType);
	}

	public static bool IsCargoFlammableLiquid(CargoType cargoType)
	{
		return FlammableLiquids.Contains(cargoType);
	}

	public static bool IsCargoCorrosiveLiquid(CargoType cargoType)
	{
		return CorosiveLiquids.Contains(cargoType);
	}

	public static bool IsCargoGas(CargoType cargoType)
	{
		return Gases.Contains(cargoType);
	}

	public static bool IsCargoFlammableGas(CargoType cargoType)
	{
		return FlammableGases.Contains(cargoType);
	}

	public static bool IsCargoExtinguishingGas(CargoType cargoType)
	{
		return ExtinguishingGases.Contains(cargoType);
	}

	public static bool IsCargoFlammable(CargoType cargoType)
	{
		return FlammableCargo.Contains(cargoType);
	}

	public static bool IsCargoOxidizer(CargoType cargoType)
	{
		return Oxidizers.Contains(cargoType);
	}

	public static bool IsCargoExplosive(CargoType cargoType)
	{
		return ExplosiveCargo.Contains(cargoType);
	}

	public static bool IsRadioactive(CargoType cargoType)
	{
		return RadioactiveCargo.Contains(cargoType);
	}

	public static CargoPhase GetCargoPhase(CargoType cargoType)
	{
		if (IsCargoLiquid(cargoType))
		{
			return CargoPhase.Liquid;
		}
		if (IsCargoGas(cargoType))
		{
			return CargoPhase.Gas;
		}
		return CargoPhase.Solid;
	}

	private static HashSet<CargoType> GetAllFlammableCargo()
	{
		if (_flammableCargo.Count <= 0)
		{
			_flammableCargo.UnionWith(FlammableGases);
			_flammableCargo.UnionWith(FlammableLiquids);
			_flammableCargo.UnionWith(FlammableSolids);
		}
		return _flammableCargo;
	}

	public static CargoEffectsType CargoTypeToEffectsType(CargoType cargoType)
	{
		CargoEffectsType cargoEffectsType = CargoEffectsType.None;
		if (IsCargoLiquid(cargoType))
		{
			cargoEffectsType |= CargoEffectsType.Liquid;
			if (IsCargoOil(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Oil;
			}
			if (IsCargoFlammable(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Flammable;
			}
			if (IsCargoExplosive(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Explosive;
			}
			if (IsRadioactive(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Radioactive;
			}
		}
		else if (IsCargoGas(cargoType))
		{
			cargoEffectsType |= CargoEffectsType.Gas;
			if (IsCargoFlammable(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Flammable;
			}
			if (IsCargoExplosive(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Explosive;
			}
			if (IsRadioactive(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Radioactive;
			}
		}
		else if (cargoType != CargoType.None)
		{
			cargoEffectsType |= CargoEffectsType.Solid;
			if (IsCargoFlammable(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Flammable;
			}
			if (IsCargoExplosive(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Explosive;
			}
			if (IsRadioactive(cargoType))
			{
				cargoEffectsType |= CargoEffectsType.Radioactive;
			}
		}
		return cargoEffectsType;
	}
}
