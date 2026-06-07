using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Cargo type", fileName = "CargoType_")]
	public class CargoType_v2 : Thing_v2_from_v1_enum<CargoType>
	{
		[Serializable]
		public class LoadableInfo
		{
			public TrainCarType_v2 carType;

			public GameObject[] cargoPrefabVariants;

			public LoadableInfo(TrainCarType_v2 carType, GameObject[] cargoPrefabVariants)
			{
				this.carType = carType;
				this.cargoPrefabVariants = cargoPrefabVariants;
			}
		}

		public string localizationKeyFull;

		public string localizationKeyShort;

		public Sprite icon;

		public Sprite resourceIcon;

		public float massPerUnit;

		public float fullDamagePrice;

		public float environmentDamagePrice;

		public float sensitivityPaymentModifier = 1f;

		public JobLicenseType_v2[] requiredJobLicenses;

		public LoadableInfo[] loadableCarTypes;

		[NonSerialized]
		private Dictionary<TrainCarType_v2, GameObject[]> _trainCargoToCargoPrefabs;

		public IReadOnlyDictionary<TrainCarType_v2, GameObject[]> TrainCargoToCargoPrefabs => RecalculateIfNull(ref _trainCargoToCargoPrefabs);

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is empty");
			}
			if (v1 == CargoType.None)
			{
				AddError("v1 is default");
			}
			if (string.IsNullOrWhiteSpace(localizationKeyFull))
			{
				AddError("localizationKeyFull is empty");
			}
			if (string.IsNullOrWhiteSpace(localizationKeyShort))
			{
				AddError("localizationKeyShort is empty");
			}
			if (icon == null)
			{
				AddError("icon is null");
			}
			if (resourceIcon == null)
			{
				AddError("resourceIcon is null");
			}
			if (massPerUnit <= 0f)
			{
				AddError("massPerUnit is not set");
			}
			if (fullDamagePrice <= 0f)
			{
				AddError("fullDamagePrice is not set");
			}
			if (environmentDamagePrice < 0f)
			{
				AddError("environmentDamagePrice is negative");
			}
			if (requiredJobLicenses == null)
			{
				AddError("requiredJobLicenses are null");
			}
			else if (sensitivityPaymentModifier > 1f && requiredJobLicenses.FirstOrDefault((JobLicenseType_v2 jl) => jl.id == "Fragile") == null)
			{
				AddError("sensitivityPaymentModifier is > 1, but cargo doesn't require Fragile license");
			}
			if (loadableCarTypes == null || loadableCarTypes.Length == 0)
			{
				AddError("loadableCarTypes is null or empty!");
				return;
			}
			for (int num = 0; num < loadableCarTypes.Length; num++)
			{
				LoadableInfo loadableInfo = loadableCarTypes[num];
				if (loadableInfo.carType == null)
				{
					AddError(string.Format("{0}. entry has {1} null", num, "carType"));
				}
				else if (loadableInfo.cargoPrefabVariants != null)
				{
					if (loadableInfo.cargoPrefabVariants.Count((GameObject el) => el == null) > 0)
					{
						AddError("cargoPrefabVariants has nulls for car type " + loadableInfo.carType.id);
					}
					if (loadableInfo.cargoPrefabVariants.Length > 255)
					{
						AddError(string.Format("{0} has more than {1} elements for car type {2}", "cargoPrefabVariants", byte.MaxValue, loadableInfo.carType.id));
					}
				}
			}
		}

		public bool IsLoadableOnCarType(TrainCarType_v2 carType)
		{
			return Array.Exists(loadableCarTypes, (LoadableInfo ld) => ld.carType == carType);
		}

		public GameObject[] GetCargoPrefabsForCarType(TrainCarType_v2 carType)
		{
			if (!TrainCargoToCargoPrefabs.TryGetValue(carType, out var value))
			{
				return null;
			}
			return value;
		}

		public bool HasVisibleModelForCarType(TrainCarType_v2 carType)
		{
			GameObject[] cargoPrefabsForCarType = GetCargoPrefabsForCarType(carType);
			if (cargoPrefabsForCarType == null)
			{
				return false;
			}
			return cargoPrefabsForCarType.Length != 0;
		}

		private T RecalculateIfNull<T>(ref T obj)
		{
			if (obj != null)
			{
				return obj;
			}
			_trainCargoToCargoPrefabs = loadableCarTypes.ToDictionary((LoadableInfo info) => info.carType, (LoadableInfo info) => info.cargoPrefabVariants);
			return obj;
		}
	}
}
