using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class WeaponTypeSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private WeaponType id;

		[SerializeField]
		private AttackType attackType;

		[SerializeField]
		private AttributeType[] damage;

		[SerializeField]
		private AttributeType[] range;

		[SerializeField]
		private AttributeType[] ignoresArmor;

		[SerializeField]
		private AttributeType[] armorDamage;

		[SerializeField]
		private AttributeType[] buildingDamage;

		[SerializeField]
		private AttributeType[] precision;

		[SerializeField]
		private AttributeType[] precisionFallof;

		[SerializeField]
		private AttributeType[] attackSpeed;

		[SerializeField]
		private string[] hitEffectorGroupIDs;

		[SerializeField]
		private string[] criticalHitEffectorGroupIDs;

		[NonSerialized]
		private HitEffector[] onHitEffectors;

		[NonSerialized]
		private HitEffector[] onCriticalHitEffectors;

		public AttackType AttackType => attackType;

		public AttributeType[] Damage => damage;

		public AttributeType[] Range => range;

		public AttributeType[] IgnoresArmor => ignoresArmor;

		public AttributeType[] ArmorDamage => armorDamage;

		public AttributeType[] BuildingDamage => buildingDamage;

		public AttributeType[] Precision => precision;

		public AttributeType[] PrecisionFallof => precisionFallof;

		public AttributeType[] AttackSpeed => attackSpeed;

		public HitEffector[] OnHitEffectors
		{
			get
			{
				if (onHitEffectors == null && hitEffectorGroupIDs != null)
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
				if (onCriticalHitEffectors == null && criticalHitEffectorGroupIDs != null)
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

		public override string GetID()
		{
			int num = (int)id;
			return num.ToString();
		}
	}
}
