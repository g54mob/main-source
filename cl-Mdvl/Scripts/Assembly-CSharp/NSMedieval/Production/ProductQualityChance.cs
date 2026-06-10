using System;
using NSEipix.Base;
using NSMedieval.Dictionary;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Production
{
	[Serializable]
	public class ProductQualityChance : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private int skillLevel;

		[SerializeField]
		private ProductQualityFloatDictionary qualityChances = SerializableDictionary<ProductQuality, float>.CreateNew<ProductQualityFloatDictionary>();

		public int SkillLevel => skillLevel;

		public ProductQualityFloatDictionary ProductQualityFloatDictionary => qualityChances;

		public override string GetID()
		{
			return id;
		}
	}
}
