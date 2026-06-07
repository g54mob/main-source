using System;
using System.Collections.Generic;
using DV;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;

[Serializable]
public class CargoGroup
{
	public List<CargoType> cargoTypes;

	public List<StationController> stations;

	public JobLicenses CargoRequiredLicenses { get; private set; }

	public JobLicenses CarRequiredLicenses { get; private set; }

	public CargoGroup(List<CargoType> cargoTypes, List<StationController> stations)
	{
		this.cargoTypes = cargoTypes;
		this.stations = stations;
	}

	public void InitializeLicenseRequirements()
	{
		LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
		CargoRequiredLicenses = JobLicenseType_v2.ListToFlags(instance.GetRequiredLicensesForCargoTypes(cargoTypes));
		DVObjectModel types = Globals.G.Types;
		HashSet<TrainCarType_v2> hashSet = new HashSet<TrainCarType_v2>();
		foreach (CargoType cargoType in cargoTypes)
		{
			hashSet.UnionWith(types.CargoToLoadableCarTypes[cargoType.ToV2()]);
		}
		CarRequiredLicenses = JobLicenseType_v2.ListToFlags(instance.GetRequiredLicensesForCarTypes(hashSet));
	}
}
