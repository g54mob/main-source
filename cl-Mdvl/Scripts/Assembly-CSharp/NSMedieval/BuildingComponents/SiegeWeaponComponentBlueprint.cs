using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.GameEventSystem;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class SiegeWeaponComponentBlueprint : NSEipix.Base.Model, IEnemyPurchaseUnit
	{
		private readonly BuildingType componentType = BuildingType.Bed;

		[SerializeField]
		private string id;

		[SerializeField]
		private float projectileSpeed;

		[SerializeField]
		private SiegeWeaponType siegeWeaponType;

		[SerializeField]
		private int price;

		[SerializeField]
		private float priceThreshold;

		[SerializeField]
		private float maxRangeRadius;

		[SerializeField]
		private float minRangeRadius;

		[SerializeField]
		private float projectileHitRadius;

		[SerializeField]
		private IntFloatDictionary rangePerLayer = SerializableDictionary<int, float>.CreateNew<IntFloatDictionary>();

		[SerializeField]
		private float attackAnimationSpeed = 1f;

		[SerializeField]
		private float reloadAnimationSpeed = 1f;

		[SerializeField]
		private float targetRandomRadius = 5f;

		[SerializeField]
		private List<string> storableResourceGroups;

		[SerializeField]
		private List<string> allowedByDefault;

		[SerializeField]
		private List<ResourceGroups> resourceGroups;

		[SerializeField]
		private string windUpAudioEvent;

		[SerializeField]
		private string releaseAudioEvent;

		[NonSerialized]
		private ResourceInstance projectileCostResource;

		public float ProjectileSpeed => projectileSpeed;

		public float MaxRangeRadius => maxRangeRadius;

		public float MinRangeRadius => minRangeRadius;

		public SiegeWeaponType SiegeWeaponType => siegeWeaponType;

		public float ProjectileHitRadius => projectileHitRadius;

		public IntFloatDictionary RangePerLayer => rangePerLayer;

		public float AttackAnimationSpeed => attackAnimationSpeed;

		public float TargetRandomRadius => targetRandomRadius;

		public float ReloadAnimationSpeed => reloadAnimationSpeed;

		public BuildingType ComponentType => componentType;

		public List<string> StorableResourceGroups => storableResourceGroups;

		public List<string> AllowedByDefault => allowedByDefault;

		public List<ResourceGroups> ResourceGroups
		{
			get
			{
				if (resourceGroups == null || resourceGroups.Count == 0)
				{
					InitializeStorableGroups(storableResourceGroups);
				}
				return resourceGroups;
			}
		}

		public string WindUpAudioEvent => windUpAudioEvent;

		public string ReleaseAudioEvent => releaseAudioEvent;

		public bool IsTrader()
		{
			return false;
		}

		public int GetPrice()
		{
			return price;
		}

		public float GetPriceThreshold()
		{
			return priceThreshold;
		}

		public override string GetID()
		{
			return id;
		}

		private void InitializeStorableGroups(List<string> storableGroups)
		{
			foreach (string storableGroup in storableGroups)
			{
				ResourceGroups actualResourceGroup = GetActualResourceGroup(storableGroup);
				if (!(actualResourceGroup == null) && !resourceGroups.Contains(actualResourceGroup))
				{
					resourceGroups.Add(GetActualResourceGroup(storableGroup));
					AddParentsToList(storableGroup);
				}
			}
		}

		private void AddParentsToList(string childNode)
		{
			foreach (ResourceGroups resourceGroup in Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups)
			{
				foreach (string subGroupID in resourceGroup.SubGroupIDs)
				{
					if (subGroupID == childNode && !resourceGroups.Contains(resourceGroup))
					{
						resourceGroups.Add(resourceGroup);
						AddParentsToList(resourceGroup.GetID());
					}
				}
			}
		}

		private ResourceGroups GetActualResourceGroup(string id)
		{
			ResourceGroups resourceGroups = Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups.FirstOrDefault((ResourceGroups x) => x.GetID() == id);
			if (resourceGroups != null)
			{
				if (resourceGroups.SubGroupIDs.Count <= 0)
				{
					return resourceGroups;
				}
				InitializeStorableGroups(resourceGroups.SubGroupIDs);
			}
			return null;
		}
	}
}
