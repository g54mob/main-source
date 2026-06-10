using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.GameEventSystem;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("Trebuchet", "")]
	public class Trebuchet : NSEipix.Base.Model, IEnemyPurchaseUnit, IFVSerializable
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string prefabID;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private int price = 100;

		[SerializeField]
		private float priceThreshold = 0.25f;

		[SerializeField]
		private float buildingDamage;

		[SerializeField]
		private float pileDamage;

		[SerializeField]
		private float creatureDamage;

		[SerializeField]
		private float groundDamage;

		[SerializeField]
		private float projectileHitRadius;

		[SerializeField]
		private float damageFalloff;

		[SerializeField]
		private float resourceSpawnAmount;

		[SerializeField]
		private float projectileResourceCost;

		[SerializeField]
		private string ammunitionResourceType;

		[SerializeField]
		private float storageCapacity;

		[SerializeField]
		private string[] hitEffectorGroupIDs;

		[SerializeField]
		private string[] criticalHitEffectorGroupIDs;

		[SerializeField]
		private float targetRandomRadius = 5f;

		[SerializeField]
		private float reloadAnimationSpeed = 1f;

		[SerializeField]
		private float attackAnimationSpeed = 1f;

		[SerializeField]
		private float powerLossAfterHit = 0.25f;

		[NonSerialized]
		private HitEffector[] onHitEffectors;

		[NonSerialized]
		private HitEffector[] onCriticalHitEffectors;

		private ResourceInstance projectileCostResource;

		public string PrefabID => prefabID;

		public float PriceThreshold => priceThreshold;

		public int Price => price;

		public float BuildingDamage => buildingDamage;

		public float CreatureDamage => creatureDamage;

		public float GroundDamage => groundDamage;

		public float ProjectileHitRadius => projectileHitRadius;

		public float DamageFalloff => damageFalloff;

		public float PileDamage => pileDamage;

		public float ResourceSpawnAmount => resourceSpawnAmount;

		public float ProjectileResourceCost => projectileResourceCost;

		public string AmmunitionResourceType => ammunitionResourceType;

		public float StorageCapacity => storageCapacity;

		public HitEffector[] OnHitEffectors
		{
			get
			{
				if (onHitEffectors == null)
				{
					List<HitEffector> list = new List<HitEffector>();
					string[] array = hitEffectorGroupIDs;
					foreach (string text in array)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(text).HitEffectors);
					}
					onHitEffectors = list.ToArray();
				}
				return onHitEffectors;
			}
		}

		public HitEffector[] OnCriticalHitEffectors
		{
			get
			{
				if (onCriticalHitEffectors == null)
				{
					List<HitEffector> list = new List<HitEffector>();
					string[] array = criticalHitEffectorGroupIDs;
					foreach (string text in array)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(text).HitEffectors);
					}
					onCriticalHitEffectors = list.ToArray();
				}
				return onCriticalHitEffectors;
			}
		}

		public float TargetRandomRadius => targetRandomRadius;

		public float AttackAnimationSpeed => attackAnimationSpeed;

		public float ReloadAnimationSpeed => reloadAnimationSpeed;

		public float PowerLossAfterHit => powerLossAfterHit;

		public LocKeys[] LocKeys => locKeys;

		public Trebuchet()
		{
		}

		public override string GetID()
		{
			return id;
		}

		public int GetPrice()
		{
			return Price;
		}

		public float GetPriceThreshold()
		{
			return PriceThreshold;
		}

		public bool IsTrader()
		{
			return false;
		}

		public ResourceInstance ProjectileCostResource()
		{
			if (projectileCostResource == null)
			{
				projectileCostResource = new ResourceInstance(Repository<ResourceRepository, Resource>.Instance.GetByID(ammunitionResourceType), (int)projectileResourceCost);
			}
			return projectileCostResource;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("prefabID", prefabID);
			serializer.Write("locKeys", locKeys);
			serializer.Write("price", price);
			serializer.Write("priceThreshold", priceThreshold);
			serializer.Write("buildingDamage", buildingDamage);
			serializer.Write("pileDamage", pileDamage);
			serializer.Write("creatureDamage", creatureDamage);
			serializer.Write("groundDamage", groundDamage);
			serializer.Write("projectileHitRadius", projectileHitRadius);
			serializer.Write("damageFalloff", damageFalloff);
			serializer.Write("resourceSpawnAmount", resourceSpawnAmount);
			serializer.Write("projectileResourceCost", projectileResourceCost);
			serializer.Write("ammunitionResourceType", ammunitionResourceType);
			serializer.Write("storageCapacity", storageCapacity);
			serializer.Write("hitEffectorGroupIDs", hitEffectorGroupIDs);
			serializer.Write("criticalHitEffectorGroupIDs", criticalHitEffectorGroupIDs);
			serializer.Write("targetRandomRadius", targetRandomRadius);
			serializer.Write("reloadAnimationSpeed", reloadAnimationSpeed);
			serializer.Write("attackAnimationSpeed", attackAnimationSpeed);
			serializer.Write("powerLossAfterHit", powerLossAfterHit);
		}

		public Trebuchet(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			prefabID = deserializer.ReadString("prefabID");
			locKeys = deserializer.ReadObjectArray<LocKeys>("locKeys");
			price = deserializer.ReadInt("price");
			priceThreshold = deserializer.ReadFloat("priceThreshold");
			buildingDamage = deserializer.ReadFloat("buildingDamage");
			pileDamage = deserializer.ReadFloat("pileDamage");
			creatureDamage = deserializer.ReadFloat("creatureDamage");
			groundDamage = deserializer.ReadFloat("groundDamage");
			projectileHitRadius = deserializer.ReadFloat("projectileHitRadius");
			damageFalloff = deserializer.ReadFloat("damageFalloff");
			resourceSpawnAmount = deserializer.ReadFloat("resourceSpawnAmount");
			projectileResourceCost = deserializer.ReadFloat("projectileResourceCost");
			ammunitionResourceType = deserializer.ReadString("ammunitionResourceType");
			storageCapacity = deserializer.ReadFloat("storageCapacity");
			hitEffectorGroupIDs = deserializer.ReadStringArray("hitEffectorGroupIDs");
			criticalHitEffectorGroupIDs = deserializer.ReadStringArray("criticalHitEffectorGroupIDs");
			targetRandomRadius = deserializer.ReadFloat("targetRandomRadius");
			reloadAnimationSpeed = deserializer.ReadFloat("reloadAnimationSpeed");
			attackAnimationSpeed = deserializer.ReadFloat("attackAnimationSpeed");
			powerLossAfterHit = deserializer.ReadFloat("powerLossAfterHit");
		}
	}
}
