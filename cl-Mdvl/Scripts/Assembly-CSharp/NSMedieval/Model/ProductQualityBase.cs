using System;
using NSEipix.Base;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ProductQualityBase : NSEipix.Base.Model
	{
		[SerializeField]
		private ProductQuality productQuality;

		[SerializeField]
		private float hitpointsMultiplier;

		[SerializeField]
		private float wealthPointsMultiplier;

		[SerializeField]
		private float beautyInputAdd;

		[SerializeField]
		private float beautyInputEquippedAdd;

		[SerializeField]
		private float beautyInputOnShelfAdd;

		[SerializeField]
		private float beautyInputInsideAdd;

		public ProductQuality Quality => productQuality;

		public float HitpointsMultiplier => hitpointsMultiplier;

		public float WealthPointsMultiplier => wealthPointsMultiplier;

		public float BeautyInputAdd => beautyInputAdd;

		public float BeautyInputOnShelfAdd => beautyInputOnShelfAdd;

		public float BeautyInputEquippedAdd => beautyInputEquippedAdd;

		public float BeautyInputInsideAdd => beautyInputInsideAdd;

		public override string GetID()
		{
			return string.Empty;
		}
	}
}
