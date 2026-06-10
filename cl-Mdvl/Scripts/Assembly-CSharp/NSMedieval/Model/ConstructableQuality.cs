using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ConstructableQuality : ProductQualityBase
	{
		[SerializeField]
		private float beautyPointsAdd;

		public float BeautyPointsAdd => beautyPointsAdd;
	}
}
