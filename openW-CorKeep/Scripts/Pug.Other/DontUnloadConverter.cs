using Pug.Automation;
using Pug.Conversion;
using UnityEngine;

public class DontUnloadConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		BossAuthoring component2;
		SummonAreaAuthoring component3;
		MerchantAuthoring component4;
		AutomatedMoverAuthoring component5;
		AutomatedCrafterAuthoring component6;
		CattleAuthoring component7;
		AutomatedMineableAuthoring component8;
		AutomatedMinerAuthoring component9;
		AutomatedStorageAuthoring component10;
		CanBePickedUpAuthoring component11;
		ElectricityAuthoring component12;
		BedAuthoring component13;
		PlayerGraveAuthoring component14;
		BossStatueAuthoring component15;
		TheCoreAuthoring component16;
		PortalAuthoring component17;
		SoulOrbAuthoring component18;
		MapMarkerAuthoring component19;
		BossSpawnLocationAuthoring component20;
		SnakeMovementStateAuthoring component21;
		PlantAuthoring component22;
		RootPlantAuthoring component23;
		SeedAuthoring component24;
		SprinklerAuthoring component25;
		if (TryGetActiveComponent<PlayerAuthoring>(authoring, out var _))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<BossAuthoring>(authoring, out component2))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<SummonAreaAuthoring>(authoring, out component3))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<MerchantAuthoring>(authoring, out component4))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<AutomatedMoverAuthoring>(authoring, out component5))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<AutomatedCrafterAuthoring>(authoring, out component6) && !TryGetActiveComponent<CattleAuthoring>(authoring, out component7))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<AutomatedMineableAuthoring>(authoring, out component8))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<AutomatedMinerAuthoring>(authoring, out component9))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<AutomatedStorageAuthoring>(authoring, out component10))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<CanBePickedUpAuthoring>(authoring, out component11))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<ElectricityAuthoring>(authoring, out component12))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<BedAuthoring>(authoring, out component13))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<PlayerGraveAuthoring>(authoring, out component14))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<BossStatueAuthoring>(authoring, out component15))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<TheCoreAuthoring>(authoring, out component16))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<PortalAuthoring>(authoring, out component17))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<SoulOrbAuthoring>(authoring, out component18))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<MapMarkerAuthoring>(authoring, out component19))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<BossSpawnLocationAuthoring>(authoring, out component20))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<SnakeMovementStateAuthoring>(authoring, out component21))
		{
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<PlantAuthoring>(authoring, out component22) && !TryGetActiveComponent<RootPlantAuthoring>(authoring, out component23))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<SeedAuthoring>(authoring, out component24))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
		else if (TryGetActiveComponent<SprinklerAuthoring>(authoring, out component25))
		{
			EnsureHasComponent<DontUnloadCD>();
			SetProperty("dontUnload");
		}
	}
}
