using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components.Base;
using NSMedieval.Construction;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class FuelConsumerComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Decoration;

		[SerializeField]
		private string id;

		[SerializeField]
		private ResourceCategory fuelType;

		[SerializeField]
		private StorageBase fuelStorage;

		[SerializeField]
		private float burnRate;

		[SerializeField]
		private float requiredCalories;

		[SerializeField]
		private float refillFactor;

		[SerializeField]
		private SerializableIntStringDictionary thermalModels = SerializableDictionary<int, string>.CreateNew<SerializableIntStringDictionary>();

		[SerializeField]
		private ThermalModelIntensity startingThermalModel;

		[SerializeField]
		private string textKeyOn;

		[SerializeField]
		private string textKeyOff;

		[SerializeField]
		private string infoTextKeyOn;

		[SerializeField]
		private string infoTextKeyOff;

		[SerializeField]
		private string lightCookieId;

		[SerializeField]
		private string prefabId;

		[SerializeField]
		private TransformSettings prefabTransformSettings;

		[NonSerialized]
		private Dictionary<ThermalModelIntensity, ThermalModel> cachedThermalModels;

		public string TextKeyOn => textKeyOn;

		public string TextKeyOff => textKeyOff;

		public string InfoTextKeyOn => infoTextKeyOn;

		public string InfoTextKeyOff => infoTextKeyOff;

		public BuildingType ComponentType => componentType;

		public ResourceCategory FuelType => fuelType;

		public StorageBase FuelStorage => fuelStorage;

		public float BurnRate => burnRate;

		public float RequiredCalories => requiredCalories;

		public float RefillFactor => refillFactor;

		public ThermalModelIntensity StartingThermalModel => startingThermalModel;

		public Dictionary<ThermalModelIntensity, ThermalModel> CachedThermalModels
		{
			get
			{
				if (cachedThermalModels != null && cachedThermalModels.Count > 0)
				{
					return cachedThermalModels;
				}
				cachedThermalModels = new Dictionary<ThermalModelIntensity, ThermalModel>();
				foreach (int key2 in thermalModels.Dictionary.Keys)
				{
					ThermalModelIntensity key = (ThermalModelIntensity)key2;
					ThermalModel byID = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(thermalModels.Dictionary[key2]);
					cachedThermalModels.Add(key, byID);
				}
				return cachedThermalModels;
			}
		}

		public string LightCookieId => lightCookieId;

		public string PrefabId => prefabId;

		public TransformSettings PrefabTransformSettings => prefabTransformSettings;

		public override string GetID()
		{
			return id;
		}
	}
}
