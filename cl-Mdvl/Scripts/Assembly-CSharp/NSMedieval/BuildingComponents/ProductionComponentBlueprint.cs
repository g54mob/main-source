using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class ProductionComponentBlueprint : NSEipix.Base.Model
	{
		[Serializable]
		public class ProductionSpeedMultipliersBySeason
		{
			[SerializeField]
			private string season;

			[SerializeField]
			private List<ProductionSpeedMultiplierTemperature> multipliers;

			public string Season => season;

			public List<ProductionSpeedMultiplierTemperature> Multipliers => multipliers;
		}

		private readonly BuildingType componentType = BuildingType.ProductionBuilding;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> productions = new List<string>();

		[SerializeField]
		private ProductionSpeedMultiplier productionSpeedMultiplier;

		[SerializeField]
		private ProductionSpeedMultiplierSkep productionSpeedMultiplierSkep;

		[SerializeField]
		private List<ProductionSpeedMultiplierTemperature> productionSpeedMultiplierTemperature;

		[SerializeField]
		private List<ProductionSpeedMultipliersBySeason> productionSpeedMultipliersBySeason;

		[SerializeField]
		private string interactTool;

		[SerializeField]
		private string activeThermalModelID = string.Empty;

		[SerializeField]
		private bool canProtectAgainstPredatorsWhileActive;

		[SerializeField]
		private string interactAnimation;

		[SerializeField]
		private string toolSocket;

		[SerializeField]
		private TransformSettings productionMarkerOffset;

		[SerializeField]
		private string productionEffectPrefabId;

		[SerializeField]
		private TransformSettings effectTransformSettings;

		[SerializeField]
		private string productionSound;

		[NonSerialized]
		private ThermalModel thermalModel;

		[NonSerialized]
		private HashSet<int> isSorted = new HashSet<int>();

		[NonSerialized]
		private object isSortedLock = new object();

		public BuildingType ComponentType => componentType;

		public List<string> Productions => productions;

		public ProductionSpeedMultiplier ProductionSpeedMultiplier => productionSpeedMultiplier;

		public ProductionSpeedMultiplierSkep ProductionSpeedMultiplierSkep => productionSpeedMultiplierSkep;

		public string InteractTool => interactTool;

		public string ToolSocket => toolSocket;

		public string InteractAnimation => interactAnimation;

		public bool CanProtectAgainstPredatorsWhileActive => canProtectAgainstPredatorsWhileActive;

		public ThermalModel ThermalModel
		{
			get
			{
				if (thermalModel == null)
				{
					thermalModel = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(activeThermalModelID);
				}
				return thermalModel;
			}
		}

		public TransformSettings ProductionMarkerOffset => productionMarkerOffset;

		public string ProductionEffectPrefabId => productionEffectPrefabId;

		public string ProductionSound => productionSound;

		public TransformSettings EffectTransformSettings => effectTransformSettings;

		public override string GetID()
		{
			return id;
		}

		public float GetSpeedMultiplierForTemperature(float temperature, Season season)
		{
			if (productionSpeedMultiplierTemperature == null || productionSpeedMultiplierTemperature.Count == 0)
			{
				return 1f;
			}
			List<ProductionSpeedMultiplierTemperature> multipliersList = GetMultipliersList(temperature, season);
			TrySortMultipliers(multipliersList);
			return GetMultiplier(temperature, multipliersList);
		}

		private List<ProductionSpeedMultiplierTemperature> GetMultipliersList(float temperature, Season season)
		{
			if (productionSpeedMultipliersBySeason != null)
			{
				foreach (ProductionSpeedMultipliersBySeason item in productionSpeedMultipliersBySeason)
				{
					if (item?.Multipliers != null && item.Multipliers.Count != 0 && string.Equals(season.Name, item.Season))
					{
						return item.Multipliers;
					}
				}
			}
			return productionSpeedMultiplierTemperature;
		}

		private void TrySortMultipliers(List<ProductionSpeedMultiplierTemperature> list)
		{
			lock (isSortedLock)
			{
				if (!isSorted.Contains(list.GetHashCode()))
				{
					isSorted.Add(list.GetHashCode());
					list.Sort((ProductionSpeedMultiplierTemperature a, ProductionSpeedMultiplierTemperature b) => (int)(1000f * (a.Temperature - b.Temperature)));
				}
			}
		}

		private float GetMultiplier(float temperature, List<ProductionSpeedMultiplierTemperature> multipliersList)
		{
			float num = 1f;
			foreach (ProductionSpeedMultiplierTemperature multipliers in multipliersList)
			{
				float num2 = num;
				num *= multipliers.GetMultiplier(temperature);
				if (Math.Abs(num - num2) > 0.0001f)
				{
					break;
				}
			}
			return num;
		}
	}
}
