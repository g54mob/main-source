using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Object Model collection asset", fileName = "DV_Object_Model_")]
	public class DVObjectModel : ScriptableObject
	{
		public static DVObjectModel current;

		public List<TrainCarType_v2> carTypes;

		public List<CargoType_v2> cargos;

		public List<ResourceType_v2> resources;

		public List<GeneralLicenseType_v2> generalLicenses;

		public List<JobLicenseType_v2> jobLicenses;

		public List<GarageType_v2> garages;

		[NonSerialized]
		private Dictionary<string, TrainCarType_v2> _carTypesById;

		[NonSerialized]
		private Dictionary<string, TrainCarLivery> _liveriesByID;

		[NonSerialized]
		private Dictionary<string, ResourceType_v2> _resourceTypesById;

		[NonSerialized]
		private Dictionary<string, CargoType_v2> _cargoTypesById;

		[NonSerialized]
		private Dictionary<string, GeneralLicenseType_v2> _generalLicensesById;

		[NonSerialized]
		private Dictionary<string, JobLicenseType_v2> _jobLicensesById;

		[NonSerialized]
		private Dictionary<string, GarageType_v2> _garagesById;

		[NonSerialized]
		private List<TrainCarLivery> _liveries;

		[NonSerialized]
		private List<TrainCarKind> _carKinds;

		[NonSerialized]
		private Dictionary<TrainCarType_v2, List<CargoType_v2>> _carTypeToLoadableCargo;

		[NonSerialized]
		private Dictionary<CargoType_v2, List<TrainCarType_v2>> _cargoToLoadableCarTypes;

		[NonSerialized]
		private Dictionary<TrainCarLivery, GarageType_v2> _carLiveryToGarageRequirement;

		[NonSerialized]
		private Dictionary<TrainCarType, TrainCarLivery> _trainCarType_to_v2;

		[NonSerialized]
		private Dictionary<CargoType, CargoType_v2> _cargoType_to_v2;

		[NonSerialized]
		private Dictionary<ResourceType, ResourceType_v2> _resourceType_to_v2;

		[NonSerialized]
		private Dictionary<GeneralLicenseType, GeneralLicenseType_v2> _generalLicenseType_to_v2;

		[NonSerialized]
		private Dictionary<JobLicenses, JobLicenseType_v2> _jobLicenses_to_v2;

		[NonSerialized]
		private Dictionary<Garage, GarageType_v2> _garage_to_v2;

		public List<TrainCarLivery> Liveries => RecalculateIfNull(ref _liveries);

		public List<TrainCarKind> CarKinds => RecalculateIfNull(ref _carKinds);

		public Dictionary<TrainCarType_v2, List<CargoType_v2>> CarTypeToLoadableCargo => RecalculateIfNull(ref _carTypeToLoadableCargo);

		public Dictionary<CargoType_v2, List<TrainCarType_v2>> CargoToLoadableCarTypes => RecalculateIfNull(ref _cargoToLoadableCarTypes);

		public Dictionary<TrainCarLivery, GarageType_v2> CarLiveryToGarageRequirement => RecalculateIfNull(ref _carLiveryToGarageRequirement);

		public Dictionary<TrainCarType, TrainCarLivery> TrainCarType_to_v2 => RecalculateIfNull(ref _trainCarType_to_v2);

		public Dictionary<CargoType, CargoType_v2> CargoType_to_v2 => RecalculateIfNull(ref _cargoType_to_v2);

		public Dictionary<ResourceType, ResourceType_v2> ResourceType_to_v2 => RecalculateIfNull(ref _resourceType_to_v2);

		public Dictionary<GeneralLicenseType, GeneralLicenseType_v2> GeneralLicenseType_to_v2 => RecalculateIfNull(ref _generalLicenseType_to_v2);

		public Dictionary<JobLicenses, JobLicenseType_v2> JobLicenses_to_v2 => RecalculateIfNull(ref _jobLicenses_to_v2);

		public Dictionary<Garage, GarageType_v2> Garage_to_v2 => RecalculateIfNull(ref _garage_to_v2);

		public bool TryGetCarType(string id, out TrainCarType_v2 carType)
		{
			return RecalculateIfNull(ref _carTypesById).TryGetValue(id, out carType);
		}

		public bool TryGetLivery(string id, out TrainCarLivery livery)
		{
			return RecalculateIfNull(ref _liveriesByID).TryGetValue(id, out livery);
		}

		public bool TryGetResource(string id, out ResourceType_v2 resource)
		{
			return RecalculateIfNull(ref _resourceTypesById).TryGetValue(id, out resource);
		}

		public bool TryGetCargo(string id, out CargoType_v2 cargo)
		{
			return RecalculateIfNull(ref _cargoTypesById).TryGetValue(id, out cargo);
		}

		public bool TryGetGeneralLicense(string id, out GeneralLicenseType_v2 generalLicense)
		{
			return RecalculateIfNull(ref _generalLicensesById).TryGetValue(id, out generalLicense);
		}

		public bool TryGetJobLicense(string id, out JobLicenseType_v2 jobLicense)
		{
			return RecalculateIfNull(ref _jobLicensesById).TryGetValue(id, out jobLicense);
		}

		public bool TryGetGarage(string id, out GarageType_v2 garage)
		{
			return RecalculateIfNull(ref _garagesById).TryGetValue(id, out garage);
		}

		public void RecalculateCaches()
		{
			Debug.Log("Recalculating DVObjectModel caches");
			_liveries = carTypes.SelectMany((TrainCarType_v2 c) => c.liveries).ToList();
			_carKinds = new HashSet<TrainCarKind>(carTypes.Select((TrainCarType_v2 c) => c.kind)).ToList();
			_carTypeToLoadableCargo = carTypes.ToDictionary((TrainCarType_v2 c) => c, (TrainCarType_v2 c) => cargos.Where((CargoType_v2 cg) => cg.loadableCarTypes.Any((CargoType_v2.LoadableInfo lct) => lct.carType == c)).ToList());
			_cargoToLoadableCarTypes = cargos.ToDictionary((CargoType_v2 c) => c, (CargoType_v2 c) => c.loadableCarTypes.Select((CargoType_v2.LoadableInfo lct) => lct.carType).ToList());
			_carLiveryToGarageRequirement = new Dictionary<TrainCarLivery, GarageType_v2>();
			foreach (GarageType_v2 garage in garages)
			{
				TrainCarLivery[] garageCarLiveries = garage.garageCarLiveries;
				foreach (TrainCarLivery key in garageCarLiveries)
				{
					_carLiveryToGarageRequirement.Add(key, garage);
				}
			}
			_carTypesById = carTypes.ToDictionary((TrainCarType_v2 c) => c.id, (TrainCarType_v2 c) => c);
			_liveriesByID = Liveries.ToDictionary((TrainCarLivery l) => l.id, (TrainCarLivery l) => l);
			_resourceTypesById = resources.ToDictionary((ResourceType_v2 r) => r.id, (ResourceType_v2 r) => r);
			_cargoTypesById = cargos.ToDictionary((CargoType_v2 c) => c.id, (CargoType_v2 c) => c);
			_generalLicensesById = generalLicenses.ToDictionary((GeneralLicenseType_v2 l) => l.id, (GeneralLicenseType_v2 l) => l);
			_jobLicensesById = jobLicenses.ToDictionary((JobLicenseType_v2 l) => l.id, (JobLicenseType_v2 l) => l);
			_garagesById = garages.ToDictionary((GarageType_v2 l) => l.id, (GarageType_v2 l) => l);
			RecalculateMapping(ref _trainCarType_to_v2, _liveries);
			RecalculateMapping(ref _cargoType_to_v2, cargos);
			RecalculateMapping(ref _resourceType_to_v2, resources);
			RecalculateMapping(ref _generalLicenseType_to_v2, generalLicenses);
			RecalculateMapping(ref _jobLicenses_to_v2, jobLicenses);
			RecalculateMapping(ref _garage_to_v2, garages);
		}

		private T RecalculateIfNull<T>(ref T obj)
		{
			if (obj == null)
			{
				RecalculateCaches();
			}
			return obj;
		}

		private void RecalculateMapping<Tv1, Tv2>(ref Dictionary<Tv1, Tv2> mapping, List<Tv2> source) where Tv1 : Enum where Tv2 : Thing_v2_from_v1_enum<Tv1>
		{
			mapping = new Dictionary<Tv1, Tv2>();
			foreach (Tv2 item in source)
			{
				mapping.Add(item.v1, item);
			}
		}

		public List<(string errorMessage, UnityEngine.Object context)> Validate()
		{
			List<(string, UnityEngine.Object)> errors = new List<(string, UnityEngine.Object)>();
			ValidateList<TrainCarType_v2>(carTypes, "carTypes");
			ValidateList<CargoType_v2>(cargos, "cargos");
			ValidateList<ResourceType_v2>(resources, "resources");
			ValidateList<GeneralLicenseType_v2>(generalLicenses, "generalLicenses");
			ValidateList<JobLicenseType_v2>(jobLicenses, "jobLicenses");
			ValidateList<GarageType_v2>(garages, "garages");
			ValidateList<TrainCarLivery>(Liveries, "liveries (derived)");
			ValidateList<TrainCarKind>(CarKinds, "car kinds (derived)");
			Thing_v2.ValidateList(CarTypeToLoadableCargo.Keys.ToList(), "carToCargo keys (derived)", ErrorPopulator);
			foreach (List<CargoType_v2> value in CarTypeToLoadableCargo.Values)
			{
				if (value.Count != 0)
				{
					Thing_v2.ValidateList(value, "carToCargo values (derived)", ErrorPopulator);
				}
			}
			Thing_v2.ValidateList(CargoToLoadableCarTypes.Keys.ToList(), "cargoToCar keys (derived)", ErrorPopulator);
			foreach (List<TrainCarType_v2> value2 in CargoToLoadableCarTypes.Values)
			{
				Thing_v2.ValidateList(value2, "cargoToCar values (derived)", ErrorPopulator);
			}
			return errors;
			void ErrorPopulator(string message, UnityEngine.Object context)
			{
				errors.Add((message, this));
			}
			void ValidateList<T>(List<T> list2, string listName) where T : Thing_v2
			{
				Thing_v2.ValidateList(list2, listName, ErrorPopulator);
				if (list2 != null)
				{
					List<(string, UnityEngine.Object)> list3 = list2.Where((T el) => el != null).SelectMany((T el) => el.Validate()).ToList();
					if (list3.Count != 0)
					{
						errors.Add(("'" + listName + "' list contains items with following errors:", this));
						errors.AddRange(list3);
					}
				}
			}
		}
	}
}
